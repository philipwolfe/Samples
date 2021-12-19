/***
 ***
 *** Generates an XSD schema and typed dataset for a set of database tables
 ***
 ***/
namespace TypedDataSetGenerator {
    using System;
    using System.Data;
    using System.IO;
    using System.Data.ADO;
    using System.Data.CodeGen;
    using System.Collections;
    using System.CodeDOM.Compiler;

    //* Expose GetSchemaTable so that we can fk info to build relationships
    internal class ADOSchemaConnection : ADOConnection {
        public ADOSchemaConnection(string con) :base(con) {}

        public DataTable ADOGetSchemaTable(Type tableType, Guid schema, object[] restrictions) {
            return this.GetSchemaTable(tableType, schema, restrictions) ;
        }

    }

    public class TDGUtil {
        
        public static void BadInput(string param) {
            Console.WriteLine("Bad Parameter: " + param);        
            BadInput();
        }   

        public static void BadInput() {
            Console.WriteLine("Usage is: TDGUtil /dsname DataSet Name /table TableName /conn ConnectionString [/cs | /vb] [/pn packageName] [/out targetDir]");        
            Console.WriteLine("Can have multiple table parameters");
            Console.WriteLine("\n\tFor example: TDGUtil /dsname CustomersDataSet /cs /table customers /out out /conn \"Provider=SQLOLEDB;Data Source=localhost;Database=northwind;User Id=sa;\"");        
        }   

        public static void Main(string[] args) {
            try {
                
                if (args == null ||
                    args.Length == 0 ||
                    "-h".Equals(args[0]) ||
                    "/h".Equals(args[0])) {
                    BadInput();
                    return;
                }

                bool vb = false, cs = false;
                string dbConnection = null;
                string packageName = null;    
                string targetDir=System.WinForms.Application.StartupPath;
                string xmlFile = null ;
                string dataSetName = null;
                ArrayList tables = new ArrayList();

                int curArg = 0;
                while (curArg < args.Length) {

                    //Console.WriteLine("args[" + curArg + "] = " + args[curArg]);

                    if (String.Compare(args[curArg],"/out", true) == 0) {
                        if (args.Length < curArg + 2 ) {
                            BadInput("/out");
                            return;
                        }
                        curArg++;
                        targetDir = args[curArg];
                    }
                    else if (String.Compare(args[curArg],"/table", true) == 0) {
                        if (args.Length < curArg + 2 ) {
                            BadInput("/table");
                            return;
                        }
                        curArg++ ;
                        tables.Add(args[curArg]);
                    }
                    else if (String.Compare(args[curArg],"/dsname", true) == 0) {
                        if (args.Length < curArg + 2 ) {
                            BadInput("/dsname");
                            return;
                        }
                        curArg++ ;
                        dataSetName = args[curArg];
                    }
                    else if (String.Compare(args[curArg],"/conn", true) == 0) {
                        if (args.Length < curArg + 2 ) {
                            BadInput("/conn");
                            return;
                        }
                        curArg++;
                        dbConnection = args[curArg];
                    }
                    else if (String.Compare(args[curArg],"/cs", true) == 0) {
                        cs = true;
                    }
                    else if (String.Compare(args[curArg],"/vb", true) == 0) {
                        vb = true;
                    }
                    else if (String.Compare(args[curArg], "/pn", true) == 0) {
                        if (args.Length < curArg + 2 ) {
                            BadInput("/pn");
                            return;
                        }
                        curArg++;
                        packageName = args[curArg];
                    }

                    curArg++;
                }

                //Check args
                if (null == dbConnection) {
                    BadInput("/conn");
                    return;
                }

                if (tables.Count == 0) {
                    BadInput("/table");
                    return;
                }

                 //set up defaults if required
                if (null == dataSetName) {
                    dataSetName = tables[0] + "DataSet";
                }

                 //set up defaults if required
                if (null == packageName) {
                    packageName = dataSetName;
                }


                xmlFile = dataSetName +".xsd" ;
                

                string langString = null;

                 // if neither specified, do both.
                if (!vb && !cs) {
                    langString = "VB & C#"; 
                } else if (vb) {
                    langString = "VB"; 
                } else if (cs) {
                    langString = "C#"; 
                }


                Console.WriteLine("Generating XSD Schema and DataSet classes for: ");
                Console.WriteLine("\tDataSet Name:" + dataSetName);
                Console.WriteLine("\tXSD File:" + xmlFile);
                Console.Write("\tTables: ");
                for (int i=0 ; i < tables.Count ; i++) {
                    Console.Write(" " + tables[i].ToString());
                }
                Console.WriteLine("\n\tDatabase: " + dbConnection);
                Console.WriteLine("\tTarget Directory: " + targetDir);
                if (packageName != null) 
                    Console.WriteLine("\tPackage: " + packageName);
                Console.WriteLine("\tLanguages: " + langString);

                DataSet ds = new DataSet();
                ADOSchemaConnection con = new ADOSchemaConnection(dbConnection);
                ds.DataSetName = dataSetName;

                Console.WriteLine("\n\tLoading DataSet Schema...");

                for (int i=0 ; i < tables.Count ; i++) {

                    //Use Schema stuff instead - talk to Gio about exposing this
                    //A lot more work tho'
                    ADODataSetCommand cmd = new ADODataSetCommand("Select TOP 1 * from [" + tables[i] + "]", con);
                    cmd.FillDataSetSchema(ds, SchemaType.Source, ((string)(tables[i])));
                }

                if (tables.Count > 1) {
                    Console.WriteLine("\n\tCreating Relationships...");
                    CreateRelationships(con, ds, tables);
                }

                Console.WriteLine("\n\tCreating XSD File...");

                StreamWriter fs = new StreamWriter(targetDir + "\\" + xmlFile);
                try {
                    fs.Write(ds.XmlSchema);    
                } finally {
                    fs.Close();
                }

                Console.WriteLine("\n\tCreating Types...");

                // if neither specified, do both.
                if (!vb && !cs) {
                    GenerateVB(ds, targetDir, packageName);
                    GenerateCs(ds, targetDir, packageName);
                } else if (vb) {
                    GenerateVB(ds, targetDir, packageName);
                } else if (cs) {
                    GenerateCs(ds, targetDir, packageName);
                }

                Console.WriteLine("Done");

            }
            catch (Exception e) {
                Console.WriteLine("Failed to generate: " + e.Message);
                Console.WriteLine(e.GetType().Name);
                Console.WriteLine(e.StackTrace);
            }
        }

	private static void GenerateCs(DataSet dataSet, string targetDir, string packageName) {
        string fileName = targetDir + "\\" + packageName + ".cs";
        StreamWriter fs = new StreamWriter(fileName);
        try {
            Generator.GenerateDataSetCSharp(fs, packageName, dataSet);
        } finally {
            fs.Close();
        }
	}		

	private static void GenerateVB(DataSet dataSet, string targetDir, string packageName) {
        string fileName = targetDir + "\\" + packageName + ".vb";
        StreamWriter fs = new StreamWriter(fileName);
        try {
            Generator.GenerateDataSetVB(fs, packageName, dataSet);
        } finally {
            fs.Close();
        }
	}		


        private static void CreateRelationships(ADOSchemaConnection con, DataSet targetDS, ArrayList tables) {
            con.Open();
            try {
                //Get Schema tables for fkeys 
                DataTable schemaTable = con.ADOGetSchemaTable(  typeof(DataTable)
                                                              , DBSchemaGUIDs.FOREIGN_KEYS
                                                              , new object[] {});

                /* Gives back:
                <PK_TABLE_CATALOG>
                <PK_TABLE_SCHEMA>
                <PK_TABLE_NAME>
                <PK_COLUMN_NAME>
                <FK_TABLE_CATALOG>
                <FK_TABLE_SCHEMA>
                <FK_TABLE_NAME>
                <FK_COLUMN_NAME>
                <ORDINAL>
                <UPDATE_RULE>
                <DELETE_RULE>
                <PK_NAME>
                <FK_NAME>
                <DEFERRABILITY>
                */

                //Get all info for each fkey and then build relationships
                Hashtable fkeys = new Hashtable() ;

                for (int i=0 ; i < tables.Count ; i++) {
                    string tablename = (string)(tables[i]);

                    //Find all the fk relationships for this table
                    DataRow[] rows = schemaTable.Select("PK_TABLE_NAME='" + tablename +"'");

                    for (int j=0 ; j < rows.Length ; j++) {

                        DataRow row2 = rows[j];
                        string fkname = (string)(row2["FK_NAME"]);
                        string childTableName = (string)(row2["FK_TABLE_NAME"]);
                        ArrayList fkcols ;

                        if (targetDS.Tables.Contains(childTableName)) {
                            if (!fkeys.ContainsKey(fkname)) {
                                fkcols = new ArrayList();
                                fkeys[fkname] = fkcols;
                            } else {
                                fkcols = (ArrayList)(fkeys[fkname]);
                            }
            
                            fkcols.Add(row2);
                        }
                    }
                }

                IDictionaryEnumerator en = (IDictionaryEnumerator)(fkeys.GetEnumerator());
                while (en.MoveNext()) {
                    ArrayList fkcols = (ArrayList)(en.Value);
                    DataRow row = (DataRow)(fkcols[0]);

                    string fkname = (string)(row["FK_NAME"]);
                    DataTable pTable = targetDS.Tables[(string)(row["PK_TABLE_NAME"])];
                    DataTable cTable = targetDS.Tables[(string)(row["FK_TABLE_NAME"])];
                    
                    string relName = pTable.TableName + cTable.TableName;

                    if (targetDS.Relations.Contains(relName)) {
                        //If duplicate then simply append fk name to end
                        relName = relName + fkname;
                    }

                    Console.WriteLine("\t\tGenerating relationship for " +  pTable.TableName);
                    Console.WriteLine("\t\t\t Creating " + relName + " for: "  +  fkname);

                    DataColumn[] pCols = new DataColumn[fkcols.Count];
                    DataColumn[] cCols = new DataColumn[fkcols.Count];
                    for (int i = 0 ; i < fkcols.Count ; i++) {
                        DataRow row1 = (DataRow)(fkcols[i]);
                        pCols[i] = pTable.Columns[(string)(row1["PK_COLUMN_NAME"])];
                        cCols[i] = cTable.Columns[(string)(row1["FK_COLUMN_NAME"])];
                    }

                    targetDS.Relations.Add(relName, pCols, cCols, true);
                }

            } finally {
                con.Close();
            }
        }


    }


    sealed internal class DBSchemaGUIDs {
        static readonly public Guid TABLES_INFO             = new Guid("c8b522e0-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid TRUSTEE                 = new Guid("c8b522ef-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid ASSERTIONS              = new Guid("c8b52210-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid CATALOGS                = new Guid("c8b52211-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid CHARACTER_SETS          = new Guid("c8b52212-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid COLLATIONS              = new Guid("c8b52213-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid COLUMNS                 = new Guid("c8b52214-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid CHECK_CONSTRAINTS       = new Guid("c8b52215-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid CONSTRAINT_COLUMN_USAGE = new Guid("c8b52216-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid CONSTRAINT_TABLE_USAGE  = new Guid("c8b52217-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid KEY_COLUMN_USAGE        = new Guid("c8b52218-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid REFERENTIAL_CONSTRAINTS = new Guid("c8b52219-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid TABLE_CONSTRAINTS       = new Guid("c8b5221a-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid COLUMN_DOMAIN_USAGE     = new Guid("c8b5221b-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid INDEXES                 = new Guid("c8b5221e-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid COLUMN_PRIVILEGES       = new Guid("c8b52221-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid TABLE_PRIVILEGES        = new Guid("c8b52222-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid USAGE_PRIVILEGES        = new Guid("c8b52223-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid PROCEDURES              = new Guid("c8b52224-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid SCHEMATA                = new Guid("c8b52225-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid SQL_LANGUAGES           = new Guid("c8b52226-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid STATISTICS              = new Guid("c8b52227-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid TABLES                  = new Guid("c8b52229-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid TRANSLATIONS            = new Guid("c8b5222a-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid PROVIDER_TYPES          = new Guid("c8b5222c-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid VIEWS                   = new Guid("c8b5222d-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid VIEW_COLUMN_USAGE       = new Guid("c8b5222e-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid VIEW_TABLE_USAGE        = new Guid("c8b5222f-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid PROCEDURE_PARAMETERS    = new Guid("c8b522b8-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid FOREIGN_KEYS            = new Guid("c8b522c4-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid PRIMARY_KEYS            = new Guid("c8b522c5-5cf3-11ce-ade5-00aa0044773d");
        static readonly public Guid PROCEDURE_COLUMNS       = new Guid("c8b522c9-5cf3-11ce-ade5-00aa0044773d");
    }



}


