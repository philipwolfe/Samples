using System;
using System.IO;
using System.Collections;


namespace BaseDALComponents
{
	
	public class DataExecuter
	{   
		protected string table; 
		protected System.Data.OleDb.OleDbConnection con1;
		protected System.Data.OleDb.OleDbCommand comm;
        protected System.Data.OleDb.OleDbDataReader myreader;
		protected ArrayList dataset=new ArrayList(); 
		
		public DataExecuter(string constring)
		{
		    this.con1 = new System.Data.OleDb.OleDbConnection();
			this.comm = new System.Data.OleDb.OleDbCommand();

			this.con1.ConnectionString =constring; 
	        this.comm.Connection = this.con1;
            
		}

		public string Table
		{
			set
			{
			this.table=value;
			}
			
		}

        public void Open () { this.con1.Open (); }
        public void Close () { this.con1.Close (); }
		
		public ArrayList ExecuteSelect(string [] fields)
		{
			this.dataset = new ArrayList ();
		    string build;
			string query="SELECT";
            try 
			{    
                //this.con1.Open();
				for(int i=0;i<fields.Length;i++)
					query=query + " " + fields[i] + ",";
				
				query=query.TrimEnd(','); 
				build = query + " " + "FROM" + " [" + table+"]";
					
//				StreamWriter sw = new StreamWriter ("c:\\External_Check.txt",false);
//				sw.WriteLine (build );
//				sw.Close ();
			
				this.comm.CommandText=build;
				this.myreader=comm.ExecuteReader();
				Object [] o= null;

			 
				while(myreader.Read())
			
				{
						o =  new Object [myreader.FieldCount];
					    myreader.GetValues(o).ToString();
						dataset.Add(o);
					
				}	
		//		this.con1.Close();
				return dataset;						 
				
			}
			catch(Exception ee) 
			{
				StreamWriter sw = new StreamWriter("C:\\Error.txt");
				sw.WriteLine(ee.Message);
				sw.Close();
				return null;
			}	
			
		}

		public ArrayList ExecuteDistinctSelect(string [] fields)
		{
			this.dataset = new ArrayList ();
			string build;
			string query="SELECT DISTINCT";
			try 
			{
		//			this.con1.Open();
				for(int i=0;i<fields.Length;i++)
					query=query + " " + fields[i] + ",";
				
				query=query.TrimEnd(','); 
				build = query + " " + "FROM" + " [" + table+"]";
					 
			
				this.comm.CommandText=build;
				this.myreader=comm.ExecuteReader();
				Object [] o= null;

			 
				while(myreader.Read())
			
				{
					o =  new Object [myreader.FieldCount];
					myreader.GetValues(o).ToString();
					dataset.Add(o);
					
				}	
			//	this.con1.Close();
				return dataset;						 
				
			}
			catch(Exception ee) 
			{
				StreamWriter sw = new StreamWriter("C:\\Error.txt");
				sw.WriteLine(ee.Message);
				sw.Close();
				return null;
			}	
			
		}
	      
		
		public ArrayList ExecuteSelect(string [] fields,string condition)
		{
			this.dataset = new ArrayList ();
			string build;
			string query="SELECT";
       //     this.con1.Open();
			try
			{
				for(int i=0;i<fields.Length;i++)
			
					query=query + " " + fields[i] + ",";
				
				query=query.TrimEnd(','); 
				build = query + " " + "FROM" + " [" + table+ "] " + "WHERE"+ " "+condition;
				
//				StreamWriter sw = new StreamWriter ("c:\\Data.txt");
//				sw.WriteLine (build);
//				sw.Close ();
			
				this.comm.CommandText=build;
	
				
				this.myreader=comm.ExecuteReader();
				
				Object [] o = null;
				while(myreader.Read())
				{
					o =  new Object [myreader.FieldCount];
					myreader.GetValues(o).ToString();
					dataset.Add(o);
			        
				}
				return dataset;
			    
			}
			catch(Exception ee) 
			{
				StreamWriter sw = new StreamWriter("C:\\Error.txt");
				sw.WriteLine(ee.Message);
				sw.Close(); 
				return null;
			}	
			
			
   finally{ //this.con1.Close();  
			
			}	
		}

		public ArrayList ExecuteDistinctSelect(string [] fields,string condition)
		{
			this.dataset = new ArrayList ();
			string build;
			string query="SELECT DISTINCT";
		//	this.con1.Open();
			try
			{
				for(int i=0;i<fields.Length;i++)
			
					query=query + " " + fields[i] + ",";
				
				query=query.TrimEnd(','); 
				build = query + " " + "FROM" + " [" + table+ "] " + "WHERE"+ " "+condition;
				
			
				this.comm.CommandText=build;
	
				
				this.myreader=comm.ExecuteReader();
				
				Object [] o = null;
				while(myreader.Read())
				{
					o =  new Object [myreader.FieldCount];
					myreader.GetValues(o).ToString();
					dataset.Add(o);
			        
				}
				return dataset;
			    
			}
			catch(Exception ee) 
			{
				StreamWriter sw = new StreamWriter("C:\\Error.txt");
				sw.WriteLine(ee.Message);
				sw.Close(); 
				return null;
			}	
			
			
			finally
			{
		//		this.con1.Close();  
			
			}	
		}
	
		
		public string ExecuteDelete(string condition)
		{
		    int check;
			string build;
			string query="DELETE ";  
			try
			{  
		//		this.con1.Open();
				build =query +" "+ "FROM" +" [" + table + "] " + "WHERE" + " " +condition; 
				
//				StreamWriter sw = new StreamWriter ("c:\\Error1.txt");
//				sw.WriteLine (build);
//				sw.Close ();


				this.comm.CommandText=build;
				check=this.comm.ExecuteNonQuery();
			    return "Performed"; 
				
			}
			catch(Exception ee) 
			{
				StreamWriter sw = new StreamWriter("C:\\Error.txt");
				sw.WriteLine(ee.Message);
				sw.Close(); 
				return null;
				
			}	
			finally 
			{ 
	//	this.con1.Close();
			
	}
		}



        public string ExecuteDelete ()
        {

            string build;
            string query = "DELETE";
            try
            {
                //			this.con1.Open();
                build = query + " " + "FROM" + " [" + table + "]";
                Console.WriteLine ( build );
                this.comm.CommandText = build;
                this.comm.ExecuteNonQuery ();
                return "Performed";

            }
            catch ( Exception ee )
            {
                StreamWriter sw = new StreamWriter ( "C:\\Error.txt" );
                sw.WriteLine ( ee.Message );
                sw.Close ();
                return null;
            }
            finally
            {// this.con1.Close();}
            }
        }
		
		
		
		
		
		
		
		
		public string ExecuteUpdate(string[] colums ,string condition)
		{
		      int a;
			  string build = "" ;
		      string query="UPDATE"+" ["+table+"] "+"SET";
			
			
			try 
			{   
		//		this.con1.Open();
				for(int i=0;i<colums.Length;i++)
			
					query=query + " " + colums[i] + ",";
				
				query=query.TrimEnd(','); 
			

				build = query +" "+"WHERE"+ " ("+condition+")";
		   	
				
				this.comm.CommandText=build;
				a=this.comm.ExecuteNonQuery();
				return "Performed";
				

				
			}
			catch (Exception eee)
			{
				StreamWriter sr = new StreamWriter("c:\\result.txt",false);;
				sr.Write (build+"      "+eee.Message);
				sr.Close();
				return null;
			}
			finally 
			{
            //    this.con1.Close(); 
            }
		}
	
	
	
	
	
		public string ExecuteInsert(string []check)
		{   
			string columns=null;
			string values=null;
			string []temp;
			Hashtable collect=new Hashtable(); 
			string query;
     		try
			{  
				temp=null; 
		//		this.con1.Open();
				
				for(int i=0;i<check.Length;i++)
				{
				
					temp=System.Text.RegularExpressions.Regex.Split(check[i],"=");
			        collect.Add(temp[0],temp[1]);
				    
				}
			       				
				IDictionaryEnumerator cool=collect.GetEnumerator();
                  
				while ( cool.MoveNext() )
				{
					columns=columns+","+cool.Key;		
					values=values+","+cool.Value;
				}
                columns=columns.Trim(',');
				values=values.Trim(',');
							
								
				query="INSERT INTO ["+table+"] ("+columns+") VALUES ("+values+")";

                //StreamWriter sw = new StreamWriter ( "C:\\Test.txt" );
                //sw.WriteLine ( query );
                //sw.Close ();
 
                this.comm.CommandText = query; 				
			    this.comm.ExecuteNonQuery();
			 				
				return "";
			}
			catch(Exception ee) 
			{
				StreamWriter sw = new StreamWriter("C:\\Error.txt");
				sw.WriteLine(ee.Message);
				sw.Close();
				return null;

			
			}
			finally
			{ 
		//		this.con1.Close();
				
			}
			
		}
	
	
	
	
		
		
		
		
		
		
//		public void multipleinserts(object o)
//		{
//			try 
//			{
//				string temp="";
//				string temp1="";
//				String temp2="";
//				this.con1.Open();
//				
//				ArrayList al=(ArrayList) o;
//               
//				//Console.WriteLine(al.Count);
//				
//				Question q=null;
//				
//				//Console.WriteLine("doing ");
//				for(int i=0;i<al.Count;i++)
//				{ 
//					q=(Question)al[i];
//					
//					string question=q.Questions;
//					string reason=q.Reason;
//					string[] opt=q.Options;
//					string[] answers=q.Answer;
//					
//					//Console.WriteLine(question);
//			        this.comm.CommandText="INSERT INTO [Questions] (Question,Reason) VALUES ("+question+","+reason+")";
//					this.comm.ExecuteNonQuery(); 			
//				    
//					//Console.WriteLine("doing ");
//					
//					for(int j=0;j<answers.Length;j++)
//					{
//						temp2=answers[i];
//						this.comm.CommandText="INSERT INTO [QuestionAnswers] (Question,Answer) VALUES ("+question+","+temp+")";
//						this.comm.ExecuteNonQuery(); 			
//					}
//					
//					for(int ii=0;ii<opt.Length;ii++)
//					{
//						temp1=opt[ii];
//                        this.comm.CommandText="INSERT INTO [QuestionOption] (Question,Options) VALUES ("+question+","+temp1+")";
//						this.comm.ExecuteNonQuery();
//					}
//						Console.WriteLine("doing ");
//				   
//				}
//			//Console.WriteLine("done");
//			}
//			catch{}
//			finally
//			{
//				con1.Close();
//			}
//		}
//       

//		public ArrayList multipleSelect()
//		{
//			
//			try 
//			{   
//				this.con1.Open();
//				this.comm.CommandText="SELECT * FROM [Questions]";
//				System.Data.OleDb.OleDbDataReader myreader=comm.ExecuteReader();
//				while(myreader.Read())
//			
//				{
//					Question check=new Question();
//					check.Questions = myreader.GetString(0);
//					check.Reason = myreader.GetString(1);   
//					dataset.Add(check);
//					
//				}	
//				
//				myreader.Close();
//				for(int i=0;i<dataset.Count;i++)
//				{
//					Question q = (Question)this.dataset[i]; 
//					this.comm.CommandText = "SELECT Option From [Options] Where Question='"+q.Questions+"'" ; 
//					myreader = comm.ExecuteReader();
//					ArrayList al = new ArrayList();
//					while(myreader.Read())
//						al.Add(myreader.GetString(0));
//					myreader.Close();
// 
//					//q.Options = (String [])al.ToArray(System.Type.GetType("String"));
//					q.Options = new string[al.Count];
//					for(int j=0;j<al.Count;j++)
//						q.Options[j] = al[j].ToString();  
//   
//					this.comm.CommandText = "SELECT Answer From [Answers] Where Question='"+q.Questions+"'";
//					myreader = comm.ExecuteReader(); 
//					al = new ArrayList();
//					while(myreader.Read())
//						al.Add(myreader.GetString(0));
//					
//					q.Answer = new string[al.Count];
//					for(int j=0;j<al.Count;j++)
//						q.Answer[j] = al[j].ToString(); 
// 
//					myreader.Close(); 
//				}
//				
//				this.con1.Close();
//				return dataset;						 
//				
//			}
//			catch {  return null;}
//			
//		}
//
//
//
//
//
//




	}
}
