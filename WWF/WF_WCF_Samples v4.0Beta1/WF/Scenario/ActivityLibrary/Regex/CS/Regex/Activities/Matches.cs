//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
namespace Microsoft.Samples.RegexActivities
{
    using System.Activities;
    using System.Text.RegularExpressions;

    // Activity to provide Regex.Matches functionality in WF programs
    public sealed class Matches : CodeActivity<MatchCollection>
    {
        public Matches() : base()
        {
            this.RegexOption = RegexOptions.IgnoreCase | RegexOptions.Compiled;
        }
    
        [IsRequired]
        public InArgument<string> Pattern { get; set; }

        [IsRequired]
        public InArgument<string> Input { get; set; }
        public RegexOptions RegexOption { get; set; }

        protected override void OnOpen(DeclaredEnvironment environment)
        {
            if ((this.Pattern == null) || (this.Pattern.Expression == null))
            {
                throw new ValidationException("Argument 'Pattern' of Matches activity must be bound before it can be used.");
            }

            if ((this.Input == null) || (this.Input.Expression == null))
            {
                throw new ValidationException("Argument 'Input' of Matches activity must be bound before it can be used.");
            }
        }

        protected override void Execute(CodeActivityContext context)
        {
            // we are using static method because by default the regular expression engine caches the 15 most recently used static regular expressions 
            
            this.Result.Set(context, Regex.Matches(this.Input.Get(context), this.Pattern.Get(context), this.RegexOption));
        }
    }
}
