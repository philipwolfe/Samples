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

#define IDR_DOCUMENT "<m:document changeNumber id creator>" \"<m:name xml:lang=\"en\">{{GetName}}</m:name>" \"<m:stream>" \"<m:body> {{GetBody}} </m:body>" \"</m:stream>" \"</m:document>";

#define IDR_FROM "<m:from>" \"<m:identityHeader>" \"<m:onBehalfOfUser></m:onBehalfOfUser>" \"<m:licenseHolder></m:licenseHolder>" \"<m:platformId></m:platformId>" \"</m:identityHeader>" \"<m:expiresAt></m:expiresAt>" \"<m:acknowledge></m:acknowledge>" \"<m:category></m:category>" \"</m:from>";

#define IDR_CONNECTION "<m:connection>" \"<m:class>{{get_class}}</m:class>" \"<m:status>{{get_status}}</m:status>" \"<m:characteristics>{{get_characteristics}}</m:characteristics>" \"<m:expiration>{{get_expiration}}</m:expiration>" \"<m:argotQuery>{{get_argotQuery}}</m:argotQuery>" \
"</m:connection>";

#define IDR_INSERT "<hs:insertRequest xmlns:hs=\"http://schemas.microsoft.com/hs/2001/10/core\" xmlns:m=\"http://schemas.microsoft.com/hs/2001/10/{{GetService}}\" select=\"/m:{{GetService}}\">" \
"{{GetInsertBody}}" \
"</hs:insertRequest>";

#define IDR_SCREENNAME "<m:screenName>" \"{{set_prefix(mp)}}" \"{{get_cat}}" \"{{get_name}}" \
"</m:screenName>";

#define IDR_SECURITYCERTIFICATE "<m:securityCertificate>" \"{{set_prefix(mp)}}" \"{{get_cat}}" \"<mp:certificate>{{get_certificate}}</mp:certificate>" \"</m:securityCertificate>";

#define IDR_SPECIALDATE "<m:specialDate>" \"{{set_prefix(mp)}}" \"{{get_cat}}" \"<mp:date>{{get_date}}</mp:date>" \"</m:specialDate>";

#define IDR_TELEPHONENUMBER "<m:telephoneNumber>" \"{{set_prefix(hs)}}" \"{{get_cat}}" \"<hs:countryCode>{{get_countryCode}}</hs:countryCode>" \"<hs:nationalCode>{{get_nationalCode}}</hs:nationalCode>" \"<hs:number>{{get_number}}</hs:number>" \"<hs:numberExtension>{{get_numberExtension}}</hs:numberExtension>" \"<hs:pin>{{get_pin}}</hs:pin>" \"</m:telephoneNumber>";

#define IDR_USERREFERENCE "<m:userReference>" \"{{set_prefix(hs)}}" \"{{get_name}}" \"<hs:puid>{{get_puid}}</hs:puid>" \"<hs:email>{{get_email}}</hs:email>" \"{{get_cat}}" \"</m:userReference>";

#define IDR_WALLET   "<m:cat ref=\"...\">0..unbounded</m:cat>" \
"<m:typeOfCard>1..1</m:typeOfCard>" \
"<m:networkBrand>1..1</m:networkBrand>" \"<m:affiliateBrand>0..1</m:affiliateBrand>" \
"<m:cardNumber>1..1</m:cardNumber>" \
"<m:displayNumber>1..1</m:displayNumber>" \
"<m:nameOnCard xml:lang=\"...\" dir=\"...\">1..1</m:nameOnCard>" \
"<m:description xml:lang=\"...\" dir=\"...\">1..1</m:description>" \
"<m:expirationDate>0..1</m:expirationDate>" \
"<m:issueDate>0..1</m:issueDate>" \
"<m:validFromDate>0..1</m:validFromDate>" \
"<m:issueNumber>0..1</m:issueNumber>";

#define IDR_WEBSITE "<m:webSite>" \"{{set_prefix(mp)}}" \
"{{get_cat}}" \
"<mp:url>{{get_url}}</mp:url>" \
"</m:webSite>";

#define IDR_XMI "<?xml version='1.0' ?>" \"<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:x=\"http://schemas.xmlsoap.org/rp/\" xmlns:hs=\"http://schemas.microsoft.com/hs/2001/10/core\" xmlns:ss=\"http://schemas.xmlsoap.org/soap/security/2000-12/\">" \"<s:Header>" \"<x:path>" \"	<x:action>{{GetPathAction}}</x:action>" \"		<x:rev>" \"			<x:via>{{GetPathRev}}</x:via>" \"		</x:rev>" \"<x:to>{{GetPathTo}}</x:to>" \"<x:id>{{GetMessageID}}</x:id>" \"</x:path>" \"<ss:licenses>" \
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

#define IDR_WORKINFORMATION "<m:workInformation>" \"{{set_prefix(mp)}}" \"{{get_cat}}" \"{{get_profession}}" \"{{get_jobTitle}}" \"{{get_officeLocation}}" \"{{get_coworkerOrDepartment}}" \"</m:workInformation>";

#define IDR_LIST "<m:list>" \"<m:title xml:lang=\"en\">{{GetTitle}}</m:title>" \"<m:description xml:lang=\"en\">{{GetDescription}}</m:description>" \"</m:list>" \"{{while HasMoreItems}}" \"<m:item>" \"<m:title xml:lang=\"en\">{{GetItemTitle}}</m:title>" \"<m:description xml:lang=\"en\">{{GetItemDescription}}</m:description>" \"</m:item>" \"{{endwhile}}";

#define IDR_ADDRESS "<m:{{get_localname}}>" \"{{set_prefix(hs)}}" \"{{get_cat}}" \"{{get_officialAddressLine}}" \"{{get_internalAddressLine}}" \"{{get_primaryCity}}" \"{{get_secondaryCity}}" \"{{get_subdivision}}" \
"<hs:postalCode>{{get_postalCode}}</hs:postalCode>" \
"<hs:countryCode>{{get_countryCode}}</hs:countryCode>" \
"<hs:latitude>{{get_latitude}}</hs:latitude>" \
"<hs:longitude>{{get_longitude}}</hs:longitude>" \
"<hs:elevation>{{get_elevation}}</hs:elevation>" \
"{{get_velocity}}" \
"<hs:confidence>{{get_confidence}}</hs:confidence>" \
"<hs:precision>{{get_precision}}</hs:precision>" \
"</m:{{get_localname}}>";

#define IDR_COWORKERORDEPARTMENT "<mp:coworkerOrDepartment>" \"{{set_prefix(hs)}}" \"{{get_name}}" \"<hs:puid>{{get_puid}}</hs:puid>" \"<hs:email>{{get_email}}</hs:email>" \"{{get_cat}}" \"</mp:coworkerOrDepartment>";

#define IDR_EMAILADDRESS "<m:emailAddress>{{set_prefix(mp)}}{{get_cat}}<mp:email>{{get_email}}</mp:email>{{get_name}}</m:emailAddress>";

#define IDR_IDENTIFICATIONNUMBER "<m:identificationNumber>" \
"{{set_prefix(mp)}}" \
"{{get_cat}}" \
"<mp:number>{{get_number}}</mp:number>" \
"</m:identificationNumber>";

#define IDR_NAME  "<m:name>" \"{{set_prefix(mp)}}" \"{{get_cat}}" \"{{get_title}}" \"{{get_givenName}}" \"{{get_middleName}}" \"{{get_surname}}" \"{{get_suffix}}" \"{{get_fileasname}}" \"</m:name>";

#define IDR_INSERTRESPONSE "<hs:insertResponse xmlns:hs=\"http://schemas.microsoft.com/hs/2001/10/core\">" \"<hs:newBlueId>{{get_newBlueId}}</hs:newBlueId>" \"</hs:insertResponse>";

#define IDR_NOTIFY "<m:notifyRequest" \"xmlns:m=\"http://schemas.microsoft.com/hs/2001/10/myAlerts\"" \"xmlns:hs=\"http://schemas.microsoft.com/hs/2001/10/core\">" \"<m:notification>" \"<m:from>" \ "</m:from>" \"<m:to>" \"<m:originalUser>{{GetToID}}</m:originalUser>" \"</m:to>" \"<m:contents>{{GetContents}}</m:contents>" \"<m:routing></m:routing>" \"</m:notification>" \"</m:notifyRequest>";

#define IDR_LOCALIZABLESTRING "<{{get_prefix}}:{{get_localname}} xml:lang=\"{{get_lang}}\" dir=\"{{get_dir}}\">{{get_value}}</{{get_prefix}}:{{get_localname}}>";

#define IDR_EMPTY "";


#define IDR_PICTURE "<m:{{get_localname}}>" \"{{set_prefix(mp)}}" \"{{get_cat}}" \"<mp:url>{{get_url}}</mp:url>" \"</m:{{get_localname}}>";


#define IDR_POLL "<m:pollRequest xmlns:m=\"http://schemas.microsoft.com/hs/2001/10/myAlerts\" xmlns:hs=\"http://schemas.microsoft.com/hs/2001/10/core\">" \"</m:pollRequest>";

#define IDR_QUERY "<hs:queryRequest xmlns:m=\"http://schemas.microsoft.com/hs/2001/10/{{GetService}}\" " \"xmlns:hs=\"http://schemas.microsoft.com/hs/2001/10/core\">" \"<hs:xpQuery select=\"{{GetXpSelectClause}}\"/>" \"</hs:queryRequest>";

#define IDR_VELOCITY "<hs:velocity>" \"<hs:speed>{{get_speed}}</{{get_prefix}}:speed>" \"<hs:direction>{{get_direction}}</{{get_prefix}}:direction>" \"</hs:velocity>";

#define IDR_NOTIFICATION "";

#define IDR_NOTIFYREQUEST "";

#define IDR_ACCOUNT "<m:account>" \"{{set_prefix(m)}}" \"{{get_cat}}" \"<m:typeOfAccount>{{get_typeOfAccount}}</m:typeOfAccount>" \"<m:accountRoutingNumber>{{get_accountRoutingNumber}}</m:accountRoutingNumber>" \"{{get_accountNumber}}" \"<m:displayNumber>{{get_displayNumber}}</m:displayNumber>" \"{{get_nameOnAccount}}" \"{{get_description}}" \"{{get_currency}}" \"{{get_accountAddress}}" \"<m:paymentInstrumentsIssuerPuid>{{get_paymentInstrumentsIssuerPuid}}</m:paymentInstrumentsIssuerPuid>" \"</m:account>";

#define IDR_CARD "<m:card>" \"{{set_prefix(m)}}" \"{{get_cat}}" \"<m:typeOfCard>{{get_typeOfCard}}</m:typeOfCard>" \"<m:networkBrand>{{get_networkBrand}}</m:networkBrand>" \"<m:affiliateBrand>{{get_affiliateBrand}}</m:affiliateBrand>" \"<m:cardNumber>{{get_cardNumber}}</m:cardNumber>" \"<m:displayNumber>{{get_displayNumber}}</m:displayNumber>" \"{{get_nameOnCard}}" \"{{get_description}}" \"<m:expirationDate>{{get_expirationDate}}</m:expirationDate>" \"<m:issueDate>{{get_issueDate}}</m:issueDate>" \"<m:validFromDate>{{get_validFromDate}}</m:validFromDate>" \"<m:issueNumber>{{get_issueNumber}}</m:issueNumber>" \"{{get_currency}}" \"{{get_billingaddress}}" \"<m:paymentInstrumentsIssuerPuid>{{get_paymentInstrumentsIssuerPuid}}</m:paymentInstrumentsIssuerPuid>" \
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