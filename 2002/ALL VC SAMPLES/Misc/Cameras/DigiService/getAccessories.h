// getAccessories.h : Declaration of the CGetAccessories

#pragma once

[
	db_source("Provider=SQLOLEDB.1;Persist Security Info=False;User ID=sa;Initial Catalog=Cameras;Data Source=(local);Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=LONFDEMO;Use Encryption for Data=False;Tag with column collation when possible=False"),
	db_command("{ ? = CALL dbo.spGetAccessoriesForCamera(?) }")
]
class CGetAccessories
{
public:

	// The following wizard-generated data members contain status
	// values for the corresponding fields. You
	// can use these values to hold NULL values that the database
	// returns or to hold error information when the compiler returns
	// errors. See "Field Status Data Members in Wizard-Generated
	// Accessors" in the Visual C++ documentation for more information
	// on using these fields.

	DBSTATUS m_dwproduct_nameStatus;
	DBSTATUS m_dwproduct_descStatus;
	DBSTATUS m_dwproduct_priceStatus;

	// The following wizard-generated data members contain length
	// values for the corresponding fields.

	DBLENGTH m_dwproduct_nameLength;
	DBLENGTH m_dwproduct_descLength;
	DBLENGTH m_dwproduct_priceLength;

	[ db_param(1, DBPARAMIO_OUTPUT) ] LONG m_RETURN_VALUE;
	[ db_param(2, DBPARAMIO_INPUT) ] LONG m_nCameraID;
	[ db_column(1, status=m_dwproduct_nameStatus, length=m_dwproduct_nameLength) ] TCHAR m_product_name[101];
	[ db_column(2, status=m_dwproduct_descStatus, length=m_dwproduct_descLength) ] TCHAR m_product_desc[1001];
	[ db_column(3, status=m_dwproduct_priceStatus, length=m_dwproduct_priceLength) ] float m_product_price;

	void GetRowsetProperties(CDBPropSet* pPropSet)
	{
		pPropSet->AddProperty(DBPROP_CANFETCHBACKWARDS, true, DBPROPOPTIONS_OPTIONAL);
		pPropSet->AddProperty(DBPROP_CANSCROLLBACKWARDS, true, DBPROPOPTIONS_OPTIONAL);
	}
};


