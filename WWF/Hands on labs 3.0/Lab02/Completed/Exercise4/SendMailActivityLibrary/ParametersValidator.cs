//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace SendMailActivityLibrary
{
	public class ParametersValidator : ActivityValidator
	{
		public override ValidationErrorCollection ValidateProperties(ValidationManager manager, object obj)
		{
			ValidationErrorCollection validationErrors = new ValidationErrorCollection(base.ValidateProperties(manager, obj));

			SendMailActivity sendMailActivityToBeValidated = obj as SendMailActivity;

			if (sendMailActivityToBeValidated == null)
			{
				throw new InvalidOperationException("Parameter obj is not of type SendMailActivity");
			}

			if (!IsValidEmailAddress(sendMailActivityToBeValidated.To))
			{
				ValidationError CustomActivityValidationError =
					new ValidationError(String.Format("\'{0}\' is an Invalid destination e-mail address", sendMailActivityToBeValidated.To), 1);

				validationErrors.Add(CustomActivityValidationError);
			}

			if (!IsValidEmailAddress(sendMailActivityToBeValidated.From))
			{
				ValidationError CustomActivityValidationError =
					new ValidationError(String.Format("\'{0}\' is an Invalid source e-mail address", sendMailActivityToBeValidated.From), 1);

				validationErrors.Add(CustomActivityValidationError);
			}

			return validationErrors;
		}
		public Boolean IsValidEmailAddress(String address)
		{
			// must only proceed with validation if we have data	
			// to validate
			if (address == null || address.Length == 0)
				return true;

			Regex rx = new Regex(@"[^A-Za-z0-9@\-_.]", RegexOptions.Compiled);
			MatchCollection matches = rx.Matches(address);

			if (matches.Count > 0)
				return false;

			// Must have an '@' character
			int i = address.IndexOf('@');

			// Must be at least three chars after the @
			if (i <= 0 || i >= address.Length - 3)
				return false;

			// Must only be one '@' character
			if (address.IndexOf('@', i + 1) >= 0)
				return false;

			// Find the last . in the address
			int j = address.LastIndexOf('.');

			// The dot can't be before or immediately after the @ char
			if (j >= 0 && j <= i + 1)
				return false;

			return true;
		}

	}
}
