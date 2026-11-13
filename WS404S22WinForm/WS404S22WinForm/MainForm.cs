using System.Net.Http.Json;
using WS404S22WinForm.DTO;

namespace WS404S22WinForm
{
    public partial class MainForm : Form
    {
        int PageNumber = 1;
        int PageSize = 10;
        int totalPages = 1;
        public MainForm()
        {
            InitializeComponent();

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadLogin();

       

            LoadDashboard();

        }

        async void LoadLogin()
        {
            /*  // Test
              APi.UserId = 3;
              await LoadDashboard();
              await LoadPlacesData();*/

            var loginForm = new LoginForm();

            this.Hide();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Show();
                await LoadDashboard();
                await LoadPlacesData();
            }
            else
            {
                MessageBox.Show("Login was not successful. The application will now close.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close(); // Close the main form if login fails
            }
        }

        private async Task LoadDashboard()
        {
            var response = await APi.LoadDashboardData();

            LblName.Text = response.Name;
            Lbltime.Text = response.Time.ToString();
            LblDate.Text = response.Date;

        }
        private async Task LoadPlacesData()
        {

            var response = await APi.client.GetFromJsonAsync<PlacesRequest>
                ($"/places?page={PageNumber}&size={PageSize}");

            if (response == null) return;

            totalPages = response.pages;


            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Name",
                HeaderText = "Name",
                DataPropertyName = "Name"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Remaining",
                HeaderText = "Remaining capacity",
                DataPropertyName = "Remaining"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Sold",
                HeaderText = "Tickets Sold",
                DataPropertyName = "Sold"
            });
            dataGridView1.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "Buy",
                HeaderText = "Action",
                Text = "Buy",
                UseColumnTextForButtonValue = true
            });
            dataGridView1.DataSource = response.items;

            RefreshButtons();


        }

        private void DataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Buy")
            {
                var place = (PlaceDTO)dataGridView1.Rows[e.RowIndex].DataBoundItem;


                //  MessageBox.Show(place.Name);

                var ticketForm = new BuyTicketForm();
                ticketForm.Place = place;
                Hide();
                var frmRes = ticketForm.ShowDialog();
                if (frmRes == DialogResult.Cancel)
                {
                    Show();
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            PageSize = int.Parse(combo.SelectedItem.ToString());
            LoadPlacesData();
        }

        void RefreshButtons()
        {
            flowLayoutPanel1.Controls.Clear();

            AddButton("<<", 1, PageNumber > 1, false);
            AddButton("<", PageNumber - 1, PageNumber > 1, false);

            for (int i = 1; i <= totalPages; i++)
            {
                AddButton(i.ToString(), i, true, i == PageNumber);
            }

            AddButton(">", PageNumber + 1, PageNumber < totalPages, false);
            AddButton(">>", totalPages, PageNumber < totalPages, false);


        }
        void AddButton(string name, int targetPage, bool enable, bool iscurrent)
        {
            Button bt = new()
            {
                Text = name,
                AutoSize = true,
                Enabled = enable
            };

            if (iscurrent)
                bt.BackColor = Color.LightBlue;

            bt.Click += async (s, e) =>
            {
                PageNumber = targetPage;
                await LoadPlacesData();
            };

            flowLayoutPanel1.Controls.Add(bt);
        }

       
    }
}
