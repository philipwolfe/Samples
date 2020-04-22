using System;
using System.Collections.Generic;
using System.Text;
using CraigsCreations.com.X10;
using System.IO;
using System.IO.IsolatedStorage;

namespace X10_Lights
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect to the Web service
            net.xmethods.services.netxmethodsservicesstockquoteStockQuoteService quoteService = new X10_Lights.net.xmethods.services.netxmethodsservicesstockquoteStockQuoteService();
            
            // Check current value by retrieving it from the Web service
            float currentValue = quoteService.getQuote("msft");

            // Check previous value by retrieving it from isolated storage
            float previousValue = 0;
            try
            {
                IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("quote.txt", FileMode.Open);
                StreamReader quoteReader = new StreamReader(isoStream);
                previousValue = float.Parse(quoteReader.ReadLine());
                quoteReader.Close();
            }
            catch
            {
                // File didn't exist, so this must be the first time we've run.
                // Just leave value at 0.
            }

            // If the value hasn't changed, don't update the lights
            if (currentValue != previousValue)
            {
                // Initialize X10 Controller
                IX10Controller x10 = new X10CM11aController(HouseCode.N, "COM1");

                // Replace the unit codes in the following two lines with unit codes
                // that you assign to your lamps
                X10Lamp redLamp = new X10Lamp(x10, 6);
                X10Lamp greenLamp = new X10Lamp(x10, 7);

                if (currentValue > previousValue)
                {
                    redLamp.Off();
                    greenLamp.On();
                }
                else if (previousValue > currentValue)
                {
                    greenLamp.Off();
                    redLamp.On();
                }
            }

            Console.WriteLine("Previous: $" + previousValue.ToString() + ", Current: $" + currentValue.ToString());

            // Save the current value to Isolated Storage
            IsolatedStorageFileStream isoStreamWriter = new IsolatedStorageFileStream("quote.txt", FileMode.Create);
            StreamWriter quoteWriter = new StreamWriter(isoStreamWriter);
            quoteWriter.WriteLine(currentValue.ToString());
            quoteWriter.Close();
        }
    }
}
