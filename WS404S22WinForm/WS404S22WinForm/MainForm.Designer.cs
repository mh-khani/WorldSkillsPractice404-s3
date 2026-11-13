namespace WS404S22WinForm
{
    partial class MainForm
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
            dataGridView1 = new DataGridView();
            LblDate = new Label();
            Lbltime = new Label();
            label1 = new Label();
            comboBox1 = new ComboBox();
            LblName = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 91);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(895, 421);
            dataGridView1.TabIndex = 0;
            // 
            // LblDate
            // 
            LblDate.AutoSize = true;
            LblDate.Location = new Point(726, 22);
            LblDate.Name = "LblDate";
            LblDate.Size = new Size(38, 15);
            LblDate.TabIndex = 1;
            LblDate.Text = "label1";
            // 
            // Lbltime
            // 
            Lbltime.AutoSize = true;
            Lbltime.Location = new Point(840, 22);
            Lbltime.Name = "Lbltime";
            Lbltime.Size = new Size(38, 15);
            Lbltime.TabIndex = 1;
            Lbltime.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 57);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 1;
            label1.Text = "Rows Count";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "10", "20", "50" });
            comboBox1.Location = new Point(89, 54);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "10";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // LblName
            // 
            LblName.AutoSize = true;
            LblName.Location = new Point(12, 9);
            LblName.Name = "LblName";
            LblName.Size = new Size(38, 15);
            LblName.TabIndex = 1;
            LblName.Text = "label1";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(12, 518);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(895, 43);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 573);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(Lbltime);
            Controls.Add(LblName);
            Controls.Add(LblDate);
            Controls.Add(dataGridView1);
            Name = "MainForm";
            Text = "Main Form";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label LblDate;
        private Label Lbltime;
        private Label label1;
        private ComboBox comboBox1;
        private Label LblName;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
