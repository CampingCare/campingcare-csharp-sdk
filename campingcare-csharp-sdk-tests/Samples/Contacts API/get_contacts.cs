using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using campingcare;
using Newtonsoft.Json.Linq;


namespace campingcare_csharp_sdk_tests
{
    public static class contacts
    {
      
        /*
        * Example get contacts - How to get a list of contacts from the Camping.care API
        * https://camping.care/developer/contacts/get_contacts
        */

        public static async void get_contacts()
        {
            try
            {
                Console.WriteLine("*************************************");
                Console.WriteLine("***          GET CONTACTS         ***");
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
                *   offset    		start offset with contacts (required)
                *   limit           end offset
                *
                */

                var send_data = new List<KeyValuePair<string, string>>();
                send_data.Add(new KeyValuePair<string, string>("offset", "1")); // start with the first dataset
                send_data.Add(new KeyValuePair<string, string>("limit", "100")); // returns 100 contacts at the time, max. is 1000


                /*
                * All data is returned in a contact opject
                * The structure can be found here: https://camping.care/developer/contacts/get_contact.
                */

                var data = await camping_care.get_contacts(send_data);

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
