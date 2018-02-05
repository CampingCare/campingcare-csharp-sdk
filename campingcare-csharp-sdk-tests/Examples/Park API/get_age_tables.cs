using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using campingcare;
using Newtonsoft.Json.Linq;

namespace campingcare_csharp_sdk_tests
{
    public static class age_tables
    {

        /*
        * Example get age tables - How to get age table information from the Camping.care API
        * https://camping.care/developer/park/get_age_tables
        */

        public static async void get_age_tables()
        {
            try
            {
                Console.WriteLine("*************************************");
                Console.WriteLine("***         GET AGE TABLES        ***");
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
                * All data is returned in a age table opject
                * The structure can be found here: https://camping.care/developer/park/get_age_tables.
                */

                var data = await camping_care.get_age_tables(post_values);


                /*
                * In this example we print the oprions in json format in the console
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
