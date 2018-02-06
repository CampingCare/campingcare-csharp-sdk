using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using campingcare;
using Newtonsoft.Json.Linq;


namespace campingcare_csharp_sdk_tests
{
    public static class contact_new
    {

        /*
        * Example get contacts - How to get a specific contacts from the Camping.care API
        * https://camping.care/developer/contacts/get_contact
        */

        public static async void create_contact()
        {
            try
            {
                Console.WriteLine("*************************************");
                Console.WriteLine("***        CREATE CONTACT         ***");
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
                *   email           The email of the contact. (required)
                *   company         The company name of the contact.
                *   first_name      The first name of the contact.
                *   last_name       The last name of the contact. (required)
                *   gender          The gender of the contact. ('male', 'female' or 'family')
                *   address         The address of the contact.
                *   address_number  The address number of the contact.        
                *   zipcode         The zip code of the contact.
                *   city            The city of the contact.
                *   country         The country of the contact in ISO 3166 1 - Alpha 2 format. ('NL', 'IT', etc)
                *   phone           The phone of the contact.
                *   birthday        The birthday of the contact(YYYY - MM - DD)
                *
                */


                var send_data = new List<KeyValuePair<string, string>>();
                send_data.Add(new KeyValuePair<string, string>("email", "johndoe@example.com"));
                send_data.Add(new KeyValuePair<string, string>("company", "Camping.care"));
                send_data.Add(new KeyValuePair<string, string>("first_name", "John"));
                send_data.Add(new KeyValuePair<string, string>("last_name", "Doe"));
                send_data.Add(new KeyValuePair<string, string>("gender", "male"));
                send_data.Add(new KeyValuePair<string, string>("address", "Exampleroad"));
                send_data.Add(new KeyValuePair<string, string>("address_number", "123"));
                send_data.Add(new KeyValuePair<string, string>("zipcode", "1234AA"));
                send_data.Add(new KeyValuePair<string, string>("city", "Amsterdam"));
                send_data.Add(new KeyValuePair<string, string>("country", "NL"));
                send_data.Add(new KeyValuePair<string, string>("phone", "+31 123456789"));
                send_data.Add(new KeyValuePair<string, string>("birthday", "2018-01-01"));

                /*
                * All data is returned in a contact object
                * The structure can be found here: https://camping.care/developer/contacts/get_contact.
                */

                var data = await camping_care.create_contact(send_data);

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
