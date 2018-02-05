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
                *   filter    		The filter can be used to filter the contact list on name, you can use the '%' to get all contacts (required)
                *
                */

                var post_values = new List<KeyValuePair<string, string>>();
                post_values.Add(new KeyValuePair<string, string>("filter", "%"));
               
                /*
                * All data is returned in a contact opject
                * The structure can be found here: https://camping.care/developer/contacts/get_contact.
                */

                var data = await camping_care.get_contacts(post_values);

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
