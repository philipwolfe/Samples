Imports System.Web
Imports System.Data
Imports System.Collections
Imports Microsoft.VisualBasic
Imports System.Data.SQLClient


Namespace ASPEnterpriseManager

	'********************************** TABLE CLASS **************************************************************
	Public Class Table
		Dim _Name as String
		Dim _Owner as String
		Dim _DateCreated as Date
		Dim _Identity as String
		Dim _Seed as Integer
		Dim _Increment as Integer
		Dim _Keys as HashTable
		Dim _Columns as ArrayList
		
		
		Public Sub New()
			_Keys = New HashTable
			_Columns = New ArrayList
		End Sub
	
		Public Property Name as String
			Get
				Return(_Name)
			End Get
			Set
         	_Name  = value
         End Set
		End Property
		
		Public ReadOnly Property Owner as String
			Get
				Return(_Owner)
			End Get
		End Property
		
		Public ReadOnly Property DateCreated as Date
			Get
				Return(_DateCreated)
			End Get
		End Property
		
		Public ReadOnly Property Columns as ArrayList
			Get
				Return(_Columns)
			End Get
		End Property
		
		Public ReadOnly Property Keys as HashTable
			Get
				Return(_Keys)
			End Get
		End Property
		
		Public Sub AddColumns (Number as Integer)
			Dim X As Integer
			Dim Column as New ASPEnterpriseManager.Column
			For X = 1 to Number
				Column.AllowNulls = true
				_Columns.Add(Column)
			Next
		End Sub
		
		Public Sub InsertColumn (Position as Integer)
			Dim Column as New ASPEnterpriseManager.Column
			Column.AllowNulls = true
			_Columns.Insert (Position, Column)
		End Sub

		
		Public Sub DropColumn(ColumnName as String)
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim sqlstmt as String = "ALTER TABLE [" & _Name & "] DROP COLUMN [" & ColumnName & "]"
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)		
			Con.Open()
			Dim cmd as SQLCommand = New SQLCommand(sqlstmt, con)
			cmd.ExecuteNonQuery()
		End Sub 

		
		Public Sub CreateColumn(Key as Boolean, Name as String, Type as String, Length as Integer, Precision as Integer, Scale as Integer, Nulls as Boolean, _
			DefaultValue as String, Identity as Boolean, Seed as Integer, Increment as Integer)
				Dim Column as ASPEnterpriseManager.Column = New ASPEnterpriseManager.Column
				Column.IsPrimaryKey = Key
				Column.Name = Name
				Column.Type = Type
				Column.Length = Length
				Column.Precision = Precision
				Column.Scale = Scale
				Column.AllowNulls = Nulls
				Column.DefaultValue = DefaultValue
				Column.IsIdentity = Identity
				Column.Increment = Increment
				Column.Seed = Seed
				_Columns.Add(Column)
		End Sub


' ********************************* CREATE A NEW TABLE ********************************************************************************
		Public Sub Create(TableName as String)
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim X as Integer
			Dim SQLStmt as String
			Dim HasFields as Boolean = False ' Will be set to True if there is at least 1 field with a name so the table can be created
			Dim Precision as String
			Dim Scale as String
			Dim pKeys as String
			
			sqlStmt = "CREATE TABLE [" & TableName & "]" &  vbCRLF
			sqlstmt = sqlstmt & " (" & vbCRLF 
			For X = 0 to _Columns.Count - 1
				if _Columns(X).Name <> "" 
					HasFields = true
					if _Columns(X).Type <> "real" then 
						sqlstmt = sqlstmt & " " &  _Columns(X).Name & "  " & _Columns(X).Type
					else
						sqlstmt = sqlstmt & " " &  _Columns(X).Name & "  float"
					end If
					
					Select Case lcase(_Columns(X).Type)
						
						case "float" :						
										sqlstmt = sqlstmt & " (53) "									
						case "real" :					
										sqlstmt = sqlstmt & " (24) "					
						case "numeric", "decimal" :	
								if _Columns(X).Precision = 0 then
									Precision = 18
								else
									Precision = _Columns(X).Precision
								end if	
								
								Scale = _Columns(X).Scale
																	
								sqlstmt = sqlstmt & " (" & Precision & "," & Scale & ") "		
																		
						case "text", "image", "ntext", "int", "bigint", "smallint", "tinyint", "bit", "datetime", "smalldatetime", "money", "smallmoney", "timestamp", "uniqueidentifier":					
											sqlstmt = sqlstmt & "  " 
						case "binary", "char", "varchar", "nchar", "nvarchar",  "varbinary" :					
											sqlstmt = sqlstmt & " (" & _Columns(X).Length & ")  "					
					End Select
					
					if _Columns(X).IsIdentity <> false then _
						sqlstmt = sqlstmt & " IDENTITY(" & _Columns(X).Seed & ", " & _Columns(X).Increment & ") "	
					
					if _Columns(X).AllowNulls = false then
						sqlstmt = sqlstmt & " NOT NULL "
					else
						sqlstmt = sqlstmt & " NULL "
					end if
					
					if _Columns(X).DefaultValue <> "" then _
						sqlstmt = sqlstmt & " DEFAULT " & _Columns(X).DefaultValue & " "
					
					if _Columns(X).IsPrimaryKey <> false then _
						pKeys = pKeys & _Columns(X).Name & ","
					
					sqlstmt = sqlstmt & ","	
					
				end if
			Next
			
			sqlstmt = Left(sqlstmt, Len(sqlstmt) - 1)
			if pKeys <> "" then pKeys = Left(pKeys, Len(pKeys) - 1)
			
			sqlstmt = sqlstmt & vbCRLF & " )"
			
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)		
			Con.Open()
			Dim cmd as SQLCommand = New SQLCommand(sqlstmt, con)
			cmd.ExecuteNonQuery()
			Dim DR as SQLDataReader 
			
			cmd = New SQLCommand("sp_pkeys [" & TableName & "]", con)
			DR = cmd.ExecuteReader()
			_Context.Trace.Write ("sp_pkeys [" & TableName & "]")
			if dr.read() 
				Dim Con2 as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)		
				Con2.Open()
				Dim cmd2 as SQLCommand = New SQLCommand("DROP INDEX [" & TableName & "]." & dr("PK_NAME"), con2)
				_Context.Trace.Write ("DROP INDEX [" & TableName & "]." & dr("PK_NAME"))
				cmd2.ExecuteNonQuery()
				Con2.Close()
				cmd2 = Nothing
				con2 = Nothing
			end if
			DR.Close()
			_Context.Trace.Write ("Keys Erased....In Theory")
			if pKeys <> "" Then
				Dim Table as String = TableName
				cmd = New SQLCommand("ALTER TABLE [" & TableName & "] ADD CONSTRAINT PK_" & Replace(TableName, " ", "_") & " PRIMARY KEY (" & pKeys & ")", con)
				cmd.ExecuteNonQuery()
				
			end If
			DR.Close()
			dr = Nothing
			cmd = Nothing
			con.close()
			con = nothing
		End Sub
		



' ********************************************** CONVERT ONE TABLE TO ANOTHER **********************************************************************		
		Public Sub ConvertTo (NewTable as Table)
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim X as Integer
			Dim NeedsToBeAltered as Boolean = False
			
			If _Columns.Count = NewTable.Columns.Count Then
				For X = 0 to _Columns.Count - 1
					If _columns(x).IsPrimaryKey <> NewTable.Columns(X).IsPrimaryKey or _
						_columns(x).IsIdentity <> NewTable.Columns(X).IsIdentity or _
						_columns(x).Type <> NewTable.Columns(X).Type or _
						_columns(x).Length <> NewTable.Columns(X).Length or _
						_columns(x).Precision <> NewTable.Columns(X).Precision or _
						_columns(x).Scale <> NewTable.Columns(X).Scale or _
						_columns(x).AllowNulls <> NewTable.Columns(X).AllowNulls or _
						_columns(x).DefaultValue <> NewTable.Columns(X).DefaultValue  Then 
							
						NeedsToBeAltered = True
						
						_Context.Trace.Write (_columns(x).IsPrimaryKey & " " & NewTable.Columns(X).IsPrimaryKey)
						_Context.Trace.Write (_columns(x).IsIdentity & " " & NewTable.Columns(X).IsIdentity)
						_Context.Trace.Write (_columns(x).Type & " " & NewTable.Columns(X).Type)
						_Context.Trace.Write (_columns(x).Length & " " & NewTable.Columns(X).Length)
						_Context.Trace.Write (_columns(x).Precision & " " & NewTable.Columns(X).Precision)
						_Context.Trace.Write (_columns(x).Scale & " " & NewTable.Columns(X).Scale)
						_Context.Trace.Write (_columns(x).AllowNulls & " " & NewTable.Columns(X).AllowNulls)
						_Context.Trace.Write (_columns(x).DefaultValue & " " &  NewTable.Columns(X).DefaultValue)
						
						NewTable.Create (NewTable.Name & "_Temp")	
						Exit For
					End If
				Next
				
				If NeedsToBeAltered Then
						Dim TableName as String = _Name
						Dim NewTableName as String = NewTable.Name & "_Temp"
						Dim sqlstmt2 as String = "Select "
						Dim FoundIdentity as Boolean = False
						Dim sqlstmt as String = "Insert Into [" & NewTableName & "] ("
						Dim con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)		
						Dim cmd as SQLCommand 
						con.Open()
									
						For X = 0 to _Columns.Count - 1
								if _Columns(X).Name <> "" then
									sqlstmt = sqlstmt & NewTable.Columns(X).Name & ","	
									sqlstmt2 = sqlstmt2 & Conversion(_Columns(X).Name, NewTable.Columns(X).Type, _Columns(X).Type, NewTable.Columns(X).Length, NewTable.Columns(X).Precision, NewTable.Columns(X).Scale) & ","
								end if
								if NewTable.Columns(X).IsIdentity then _
									FoundIdentity = True
						Next
						sqlstmt = Left(sqlstmt, Len(sqlstmt) - 1) & ")"
						sqlstmt2 = Left(sqlstmt2, Len(sqlstmt2) - 1) & " from [" & TableName & "] "				
						sqlstmt = sqlstmt & " " & sqlstmt2						
						if FoundIdentity then _
								sqlstmt = "SET IDENTITY_INSERT [" & NewTableName & "] ON " & sqlstmt & " SET IDENTITY_INSERT [" & NewTableName & "] OFF"
					
						Try  ' Try to insert the data from the original table into the new table and delete the old table
							_Context.Trace.Write (sqlstmt)
							cmd = New SQLCommand(sqlstmt, con)
							cmd.executeNonQuery()
							
							cmd = New SQLCommand("DROP TABLE [" & TableName & "]", con)
							cmd.ExecuteNonQuery()
							
							cmd = New SQLCommand("sp_rename '" & NewTableName & "', '" & NewTable.Name & "'", con)
							cmd.ExecuteNonQuery()
							
							_Context.Trace.Write ("sp_rename '" & NewTableName & "', '" & NewTable.Name & "'")
						
						Catch  ' Couldn't get data From old table to new so drop new table and keep old
							_Context.Trace.Write ("ERROR")
							cmd = New SQLCOmmand("DROP TABLE [" & NewTableName & "]", con) 
							cmd.ExecuteNonQuery()
						
						Finally
							con.Close()
							cmd = Nothing
							con = Nothing							
						End try
				Else ' The table does not need to be altered - see if the name of the table needs to be changed
						Dim con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)		
						Dim cmd as SQLCommand 
						con.Open()
						If NewTable.Name <> _Name Then
							cmd = New SQLCommand("sp_rename '" & _Name & "', '" & NewTable.Name & "'", con)
							cmd.ExecuteNonQuery()
						End if
						
						For X = 0 to _Columns.Count - 1
							If _columns(x).Name <> NewTable.Columns(X).Name and Trim(NewTable.Columns(x).Name) <> "" Then
								cmd = New SQLCommand("sp_rename '" & NewTable.Name & "." & _columns(x).Name & "', '" & NewTable.Columns(X).Name & "', 'COLUMN'", con)
								cmd.ExecuteNonQuery()		
							End If
						Next 
						
						
						con.Close()
						cmd = Nothing
						con = Nothing
						
						
						_Context.Trace.Write ("sp_rename '" & _Name & "', '" & NewTable.Name & "'")
					
				End If ' The Table Needs to Be Altered
				
			End If ' Same Number of Columns 
		End Sub
		
		
		' The Following Function makes the Explicit Conversions Required on the field to go from Type2 to Type1
		Private Function Conversion (Field as String, Type1 as String, Type2 as String, Length as String, Precision as String, Scale as String) as String
			Dim PrScale as String
			Type1 = replace(Type1, "(", "")
			Type1 = replace(Type1, ")", "")
			if instr(Type1, " ") then
				Type1 = Trim(Left(Type1, Instr(Type1, " ")))
			end If
			Type2 = replace(Type2, "(", "")
			Type2 = replace(Type2, ")", "")
			if instr(Type2, " ") then
				Type2 = Trim(Left(Type2, Instr(Type2, " ")))
			end If
			Select Case lcase(Type1)								
						case "float" :						
									prScale = " (53) "									
						case "real" :					
									prScale = " (24) "					
						case "numeric", "decimal" :	
									if Precision = "" then
										Precision = 18
									else
										Precision = Precision
									end if	
									
									if Scale = "" then
										Scale = 0
									else
										Scale = Scale
									end if											
									prScale = " (" & Precision & "," & Scale & ") "												
			End Select
			
			Select Case lcase(Type2)
					
					 Case "char", "varchar", "nchar", "nvarchar":
						Select Case lcase(Type1) 
							case "binary":				return " CONVERT(binary(" & Length & "), " & Field & ")"
							case "varbinary":			return " CONVERT(varbinary(" & Length & "), " & Field & ")"
							case "money":				return " CONVERT(money, " & Field & ")"
							case "smallmoney":		return " CONVERT(smallmoney, " & Field & ")"
							case "timestamp":			return " CONVERT(timestamp, " & Field & ")"
							case else: 					return Field
						End Select
							
					case "datetime", "smalldatetime":	
						Select Case lcase(Type1) 
								case "binary":				return " CONVERT(binary(" & Length & "), " & Field & ")"
								case "varbinary":			return " CONVERT(varbinary(" & Length & "), " & Field & ")"
								case "decimal":			return " CONVERT(decimal" & prScale & ", " & Field & ")"
								case "numeric":			return " CONVERT(numeric" & prScale & ", " & Field & ")"
								case "float":				return " CONVERT(float" & prScale & ", " & Field & ")"
								case "real":				return " CONVERT(float" & prScale & ", " & Field & ")"
								case "bigint":				return " CONVERT(bigint, " & Field & ")"
								case "int":					return " CONVERT(int, " & Field & ")"
								case "smallint":			return " CONVERT(smallint, " & Field & ")"
								case "tinyint":			return " CONVERT(tinyint, " & Field & ")"						
								case "money":				return " CONVERT(money, " & Field & ")"
								case "smallmoney":		return " CONVERT(smallmoney, " & Field & ")"
								case "bit":					return " CONVERT(bit, " & Field & ")"
								case "timestamp":			return " CONVERT(timestamp, " & Field & ")"
								case else: 					return Field
						End Select
					
					case "money", "smallmoney":
						Select Case lcase(Type1) 
								case "char":				return " CONVERT(char(" & Length & "), " & Field & ")"
								case "varchar":			return " CONVERT(varchar(" & Length & "), " & Field & ")"
								case "nchar":				return " CONVERT(nchar(" & Length & "), " & Field & ")"
								case "nvarchar":			return " CONVERT(nvarchar(" & Length & "), " & Field & ")"
								case else:					return Field
						End Select
			
					case "ntext":
						Select Case lcase(Type1) 
								case "char":				return " CONVERT(char(" & Length & "), " & Field & ")"
								case "varchar":			return " CONVERT(varchar(" & Length & "), " & Field & ")"
								case else:					return Field
						End Select
						
					case "text":
						Select Case lcase(Type1) 
								case "nchar":				return " CONVERT(nchar(" & Length & "), " & Field & ")"
								case "nvarchar":			return " CONVERT(nvarchar(" & Length & "), " & Field & ")"
								case else:					return Field
						End Select	
			
					case else: 								return Field
			
			End Select
		
		
		End Function
		

' ********************************* LOAD A TABLE ************************************************************************		
		Public Sub Load(TableName as String)
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Dim DR as SqlDataReader
			Con.Open()
			Dim cmd as SQLCommand = New SQLCommand("sp_help '" & TableName & "'", con)
			DR = cmd.ExecuteReader()
			DR.Read
			_Name = TableName
			_Owner = DR("Owner")
			_DateCreated = DR("created_datetime")
			DR.Close()
			
			' Load PrimaryKeys
			cmd = New SQLCommand("sp_pkeys '" & TableName & "'", con)
			DR = cmd.ExecuteReader()
			While DR.Read()
				_Keys.Add(dr("COLUMN_NAME"), "")
			End While
			DR.Close()
			
			cmd = New SQLCommand("Select Ident_Incr('" & TableName & "') as IDENT_INCR, IDENT_SEED('" & TableName & "') as IDENT_SEED from " _
					& " INFORMATION_SCHEMA.TABLES Where TABLE_NAME='" & TableName & "'", con)
			DR = cmd.ExecuteReader()
			if dr.read() then
				_Seed = iif(IsDBNull(dr("Ident_Seed")), -1, dr("Ident_Seed"))
				_Increment = iif(IsDBNull(dr("Ident_Incr")), -1, dr("Ident_Incr"))
			end If
			DR.Close()
			
			cmd = New SQLCommand("SP_Columns '" & TableName & "'", con)
			DR = cmd.ExecuteReader()
			Dim Column as ASPEnterpriseManager.Column
			While DR.Read()
					Column = New Column			
					
					Column.Name = DR("column_name")
					
					If _Keys.ContainsKey(DR("column_Name")) Then
						Column.IsPrimaryKey = True
					Else
						Column.IsPrimaryKey = False
					End If		
					
					' Load Length, Precision Scale of column			
					Column.Length = DR("Length")
					Column.Precision = DR("Precision")
					Column.Scale = IIf(IsDBNull(DR("Scale")), 0, DR("Scale"))		
					
					' Format the Column Size Length(Precision, Scale) - For Display Only
					' Or make changes as necessary to fields
					Select Case lcase(dr("Type_name"))
						Case "nchar", "nvarchar":
									Column.Length = Column.Length / 2
									Column.Precision = Column.Precision / 2
						case "real", "numeric", "decimal"  :						
									Column.Size = Column.Length & "(" & Column.Precision & "," & Column.Scale & ")"	
						case else:
									Column.Size = Column.Length
									if Val(Column.Size) > 100000 then
										Column.Size = "16"
										Column.Length = 16
										Column.Precision = 0
									End if
					End Select
					
					
					' Get the type and exclude charachters that are found in Icentity Type
					Column.Type = dr("Type_Name") 
					Column.Type = replace(Column.Type, "(", "")
					Column.Type = replace(Column.Type, ")", "")
					if InStr(Column.Type, " ") then
						Column.Type = Trim(Left(Column.Type, Instr(Column.Type, " ")))
					end If
					
					' See If Column Is Identity
					if InStr(dr("Type_Name"), "identity") <> 0 Then
						Column.IsIdentity = True
						Column.Increment = _Increment
						Column.Seed = _Seed
					End if
						
					Column.DefaultValue = IIf(IsDBNull(DR("Column_Def")), "", DR("Column_Def"))
					
					if lcase(dr("Is_Nullable")) = "yes" Then _
						Column.AllowNulls = True
						
					_Columns.Add(Column)
			
			End While			
			DR.Close()
			cmd = nothing
			DR = Nothing
			Con.Close()
			Con = Nothing
		End Sub
	End Class
	
	
	
	
' ************************** COLUMN CLASS ****************************************************************************
	Public Class Column
		Dim _IsPrimaryKey as Boolean
		Dim _IsIdentity as Boolean
		Dim _Name as String
		Dim _Type as String
		Dim _Size as String
		Dim _Length as Integer
		Dim _Precision as Integer
		Dim _Scale as Integer
		Dim _AllowNulls as Boolean
		Dim _Default as String
		Dim _Increment as Integer
		Dim _Seed as Integer
	
		Public Sub New()
			_Name = ""
			_Type = ""
			_Size = ""
			_Length = 0
			_Precision = 0
			_Scale = 0
			_IsPrimaryKey = False
			_IsIdentity = False
			_AllowNulls = False
			_Default = ""
		End Sub
	
		Public Property IsPrimaryKey as Boolean
			Get
	           Return(_IsPrimaryKey)
         End get
         Set
         	_IsPrimaryKey  = value
         End Set
		End Property
		
		Public Property IsIdentity as Boolean
			Get
	           Return(_IsIdentity)
         End get
         Set
         	_IsIdentity  = value
         End Set
		End Property
		
		Public Property Name as String
			Get
	           Return(_Name)
         End get
         Set
         	_Name = value
         End Set
		End Property
		
		Public Property Type as String
			Get
	           Return(_Type)
         End get
         Set
         	_Type = value
         End Set
		End Property
		
		Public Property Size as String
			Get
	           Return(_Size)
         End get
         Set
         	_Size = value
         End Set
		End Property
		
		Public Property Length as Integer
			Get
	           Return(_Length)
         End get
         Set
         	_Length = value
         End Set
		End Property
		
		Public Property Precision as Integer
			Get
	           Return(_Precision)
         End get
         Set
         	_Precision = value
         End Set
		End Property
		
		Public Property Scale as Integer
			Get
	           Return(_Scale)
         End get
         Set
         	_Scale = value
         End Set
		End Property
		
		Public Property DefaultValue as String
			Get
	           Return(_Default)
         End get
         Set
         	_Default = value
         End Set
		End Property
		
		Public Property AllowNulls as Boolean
			Get
	           Return(_AllowNulls)
         End get
         Set
         	_AllowNulls  = value
         End Set
		End Property
		
		Public Property Increment as Integer
			Get
	           Return(_Increment)
         End get
         Set
         	_Increment = value
         End Set
		End Property
		
		Public Property Seed as Integer
			Get
	           Return(_Seed)
         End get
         Set
         	_Seed = value
         End Set
		End Property
		   
        
	
	End Class

End NameSpace