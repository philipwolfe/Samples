using System;
using System.Collections;
using System.Management;

namespace ManageabilityTool
{
    class Program
    {
        ArrayList validCommands;
        ArrayList tokens;

        String[] loadTokens = { "commands", "exit", "list" };

        String inputString = String.Empty;
        Tokenizer tokenizer;

        bool exit;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Program()
        {
            validCommands = new ArrayList(loadTokens);

            tokenizer = new Tokenizer();

            exit = false;
        }

        /// <summary>
        /// Listens for valid commands from the user.
        /// </summary>
        public void Listen()
        {
            this.ListCommands();

            // listen for user input until requesting to exit
            while (exit != true)
            {
                Console.Write("WCF Service Manager > ");

                inputString = Console.ReadLine();
                
                tokens = tokenizer.TokenizeInput(inputString);

                if (this.ValidateCommand())
                    this.ApplyCommand();
                else
                {
                    //report error
                    Console.WriteLine("Invalid command: {0}\n", tokens[0]);
                }
            }
        }

        /// <summary>
        /// Validates the first token in the token list to ensure it is
        /// contained in the list of valid commands.
        /// </summary>
        private bool ValidateCommand()
        {
            bool validatioResult;

            if (validCommands.Contains(tokens[0]))
                validatioResult = true;
            else
                validatioResult = false;

            return validatioResult;
        }

        /// <summary>
        /// Displays the list of valid user commands.
        /// </summary>
        private void ListCommands()
        {
            Console.WriteLine("\nValid Commands:");
            Console.WriteLine("---------------");

            foreach (String command in validCommands)
            {
                Console.WriteLine(" " + command);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Displays all active WCF services running on the client machine.
        /// </summary>
        private void EnumerateServices()
        {
            const String WMINamespace = @"\\localhost\root\ServiceModel";

            try
            {
                ManagementScope wmiScope = 
                    new ManagementScope(WMINamespace);

                wmiScope.Connect();

                ObjectQuery objQuery = 
                    new ObjectQuery("SELECT * FROM Service");
                ManagementObjectSearcher objSearcher = 
                    new ManagementObjectSearcher(wmiScope, objQuery);

                
                ManagementObjectCollection queryCollection =
                    objSearcher.Get();

                ///
                ///TODO: Format these output strings
                ///

                Console.WriteLine("\n Listing Available WCF Services...\n");
                Console.WriteLine("Name\t\t\tProcess ID");
                Console.WriteLine("----\t\t\t----------");

                foreach (ManagementObject obj in queryCollection)
                {
                    Console.WriteLine(obj["Name"] + "\t" + obj["ProcessId"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Applys the command requested by the user.
        /// </summary>
        private void ApplyCommand()
        {
            String command = ((String)tokens[0]).ToLower();

            switch (command)
            {
                case "commands":
                    ListCommands();
                    break;
                case "exit":
                    exit = true;
                    break;
                case "list":
                    EnumerateServices();
                    break;             
            }
        }
    }
}
