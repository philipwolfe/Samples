using System;
using System.Collections;

namespace ManageabilityTool
{
    class Tokenizer
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Tokenizer()
        {
            
        }

        /// <summary>
        /// Parses the users input into tokens.
        /// </summary>
        /// <param name="inputString"></param>
        public ArrayList TokenizeInput(String inputString)
        {
            ArrayList inputTokens = new ArrayList();

            inputTokens.AddRange(inputString.Split(' '));

            /**
             * 
             * The tokenizer is separate from the program to allow
             * for a more complex implementation even though it is
             * just using String.Split as of right now.
             *
             */

            return inputTokens;
        }        
    }
}
