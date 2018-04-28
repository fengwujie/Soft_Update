using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Soft_Update
{
    public partial class frmDownload : Form
    {
        //UpdateDataContract myInfo = new UpdateDataContract();
        public frmDownload()
        {
            InitializeComponent();
        }

        void SetProgressValue(int Value)
        {
            this.progressBar1.Value = Value;
            this.progressBar1.Refresh();
        }

        void AppendMessage(string Message)
        {
            this.txtMsg.AppendText(Message + Environment.NewLine);
            this.txtMsg.Refresh();
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            ////JP.Common.Encrypt.Encrypt ecy = new JP.Common.Encrypt.Encrypt(PublicSetting.Pa, PublicSetting.Pb);
            ////string a = ecy.EncryptString("Data Source=192.0.22.222;Initial Catalog=JP_SOFTWARE;User Id=sa;Password=jp2015;");
            ////string b = ecy.DecryptString(a);
            ////Console.WriteLine(b);
            //bool A = JP.Common.PublicFunctions.IsAppOnRunning("PrescriptionOrder.exe*32");

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += timer_Tick;
            timer.Enabled = true;
            timer.Start();            
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Timer timer = (Timer)sender;
            timer.Stop();
            timer.Enabled = false;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.DoUpgrade();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), this.Text);
            }
            finally
            {
                this.Cursor = Cursors.Default;

                //运行程序
                UpdateDataContract myInfo = this.ReadLocalInformation();
                if (!string.IsNullOrEmpty(myInfo.ExeFile) && System.IO.File.Exists(myInfo.ExeFile))
                {
                    try
                    {
                        if (PublicFunction.IsAppOnRunning(myInfo.ProcessName.Replace(".exe","")) == false)
                        {                            
                            System.Diagnostics.Process.Start(myInfo.ExeFile);
                        }
                    }
                    catch (Exception ex)
                    { }
                    this.Close();
                }
            }
        }

        bool ShowCompleteMessage()
        {
            bool result = true;
            if (System.IO.File.Exists("HideMsg.JP_"))
                result = false;
            return result;
        }

        void DoUpgrade()
        {            
            this.progressBar1.Value = 0;
            this.txtMsg.Clear();

            this.AppendMessage("初始化升级信息...");
            if (this.CheckLicense() == false)
            {
                this.AppendMessage("初始化升级程序出错，请联系管理员.");
                if( string.IsNullOrEmpty( (PublicSetting.ProductCodeExt)))
                    MessageBox.Show("初始化升级程序出错，请联系管理员.");
                return ;
            }
            if (PublicFunction.IsAppOnRunning() == true)
            {
                this.AppendMessage("升级程序运行中，请不要重复运行.");
                if (string.IsNullOrEmpty((PublicSetting.ProductCodeExt)))
                    MessageBox.Show("升级程序运行中，请不要重复运行.");
                this.Close();
            }

            UpdateDataContract myInfo = this.ReadLocalInformation();
            if (string.IsNullOrEmpty(myInfo.ProductCode))
            {
                this.AppendMessage("加载升级信息出错，请联系管理员.");
                if (string.IsNullOrEmpty((PublicSetting.ProductCodeExt)))
                    MessageBox.Show("加载升级信息出错，请联系管理员.");
                return;
            }

            if (! string.IsNullOrEmpty(PublicSetting.ProductCodeExt) && myInfo.ProductCode != PublicSetting.ProductCodeExt)
                this.Close();

            this.SetProgressValue(5);
            this.AppendMessage("读取升级列表中...");

            VersionManager versionMan = new VersionManager();
            myInfo.ServerVersion = versionMan.GetServerVersion(myInfo);
            if (myInfo.ServerVersion == myInfo.LocalVersion)
            {
                this.SetProgressValue(100);
                this.AppendMessage("当前已是最新版本.");
                if (string.IsNullOrEmpty((PublicSetting.ProductCodeExt)))
                {
                    if (ShowCompleteMessage() == true)
                    {
                        MessageBox.Show("当前已是最新版本.");
                    }
                    return;
                }
                else
                {
                    this.Close();
                    return;
                }
            }

            //删除运行中的进程
            PublicFunction.KillProcess(myInfo.ProcessName);
            if( ! string.IsNullOrEmpty(PublicSetting.ProcessNameExt))
                PublicFunction.KillProcess(PublicSetting.ProcessNameExt);

            //开始下载
            this.SetProgressValue(10);
            this.AppendMessage("开始下载升级文件...");
            System.Threading.Thread.Sleep(2000);
            string msg = "";
            List<VersionFileDataContract> fileList = versionMan.GetDownLoadList(myInfo.ProductCode, myInfo.ServerVersion);
            for (int i = 0; i < fileList.Count; i++)
            {
                this.SetProgressValue(10 + (i+1) * 100 / fileList.Count * 9 / 10);
                this.AppendMessage("文件下载中..." + fileList[i].FileName);
                //下载文件
                if (this.WriteFile(versionMan.GetFile(fileList[i]), fileList[i].FileName) == false)
                {
                    if (msg.Length > 0)
                        msg += ";文件下载失败->";
                    msg += fileList[i].FileName;
                }
            }

            if (string.IsNullOrEmpty(msg))
            {
                this.AppendMessage("系统升级完成!");
                if (string.IsNullOrEmpty((PublicSetting.ProductCodeExt)))
                {
                    if (ShowCompleteMessage() == true)
                        MessageBox.Show("系统升级完成!");
                }
                try
                {
                    //升级信息保存到本地
                    this.UpdateUpgradeInformation(myInfo);
                    //System.Diagnostics.Process.Start
                }
                catch (Exception ex)
                { }
            }
            else
            {
                this.AppendMessage("升级失败，参考信息：" + msg);
                if (string.IsNullOrEmpty((PublicSetting.ProductCodeExt)))
                    MessageBox.Show("升级失败，参考信息：" + msg);
            }            
        }

        bool WriteFile(byte[] FileData,string FileName)
        {
            bool result = false;
            try
            {
                if (System.IO.File.Exists(FileName))
                    System.IO.File.Delete(FileName);
                System.IO.FileStream fs = new System.IO.FileStream(FileName, FileMode.CreateNew);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(FileData, 0, FileData.Length);
                bw.Close();
                fs.Close();
                result = true;
            }
            catch (Exception ex)
            { }
            return result;
        }

        UpdateDataContract ReadLocalInformation()
        {
            UpdateDataContract result = new UpdateDataContract();

            if (System.IO.File.Exists("update.xml"))
            {
                DataSet ds = new DataSet();
                ds.ReadXml("update.xml");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    result.ProductCode = ds.Tables[0].Rows[0]["ProductCode"].ToString();
                    result.LocalVersion = ds.Tables[0].Rows[0]["CurrentVersion"].ToString();
                    result.VersionDate = ds.Tables[0].Rows[0]["VersionDate"].ToString();
                    result.ProcessName = ds.Tables[0].Rows[0]["ProcessName"].ToString();
                    result.ExeFile = ds.Tables[0].Rows[0]["ExeFile"].ToString();
                }
            }
            return result;
        }

        void UpdateUpgradeInformation(UpdateDataContract Request)
        {
            try
            {
                if (System.IO.File.Exists("update.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("update.xml");
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Tables[0].Rows[0]["CurrentVersion"] = Request.ServerVersion;
                        ds.Tables[0].Rows[0]["VersionDate"] = System.DateTime.Now.ToString();
                        ds.WriteXml("update.xml");
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        bool CheckLicense()
        {
            bool result = false;
            result = PublicSetting.GetParameterA().Trim().Length > 0;
            return result;
        }
    }
}
