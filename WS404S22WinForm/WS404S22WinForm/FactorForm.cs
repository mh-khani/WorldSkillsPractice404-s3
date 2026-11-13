using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http.Json;
using System.Text;
using System.Windows.Forms;
using WS404S22WinForm.DTO;
using static System.Collections.Specialized.BitVector32;

namespace WS404S22WinForm
{
    public partial class FactorForm : Form
    {
        public FactorForm()
        {
            InitializeComponent();
        }

        public List<TicketSectionDetail> sectionDetails = new();
        public int TicketId;

        private async Task LoadDashboard()
        {
            var response = await APi.LoadDashboardData();

            if (response == null) return;

            NameLbl.Text = response.Name;
            TimrLbl.Text = response.Time.ToString();
            dataLbl.Text = response.Date;
        }

        private void FactorForm_Load(object sender, EventArgs e)
        {
            LoadDashboard();
            LoadData();
        }
        async void LoadData()
        {
            try
            {
                var response = await APi.client.GetFromJsonAsync<PrintDTO>($"/tickets/{TicketId}/print");

                if (response == null)
                {
                    MessageBox.Show("Erro");
                    return;
                }
                PlaceNameLabel.Text = response.PlaceName;
                NumberOfTickets.Text = response.NumberOfTickets.ToString();
                TotalLbl.Text = response.Total.ToString();
                BarcodeLbl.Text = response.Barcode;
                sectionDetails = response.SectionDetailss;
                fillData();

            }
            catch
            {
                MessageBox.Show("Erro");
            }
        }
        void fillData()
        {




            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "SectionName",
                HeaderText = "Section Name",
                DataPropertyName = "SectionName",
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Price",
                HeaderText = "Price",
                DataPropertyName = "Price"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TotalPrice",
                HeaderText = "Total Price",
                DataPropertyName = "TotalPrice"
            });
            dataGridView1.DataSource = sectionDetails;

        }
    }

}

