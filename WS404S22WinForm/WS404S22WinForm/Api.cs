using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using WS404S22WinForm.DTO;

namespace WS404S22WinForm
{
    public static class APi
    {
        public static HttpClient client = new()
        {
            BaseAddress = new Uri("https://localhost:7096/")
        };

        public static int UserId { get; set; } = 0;
        public static string Username { get; set; } = string.Empty;


        public async static Task<DashboardRequest> LoadDashboardData()
        {
            try
            {
                //APi.UserId = 3;
                var response = await client.GetFromJsonAsync<DashboardRequest>(
                    $"dashboard?userId={UserId}");

                return response;

                if (response == null)
                    return null;
            }
            catch
            {
                MessageBox.Show("Failed to load dashboard data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
