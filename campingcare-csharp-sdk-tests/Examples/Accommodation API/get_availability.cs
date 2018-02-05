using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using campingcare;
using Newtonsoft.Json.Linq;


namespace campingcare_csharp_sdk_tests
{
    public static class availability
    {

        /*
        * Example get accommodation - How to get accommodation information from the Camping.care API
        * https://camping.care/developer/accommodations/get_availability
        */

        public static async void get_availability()
        {
            try
            {
                Console.WriteLine("*************************************");
                Console.WriteLine("***      GET AVAILABILITY         ***");
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
                int id = 123;

                /*
                * Parameters:
                *   arrival             Arrival date for the availability (required)
                *   departure           Departure date for the availability (required)
                *   places              If set it returns the available places, if this parameter is not set you get the availability count only for this accommodation (optional)
                *   inactive_places     If set it includes the inactive places in the results (optional)
                *
                */

                var post_values = new List<KeyValuePair<string, string>>();

                post_values.Add(new KeyValuePair<string, string>("arrival", "2018-03-01"));
                post_values.Add(new KeyValuePair<string, string>("departure", "2018-03-02"));
                post_values.Add(new KeyValuePair<string, string>("places", "1"));
                post_values.Add(new KeyValuePair<string, string>("inactive_places", "0"));

                /*
                * All data is returned in a availbility count, if requested also the places are returned in a array of place objects
                * The structure can be found here: https://camping.care/developer/accommodations/get_availability
                */

                var data = await camping_care.get_availability(id, post_values);


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
