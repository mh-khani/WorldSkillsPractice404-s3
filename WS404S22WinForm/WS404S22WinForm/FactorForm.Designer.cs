namespace WS404S22WinForm
{
    partial class FactorForm
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
            PlaceNameLabel = new Label();
            label2 = new Label();
            BarcodeLbl = new Label();
            dataGridView1 = new DataGridView();
            dataLbl = new Label();
            TimrLbl = new Label();
            NameLbl = new Label();
            label7 = new Label();
            TotalLbl = new Label();
            NumberOfTickets = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // PlaceNameLabel
            // 
            PlaceNameLabel.AutoSize = true;
            PlaceNameLabel.Location = new Point(32, 36);
            PlaceNameLabel.Name = "PlaceNameLabel";
            PlaceNameLabel.Size = new Size(38, 15);
            PlaceNameLabel.TabIndex = 0;
            PlaceNameLabel.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(666, 22);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 1;
            label2.Text = "NumberOfTickets";
            // 
            // BarcodeLbl
            // 
            BarcodeLbl.AutoSize = true;
            BarcodeLbl.Location = new Point(934, 238);
            BarcodeLbl.Name = "BarcodeLbl";
            BarcodeLbl.Size = new Size(38, 15);
            BarcodeLbl.TabIndex = 2;
            BarcodeLbl.Text = "label3";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(32, 66);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(792, 330);
            dataGridView1.TabIndex = 3;
            // 
            // dataLbl
            // 
            dataLbl.AutoSize = true;
            dataLbl.Location = new Point(38, 459);
            dataLbl.Name = "dataLbl";
            dataLbl.Size = new Size(38, 15);
            dataLbl.TabIndex = 4;
            dataLbl.Text = "label4";
            // 
            // TimrLbl
            // 
            TimrLbl.AutoSize = true;
            TimrLbl.Location = new Point(173, 459);
            TimrLbl.Name = "TimrLbl";
            TimrLbl.Size = new Size(38, 15);
            TimrLbl.TabIndex = 5;
            TimrLbl.Text = "label5";
            // 
            // NameLbl
            // 
            NameLbl.AutoSize = true;
            NameLbl.Location = new Point(306, 459);
            NameLbl.Name = "NameLbl";
            NameLbl.Size = new Size(38, 15);
            NameLbl.TabIndex = 6;
            NameLbl.Text = "label6";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(37, 411);
            label7.Name = "label7";
            label7.Size = new Size(33, 15);
            label7.TabIndex = 7;
            label7.Text = "Total";
            // 
            // TotalLbl
            // 
            TotalLbl.AutoSize = true;
            TotalLbl.Location = new Point(101, 411);
            TotalLbl.Name = "TotalLbl";
            TotalLbl.Size = new Size(38, 15);
            TotalLbl.TabIndex = 8;
            TotalLbl.Text = "label8";
            // 
            // NumberOfTickets
            // 
            NumberOfTickets.AutoSize = true;
            NumberOfTickets.Location = new Point(786, 22);
            NumberOfTickets.Name = "NumberOfTickets";
            NumberOfTickets.Size = new Size(38, 15);
            NumberOfTickets.TabIndex = 9;
            NumberOfTickets.Text = "label9";
            // 
            // FactorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1113, 515);
            Controls.Add(NumberOfTickets);
            Controls.Add(TotalLbl);
            Controls.Add(label7);
            Controls.Add(NameLbl);
            Controls.Add(TimrLbl);
            Controls.Add(dataLbl);
            Controls.Add(dataGridView1);
            Controls.Add(BarcodeLbl);
            Controls.Add(label2);
            Controls.Add(PlaceNameLabel);
            Name = "FactorForm";
            Text = "FactorForm";
            Load += FactorForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PlaceNameLabel;
        private Label label2;
        private Label BarcodeLbl;
        private DataGridView dataGridView1;
        private Label dataLbl;
        private Label TimrLbl;
        private Label NameLbl;
        private Label label7;
        private Label TotalLbl;
        private Label NumberOfTickets;
    }
}