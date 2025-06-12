namespace testapibuoi6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            #endregion
            dataGridView1 = new DataGridView();
            buttonGet = new Button();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            textBoxId = new TextBox();
            textBoxName = new TextBox();
            textBoxPrice = new TextBox();
            textBoxDescription = new TextBox();
            labelId = new Label();
            labelName = new Label();
            labelPrice = new Label();
            labelDescription = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // dataGridView1
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(20, 200);
            dataGridView1.Size = new Size(740, 200);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.TabIndex = 0;
            // buttonGet
            buttonGet.Text = "Lấy SP";
            buttonGet.Location = new Point(20, 420);
            buttonGet.Click += buttonGet_Click;
            // buttonAdd
            buttonAdd.Text = "Thêm SP";
            buttonAdd.Location = new Point(120, 420);
            buttonAdd.Click += buttonAdd_Click;
            // buttonUpdate
            buttonUpdate.Text = "Sửa SP";
            buttonUpdate.Location = new Point(220, 420);
            buttonUpdate.Click += buttonUpdate_Click;
            // buttonDelete
            buttonDelete.Text = "Xoá SP";
            buttonDelete.Location = new Point(320, 420);
            buttonDelete.Click += buttonDelete_Click;
            // textBoxId
            textBoxId.Location = new Point(100, 20);
            textBoxId.Name = "textBoxId";
            // textBoxName
            textBoxName.Location = new Point(100, 60);
            textBoxName.Name = "textBoxName";
            // textBoxPrice
            textBoxPrice.Location = new Point(100, 100);
            textBoxPrice.Name = "textBoxPrice";
            // textBoxDescription
            textBoxDescription.Location = new Point(100, 140);
            textBoxDescription.Name = "textBoxDescription";
            // labelId
            labelId.Text = "ID:";
            labelId.Location = new Point(20, 20);
            // labelName
            labelName.Text = "Tên SP:";
            labelName.Location = new Point(20, 60);
            textBoxSearch = new TextBox();
            textBoxSearch.Location = new Point(500, 20);
            textBoxSearch.Size = new Size(180, 23);
            textBoxSearch.Name = "textBoxSearch";
            // buttonSearch
            buttonSearch = new Button();
            buttonSearch.Text = "Tìm kiếm";
            buttonSearch.Location = new Point(690, 20);
            buttonSearch.Click += buttonSearch_Click;
            // Add to Form controls
            Controls.Add(textBoxSearch);
            Controls.Add(buttonSearch);
            // labelPrice
            labelPrice.Text = "Giá:";
            labelPrice.Location = new Point(20, 100);
            // labelDescription
            labelDescription.Text = "Mô tả:";
            labelDescription.Location = new Point(20, 140);
            // Form1
            ClientSize = new Size(800, 500);
            Controls.Add(dataGridView1);
            Controls.Add(buttonGet);
            Controls.Add(buttonAdd);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonDelete);
            Controls.Add(textBoxId);
            Controls.Add(textBoxName);
            Controls.Add(textBoxPrice);
            Controls.Add(textBoxDescription);
            Controls.Add(labelId);
            Controls.Add(labelName);
            Controls.Add(labelPrice);
            Controls.Add(labelDescription);
            Text = "Quản lý Sản phẩm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // Khai báo biến controls
        private DataGridView dataGridView1;
private Button buttonGet;
private Button buttonAdd;
private Button buttonUpdate;
private Button buttonDelete;
private TextBox textBoxId;
private TextBox textBoxName;
private TextBox textBoxPrice;
private TextBox textBoxDescription;
private Label labelId;
private Label labelName;
private Label labelPrice;
private Label labelDescription;
        private TextBox textBoxSearch;
        private Button buttonSearch;

    }
}
