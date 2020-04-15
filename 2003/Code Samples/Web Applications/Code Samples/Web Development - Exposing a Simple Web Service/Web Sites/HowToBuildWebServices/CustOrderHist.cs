//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Xml.Serialization;

public class CustomerAndOrderHistoryInfo
{

    // NWPRoducts is a typed Dataset class. See the ReadMe file for more information
    // on how to create this custom type.

    public dsCustOrderHist Orders;

    // Declaratively use the XmlAttribute class to shape the XML returned by the Web
    // service so that the CompanyName field is an attribute instead of an element
    // (the default serialization type). The AttributeName property is also set,
    // which will change its name from CompanyName to Company when serialized. (Note:
    // These XML changes do not have any impact on the client applications in this 
    // sample. You will see the effect of using XMLAttributeAttribute only by directly
    // viewing the XML returned by the Web service. 

    [XmlAttributeAttribute(AttributeName="Company")]public string CompanyName;

}

