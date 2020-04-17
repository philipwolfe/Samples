//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

namespace WorkflowDesignerControl
{
    #region Using Statements
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Drawing.Design;
    using System.Collections;
    using System.ComponentModel;

    #endregion

    #region PropertyValueUIService
    public class PropertyValueUIService : IPropertyValueUIService
    {

        private PropertyValueUIHandler _handler;
        private EventHandler _notifyHandler;
        private ArrayList _itemList;

        public PropertyValueUIService()
        {
        }

       /// <summary>
       /// Adds or removes an event handler that will be invoked
       /// when the global list of PropertyValueUIItems is modified.
       /// </summary>
        event EventHandler IPropertyValueUIService.PropertyUIValueItemsChanged
        {
            add
            {
                _notifyHandler += value;
            }
            remove
            {
                _notifyHandler -= value;
            }
        }

        /// <summary>
        /// Adds a PropertyValueUIHandler to this service.  When GetPropertyUIValueItems is
        /// called, each handler added to this service will be called and given the opportunity
        /// to add an icon to the specified property.
        /// </summary>
        /// <param name="newHandler"></param>
        void IPropertyValueUIService.AddPropertyValueUIHandler(PropertyValueUIHandler newHandler)
        {
            if (newHandler == null)
            {
                throw new ArgumentNullException("newHandler");
            }

            _handler = (PropertyValueUIHandler)Delegate.Combine(_handler, newHandler);
        }

       /// <summary>
       /// Gets all the PropertyValueUIItems that should be displayed on the given property.
       /// For each item returned, a glyph icon will be aded to the property.
       /// </summary>
       /// <param name="context"></param>
       /// <param name="propDesc"></param>
       /// <returns></returns>
        PropertyValueUIItem[] IPropertyValueUIService.GetPropertyUIValueItems(ITypeDescriptorContext context, PropertyDescriptor propDesc)
        {

            if (propDesc == null)
            {
                throw new ArgumentNullException("propDesc");
            }

            if (_handler == null)
            {
                return new PropertyValueUIItem[0];
            }

            lock (this)
            {
                if (_itemList == null)
                {
                    _itemList = new ArrayList();
                }

                _handler(context, propDesc, _itemList);

                int nItems = _itemList.Count;

                if (nItems > 0)
                {
                    PropertyValueUIItem[] items = new PropertyValueUIItem[nItems];
                    _itemList.CopyTo(items, 0);
                    _itemList.Clear();
                    return items;
                }
            }

            return null;
        }

        /// <summary>
        /// Tell the IPropertyValueUIService implementation that the global list of PropertyValueUIItems has been modified.
        /// </summary>
        void IPropertyValueUIService.NotifyPropertyValueUIItemsChanged()
        {
            if (_notifyHandler != null)
            {
                _notifyHandler(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Removes a PropertyValueUIHandler to this service.  When GetPropertyUIValueItems is
        /// called, each handler added to this service will be called and given the opportunity
        /// to add an icon to the specified property.
        /// </summary>
        /// <param name="newHandler"></param>
        void IPropertyValueUIService.RemovePropertyValueUIHandler(PropertyValueUIHandler newHandler)
        {
            if (newHandler == null)
            {
                throw new ArgumentNullException("newHandler");
            }

            _handler = (PropertyValueUIHandler)Delegate.Remove(_handler, newHandler);
        }
    }
    #endregion
}
