namespace WS404S22WinForm
{
    partial class BuyTicketForm
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
            dataGridView1 = new DataGridView();
            PlaceNameTxt = new Label();
            label1 = new Label();
            SumLbl = new Label();
            dateLbl = new Label();
            TimeLbl = new Label();
            nemLbl = new Label();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(71, 90);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(766, 417);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // PlaceNameTxt
            // 
            PlaceNameTxt.AutoSize = true;
            PlaceNameTxt.Location = new Point(71, 61);
            PlaceNameTxt.Name = "PlaceNameTxt";
            PlaceNameTxt.Size = new Size(38, 15);
            PlaceNameTxt.TabIndex = 1;
            PlaceNameTxt.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 534);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 2;
            label1.Text = "Sum factore:";
            // 
            // SumLbl
            // 
            SumLbl.AutoSize = true;
            SumLbl.Location = new Point(151, 534);
            SumLbl.Name = "SumLbl";
            SumLbl.Size = new Size(74, 15);
            SumLbl.TabIndex = 2;
            SumLbl.Text = "Sum factore:";
            // 
            // dateLbl
            // 
            dateLbl.AutoSize = true;
            dateLbl.Location = new Point(892, 21);
            dateLbl.Name = "dateLbl";
            dateLbl.Size = new Size(38, 15);
            dateLbl.TabIndex = 3;
            dateLbl.Text = "label2";
            // 
            // TimeLbl
            // 
            TimeLbl.AutoSize = true;
            TimeLbl.Location = new Point(972, 21);
            TimeLbl.Name = "TimeLbl";
            TimeLbl.Size = new Size(38, 15);
            TimeLbl.TabIndex = 3;
            TimeLbl.Text = "label2";
            // 
            // nemLbl
            // 
            nemLbl.AutoSize = true;
            nemLbl.Location = new Point(892, 51);
            nemLbl.Name = "nemLbl";
            nemLbl.Size = new Size(38, 15);
            nemLbl.TabIndex = 3;
            nemLbl.Text = "label2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(911, 218);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 3;
            label2.Text = "numberOfTickets";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(911, 276);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 4;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // button1
            // 
            button1.Location = new Point(902, 451);
            button1.Name = "button1";
            button1.Size = new Size(129, 81);
            button1.TabIndex = 5;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // BuyTicketForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 592);
            Controls.Add(button1);
            Controls.Add(numericUpDown1);
            Controls.Add(TimeLbl);
            Controls.Add(label2);
            Controls.Add(nemLbl);
            Controls.Add(dateLbl);
            Controls.Add(SumLbl);
            Controls.Add(label1);
            Controls.Add(PlaceNameTxt);
            Controls.Add(dataGridView1);
            Name = "BuyTicketForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "BuyTicketForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label PlaceNameTxt;
        private Label label1;
        private Label SumLbl;
        private Label dateLbl;
        private Label TimeLbl;
        private Label nemLbl;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Button button1;
    }
}