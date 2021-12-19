<%@ Page Language="c#" Debug="true" CodeBehind="CensusSample1.aspx.cs" AutoEventWireup="false" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="CensusServer" %>
<%
	Int32			OkFlag = 1;
	PoliticalUnit	FindPu = PoliticalUnit.State;
	String			Name = "", ParentName = "";
	Int32			Year = 1990;
	try{ FindPu = (PoliticalUnit)Enum.Parse(typeof(PoliticalUnit),Request["pu"]); } catch { } 
	try{ Name = Request["name"]; } catch{ }
	try{ ParentName = Request["ParentName"]; } catch { }
	try{ Year = Convert.ToInt32(Request["Year"]); } catch{ }
	CensusService cs = new CensusService();
	CensusFacts cf = cs.GetPoliticalUnitFactsByName ( FindPu, Name, ParentName, Year);
	String SelectPoliticalUnit = "<option value=\"County\"";
	if(FindPu == PoliticalUnit.County) SelectPoliticalUnit += " selected";
	SelectPoliticalUnit += ">County</option><option value=\"City\"";
	if(FindPu == PoliticalUnit.City) SelectPoliticalUnit += " selected";
	SelectPoliticalUnit += ">City</option><option value=\"State\"";
	if(FindPu == PoliticalUnit.State) SelectPoliticalUnit += " selected";
	SelectPoliticalUnit += ">State</option><option value=\"CensusTract\"";
	if(FindPu == PoliticalUnit.CensusTract) SelectPoliticalUnit += " selected";
	SelectPoliticalUnit += ">Tract</option>";
%>
<HTML>
	<HEAD>
		<META NAME="GENERATOR" Content="Microsoft Developer Studio">
		<META HTTP-EQUIV="Content-Type" content="text/html; charset=iso-8859-1">
		<TITLE>Document Title </TITLE>
		<style>
			p {font-family:Verdana,Arial,Helvetica;color=666666;size=2;} td 
			{font-family:Verdana,Arial,Helvetica;color=006699;size=2;font-weight:bold;} 
			h2,h3 {font-family:Verdana,Arial,Helvetica;color=666666;size=2;}
		</style>
	</HEAD>
	<body bgcolor="#ffffff" text="#000000" link="#0000ee" vlink="#551a8b">
		<center>
			<img src="images/census/cb_head.gif" alt="This is a mockup of a potential U.S. Census application">
			<!-- Insert HTML here -->
			<table cellpadding="0" cellspacing="0" border="0">
				<tr>
					<td width="150">
						<h3>
							Use the Form to Alter the Selection
						</h3>
					</td>
					<td>
						<form action="CensusSample1.aspx" method="get">
							<table cellpadding="3" cellspacing="3" border="1" bgcolor="#666666">
								<tr>
									<td align="right" bgcolor="#ffffff">
										Political Unit:
									</td>
									<td align="left" bgcolor="#cccccc">
										<select name="pu" size="1">
											<%=SelectPoliticalUnit%>
										</select>
									</td>
								</tr>
								<tr>
									<td align="right" bgcolor="#ffffff">
										Unit Name (City, State or County):
									</td>
									<td align="left" bgcolor="#cccccc">
										<input type="text" name="name" size="20" value="<%=Name%>">
									</td>
								</tr>
								<tr>
									<td align="right" bgcolor="#ffffff">
										Parent Name (Country or State name):
									</td>
									<td align="left" bgcolor="#cccccc">
										<input type="text" name="parentname" size="20" value="<%=ParentName%>">
									</td>
								</tr>
								<tr>
									<td align="right" bgcolor="#ffffff">
										Census Year:
									</td>
									<td align="left" bgcolor="#cccccc">
										<input type="text" name="year" size="20" value="<%=Year%>">
									</td>
								</tr>
								<tr>
									<td align="right" bgcolor="#ffffff">
										<b>Click Go to search our database:</b>
									</td>
									<td align="left" bgcolor="#cccccc">
										<input type="submit" value="Go" tabindex="106" style="border-bottom:thin solid #000000;	border-right:thin solid #000000;border-top:thin solid #CCCCCC;border-left:thin solid #CCCCCC;font:bold 11px verdana,sans-serif;background-color:#006699;color:#ffffff;cursor:hand;">
									</td>
								</tr>
				</tr>
			</table>
			</form></td></tr></table><%
	if(OkFlag == 1) {
			%>
			<hr>
			<h3>
				<%=cf.Pu.ToString()%>
				of
				<%=cf.Name%>
				,
				<%=cf.SecondaryName%>
			</h3>
			<table cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td bgcolor="#cccccc" align="right">
						Area:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N}",cf.Area)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Population 1990:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Population1990)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Population 1999:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Population1999)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Population Per Square Mile:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Population1990_PerSquareMile)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Households:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Households)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Males:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Males)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Females:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Females)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Whites:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.White)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Blacks:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Black)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Native Americans:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.NativeAmericans)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Asian and Polynesian Islanders:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.AsianPolynesianIslands)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Hispanic:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Hispanic)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Other:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Other)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Under 5 years of age:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Age_Under5)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Between 5 and 17 years of age:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Age_5_17)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Between 18 and 29 years of age:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Age_18_29)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Between 30 and 49 years of age:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Age_30_49)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Between 50 and 64 years of age:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Age_50_64)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						65 years and older:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Age_65_Up)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Never Married:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.NeverMarry)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Married:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Married)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Separated:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Separated)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Widowed:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Widowed)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Divorced:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Divorced)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Households with 1 Male:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.HouseHolds_1Male)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Households with 1 Female:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.HouseHolds_1Female)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Households with children:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Married_Households_Child)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Married Household with Children:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Married_households_NoChild)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Male Household with Children:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Male_Households_Child)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Female Household with Children:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Female_HouseHolds_Child)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Household units:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Household_Units)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Vacant Households:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Vacant)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Households occupied by Owner:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.OwnerOccupied)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Households occupied by Renter:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.RenterOccupied)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Household Median Value:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.MedianValue)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Household Median Rent:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.MedianRent)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Detached Households:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Units_1Detach)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Attached Households:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Units_1Attach)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						2 Unit Households:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Units_2)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						3 to 9 Unit Households:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Units_3_9)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						10 to 49 Unit Households:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Units_10_49)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						50+ Unit Households:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.Units_50_Up)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Mobile Households:&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.MobileHome)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Number of Farms (1987):&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N0}",cf.No_Farms87)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Average Farm Size (1987):&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N}",cf.Avg_Farm_Size87)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Acreage with crops (1987):&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N}",cf.Crop_Acre87)%>
					</td>
				</tr>
				<tr>
					<td bgcolor="#cccccc" align="right">
						Average Sales (1987):&nbsp;
					</td>
					<td align="right">
						<%=String.Format("{0:N}",cf.Avg_Sale87)%>
					</td>
				</tr>
			</table>
			<%
	}
			%>
			<h3>
				Other Links
			</h3>
			<p>
				<table cellpadding="3" cellspacing="3" border="0" width="90%">
					<tr>
						<td>
							<a href="CensusDoc.htm">Documentation</a>
						</td>
						<td>
							Documentation on the Census Database and Web Service
						</td>
					</tr>
					<tr>
						<td>
							<a href="CensusSample1.aspx">Sample Web Form</a>
						</td>
						<td>
							A sample ASP+ page that calls the Census Services
						</td>
					</tr>
					<tr>
						<td>
							<a href="http://terraweb/terranet/CensusService.asmx">ASP CensusService Test 
							Page
						</td>
						<td>
							The ASP+ Web Service test execution page. This page is auto-generated by the 
							ASP+ service.
						</td>
					</tr>
				</table>
				<hr width="75%">
				<table cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td align="left" width="33%">
							&nbsp;
						</td>
						<td align="center" width="33%">
							<IMG SRC="images/census/wordmarktl.gif" ALT="U.S. Census Bureau: Helping You Make Informed Decisions" align="center">
						</td>
						<td align="right" width="33%">
							<img src="images/ts4/bnrWindowsNgws1_sm.gif" align="right" width="118" height="60" alt="Microsoft .NET" border="0">
						</td>
					</tr>
				</table>
		</center>
	</body>
</HTML>
