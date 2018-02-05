using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using campingcare;
using Newtonsoft.Json.Linq;


namespace campingcare_csharp_sdk_tests
{
    public static class invoices
    {
        
        /*
        * Example get invoices - How to get invoices between a start and end date from the Camping.care API
        * https://camping.care/developer/invoicing/get_invoices
        */

        public static async void get_invoices()
        {
            try
            {
                Console.WriteLine("*************************************");
                Console.WriteLine("***           GET INVOICES        ***");
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
                *   start_date:		    The arrival date where reservations have to be inbetween (required)
                *   end_date:			The departure date where reservations have to be inbetween (required)
                *
                */

                var post_values = new List<KeyValuePair<string, string>>();
                post_values.Add(new KeyValuePair<string, string>("start_date", "2017-01-01"));
                post_values.Add(new KeyValuePair<string, string>("end_date", "2018-12-31"));

                /*
                * All data is returned in a invoice object
                * The structure can be found here: https://camping.care/developer/invoicing/get_invoice.
                */

                var data = await camping_care.get_invoices(post_values);


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
