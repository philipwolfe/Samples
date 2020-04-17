//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
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
using System.Collections.Generic;
using System.Text;
using System.Workflow.Runtime;

namespace Workflows
{
	public class Helper
	{
        public const string DescriptionPropertyName = "QualifiedName", ActivityGuidPropertyName = "ActivityGuid";

        private static WorkflowRuntime runtime;

		/// <summary>
		/// Provides access to the <see cref="WorkflowRuntime"/>.
		/// </summary>
		public static WorkflowRuntime Runtime
		{
			get { return runtime; }
			set { runtime = value; }
		}

		private static IUserActivityService userActivityService;

		/// <summary>
		/// Provides access to the IUserActivityService implementation.
		/// </summary>
		public static IUserActivityService UserActivityService
		{
			get { return userActivityService; }
			set { userActivityService = value; }
		}

		public static string MakeQueueName(Guid activityGuid)
		{
			return "User Activity: " + activityGuid.ToString();
		}
	}
}
