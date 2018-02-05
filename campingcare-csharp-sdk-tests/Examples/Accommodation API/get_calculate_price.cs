using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using campingcare;
using Newtonsoft.Json.Linq;


namespace campingcare_csharp_sdk_tests
{
    public static class calculate_price
    {
        /*
        * Example get calculate_price - How to get calculated price for a specific accommodation between 2 dates from the Camping.care API
        * https://camping.care/developer/accommodations/get_calculate_price
        */

        public static async void get_calculate_price()
        {
            try
            {
                Console.WriteLine("*************************************");
                Console.WriteLine("***      GET CALCULATE PRICE      ***");
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
                * https://camping.care/developer/accommodations/get_calculate_price
                */
                int id = 36;

                /*
                * Parameters:
                *   arrival             Arrival date for the availability (required)
                *   departure           Departure date for the availability (required)
                *   persons             Number of persons. (required if no age tables)
                *   age_tables          Array of age table data check https://camping.care/developer/accommodations/get_calculate_price (required if age tables are used in a park)
                *
                */

                var post_values = new List<KeyValuePair<string, string>>();
                post_values.Add(new KeyValuePair<string, string>("arrival", "2018-03-01"));
                post_values.Add(new KeyValuePair<string, string>("departure", "2018-03-10"));
                post_values.Add(new KeyValuePair<string, string>("persons", "2"));

                /*
                * All data is returned as calculate price opject
                * The structure can be found here: https://camping.care/developer/accommodations/get_calculate_price.
                */
                var data = await camping_care.get_calculate_price(id, post_values);

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
