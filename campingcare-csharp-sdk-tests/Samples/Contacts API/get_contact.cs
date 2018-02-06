using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using campingcare;
using Newtonsoft.Json.Linq;


namespace campingcare_csharp_sdk_tests
{
    public static class contact
    {

        /*
        * Example get contacts - How to get a specific contacts from the Camping.care API
        * https://camping.care/developer/contacts/get_contact
        */

        public static async void get_contact()
        {
            try
            {
                Console.WriteLine("*************************************");
                Console.WriteLine("***          GET CONTACT          ***");
                Console.WriteLine("*************************************");

                /*
                * Initialize the Camping.care API SDK with your API key.
                *
                * See: https://camping.care/settings/api
                */

                campingcare_api camping_care = new campingcare_api();
                camping_care.set_api_key("YOUR API KEY");

                /*
                * Set your contact id. It can be found by using the function get_contacts
                * https://camping.care/developer/contacts/get_contacts
                */

                int id = 191;

                /*
                * Parameters:
                * None
                *
                */

                var send_data = new List<KeyValuePair<string, string>>();

                /*
                * All data is returned in a contact object
                * The structure can be found here: https://camping.care/developer/contacts/get_contact.
                */

                var data = await camping_care.get_contact(id, send_data);

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
