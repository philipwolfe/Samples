using System ;
using System.Web;
using System.Web.UI; 
using System.Collections;
using System.Reflection;

namespace ClassInfo
{

public class SortTable : Hashtable, IComparable
   {
       public String sortField;
    
       public SortTable(String sField)
       {
           sortField= sField;
       }

       public int CompareTo(Object b)
       {
            return ((String)this[sortField]).CompareTo((String)((SortTable)b)[sortField]);
       }
   }




public class DisplayFields : ArrayList
{ 
    public  DisplayFields(Type classType) 
    {
        System.Reflection.FieldInfo[] fieldInfos = classType.GetFields();

        if (fieldInfos == null)
            return;
               
        ArrayList fieldTable = new ArrayList();

        for (int x=0; x<fieldInfos.Length; x++)
        {
            SortTable fieldDetails = new SortTable("Name");

            fieldDetails["Name"] = fieldInfos[x].Name;
            fieldDetails["Type"] = fieldInfos[x].FieldType.Name;
            if(( fieldInfos[x].FieldType.IsArray && fieldInfos[x].FieldType.Name != "Array") ||  fieldInfos[x].FieldType.IsPointer)
            {
                fieldDetails["GetType"]   = fieldInfos[x].FieldType.GetElementType().Name;
                fieldDetails["Namespace"] = fieldInfos[x].FieldType.GetElementType().Namespace;
            }
            else
            {
                fieldDetails["GetType"]   = fieldInfos[x].FieldType.Name;
                fieldDetails["Namespace"] = fieldInfos[x].FieldType.Namespace;
            }
            if (fieldInfos[x].IsPublic == true) 
            {
                fieldDetails["Access"] = "public ";
            }
            else if (fieldInfos[x].IsPrivate == true) 
            {
                fieldDetails["Access"] = "private ";
            }     
            else if (fieldInfos[x].IsFamily == true) 
            {
                fieldDetails["Access"] = "protected ";
            }                  

            if (fieldInfos[x].IsStatic == true) 
            {
                fieldDetails["Access"] = ((String) fieldDetails["Access"]) + "static ";
            }

            if (fieldInfos[x].IsLiteral == true) 
            {
                fieldDetails["Access"] = ((String) fieldDetails["Access"]) + "const ";
            }

            this.Add(fieldDetails);
       }
         this.Sort();
    }
}

public class DisplayConstructors : ArrayList
{
    public DisplayConstructors(Type classType)
    {
        System.Reflection.ConstructorInfo[] constructorInfos = classType.GetConstructors();
        
        if (constructorInfos == null)
            return;
               
        for (int x=0; x<constructorInfos.Length; x++) 
        {
            Hashtable constructorDetails = new Hashtable();

            constructorDetails["Name"] = classType.Name;

            if (constructorInfos[x].IsPublic == true) 
            {
                constructorDetails["Access"] = "public ";
            }
            else if (constructorInfos[x].IsPrivate == true) 
            {
                constructorDetails["Access"] = "private ";
            }     
            else if (constructorInfos[x].IsFamily == true) 
            {
                constructorDetails["Access"] = "protected ";
            }    

            System.Reflection.ParameterInfo[] paramInfos = constructorInfos[x].GetParameters();

            if (paramInfos != null)
            {
                ArrayList paramTable = new ArrayList();
                for (int y=0; y<paramInfos.Length; y++)
                {     
                    Hashtable paramDetails = new Hashtable();
                    paramDetails["ParamName"] = paramInfos[y].Name;
                    paramDetails["ParamType"] = paramInfos[y].ParameterType.Name;    
                    if ( ( paramInfos[y].ParameterType.IsArray && paramInfos[y].ParameterType.Name !="Array" ) || paramInfos[y].ParameterType.IsPointer )  
                    {
                        paramDetails["GetType"]   = paramInfos[y].ParameterType.GetElementType().Name ;
                        paramDetails["Namespace"] = paramInfos[y].ParameterType.GetElementType().Namespace ;
                    }
  
                    else  
                    {
	                paramDetails["GetType"]   = paramInfos[y].ParameterType.Name;
                        paramDetails["Namespace"] = paramInfos[y].ParameterType.Namespace ;
                    }
                    paramTable.Add(paramDetails); 
                }
                 
                constructorDetails["Params"] = paramTable;
            }    

            this.Add(constructorDetails);
        }  
    }
}


public class DisplayProperties : ArrayList
{
    public  DisplayProperties(Type classType) 
    {
        System.Reflection.PropertyInfo[] propertyInfos = classType.GetProperties();

        if (propertyInfos == null)
            return;
               
        ArrayList propertyTable = new ArrayList();
         
        for (int x=0; x<propertyInfos.Length; x++)
        {
                         
            SortTable propertyDetails = new SortTable("Name");
                
            if(propertyInfos[x].GetGetMethod() != null)
            {
                if(( propertyInfos[x].GetGetMethod().ReturnType.IsArray && propertyInfos[x].GetGetMethod().ReturnType.Name !="Array" ) || propertyInfos[x].GetGetMethod().ReturnType.IsPointer )
                {   
                    propertyDetails["GetType"] = propertyInfos[x].GetGetMethod().ReturnType.GetElementType().Name;
                    propertyDetails["Namespace"]=propertyInfos[x].GetGetMethod().ReturnType.GetElementType().Namespace;
             
                }
                else
                {
                    propertyDetails["GetType"] = propertyInfos[x].GetGetMethod().ReturnType.Name; 
                    propertyDetails["Namespace"] = propertyInfos[x].GetGetMethod().ReturnType.Namespace;
                }
                propertyDetails["Type"] = propertyInfos[x].GetGetMethod().ReturnType.Name; 
                propertyDetails["Name"] = propertyInfos[x].Name;
               
                if (propertyInfos[x].GetGetMethod().IsPublic == true) 
                {
                     propertyDetails["Visibility"] = "public";
                }
                else if (propertyInfos[x].GetGetMethod().IsPrivate == true) 
                {
                     propertyDetails["Visibility"] = "private";
                }     
                else if (propertyInfos[x].GetGetMethod().IsFamily == true) 
                {
                    propertyDetails["Visibility"] = "protected";
                }                  
               
                if (propertyInfos[x].GetGetMethod().IsStatic == true) 
                {
                    propertyDetails["Visibility"] = ((String) propertyDetails["Visibility"]) + " static";
                }
                  
                if (propertyInfos[x].GetSetMethod() == null)
                { 
                    propertyDetails["Access"] =  "[Get]" ; 
                }
	        else
                {
	            propertyDetails["Access"] = "[Get , Set]" ;
	        }	
                  
                System.Reflection.ParameterInfo[] paramInfos = propertyInfos[x].GetGetMethod().GetParameters();
                
                if (paramInfos != null)
                {
                    ArrayList paramTable = new ArrayList();
                 
                    for (int y=0; y<paramInfos.Length; y++)
                    {     
                        Hashtable paramDetails = new Hashtable();
                        paramDetails["ParamName"] = paramInfos[y].Name;
                        paramDetails["ParamType"] = paramInfos[y].ParameterType.Name;    
                        if (( paramInfos[y].ParameterType.IsArray && paramInfos[y].ParameterType.Name !="Array") ||paramInfos[y].ParameterType.IsPointer )  
                        {
                            paramDetails["GetType"]   = paramInfos[y].ParameterType.GetElementType().Name ;
                            paramDetails["Namespace"] = paramInfos[y].ParameterType.GetElementType().Namespace ;
                        }
                        else  
                        {
	                    paramDetails["GetType"]   = paramInfos[y].ParameterType.Name;
                            paramDetails["Namespace"] = paramInfos[y].ParameterType.Namespace ;
                        }
                        paramTable.Add(paramDetails); 
                    }
                 
                    propertyDetails["Params"] = paramTable;
               }
            }
            else if(propertyInfos[x].GetSetMethod() != null)
            {
                
                propertyDetails["GetType"] = propertyInfos[x].GetSetMethod().ReturnType.Name; 
                propertyDetails["Namespace"] = propertyInfos[x].GetSetMethod().ReturnType.Namespace;
              
                propertyDetails["Type"] = propertyInfos[x].GetSetMethod().ReturnType.Name; 
                propertyDetails["Name"] = propertyInfos[x].Name;
            
                if (propertyInfos[x].GetSetMethod().IsPublic == true) 
                {
                     propertyDetails["Visibility"] = "public";
                }
                else if (propertyInfos[x].GetSetMethod().IsPrivate == true) 
                {
                     propertyDetails["Visibility"] = "private";
                }     
                else if (propertyInfos[x].GetSetMethod().IsFamily == true) 
                {
                    propertyDetails["Visibility"] = "protected";
                }                  
              
                if (propertyInfos[x].GetSetMethod().IsStatic == true) 
                {
                    propertyDetails["Visibility"] = ((String) propertyDetails["Visibility"]) + " static";
                }
                        
	        propertyDetails["Access"] = "[ Set ]" ;
	              	
                System.Reflection.ParameterInfo[] paramInfos = propertyInfos[x].GetSetMethod().GetParameters();
                
                if (paramInfos != null)
                {
                    ArrayList paramTable = new ArrayList();
                 
                    for (int y=0; y<paramInfos.Length; y++)
                    {     
                        Hashtable paramDetails = new Hashtable();
                        paramDetails["ParamName"] = paramInfos[y].Name;
                        paramDetails["ParamType"] = paramInfos[y].ParameterType.Name;    
                        if(( paramInfos[y].ParameterType.IsArray && paramInfos[y].ParameterType.Name !="Array") || paramInfos[y].ParameterType.IsPointer) 
                        {
                            paramDetails["GetType"]   = paramInfos[y].ParameterType.GetElementType().Name ;
                            paramDetails["Namespace"] = paramInfos[y].ParameterType.GetElementType().Namespace ;
                        }
                        else  
                        {
	                    paramDetails["GetType"]   = paramInfos[y].ParameterType.Name;
                            paramDetails["Namespace"] = paramInfos[y].ParameterType.Namespace ;
                        }
                        paramTable.Add(paramDetails); 
                    }
                 
                    propertyDetails["Params"] = paramTable;
               }
            }
          
           this.Add(propertyDetails);
           
        }
        this.Sort();
    }
}        


public class DisplayMethods : ArrayList
{    
     public DisplayMethods(Type classType, String myclassname)
     { 
         System.Reflection.MethodInfo[] methodInfos = classType.GetMethods(BindingFlags.Default) ;
          
         if (methodInfos == null)
             return;
               
         for (int x=0; x<methodInfos.Length; x++) 
         {
             if((String.Compare(myclassname,methodInfos[x].DeclaringType.Name )==0)&&(methodInfos[x].IsPublic || methodInfos[x].IsFamily) && (!(methodInfos[x].IsSpecialName)) ) 
             { 
                 SortTable MethodDetails = new SortTable("Name");

                 MethodDetails["Name"] = methodInfos[x].Name;
                 MethodDetails["Type"] = methodInfos[x].ReturnType.Name;
                 if(( methodInfos[x].ReturnType.IsArray && methodInfos[x].ReturnType.Name !="Array") ||  methodInfos[x].ReturnType.IsPointer)  
                 {
                     // For Supporting Multi-Dimension Arrays as Return Type 
                     Type ReturnElementType =  methodInfos[x].ReturnType.GetElementType();
                     while(ReturnElementType.IsArray)
                     {
                        ReturnElementType =  ReturnElementType.GetElementType();    
                     }

                     MethodDetails["GetType"]   = ReturnElementType.Name ;
                     MethodDetails["Namespace"] = ReturnElementType.Namespace ;
                      
                 }
                 else  
                 {
                 
	              MethodDetails["GetType"] = methodInfos[x].ReturnType.Name;
                      MethodDetails["Namespace"] = methodInfos[x].ReturnType.Namespace ;
                 }             
                
                 if (methodInfos[x].IsPublic == true) 
                 {
                     MethodDetails["Access"] = "public ";
                 }
                 else if (methodInfos[x].IsPrivate == true) 
                 {
                     MethodDetails["Access"] = "private ";
                 }     
                 else if (methodInfos[x].IsFamily == true) 
                 {
                     MethodDetails["Access"] = "protected ";
                 }    
                 
                 if (methodInfos[x].IsStatic == true) 
                 {
                     MethodDetails["Access"] = ((String) MethodDetails["Access"]) + "static ";
                 }

                 System.Reflection.ParameterInfo[] paramInfos = methodInfos[x].GetParameters();

                 if (paramInfos != null)
                 {
                  
                     ArrayList paramTable = new ArrayList();
                 
                     for (int y=0; y<paramInfos.Length; y++)
                     {     
                         Hashtable paramDetails = new Hashtable();
                         paramDetails["ParamName"] = paramInfos[y].Name;
                         paramDetails["ParamType"] = paramInfos[y].ParameterType.Name;
                         if(( paramInfos[y].ParameterType.IsArray && paramInfos[y].ParameterType.Name != "Array" )  || paramInfos[y].ParameterType.IsPointer)
                         {
                             paramDetails["GetType"]   = paramInfos[y].ParameterType.GetElementType().Name ;
                             paramDetails["Namespace"] = paramInfos[y].ParameterType.GetElementType().Namespace ;
                         }
                         else  
                         {
	                     paramDetails["GetType"]   = paramInfos[y].ParameterType.Name;
                             paramDetails["Namespace"] = paramInfos[y].ParameterType.Namespace ;
                         }
                         paramTable.Add(paramDetails);
                     }
                     
                     MethodDetails["Params"] = paramTable;
                 }

                this.Add(MethodDetails);
             }
        }
         this.Sort();
    }
} 

public class DisplayInterfaces : ArrayList
{
    public DisplayInterfaces(Type classType)
    {
         Type[] classInterfaces = classType.GetInterfaces();
         for(int x = 0 ; x < classInterfaces.Length ; x++)
         {
            
            Hashtable interfaceDetails = new Hashtable();

            interfaceDetails["FullName"]     = classInterfaces[x].FullName;
            interfaceDetails["GetType"]      = classInterfaces[x].Name;
            interfaceDetails["Namespace"]    = classInterfaces[x].Namespace;
            this.Add(interfaceDetails);
         }
         
     }
}


public class DisplaySuperclasses : ArrayList
{
    public DisplaySuperclasses(Type classType)
    {
       Type SuperClass ;

       Hashtable classDetails = new Hashtable();

       classDetails["FullName"]     = classType.FullName;
       classDetails["GetType"]      = classType.Name;
       classDetails["Namespace"]    = classType.Namespace;

       this.Add(classDetails);

       while (classType.BaseType != null)
       {
           Hashtable superclassDetails = new Hashtable();
           SuperClass =  classType.BaseType ;
           classType   =  SuperClass        ;

           superclassDetails["FullName"]     = SuperClass.FullName;
           superclassDetails["GetType"]      = SuperClass.Name;
           superclassDetails["Namespace"]    = SuperClass.Namespace;

           this.Add(superclassDetails)    ;
       }
       this.Reverse() ;
    }
   
}
 
public class DisplaySubClasses : ArrayList 
{
     private Type        classType ;
     private Module[]      CorRuntime ;
     private Type[]      CorClasses;
     private String      myclassname ;
     private Type[]      classInterfaces; 

   
    public DisplaySubClasses(Type classtype,ArrayList ModuleName)
    {
        this.classType =classtype ;
        myclassname = classType.FullName ;
        if (classType.IsInterface ) 
        {
            for(int y = 0 ; y <  ModuleName.Count ;y++)
            {
                CorRuntime = Assembly.Load(ModuleName[y].ToString()).GetModules(); 
	        CorClasses   = CorRuntime[0].GetTypes() ;
                    	           
                for(int x= 0 ; x < CorClasses.Length; x++)
                {
                    classType       =  CorClasses[x];
                    classInterfaces =  classType.GetInterfaces() ;
	            
                    for(int  i = 0 ; i < classInterfaces.Length ; i++)
		    {
                        if(String.Compare(myclassname , classInterfaces[i].FullName )==0)
                        {

                             SortTable subclassDetails     = new SortTable("FullName");
                             subclassDetails["FullName"]     = classType.FullName;
                             subclassDetails["GetType"]      = classType.Name;
                             subclassDetails["Namespace"]    = classType.Namespace;
		 	     this.Add(subclassDetails) ; 	 
		        }
                    }
                }
            }
        }                  
         
        else 
        {
            for(int y = 0; y < ModuleName.Count ; y++)  
            {
                CorRuntime = Assembly.Load(ModuleName[y].ToString()).GetModules() ;
    	 	CorClasses  = CorRuntime[0].GetTypes() ;
 
                for( int x= 0 ; x< CorClasses.Length ;x++)
                {
                    classType = CorClasses[x].BaseType ;

                    if ( null != classType  )  
                    {
                        if( String.Compare(classType.FullName, myclassname)==0)
                        {
                            SortTable subclassDetails     = new SortTable("FullName");
                            subclassDetails["FullName"]     = CorClasses[x].FullName;
                            subclassDetails["GetType"]      = CorClasses[x].Name;
                            subclassDetails["Namespace"]    = CorClasses[x].Namespace;
		 	    this.Add(subclassDetails) ;      
                        }      
                    }
                }
            }
        }
        this.Sort();
    }
}
 

}

 
 