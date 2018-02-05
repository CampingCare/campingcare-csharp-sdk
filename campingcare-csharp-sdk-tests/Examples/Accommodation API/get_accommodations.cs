using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using campingcare;
using Newtonsoft.Json.Linq;


namespace campingcare_csharp_sdk_tests
{
    public static class accommodations
    {

        /*
        * Example get accommodations - How to get all accommodations data from the Camping.care API
        * https://camping.care/developer/accommodations/get_accommodations
        */

        public static async void get_accommodations()
        {
            try
            {
                Console.WriteLine("*************************************");
                Console.WriteLine("***      GET ACCOMMODATIONS       ***");
                Console.WriteLine("*************************************");

                /*
                * Initialize the Camping.care API SDK with your API key.
                *
                * See: https://camping.care/settings/api
                */

                campingcare_api camping_care = new campingcare_api();
                camping_care.set_api_key("YOUR API KEY");

                /*
                * Parameters:
                * None
                *
                */
                var post_values = new List<KeyValuePair<string, string>>();

                /*
                * All data is returned in a accommodations object
                * The structure can be found here: https://camping.care/developer/accommodations/get_accommodations.
                */

                var data = await camping_care.get_accommodations(post_values);

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
