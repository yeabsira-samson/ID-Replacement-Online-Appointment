namespace IDreplacement
{
    partial class Form3
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
            panel1 = new Panel();
            btnmessage = new Button();
            btnlogout = new Button();
            btnreport = new Button();
            btnview = new Button();
            panel2 = new Panel();
            statusbox = new ComboBox();
            status = new Label();
            btnupdate = new Button();
            dataGridView1 = new DataGridView();
            panel3 = new Panel();
            btnsend = new Button();
            dataGridView2 = new DataGridView();
            btnsearch = new Button();
            txtStudentid = new TextBox();
            Student_id = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LavenderBlush;
            panel1.Controls.Add(btnmessage);
            panel1.Controls.Add(btnlogout);
            panel1.Controls.Add(btnreport);
            panel1.Controls.Add(btnview);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(124, 450);
            panel1.TabIndex = 0;
            // 
            // btnmessage
            // 
            btnmessage.Font = new Font("Times New Roman", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnmessage.Location = new Point(3, 210);
            btnmessage.Name = "btnmessage";
            btnmessage.Size = new Size(112, 34);
            btnmessage.TabIndex = 4;
            btnmessage.Text = "Message";
            btnmessage.UseVisualStyleBackColor = true;
            btnmessage.Click += btnmessage_Click;
            // 
            // btnlogout
            // 
            btnlogout.Font = new Font("Times New Roman", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnlogout.Location = new Point(3, 293);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(112, 34);
            btnlogout.TabIndex = 3;
            btnlogout.Text = "Log Out";
            btnlogout.UseVisualStyleBackColor = true;
            btnlogout.Click += btnlogout_Click;
            // 
            // btnreport
            // 
            btnreport.Font = new Font("Times New Roman", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnreport.Location = new Point(3, 135);
            btnreport.Name = "btnreport";
            btnreport.Size = new Size(112, 34);
            btnreport.TabIndex = 2;
            btnreport.Text = "Report";
            btnreport.UseVisualStyleBackColor = true;
            btnreport.Click += btnreport_Click;
            // 
            // btnview
            // 
            btnview.Font = new Font("Times New Roman", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnview.Location = new Point(3, 63);
            btnview.Name = "btnview";
            btnview.Size = new Size(112, 34);
            btnview.TabIndex = 0;
            btnview.Text = "View ";
            btnview.UseVisualStyleBackColor = true;
            btnview.Click += btnview_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Honeydew;
            panel2.Controls.Add(statusbox);
            panel2.Controls.Add(status);
            panel2.Controls.Add(btnupdate);
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(156, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(632, 410);
            panel2.TabIndex = 1;
            // 
            // statusbox
            // 
            statusbox.Font = new Font("Times New Roman", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            statusbox.FormattingEnabled = true;
            statusbox.Items.AddRange(new object[] { "Accepted", "Completed" });
            statusbox.Location = new Point(90, 294);
            statusbox.Name = "statusbox";
            statusbox.Size = new Size(182, 29);
            statusbox.TabIndex = 3;
            // 
            // status
            // 
            status.AutoSize = true;
            status.Font = new Font("Times New Roman", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            status.Location = new Point(14, 294);
            status.Name = "status";
            status.Size = new Size(56, 21);
            status.TabIndex = 2;
            status.Text = "Status";
            // 
            // btnupdate
            // 
            btnupdate.Font = new Font("Times New Roman", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnupdate.Location = new Point(65, 356);
            btnupdate.Name = "btnupdate";
            btnupdate.Size = new Size(112, 34);
            btnupdate.TabIndex = 1;
            btnupdate.Text = "Update";
            btnupdate.UseVisualStyleBackColor = true;
            btnupdate.Click += update_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(629, 274);
            dataGridView1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Honeydew;
            panel3.Controls.Add(btnsend);
            panel3.Controls.Add(dataGridView2);
            panel3.Controls.Add(btnsearch);
            panel3.Controls.Add(txtStudentid);
            panel3.Controls.Add(Student_id);
            panel3.Location = new Point(150, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(638, 410);
            panel3.TabIndex = 2;
            // 
            // btnsend
            // 
            btnsend.Font = new Font("Times New Roman", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnsend.Location = new Point(318, 76);
            btnsend.Name = "btnsend";
            btnsend.Size = new Size(112, 34);
            btnsend.TabIndex = 4;
            btnsend.Text = "Send";
            btnsend.UseVisualStyleBackColor = true;
            btnsend.Click += send_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(6, 144);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(618, 215);
            dataGridView2.TabIndex = 3;
            // 
            // btnsearch
            // 
            btnsearch.Font = new Font("Times New Roman", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnsearch.Location = new Point(318, 20);
            btnsearch.Name = "btnsearch";
            btnsearch.Size = new Size(112, 34);
            btnsearch.TabIndex = 2;
            btnsearch.Text = "Search";
            btnsearch.UseVisualStyleBackColor = true;
            btnsearch.Click += Search_Click;
            // 
            // txtStudentid
            // 
            txtStudentid.Font = new Font("Times New Roman", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            txtStudentid.Location = new Point(141, 20);
            txtStudentid.Name = "txtStudentid";
            txtStudentid.Size = new Size(150, 28);
            txtStudentid.TabIndex = 1;
            // 
            // Student_id
            // 
            Student_id.AutoSize = true;
            Student_id.Font = new Font("Times New Roman", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Student_id.Location = new Point(23, 27);
            Student_id.Name = "Student_id";
            Student_id.Size = new Size(93, 21);
            Student_id.TabIndex = 0;
            Student_id.Text = "Student Id ";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Adminstrator ";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnlogout;
        private Button btnreport;
        private Button btnview;
        private Button btnmessage;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Label status;
        private Button btnupdate;
        private ComboBox statusbox;
        private Panel panel3;
        private Button btnsearch;
        private TextBox txtStudentid;
        private Label Student_id;
        private Button btnsend;
        private DataGridView dataGridView2;
    }
}