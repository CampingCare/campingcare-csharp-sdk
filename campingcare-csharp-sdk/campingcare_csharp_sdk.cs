using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace campingcare
{
    public class campingcare_api
    {

        private string api_key ; 
	    private string api_url = "https://camping.care/api/v1/"; 

       
        public bool set_api_key(string api_key)
        {
            try
            {
                this.api_key = api_key;
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool set_api_url(string api_url)
        {
            try
            {
                this.api_url = api_url;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }




        private async Task<object> make_api_requestAsync(string endpoint, List<KeyValuePair<string, string>> send_data, string type = "GET")
        {
            try
            {

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(api_url);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", api_key);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                

                HttpResponseMessage json_response;

                if (type.ToUpper() == "POST")
                {
                    var httpContent = new FormUrlEncodedContent(send_data);
                    json_response = await client.PostAsync(api_url + endpoint, httpContent);
                }
                else
                {
                    string get_values = "";
                    foreach(KeyValuePair<string, string>  parameter in send_data)
                    {
                        get_values = get_values + parameter.Key + "=" + parameter.Value + "&";
                    }

                    if (get_values.Length > 1)
                    {
                        get_values = get_values.Substring(0, get_values.Length - 1);
                    }

                    json_response = await client.GetAsync(api_url + endpoint + "?" + get_values);

                }
                
                HttpStatusCode httpcode = json_response.StatusCode;

                if (httpcode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception("Httpcode 500 - we could not reach the server");
                }
                else if (httpcode == HttpStatusCode.Created)
                {
                    if (json_response.Content == null)
                    {
                        throw new Exception("We got an empty response");
                    }
                    else
                    {
                        var response = json_response.Content.ReadAsStringAsync().Result;                    
                        return response;
                    }



                }
                else if (httpcode == HttpStatusCode.NonAuthoritativeInformation)
                {
                    if (json_response.Content == null)
                    {
                        throw new Exception("We got an empty response");
                    }
                    else
                    {
                        var response = json_response.Content.ReadAsStringAsync();
                    }
                }
                else if (httpcode == HttpStatusCode.NotFound)
                {
                    throw new Exception("404 - Page not found");
                }
                else if (Convert.ToInt32(httpcode) == 230)
                {
                    var error_code = json_response.Content.ReadAsStringAsync().Result;

                    if(error_code == "")
                    {
                        throw new Exception("230 - Error: We got an empty error message.");
                    }
                    else
                    {
                        throw new Exception("230 - Error: " + error_code);
                    }
                   
                }

                
                throw new Exception("Unknown httpcode ("+httpcode+") ");

                


            }
            catch (Exception)
            {
                return false;
            }
        }


 

        public async Task<object> get_park(List<KeyValuePair<string, string>> data)
        {
            var return_data = await make_api_requestAsync("/park/", data, "GET");
            return return_data;
        }

        public async Task<object> get_age_tables(List<KeyValuePair<string, string>> data)
        {
            var return_data = await make_api_requestAsync("/park/age_tables", data, "GET");
            return return_data;
        }

        public async Task<object> get_cards(List<KeyValuePair<string, string>> data)
        {
            var return_data = await make_api_requestAsync("/park/cards", data, "GET");
            return return_data;
        }

        public async Task<object> get_vat_groups(List<KeyValuePair<string, string>> data)
        {
            var return_data = await make_api_requestAsync("/invoicing/vat_groups", data, "GET");
            return return_data;
        }

        public async Task<object> get_accommodations(List<KeyValuePair<string, string>> data)
        {
            var return_data = await make_api_requestAsync("/accommodations", data, "GET");
            return return_data;
        }

        public async Task<object> get_accommodation(int id, List<KeyValuePair<string, string>> data)
        {

		    if (id == 0){
                throw new Exception("No accommodation ID found");
            };

            var return_data = await make_api_requestAsync("/accommodations/" + id, data, "GET");
            return return_data;

        }

        public async Task<object> get_availability(int id, List<KeyValuePair<string, string>> data)
        {

            if (id == 0)
            {
                throw new Exception("No accommodation ID found");
            };

            var return_data = await make_api_requestAsync("/accommodations/" + id + "/availability", data, "GET");
            return return_data;

        }


       

        public async Task<object> get_options(int id, List<KeyValuePair<string, string>> data)
        {
            if (id == 0)
            {
                throw new Exception("No accommodation ID found");
            };

            var return_data = await make_api_requestAsync("/accommodations/" + id + "/options", data, "GET");
            return return_data;
        }


        public async Task<object> get_reservations(List<KeyValuePair<string, string>> data)
        {
        
            var return_data = await make_api_requestAsync("/reservations/", data, "GET");
            return return_data;
        }

        public async Task<object> get_reservation(int id, List<KeyValuePair<string, string>> data)
        {
            if (id == 0)
            {
                throw new Exception("No reservation ID found");
            };

            var return_data = await make_api_requestAsync("/reservations/" + id, data, "GET");
            return return_data;
        }

        public async Task<object> get_reservation_options(int id, List<KeyValuePair<string, string>> data)
        {
            if (id == 0)
            {
                throw new Exception("No reservation ID found");
            };

            var return_data = await make_api_requestAsync("/reservations/" + id + "/options", data, "GET");
            return return_data;
        }


        public async Task<object> create_reservation(List<KeyValuePair<string, string>> data)
        {

            var return_data = await make_api_requestAsync("/reservations/", data, "POST");
            return return_data;
        }

        public async Task<object> update_reservation(int id, List<KeyValuePair<string, string>> data)
        {

            var return_data = await make_api_requestAsync("/reservations/" + id, data, "POST");
            return return_data;
        }

        public async Task<object> calculate_price(List<KeyValuePair<string, string>> data)
        {
            var return_data = await make_api_requestAsync("/reservations/calculate_price", data, "POST");
            return return_data;
        }


        public async Task<object> get_prices(int id, List<KeyValuePair<string, string>> data)
        {
            if (id == 0)
            {
                throw new Exception("No accommodation ID found");
            };

            var return_data = await make_api_requestAsync("/prices/" + id, data, "GET");
            return return_data;
        }

        public async Task<object> get_price(int id, List<KeyValuePair<string, string>> data)
        {
            if (id == 0)
            {
                throw new Exception("No price ID found");
            };

            var return_data = await make_api_requestAsync("/price/" + id, data, "GET");
            return return_data;
        }

        public async Task<object> get_invoices(List<KeyValuePair<string, string>> data)
        {

            var return_data = await make_api_requestAsync("/invoicing/", data, "GET");
            return return_data;
        }

        public async Task<object> get_invoice(int id, List<KeyValuePair<string, string>> data)
        {
            if (id == 0)
            {
                throw new Exception("No invoice ID found");
            };

            var return_data = await make_api_requestAsync("/invoicing/" + id, data, "GET");
            return return_data;
        }

        public async Task<object> get_contacts(List<KeyValuePair<string, string>> data)
        {

            var return_data = await make_api_requestAsync("/contacts/", data, "GET");
            return return_data;
        }

        public async Task<object> get_contact(int id, List<KeyValuePair<string, string>> data)
        {
            if (id == 0)
            {
                throw new Exception("No contact ID found");
            };

            var return_data = await make_api_requestAsync("/contacts/" + id, data, "GET");
            return return_data;
        }

        public async Task<object> create_contact(List<KeyValuePair<string, string>> data)
        {
            
            var return_data = await make_api_requestAsync("/contacts/", data, "POST");
            return return_data;
        }

    }

    public class age_table_struct
    {
        public int id { get; set; }
        public int count { get; set; }
    }

    public class option_struct
    {
        public int id { get; set; }
        public int count { get; set; }
    }


}
