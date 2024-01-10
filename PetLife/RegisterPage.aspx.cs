using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace PetLife
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        

        protected async void RegisterButton_Click(object sender, EventArgs e)
        {

            string fullName = FullNameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                bool isSuccess = await CallRegisterApi(email, password, fullName);

                if (isSuccess)
                {
                    
                    Response.Redirect("LoginPage.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "showErrorPopup", "showErrorPopup();", true);
                }
            }


        }
        
        private async Task<bool> CallRegisterApi(string email, string password, string fullName)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiEndpoint = "http://localhost:7094/api/User/register";

                    var requestData = new {fullname=fullName, email = email, password = password };

                    var jsonContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiEndpoint, jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                            Console.WriteLine("Register successfully.");
                       
                        return true;
                    }
                    else
                    {
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Register failed. Error: " + errorResponse);

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during Register: " + ex.Message);
                return false;
            }
        }

    }
}
