using Soft_Update;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Soft_Update
{
    public partial class FrmUpFile : Form
    {
        public FrmUpFile()
        {
            InitializeComponent();
        }
        //private List<VersionFileDataContract> listFile = new List<VersionFileDataContract>();
        DataTable dtFile = null;
        private List<string> listFileTypeName = new List<string>();
        private void FrmUpFile_Load(object sender, EventArgs e)
        {
            initTableFile();
            LoadSourceProduct();
            this.checkedListBox1.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            LoadSourceFileType();
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
        }

        private void initTableFile()
        {
            dtFile = new DataTable();
            DataColumn col1 = new DataColumn("Check", typeof(bool));
            DataColumn col2 = new DataColumn("FileName",typeof(string));
            DataColumn col3 = new DataColumn("FilePath",typeof(string));
            DataColumn col4 = new DataColumn("FileByte",typeof(byte[]));
            dtFile.Columns.AddRange(new DataColumn[] { col1,col2,col3,col4});
            this.dataGridView1.DataSource = dtFile;
        }

        /// <summary>
        /// 加载产品列表
        /// </summary>
        private void LoadSourceProduct()
        {
            try
            {
                VersionManager versionMan = new VersionManager();
                DataSet dsList = versionMan.GetProductList();
                if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    this.cmdProduct.ValueMember = "product_code";
                    this.cmdProduct.DisplayMember = "product_name";
                    this.cmdProduct.DataSource = dsList.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 加载需要升级的文件后缀名
        /// </summary>
        private void LoadSourceFileType()
        {
            try
            {
                VersionManager versionMan = new VersionManager();
                List<FileExtensionDataContract> listFileExtension = versionMan.GetFileExtensionList();
                foreach (FileExtensionDataContract fileExtension in listFileExtension)
                    this.checkedListBox1.Items.Add(fileExtension.ExtensionName,true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择程序根目录";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = dialog.SelectedPath;
            }
        }
        //查询文件清单
        private void btnQueryFile_Click(object sender, EventArgs e)
        {
            if(this.txtFile.Text.Length == 0)
            {
                MessageBox.Show("请先选择程序目录！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            queryFile();
        }
        
        private void chkContainSubFolder_CheckedChanged(object sender, EventArgs e)
        {
            //queryFile();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //queryFile();
        }
        /// <summary>
        /// 获取选择的文件类型
        /// </summary>
        private void getCheckFileType()
        {
            listFileTypeName.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (this.checkedListBox1.GetItemChecked(i))
                {
                    listFileTypeName.Add(checkedListBox1.Items[i].ToString());
                }
            }
        }
        /// <summary>
        /// 查询文件
        /// </summary>
        private void queryFile()
        {
            getCheckFileType();
            dtFile.Rows.Clear();
            if (listFileTypeName.Count>0)
                serachFileName(txtFile.Text);
            //this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = dtFile;
            this.dataGridView1.Refresh();
        }

        /// <summary>
        /// 查找文件名
        /// </summary>
        /// <param name="folder">文件夹路径</param>
        private void serachFileName(string folder)
        {
            if(Directory.Exists(folder))
            {
                DirectoryInfo dir = new DirectoryInfo(folder);
                FileInfo[] allFile = dir.GetFiles();
                foreach (FileInfo fi in allFile)
                {
                    if(listFileTypeName.Contains( fi.Extension))
                    {
                        //VersionFileDataContract vFile = new VersionFileDataContract();
                        //vFile.FileName = fi.Name;
                        //vFile.FilePath = fi.FullName.Replace(txtFile.Text,"");
                        //vFile.Check = true;
                        //listFile.Add(vFile);

                        DataRow newRow = dtFile.NewRow();
                        newRow["Check"] = true;
                        newRow["FileName"] = fi.Name;
                        newRow["FilePath"] = fi.FullName.Replace(txtFile.Text, "");
                        newRow["FileByte"] = getByte(fi.FullName);
                        dtFile.Rows.Add(newRow);
                    }
                }
                if (chkContainSubFolder.Checked)
                {
                    DirectoryInfo[] allDir = dir.GetDirectories();
                    foreach (DirectoryInfo dirInfo in allDir)
                    {
                        serachFileName(dirInfo.FullName);
                    }
                }
            }
        }
        /// <summary>
        /// 获取文件的二进制流
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private byte[] getByte(string fileName)
        {
            byte[] content = null;
            using (FileStream fs = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None))
            {
                content = new Byte[fs.Length];
                fs.Read(content, 0, content.Length);
                fs.Close();
            }
            return content;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                if(this.dataGridView1.Columns[e.ColumnIndex].Name == "Check")
                {
                    //VersionFileDataContract vFile = listFile[e.RowIndex];
                    //vFile.Check = !vFile.Check;
                    DataRow row = dtFile.Rows[e.RowIndex];
                    row["Check"] = !Convert.ToBoolean(row["Check"]);
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.cmdProduct.SelectedValue == null)
            {
                MessageBox.Show("系统名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cmdProduct.Focus();
                return;
            }
            string version = txtVersion.Text.Trim();
            if (version.Length == 0)
            {
                MessageBox.Show("版本号不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtVersion.Focus();
                return;
            }
            if (MessageBox.Show(string.Format("确定要上传升级文件到版本号【{0}】吗？", version), "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            VersionManager versionMan = new VersionManager();
            foreach (DataRow row in dtFile.Rows)
            {
                versionMan.UpFile(row, this.cmdProduct.SelectedValue.ToString(), version);
            }
        }

        private void cmdProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmdProduct.DataSource == null && this.cmdProduct.SelectedValue == null)
                return;
            DataTable dt = (DataTable)this.cmdProduct.DataSource;
            DataRow[] rows = dt.Select("product_code ='" + this.cmdProduct.SelectedValue.ToString() + "'");
            if (rows.Length > 0)
            {
                this.txtVersion.Text = rows[0]["version"].ToString();
            }
        }
    }
}
