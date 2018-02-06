using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using campingcare;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace campingcare_csharp_sdk_tests
{
    public static class reservation_update
    {

        /*
        * Example update reservation - How to create a reservation from the Camping.care API
        * https://camping.care/developer/reservations/create_reservation
        */
        public static async void update_reservation()
        {
            try
            {
                Console.WriteLine("*************************************");
                Console.WriteLine("***       UPDATE RESERVATION      ***");
                Console.WriteLine("*************************************");

                /*
                * Initialize the Camping.care API SDK with your API key.
                *
                * See: https://camping.care/settings/api
                */

                campingcare_api camping_care = new campingcare_api();
                camping_care.set_api_key("YOUR API KEY");

                int id = 1; // this is the id of the reservation, not the reservation_id (Required)

                /*
                * Parameters:
                *   contact_id:     The id of a contact (required)
                *   options:        he options that are selected by the guest. You can get the available options with this function get options
                *   finish:         Make it final by setting this variable to true. The reservation will get the status 'pending', this means the reservation is done.
                */


                var send_data = new List<KeyValuePair<string, string>>();
                send_data.Add(new KeyValuePair<string, string>("contact_id", "192"));

                // Create a age table array and genreate age table JSON data
                var options = new List<option_struct>();

                campingcare.option_struct option0 = new option_struct();
                option0.id = 29;
                option0.count = 3;

                campingcare.option_struct option1 = new option_struct();
                option1.id = 30;
                option1.count = 2;

                options.Add(option0);
                options.Add(option1);

                string option_json_string = JsonConvert.SerializeObject(options);

                send_data.Add(new KeyValuePair<string, string>("options", option_json_string));

                send_data.Add(new KeyValuePair<string, string>("finish", "0"));


                /*
                * All data is returned in a reservation object
                * The structure can be found here: https://camping.care/developer/reservations/get_reservation.
                */

                var data = await camping_care.update_reservation(id, send_data);


                /*
                * In this example we print the data in json format in the console
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
