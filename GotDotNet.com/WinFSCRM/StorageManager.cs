using System;
using System.IO;
using System.Collections;
using System.Xml.Serialization;
using System.Storage;
using System.Storage.Core;
using System.Storage.Contact;

namespace WinFSCRM
{
	internal class StorageManager
	{
		private static ItemContext context;
		private string folderName;

		public StorageManager(string folderName)
		{
			this.folderName = folderName;
		}

		public Person[] GetClients()
		{
			ArrayList list = null;

			this.OpenContext();

			Folder udf = UserDataFolder.FindMyUserDataFolder(context);
			Folder sampleDataFolder = udf.GetOneMemberWithName(folderName) as Folder;
			FindResult result = sampleDataFolder.GetAllMembersOfType(typeof(Person));

			list = new ArrayList();
			foreach (Person client in result)
			{
				list.Add(client);
			}

			return list.ToArray(typeof(Person)) as Person[];
		}

		public Document[] GetNotes()
		{
			ArrayList list = null;

			this.OpenContext();

			Folder udf = UserDataFolder.FindMyUserDataFolder(context);
			Folder sampleDataFolder = udf.GetOneMemberWithName(folderName) as Folder;
			FindResult result = sampleDataFolder.GetAllMembersOfType(typeof(Document));

			list = new ArrayList();
			foreach (System.Storage.Core.Document document in result)
			{
				list.Add(document);
			}

			return list.ToArray(typeof(Document)) as Document[];
		}

		public Event[] GetEvents()
		{
			ArrayList list = null;

			this.OpenContext();

			Folder udf = UserDataFolder.FindMyUserDataFolder(context);
			Folder sampleDataFolder = udf.GetOneMemberWithName(folderName) as Folder;
			FindResult result = sampleDataFolder.GetAllMembersOfType(typeof(Event));

			list = new ArrayList();
			foreach (System.Storage.Core.Event e in result)
			{
				list.Add(e);
			}

			return list.ToArray(typeof(Event)) as Event[];
		}

		public string[] RunFullSearch(string query)
		{
			ArrayList list = null;

			this.OpenContext();

			Folder udf = UserDataFolder.FindMyUserDataFolder(context);
			Folder sampleDataFolder = udf.GetOneMemberWithName(folderName) as Folder;
			// An example of an OPath
			FindResult result = sampleDataFolder.GetAllMembersOfType("DisplayName LIKE '%" + query + "%'");

			list = new ArrayList();
			foreach (System.Storage.Item i in result)
			{
				list.Add((string)i.DisplayName);
			}

			return list.ToArray(typeof(string)) as string[];
		}

		public void CreateSampleData()
		{
			try
			{
				// We open a static context, because when I use the c# using pattern,
				//	which is recommended, I get errors.
				this.OpenContext();
				// Delete any data that may still exist so we can 
				//	writer new data.
				this.DeleteSampleData();

				// Get the User's data folder.
				//	This is dependent on the context.  You can change the context volume,
				//	by simply passing a string of the new location to ItemContext.Open(...).
				Folder udf = UserDataFolder.FindMyUserDataFolder(context);
				// Now, grab a reference to the folder whose name was passed in the 
				//	constructor to the class.  This is dependent on the user data folder
				//	from above.
				Folder sampleDataFolder = udf.GetOneMemberWithName(folderName) as Folder;

				// This code is redundant for demonstration purposes.  Usually you
				//	won't delete and then create data.
				if (sampleDataFolder == null)
				{
					// Create the new folder that we deleted above, passing the folder
					//	that will be the parent, which is udf.
					sampleDataFolder = new Folder(udf, folderName);
					// Set the display name
					sampleDataFolder.DisplayName = folderName;
				}

				// Update everything to the store
				context.Update();
				
				// Iterate through our serialized sample data
				foreach (ClientData data in this.DeserializeClientData())
				{
					// Create a Person, look at the function for more details on a Person item
					Person client = this.CreateClient(data, sampleDataFolder);
					
					// We are going to add a relationship to the folder that points
					//	to the Person item.  Relationships are important, because remember
					//	that many folders can point to the same item, in this case, a Person.
					//	So, it is not always the case that the item is directly parented under a folder,
					//	as in this case.
					sampleDataFolder.MemberRelationships.Add(new FolderMembersRelationship(client, (string)client.DisplayName, false));

					// Create a document, passing the folder that we want it to be referenced in.
					System.Storage.Core.Document doc = new Document(sampleDataFolder, data.NoteDisplayName);

					doc.Title = data.NoteDisplayName;
					doc.DisplayName = data.NoteDisplayName;

					// Author of the document
					Author author = new Author();
					// Create a relationship between the client created above and the
					//	document author, which in this case, is the same person.  So,
					//	you could imagine running an OPath query that finds all documents
					//	authored by the client above.
					author.TargetItem = client;
					author.DisplayName = client.DisplayName;
					author.Name = client.DisplayName;
					doc.Authors.Add(author);
					doc.Body = System.Text.Encoding.UTF8.GetBytes(data.Note);
					// Create an event, nothing new
					System.Storage.Core.Event e = new System.Storage.Core.Event(sampleDataFolder, data.EventDisplayName);

					e.Description = data.EventBody;
					e.DisplayName = data.EventDisplayName;
					e.EventTime = DateTime.Parse(data.EventTime);
				}
				// Final update
				context.Update();
			}
			catch (Exception)
			{
			}
		}


		private ClientData[] DeserializeClientData()
		{
			ClientData[] list = new ClientData[0];

			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(ClientData[]));
				StreamReader reader = new StreamReader(@"../../sampleData.xml");

				list = serializer.Deserialize(reader) as ClientData[];
				reader.Close();
			}
			catch(Exception ex)
			{
				string s = ex.Message;
			}
			return list;
		}

		private Person CreateClient(ClientData data, Folder folder)
		{
			// I picked some important fields to populate, but be sure
			//	to surf Intellisense on your own to experience the depth
			//	of the schemas.


			Person client = new Person(folder, data.GivenName + " " + data.SurName);

			client.DisplayName = data.GivenName + " " + data.SurName;
			client.CreatePrimaryName();
			client.PrimaryName.GivenName = data.GivenName;
			client.PrimaryName.Surname = data.SurName;

			InstantMessagingAddress im = new InstantMessagingAddress();

			im.Address = data.IMAddress;
			im.ProviderUri = "MSN";
			client.PersonalInstantMessagingAddresses.Add(im);

			Address a = new Address();
			a.AddressLine = data.AddressLine1;
			a.PrimaryCity = data.City;
			a.PostalCode = data.PostalCode;
			a.CountryRegion = "USA";
			client.PersonalAddresses.Add(a);

			SmtpEmailAddress sea = new SmtpEmailAddress(data.Email);

			client.PersonalEmailAddresses.Add(sea);

			TelephoneNumber tn = new TelephoneNumber();

			tn.AreaCode = data.AreaCode;
			tn.Number = data.Number;
			client.PersonalTelephoneNumbers.Add(tn);
			return client;
		}

		private void SerializeData()
		{
			ArrayList list = new ArrayList();
			ClientData cd = new ClientData();
			cd.AddressLine1 = "234 Fluker";
			cd.AreaCode = "123";
			cd.City = "Monsterville";
			cd.Email = "bob@builder.com";
			cd.EventBody = "sdfljkasdf";
			cd.EventDisplayName = "Call Bob";
			cd.EventTime = "7/12/2004";
			cd.GivenName = "Bob";
			cd.IMAddress = "bob";
			cd.Note = "asf";
			cd.NoteDisplayName = "Steel Nails";
			cd.Number = "2341331";
			cd.PostalCode = "132";
			cd.State = "Texas";
			cd.SurName = "Hansel";
			list.Add(cd);

			cd = new ClientData();
			cd.AddressLine1 = "234 Fluker";
			cd.AreaCode = "123";
			cd.City = "Monsterville";
			cd.Email = "bob@builder.com";
			cd.EventBody = "sdfljkasdf";
			cd.EventDisplayName = "Call Bob";
			cd.EventTime = "7/12/2004";
			cd.GivenName = "Bob";
			cd.IMAddress = "bob";
			cd.Note = "asf";
			cd.NoteDisplayName = "Steel Nails";
			cd.Number = "2341331";
			cd.PostalCode = "132";
			cd.State = "Texas";
			cd.SurName = "Hansel";
			list.Add(cd);

			cd = new ClientData();
			cd.AddressLine1 = "234 Fluker";
			cd.AreaCode = "123";
			cd.City = "Monsterville";
			cd.Email = "bob@builder.com";
			cd.EventBody = "sdfljkasdf";
			cd.EventDisplayName = "Call Bob";
			cd.EventTime = "7/12/2004";
			cd.GivenName = "Bob";
			cd.IMAddress = "bob";
			cd.Note = "asf";
			cd.NoteDisplayName = "Steel Nails";
			cd.Number = "2341331";
			cd.PostalCode = "132";
			cd.State = "Texas";
			cd.SurName = "Hansel";
			list.Add(cd);

			cd = new ClientData();
			cd.AddressLine1 = "234 Fluker";
			cd.AreaCode = "123";
			cd.City = "Monsterville";
			cd.Email = "bob@builder.com";
			cd.EventBody = "sdfljkasdf";
			cd.EventDisplayName = "Call Bob";
			cd.EventTime = "7/12/2004";
			cd.GivenName = "Bob";
			cd.IMAddress = "bob";
			cd.Note = "asf";
			cd.NoteDisplayName = "Steel Nails";
			cd.Number = "2341331";
			cd.PostalCode = "132";
			cd.State = "Texas";
			cd.SurName = "Hansel";
			list.Add(cd);

			XmlSerializer serializer = new XmlSerializer(typeof(ClientData[]));
			StreamWriter writer = new StreamWriter(@"../../sampleData.xml");

			serializer.Serialize(writer, list.ToArray(typeof(ClientData)) as ClientData[]);;
		}

		public void DeleteSampleData()
		{
			Folder udf = UserDataFolder.FindMyUserDataFolder(context);
			Folder sampleDataFolder = udf.GetOneMemberWithName(folderName) as Folder;

			if(sampleDataFolder != null)
			{
				ArrayList links = new ArrayList();

				// It isw1 Important that you do this.
				//	You have to offload the links into a
				//	temporary array before processing.  If you don't,
				//	the iterator will not be able to find the next Link in
				//	sampleDataFolder.Members, and subsequently throw
				//	an error.
				foreach(Link l in sampleDataFolder.Members)
				{
					links.Add(l);
				}

				foreach(Link link in links)
				{
					if(link.TargetItem != null)
					{
						try
						{
							link.TargetItem.Delete();
							context.Update();
						}
						catch
						{
						}
					}

					sampleDataFolder.Members.Remove(link);
				}

				context.Update();
				sampleDataFolder.Delete();
				context.Update();
			}
		}

		private void OpenContext()
		{
			if (context == null)
			{
				context = ItemContext.Open();
			}
		}
	}
}