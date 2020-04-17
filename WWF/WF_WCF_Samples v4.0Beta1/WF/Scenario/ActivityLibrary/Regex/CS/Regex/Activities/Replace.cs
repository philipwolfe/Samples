//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
namespace Microsoft.Samples.RegexActivities
{
    using System.Activities;
    using System.Text.RegularExpressions;

    // Activity to provide Regex.Replace functionality in WF programs
    public sealed class Replace : CodeActivity<string>
    {
        public Replace() : base()
        {
            this.RegexOption = RegexOptions.IgnoreCase | RegexOptions.Compiled;
        }

        [IsRequired]
        public InArgument<string> Pattern { get; set; }

        [IsRequired]
        public InArgument<string> Input { get; set; }
        public RegexOptions RegexOption { get; set; }
        public InArgument<string> Replacement { get; set; }
        public MatchEvaluator MatchEvaluator { get; set; }

        protected override void OnOpen(DeclaredEnvironment environment)
        {          
            if ((this.Pattern == null) || (this.Pattern.Expression == null))
            {
                throw new ValidationException("Argument 'Pattern' of Replace activity must be bound before it can be used.");
            }

            if ((this.Input == null) || (this.Input.Expression == null))
            {
                throw new ValidationException("Argument 'Input' of Replace activity must be bound before it can be used.");
            }

            if (this.MatchEvaluator == null && (this.Replacement == null || this.Replacement.Expression == null))
            {
                throw new ValidationException("'Replacement' or 'MatchEvaluator' arguments in Replace not set.");
            }
        }

        protected override void Execute(CodeActivityContext context)
        {
            // we are using static method because by default the regular expression engine caches the 15 most recently used static regular expressions            

            if (this.Replacement.Get(context) != null || this.Replacement.Expression != null)
            {
                this.Result.Set(context, Regex.Replace(this.Input.Get(context), this.Pattern.Get(context), this.Replacement.Get(context), this.RegexOption));
            }
            else            
            {
                this.Result.Set(context, Regex.Replace(this.Input.Get(context), this.Pattern.Get(context), this.MatchEvaluator, this.RegexOption));
            }
        }
    }
}