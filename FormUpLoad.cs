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
    public partial class FormUpLoad : Form
    {
        public FormUpLoad()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 产品基础资料表
        /// </summary>
        private DataTable dtProduct = null;
        /// <summary>
        /// 产品默认升级文件资料表
        /// </summary>
        private DataTable dtProductFile = null;
        /// <summary>
        /// 实际升级的版本文件资料
        /// </summary>
        private DataTable dtVersionFile = null;

        private void FormUpLoad_Load(object sender, EventArgs e)
        {
            LoadSourceProduct();
        }

        #region 上传升级文件维护

        /// <summary>
        /// 加载产品列表
        /// </summary>
        private void LoadSourceProduct()
        {
            try
            {
                ProductManager productMan = new ProductManager();
                dtProduct = productMan.GetProductList();
                this.dgvProduct.DataSource = dtProduct;

                if (dtProduct != null)
                {
                    this.cmdProduct.ValueMember = "PRODUCT_CODE";
                    this.cmdProduct.DisplayMember = "PRODUCT_NAME";
                    this.cmdProduct.DataSource = dtProduct.Copy();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                this.txt_ProductVersion.Text = rows[0]["PRODUCT_VERSION2"].ToString();
            }
            LoadProductFile();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.cmdProduct.SelectedValue == null)
            {
                MessageBox.Show("产品名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cmdProduct.Focus();
                return;
            }
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择程序根目录";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txt_ProductFolder.Text = dialog.SelectedPath;
                LoadProductFile();

            }
        }
        /// <summary>
        /// 加载升级文件清单
        /// </summary>
        private void LoadProductFile()
        {
            if (dtVersionFile != null)
                dtVersionFile.Clear();
            else
            {
                VersionFileManager versionMan = new VersionFileManager();
                dtVersionFile = versionMan.GetList("1=2");
                DataColumn col = new DataColumn("bCheck", typeof(bool));
                dtVersionFile.Columns.Add(col);
                this.dgvVERSIONFILE.DataSource = dtVersionFile;
            }
            string folder = txt_ProductFolder.Text.Trim();
            if (folder.Trim().Length == 0) return;
            ProductFileManager pfMan = new ProductFileManager();
            DataTable dtPF = pfMan.GetProductFileList(this.cmdProduct.SelectedValue.ToString());
            foreach(DataRow row in dtPF.Rows)
            {
                //[OBJ_NO],[PRODUCT_CODE],[FILE_VERSION],[FILE_VERSION2],[FILE_NAME],[FILE_PATH],[FILE_DATA],[OBJ_DATE],[REMARK]
                string fileName = folder + @"\" + row["PRODUCT_FILENAME"].ToString();
                if(File.Exists(fileName))
                {
                    DataRow newRow = dtVersionFile.NewRow();
                    newRow["bCheck"] = 1;
                    newRow["OBJ_NO"] = Guid.NewGuid().ToString();
                    newRow["PRODUCT_CODE"] = this.cmdProduct.SelectedValue.ToString();
                    string product_Filename = row["PRODUCT_FILENAME"].ToString();
                    string[] names = product_Filename.Split('\\');
                    newRow["FILE_NAME"] = names[names.Length-1];
                    newRow["FILE_PATH"] = @"\" + product_Filename;
                    newRow["FILE_DATA"] = getFileByte(fileName);
                    dtVersionFile.Rows.Add(newRow);
                }
            }
        }


        /// <summary>
        /// 获取文件的二进制流
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private byte[] getFileByte(string fileName)
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

        private void dgvVERSIONFILE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (this.dgvVERSIONFILE.Columns[e.ColumnIndex].Name == "bCheck")
                {
                    DataRow row = dtVersionFile.Rows[e.RowIndex];
                    row["bCheck"] = !Convert.ToBoolean(row["bCheck"]);
                }
            }
        }
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            if(dtVersionFile!=null)
            {
                foreach (DataRow row in dtVersionFile.Rows)
                    row["bCheck"] = 1;
            }
        }

        private void btnCheckAban_Click(object sender, EventArgs e)
        {
            if (dtVersionFile != null)
            {
                foreach (DataRow row in dtVersionFile.Rows)
                    row["bCheck"] = !Convert.ToBoolean(row["bCheck"]);
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (this.cmdProduct.SelectedValue == null)
            {
                MessageBox.Show("产品名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cmdProduct.Focus();
                return;
            }
            if (dtVersionFile == null)
            {
                VersionFileManager versionMan = new VersionFileManager();
                dtVersionFile = versionMan.GetList("1=2");
                DataColumn col = new DataColumn("bCheck", typeof(bool));
                dtVersionFile.Columns.Add(col);
                this.dgvVERSIONFILE.DataSource = dtVersionFile;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = this.txt_ProductFolder.Text;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                DataRow newRow = dtVersionFile.NewRow();
                newRow["bCheck"] = 1;
                newRow["OBJ_NO"] = Guid.NewGuid().ToString();
                newRow["PRODUCT_CODE"] = this.cmdProduct.SelectedValue.ToString();
                newRow["FILE_NAME"] = openFileDialog.SafeFileName;
                newRow["FILE_PATH"] = fileName.Replace(this.txt_ProductFolder.Text,"");
                newRow["FILE_DATA"] = getFileByte(fileName);
                dtVersionFile.Rows.Add(newRow);
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (this.dgvVERSIONFILE.DataSource == null || this.dgvVERSIONFILE.RowCount == 0)
                return;
            this.dgvVERSIONFILE.Rows.Remove(this.dgvVERSIONFILE.CurrentRow);
            dtVersionFile.AcceptChanges();
        }

        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvVERSIONFILE.DataSource == null || this.dgvVERSIONFILE.RowCount == 0)
                    return;
                if (this.txt_REMARK.Text.Trim().Length == 0)
                {
                    MessageBox.Show("升级说明不允许为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txt_REMARK.Focus();
                    return;
                }
                DataRow[] rows = dtVersionFile.Select("bCheck = 1");
                if (rows.Length == 0)
                {
                    MessageBox.Show("没有选择上传的文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show(string.Format(string.Format("确定要上传【{0}】个升级文件，版本信息【{1}】", rows.Length, this.txt_ProductVersion.Text)), "询问",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
                ProductManager pMan = new ProductManager();
                int iVersion = pMan.GetVersion(this.cmdProduct.SelectedValue.ToString()) + 1;
                VersionFileManager vfMan = new VersionFileManager();
                foreach (DataRow row in rows)
                {
                    row["FILE_VERSION"] = iVersion;
                    row["FILE_VERSION2"] = txt_ProductVersion.Text.Trim();
                    row["REMARK"] = txt_REMARK.Text.Trim();
                    vfMan.UpFile(row);
                }
                MessageBox.Show(string.Format("成功上传升级文件【{0}】个！", rows.Length), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("上传升级文件失败！" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        #endregion
        
        #region 产品基础数据维护
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            DataRow newRow = dtProduct.NewRow();
            newRow["PRODUCT_CODE"] = Guid.NewGuid().ToString();
            newRow["PRODUCT_VERSION"] = 1;
            newRow["PRODUCT_VERSION2"] = "0.0.1";
            dtProduct.Rows.Add(newRow);
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if(this.dgvProduct.RowCount == 0 || this.dgvProduct.CurrentRow == null)
            {
                MessageBox.Show("请先选择要删除的产品数据！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            this.dgvProduct.Rows.Remove(this.dgvProduct.CurrentRow);
        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                ProductManager productMan = new ProductManager();
                foreach (DataRow row in dtProduct.Rows)
                {
                    switch (row.RowState)
                    {
                        case DataRowState.Added:
                            i += productMan.AddProduct(row);
                            break;
                        case DataRowState.Modified:
                            i += productMan.UpdateProduct(row);
                            break;
                        case DataRowState.Deleted:
                            i += productMan.DeleteProduct(row["PRODUCT_CODE", DataRowVersion.Original].ToString());
                            break;
                    }
                }
                dtProduct.AcceptChanges();
                this.cmdProduct.DataSource = dtProduct.Copy();
                MessageBox.Show(string.Format("保存成功，更新【{0}】条数据！", i), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("保存失败！" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 产品默认升级文件维护

        private void LoadSourcePorductFile()
        {
            try
            {
                string product_code = string.Empty;
                if (this.dgvProduct.CurrentRow != null)
                    product_code = this.dgvProduct.CurrentRow.Cells["PRODUCT_CODE"].Value.ToString();
                ProductFileManager man = new ProductFileManager();
                dtProductFile = man.GetProductFileList(product_code);
                this.dgvProductFile.DataSource = dtProductFile;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnAddProductFile_Click(object sender, EventArgs e)
        {
            if (this.dgvProduct.RowCount == 0 || this.dgvProduct.CurrentRow == null)
            {
                MessageBox.Show("请先选择产品数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string Product_Code = this.dgvProduct.CurrentRow.Cells["PRODUCT_CODE"].Value.ToString();
            DataRow newRow = dtProductFile.NewRow();
            newRow["PRODUCT_CODE"] = Product_Code;
            dtProductFile.Rows.Add(newRow);
        }

        private void btnDeleteProductFile_Click(object sender, EventArgs e)
        {
            if (this.dgvProductFile.RowCount == 0 || this.dgvProductFile.CurrentRow == null)
            {
                MessageBox.Show("请先选择要删除的产品数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.dgvProductFile.Rows.Remove(this.dgvProductFile.CurrentRow);
        }

        private void btnSaveProductFile_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                ProductFileManager man = new ProductFileManager();
                foreach (DataRow row in dtProductFile.Rows)
                {
                    switch (row.RowState)
                    {
                        case DataRowState.Added:
                            i += man.AddProductFile(row);
                            break;
                        case DataRowState.Modified:
                            i += man.UpdateProductFile(row);
                            break;
                        case DataRowState.Deleted:
                            i += man.DeleteProductFile(row);
                            break;
                    }
                }
                dtProductFile.AcceptChanges();
                MessageBox.Show(string.Format("保存成功，更新【{0}】条数据！", i), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            LoadSourcePorductFile();
        }
        #endregion

    }
}
