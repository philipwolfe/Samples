'
' ClassInfo.vb
'
' Contains the classes SortTable, DisplayFields, DisplayConstructors, DisplayProperties, DisplayMethods,
' DisplayInterfaces, DisplaySuperClasses, DisplaySubClasses
'
' Instances of these classes are created from ClassBrowser.aspx to help building the output describing the class
'
Imports System 
Imports System.Web
Imports System.Web.UI
Imports System.Collections
Imports System.Reflection       ' this is used for most of the class inspection
Imports Microsoft.VisualBasic   ' for Information.IsReference

namespace ClassInfo

'
' class SortTable
'
' This is used for several lists of strings that are stored in and returned by the classes.
' The C# version of this sample uses multiple inheritance and we can't do that in VB so
' remove the IComparable interface inheritance.
'
public class SortTable : Inherits Hashtable
    Implements IComparable
    public sortField as String 
    
    public sub New(ByVal sField as String)
        MyBase.New
        sortField = sField
    end sub

    public function CompareTo( ByVal b as Object ) as Integer Implements IComparable.CompareTo
        dim OtherSortTable as SortTable = CType( b, SortTable )

        return sortField.CompareTo( OtherSortTable.sortField )
    end function
end class

'
' class DisplayFields
'
' When created, this class builds a list of fields in the class using Type.GetFields()
'
public class DisplayFields : Inherits ArrayList

    '
    ' Constructor
    '
    public sub New( ByVal classType as Type )  
        MyBase.New
        Dim x           as Integer
        Dim fieldInfos  as System.Reflection.FieldInfo() = classType.GetFields()

        if ( not Information.IsReference( fieldInfos ) ) then
            return
        end if
               
        Dim fieldTable as ArrayList = New ArrayList()

        for x = 0 to fieldInfos.Length-1
            Dim fieldDetails as SortTable = New SortTable("Name")

            fieldDetails("Name") = fieldInfos(x).Name
            fieldDetails("Type") = fieldInfos(x).FieldType.Name
            if ((fieldInfos(x).FieldType.IsArray And fieldInfos(x).FieldType.Name <> "Array") Or  fieldInfos(x).FieldType.IsPointer) then
                fieldDetails("GetType")   = fieldInfos(x).FieldType.GetElementType().Name
                fieldDetails("Namespace") = fieldInfos(x).FieldType.GetElementType().Namespace
            else
                fieldDetails("GetType")   = fieldInfos(x).FieldType.Name
                fieldDetails("Namespace") = fieldInfos(x).FieldType.Namespace
            end if

            if (fieldInfos(x).IsPublic = true) then 
                fieldDetails("Access") = "public "
            else if (fieldInfos(x).IsPrivate = true) then 
                fieldDetails("Access") = "private "
            else if (fieldInfos(x).IsFamily = true) then 
                fieldDetails("Access") = "protected "
            end if 

            if (fieldInfos(x).IsStatic = true) then 
                fieldDetails("Access") = CStr( fieldDetails("Access")) + "static "
            end if

            if (fieldInfos(x).IsLiteral = true) then 
                fieldDetails("Access") = CStr( fieldDetails("Access")) + "const "
            end if

            Me.Add(fieldDetails)
       next
       Me.Sort()
    end sub
end class

'
' class DisplayConstructors
'
' This fetches the constructors and populates an array of it
'
public class DisplayConstructors : Inherits ArrayList

    '
    ' Constructor
    '
    public sub New( ByVal classType as Type )
        MyBase.New
        Dim constructorInfos    as System.Reflection.ConstructorInfo() = classType.GetConstructors()
        Dim x                   as Integer           
        
        if ( not Information.IsReference( constructorInfos ) ) then
            return
        end if    

        for x = 0 to constructorInfos.Length-1 
            Dim constructorDetails as Hashtable = New Hashtable()

            constructorDetails("Name") = classType.Name

            if (constructorInfos(x).IsPublic = true) then 
                constructorDetails("Access") = "public "
            else if (constructorInfos(x).IsPrivate = true) then 
                constructorDetails("Access") = "private "
            else if (constructorInfos(x).IsFamily = true) then 
                constructorDetails("Access") = "protected "
            end if

            Dim paramInfos as System.Reflection.ParameterInfo() = constructorInfos(x).GetParameters()

            if ( Information.IsReference( paramInfos ) ) then
                Dim paramTable as ArrayList = New ArrayList()
                Dim y as Integer
                for y = 0 to paramInfos.Length - 1
                    Dim paramDetails as Hashtable = New Hashtable()
                    paramDetails("ParamName") = paramInfos(y).Name
                    paramDetails("ParamType") = paramInfos(y).ParameterType.Name
                    if ( ( paramInfos(y).ParameterType.IsArray And paramInfos(y).ParameterType.Name <>"Array" ) Or paramInfos(y).ParameterType.IsPointer ) then 
                        paramDetails("GetType")   = paramInfos(y).ParameterType.GetElementType().Name 
                        paramDetails("Namespace") = paramInfos(y).ParameterType.GetElementType().Namespace 
                    else  
    	                paramDetails("GetType")   = paramInfos(y).ParameterType.Name
                        paramDetails("Namespace") = paramInfos(y).ParameterType.Namespace 
                    end if
                    paramTable.Add(paramDetails)
                next
                 
                constructorDetails("Params") = paramTable
            end if

            Me.Add(constructorDetails)
        next
    end sub
end class

'
' class DisplayProperties
'
' On construction, this populates an array with the properties in the class
'
public class DisplayProperties : Inherits ArrayList
    '
    ' Constructor
    '
    public sub New( ByVal classType as Type ) 
        MyBase.New
        Dim propertyInfos as System.Reflection.PropertyInfo() = classType.GetProperties()
        Dim x as Integer

        if ( not Information.IsReference( propertyInfos ) ) then
            return
        end if
        dim propertyTable as ArrayList = New ArrayList()        
 
        for x = 0 to propertyInfos.Length-1
            dim propertyDetails as SortTable = New SortTable("Name")
                
            if ( Information.IsReference( propertyInfos(x).GetGetMethod() ) ) then
                if (( propertyInfos(x).GetGetMethod().ReturnType.IsArray And propertyInfos(x).GetGetMethod().ReturnType.Name <>"Array" ) Or propertyInfos(x).GetGetMethod().ReturnType.IsPointer ) then
                    propertyDetails("GetType") = propertyInfos(x).GetGetMethod().ReturnType.GetElementType().Name
                    propertyDetails("Namespace")=propertyInfos(x).GetGetMethod().ReturnType.GetElementType().Namespace
                else
                    propertyDetails("GetType") = propertyInfos(x).GetGetMethod().ReturnType.Name
                    propertyDetails("Namespace") = propertyInfos(x).GetGetMethod().ReturnType.Namespace
                end if
                propertyDetails("Type") = propertyInfos(x).GetGetMethod().ReturnType.Name
                propertyDetails("Name") = propertyInfos(x).Name
               
                if (propertyInfos(x).GetGetMethod().IsPublic = true) then 
                     propertyDetails("Visibility") = "public"
                else if (propertyInfos(x).GetGetMethod().IsPrivate = true) then 
                     propertyDetails("Visibility") = "private"
                else if (propertyInfos(x).GetGetMethod().IsFamily = true) then 
                    propertyDetails("Visibility") = "protected"
                end if
               
                if (propertyInfos(x).GetGetMethod().IsStatic = true) then 
                    propertyDetails("Visibility") = CStr( propertyDetails("Visibility")) + " static"
                end if
                  
                if ( not Information.IsReference( propertyInfos(x).GetSetMethod() ) ) then
                    propertyDetails("Access") =  "(Get)" 
    	        else
	                propertyDetails("Access") = "(Get , Set)" 
	            end if
                  
                Dim paramInfos as System.Reflection.ParameterInfo() = propertyInfos(x).GetGetMethod().GetParameters()
                
                if ( Information.IsReference( paramInfos ) ) then
                    Dim paramTable as ArrayList = New ArrayList()
                    Dim y as Integer
                 
                    for y = 0 to paramInfos.Length-1
                        Dim paramDetails as Hashtable = New Hashtable()
                        paramDetails("ParamName") = paramInfos(y).Name
                        paramDetails("ParamType") = paramInfos(y).ParameterType.Name
                        if (( paramInfos(y).ParameterType.IsArray And paramInfos(y).ParameterType.Name <>"Array") Or paramInfos(y).ParameterType.IsPointer ) then 
                            paramDetails("GetType")   = paramInfos(y).ParameterType.GetElementType().Name 
                            paramDetails("Namespace") = paramInfos(y).ParameterType.GetElementType().Namespace 
                        else  
    	                    paramDetails("GetType")   = paramInfos(y).ParameterType.Name
                            paramDetails("Namespace") = paramInfos(y).ParameterType.Namespace 
                        end if
                        paramTable.Add(paramDetails)
                    next
                 
                    propertyDetails("Params") = paramTable
                end if
            else if ( Information.IsReference( propertyInfos(x).GetSetMethod() ) ) then
                propertyDetails("GetType") = propertyInfos(x).GetSetMethod().ReturnType.Name
                propertyDetails("Namespace") = propertyInfos(x).GetSetMethod().ReturnType.Namespace
              
                propertyDetails("Type") = propertyInfos(x).GetSetMethod().ReturnType.Name
                propertyDetails("Name") = propertyInfos(x).Name
            
                if (propertyInfos(x).GetSetMethod().IsPublic = true) then 
                     propertyDetails("Visibility") = "public"
                else if (propertyInfos(x).GetSetMethod().IsPrivate = true) then 
                     propertyDetails("Visibility") = "private"
                else if (propertyInfos(x).GetSetMethod().IsFamily = true) then 
                    propertyDetails("Visibility") = "protected"
                end if                
              
                if (propertyInfos(x).GetSetMethod().IsStatic = true) then 
                    propertyDetails("Visibility") = CStr( propertyDetails("Visibility")) + " static"
                end if
                        
	            propertyDetails("Access") = "( Set )" 
	              	
                Dim paramInfos as System.Reflection.ParameterInfo() = propertyInfos(x).GetSetMethod().GetParameters()
                
                if ( Information.IsReference( paramInfos ) ) then
                    Dim paramTable  as ArrayList = New ArrayList()
                    Dim y           as Integer
                 
                    for y = 0 to paramInfos.Length-1
                        Dim paramDetails as Hashtable = New Hashtable()
                        paramDetails("ParamName") = paramInfos(y).Name
                        paramDetails("ParamType") = paramInfos(y).ParameterType.Name
                        if ((paramInfos(y).ParameterType.IsArray And paramInfos(y).ParameterType.Name <>"Array") Or paramInfos(y).ParameterType.IsPointer) then
                            paramDetails("GetType")   = paramInfos(y).ParameterType.GetElementType().Name 
                            paramDetails("Namespace") = paramInfos(y).ParameterType.GetElementType().Namespace 
                        else  
    	                    paramDetails("GetType")   = paramInfos(y).ParameterType.Name
                            paramDetails("Namespace") = paramInfos(y).ParameterType.Namespace 
                        end if
                        paramTable.Add(paramDetails)
                    next y
                 
                    propertyDetails("Params") = paramTable
               end if
            end if
          
           Me.Add(propertyDetails)
           
        next
        Me.Sort()
    end sub
end class

'
' class DisplayMethods
'
' On construction this class 
'
public class DisplayMethods : Inherits ArrayList
  
    '
    ' Constructor
    '    
    public sub New( ByVal classType as Type, ByVal myclassname as String )
        MyBase.New
        Dim methodInfos as System.Reflection.MethodInfo() = classType.GetMethods(BindingFlags.Default) 
        Dim x as Integer
          
        if ( not Information.IsReference( methodInfos ) ) then
            return
        end if

        for x = 0 to methodInfos.Length-1 
            if ((String.Compare(myclassname,methodInfos(x).DeclaringType.Name )=0)And(methodInfos(x).IsPublic Or methodInfos(x).IsFamily) And (not (methodInfos(x).IsSpecialName)) ) then
                Dim MethodDetails as SortTable = New SortTable("Name")

                 MethodDetails("Name") = methodInfos(x).Name
                 MethodDetails("Type") = methodInfos(x).ReturnType.Name
                 if (( methodInfos(x).ReturnType.IsArray And methodInfos(x).ReturnType.Name <>"Array") Or  methodInfos(x).ReturnType.IsPointer) then
                 
                    '
                    ' For Supporting Multi-Dimension Arrays as Return Type 
                    '
                    Dim ReturnElementType as Type =  methodInfos(x).ReturnType.GetElementType()
                    do while(ReturnElementType.IsArray)
                       ReturnElementType =  ReturnElementType.GetElementType()
                    loop

                     MethodDetails("GetType")   = ReturnElementType.Name 
                     MethodDetails("Namespace") = ReturnElementType.Namespace 
                 else  
	                 MethodDetails("GetType") = methodInfos(x).ReturnType.Name
                     MethodDetails("Namespace") = methodInfos(x).ReturnType.Namespace 
                 end if  
                
                 if (methodInfos(x).IsPublic = true) then 
                     MethodDetails("Access") = "public "
                 else if (methodInfos(x).IsPrivate = true) then 
                     MethodDetails("Access") = "private "
                 else if (methodInfos(x).IsFamily = true) then 
                     MethodDetails("Access") = "protected "
                 end if
                 
                 if (methodInfos(x).IsStatic = true) then 
                     MethodDetails("Access") = CStr( MethodDetails("Access")) + "static "
                 end if

                 Dim paramInfos as System.Reflection.ParameterInfo() = methodInfos(x).GetParameters()
                
                if ( Information.IsReference( paramInfos ) ) then
                    Dim paramTable as ArrayList = New ArrayList()
                    Dim y as Integer
                 
                    for y = 0 to paramInfos.Length-1
                        Dim paramDetails as Hashtable = New Hashtable()
                        paramDetails("ParamName") = paramInfos(y).Name
                        paramDetails("ParamType") = paramInfos(y).ParameterType.Name
                        if (( paramInfos(y).ParameterType.IsArray And paramInfos(y).ParameterType.Name <> "Array" )  Or paramInfos(y).ParameterType.IsPointer) then
                            paramDetails("GetType")   = paramInfos(y).ParameterType.GetElementType().Name 
                            paramDetails("Namespace") = paramInfos(y).ParameterType.GetElementType().Namespace 
                        else  
                            paramDetails("GetType")   = paramInfos(y).ParameterType.Name
                            paramDetails("Namespace") = paramInfos(y).ParameterType.Namespace 
                        end if
                        paramTable.Add(paramDetails)
                    next
                    
                    MethodDetails("Params") = paramTable
                end if

                Me.Add(MethodDetails)
             end if
        next
        Me.Sort()
    end sub
end class

'
' class DisplayInterfaces
'
' On construction this class populates a list with all interfaces on the type
'
public class DisplayInterfaces : Inherits ArrayList

    '
    ' Constructor
    '
    public sub New( ByVal classType as Type )
        MyBase.New
        Dim classInterfaces as Type() = classType.GetInterfaces()
        Dim x               as Integer
        for x = 0 to classInterfaces.Length -1
            Dim interfaceDetails as Hashtable = New Hashtable()

            interfaceDetails("FullName")     = classInterfaces(x).FullName
            interfaceDetails("GetType")      = classInterfaces(x).Name
            interfaceDetails("Namespace")    = classInterfaces(x).Namespace
            Me.Add(interfaceDetails)
         next
     end sub
end class

'
' class DisplaySuperClasses
'
' On construction this class populates an array with all parent classes of the target class
'
public class DisplaySuperclasses : Inherits ArrayList
    public sub New( ByVal classType as Type )
        MyBase.New
       Dim SuperClass as Type 

       Dim classDetails as Hashtable = New Hashtable()

       classDetails("FullName")     = classType.FullName
       classDetails("GetType")      = classType.Name
       classDetails("Namespace")    = classType.Namespace

       Me.Add(classDetails)

       do while classType.BaseType <> Nothing
           Dim superclassDetails as Hashtable = New Hashtable()
           SuperClass =  classType.BaseType 
           classType   =  SuperClass        

            superclassDetails("FullName")     = SuperClass.FullName
            superclassDetails("GetType")      = SuperClass.Name
            superclassDetails("Namespace")    = SuperClass.Namespace
    
           Me.Add(superclassDetails)    
       loop
       Me.Reverse() 
    end sub
end class

'
' class DisplaySubClasses
' 
' On construction this class populates an array with all subclasses of the target class
'
public class DisplaySubClasses : Inherits ArrayList 

    private classType       as Type        
    private CorRuntime      as System.Reflection.Module()      
    private CorClasses      as Type()      
    private myclassname     as String      
    private classInterfaces as Type()      

    '
    ' Constructor
    '   
    public sub New ( ByVal classtype as Type, ByVal ModuleName as ArrayList )
        MyBase.New

        Dim x, y, i as Integer
        Me.classType = classtype 
		'
        ' remark
        '
        myclassname = classType.FullName 
        if (classType.IsInterface ) then 
            for y = 0 to ModuleName.Count - 1
                CorRuntime = System.Reflection.Assembly.Load(ModuleName(y).ToString()).GetModules()
	            CorClasses   = CorRuntime(0).GetTypes() 
                    	           
                for x = 0 to CorClasses.Length - 1
                    classType       =  CorClasses(x)
                    classInterfaces =  classType.GetInterfaces() 
	            
                    for i = 0 to classInterfaces.Length - 1
                        if ( String.Compare( myclassname, classInterfaces(i).FullName ) = 0 ) then
                             Dim subclassDetails as SortTable  = New SortTable("FullName")
                             subclassDetails("FullName")     = classType.FullName
                             subclassDetails("GetType")      = classType.Name
                             subclassDetails("Namespace")    = classType.Namespace
    	        	 	     Me.Add( subclassDetails )
	    	            end if
                    next
                next
            next
        else 
            for y = 0 to ModuleName.Count - 1  
                CorRuntime = System.Reflection.Assembly.Load(ModuleName(y).ToString()).GetModules() 
        	 	CorClasses  = CorRuntime(0).GetTypes() 
 
                for x = 0 to CorClasses.Length - 1
                    classType = CorClasses(x).BaseType 
                    if ( not Information.IsReference( classType ) ) then  
                        if ( String.Compare( classType.FullName, myclassname ) = 0 ) then
                            Dim subclassDetails as SortTable  = New SortTable( "FullName" )
                            subclassDetails("FullName")     = CorClasses(x).FullName
                            subclassDetails("GetType")      = CorClasses(x).Name
                            subclassDetails("Namespace")    = CorClasses(x).Namespace
         	                Me.Add( subclassDetails )       
                        end if
                    end if
                next
            next
        end if
        Me.Sort()
		end sub
    end class
end namespace