//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs
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

namespace WorkflowDesignerControl
{
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Collections;
	using System.ComponentModel.Design;
	using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
    using System.Diagnostics;
	using System.Drawing.Design;
	using System.Drawing.Text;
	using System.Drawing;
	using System.IO;
	using System.Reflection;
	using System.Runtime.InteropServices;
	using System.Runtime.Remoting;
	using System.Runtime.Serialization.Formatters;
	using System.Text;
	using System.Windows.Forms.ComponentModel;
	using System.Windows.Forms.Design;
	using System.Windows.Forms;
	using System;
	using System.Workflow.Activities;
	using System.Workflow.ComponentModel;
	using System.Workflow.ComponentModel.Design;

	#region Class Toolbox
	/// <summary>
	/// Class implementing the toolbox functionality in the sample.
	/// Toolbox displays workflow components using which the workflow can be created
	/// For more information on toolbox please refer to IToolboxService, ToolboxItem documentation
	/// 
	/// </summary>
	[ToolboxItem(false)]
	public class ToolboxService: Panel, IToolboxService
	{
        private const string CF_DESIGNER = "CF_WINOEDESIGNERCOMPONENTS";

        private IServiceProvider provider;
		private Hashtable customCreators;
		private Type currentSelection;
		private ListBox listBox = new ListBox();

		//Create the toolbox and add the toolbox entries
		public ToolboxService(IServiceProvider provider)
		{
			this.provider = provider;

			Text = "Toolbox";
			Size = new System.Drawing.Size(224, 350);

			listBox.Dock = DockStyle.Fill;
			listBox.IntegralHeight = false;
			listBox.ItemHeight = 20;
			listBox.DrawMode = DrawMode.OwnerDrawFixed;
			listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			listBox.BackColor = SystemColors.Window;
			listBox.ForeColor = SystemColors.ControlText;
			listBox.MouseMove +=new MouseEventHandler(OnListBoxMouseMove);
			Controls.Add(listBox);

			listBox.DrawItem += new DrawItemEventHandler(this.OnDrawItem);
			listBox.KeyPress += new KeyPressEventHandler(this.OnListKeyPress);
			listBox.SelectedIndexChanged += new EventHandler(this.OnListBoxClick);
			listBox.DoubleClick += new EventHandler(this.OnListBoxDoubleClick);

			AddToolboxEntries(listBox);
		}

		public void AddCreator(ToolboxItemCreatorCallback creator, string format)
		{
			AddCreator(creator, format, null);
		}

		public void AddCreator(ToolboxItemCreatorCallback creator, string format, IDesignerHost host)
		{
			if (creator == null || format == null)
			{
				throw new ArgumentNullException(creator == null ? "creator" : "format");
			}

			if (customCreators == null)
			{
				customCreators = new Hashtable();
			}
			else
			{
				string key = format;

				if (host != null) key += ", " + host.GetHashCode().ToString();

				if (customCreators.ContainsKey(key))
				{
					throw new Exception("There is already a creator registered for the format '" + format + "'.");
				}
			}

			customCreators[format] = creator;
		}

		public void AddLinkedToolboxItem(ToolboxItem toolboxItem, IDesignerHost host)
		{
		}

		public void AddLinkedToolboxItem(ToolboxItem toolboxItem, string category, IDesignerHost host)
		{
		}

		public virtual void AddToolboxItem(ToolboxItem toolboxItem)
		{
		}

		public virtual void AddToolboxItem(ToolboxItem toolboxItem, IDesignerHost host)
		{
		}

		public virtual void AddToolboxItem(ToolboxItem toolboxItem, string category)
		{
		}

		public virtual void AddToolboxItem(ToolboxItem toolboxItem, string category, IDesignerHost host)
		{
		}

		public CategoryNameCollection CategoryNames
		{
			get
			{
                return new CategoryNameCollection(new string[] { "Workflow" });
			}
		}

		public string SelectedCategory
		{
			get
			{
				return "Workflow";
			}
			set
			{
			}
		}

		private ToolboxItemCreatorCallback FindToolboxItemCreator(IDataObject dataObj, IDesignerHost host, out string foundFormat)
		{
			foundFormat = string.Empty;

			ToolboxItemCreatorCallback creator = null;
			if (customCreators != null)
			{
				IEnumerator keys = customCreators.Keys.GetEnumerator();
				while (keys.MoveNext())
				{
					string key = (string)keys.Current;
					string[] keyParts = key.Split(new char[] { ',' });
					string format = keyParts[0];

					if (dataObj.GetDataPresent(format))
					{
						// Check to see if the host matches.
						if (keyParts.Length == 1 || (host != null && host.GetHashCode().ToString().Equals(keyParts[1])))
						{
							creator = (ToolboxItemCreatorCallback)customCreators[format];
							foundFormat = format;
							break;
						}
					}
				}
			}

			return creator;
		}

		public virtual ToolboxItem GetSelectedToolboxItem()
		{
			ToolboxItem toolClass = null;
			if (this.currentSelection != null)
			{
				try
				{
					toolClass = ToolboxService.GetToolboxItem(this.currentSelection);
				}
				catch (TypeLoadException)
				{
				}
			}

			return toolClass;
		}

		public virtual ToolboxItem GetSelectedToolboxItem(IDesignerHost host)
		{
			return GetSelectedToolboxItem();
		}

		public object SerializeToolboxItem(ToolboxItem toolboxItem)
		{
            DataObject dataObject = new DataObject();
            dataObject.SetData(typeof(ToolboxItem), toolboxItem);
            return dataObject;
		}

		public ToolboxItem DeserializeToolboxItem(object dataObject)
		{
			return DeserializeToolboxItem(dataObject, null);
		}

		public ToolboxItem DeserializeToolboxItem(object data, IDesignerHost host)
		{
			IDataObject dataObject = data as IDataObject;

			if (dataObject == null)
			{
				return null;
			}

			ToolboxItem t = (ToolboxItem)dataObject.GetData(typeof(ToolboxItem));

			if (t == null)
			{
				string format;
				ToolboxItemCreatorCallback creator = FindToolboxItemCreator(dataObject, host, out format);

				if (creator != null)
				{
					return creator(dataObject, format);
				}
			}

			return t;
		}

		public ToolboxItemCollection GetToolboxItems()
		{
			return new ToolboxItemCollection(new ToolboxItem[0]);
		}

		public ToolboxItemCollection GetToolboxItems(IDesignerHost host)
		{
			return new ToolboxItemCollection(new ToolboxItem[0]);
		}

		public ToolboxItemCollection GetToolboxItems(string category)
		{
			return new ToolboxItemCollection(new ToolboxItem[0]);
		}

		public ToolboxItemCollection GetToolboxItems(string category, IDesignerHost host)
		{
			return new ToolboxItemCollection(new ToolboxItem[0]);
		}

		public bool IsSupported(object data, IDesignerHost host)
		{
			return true;
		}

		public bool IsSupported(object serializedObject, ICollection filterAttributes)
		{
			return true;
		}

		public bool IsToolboxItem(object dataObject)
		{
			return IsToolboxItem(dataObject, null);
		}

		public bool IsToolboxItem(object data, IDesignerHost host)
		{
			IDataObject dataObject = data as IDataObject;
			if (dataObject == null)
				return false;

			if (dataObject.GetDataPresent(typeof(ToolboxItem)))
			{
				return true;
			}
			else
			{
				string format;
				ToolboxItemCreatorCallback creator = FindToolboxItemCreator(dataObject, host, out format);
				if (creator != null)
					return true;
			}

			return false;
		}

		public new void Refresh()
		{
		}

		public void RemoveCreator(string format)
		{
			RemoveCreator(format, null);
		}

		public void RemoveCreator(string format, IDesignerHost host)
		{
			if (format == null)
				throw new ArgumentNullException("format");

			if (customCreators != null)
			{
				string key = format;
				if (host != null) 
					key += ", " + host.GetHashCode().ToString();
				customCreators.Remove(key);
			}
		}

		public virtual void RemoveToolboxItem(ToolboxItem toolComponentClass)
		{
		}

		public virtual void RemoveToolboxItem(ToolboxItem componentClass, string category)
		{
		}

		public virtual bool SetCursor()
		{
			if (this.currentSelection != null)
			{
				Cursor.Current = Cursors.Cross;
				return true;
			}

			return false;
		}

		public virtual void SetSelectedToolboxItem(ToolboxItem selectedToolClass)
		{
			if (selectedToolClass == null)
			{
				listBox.SelectedIndex = 0;
				OnListBoxClick(null, EventArgs.Empty);
			}
		}

		public void AddType(Type t)
		{
			listBox.Items.Add(new SelfHostToolboxItem(t.AssemblyQualifiedName));
		}

		public Attribute[] GetEnabledAttributes()
		{
			return null;
		}

		public void SetEnabledAttributes(Attribute[] attrs)
		{
		}

		public void SelectedToolboxItemUsed()
		{
			SetSelectedToolboxItem(null);
		}

        public static IDataObject SerializeActivitiesToDataObject(IServiceProvider serviceProvider, ICollection activities)
        {
            // get component serialization service
            ComponentSerializationService css = (ComponentSerializationService)serviceProvider.GetService(typeof(ComponentSerializationService));
            if (css == null)
                throw new InvalidOperationException("Component Serialization Service is missing.");

            // serialize all activities to the store
            SerializationStore store = css.CreateStore();
            using (store)
            {
                foreach (Activity activity in activities)
                    css.Serialize(store, activity);
            }

            // wrap it with clipboard style object
            Stream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, store);
            stream.Seek(0, SeekOrigin.Begin);
            return new DataObject(CF_DESIGNER, stream);
        }

        public static Activity[] DeserializeActivitiesFromDataObject(IServiceProvider serviceProvider, IDataObject dataObj, bool addReference)
        {
            IDesignerHost designerHost = (IDesignerHost)serviceProvider.GetService(typeof(IDesignerHost));
            if (designerHost == null)
                throw new InvalidOperationException("IDesignerHost is missing.");

            if (dataObj == null)
                return new Activity[] { };

            object data = dataObj.GetData(CF_DESIGNER);
            ICollection activities = null;
            if (data is Stream)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                ((Stream)data).Seek(0, SeekOrigin.Begin);
                object serializationData = formatter.Deserialize((Stream)data);
                if (serializationData is SerializationStore)
                {
                    // get component serialization service
                    ComponentSerializationService css = serviceProvider.GetService(typeof(ComponentSerializationService)) as ComponentSerializationService;
                    if (css == null)
                        throw new Exception("ComponentSerializationService is missing.");

                    // deserialize data
                    activities = css.Deserialize((SerializationStore)serializationData);
                }
            }
            else
            {
                // Now check for a toolbox item.
                IToolboxService ts = (IToolboxService)serviceProvider.GetService(typeof(IToolboxService));
                if (ts != null && ts.IsSupported(dataObj, designerHost))
                {
                    ToolboxItem toolBoxItem = ts.DeserializeToolboxItem(dataObj, designerHost);
                    if (toolBoxItem != null)
                    {
                        // this will make sure that we add the assembly reference to project
                        if (addReference && toolBoxItem.AssemblyName != null)
                        {
                            ITypeResolutionService trs = serviceProvider.GetService(typeof(ITypeResolutionService)) as ITypeResolutionService;
                            if (trs != null)
                                trs.ReferenceAssembly(toolBoxItem.AssemblyName);
                        }

                        ActivityToolboxItem ActivityToolboxItem = toolBoxItem as ActivityToolboxItem;
                        if (addReference && ActivityToolboxItem != null)
                            activities = ActivityToolboxItem.CreateComponentsWithUI(designerHost);
                        else
                            activities = toolBoxItem.CreateComponents(designerHost);
                    }
                }
            }

            return (activities != null) ? (Activity[])(new ArrayList(activities).ToArray(typeof(Activity))) : new Activity[] { };
        }

		//Gets the toolbox item associated with a component type
		internal static ToolboxItem GetToolboxItem(Type toolType)
		{
			if (toolType == null)
				throw new ArgumentNullException("toolType");

			ToolboxItem item = null;
			if ((toolType.IsPublic || toolType.IsNestedPublic) && typeof(IComponent).IsAssignableFrom(toolType) && !toolType.IsAbstract)
			{
				ToolboxItemAttribute toolboxItemAttribute = (ToolboxItemAttribute)TypeDescriptor.GetAttributes(toolType)[typeof(ToolboxItemAttribute)];
				if (toolboxItemAttribute != null && !toolboxItemAttribute.IsDefaultAttribute())
				{
					Type itemType = toolboxItemAttribute.ToolboxItemType;
					if (itemType != null)
					{
						// First, try to find a constructor with Type as a parameter.  If that
						// fails, try the default constructor.
						ConstructorInfo ctor = itemType.GetConstructor(new Type[] { typeof(Type) });
						if (ctor != null)
						{
							item = (ToolboxItem)ctor.Invoke(new object[] { toolType });
						}
						else
						{
							ctor = itemType.GetConstructor(new Type[0]);
							if (ctor != null)
							{
								item = (ToolboxItem)ctor.Invoke(new object[0]);
								item.Initialize(toolType);
							}
						}
					}
				}
				else if (!toolboxItemAttribute.Equals(ToolboxItemAttribute.None))
				{
					item = new ToolboxItem(toolType);
				}
			}
			else if (typeof(ToolboxItem).IsAssignableFrom(toolType))
			{
				// if the type *is* a toolboxitem, just create it..
				//
				try
				{
					item = (ToolboxItem)Activator.CreateInstance(toolType, true);
				}
				catch
				{
				}
			}

			return item;
		}

		//Parse the toolbox.txt file embedded in resource and create the entries in toolbox
		private void AddToolboxEntries(ListBox lb)
		{
			Stream selfTools = GetType().Module.Assembly.GetManifestResourceStream(GetType(), "ToolboxItems.txt");
			Debug.Assert(selfTools != null, "Unable to load toollist.txt for type '" + GetType().FullName + "'");

			int len = (int)selfTools.Length;
			byte[] bytes = new byte[len];
			selfTools.Read(bytes, 0, len);

			string entries = Encoding.Default.GetString(bytes);

			int start = 0, end = 0;
			string entry;
			while (end < entries.Length)
			{
				end = entries.IndexOf('\r', start);
				if (end == -1)
					end = entries.Length;

				entry = entries.Substring(start, (end - start));
				if (entry.Length != 0 && !entry.StartsWith(";"))
					lb.Items.Add(new SelfHostToolboxItem(entry));

				start = end + 2;
			}
		}

		private void OnDrawItem(object sender, DrawItemEventArgs e)
		{
			Graphics g = e.Graphics;
			ListBox listBox = (ListBox)sender;
			object objItem = listBox.Items[e.Index];
			SelfHostToolboxItem item = null;
			Bitmap bitmap = null;
			string text = null;

			if (objItem is string)
			{
				bitmap = null;
				text = (string)objItem;
			}
			else
			{
				item = (SelfHostToolboxItem)objItem;
				bitmap = (Bitmap)item.Glyph; // if it's not a bitmap, it's a metafile, and how likely is that?
				text = item.Name;
			}

			bool selected = false;
			bool disabled = false;

			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
				selected = true;

			if ((int)(e.State & (DrawItemState.Disabled | DrawItemState.Grayed | DrawItemState.Inactive)) != 0)
				disabled = true;

			StringFormat format = new StringFormat();
			format.HotkeyPrefix = HotkeyPrefix.Show;

			int x = e.Bounds.X + 4;
			x += 20;

			if (selected)
			{
                Rectangle r = e.Bounds;
                r.Width--; r.Height--;
                g.DrawRectangle(SystemPens.ActiveCaption, r);
            }
			else
			{
				g.FillRectangle(SystemBrushes.Menu, e.Bounds);
				using(Brush border = new SolidBrush(Color.FromArgb(Math.Min(SystemColors.Menu.R + 15, 255), Math.Min(SystemColors.Menu.G + 15, 255), Math.Min(SystemColors.Menu.B + 15, 255))))
				    g.FillRectangle(border, new Rectangle(e.Bounds.X, e.Bounds.Y, 20, e.Bounds.Height));
			}

			if (bitmap != null)
                g.DrawImage(bitmap, e.Bounds.X + 2, e.Bounds.Y + 2, bitmap.Width, bitmap.Height);

            Brush textBrush = (disabled) ? new SolidBrush(Color.FromArgb(120, SystemColors.MenuText)) : SystemBrushes.FromSystemColor(SystemColors.MenuText);
            Font f = new Font("Courier", 8);
            g.DrawString(text, f, textBrush, x, e.Bounds.Y + 2, format);
			if (disabled)
				textBrush.Dispose();
			format.Dispose();
		}

		//Start the drag drop when user selects and drags the tool
		private void OnListBoxMouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && this.listBox.SelectedItem != null)
			{
				SelfHostToolboxItem selectedItem = listBox.SelectedItem as SelfHostToolboxItem;

				if (selectedItem == null || selectedItem.ComponentClass == null)
					return;

				ToolboxItem toolboxItem = ToolboxService.GetToolboxItem(selectedItem.ComponentClass);
				IDataObject dataObject = this.SerializeToolboxItem(toolboxItem) as IDataObject;
				DragDropEffects effects = DoDragDrop(dataObject, DragDropEffects.Copy | DragDropEffects.Move);
			}
		}

		private void OnListBoxClick(object sender, EventArgs eevent)
		{
			SelfHostToolboxItem toolboxItem = listBox.SelectedItem as SelfHostToolboxItem;
			if (toolboxItem != null)
			{
				this.currentSelection = toolboxItem.ComponentClass;
			}
			else if (this.currentSelection != null)
			{
				int index = this.listBox.Items.IndexOf(this.currentSelection);
				if (index >= 0)
					this.listBox.SelectedIndex = index;
			}
		}

		private void OnListKeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 0xD)
			{
				OnListBoxDoubleClick(sender, e);
				e.Handled = true;
			}
		}

		private void OnListBoxDoubleClick(object sener, EventArgs e)
		{
			IToolboxUser docDes = null;
			SelfHostToolboxItem selectedItem = listBox.SelectedItem as SelfHostToolboxItem;
			if (selectedItem == null)
				return;

			this.currentSelection = selectedItem.ComponentClass;
			IDesignerHost host = (IDesignerHost)provider.GetService(typeof(IDesignerHost));//des.ActiveDesigner;
			if (host != null && this.currentSelection != null)
			{
				IDesigner designer = host.GetDesigner(host.RootComponent);
				if (designer is IToolboxUser)
					docDes = (IToolboxUser)designer;

				if (docDes != null)
				{
					ToolboxItem c = ToolboxService.GetToolboxItem(this.currentSelection);
					Debug.Assert(c != null, "Class " + this.currentSelection.FullName + " does not exist");
					if (c != null && docDes.GetToolSupported(c))
					{
						try
						{
							docDes.ToolPicked(c);
						}
						catch (Exception ex)
						{
							IUIService uis = (IUIService)provider.GetService(typeof(IUIService));

							if (uis != null)
								uis.ShowError(ex);
							else
								MessageBox.Show("Error: " + ex.ToString());
						}
					}
				}
				else
				{
					object o  = Activator.CreateInstance(this.currentSelection);
                    SequentialWorkflowActivity service = host.RootComponent as SequentialWorkflowActivity;
					service.Activities.Add(o as Activity);
					host.RootComponent.Site.Container.Add(o as IComponent);
				}
			}
		}
	}
	#endregion

	#region Class SelfHostToolboxItem
	internal class SelfHostToolboxItem
	{
		private string componentClassName;
		private Type componentClass;
		private string name = null;
		private string className = null;
		private Image glyph = null;
	
		public SelfHostToolboxItem(string componentClassName)
		{
			this.componentClassName = componentClassName;
		}

		public string ClassName
		{
			get
			{
				if (className == null)
				{
					className = ComponentClass.FullName;
				}

				return className;
			}
		}

		public Type ComponentClass
		{
			get
			{
				if (componentClass == null)
				{
					componentClass = Type.GetType(componentClassName);
					if (componentClass == null)
					{
						int index = componentClassName.IndexOf(",");
						if (index >= 0)
							componentClassName = componentClassName.Substring(0, index);

                        foreach (AssemblyName referencedAssemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
                        {
                            Assembly assembly = Assembly.Load(referencedAssemblyName);
                            if (assembly != null)
                            {
                                componentClass = assembly.GetType(componentClassName);
                                if (componentClass != null)
                                    break;
                            }
                        }

                        //Finally check in Activities and ComponentModel dll
						componentClass = typeof(SequentialWorkflowActivity).Assembly.GetType(componentClassName);
                        if (componentClass == null)
                            componentClass = typeof(CompositeActivity).Assembly.GetType(componentClassName);

					}
				}

				return componentClass;
			}
		}

		public string Name
		{
			get
			{
				if (name == null)
				{
					if (ComponentClass != null)
						name = ComponentClass.Name;
					else
						name = "Unknown Item";
				}

				return name;
			}
		}

		public virtual Image Glyph
		{
			get
			{
				if (glyph == null)
				{
					Type t = ComponentClass;

					if (t == null)
						t = typeof(Component);

					ToolboxBitmapAttribute attr = (ToolboxBitmapAttribute)TypeDescriptor.GetAttributes(t)[typeof(ToolboxBitmapAttribute)];

					if (attr != null)
						glyph = attr.GetImage(t, false);
				}
				return glyph;
			}
		}

		public override string ToString()
		{
			return componentClassName;
		}
	}
	#endregion
}
