using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace PetLife
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected async void LoginButton_Click(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                bool isSuccess = await CallLoginApi(email, password);

                if (isSuccess)
                {
                    Response.Redirect($"HomePage.aspx?token={HttpUtility.UrlEncode(email)}");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "showErrorPopup", "showErrorPopup();", true);
                }
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {

            Response.Redirect("RegisterPage.aspx");


        }
        
        private async Task<bool> CallLoginApi(string email, string password)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiEndpoint = "http://localhost:7094/api/User/login";

                    var requestData = new { email = email, password = password };

                    var jsonContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiEndpoint, jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        
                        return true;
                    }
                    else
                    {
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Login failed. Error: " + errorResponse);

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during login: " + ex.Message);
                return false;
            }
        }

    }
}
