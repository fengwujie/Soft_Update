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
    public partial class frmUpload : Form
    {
        public frmUpload()
        {
            InitializeComponent();
        }

        private void frmUpload_Load(object sender, EventArgs e)
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFile.Text = openFileDialog.FileName;
                this.txtVersion.Tag = openFileDialog.SafeFileName;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (this.cmdProduct.SelectedValue  == null)
            {
                this.cmdProduct.Focus();
                return;
            }

            try
            {
                this.btnUpload.Enabled = false;

                if (this.txtFile.Text.Trim() != "" && System.IO.File.Exists(this.txtFile.Text))
                {
                    byte[] content = null;
                    using (FileStream fs = File.Open(this.txtFile.Text, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None))
                    {
                        content = new Byte[fs.Length];
                        fs.Read(content, 0, content.Length);
                        fs.Close();
                    }

                    VersionManager versionMan = new VersionManager();
                    if (versionMan.UploadFile(this.cmdProduct.SelectedValue.ToString(), this.txtVersion.Tag.ToString(), this.txtVersion.Text, content) == true)
                    {
                        MessageBox.Show("文件上传成功.");
                    }
                    else
                    {
                        MessageBox.Show("文件上传失败.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.btnUpload.Enabled = true;
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
