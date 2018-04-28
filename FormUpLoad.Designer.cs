namespace Soft_Update
{
    partial class FormUpLoad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvVERSIONFILE = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpLoad = new System.Windows.Forms.Button();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnCheckAban = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txt_ProductFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdProduct = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ProductVersion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSaveProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvProductFile = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSaveProductFile = new System.Windows.Forms.Button();
            this.btnDeleteProductFile = new System.Windows.Forms.Button();
            this.btnAddProductFile = new System.Windows.Forms.Button();
            this.PRODUCT_FILENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_CODE2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_REMARK = new System.Windows.Forms.TextBox();
            this.bCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OBJ_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_CODE3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FILE_VERSION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FILE_VERSION2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FILE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FILE_PATH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FILE_DATA = new System.Windows.Forms.DataGridViewImageColumn();
            this.OBJ_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REMARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRCESS_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_VERSION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_VERSION2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVERSIONFILE)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductFile)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1254, 662);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvVERSIONFILE);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1246, 633);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "上传升级文件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvVERSIONFILE
            // 
            this.dgvVERSIONFILE.AllowUserToAddRows = false;
            this.dgvVERSIONFILE.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvVERSIONFILE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVERSIONFILE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bCheck,
            this.OBJ_NO,
            this.PRODUCT_CODE3,
            this.FILE_VERSION,
            this.FILE_VERSION2,
            this.FILE_NAME,
            this.FILE_PATH,
            this.FILE_DATA,
            this.OBJ_DATE,
            this.REMARK});
            this.dgvVERSIONFILE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVERSIONFILE.Location = new System.Drawing.Point(3, 90);
            this.dgvVERSIONFILE.Name = "dgvVERSIONFILE";
            this.dgvVERSIONFILE.RowTemplate.Height = 27;
            this.dgvVERSIONFILE.Size = new System.Drawing.Size(951, 540);
            this.dgvVERSIONFILE.TabIndex = 13;
            this.dgvVERSIONFILE.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVERSIONFILE_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnUpLoad);
            this.panel2.Controls.Add(this.btnDeleteFile);
            this.panel2.Controls.Add(this.btnAddFile);
            this.panel2.Controls.Add(this.btnCheckAban);
            this.panel2.Controls.Add(this.btnCheckAll);
            this.panel2.Controls.Add(this.btnSelect);
            this.panel2.Controls.Add(this.txt_ProductFolder);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cmdProduct);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_ProductVersion);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1240, 87);
            this.panel2.TabIndex = 12;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(549, 45);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 34);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "退出程序";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpLoad
            // 
            this.btnUpLoad.Location = new System.Drawing.Point(429, 45);
            this.btnUpLoad.Name = "btnUpLoad";
            this.btnUpLoad.Size = new System.Drawing.Size(88, 34);
            this.btnUpLoad.TabIndex = 19;
            this.btnUpLoad.Text = "上传升级";
            this.btnUpLoad.UseVisualStyleBackColor = true;
            this.btnUpLoad.Click += new System.EventHandler(this.btnUpLoad_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Location = new System.Drawing.Point(316, 45);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(88, 34);
            this.btnDeleteFile.TabIndex = 18;
            this.btnDeleteFile.Text = "删除文件";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(202, 45);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(88, 34);
            this.btnAddFile.TabIndex = 17;
            this.btnAddFile.Text = "新增文件";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnCheckAban
            // 
            this.btnCheckAban.Location = new System.Drawing.Point(106, 45);
            this.btnCheckAban.Name = "btnCheckAban";
            this.btnCheckAban.Size = new System.Drawing.Size(75, 34);
            this.btnCheckAban.TabIndex = 16;
            this.btnCheckAban.Text = "反选";
            this.btnCheckAban.UseVisualStyleBackColor = true;
            this.btnCheckAban.Click += new System.EventHandler(this.btnCheckAban_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Location = new System.Drawing.Point(14, 45);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(75, 34);
            this.btnCheckAll.TabIndex = 15;
            this.btnCheckAll.Text = "全选";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("宋体", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelect.Location = new System.Drawing.Point(1173, 12);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(35, 29);
            this.btnSelect.TabIndex = 13;
            this.btnSelect.Text = "...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txt_ProductFolder
            // 
            this.txt_ProductFolder.BackColor = System.Drawing.Color.White;
            this.txt_ProductFolder.ForeColor = System.Drawing.Color.Black;
            this.txt_ProductFolder.Location = new System.Drawing.Point(684, 14);
            this.txt_ProductFolder.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ProductFolder.Name = "txt_ProductFolder";
            this.txt_ProductFolder.ReadOnly = true;
            this.txt_ProductFolder.Size = new System.Drawing.Size(481, 25);
            this.txt_ProductFolder.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(600, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "程序目录：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdProduct
            // 
            this.cmdProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdProduct.FormattingEnabled = true;
            this.cmdProduct.Location = new System.Drawing.Point(94, 15);
            this.cmdProduct.Margin = new System.Windows.Forms.Padding(4);
            this.cmdProduct.Name = "cmdProduct";
            this.cmdProduct.Size = new System.Drawing.Size(310, 23);
            this.cmdProduct.TabIndex = 8;
            this.cmdProduct.SelectedIndexChanged += new System.EventHandler(this.cmdProduct_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "产品名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_ProductVersion
            // 
            this.txt_ProductVersion.Location = new System.Drawing.Point(491, 14);
            this.txt_ProductVersion.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ProductVersion.Name = "txt_ProductVersion";
            this.txt_ProductVersion.Size = new System.Drawing.Size(89, 25);
            this.txt_ProductVersion.TabIndex = 9;
            this.txt_ProductVersion.Text = "1.0.1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(426, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "版本号：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1246, 633);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "产品升级文件配置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1240, 627);
            this.splitContainer1.SplitterDistance = 929;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvProduct);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(929, 627);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "产品基础数据维护";
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRODUCT_CODE,
            this.PRODUCT_NAME,
            this.PRCESS_NAME,
            this.PRODUCT_VERSION,
            this.PRODUCT_VERSION2});
            this.dgvProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduct.Location = new System.Drawing.Point(3, 67);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.RowHeadersWidth = 30;
            this.dgvProduct.RowTemplate.Height = 27;
            this.dgvProduct.Size = new System.Drawing.Size(923, 557);
            this.dgvProduct.TabIndex = 1;
            this.dgvProduct.SelectionChanged += new System.EventHandler(this.dgvProduct_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSaveProduct);
            this.panel1.Controls.Add(this.btnDeleteProduct);
            this.panel1.Controls.Add(this.btnAddProduct);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 46);
            this.panel1.TabIndex = 0;
            // 
            // btnSaveProduct
            // 
            this.btnSaveProduct.Location = new System.Drawing.Point(211, 4);
            this.btnSaveProduct.Name = "btnSaveProduct";
            this.btnSaveProduct.Size = new System.Drawing.Size(75, 36);
            this.btnSaveProduct.TabIndex = 2;
            this.btnSaveProduct.Text = "保存";
            this.btnSaveProduct.UseVisualStyleBackColor = true;
            this.btnSaveProduct.Click += new System.EventHandler(this.btnSaveProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(115, 4);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(75, 36);
            this.btnDeleteProduct.TabIndex = 1;
            this.btnDeleteProduct.Text = "删除";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(17, 4);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 36);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "新增";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvProductFile);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 627);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "产品默认升级文件列表";
            // 
            // dgvProductFile
            // 
            this.dgvProductFile.AllowUserToAddRows = false;
            this.dgvProductFile.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvProductFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRODUCT_FILENAME,
            this.PRODUCT_CODE2});
            this.dgvProductFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductFile.Location = new System.Drawing.Point(3, 67);
            this.dgvProductFile.Name = "dgvProductFile";
            this.dgvProductFile.RowTemplate.Height = 27;
            this.dgvProductFile.Size = new System.Drawing.Size(301, 557);
            this.dgvProductFile.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSaveProductFile);
            this.panel3.Controls.Add(this.btnDeleteProductFile);
            this.panel3.Controls.Add(this.btnAddProductFile);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(301, 46);
            this.panel3.TabIndex = 1;
            // 
            // btnSaveProductFile
            // 
            this.btnSaveProductFile.Location = new System.Drawing.Point(213, 4);
            this.btnSaveProductFile.Name = "btnSaveProductFile";
            this.btnSaveProductFile.Size = new System.Drawing.Size(75, 36);
            this.btnSaveProductFile.TabIndex = 2;
            this.btnSaveProductFile.Text = "保存";
            this.btnSaveProductFile.UseVisualStyleBackColor = true;
            this.btnSaveProductFile.Click += new System.EventHandler(this.btnSaveProductFile_Click);
            // 
            // btnDeleteProductFile
            // 
            this.btnDeleteProductFile.Location = new System.Drawing.Point(115, 4);
            this.btnDeleteProductFile.Name = "btnDeleteProductFile";
            this.btnDeleteProductFile.Size = new System.Drawing.Size(75, 36);
            this.btnDeleteProductFile.TabIndex = 1;
            this.btnDeleteProductFile.Text = "删除";
            this.btnDeleteProductFile.UseVisualStyleBackColor = true;
            this.btnDeleteProductFile.Click += new System.EventHandler(this.btnDeleteProductFile_Click);
            // 
            // btnAddProductFile
            // 
            this.btnAddProductFile.Location = new System.Drawing.Point(17, 4);
            this.btnAddProductFile.Name = "btnAddProductFile";
            this.btnAddProductFile.Size = new System.Drawing.Size(75, 36);
            this.btnAddProductFile.TabIndex = 0;
            this.btnAddProductFile.Text = "新增";
            this.btnAddProductFile.UseVisualStyleBackColor = true;
            this.btnAddProductFile.Click += new System.EventHandler(this.btnAddProductFile_Click);
            // 
            // PRODUCT_FILENAME
            // 
            this.PRODUCT_FILENAME.DataPropertyName = "PRODUCT_FILENAME";
            this.PRODUCT_FILENAME.HeaderText = "文件名（程序根目录下的文件名，有子文件夹需要把子文件夹路径一起写上）";
            this.PRODUCT_FILENAME.Name = "PRODUCT_FILENAME";
            this.PRODUCT_FILENAME.Width = 250;
            // 
            // PRODUCT_CODE2
            // 
            this.PRODUCT_CODE2.DataPropertyName = "PRODUCT_CODE";
            this.PRODUCT_CODE2.HeaderText = "产品内码";
            this.PRODUCT_CODE2.Name = "PRODUCT_CODE2";
            this.PRODUCT_CODE2.ReadOnly = true;
            this.PRODUCT_CODE2.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_REMARK);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(954, 90);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(289, 540);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "升级说明";
            // 
            // txt_REMARK
            // 
            this.txt_REMARK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_REMARK.Location = new System.Drawing.Point(3, 21);
            this.txt_REMARK.Multiline = true;
            this.txt_REMARK.Name = "txt_REMARK";
            this.txt_REMARK.Size = new System.Drawing.Size(283, 516);
            this.txt_REMARK.TabIndex = 0;
            // 
            // bCheck
            // 
            this.bCheck.DataPropertyName = "bCheck";
            this.bCheck.HeaderText = "选择";
            this.bCheck.Name = "bCheck";
            this.bCheck.ReadOnly = true;
            this.bCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.bCheck.Width = 80;
            // 
            // OBJ_NO
            // 
            this.OBJ_NO.DataPropertyName = "OBJ_NO";
            this.OBJ_NO.HeaderText = "文件内码";
            this.OBJ_NO.Name = "OBJ_NO";
            this.OBJ_NO.ReadOnly = true;
            this.OBJ_NO.Visible = false;
            // 
            // PRODUCT_CODE3
            // 
            this.PRODUCT_CODE3.DataPropertyName = "PRODUCT_CODE";
            this.PRODUCT_CODE3.HeaderText = "产品内码";
            this.PRODUCT_CODE3.Name = "PRODUCT_CODE3";
            this.PRODUCT_CODE3.ReadOnly = true;
            this.PRODUCT_CODE3.Visible = false;
            // 
            // FILE_VERSION
            // 
            this.FILE_VERSION.DataPropertyName = "FILE_VERSION";
            this.FILE_VERSION.HeaderText = "版本号";
            this.FILE_VERSION.Name = "FILE_VERSION";
            this.FILE_VERSION.ReadOnly = true;
            this.FILE_VERSION.Visible = false;
            // 
            // FILE_VERSION2
            // 
            this.FILE_VERSION2.DataPropertyName = "FILE_VERSION2";
            this.FILE_VERSION2.HeaderText = "版本信息";
            this.FILE_VERSION2.Name = "FILE_VERSION2";
            this.FILE_VERSION2.ReadOnly = true;
            this.FILE_VERSION2.Visible = false;
            // 
            // FILE_NAME
            // 
            this.FILE_NAME.DataPropertyName = "FILE_NAME";
            this.FILE_NAME.HeaderText = "文件名";
            this.FILE_NAME.Name = "FILE_NAME";
            this.FILE_NAME.ReadOnly = true;
            this.FILE_NAME.Width = 150;
            // 
            // FILE_PATH
            // 
            this.FILE_PATH.DataPropertyName = "FILE_PATH";
            this.FILE_PATH.HeaderText = "路径";
            this.FILE_PATH.Name = "FILE_PATH";
            this.FILE_PATH.ReadOnly = true;
            this.FILE_PATH.Width = 300;
            // 
            // FILE_DATA
            // 
            this.FILE_DATA.DataPropertyName = "FILE_DATA";
            this.FILE_DATA.HeaderText = "文件流";
            this.FILE_DATA.Name = "FILE_DATA";
            this.FILE_DATA.ReadOnly = true;
            this.FILE_DATA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FILE_DATA.Visible = false;
            // 
            // OBJ_DATE
            // 
            this.OBJ_DATE.DataPropertyName = "OBJ_DATE";
            this.OBJ_DATE.HeaderText = "上传时间";
            this.OBJ_DATE.Name = "OBJ_DATE";
            this.OBJ_DATE.ReadOnly = true;
            this.OBJ_DATE.Visible = false;
            // 
            // REMARK
            // 
            this.REMARK.DataPropertyName = "REMARK";
            this.REMARK.HeaderText = "升级说明";
            this.REMARK.Name = "REMARK";
            this.REMARK.ReadOnly = true;
            this.REMARK.Visible = false;
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.DataPropertyName = "PRODUCT_CODE";
            this.PRODUCT_CODE.HeaderText = "产品代码";
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.ReadOnly = true;
            this.PRODUCT_CODE.Visible = false;
            this.PRODUCT_CODE.Width = 230;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.PRODUCT_NAME.HeaderText = "产品名称";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.Width = 200;
            // 
            // PRCESS_NAME
            // 
            this.PRCESS_NAME.DataPropertyName = "PRCESS_NAME";
            this.PRCESS_NAME.HeaderText = "进程名称";
            this.PRCESS_NAME.Name = "PRCESS_NAME";
            this.PRCESS_NAME.Width = 150;
            // 
            // PRODUCT_VERSION
            // 
            this.PRODUCT_VERSION.DataPropertyName = "PRODUCT_VERSION";
            this.PRODUCT_VERSION.HeaderText = "产品版本";
            this.PRODUCT_VERSION.Name = "PRODUCT_VERSION";
            this.PRODUCT_VERSION.ReadOnly = true;
            this.PRODUCT_VERSION.Visible = false;
            this.PRODUCT_VERSION.Width = 130;
            // 
            // PRODUCT_VERSION2
            // 
            this.PRODUCT_VERSION2.DataPropertyName = "PRODUCT_VERSION2";
            this.PRODUCT_VERSION2.HeaderText = "版本信息";
            this.PRODUCT_VERSION2.Name = "PRODUCT_VERSION2";
            // 
            // FormUpLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 662);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormUpLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "升级系统上传文件管理";
            this.Load += new System.EventHandler(this.FormUpLoad_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVERSIONFILE)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductFile)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSaveProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmdProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ProductVersion;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txt_ProductFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnUpLoad;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnCheckAban;
        private System.Windows.Forms.DataGridView dgvVERSIONFILE;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDeleteProductFile;
        private System.Windows.Forms.Button btnAddProductFile;
        private System.Windows.Forms.DataGridView dgvProductFile;
        private System.Windows.Forms.Button btnSaveProductFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_FILENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_REMARK;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBJ_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE3;
        private System.Windows.Forms.DataGridViewTextBoxColumn FILE_VERSION;
        private System.Windows.Forms.DataGridViewTextBoxColumn FILE_VERSION2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FILE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn FILE_PATH;
        private System.Windows.Forms.DataGridViewImageColumn FILE_DATA;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBJ_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMARK;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRCESS_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_VERSION;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_VERSION2;
    }
}