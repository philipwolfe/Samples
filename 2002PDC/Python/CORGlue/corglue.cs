using System;
using System.Reflection;
using System.Reflection.Emit;

namespace P2IL2
{

public class CORGlue
{
	public Type m_OpCodesType;
	public CORGlue()
	{
		m_OpCodesType = Type.GetType("System.Reflection.Emit.OpCodes");
	}

	public Object GetOpCode(String name)
	{
		FieldInfo fi = m_OpCodesType.GetField(name, BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.GetField | BindingFlags.Default);
		if (fi==null)
			throw new Exception(String.Format("The opcode '{0}' can not be located", name));
		return fi.GetValue(null);
	}
	public Object CreateStaticDelegate(Type type, Type target, String name)
	{
		return Delegate.CreateDelegate(type, target, name);
	}
	public Object CreateInstanceDelegate(Type type, Object target, String name)
	{
		return Delegate.CreateDelegate(type, target, name);
	}

	// Something in this implementation doesnt work from Python (probably does now though!)
	public Type CreateDelegateType(ModuleBuilder module, String name)
	{
		Type delegateType = Type.GetType("System.Delegate");
		TypeAttributes attr = (TypeAttributes)(TypeAttributes.Public|TypeAttributes.Sealed);
		TypeBuilder tb = module.DefineType(name, attr, delegateType);
	
		// Define the delegate ctor
		Type[] args = new Type [2];
		args[0] = Type.GetType("System.Object");
		args[1] = Type.GetType("System.Int32*");
		
		MethodAttributes mattr = MethodAttributes.RTSpecialName | MethodAttributes.SpecialName | MethodAttributes.Public;
		MethodBuilder b = tb.DefineMethod(".ctor", mattr, null, args);
		b.SetImplementationFlags(MethodImplAttributes.Runtime);
		
		// Now the "Invoke" function.
		mattr = MethodAttributes.Virtual | MethodAttributes.Public;
		b = tb.DefineMethod("Invoke", mattr, null, null);	
		b.SetImplementationFlags(MethodImplAttributes.Runtime);
	
		return tb.CreateType();
	}

	// *****************************
	// AppDomain delegation, static method, ctor support etc
	// *****************************
	public AssemblyBuilder AppDomain_DefineDynamicAssembly(AppDomain a, AssemblyName n, int access)
	{
		// Broke in 1626
		return a.DefineDynamicAssembly(n, (AssemblyBuilderAccess)access);
	}
	// *****************************
	// Assembly delegation, static method, ctor support etc
	// *****************************
	public AssemblyName CreateAssemblyName()
	{
		return new AssemblyName();
	}
	public Assembly Assembly_Load( String name )
	{
		return Assembly.Load(name);
	}
	public Assembly Assembly_LoadName( AssemblyName name )
	{
		return Assembly.Load(name);
	}

	// *************************
	// ConstructorBuilder delegation, static method, ctor support etc
	// *************************

	// *************************
	// MethodBuilder delegation, static method, ctor support etc
	// *************************

	// *************************
	// MethodInfo delegation, static method, ctor support etc
	// *************************
	public String  MethodInfo_GetName(MethodInfo i)
	{
		return i.Name;
	}
	public Type MethodInfo_GetReturnType(MethodInfo i)
	{
		return i.ReturnType;
	}

	public bool MethodBase_IsStatic(MethodBase b)
	{
		return b.IsStatic;
	}
	public bool MethodBase_IsVirtual(MethodBase b)
	{
		return b.IsVirtual;
	}
	public int MethodBase_Attributes(MethodBase b)
	{
		return (int)b.Attributes;
	}
	public ParameterInfo []MethodBase_GetParameters(MethodBase i)
	{
		return i.GetParameters();
	}

	// *************************
	// Module static methods
	// See the ModuleHelper below for delegation
	// *************************

	// *************************
	// PropertyInfo delegation, static method, ctor support etc
	// *************************
	public MethodInfo PropertyInfo_GetSetMethod(PropertyInfo pi)
	{
		return pi.GetSetMethod();
	}
	public MethodInfo PropertyInfo_GetGetMethod(PropertyInfo pi)
	{
		return pi.GetGetMethod();
	}

	// *************************
	// Thread delegation, static method, ctor support etc
	// *************************
	public AppDomain Thread_GetDomain()
	{
		return System.Threading.Thread.GetDomain();
	}

	// *****************************
	// Type delegation, static method, ctor support etc
	// *****************************
	public Type GetType(String typeName)
	{
		return Type.GetType(typeName);
	}
	// WTF - Python wont let "GetType" through??????
	public Type GetTypeX(String typeName)
	{
		return Type.GetType(typeName);
	}
	public String Type_GetName( Type t )
	{
		return t.Name;
	}
	public String Type_GetFullName( Type t )
	{
		return t.FullName;
	}
	public Module Type_GetModule( Type t )
	{
		return t.Module;
	}
	public bool Type_Equals( Type t, Type o )
	{
		return t.Equals(o);
	}
	public bool Type_IsValueType(Type t)
	{
		return t.IsValueType;
	}
	public MethodInfo Type_GetMethod( Type t, String name)
	{
		return t.GetMethod(name);
	}
	public MethodInfo []Type_GetMethods( Type t)
	{
		return t.GetMethods();
	}
	public MethodInfo Type_GetMethodArgs( Type t, String name, Type [] args)
	{
		return t.GetMethod(name, args);
	}
	public PropertyInfo Type_GetProperty( Type t, String name)
	{
		return t.GetProperty(name);
	}
	public FieldInfo Type_GetField( Type t, String name)
	{
		return t.GetField(name);
	}
	
	public ConstructorInfo []Type_GetConstructors( Type t)
	{
		return t.GetConstructors();
	}
	public Object Type_GetConstructor(Type typ, Type[] args)
	{
		ConstructorInfo info = typ.GetConstructor(args);
		return (Object)info;
	}
	public bool Type_IsClass(Type t)
	{
		return t.IsClass;
	}
	public bool Type_IsInterface(Type t)
	{
		return t.IsInterface;
	}
	public bool Type_IsArray(Type t)
	{
		return t.IsArray;
	}
	// *****************************
	// TypeBuilder delegation, static method, ctor support etc
	// *****************************
	public ConstructorBuilder TypeBuilder_DefineConstructor(TypeBuilder tb, MethodAttributes attr, CallingConventions cc, Type []pt)
	{
		return tb.DefineConstructor(attr, cc, pt);
	}
	// *****************************
	// StrongKeyNamePair delegation, static method, ctor support etc
	// *****************************
	public StrongNameKeyPair LoadStrongNameKeyPair(String filename)
	{
		System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open);
		return new StrongNameKeyPair(fs);
	}
};

public class ILGenWrapper
{
	System.Reflection.Emit.ILGenerator gen;
	public void SetILGenerator(System.Reflection.Emit.ILGenerator g)
	{
		gen = g;
	}
	public Object BeginExceptionBlock2()
	{
		return (Object )gen.BeginExceptionBlock();
	}
	public Object CreateLabel2()
	{
		return (Object )gen.DefineLabel();
	}
	public void MarkLabel2(Object label)
	{
		gen.MarkLabel( (Label)label);
	}
	public void Emit(Object instruction)
	{
		OpCode i = (OpCode)instruction;
		gen.Emit(i);
	}
	public void EmitLocal(Object instruction, LocalBuilder local)
	{
		System.Reflection.Emit.OpCode i = (OpCode)instruction;
		gen.Emit(i, local);
	}
	public void EmitString(Object instruction, String str)
	{
		gen.Emit((OpCode)instruction, str);
	}
	
	public void EmitInt(Object  instruction, int val)
	{
		gen.Emit((OpCode)instruction, val);
	}
	public void EmitDouble(Object  instruction, double val)
	{
		gen.Emit((OpCode)instruction, val);
	}
	public void EmitField(Object  instruction, FieldInfo field)
	{
		gen.Emit((OpCode)instruction, field);
	}
	public void EmitType(Object  instruction, Type info)
	{
		gen.Emit((OpCode)instruction, info);
	}
	public void EmitMethod(Object  instruction, MethodInfo meth)
	{
		gen.Emit((OpCode)instruction, meth);
	}
	public void EmitConstructor(Object  instruction, ConstructorInfo ci)
	{
		gen.Emit((OpCode)instruction, ci);
	}
	public void EmitLabel(Object  instruction, Object label)
	{
		gen.Emit((OpCode)instruction, (Label)label);
	}
	public void EmitWriteLineString(String val)
	{
		gen.EmitWriteLine(val);
	}
	public void EmitWriteLineField(FieldInfo fld)
	{
		gen.EmitWriteLine(fld);
	}
	public void EmitWriteLineLocal(LocalBuilder lcl)
	{
		gen.EmitWriteLine(lcl);
	}
	public Object BeginExceptionBlockX()
	{
		return (Object )gen.BeginExceptionBlock();
	}
};

public class ModuleHelper
{
	ModuleBuilder mod;

	public void SetModule(ModuleBuilder module)
	{
		mod = module;
	}
	public Object DefineDocument(String name)
	{
		Guid g = System.Guid.Empty;
		return mod.DefineDocument(name, g, g, g);
	}
};

}
