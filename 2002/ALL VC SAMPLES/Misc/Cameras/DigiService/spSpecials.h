// spSpecials.h : Declaration of the CGetSpecials

#pragma once

[
	db_source("Provider=SQLOLEDB.1;Persist Security Info=False;User ID=sa;Initial Catalog=Cameras;Data Source=(local);Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=LONFDEMO;Use Encryption for Data=False;Tag with column collation when possible=False"),
	db_command("{ ? = CALL dbo.spGetSpecials }")
]
class CGetSpecials
{
public:

	// The following wizard-generated data members contain status
	// values for the corresponding fields. You
	// can use these values to hold NULL values that the database
	// returns or to hold error information when the compiler returns
	// errors. See "Field Status Data Members in Wizard-Generated
	// Accessors" in the Visual C++ documentation for more information
	// on using these fields.

	DBSTATUS m_dwproduct_idStatus;
	DBSTATUS m_dwproduct_nameStatus;
	DBSTATUS m_dwspecial_priceStatus;

	// The following wizard-generated data members contain length
	// values for the corresponding fields.

	DBLENGTH m_dwproduct_idLength;
	DBLENGTH m_dwproduct_nameLength;
	DBLENGTH m_dwspecial_priceLength;

	[ db_param(1, DBPARAMIO_OUTPUT) ] LONG m_RETURN_VALUE;
	[ db_column(1, status=m_dwproduct_idStatus, length=m_dwproduct_idLength) ] LONG m_product_id;
	[ db_column(2, status=m_dwproduct_nameStatus, length=m_dwproduct_nameLength) ] TCHAR m_product_name[101];
	[ db_column(3, status=m_dwspecial_priceStatus, length=m_dwspecial_priceLength) ] float m_special_price;

	void GetRowsetProperties(CDBPropSet* pPropSet)
	{
		pPropSet->AddProperty(DBPROP_CANFETCHBACKWARDS, true, DBPROPOPTIONS_OPTIONAL);
		pPropSet->AddProperty(DBPROP_CANSCROLLBACKWARDS, true, DBPROPOPTIONS_OPTIONAL);
	}
};


