using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http.Json;
using System.Text;
using System.Windows.Forms;
using WS404S22WinForm.DTO;

namespace WS404S22WinForm
{
    public partial class BuyTicketForm : Form
    {
        public PlaceDTO Place;

        private List<SectionDTO> Sections = new();
        private List<int> SectionIdList = new();

        public BuyTicketForm()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            LoadDashboard();
            LoadData();

        }

        private async Task LoadDashboard()
        {
            var response = await APi.LoadDashboardData();

            if (response == null) return;

            nemLbl.Text = response.Name;
            TimeLbl.Text = response.Time.ToString();
            dateLbl.Text = response.Date;
        }

        private void LoadData()
        {
            if (Place == null)
            {
                MessageBox.Show("Place is null");
                return;
            }

            PlaceNameTxt.Text = Place.Name;

            Sections = Place.Sections;
            foreach (var item in Sections)
            {
                item.Total = item.Price * PaidTickets();
            }

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
                DataPropertyName = "Total"
            });
            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "Select",
                HeaderText = "Select",
            });


            Sections.Insert(0, new SectionDTO()
            {
                SectionId = 0,
                SectionName = "Base Price",
                Price = Place.BasePrice,
                Total = Place.BasePrice * PaidTickets()
            });

            dataGridView1.DataSource = Sections;
            dataGridView1.Rows[0].Cells["Select"].ReadOnly = true;

            ReCalc();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            //      MessageBox.Show(Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["Select"].Value).ToString());

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Select")
            {
                //       dataGridView1.CommitEdit()
                dataGridView1.CommitEdit(new());

                ReCalc();
            }
        }
        void ReCalc()
        {
            SectionIdList.Clear();
            int NumberOfTickets = (int)numericUpDown1.Value;

            int TotalPrice = Place.BasePrice * PaidTickets();


            dataGridView1.Rows[0].Cells["TotalPrice"].Value = Place.BasePrice * PaidTickets();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (i > 0)
                    dataGridView1.Rows[i].Cells["TotalPrice"].Value = Sections[i].Price * PaidTickets();
            }

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                var isActive = Convert.ToBoolean(item.Cells["Select"].Value);
                if (isActive)
                {
                    TotalPrice += Convert.ToInt32(item.Cells["TotalPrice"].Value);
                    SectionIdList.Add(Sections[item.Index].SectionId);
                }
            }

            SumLbl.Text = TotalPrice.ToString();

        }
        int PaidTickets()
        {
            int NumberOfTickets = (int)numericUpDown1.Value;
            int freeTicket = NumberOfTickets / 3;
            return NumberOfTickets - freeTicket;
        }



        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ReCalc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterTicket();
        }

        private async void RegisterTicket()
        {
            try
            {
                var request = new BuyRequest()
                {
                    UserId = APi.UserId,
                    PlaceId = Place.Id,
                    VisitorCount = (int)numericUpDown1.Value,
                    SectionIds = SectionIdList
                };

                var response = await APi.client.PostAsJsonAsync("/tickets", request);

                var responseResult = await response.Content.ReadFromJsonAsync<BuyRequestResponse>();

                if (response.IsSuccessStatusCode)
                {
               //     MessageBox.Show("ok", responseResult.id.ToString());

                    int ticketId = responseResult.id;

                    var form = new FactorForm();
                    form.TicketId = ticketId;
                    Hide();
                    if(form.ShowDialog() == DialogResult.Cancel)
                    {
                        Hide();
                    }
                }
                else 
                {
                    MessageBox.Show(responseResult?.error ?? "", "Error");
                }
            }

            catch
            {
                MessageBox.Show("Unkown Error!");
            }
        }
    }
}
