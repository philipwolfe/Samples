using System;
using System.Storage.Core;
using System.Storage.Contact;
using MSAvalon.Windows;
using MSAvalon.Windows.Controls;
using MSAvalon.Windows.Documents;
using MSAvalon.Windows.Navigation;
using MSAvalon.Windows.Shapes;

namespace WinFSCRM
{
    /// <summary>
	/// Interaction logic for ClientInformation.xaml
    /// </summary>

	public partial class ClientInformation: FlowPanel
    {
		public void LoadData(Person person)
		{
			this.displayName.Text = (string)person.DisplayName;
			this.givenName.Text = (string)person.PrimaryName.GivenName;
			this.surname.Text = (string)person.PrimaryName.Surname;
			this.imAddress.Text = (string)person.BestIMAddress.Address;
			this.provider.Text = (string)person.BestIMAddress.ProviderUri;
			Address a = person.PersonalAddresses[0] as Address;
			this.addressLine.Text = (string)a.AddressLine;
			this.city.Text = (string)a.PrimaryCity;
			this.postalCode.Text = (string)a.PostalCode;
			this.country.Text = (string)a.CountryRegion;
			this.email.Text = (string)person.PrimaryEmailAddress.Address;
			this.areaCode.Text = (string)person.BestTelephoneNumber.AreaCode;
			this.number.Text = (string)person.BestTelephoneNumber.Number;
		}
    }
}