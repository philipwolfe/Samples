//-----------------------------------------------------------------------
//  This file is part of the Microsoft .NET SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//-----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Forms;
using System.Collections;

namespace Microsoft.Samples.Globalization.Culture
{
	/// <summary>
	/// Class which handled all the logic behind the sample.
	/// </summary>
	public class CultureInfoHelper
	{
		//Handle to display the newly created windows
		private DisplayCulture displayHelper;
		
		public CultureInfoHelper(DisplayCulture display)
		{
			displayHelper = display;
		}

		/**
		 * Method to create a new culture either by mixing or inheriting from the
		 * InvariantCulture
		 */
		public void GetNewCultureInfo(NumberFormatInfo numberFormat, DateTimeFormatInfo dateFormat, 
					string locale, string name)
		{
			try
			{
				CultureInfo ci = new CultureInfo(locale);
				RegionInfo ri ;
				//In case the locale name is empty as is for Invariant culture
				if (locale.Length == 0)
					ri = RegionInfo.CurrentRegion;
				else
					ri = new RegionInfo(locale);

				// See if we're neutral
				CultureAndRegionModifiers mods = CultureAndRegionModifiers.None;
                if (name.IndexOf('-') < 0)
                    mods |= CultureAndRegionModifiers.Neutral;

                // See if we already have one
                try
                {
                    CultureInfo test = CultureInfo.GetCultureInfo(name);
                    mods |= CultureAndRegionModifiers.Replacement;
                }
                catch (System.ArgumentException)
                {
                    // name doesn't exist (yet)
                }
                
				//Use the builder to register the culture
				CultureAndRegionInfoBuilder cib = new CultureAndRegionInfoBuilder(
				                                         name, mods);

                cib.LoadDataFromCultureInfo(ci);
                cib.LoadDataFromRegionInfo(ri);
                
                cib.NumberFormat = numberFormat;
                cib.GregorianDateTimeFormat = dateFormat;
                cib.IetfLanguageTag = name;
                cib.Register();

				//Add the new culture using the DisplayCulture
				Add(name);
				
				MessageBox.Show(Constants.SuccessMessage);
			}
			catch (System.IO.IOException)
			{
				//The .nlp file already exists
				MessageBox.Show(Constants.ErrorFileFound);
			}
			catch (System.ArgumentOutOfRangeException ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		
		/**
		 * Method to create a new culture instance by inheriting from 
		 * a culture
		 */
		public void NewCultureInstance(string locale, string name)
		{
			try
			{
				CultureInfo ci = new CultureInfo(locale);
				RegionInfo ri;
				//In case the locale name is empty as is for Invariant culture
				if (locale.Length == 0)
					ri = RegionInfo.CurrentRegion;
				else
					ri = new RegionInfo(locale);
				//Split the name to language and region
				string[] lang = ci.Name.Split(Constants.CharHyphen);

				// See if we're neutral
				CultureAndRegionModifiers mods = CultureAndRegionModifiers.None;
                if (name.IndexOf('-') < 0)
                    mods |= CultureAndRegionModifiers.Neutral;

                // See if we already have one
                try
                {
                    CultureInfo test = CultureInfo.GetCultureInfo(name);
                    mods |= CultureAndRegionModifiers.Replacement;
                }
                catch (System.ArgumentException)
                {
                    // name doesn't exist (yet)
                }

				//Use the builder to register the culture
				CultureAndRegionInfoBuilder cib = new CultureAndRegionInfoBuilder(
				                                         name, mods);                

                cib.LoadDataFromCultureInfo(ci);
                if ((mods & CultureAndRegionModifiers.Neutral) == 0)
                    cib.LoadDataFromRegionInfo(ri);
                cib.IetfLanguageTag = name;
				cib.Register();

				//Add the new culture using the DisplayCulture
				Add(name);
				MessageBox.Show(Constants.SuccessMessage);
			}
			catch (System.ArgumentOutOfRangeException ex)
			{
				MessageBox.Show(ex.ToString());
			} catch (System.InvalidOperationException) {
            MessageBox.Show("That culture already exists. Please add a NEW instance of a culture");
            } catch (System.ArgumentException) {
                MessageBox.Show("That culture already exists. Please add a NEW instance of a culture");
            }
        }

		/**
		 * Get all cultures of a particular type
		 * Used to load the Comboboxes
		 */
		public string[] GetCultures(CultureTypes type)
		{
			CultureInfo[] cis = CultureInfo.GetCultures(type);
			string[] names = new string[cis.Length];
			for (int i = 0; i < cis.Length; i++) 
				names[i] = cis[i].Name;

			return names;
		}

		public void Add(string cultureName)
		{
			displayHelper.AddSelectItem(cultureName);
		}
	}
}
