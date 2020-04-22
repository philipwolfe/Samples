#pragma once

#define IDR_CAT "<{{get_prefix}}:cat ref=\"{{get_ref}}\">{{get_value}}</{{get_prefix}}:cat>";

#define IDR_CONTACT "<m:contact xmlns:mp=\"http://schemas.microsoft.com/hs/2001/10/myProfile\" xmlns:mc=\"http://schemas.microsoft.com/hs/2001/10/myCalendar\">" \
"{{set_prefix(m)}}" \
"{{get_cat}}" \
"{{get_name}}" \
"<m:puid>{{get_puid}}</m:puid>" \
"{{get_specialDate}}" \
"<m:gender>{{get_gender}}</m:gender>" \
"{{get_notes}}" \
"{{get_address}}" \
"{{get_emailaddress}}" \
"{{get_website}}" \
"{{get_screenname}}" \
"{{get_telephonenumber}}" \
"{{get_identificationNumber}}" \
"{{get_workInformation}}" \
"{{get_userReference}}" \
"{{get_securityCertificate}}</m:contact>";

#define IDR_BASEELEMENT "<{{Get_qname}} ref=\"{{Get_ref}}\">" "{{Get_value}}</{{Get_qname}}>";

#define IDR_CURRENCY \
"<m:currency>" \
"<m:currencyCode>{{get_currencycode}}</m:currencyCode>" \
"</m:currency>";

#define IDR_DOCUMENT "<m:document changeNumber id creator>" \

#define IDR_FROM "<m:from>" \

#define IDR_CONNECTION "<m:connection>" \
"</m:connection>";

#define IDR_INSERT "<hs:insertRequest xmlns:hs=\"http://schemas.microsoft.com/hs/2001/10/core\" xmlns:m=\"http://schemas.microsoft.com/hs/2001/10/{{GetService}}\" select=\"/m:{{GetService}}\">" \
"{{GetInsertBody}}" \
"</hs:insertRequest>";

#define IDR_SCREENNAME "<m:screenName>" \
"</m:screenName>";

#define IDR_SECURITYCERTIFICATE "<m:securityCertificate>" \

#define IDR_SPECIALDATE "<m:specialDate>" \

#define IDR_TELEPHONENUMBER "<m:telephoneNumber>" \

#define IDR_USERREFERENCE "<m:userReference>" \

#define IDR_WALLET   "<m:cat ref=\"...\">0..unbounded</m:cat>" \
"<m:typeOfCard>1..1</m:typeOfCard>" \
"<m:networkBrand>1..1</m:networkBrand>" \
"<m:cardNumber>1..1</m:cardNumber>" \
"<m:displayNumber>1..1</m:displayNumber>" \
"<m:nameOnCard xml:lang=\"...\" dir=\"...\">1..1</m:nameOnCard>" \
"<m:description xml:lang=\"...\" dir=\"...\">1..1</m:description>" \
"<m:expirationDate>0..1</m:expirationDate>" \
"<m:issueDate>0..1</m:issueDate>" \
"<m:validFromDate>0..1</m:validFromDate>" \
"<m:issueNumber>0..1</m:issueNumber>";

#define IDR_WEBSITE "<m:webSite>" \
"{{get_cat}}" \
"<mp:url>{{get_url}}</mp:url>" \
"</m:webSite>";

#define IDR_XMI "<?xml version='1.0' ?>" \
"<hs:identity mustUnderstand=\"1\">" \
"<hs:kerberos>{{GetPUID}}</hs:kerberos>" \
"</hs:identity>" \
"</ss:licenses>" \
"<hs:request mustUnderstand=\"1\" service=\"{{GetService}}\" document=\"{{GetDocumentType}}\" method=\"{{GetMethod}}\" genResponse=\"{{GetGenResponse}}\">" \
"<hs:key instance=\"{{GetInstance}}\" cluster=\"{{GetCluster}}\" puid=\"{{GetPUID}}\" />" \
"</hs:request>" \
"</s:Header>" \
"<s:Body>{{GetBody}}</s:Body>" \
"</s:Envelope>";

#define IDR_WORKINFORMATION "<m:workInformation>" \

#define IDR_LIST "<m:list>" \

#define IDR_ADDRESS "<m:{{get_localname}}>" \
"<hs:postalCode>{{get_postalCode}}</hs:postalCode>" \
"<hs:countryCode>{{get_countryCode}}</hs:countryCode>" \
"<hs:latitude>{{get_latitude}}</hs:latitude>" \
"<hs:longitude>{{get_longitude}}</hs:longitude>" \
"<hs:elevation>{{get_elevation}}</hs:elevation>" \
"{{get_velocity}}" \
"<hs:confidence>{{get_confidence}}</hs:confidence>" \
"<hs:precision>{{get_precision}}</hs:precision>" \
"</m:{{get_localname}}>";

#define IDR_COWORKERORDEPARTMENT "<mp:coworkerOrDepartment>" \

#define IDR_EMAILADDRESS "<m:emailAddress>{{set_prefix(mp)}}{{get_cat}}<mp:email>{{get_email}}</mp:email>{{get_name}}</m:emailAddress>";

#define IDR_IDENTIFICATIONNUMBER "<m:identificationNumber>" \
"{{set_prefix(mp)}}" \
"{{get_cat}}" \
"<mp:number>{{get_number}}</mp:number>" \
"</m:identificationNumber>";

#define IDR_NAME  "<m:name>" \

#define IDR_INSERTRESPONSE "<hs:insertResponse xmlns:hs=\"http://schemas.microsoft.com/hs/2001/10/core\">" \

#define IDR_NOTIFY "<m:notifyRequest" \

#define IDR_LOCALIZABLESTRING "<{{get_prefix}}:{{get_localname}} xml:lang=\"{{get_lang}}\" dir=\"{{get_dir}}\">{{get_value}}</{{get_prefix}}:{{get_localname}}>";

#define IDR_EMPTY "";


#define IDR_PICTURE "<m:{{get_localname}}>" \


#define IDR_POLL "<m:pollRequest xmlns:m=\"http://schemas.microsoft.com/hs/2001/10/myAlerts\" xmlns:hs=\"http://schemas.microsoft.com/hs/2001/10/core\">" \

#define IDR_QUERY "<hs:queryRequest xmlns:m=\"http://schemas.microsoft.com/hs/2001/10/{{GetService}}\" " \

#define IDR_VELOCITY "<hs:velocity>" \

#define IDR_NOTIFICATION "";

#define IDR_NOTIFYREQUEST "";

#define IDR_ACCOUNT "<m:account>" \

#define IDR_CARD "<m:card>" \
"</m:card>";

#define IDR_DELETE "<hs:deleteRequest select=\"{{GetXpSelectClause}}\"" \
" xmlns:m=\"http://schemas.microsoft.com/hs/2001/10/{{GetService}}\"" \
" xmlns:hs=\"http://schemas.microsoft.com/hs/2001/10/core\"></hs:deleteRequest>";

#define IDR_ITEM "<m:item>" \
"{{set_prefix(m)}}" \
"{{get_cat}}" \
"{{get_title}}" \
"{{get_description}}" \
"<m:url>{{get_url}</m:url>" \
"<m:listRef>{{get_listRef}}</m:listRef>" \
"<m:date>{{get_date}}</m:date>" \
"<m:status>{{get_status}}</m:status>" \
"<m:priority>{{get_priority}}</m:priority>" \
"{{get_assignedTo}}" \
"</m:item>";

#define IDR_MYLIST "<m:list>" \
"{{set_prefix(m)}}" \
"{{get_cat}}" \
"<m:listRef>{{get_ref}}</m:listRef>" \
"{{get_title}}" \
"{{get_description}}" \
"<m:status>{{get_status}}</m:status>" \
"</m:list>";

#define IDR_APPLICATION_SETTING "<m:applicationSetting>" \
"{{set_prefix(m)}}" \
"{{get_cat}}" \
"<m:name>{{get_name}}</m:name>" \
"{{while has_more_settings}}" \
"<{{get_setting_prefix}}:{{get_setting_name}} xmlns:{{get_setting_prefix}}=\"{{get_name}}\">{{get_setting_value}}</{{get_setting_prefix}}:{{get_setting_name}}>" \
"{{endwhile}}" \
"</m:applicationSetting>";

#define IDR_REPLACE \
"<hs:replaceRequest 	select=\"{{GetXpSelectClause}}\" " \
"	xmlns:hs=\"http://schemas.microsoft.com/hs/2001/10/core\" " \
"	xmlns:m=\"http://schemas.microsoft.com/hs/2001/10/{{GetService}}\" " \
"{{GetItemNamespace}}> " \
"	{{GetBody}} " \
"</hs:replaceRequest>";