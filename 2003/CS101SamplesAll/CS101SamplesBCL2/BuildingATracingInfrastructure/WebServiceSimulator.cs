using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingATracingInfrastructure {

    // This class simulates a web service.
    class WebServiceSimulator {

        public string GetEmployeeNames(int delayLength) {
            // Retrieve a list of employees.
            // Simulate a web service responding slowly.
            if (delayLength > 0) {
                System.Threading.Thread.Sleep(delayLength);
            }

            // Return the list if the delay is less than three seconds, otherwise 
            // return an error string.
            if (delayLength < 4000) {
                // Access a database for the information.
                return "Nancy Davolio, Andrew Fuller, Janet Leverling, " +
                    "Margaret Peacock, Steven Buchanan";

            }
            else {
                return "Error";
            }
        }
    }
}
