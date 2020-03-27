// File: validation.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#ifndef VALIDATION_H
#define VALIDATION_H

#include "StdAfx.h"

// regular expressions to be used for client-side validation
// For JScript regular expression syntax, refer to the following URL:
// http://msdn.microsoft.com/scripting/default.htm?/scripting/JScript/doc/reconintroductiontoregularexpressions.htm
#define REGEX_TITLE		"^(Mr.|Mrs.|Ms.|Dr.){1}$"
#define REGEX_NAME		"^([a-zA-Z ]+)$"
#define REGEX_EMAIL		"^([\\.\\w])+\\@([a-zA-Z\\d-]+\\.)+([a-zA-Z]{2,3})$"
#define REGEX_PHONE		"^([0-9]{3}-[0-9]{3}-[0-9]{4})$"
#define REGEX_TEXT		"^([\\w\\. ]*)$"
#define REGEX_TEXT_REQ	"^([\\w-\\. ]+)$"  //you can make a variable required by tightening the regular expression
#define REGEX_STATE		"^([A-Z]){2}$"
#define REGEX_ZIPCODE	"^(\\d{5})(-\\d{4})?$"

//regular expressions to be used for server-side validation
//Note: ATL regular expressions are not grammatically equivalent to JScript, Perl 5, POSIX, or .NET regular expressions.
//For this reason, you will likely need to maintain a separate collection of regular expressions than used with other implementations.
#define ATLS_REGEX_TITLE	"^{Mr\\.}|{Mrs\\.}|{Ms\\.}|{Dr\\.}$"
#define ATLS_REGEX_NAME		"^{[a-zA-Z ]+}$"
#define ATLS_REGEX_EMAIL	"^{[\\._a-zA-Z0-9]}+\\@{[a-zA-Z0-9-]+\\.}+{{[a-zA-Z][a-zA-Z]}|{[a-zA-Z][a-zA-Z][a-zA-Z]}}$"
#define ATLS_REGEX_PHONE	"^{[0-9][0-9][0-9]}-{[0-9][0-9][0-9]}-{[0-9][0-9][0-9][0-9]}$"
#define ATLS_REGEX_TEXT		"^{[a-zA-Z0-9-\\. ]*}$"
#define ATLS_REGEX_TEXT_REQ	"^{[a-zA-Z0-9-\\. ]+}$"  //make a variable required by tightening the regular expression (+ instead of *)
#define ATLS_REGEX_STATE	"^{[A-Z][A-Z]}$"
#define ATLS_REGEX_ZIPCODE	"^{[0-9][0-9][0-9][0-9][0-9]}|{[0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]}$"

//define specific values used in creating input elements
char * titles[] =	{"","Mr.","Mrs.","Ms.","Dr."};
char * postalCodeNames[] =
			{"Alabama","Alaska","American Samoa","Arizona","Arkansas","California","Colorado","Connecticut","Delaware","District Of Columbia",
			 "Federated States Of Micronesia","Florida","Georgia","Guam","Hawaii","Idaho","Illinois","Indiana","Iowa","Kansas","Kentucky", 
			 "Louisiana","Maine","Marshall Islands","Maryland","Massachusetts","Michigan","Minnesota","Mississippi","Missouri","Montana", 
			 "Nebraska","Nevada","New Hampshire","New Jersey","New Mexico","New York","North Carolina","North Dakota","Northern Mariana Islands",
			 "Ohio","Oklahoma","Oregon","Palau","Pennsylvania","Puerto Rico","Rhode Island","South Carolina","South Dakota","Tennessee",
			 "Texas","Utah","Vermont","Virgin Islands","Virginia","Washington","West Virginia","Wisconsin","Wyoming","Armed Forces Africa",
			 "Armed Forces Americas","Armed Forces Canada","Armed Forces Europe","Armed Forces Middle East","Armed Forces Pacific"};
char * postalCodeValues[] =
			{"AL","AK","AS","AZ","AR","CA","CO","CT","DE","DC","FM","FL","GA","GU","HI","ID","IL","IN","IA","KS","KY","LA","ME","MH","MD",
			 "MA","MI","MN","MS","MO","MT","NE","NV","NH","NJ","NM","NY","NC","ND","MP","OH","OK","OR","PW","PA","PR","RI","SC","SD","TN",
			 "TX","UT","VT","VI","VA","WA","WV","WI","WY","AE","AA","AE","AE","AE","AP" };

typedef struct 
{
	char * name;
	char * regex;
	char * atl_regex;
	char * error;
	bool valid;
} formVar;

//now build an array of formVar structs representing the HTML form 
#define NUMBER_OF_FORM_VARS		10
const formVar theForm[NUMBER_OF_FORM_VARS] = 
{
	{"Title",		REGEX_TITLE, 	ATLS_REGEX_TITLE,	"Title must be either Mr., Mrs., Ms., or Dr."								},
	{"FirstName",	REGEX_NAME,		ATLS_REGEX_NAME,	"First Name is required and may only contain letters and spaces."			},
	{"LastName",	REGEX_NAME,		ATLS_REGEX_NAME,	"Last Name is required and may only contain letters and spaces."			},
	{"Email",		REGEX_EMAIL,	ATLS_REGEX_EMAIL,	"Email must be of the form: someone@microsoft.com"							},
	{"Phone",		REGEX_PHONE,	ATLS_REGEX_PHONE,	"Phone number must be of the form: xxx-xxx-xxxx"							},
	{"Street1",		REGEX_TEXT_REQ,	ATLS_REGEX_TEXT_REQ,"The first line of your address is missing or contains invalid characters."	},
	{"Street2",		REGEX_TEXT,		ATLS_REGEX_TEXT,	"The second line of your address contains invalid characters."				},
	{"City",		REGEX_TEXT_REQ,	ATLS_REGEX_TEXT_REQ,"City is missing or contains invalid characters."							},
	{"State",		REGEX_STATE,	ATLS_REGEX_STATE,	"Please select a state."													},
	{"ZipCode",		REGEX_ZIPCODE,	ATLS_REGEX_ZIPCODE,	"Zip Code is required and must be of the form: xxxxx or xxxxx-xxxx"			}
};

#endif