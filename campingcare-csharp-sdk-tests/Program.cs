using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace campingcare_csharp_sdk_tests
{
    class Program
    {


        static void Main(string[] args)
        {
            try
            {

                ///////////////////////////////////////////////////////////////////////////
                //////////
                //////////              Park API
                //////////
                ///////////////////////////////////////////////////////////////////////////

                // Call get park
                //park.get_park();

                // Call age tables
                //age_tables.get_age_tables();

                // Call cards
                //cards.get_cards();

                // Call vat groups
                //vat_groups.get_vat_groups();


                ///////////////////////////////////////////////////////////////////////////
                //////////
                //////////              Accommodation API
                //////////
                ///////////////////////////////////////////////////////////////////////////


                // Call get accommodations 
                //accommodations.get_accommodations();

                // Call get accommodation
                //accommodation.get_accommodation();


                // Call get availability
                //availability.get_availability();

                // Call get Prices
                //prices.get_prices();

                // Call get options
                //options.get_options();

                ///////////////////////////////////////////////////////////////////////////
                //////////
                //////////              Reservation API
                //////////
                ///////////////////////////////////////////////////////////////////////////


                // Call get reservations 
                //reservations.get_reservations();

                // Call get reservation
                // reservation.get_reservation();

                // Call create reservation
                //reservation_new.create_reservation();


                ///////////////////////////////////////////////////////////////////////////
                //////////
                //////////              Prices API
                //////////
                ///////////////////////////////////////////////////////////////////////////

                // Call get Price
                // price.get_price();

                // Call get calculate price
                //calculate_price.get_calculate_price();

                ///////////////////////////////////////////////////////////////////////////
                //////////
                //////////              Invoice API
                //////////
                ///////////////////////////////////////////////////////////////////////////


                // Call get Invoices 
                //invoices.get_invoices();

                // Call get invoice
                //invoice.get_invoice();

                ///////////////////////////////////////////////////////////////////////////
                //////////
                //////////              Contacts API
                //////////
                ///////////////////////////////////////////////////////////////////////////


                // Call get contacts 
                //contacts.get_contacts();

                // Call get contact
                //contact.get_contact();



                Console.Read();
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
