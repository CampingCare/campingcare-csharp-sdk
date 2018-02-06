using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using campingcare;
using Newtonsoft.Json.Linq;


namespace campingcare_csharp_sdk_tests
{
    public static class options
    {

        /*
        * Example get options - How to get acoomodation options the Camping.care API
        * https://camping.care/developer/accommodations/get_options.
        */

        public static async void get_options()
        {
            try
            {
                Console.WriteLine("*************************************");
                Console.WriteLine("***           GET OPTIONS         ***");
                Console.WriteLine("*************************************");

                /*
                * Initialize the Camping.care API SDK with your API key.
                *
                * See: https://camping.care/settings/api
                */

                campingcare_api camping_care = new campingcare_api();
                camping_care.set_api_key("YOUR API KEY");

                /*
                * Set your accommodation id. It can be found by using the function get_accommodations 
                * http://camping.care/developer/accommodations/get_accommodations
                */

                int id = 37;

                /*
                * Parameters:
                *   reservation_id     Reservation id for getting options for a specific reservation (optional)
                *   required_only      To get the required ooptions only if a reservation id is set (optional only in combination with parameter reservation_id)
                *
                * You can include additional data to the get options function.
                * By including the reservation id you only get the options which are available for a specific reservation by setting the reservation_id
                *
                * If you choose to get the required options for a specific resercation only you can add the required_only parameter
                *
                */
                var send_data = new List<KeyValuePair<string, string>>();
                send_data.Add(new KeyValuePair<string, string>("reservation_id", "638"));
                send_data.Add(new KeyValuePair<string, string>("required_only", "1"));

                /*
                * All data is returned in a option opject
                * The structure can be found here: https://camping.care/developer/accommodations/get_options.
                */
                var data = await camping_care.get_options(id, send_data);

                /*
                * In this example we print the oprions in json format on the page
                */
                JObject json = JObject.Parse(data.ToString());

                foreach (var pair in json)
                {
                    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                }

            }
            catch (Exception ex)
            {
                LogData(ex.Message);
            }
        }

        private static void LogData(string Message)
        {
            Console.WriteLine("Error: " + Message);
        }
    }
}
