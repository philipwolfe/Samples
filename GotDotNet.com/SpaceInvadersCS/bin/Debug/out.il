
//  Microsoft (R) .NET Framework IL Disassembler.  Version 2.0.41014.0
//  Copyright (C) Microsoft Corporation. All rights reserved.



// Metadata version: v2.0.41014
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 2:0:3600:0
}
.assembly extern System
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 2:0:3600:0
}
.assembly SpaceInvaders
{
  .custom instance void [mscorlib]System.Reflection.AssemblyKeyNameAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyDelaySignAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.CLSCompliantAttribute::.ctor(bool) = ( 01 00 01 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 00 00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .permissionset reqmin
             = {[mscorlib]System.Security.Permissions.RegistryPermissionAttribute = {}}
  .hash algorithm 0x00008004
  .ver 1:0:1761:36826
}
.module SpaceInvaders.exe
// MVID: {D0554739-A3F9-4B53-8210-F567A008B2F2}
.imagebase 0x11000000
.file alignment 0x00001000
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x042C0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi sealed Microsoft.Samples.SpaceInvaders.LcdKey
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.LcdKey None = int32(0x00000000)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.LcdKey Up = int32(0x00000001)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.LcdKey Down = int32(0x00000002)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.LcdKey Left = int32(0x00000003)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.LcdKey Right = int32(0x00000004)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.LcdKey Enter = int32(0x00000005)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.LcdKey Exit = int32(0x00000006)
} // end of class Microsoft.Samples.SpaceInvaders.LcdKey

.class public auto ansi beforefieldinit Microsoft.Samples.SpaceInvaders.SerialLcd
       extends [mscorlib]System.Object
{
  .custom instance void [mscorlib]System.CLSCompliantAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .class auto ansi sealed nested public Fans
         extends [mscorlib]System.Enum
  {
    .custom instance void [mscorlib]System.FlagsAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public specialname rtspecialname int32 value__
    .field public static literal valuetype Microsoft.Samples.SpaceInvaders.SerialLcd/Fans Fan1 = int32(0x00000001)
    .field public static literal valuetype Microsoft.Samples.SpaceInvaders.SerialLcd/Fans Fan2 = int32(0x00000002)
    .field public static literal valuetype Microsoft.Samples.SpaceInvaders.SerialLcd/Fans Fan3 = int32(0x00000004)
    .field public static literal valuetype Microsoft.Samples.SpaceInvaders.SerialLcd/Fans Fan4 = int32(0x00000008)
  } // end of class Fans

  .class auto ansi sealed nested public KeyActivityEventHandler
         extends [mscorlib]System.MulticastDelegate
  {
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor(object 'object',
                                 native int 'method') runtime managed
    {
    } // end of method KeyActivityEventHandler::.ctor

    .method public hidebysig newslot virtual 
            instance class [mscorlib]System.'EventHandler`1'<class [mscorlib]System.EventArgs> 
            Invoke(object sender,
                   class [mscorlib]System.EventArgs e) runtime managed
    {
    } // end of method KeyActivityEventHandler::Invoke

    .method public hidebysig newslot virtual 
            instance class [mscorlib]System.IAsyncResult 
            BeginInvoke(object sender,
                        class [mscorlib]System.EventArgs e,
                        class [mscorlib]System.AsyncCallback callback,
                        object 'object') runtime managed
    {
    } // end of method KeyActivityEventHandler::BeginInvoke

    .method public hidebysig newslot virtual 
            instance class [mscorlib]System.'EventHandler`1'<class [mscorlib]System.EventArgs> 
            EndInvoke(class [mscorlib]System.IAsyncResult result) runtime managed
    {
    } // end of method KeyActivityEventHandler::EndInvoke

  } // end of class KeyActivityEventHandler

  .field private static literal int32 READ_BUFFER_SIZE = int32(0x00000080)
  .field private static literal int32 MAX_DATA_LENGTH = int32(0x00000010)
  .field private static literal int32 MAX_RESPONSE_TIME = int32(0x000000FA)
  .field private static literal int32 LINE_LENGTH = int32(0x00000010)
  .field private static literal int32 MAX_PACKET_LENGTH = int32(0x00000014)
  .field private static literal uint8 NORMAL_RESPONSE = uint8(0x40)
  .field private static literal uint8 NORMAL_REPORT = uint8(0x80)
  .field private static literal uint8 ERROR_RESPONSE = uint8(0xC0)
  .field private static literal uint8 KEY_ACTIVITY_REPORT = uint8(0x80)
  .field private static literal uint8 FAN_SPEED_REPORT = uint8(0x81)
  .field private static literal uint8 TEMPATURE_SENSOR_REPORT = uint8(0x82)
  .field private uint16 CYCLIC_REDUNDANCY_CHECK_SEED
  .field private class [System]System.IO.Ports.SerialPort com
  .field private uint8[] packetRcvBuffer
  .field private uint8[] packetXMitBuffer
  .field private class [mscorlib]System.Threading.Thread receiveThread
  .field private class [mscorlib]System.Threading.Thread eventThread
  .field private class Microsoft.Samples.SpaceInvaders.LcdPacket responsePacket
  .field private class [System]System.Collections.Generic.'Queue`1'<class Microsoft.Samples.SpaceInvaders.LcdPacket> reportQueue
  .field private object responseSignal
  .field private object reportSignal
  .field private valuetype Microsoft.Samples.SpaceInvaders.LcdKey _key
  .field private uint8 fan1Power
  .field private uint8 fan2Power
  .field private uint8 fan3Power
  .field private uint8 fan4Power
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       134 (0x86)
    .maxstack  6
    .locals init ([0] uint8 CS$0$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4     0xffff
    IL_0006:  stfld      uint16 Microsoft.Samples.SpaceInvaders.SerialLcd::CYCLIC_REDUNDANCY_CHECK_SEED
    IL_000b:  ldarg.0
    IL_000c:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0011:  nop
    IL_0012:  ldarg.0
    IL_0013:  ldstr      "COM3"
    IL_0018:  ldc.i4     0x4b00
    IL_001d:  newobj     instance void [System]System.IO.Ports.SerialPort::.ctor(string,
                                                                                 int32)
    IL_0022:  stfld      class [System]System.IO.Ports.SerialPort Microsoft.Samples.SpaceInvaders.SerialLcd::com
    IL_0027:  ldarg.0
    IL_0028:  ldc.i4.s   20
    IL_002a:  newarr     [mscorlib]System.Byte
    IL_002f:  stfld      uint8[] Microsoft.Samples.SpaceInvaders.SerialLcd::packetRcvBuffer
    IL_0034:  ldarg.0
    IL_0035:  ldc.i4.s   20
    IL_0037:  newarr     [mscorlib]System.Byte
    IL_003c:  stfld      uint8[] Microsoft.Samples.SpaceInvaders.SerialLcd::packetXMitBuffer
    IL_0041:  ldarg.0
    IL_0042:  ldarg.0
    IL_0043:  ldarg.0
    IL_0044:  ldarg.0
    IL_0045:  ldc.i4.0
    IL_0046:  dup
    IL_0047:  stloc.0
    IL_0048:  stfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan4Power
    IL_004d:  ldloc.0
    IL_004e:  dup
    IL_004f:  stloc.0
    IL_0050:  stfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan3Power
    IL_0055:  ldloc.0
    IL_0056:  dup
    IL_0057:  stloc.0
    IL_0058:  stfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan2Power
    IL_005d:  ldloc.0
    IL_005e:  stfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan1Power
    IL_0063:  ldarg.0
    IL_0064:  newobj     instance void class [System]System.Collections.Generic.'Queue`1'<class Microsoft.Samples.SpaceInvaders.LcdPacket>::.ctor()
    IL_0069:  stfld      class [System]System.Collections.Generic.'Queue`1'<class Microsoft.Samples.SpaceInvaders.LcdPacket> Microsoft.Samples.SpaceInvaders.SerialLcd::reportQueue
    IL_006e:  ldarg.0
    IL_006f:  newobj     instance void [mscorlib]System.Object::.ctor()
    IL_0074:  stfld      object Microsoft.Samples.SpaceInvaders.SerialLcd::responseSignal
    IL_0079:  ldarg.0
    IL_007a:  newobj     instance void [mscorlib]System.Object::.ctor()
    IL_007f:  stfld      object Microsoft.Samples.SpaceInvaders.SerialLcd::reportSignal
    IL_0084:  nop
    IL_0085:  ret
  } // end of method SerialLcd::.ctor

  .method public hidebysig instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> 
          Ping(class [mscorlib]System.Collections.Generic.'List`1'<uint8> data) cil managed
  {
    // Code size       55 (0x37)
    .maxstack  4
    .locals init ([0] uint8 'type',
             [1] class [mscorlib]System.Collections.Generic.'List`1'<uint8> CS$1$0000,
             [2] bool CS$4$0001)
    IL_0000:  ldc.i4.0
    IL_0001:  stloc.0
    IL_0002:  ldc.i4.s   16
    IL_0004:  ldarg.1
    IL_0005:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<uint8>::get_Count()
    IL_000a:  clt
    IL_000c:  ldc.i4.0
    IL_000d:  ceq
    IL_000f:  stloc.2
    IL_0010:  ldloc.2
    IL_0011:  brtrue.s   IL_0023

    IL_0013:  ldstr      "data"
    IL_0018:  ldstr      "must have 16 items or less"
    IL_001d:  newobj     instance void [mscorlib]System.ArgumentException::.ctor(string,
                                                                                 string)
    IL_0022:  throw

    IL_0023:  ldarg.0
    IL_0024:  ldloc.0
    IL_0025:  ldarg.1
    IL_0026:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<uint8>::get_Count()
    IL_002b:  conv.u1
    IL_002c:  ldarg.1
    IL_002d:  call       instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> Microsoft.Samples.SpaceInvaders.SerialLcd::SendReturnData(uint8,
                                                                                                                                                       uint8,
                                                                                                                                                       class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_0032:  stloc.1
    IL_0033:  br.s       IL_0035

    IL_0035:  ldloc.1
    IL_0036:  ret
  } // end of method SerialLcd::Ping

  .method public hidebysig specialname instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> 
          get_GetHardwareFirmwareVersion() cil managed
  {
    // Code size       16 (0x10)
    .maxstack  4
    .locals init ([0] uint8 'type',
             [1] class [mscorlib]System.Collections.Generic.'List`1'<uint8> CS$1$0000)
    IL_0000:  ldc.i4.1
    IL_0001:  stloc.0
    IL_0002:  ldarg.0
    IL_0003:  ldloc.0
    IL_0004:  ldc.i4.0
    IL_0005:  ldnull
    IL_0006:  call       instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> Microsoft.Samples.SpaceInvaders.SerialLcd::SendReturnData(uint8,
                                                                                                                                                       uint8,
                                                                                                                                                       class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_000b:  stloc.1
    IL_000c:  br.s       IL_000e

    IL_000e:  ldloc.1
    IL_000f:  ret
  } // end of method SerialLcd::get_GetHardwareFirmwareVersion

  .method public hidebysig instance bool 
          WriteUserFlashArea(class [mscorlib]System.Collections.Generic.'List`1'<uint8> data) cil managed
  {
    // Code size       28 (0x1c)
    .maxstack  4
    .locals init ([0] uint8 'type',
             [1] bool CS$1$0000)
    IL_0000:  ldc.i4.2
    IL_0001:  stloc.0
    IL_0002:  ldarg.0
    IL_0003:  ldarg.1
    IL_0004:  ldc.i4.s   16
    IL_0006:  call       instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> Microsoft.Samples.SpaceInvaders.SerialLcd::CreateListOfLength(class [mscorlib]System.Collections.Generic.'List`1'<uint8>,
                                                                                                                                                           int32)
    IL_000b:  starg.s    data
    IL_000d:  ldarg.0
    IL_000e:  ldloc.0
    IL_000f:  ldc.i4.s   16
    IL_0011:  ldarg.1
    IL_0012:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SendReturnBool(uint8,
                                                                                                 uint8,
                                                                                                 class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_0017:  stloc.1
    IL_0018:  br.s       IL_001a

    IL_001a:  ldloc.1
    IL_001b:  ret
  } // end of method SerialLcd::WriteUserFlashArea

  .method public hidebysig instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> 
          ReadUserFlashArea() cil managed
  {
    // Code size       16 (0x10)
    .maxstack  4
    .locals init ([0] uint8 'type',
             [1] class [mscorlib]System.Collections.Generic.'List`1'<uint8> CS$1$0000)
    IL_0000:  ldc.i4.3
    IL_0001:  stloc.0
    IL_0002:  ldarg.0
    IL_0003:  ldloc.0
    IL_0004:  ldc.i4.0
    IL_0005:  ldnull
    IL_0006:  call       instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> Microsoft.Samples.SpaceInvaders.SerialLcd::SendReturnData(uint8,
                                                                                                                                                       uint8,
                                                                                                                                                       class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_000b:  stloc.1
    IL_000c:  br.s       IL_000e

    IL_000e:  ldloc.1
    IL_000f:  ret
  } // end of method SerialLcd::ReadUserFlashArea

  .method public hidebysig instance bool 
          SaveState() cil managed
  {
    // Code size       16 (0x10)
    .maxstack  4
    .locals init ([0] uint8 'type',
             [1] bool CS$1$0000)
    IL_0000:  ldc.i4.4
    IL_0001:  stloc.0
    IL_0002:  ldarg.0
    IL_0003:  ldloc.0
    IL_0004:  ldc.i4.0
    IL_0005:  ldnull
    IL_0006:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SendReturnBool(uint8,
                                                                                                 uint8,
                                                                                                 class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_000b:  stloc.1
    IL_000c:  br.s       IL_000e

    IL_000e:  ldloc.1
    IL_000f:  ret
  } // end of method SerialLcd::SaveState

  .method public hidebysig instance bool 
          Clear() cil managed
  {
    // Code size       16 (0x10)
    .maxstack  4
    .locals init ([0] uint8 'type',
             [1] bool CS$1$0000)
    IL_0000:  ldc.i4.6
    IL_0001:  stloc.0
    IL_0002:  ldarg.0
    IL_0003:  ldloc.0
    IL_0004:  ldc.i4.0
    IL_0005:  ldnull
    IL_0006:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SendReturnBool(uint8,
                                                                                                 uint8,
                                                                                                 class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_000b:  stloc.1
    IL_000c:  br.s       IL_000e

    IL_000e:  ldloc.1
    IL_000f:  ret
  } // end of method SerialLcd::Clear

  .method public hidebysig instance bool 
          WriteLine1(string line) cil managed
  {
    // Code size       15 (0xf)
    .maxstack  3
    .locals init ([0] uint8 'type',
             [1] bool CS$1$0000)
    IL_0000:  ldc.i4.7
    IL_0001:  stloc.0
    IL_0002:  ldarg.0
    IL_0003:  ldloc.0
    IL_0004:  ldarg.1
    IL_0005:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::WriteLine(uint8,
                                                                                            string)
    IL_000a:  stloc.1
    IL_000b:  br.s       IL_000d

    IL_000d:  ldloc.1
    IL_000e:  ret
  } // end of method SerialLcd::WriteLine1

  .method public hidebysig instance bool 
          WriteLine1(class [mscorlib]System.Collections.Generic.'List`1'<uint8> data) cil managed
  {
    // Code size       28 (0x1c)
    .maxstack  4
    .locals init ([0] uint8 'type',
             [1] bool CS$1$0000)
    IL_0000:  ldc.i4.7
    IL_0001:  stloc.0
    IL_0002:  ldarg.0
    IL_0003:  ldarg.1
    IL_0004:  ldc.i4.s   16
    IL_0006:  call       instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> Microsoft.Samples.SpaceInvaders.SerialLcd::CreateListOfLength(class [mscorlib]System.Collections.Generic.'List`1'<uint8>,
                                                                                                                                                           int32)
    IL_000b:  starg.s    data
    IL_000d:  ldarg.0
    IL_000e:  ldloc.0
    IL_000f:  ldc.i4.s   16
    IL_0011:  ldarg.1
    IL_0012:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SendReturnBool(uint8,
                                                                                                 uint8,
                                                                                                 class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_0017:  stloc.1
    IL_0018:  br.s       IL_001a

    IL_001a:  ldloc.1
    IL_001b:  ret
  } // end of method SerialLcd::WriteLine1

  .method public hidebysig instance bool 
          WriteLine2(string line) cil managed
  {
    // Code size       15 (0xf)
    .maxstack  3
    .locals init ([0] uint8 'type',
             [1] bool CS$1$0000)
    IL_0000:  ldc.i4.8
    IL_0001:  stloc.0
    IL_0002:  ldarg.0
    IL_0003:  ldloc.0
    IL_0004:  ldarg.1
    IL_0005:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::WriteLine(uint8,
                                                                                            string)
    IL_000a:  stloc.1
    IL_000b:  br.s       IL_000d

    IL_000d:  ldloc.1
    IL_000e:  ret
  } // end of method SerialLcd::WriteLine2

  .method public hidebysig instance bool 
          WriteLine2(class [mscorlib]System.Collections.Generic.'List`1'<uint8> data) cil managed
  {
    // Code size       28 (0x1c)
    .maxstack  4
    .locals init ([0] uint8 'type',
             [1] bool CS$1$0000)
    IL_0000:  ldc.i4.8
    IL_0001:  stloc.0
    IL_0002:  ldarg.0
    IL_0003:  ldarg.1
    IL_0004:  ldc.i4.s   16
    IL_0006:  call       instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> Microsoft.Samples.SpaceInvaders.SerialLcd::CreateListOfLength(class [mscorlib]System.Collections.Generic.'List`1'<uint8>,
                                                                                                                                                           int32)
    IL_000b:  starg.s    data
    IL_000d:  ldarg.0
    IL_000e:  ldloc.0
    IL_000f:  ldc.i4.s   16
    IL_0011:  ldarg.1
    IL_0012:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SendReturnBool(uint8,
                                                                                                 uint8,
                                                                                                 class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_0017:  stloc.1
    IL_0018:  br.s       IL_001a

    IL_001a:  ldloc.1
    IL_001b:  ret
  } // end of method SerialLcd::WriteLine2

  .method private hidebysig instance bool 
          WriteLine(uint8 'type',
                    string line) cil managed
  {
    // Code size       92 (0x5c)
    .maxstack  4
    .locals init ([0] uint8[] vals,
             [1] class [mscorlib]System.Collections.Generic.'List`1'<uint8> sendVals,
             [2] uint8 b,
             [3] bool CS$1$0000,
             [4] uint8[] CS$6$0001,
             [5] int32 CS$7$0002,
             [6] bool CS$4$0003)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.2
    IL_0002:  ldc.i4.s   16
    IL_0004:  call       instance string Microsoft.Samples.SpaceInvaders.SerialLcd::CreateStringOfLength(string,
                                                                                                         int32)
    IL_0009:  starg.s    line
    IL_000b:  call       class [mscorlib]System.Text.Encoding [mscorlib]System.Text.Encoding::get_ASCII()
    IL_0010:  ldarg.2
    IL_0011:  callvirt   instance char[] [mscorlib]System.String::ToCharArray()
    IL_0016:  callvirt   instance uint8[] [mscorlib]System.Text.Encoding::GetBytes(char[])
    IL_001b:  stloc.0
    IL_001c:  newobj     instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::.ctor()
    IL_0021:  stloc.1
    IL_0022:  ldloc.0
    IL_0023:  stloc.s    CS$6$0001
    IL_0025:  ldc.i4.0
    IL_0026:  stloc.s    CS$7$0002
    IL_0028:  br.s       IL_003f

    IL_002a:  ldloc.s    CS$6$0001
    IL_002c:  ldloc.s    CS$7$0002
    IL_002e:  ldelem.u1
    IL_002f:  stloc.2
    IL_0030:  ldloc.1
    IL_0031:  ldloc.2
    IL_0032:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::Add(!0)
    IL_0037:  nop
    IL_0038:  nop
    IL_0039:  ldloc.s    CS$7$0002
    IL_003b:  ldc.i4.1
    IL_003c:  add
    IL_003d:  stloc.s    CS$7$0002
    IL_003f:  ldloc.s    CS$7$0002
    IL_0041:  ldloc.s    CS$6$0001
    IL_0043:  ldlen
    IL_0044:  conv.i4
    IL_0045:  clt
    IL_0047:  stloc.s    CS$4$0003
    IL_0049:  ldloc.s    CS$4$0003
    IL_004b:  brtrue.s   IL_002a

    IL_004d:  ldarg.0
    IL_004e:  ldarg.1
    IL_004f:  ldc.i4.s   16
    IL_0051:  ldloc.1
    IL_0052:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SendReturnBool(uint8,
                                                                                                 uint8,
                                                                                                 class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_0057:  stloc.3
    IL_0058:  br.s       IL_005a

    IL_005a:  ldloc.3
    IL_005b:  ret
  } // end of method SerialLcd::WriteLine

  .method public hidebysig instance bool 
          SetCursorPosition(int32 column,
                            int32 row) cil managed
  {
    // Code size       110 (0x6e)
    .maxstack  4
    .locals init ([0] uint8 'type',
             [1] class [mscorlib]System.Collections.Generic.'List`1'<uint8> data,
             [2] bool CS$1$0000,
             [3] bool CS$4$0001)
    IL_0000:  ldc.i4.s   11
    IL_0002:  stloc.0
    IL_0003:  newobj     instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::.ctor()
    IL_0008:  stloc.1
    IL_0009:  ldc.i4.s   15
    IL_000b:  ldarg.1
    IL_000c:  blt.s      IL_0017

    IL_000e:  ldc.i4.0
    IL_000f:  ldarg.1
    IL_0010:  cgt
    IL_0012:  ldc.i4.0
    IL_0013:  ceq
    IL_0015:  br.s       IL_0018

    IL_0017:  ldc.i4.0
    IL_0018:  stloc.3
    IL_0019:  ldloc.3
    IL_001a:  brtrue.s   IL_002c

    IL_001c:  ldstr      "column"
    IL_0021:  ldstr      "must be 0-15"
    IL_0026:  newobj     instance void [mscorlib]System.ArgumentOutOfRangeException::.ctor(string,
                                                                                           string)
    IL_002b:  throw

    IL_002c:  ldc.i4.1
    IL_002d:  ldarg.1
    IL_002e:  blt.s      IL_0039

    IL_0030:  ldc.i4.0
    IL_0031:  ldarg.1
    IL_0032:  cgt
    IL_0034:  ldc.i4.0
    IL_0035:  ceq
    IL_0037:  br.s       IL_003a

    IL_0039:  ldc.i4.0
    IL_003a:  stloc.3
    IL_003b:  ldloc.3
    IL_003c:  brtrue.s   IL_004e

    IL_003e:  ldstr      "row"
    IL_0043:  ldstr      "must be 0-1"
    IL_0048:  newobj     instance void [mscorlib]System.ArgumentOutOfRangeException::.ctor(string,
                                                                                           string)
    IL_004d:  throw

    IL_004e:  ldloc.1
    IL_004f:  ldarg.1
    IL_0050:  conv.u1
    IL_0051:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::Add(!0)
    IL_0056:  nop
    IL_0057:  ldloc.1
    IL_0058:  ldarg.2
    IL_0059:  conv.u1
    IL_005a:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::Add(!0)
    IL_005f:  nop
    IL_0060:  ldarg.0
    IL_0061:  ldloc.0
    IL_0062:  ldc.i4.2
    IL_0063:  ldloc.1
    IL_0064:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SendReturnBool(uint8,
                                                                                                 uint8,
                                                                                                 class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_0069:  stloc.2
    IL_006a:  br.s       IL_006c

    IL_006c:  ldloc.2
    IL_006d:  ret
  } // end of method SerialLcd::SetCursorPosition

  .method public hidebysig instance bool 
          SetLcdContrast(int32 contrastValue) cil managed
  {
    // Code size       67 (0x43)
    .maxstack  4
    .locals init ([0] uint8 'type',
             [1] class [mscorlib]System.Collections.Generic.'List`1'<uint8> data,
             [2] bool CS$1$0000,
             [3] bool CS$4$0001)
    IL_0000:  ldc.i4.s   13
    IL_0002:  stloc.0
    IL_0003:  newobj     instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::.ctor()
    IL_0008:  stloc.1
    IL_0009:  ldc.i4.0
    IL_000a:  ldarg.1
    IL_000b:  bgt.s      IL_0017

    IL_000d:  ldc.i4.s   50
    IL_000f:  ldarg.1
    IL_0010:  clt
    IL_0012:  ldc.i4.0
    IL_0013:  ceq
    IL_0015:  br.s       IL_0018

    IL_0017:  ldc.i4.0
    IL_0018:  stloc.3
    IL_0019:  ldloc.3
    IL_001a:  brtrue.s   IL_002c

    IL_001c:  ldstr      "contrastValue"
    IL_0021:  ldstr      "must be 0 -50"
    IL_0026:  newobj     instance void [mscorlib]System.ArgumentOutOfRangeException::.ctor(string,
                                                                                           string)
    IL_002b:  throw

    IL_002c:  ldloc.1
    IL_002d:  ldarg.1
    IL_002e:  conv.u1
    IL_002f:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::Add(!0)
    IL_0034:  nop
    IL_0035:  ldarg.0
    IL_0036:  ldloc.0
    IL_0037:  ldc.i4.1
    IL_0038:  ldloc.1
    IL_0039:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SendReturnBool(uint8,
                                                                                                 uint8,
                                                                                                 class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_003e:  stloc.2
    IL_003f:  br.s       IL_0041

    IL_0041:  ldloc.2
    IL_0042:  ret
  } // end of method SerialLcd::SetLcdContrast

  .method public hidebysig instance bool 
          SetLcdBacklight(int32 backlightValue) cil managed
  {
    // Code size       67 (0x43)
    .maxstack  4
    .locals init ([0] uint8 'type',
             [1] class [mscorlib]System.Collections.Generic.'List`1'<uint8> data,
             [2] bool CS$1$0000,
             [3] bool CS$4$0001)
    IL_0000:  ldc.i4.s   14
    IL_0002:  stloc.0
    IL_0003:  newobj     instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::.ctor()
    IL_0008:  stloc.1
    IL_0009:  ldc.i4.0
    IL_000a:  ldarg.1
    IL_000b:  bgt.s      IL_0017

    IL_000d:  ldc.i4.s   100
    IL_000f:  ldarg.1
    IL_0010:  clt
    IL_0012:  ldc.i4.0
    IL_0013:  ceq
    IL_0015:  br.s       IL_0018

    IL_0017:  ldc.i4.0
    IL_0018:  stloc.3
    IL_0019:  ldloc.3
    IL_001a:  brtrue.s   IL_002c

    IL_001c:  ldstr      "backlightValue"
    IL_0021:  ldstr      "must be 0 - 50"
    IL_0026:  newobj     instance void [mscorlib]System.ArgumentOutOfRangeException::.ctor(string,
                                                                                           string)
    IL_002b:  throw

    IL_002c:  ldloc.1
    IL_002d:  ldarg.1
    IL_002e:  conv.u1
    IL_002f:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::Add(!0)
    IL_0034:  nop
    IL_0035:  ldarg.0
    IL_0036:  ldloc.0
    IL_0037:  ldc.i4.1
    IL_0038:  ldloc.1
    IL_0039:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SendReturnBool(uint8,
                                                                                                 uint8,
                                                                                                 class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_003e:  stloc.2
    IL_003f:  br.s       IL_0041

    IL_0041:  ldloc.2
    IL_0042:  ret
  } // end of method SerialLcd::SetLcdBacklight

  .method public hidebysig specialname instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> 
          get_GetLastFanPulse() cil managed
  {
    // Code size       17 (0x11)
    .maxstack  4
    .locals init ([0] uint8 'type',
             [1] class [mscorlib]System.Collections.Generic.'List`1'<uint8> CS$1$0000)
    IL_0000:  ldc.i4.s   15
    IL_0002:  stloc.0
    IL_0003:  ldarg.0
    IL_0004:  ldloc.0
    IL_0005:  ldc.i4.0
    IL_0006:  ldnull
    IL_0007:  call       instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> Microsoft.Samples.SpaceInvaders.SerialLcd::SendReturnData(uint8,
                                                                                                                                                       uint8,
                                                                                                                                                       class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_000c:  stloc.1
    IL_000d:  br.s       IL_000f

    IL_000f:  ldloc.1
    IL_0010:  ret
  } // end of method SerialLcd::get_GetLastFanPulse

  .method public hidebysig instance bool 
          SetupFanReporting(valuetype Microsoft.Samples.SpaceInvaders.SerialLcd/Fans fans) cil managed
  {
    // Code size       67 (0x43)
    .maxstack  4
    .locals init ([0] uint8 'type',
             [1] class [mscorlib]System.Collections.Generic.'List`1'<uint8> data,
             [2] bool CS$1$0000,
             [3] bool CS$4$0001)
    IL_0000:  ldc.i4.s   16
    IL_0002:  stloc.0
    IL_0003:  newobj     instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::.ctor()
    IL_0008:  stloc.1
    IL_0009:  ldarg.1
    IL_000a:  ldc.i4.1
    IL_000b:  blt.s      IL_0017

    IL_000d:  ldc.i4.s   15
    IL_000f:  ldarg.1
    IL_0010:  clt
    IL_0012:  ldc.i4.0
    IL_0013:  ceq
    IL_0015:  br.s       IL_0018

    IL_0017:  ldc.i4.0
    IL_0018:  stloc.3
    IL_0019:  ldloc.3
    IL_001a:  brtrue.s   IL_002c

    IL_001c:  ldstr      "backlightValue"
    IL_0021:  ldstr      "must be 0 -50"
    IL_0026:  newobj     instance void [mscorlib]System.ArgumentOutOfRangeException::.ctor(string,
                                                                                           string)
    IL_002b:  throw

    IL_002c:  ldloc.1
    IL_002d:  ldarg.1
    IL_002e:  conv.u1
    IL_002f:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::Add(!0)
    IL_0034:  nop
    IL_0035:  ldarg.0
    IL_0036:  ldloc.0
    IL_0037:  ldc.i4.1
    IL_0038:  ldloc.1
    IL_0039:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SendReturnBool(uint8,
                                                                                                 uint8,
                                                                                                 class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_003e:  stloc.2
    IL_003f:  br.s       IL_0041

    IL_0041:  ldloc.2
    IL_0042:  ret
  } // end of method SerialLcd::SetupFanReporting

  .method public hidebysig instance bool 
          SetFan1Power(int32 fan1) cil managed
  {
    // Code size       50 (0x32)
    .maxstack  4
    .locals init ([0] bool CS$1$0000,
             [1] int32[] CS$0$0001)
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.4
    IL_0002:  newarr     [mscorlib]System.Int32
    IL_0007:  stloc.1
    IL_0008:  ldloc.1
    IL_0009:  ldc.i4.0
    IL_000a:  ldarg.1
    IL_000b:  stelem.i4
    IL_000c:  ldloc.1
    IL_000d:  ldc.i4.1
    IL_000e:  ldarg.0
    IL_000f:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan2Power
    IL_0014:  stelem.i4
    IL_0015:  ldloc.1
    IL_0016:  ldc.i4.2
    IL_0017:  ldarg.0
    IL_0018:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan3Power
    IL_001d:  stelem.i4
    IL_001e:  ldloc.1
    IL_001f:  ldc.i4.3
    IL_0020:  ldarg.0
    IL_0021:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan4Power
    IL_0026:  stelem.i4
    IL_0027:  ldloc.1
    IL_0028:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SetFanPower(int32[])
    IL_002d:  stloc.0
    IL_002e:  br.s       IL_0030

    IL_0030:  ldloc.0
    IL_0031:  ret
  } // end of method SerialLcd::SetFan1Power

  .method public hidebysig instance bool 
          SetFan2Power(int32 fan2) cil managed
  {
    // Code size       50 (0x32)
    .maxstack  4
    .locals init ([0] bool CS$1$0000,
             [1] int32[] CS$0$0001)
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.4
    IL_0002:  newarr     [mscorlib]System.Int32
    IL_0007:  stloc.1
    IL_0008:  ldloc.1
    IL_0009:  ldc.i4.0
    IL_000a:  ldarg.0
    IL_000b:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan1Power
    IL_0010:  stelem.i4
    IL_0011:  ldloc.1
    IL_0012:  ldc.i4.1
    IL_0013:  ldarg.1
    IL_0014:  stelem.i4
    IL_0015:  ldloc.1
    IL_0016:  ldc.i4.2
    IL_0017:  ldarg.0
    IL_0018:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan3Power
    IL_001d:  stelem.i4
    IL_001e:  ldloc.1
    IL_001f:  ldc.i4.3
    IL_0020:  ldarg.0
    IL_0021:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan4Power
    IL_0026:  stelem.i4
    IL_0027:  ldloc.1
    IL_0028:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SetFanPower(int32[])
    IL_002d:  stloc.0
    IL_002e:  br.s       IL_0030

    IL_0030:  ldloc.0
    IL_0031:  ret
  } // end of method SerialLcd::SetFan2Power

  .method public hidebysig instance bool 
          SetFan3Power(int32 fan3) cil managed
  {
    // Code size       50 (0x32)
    .maxstack  4
    .locals init ([0] bool CS$1$0000,
             [1] int32[] CS$0$0001)
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.4
    IL_0002:  newarr     [mscorlib]System.Int32
    IL_0007:  stloc.1
    IL_0008:  ldloc.1
    IL_0009:  ldc.i4.0
    IL_000a:  ldarg.0
    IL_000b:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan1Power
    IL_0010:  stelem.i4
    IL_0011:  ldloc.1
    IL_0012:  ldc.i4.1
    IL_0013:  ldarg.0
    IL_0014:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan2Power
    IL_0019:  stelem.i4
    IL_001a:  ldloc.1
    IL_001b:  ldc.i4.2
    IL_001c:  ldarg.1
    IL_001d:  stelem.i4
    IL_001e:  ldloc.1
    IL_001f:  ldc.i4.3
    IL_0020:  ldarg.0
    IL_0021:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan4Power
    IL_0026:  stelem.i4
    IL_0027:  ldloc.1
    IL_0028:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SetFanPower(int32[])
    IL_002d:  stloc.0
    IL_002e:  br.s       IL_0030

    IL_0030:  ldloc.0
    IL_0031:  ret
  } // end of method SerialLcd::SetFan3Power

  .method public hidebysig instance bool 
          SetFan4Power(int32 fan4) cil managed
  {
    // Code size       50 (0x32)
    .maxstack  4
    .locals init ([0] bool CS$1$0000,
             [1] int32[] CS$0$0001)
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.4
    IL_0002:  newarr     [mscorlib]System.Int32
    IL_0007:  stloc.1
    IL_0008:  ldloc.1
    IL_0009:  ldc.i4.0
    IL_000a:  ldarg.0
    IL_000b:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan1Power
    IL_0010:  stelem.i4
    IL_0011:  ldloc.1
    IL_0012:  ldc.i4.1
    IL_0013:  ldarg.0
    IL_0014:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan2Power
    IL_0019:  stelem.i4
    IL_001a:  ldloc.1
    IL_001b:  ldc.i4.2
    IL_001c:  ldarg.0
    IL_001d:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan3Power
    IL_0022:  stelem.i4
    IL_0023:  ldloc.1
    IL_0024:  ldc.i4.3
    IL_0025:  ldarg.1
    IL_0026:  stelem.i4
    IL_0027:  ldloc.1
    IL_0028:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SetFanPower(int32[])
    IL_002d:  stloc.0
    IL_002e:  br.s       IL_0030

    IL_0030:  ldloc.0
    IL_0031:  ret
  } // end of method SerialLcd::SetFan4Power

  .method public hidebysig instance bool 
          SetFanPower(int32[] fans) cil managed
  {
    .param [1]
    .custom instance void [mscorlib]System.ParamArrayAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       386 (0x182)
    .maxstack  4
    .locals init ([0] uint8 'type',
             [1] class [mscorlib]System.Collections.Generic.'List`1'<uint8> data,
             [2] bool CS$1$0000,
             [3] bool CS$4$0001)
    IL_0000:  ldarg.1
    IL_0001:  ldnull
    IL_0002:  ceq
    IL_0004:  ldc.i4.0
    IL_0005:  ceq
    IL_0007:  stloc.3
    IL_0008:  ldloc.3
    IL_0009:  brtrue.s   IL_0016

    IL_000b:  ldstr      "The fans argument cannot be null"
    IL_0010:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string)
    IL_0015:  throw

    IL_0016:  ldarg.1
    IL_0017:  ldlen
    IL_0018:  conv.i4
    IL_0019:  ldc.i4.4
    IL_001a:  cgt
    IL_001c:  ldc.i4.0
    IL_001d:  ceq
    IL_001f:  stloc.3
    IL_0020:  ldloc.3
    IL_0021:  brtrue.s   IL_002e

    IL_0023:  ldstr      "At most, 4 fans can be specified"
    IL_0028:  newobj     instance void [mscorlib]System.ArgumentException::.ctor(string)
    IL_002d:  throw

    IL_002e:  ldc.i4.s   17
    IL_0030:  stloc.0
    IL_0031:  newobj     instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::.ctor()
    IL_0036:  stloc.1
    IL_0037:  ldarg.1
    IL_0038:  ldc.i4.0
    IL_0039:  ldelem.i4
    IL_003a:  ldc.i4.0
    IL_003b:  blt.s      IL_0049

    IL_003d:  ldc.i4.s   100
    IL_003f:  ldarg.1
    IL_0040:  ldc.i4.0
    IL_0041:  ldelem.i4
    IL_0042:  clt
    IL_0044:  ldc.i4.0
    IL_0045:  ceq
    IL_0047:  br.s       IL_004a

    IL_0049:  ldc.i4.0
    IL_004a:  stloc.3
    IL_004b:  ldloc.3
    IL_004c:  brtrue.s   IL_005e

    IL_004e:  ldstr      "fan1"
    IL_0053:  ldstr      "must be 0-100"
    IL_0058:  newobj     instance void [mscorlib]System.ArgumentOutOfRangeException::.ctor(string,
                                                                                           string)
    IL_005d:  throw

    IL_005e:  ldarg.1
    IL_005f:  ldlen
    IL_0060:  conv.i4
    IL_0061:  ldc.i4.1
    IL_0062:  ble.s      IL_0079

    IL_0064:  ldarg.1
    IL_0065:  ldc.i4.1
    IL_0066:  ldelem.i4
    IL_0067:  ldc.i4.0
    IL_0068:  blt.s      IL_0076

    IL_006a:  ldc.i4.s   100
    IL_006c:  ldarg.1
    IL_006d:  ldc.i4.1
    IL_006e:  ldelem.i4
    IL_006f:  clt
    IL_0071:  ldc.i4.0
    IL_0072:  ceq
    IL_0074:  br.s       IL_0077

    IL_0076:  ldc.i4.0
    IL_0077:  br.s       IL_007a

    IL_0079:  ldc.i4.1
    IL_007a:  stloc.3
    IL_007b:  ldloc.3
    IL_007c:  brtrue.s   IL_008e

    IL_007e:  ldstr      "fan2"
    IL_0083:  ldstr      "must be 0-100"
    IL_0088:  newobj     instance void [mscorlib]System.ArgumentOutOfRangeException::.ctor(string,
                                                                                           string)
    IL_008d:  throw

    IL_008e:  ldarg.1
    IL_008f:  ldlen
    IL_0090:  conv.i4
    IL_0091:  ldc.i4.2
    IL_0092:  ble.s      IL_00a9

    IL_0094:  ldarg.1
    IL_0095:  ldc.i4.2
    IL_0096:  ldelem.i4
    IL_0097:  ldc.i4.0
    IL_0098:  blt.s      IL_00a6

    IL_009a:  ldc.i4.s   100
    IL_009c:  ldarg.1
    IL_009d:  ldc.i4.2
    IL_009e:  ldelem.i4
    IL_009f:  clt
    IL_00a1:  ldc.i4.0
    IL_00a2:  ceq
    IL_00a4:  br.s       IL_00a7

    IL_00a6:  ldc.i4.0
    IL_00a7:  br.s       IL_00aa

    IL_00a9:  ldc.i4.1
    IL_00aa:  stloc.3
    IL_00ab:  ldloc.3
    IL_00ac:  brtrue.s   IL_00be

    IL_00ae:  ldstr      "fan3"
    IL_00b3:  ldstr      "must be 0-100"
    IL_00b8:  newobj     instance void [mscorlib]System.ArgumentOutOfRangeException::.ctor(string,
                                                                                           string)
    IL_00bd:  throw

    IL_00be:  ldarg.1
    IL_00bf:  ldlen
    IL_00c0:  conv.i4
    IL_00c1:  ldc.i4.3
    IL_00c2:  ble.s      IL_00d9

    IL_00c4:  ldarg.1
    IL_00c5:  ldc.i4.3
    IL_00c6:  ldelem.i4
    IL_00c7:  ldc.i4.0
    IL_00c8:  blt.s      IL_00d6

    IL_00ca:  ldc.i4.s   100
    IL_00cc:  ldarg.1
    IL_00cd:  ldc.i4.3
    IL_00ce:  ldelem.i4
    IL_00cf:  clt
    IL_00d1:  ldc.i4.0
    IL_00d2:  ceq
    IL_00d4:  br.s       IL_00d7

    IL_00d6:  ldc.i4.0
    IL_00d7:  br.s       IL_00da

    IL_00d9:  ldc.i4.1
    IL_00da:  stloc.3
    IL_00db:  ldloc.3
    IL_00dc:  brtrue.s   IL_00ee

    IL_00de:  ldstr      "fan4"
    IL_00e3:  ldstr      "must be 0-100"
    IL_00e8:  newobj     instance void [mscorlib]System.ArgumentOutOfRangeException::.ctor(string,
                                                                                           string)
    IL_00ed:  throw

    IL_00ee:  ldarg.0
    IL_00ef:  ldarg.1
    IL_00f0:  ldc.i4.0
    IL_00f1:  ldelem.i4
    IL_00f2:  conv.u1
    IL_00f3:  stfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan1Power
    IL_00f8:  ldloc.1
    IL_00f9:  ldarg.0
    IL_00fa:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan1Power
    IL_00ff:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::Add(!0)
    IL_0104:  nop
    IL_0105:  ldarg.1
    IL_0106:  ldlen
    IL_0107:  conv.i4
    IL_0108:  ldc.i4.1
    IL_0109:  cgt
    IL_010b:  ldc.i4.0
    IL_010c:  ceq
    IL_010e:  stloc.3
    IL_010f:  ldloc.3
    IL_0110:  brtrue.s   IL_0174

    IL_0112:  ldarg.0
    IL_0113:  ldarg.1
    IL_0114:  ldc.i4.1
    IL_0115:  ldelem.i4
    IL_0116:  conv.u1
    IL_0117:  stfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan2Power
    IL_011c:  ldloc.1
    IL_011d:  ldarg.0
    IL_011e:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan2Power
    IL_0123:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::Add(!0)
    IL_0128:  nop
    IL_0129:  ldarg.1
    IL_012a:  ldlen
    IL_012b:  conv.i4
    IL_012c:  ldc.i4.2
    IL_012d:  cgt
    IL_012f:  ldc.i4.0
    IL_0130:  ceq
    IL_0132:  stloc.3
    IL_0133:  ldloc.3
    IL_0134:  brtrue.s   IL_0173

    IL_0136:  ldarg.0
    IL_0137:  ldarg.1
    IL_0138:  ldc.i4.2
    IL_0139:  ldelem.i4
    IL_013a:  conv.u1
    IL_013b:  stfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan3Power
    IL_0140:  ldloc.1
    IL_0141:  ldarg.0
    IL_0142:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan3Power
    IL_0147:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::Add(!0)
    IL_014c:  nop
    IL_014d:  ldarg.1
    IL_014e:  ldlen
    IL_014f:  conv.i4
    IL_0150:  ldc.i4.3
    IL_0151:  cgt
    IL_0153:  ldc.i4.0
    IL_0154:  ceq
    IL_0156:  stloc.3
    IL_0157:  ldloc.3
    IL_0158:  brtrue.s   IL_0172

    IL_015a:  ldarg.0
    IL_015b:  ldarg.1
    IL_015c:  ldc.i4.3
    IL_015d:  ldelem.i4
    IL_015e:  conv.u1
    IL_015f:  stfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan4Power
    IL_0164:  ldloc.1
    IL_0165:  ldarg.0
    IL_0166:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.SerialLcd::fan4Power
    IL_016b:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::Add(!0)
    IL_0170:  nop
    IL_0171:  nop
    IL_0172:  nop
    IL_0173:  nop
    IL_0174:  ldarg.0
    IL_0175:  ldloc.0
    IL_0176:  ldc.i4.4
    IL_0177:  ldloc.1
    IL_0178:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SendReturnBool(uint8,
                                                                                                 uint8,
                                                                                                 class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_017d:  stloc.2
    IL_017e:  br.s       IL_0180

    IL_0180:  ldloc.2
    IL_0181:  ret
  } // end of method SerialLcd::SetFanPower

  .method private hidebysig instance string 
          CreateStringOfLength(string s,
                               int32 length) cil managed
  {
    // Code size       73 (0x49)
    .maxstack  4
    .locals init ([0] string CS$1$0000,
             [1] bool CS$4$0001)
    IL_0000:  ldarg.2
    IL_0001:  ldarg.1
    IL_0002:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_0007:  clt
    IL_0009:  ldc.i4.0
    IL_000a:  ceq
    IL_000c:  stloc.1
    IL_000d:  ldloc.1
    IL_000e:  brtrue.s   IL_001b

    IL_0010:  ldarg.1
    IL_0011:  ldarg.2
    IL_0012:  callvirt   instance string [mscorlib]System.String::Substring(int32)
    IL_0017:  starg.s    s
    IL_0019:  br.s       IL_0043

    IL_001b:  ldarg.2
    IL_001c:  ldarg.1
    IL_001d:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_0022:  cgt
    IL_0024:  ldc.i4.0
    IL_0025:  ceq
    IL_0027:  stloc.1
    IL_0028:  ldloc.1
    IL_0029:  brtrue.s   IL_0043

    IL_002b:  ldarg.1
    IL_002c:  ldc.i4.s   32
    IL_002e:  ldarg.2
    IL_002f:  ldarg.1
    IL_0030:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_0035:  sub
    IL_0036:  newobj     instance void [mscorlib]System.String::.ctor(char,
                                                                      int32)
    IL_003b:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_0040:  starg.s    s
    IL_0042:  nop
    IL_0043:  ldarg.1
    IL_0044:  stloc.0
    IL_0045:  br.s       IL_0047

    IL_0047:  ldloc.0
    IL_0048:  ret
  } // end of method SerialLcd::CreateStringOfLength

  .method private hidebysig instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> 
          CreateListOfLength(class [mscorlib]System.Collections.Generic.'List`1'<uint8> bArray,
                             int32 length) cil managed
  {
    // Code size       52 (0x34)
    .maxstack  3
    .locals init ([0] class [mscorlib]System.Collections.Generic.'List`1'<uint8> CS$1$0000,
             [1] bool CS$4$0001)
    IL_0000:  ldarg.2
    IL_0001:  ldarg.1
    IL_0002:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<uint8>::get_Count()
    IL_0007:  ceq
    IL_0009:  stloc.1
    IL_000a:  ldloc.1
    IL_000b:  brtrue.s   IL_002e

    IL_000d:  br.s       IL_001f

    IL_000f:  ldarg.1
    IL_0010:  ldarg.1
    IL_0011:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<uint8>::get_Count()
    IL_0016:  ldc.i4.1
    IL_0017:  sub
    IL_0018:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::RemoveAt(int32)
    IL_001d:  nop
    IL_001e:  nop
    IL_001f:  ldarg.1
    IL_0020:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<uint8>::get_Count()
    IL_0025:  ldc.i4.s   16
    IL_0027:  cgt
    IL_0029:  stloc.1
    IL_002a:  ldloc.1
    IL_002b:  brtrue.s   IL_000f

    IL_002d:  nop
    IL_002e:  ldarg.1
    IL_002f:  stloc.0
    IL_0030:  br.s       IL_0032

    IL_0032:  ldloc.0
    IL_0033:  ret
  } // end of method SerialLcd::CreateListOfLength

  .method private hidebysig instance class Microsoft.Samples.SpaceInvaders.LcdPacket 
          Send(uint8 'type',
               uint8 dataLength,
               class [mscorlib]System.Collections.Generic.'List`1'<uint8> data) cil managed
  {
    // Code size       267 (0x10b)
    .maxstack  5
    .locals init ([0] uint16 _cyclicRedundancyCheck,
             [1] int32 i,
             [2] class Microsoft.Samples.SpaceInvaders.LcdPacket CS$1$0000,
             [3] bool CS$4$0001,
             [4] object CS$2$0002)
    IL_0000:  ldarg.3
    IL_0001:  brtrue.s   IL_0006

    IL_0003:  ldarg.2
    IL_0004:  brtrue.s   IL_0014

    IL_0006:  ldarg.2
    IL_0007:  ldarg.3
    IL_0008:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<uint8>::get_Count()
    IL_000d:  cgt
    IL_000f:  ldc.i4.0
    IL_0010:  ceq
    IL_0012:  br.s       IL_0015

    IL_0014:  ldc.i4.0
    IL_0015:  stloc.3
    IL_0016:  ldloc.3
    IL_0017:  brtrue.s   IL_0024

    IL_0019:  ldstr      "data"
    IL_001e:  newobj     instance void [mscorlib]System.ArgumentException::.ctor(string)
    IL_0023:  throw

    IL_0024:  ldarg.0
    IL_0025:  ldfld      uint8[] Microsoft.Samples.SpaceInvaders.SerialLcd::packetXMitBuffer
    IL_002a:  ldc.i4.0
    IL_002b:  ldarg.1
    IL_002c:  stelem.i1
    IL_002d:  ldarg.0
    IL_002e:  ldfld      uint8[] Microsoft.Samples.SpaceInvaders.SerialLcd::packetXMitBuffer
    IL_0033:  ldc.i4.1
    IL_0034:  ldarg.2
    IL_0035:  stelem.i1
    IL_0036:  ldc.i4.0
    IL_0037:  ldarg.2
    IL_0038:  ceq
    IL_003a:  stloc.3
    IL_003b:  ldloc.3
    IL_003c:  brtrue.s   IL_0061

    IL_003e:  ldc.i4.0
    IL_003f:  stloc.1
    IL_0040:  br.s       IL_0058

    IL_0042:  ldarg.0
    IL_0043:  ldfld      uint8[] Microsoft.Samples.SpaceInvaders.SerialLcd::packetXMitBuffer
    IL_0048:  ldloc.1
    IL_0049:  ldc.i4.2
    IL_004a:  add
    IL_004b:  ldarg.3
    IL_004c:  ldloc.1
    IL_004d:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<uint8>::get_Item(int32)
    IL_0052:  stelem.i1
    IL_0053:  nop
    IL_0054:  ldloc.1
    IL_0055:  ldc.i4.1
    IL_0056:  add
    IL_0057:  stloc.1
    IL_0058:  ldloc.1
    IL_0059:  ldarg.2
    IL_005a:  clt
    IL_005c:  stloc.3
    IL_005d:  ldloc.3
    IL_005e:  brtrue.s   IL_0042

    IL_0060:  nop
    IL_0061:  ldarg.0
    IL_0062:  ldfld      uint8[] Microsoft.Samples.SpaceInvaders.SerialLcd::packetXMitBuffer
    IL_0067:  ldarg.2
    IL_0068:  ldc.i4.2
    IL_0069:  add
    IL_006a:  ldarg.0
    IL_006b:  ldfld      uint16 Microsoft.Samples.SpaceInvaders.SerialLcd::CYCLIC_REDUNDANCY_CHECK_SEED
    IL_0070:  call       uint16 Microsoft.Samples.SpaceInvaders.CyclicRedundancyCheckGenerator::GenerateCyclicRedundancyCheck(uint8[],
                                                                                                                              int32,
                                                                                                                              uint16)
    IL_0075:  stloc.0
    IL_0076:  ldarg.0
    IL_0077:  ldfld      uint8[] Microsoft.Samples.SpaceInvaders.SerialLcd::packetXMitBuffer
    IL_007c:  ldc.i4.2
    IL_007d:  ldarg.2
    IL_007e:  add
    IL_007f:  ldc.i4.1
    IL_0080:  add
    IL_0081:  ldloc.0
    IL_0082:  ldc.i4.8
    IL_0083:  shr
    IL_0084:  conv.u1
    IL_0085:  stelem.i1
    IL_0086:  ldarg.0
    IL_0087:  ldfld      uint8[] Microsoft.Samples.SpaceInvaders.SerialLcd::packetXMitBuffer
    IL_008c:  ldc.i4.2
    IL_008d:  ldarg.2
    IL_008e:  add
    IL_008f:  ldloc.0
    IL_0090:  conv.u1
    IL_0091:  stelem.i1
    IL_0092:  ldarg.0
    IL_0093:  ldfld      object Microsoft.Samples.SpaceInvaders.SerialLcd::responseSignal
    IL_0098:  dup
    IL_0099:  stloc.s    CS$2$0002
    IL_009b:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_00a0:  nop
    .try
    {
      IL_00a1:  ldarg.0
      IL_00a2:  ldnull
      IL_00a3:  stfld      class Microsoft.Samples.SpaceInvaders.LcdPacket Microsoft.Samples.SpaceInvaders.SerialLcd::responsePacket
      IL_00a8:  ldarg.0
      IL_00a9:  ldfld      class [System]System.IO.Ports.SerialPort Microsoft.Samples.SpaceInvaders.SerialLcd::com
      IL_00ae:  callvirt   instance bool [System]System.IO.Ports.SerialPort::get_IsOpen()
      IL_00b3:  ldc.i4.0
      IL_00b4:  ceq
      IL_00b6:  stloc.3
      IL_00b7:  ldloc.3
      IL_00b8:  brtrue.s   IL_00f3

      IL_00ba:  ldarg.0
      IL_00bb:  ldfld      class [System]System.IO.Ports.SerialPort Microsoft.Samples.SpaceInvaders.SerialLcd::com
      IL_00c0:  ldarg.0
      IL_00c1:  ldfld      uint8[] Microsoft.Samples.SpaceInvaders.SerialLcd::packetXMitBuffer
      IL_00c6:  ldc.i4.0
      IL_00c7:  ldarg.2
      IL_00c8:  ldc.i4.4
      IL_00c9:  add
      IL_00ca:  callvirt   instance void [System]System.IO.Ports.SerialPort::Write(uint8[],
                                                                                   int32,
                                                                                   int32)
      IL_00cf:  nop
      IL_00d0:  ldarg.0
      IL_00d1:  ldfld      object Microsoft.Samples.SpaceInvaders.SerialLcd::responseSignal
      IL_00d6:  ldc.i4     0xfa
      IL_00db:  call       bool [mscorlib]System.Threading.Monitor::Wait(object,
                                                                         int32)
      IL_00e0:  ldc.i4.0
      IL_00e1:  ceq
      IL_00e3:  stloc.3
      IL_00e4:  ldloc.3
      IL_00e5:  brtrue.s   IL_00f0

      IL_00e7:  ldarg.0
      IL_00e8:  ldfld      class Microsoft.Samples.SpaceInvaders.LcdPacket Microsoft.Samples.SpaceInvaders.SerialLcd::responsePacket
      IL_00ed:  stloc.2
      IL_00ee:  leave.s    IL_0108

      IL_00f0:  nop
      IL_00f1:  br.s       IL_00f7

      IL_00f3:  ldnull
      IL_00f4:  stloc.2
      IL_00f5:  leave.s    IL_0108

      IL_00f7:  nop
      IL_00f8:  leave.s    IL_0103

    }  // end .try
    finally
    {
      IL_00fa:  ldloc.s    CS$2$0002
      IL_00fc:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0101:  nop
      IL_0102:  endfinally
    }  // end handler
    IL_0103:  nop
    IL_0104:  ldnull
    IL_0105:  stloc.2
    IL_0106:  br.s       IL_0108

    IL_0108:  nop
    IL_0109:  ldloc.2
    IL_010a:  ret
  } // end of method SerialLcd::Send

  .method private hidebysig instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> 
          SendReturnData(uint8 'type',
                         uint8 dataLength,
                         class [mscorlib]System.Collections.Generic.'List`1'<uint8> data) cil managed
  {
    // Code size       33 (0x21)
    .maxstack  4
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.LcdPacket packet,
             [1] class [mscorlib]System.Collections.Generic.'List`1'<uint8> CS$1$0000,
             [2] bool CS$4$0001)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  ldarg.3
    IL_0004:  call       instance class Microsoft.Samples.SpaceInvaders.LcdPacket Microsoft.Samples.SpaceInvaders.SerialLcd::Send(uint8,
                                                                                                                                  uint8,
                                                                                                                                  class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_0009:  stloc.0
    IL_000a:  ldnull
    IL_000b:  ldloc.0
    IL_000c:  ceq
    IL_000e:  stloc.2
    IL_000f:  ldloc.2
    IL_0010:  brtrue.s   IL_001b

    IL_0012:  ldloc.0
    IL_0013:  callvirt   instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> Microsoft.Samples.SpaceInvaders.LcdPacket::get_Data()
    IL_0018:  stloc.1
    IL_0019:  br.s       IL_001f

    IL_001b:  ldnull
    IL_001c:  stloc.1
    IL_001d:  br.s       IL_001f

    IL_001f:  ldloc.1
    IL_0020:  ret
  } // end of method SerialLcd::SendReturnData

  .method private hidebysig instance bool 
          SendReturnBool(uint8 'type',
                         uint8 dataLength,
                         class [mscorlib]System.Collections.Generic.'List`1'<uint8> data) cil managed
  {
    // Code size       56 (0x38)
    .maxstack  4
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.LcdPacket packet,
             [1] bool CS$1$0000,
             [2] bool CS$4$0001)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  ldarg.3
    IL_0004:  call       instance class Microsoft.Samples.SpaceInvaders.LcdPacket Microsoft.Samples.SpaceInvaders.SerialLcd::Send(uint8,
                                                                                                                                  uint8,
                                                                                                                                  class [mscorlib]System.Collections.Generic.'List`1'<uint8>)
    IL_0009:  stloc.0
    IL_000a:  ldnull
    IL_000b:  ldloc.0
    IL_000c:  ceq
    IL_000e:  stloc.2
    IL_000f:  ldloc.2
    IL_0010:  brtrue.s   IL_0032

    IL_0012:  ldarg.1
    IL_0013:  ldloc.0
    IL_0014:  callvirt   instance uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::get_Type()
    IL_0019:  ldc.i4.s   15
    IL_001b:  and
    IL_001c:  bne.un.s   IL_002e

    IL_001e:  ldc.i4.0
    IL_001f:  ldarg.0
    IL_0020:  ldfld      class Microsoft.Samples.SpaceInvaders.LcdPacket Microsoft.Samples.SpaceInvaders.SerialLcd::responsePacket
    IL_0025:  callvirt   instance valuetype Microsoft.Samples.SpaceInvaders.LcdPacket/LcdPacketType Microsoft.Samples.SpaceInvaders.LcdPacket::get_PacketType()
    IL_002a:  ceq
    IL_002c:  br.s       IL_002f

    IL_002e:  ldc.i4.0
    IL_002f:  stloc.1
    IL_0030:  br.s       IL_0036

    IL_0032:  ldc.i4.0
    IL_0033:  stloc.1
    IL_0034:  br.s       IL_0036

    IL_0036:  ldloc.1
    IL_0037:  ret
  } // end of method SerialLcd::SendReturnBool

  .method private hidebysig instance void 
          Receive() cil managed
  {
    // Code size       221 (0xdd)
    .maxstack  5
    .locals init ([0] uint8[] receiveBuffer,
             [1] int32 bytesRead,
             [2] int32 bufferIndex,
             [3] int32 startPacketIndex,
             [4] int32 expectedPacketLength,
             [5] bool expectedPacketLengthIsSet,
             [6] int32 numBytesToRead,
             [7] bool CS$4$0000)
    IL_0000:  ldc.i4     0x80
    IL_0005:  newarr     [mscorlib]System.Byte
    IL_000a:  stloc.0
    IL_000b:  ldc.i4.0
    IL_000c:  stloc.1
    IL_000d:  ldc.i4.0
    IL_000e:  stloc.2
    IL_000f:  ldc.i4.0
    IL_0010:  stloc.3
    IL_0011:  ldc.i4.m1
    IL_0012:  stloc.s    expectedPacketLength
    IL_0014:  ldc.i4.0
    IL_0015:  stloc.s    expectedPacketLengthIsSet
    IL_0017:  ldloc.0
    IL_0018:  ldlen
    IL_0019:  conv.i4
    IL_001a:  stloc.s    numBytesToRead
    IL_001c:  br         IL_00d3

    IL_0021:  ldloc.s    expectedPacketLengthIsSet
    IL_0023:  brtrue.s   IL_002b

    IL_0025:  ldc.i4.1
    IL_0026:  ldloc.1
    IL_0027:  clt
    IL_0029:  br.s       IL_002c

    IL_002b:  ldc.i4.0
    IL_002c:  stloc.s    CS$4$0000
    IL_002e:  ldloc.s    CS$4$0000
    IL_0030:  brtrue.s   IL_0053

    .try
    {
      IL_0032:  ldloc.1
      IL_0033:  ldarg.0
      IL_0034:  ldfld      class [System]System.IO.Ports.SerialPort Microsoft.Samples.SpaceInvaders.SerialLcd::com
      IL_0039:  ldloc.0
      IL_003a:  ldloc.2
      IL_003b:  ldloc.s    numBytesToRead
      IL_003d:  callvirt   instance int32 [System]System.IO.Ports.SerialPort::Read(uint8[],
                                                                                   int32,
                                                                                   int32)
      IL_0042:  add
      IL_0043:  stloc.1
      IL_0044:  ldloc.3
      IL_0045:  ldloc.1
      IL_0046:  add
      IL_0047:  stloc.2
      IL_0048:  nop
      IL_0049:  leave.s    IL_0051

    }  // end .try
    catch [mscorlib]System.IO.IOException 
    {
      IL_004b:  pop
      IL_004c:  leave      IL_00db

    }  // end handler
    IL_0051:  nop
    IL_0052:  nop
    IL_0053:  ldc.i4.1
    IL_0054:  ldloc.1
    IL_0055:  clt
    IL_0057:  ldc.i4.0
    IL_0058:  ceq
    IL_005a:  stloc.s    CS$4$0000
    IL_005c:  ldloc.s    CS$4$0000
    IL_005e:  brtrue.s   IL_00bc

    IL_0060:  ldloc.s    expectedPacketLengthIsSet
    IL_0062:  stloc.s    CS$4$0000
    IL_0064:  ldloc.s    CS$4$0000
    IL_0066:  brtrue.s   IL_0079

    IL_0068:  ldloc.0
    IL_0069:  ldc.i4.1
    IL_006a:  ldloc.3
    IL_006b:  add
    IL_006c:  ldloc.0
    IL_006d:  ldlen
    IL_006e:  conv.i4
    IL_006f:  rem
    IL_0070:  ldelem.u1
    IL_0071:  ldc.i4.4
    IL_0072:  add
    IL_0073:  stloc.s    expectedPacketLength
    IL_0075:  ldc.i4.1
    IL_0076:  stloc.s    expectedPacketLengthIsSet
    IL_0078:  nop
    IL_0079:  ldloc.1
    IL_007a:  ldloc.s    expectedPacketLength
    IL_007c:  clt
    IL_007e:  stloc.s    CS$4$0000
    IL_0080:  ldloc.s    CS$4$0000
    IL_0082:  brtrue.s   IL_00bb

    IL_0084:  ldarg.0
    IL_0085:  ldloc.0
    IL_0086:  ldloc.3
    IL_0087:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::AddPacket(uint8[],
                                                                                            int32)
    IL_008c:  pop
    IL_008d:  ldc.i4.0
    IL_008e:  stloc.s    expectedPacketLengthIsSet
    IL_0090:  ldloc.1
    IL_0091:  ldloc.s    expectedPacketLength
    IL_0093:  ceq
    IL_0095:  ldc.i4.0
    IL_0096:  ceq
    IL_0098:  stloc.s    CS$4$0000
    IL_009a:  ldloc.s    CS$4$0000
    IL_009c:  brtrue.s   IL_00a5

    IL_009e:  ldc.i4.0
    IL_009f:  stloc.1
    IL_00a0:  ldloc.3
    IL_00a1:  stloc.2
    IL_00a2:  nop
    IL_00a3:  br.s       IL_00ba

    IL_00a5:  ldloc.3
    IL_00a6:  ldloc.s    expectedPacketLength
    IL_00a8:  add
    IL_00a9:  stloc.3
    IL_00aa:  ldloc.3
    IL_00ab:  ldloc.0
    IL_00ac:  ldlen
    IL_00ad:  conv.i4
    IL_00ae:  rem
    IL_00af:  stloc.3
    IL_00b0:  ldloc.1
    IL_00b1:  ldloc.s    expectedPacketLength
    IL_00b3:  sub
    IL_00b4:  stloc.1
    IL_00b5:  ldloc.3
    IL_00b6:  ldloc.1
    IL_00b7:  add
    IL_00b8:  stloc.2
    IL_00b9:  nop
    IL_00ba:  nop
    IL_00bb:  nop
    IL_00bc:  ldloc.2
    IL_00bd:  ldloc.0
    IL_00be:  ldlen
    IL_00bf:  conv.i4
    IL_00c0:  rem
    IL_00c1:  stloc.2
    IL_00c2:  ldloc.2
    IL_00c3:  ldloc.3
    IL_00c4:  blt.s      IL_00cd

    IL_00c6:  ldloc.0
    IL_00c7:  ldlen
    IL_00c8:  conv.i4
    IL_00c9:  ldloc.2
    IL_00ca:  sub
    IL_00cb:  br.s       IL_00d0

    IL_00cd:  ldloc.3
    IL_00ce:  ldloc.2
    IL_00cf:  sub
    IL_00d0:  stloc.s    numBytesToRead
    IL_00d2:  nop
    IL_00d3:  ldc.i4.1
    IL_00d4:  stloc.s    CS$4$0000
    IL_00d6:  br         IL_0021

    IL_00db:  nop
    IL_00dc:  ret
  } // end of method SerialLcd::Receive

  .method private hidebysig instance void 
          ReportEventHandler() cil managed
  {
    // Code size       123 (0x7b)
    .maxstack  2
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.LcdPacket packet,
             [1] object CS$2$0000,
             [2] bool CS$4$0001,
             [3] uint8 CS$4$0002,
             [4] uint8 CS$0$0003)
    IL_0000:  ldnull
    IL_0001:  stloc.0
    IL_0002:  br.s       IL_0077

    IL_0004:  br.s       IL_004d

    IL_0006:  ldarg.0
    IL_0007:  ldfld      object Microsoft.Samples.SpaceInvaders.SerialLcd::reportSignal
    IL_000c:  dup
    IL_000d:  stloc.1
    IL_000e:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0013:  nop
    .try
    {
      IL_0014:  ldc.i4.0
      IL_0015:  ldarg.0
      IL_0016:  ldfld      class [System]System.Collections.Generic.'Queue`1'<class Microsoft.Samples.SpaceInvaders.LcdPacket> Microsoft.Samples.SpaceInvaders.SerialLcd::reportQueue
      IL_001b:  callvirt   instance int32 class [System]System.Collections.Generic.'Queue`1'<class Microsoft.Samples.SpaceInvaders.LcdPacket>::get_Count()
      IL_0020:  ceq
      IL_0022:  stloc.2
      IL_0023:  ldloc.2
      IL_0024:  brtrue.s   IL_0034

      IL_0026:  ldarg.0
      IL_0027:  ldfld      class [System]System.Collections.Generic.'Queue`1'<class Microsoft.Samples.SpaceInvaders.LcdPacket> Microsoft.Samples.SpaceInvaders.SerialLcd::reportQueue
      IL_002c:  callvirt   instance !0 class [System]System.Collections.Generic.'Queue`1'<class Microsoft.Samples.SpaceInvaders.LcdPacket>::Dequeue()
      IL_0031:  stloc.0
      IL_0032:  br.s       IL_0040

      IL_0034:  ldarg.0
      IL_0035:  ldfld      object Microsoft.Samples.SpaceInvaders.SerialLcd::reportSignal
      IL_003a:  call       bool [mscorlib]System.Threading.Monitor::Wait(object)
      IL_003f:  pop
      IL_0040:  nop
      IL_0041:  leave.s    IL_004b

    }  // end .try
    finally
    {
      IL_0043:  ldloc.1
      IL_0044:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0049:  nop
      IL_004a:  endfinally
    }  // end handler
    IL_004b:  nop
    IL_004c:  nop
    IL_004d:  ldnull
    IL_004e:  ldloc.0
    IL_004f:  ceq
    IL_0051:  stloc.2
    IL_0052:  ldloc.2
    IL_0053:  brtrue.s   IL_0006

    IL_0055:  ldloc.0
    IL_0056:  callvirt   instance uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::get_Type()
    IL_005b:  stloc.3
    IL_005c:  ldloc.3
    IL_005d:  stloc.s    CS$0$0003
    IL_005f:  ldloc.s    CS$0$0003
    IL_0061:  ldc.i4     0x80
    IL_0066:  beq.s      IL_006a

    IL_0068:  br.s       IL_0074

    IL_006a:  ldarg.0
    IL_006b:  ldloc.0
    IL_006c:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::ReportKeyActivityEventHandler(class Microsoft.Samples.SpaceInvaders.LcdPacket)
    IL_0071:  nop
    IL_0072:  br.s       IL_0074

    IL_0074:  ldnull
    IL_0075:  stloc.0
    IL_0076:  nop
    IL_0077:  ldc.i4.1
    IL_0078:  stloc.2
    IL_0079:  br.s       IL_0004
  } // end of method SerialLcd::ReportEventHandler

  .method public hidebysig specialname instance valuetype Microsoft.Samples.SpaceInvaders.LcdKey 
          get_Key() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] valuetype Microsoft.Samples.SpaceInvaders.LcdKey CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      valuetype Microsoft.Samples.SpaceInvaders.LcdKey Microsoft.Samples.SpaceInvaders.SerialLcd::_key
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method SerialLcd::get_Key

  .method public hidebysig specialname instance void 
          set_Key(valuetype Microsoft.Samples.SpaceInvaders.LcdKey 'value') cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      valuetype Microsoft.Samples.SpaceInvaders.LcdKey Microsoft.Samples.SpaceInvaders.SerialLcd::_key
    IL_0007:  ret
  } // end of method SerialLcd::set_Key

  .method private hidebysig instance void 
          ReportKeyActivityEventHandler(class Microsoft.Samples.SpaceInvaders.LcdPacket packet) cil managed
  {
    // Code size       317 (0x13d)
    .maxstack  2
    .locals init ([0] bool CS$4$0000,
             [1] uint8 CS$4$0001,
             [2] uint8 CS$0$0002)
    IL_0000:  ldc.i4.1
    IL_0001:  ldarg.1
    IL_0002:  callvirt   instance uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::get_DataLength()
    IL_0007:  ceq
    IL_0009:  stloc.0
    IL_000a:  ldloc.0
    IL_000b:  brtrue.s   IL_0012

    IL_000d:  br         IL_013c

    IL_0012:  ldarg.1
    IL_0013:  callvirt   instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> Microsoft.Samples.SpaceInvaders.LcdPacket::get_Data()
    IL_0018:  ldc.i4.0
    IL_0019:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<uint8>::get_Item(int32)
    IL_001e:  stloc.1
    IL_001f:  ldloc.1
    IL_0020:  stloc.2
    IL_0021:  ldloc.2
    IL_0022:  ldc.i4.1
    IL_0023:  sub
    IL_0024:  switch     ( 
                          IL_005e,
                          IL_006a,
                          IL_0076,
                          IL_0082,
                          IL_008e,
                          IL_009a,
                          IL_00a6,
                          IL_00bf,
                          IL_00d8,
                          IL_00f1,
                          IL_010a,
                          IL_0123)
    IL_0059:  br         IL_013c

    IL_005e:  ldarg.0
    IL_005f:  ldc.i4.1
    IL_0060:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::set_Key(valuetype Microsoft.Samples.SpaceInvaders.LcdKey)
    IL_0065:  br         IL_013c

    IL_006a:  ldarg.0
    IL_006b:  ldc.i4.2
    IL_006c:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::set_Key(valuetype Microsoft.Samples.SpaceInvaders.LcdKey)
    IL_0071:  br         IL_013c

    IL_0076:  ldarg.0
    IL_0077:  ldc.i4.3
    IL_0078:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::set_Key(valuetype Microsoft.Samples.SpaceInvaders.LcdKey)
    IL_007d:  br         IL_013c

    IL_0082:  ldarg.0
    IL_0083:  ldc.i4.4
    IL_0084:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::set_Key(valuetype Microsoft.Samples.SpaceInvaders.LcdKey)
    IL_0089:  br         IL_013c

    IL_008e:  ldarg.0
    IL_008f:  ldc.i4.5
    IL_0090:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::set_Key(valuetype Microsoft.Samples.SpaceInvaders.LcdKey)
    IL_0095:  br         IL_013c

    IL_009a:  ldarg.0
    IL_009b:  ldc.i4.6
    IL_009c:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::set_Key(valuetype Microsoft.Samples.SpaceInvaders.LcdKey)
    IL_00a1:  br         IL_013c

    IL_00a6:  ldarg.0
    IL_00a7:  call       instance valuetype Microsoft.Samples.SpaceInvaders.LcdKey Microsoft.Samples.SpaceInvaders.SerialLcd::get_Key()
    IL_00ac:  ldc.i4.1
    IL_00ad:  ceq
    IL_00af:  ldc.i4.0
    IL_00b0:  ceq
    IL_00b2:  stloc.0
    IL_00b3:  ldloc.0
    IL_00b4:  brtrue.s   IL_00bd

    IL_00b6:  ldarg.0
    IL_00b7:  ldc.i4.0
    IL_00b8:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::set_Key(valuetype Microsoft.Samples.SpaceInvaders.LcdKey)
    IL_00bd:  br.s       IL_013c

    IL_00bf:  ldarg.0
    IL_00c0:  call       instance valuetype Microsoft.Samples.SpaceInvaders.LcdKey Microsoft.Samples.SpaceInvaders.SerialLcd::get_Key()
    IL_00c5:  ldc.i4.2
    IL_00c6:  ceq
    IL_00c8:  ldc.i4.0
    IL_00c9:  ceq
    IL_00cb:  stloc.0
    IL_00cc:  ldloc.0
    IL_00cd:  brtrue.s   IL_00d6

    IL_00cf:  ldarg.0
    IL_00d0:  ldc.i4.0
    IL_00d1:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::set_Key(valuetype Microsoft.Samples.SpaceInvaders.LcdKey)
    IL_00d6:  br.s       IL_013c

    IL_00d8:  ldarg.0
    IL_00d9:  call       instance valuetype Microsoft.Samples.SpaceInvaders.LcdKey Microsoft.Samples.SpaceInvaders.SerialLcd::get_Key()
    IL_00de:  ldc.i4.3
    IL_00df:  ceq
    IL_00e1:  ldc.i4.0
    IL_00e2:  ceq
    IL_00e4:  stloc.0
    IL_00e5:  ldloc.0
    IL_00e6:  brtrue.s   IL_00ef

    IL_00e8:  ldarg.0
    IL_00e9:  ldc.i4.0
    IL_00ea:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::set_Key(valuetype Microsoft.Samples.SpaceInvaders.LcdKey)
    IL_00ef:  br.s       IL_013c

    IL_00f1:  ldarg.0
    IL_00f2:  call       instance valuetype Microsoft.Samples.SpaceInvaders.LcdKey Microsoft.Samples.SpaceInvaders.SerialLcd::get_Key()
    IL_00f7:  ldc.i4.4
    IL_00f8:  ceq
    IL_00fa:  ldc.i4.0
    IL_00fb:  ceq
    IL_00fd:  stloc.0
    IL_00fe:  ldloc.0
    IL_00ff:  brtrue.s   IL_0108

    IL_0101:  ldarg.0
    IL_0102:  ldc.i4.0
    IL_0103:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::set_Key(valuetype Microsoft.Samples.SpaceInvaders.LcdKey)
    IL_0108:  br.s       IL_013c

    IL_010a:  ldarg.0
    IL_010b:  call       instance valuetype Microsoft.Samples.SpaceInvaders.LcdKey Microsoft.Samples.SpaceInvaders.SerialLcd::get_Key()
    IL_0110:  ldc.i4.5
    IL_0111:  ceq
    IL_0113:  ldc.i4.0
    IL_0114:  ceq
    IL_0116:  stloc.0
    IL_0117:  ldloc.0
    IL_0118:  brtrue.s   IL_0121

    IL_011a:  ldarg.0
    IL_011b:  ldc.i4.0
    IL_011c:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::set_Key(valuetype Microsoft.Samples.SpaceInvaders.LcdKey)
    IL_0121:  br.s       IL_013c

    IL_0123:  ldarg.0
    IL_0124:  call       instance valuetype Microsoft.Samples.SpaceInvaders.LcdKey Microsoft.Samples.SpaceInvaders.SerialLcd::get_Key()
    IL_0129:  ldc.i4.5
    IL_012a:  ceq
    IL_012c:  ldc.i4.0
    IL_012d:  ceq
    IL_012f:  stloc.0
    IL_0130:  ldloc.0
    IL_0131:  brtrue.s   IL_013a

    IL_0133:  ldarg.0
    IL_0134:  ldc.i4.0
    IL_0135:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::set_Key(valuetype Microsoft.Samples.SpaceInvaders.LcdKey)
    IL_013a:  br.s       IL_013c

    IL_013c:  ret
  } // end of method SerialLcd::ReportKeyActivityEventHandler

  .method private hidebysig instance void 
          ReportKeyActivityEventHandler(class Microsoft.Samples.SpaceInvaders.SerialLcd/KeyActivityEventHandler keyActivityEventHandler) cil managed
  {
    // Code size       26 (0x1a)
    .maxstack  3
    .locals init ([0] bool CS$4$0000)
    .try
    {
      IL_0000:  ldnull
      IL_0001:  ldarg.1
      IL_0002:  ceq
      IL_0004:  stloc.0
      IL_0005:  ldloc.0
      IL_0006:  brtrue.s   IL_0011

      IL_0008:  ldarg.1
      IL_0009:  ldarg.0
      IL_000a:  ldnull
      IL_000b:  callvirt   instance class [mscorlib]System.'EventHandler`1'<class [mscorlib]System.EventArgs> Microsoft.Samples.SpaceInvaders.SerialLcd/KeyActivityEventHandler::Invoke(object,
                                                                                                                                                                                        class [mscorlib]System.EventArgs)
      IL_0010:  pop
      IL_0011:  nop
      IL_0012:  leave.s    IL_0018

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_0014:  pop
      IL_0015:  nop
      IL_0016:  leave.s    IL_0018

    }  // end handler
    IL_0018:  nop
    IL_0019:  ret
  } // end of method SerialLcd::ReportKeyActivityEventHandler

  .method private hidebysig instance class Microsoft.Samples.SpaceInvaders.LcdPacket 
          CreatePacket(uint8[] buffer,
                       int32 startIndex) cil managed
  {
    // Code size       115 (0x73)
    .maxstack  5
    .locals init ([0] uint8 'type',
             [1] uint8 dataLength,
             [2] class [mscorlib]System.Collections.Generic.'List`1'<uint8> data,
             [3] uint16 _cyclicRedundancyCheck,
             [4] int32 i,
             [5] class Microsoft.Samples.SpaceInvaders.LcdPacket CS$1$0000,
             [6] bool CS$4$0001)
    IL_0000:  ldarg.1
    IL_0001:  ldarg.2
    IL_0002:  ldelem.u1
    IL_0003:  stloc.0
    IL_0004:  ldarg.1
    IL_0005:  ldarg.2
    IL_0006:  ldc.i4.1
    IL_0007:  add
    IL_0008:  ldarg.1
    IL_0009:  ldlen
    IL_000a:  conv.i4
    IL_000b:  rem
    IL_000c:  ldelem.u1
    IL_000d:  stloc.1
    IL_000e:  newobj     instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::.ctor()
    IL_0013:  stloc.2
    IL_0014:  ldc.i4.0
    IL_0015:  stloc.3
    IL_0016:  ldc.i4.0
    IL_0017:  stloc.s    i
    IL_0019:  br.s       IL_0035

    IL_001b:  ldloc.2
    IL_001c:  ldarg.1
    IL_001d:  ldarg.2
    IL_001e:  ldc.i4.2
    IL_001f:  add
    IL_0020:  ldloc.s    i
    IL_0022:  add
    IL_0023:  ldarg.1
    IL_0024:  ldlen
    IL_0025:  conv.i4
    IL_0026:  rem
    IL_0027:  ldelem.u1
    IL_0028:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<uint8>::Add(!0)
    IL_002d:  nop
    IL_002e:  nop
    IL_002f:  ldloc.s    i
    IL_0031:  ldc.i4.1
    IL_0032:  add
    IL_0033:  stloc.s    i
    IL_0035:  ldloc.s    i
    IL_0037:  ldloc.1
    IL_0038:  clt
    IL_003a:  stloc.s    CS$4$0001
    IL_003c:  ldloc.s    CS$4$0001
    IL_003e:  brtrue.s   IL_001b

    IL_0040:  ldloc.3
    IL_0041:  ldarg.1
    IL_0042:  ldarg.2
    IL_0043:  ldc.i4.2
    IL_0044:  add
    IL_0045:  ldloc.1
    IL_0046:  add
    IL_0047:  ldarg.1
    IL_0048:  ldlen
    IL_0049:  conv.i4
    IL_004a:  rem
    IL_004b:  ldelem.u1
    IL_004c:  or
    IL_004d:  conv.u2
    IL_004e:  stloc.3
    IL_004f:  ldloc.3
    IL_0050:  ldarg.1
    IL_0051:  ldarg.2
    IL_0052:  ldc.i4.2
    IL_0053:  add
    IL_0054:  ldloc.1
    IL_0055:  add
    IL_0056:  ldc.i4.1
    IL_0057:  add
    IL_0058:  ldarg.1
    IL_0059:  ldlen
    IL_005a:  conv.i4
    IL_005b:  rem
    IL_005c:  ldelem.u1
    IL_005d:  ldc.i4.8
    IL_005e:  shl
    IL_005f:  conv.u2
    IL_0060:  or
    IL_0061:  conv.u2
    IL_0062:  stloc.3
    IL_0063:  ldloc.0
    IL_0064:  ldloc.1
    IL_0065:  ldloc.2
    IL_0066:  ldloc.3
    IL_0067:  newobj     instance void Microsoft.Samples.SpaceInvaders.LcdPacket::.ctor(uint8,
                                                                                        uint8,
                                                                                        class [mscorlib]System.Collections.Generic.'List`1'<uint8>,
                                                                                        uint16)
    IL_006c:  stloc.s    CS$1$0000
    IL_006e:  br.s       IL_0070

    IL_0070:  ldloc.s    CS$1$0000
    IL_0072:  ret
  } // end of method SerialLcd::CreatePacket

  .method private hidebysig instance bool 
          AddPacket(uint8[] buffer,
                    int32 startIndex) cil managed
  {
    // Code size       152 (0x98)
    .maxstack  4
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.LcdPacket packet,
             [1] uint16 calculatedCyclicRedundancyCheck,
             [2] bool CS$1$0000,
             [3] valuetype Microsoft.Samples.SpaceInvaders.LcdPacket/LcdPacketType CS$4$0001,
             [4] valuetype Microsoft.Samples.SpaceInvaders.LcdPacket/LcdPacketType CS$0$0002,
             [5] bool CS$4$0003)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  call       instance class Microsoft.Samples.SpaceInvaders.LcdPacket Microsoft.Samples.SpaceInvaders.SerialLcd::CreatePacket(uint8[],
                                                                                                                                          int32)
    IL_0008:  stloc.0
    IL_0009:  ldarg.1
    IL_000a:  ldarg.2
    IL_000b:  ldloc.0
    IL_000c:  callvirt   instance uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::get_DataLength()
    IL_0011:  ldc.i4.2
    IL_0012:  add
    IL_0013:  ldarg.0
    IL_0014:  ldfld      uint16 Microsoft.Samples.SpaceInvaders.SerialLcd::CYCLIC_REDUNDANCY_CHECK_SEED
    IL_0019:  call       uint16 Microsoft.Samples.SpaceInvaders.CyclicRedundancyCheckGenerator::GenerateCyclicRedundancyCheck(uint8[],
                                                                                                                              int32,
                                                                                                                              int32,
                                                                                                                              uint16)
    IL_001e:  stloc.1
    IL_001f:  ldloc.0
    IL_0020:  callvirt   instance valuetype Microsoft.Samples.SpaceInvaders.LcdPacket/LcdPacketType Microsoft.Samples.SpaceInvaders.LcdPacket::get_PacketType()
    IL_0025:  stloc.3
    IL_0026:  ldloc.3
    IL_0027:  stloc.s    CS$0$0002
    IL_0029:  ldloc.s    CS$0$0002
    IL_002b:  switch     ( 
                          IL_003e,
                          IL_0048,
                          IL_0052)
    IL_003c:  br.s       IL_005c

    IL_003e:  ldarg.0
    IL_003f:  ldloc.0
    IL_0040:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::AddResponsePacket(class Microsoft.Samples.SpaceInvaders.LcdPacket)
    IL_0045:  nop
    IL_0046:  br.s       IL_005c

    IL_0048:  ldarg.0
    IL_0049:  ldloc.0
    IL_004a:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::AddReportPacket(class Microsoft.Samples.SpaceInvaders.LcdPacket)
    IL_004f:  nop
    IL_0050:  br.s       IL_005c

    IL_0052:  ldarg.0
    IL_0053:  ldloc.0
    IL_0054:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::AddResponsePacket(class Microsoft.Samples.SpaceInvaders.LcdPacket)
    IL_0059:  nop
    IL_005a:  br.s       IL_005c

    IL_005c:  ldloc.1
    IL_005d:  ldloc.0
    IL_005e:  callvirt   instance uint16 Microsoft.Samples.SpaceInvaders.LcdPacket::get_CyclicRedundancyCheck()
    IL_0063:  ceq
    IL_0065:  stloc.s    CS$4$0003
    IL_0067:  ldloc.s    CS$4$0003
    IL_0069:  brtrue.s   IL_0092

    IL_006b:  ldstr      "CyclicRedundancyCheck ERROR!!!: Calculated CyclicR"
    + "edundancyCheck={0} Actual CyclicRedundancyCheck={1}"
    IL_0070:  ldloc.1
    IL_0071:  ldc.i4.s   16
    IL_0073:  call       string [mscorlib]System.Convert::ToString(int32,
                                                                   int32)
    IL_0078:  ldloc.0
    IL_0079:  callvirt   instance uint16 Microsoft.Samples.SpaceInvaders.LcdPacket::get_CyclicRedundancyCheck()
    IL_007e:  box        [mscorlib]System.UInt16
    IL_0083:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()
    IL_0088:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                  object,
                                                                  object,
                                                                  object)
    IL_008d:  nop
    IL_008e:  ldc.i4.0
    IL_008f:  stloc.2
    IL_0090:  br.s       IL_0096

    IL_0092:  ldc.i4.1
    IL_0093:  stloc.2
    IL_0094:  br.s       IL_0096

    IL_0096:  ldloc.2
    IL_0097:  ret
  } // end of method SerialLcd::AddPacket

  .method private hidebysig instance void 
          AddResponsePacket(class Microsoft.Samples.SpaceInvaders.LcdPacket packet) cil managed
  {
    // Code size       46 (0x2e)
    .maxstack  2
    .locals init ([0] object CS$2$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      object Microsoft.Samples.SpaceInvaders.SerialLcd::responseSignal
    IL_0006:  dup
    IL_0007:  stloc.0
    IL_0008:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_000d:  nop
    .try
    {
      IL_000e:  ldarg.0
      IL_000f:  ldarg.1
      IL_0010:  stfld      class Microsoft.Samples.SpaceInvaders.LcdPacket Microsoft.Samples.SpaceInvaders.SerialLcd::responsePacket
      IL_0015:  ldarg.0
      IL_0016:  ldfld      object Microsoft.Samples.SpaceInvaders.SerialLcd::responseSignal
      IL_001b:  call       void [mscorlib]System.Threading.Monitor::Pulse(object)
      IL_0020:  nop
      IL_0021:  nop
      IL_0022:  leave.s    IL_002c

    }  // end .try
    finally
    {
      IL_0024:  ldloc.0
      IL_0025:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_002a:  nop
      IL_002b:  endfinally
    }  // end handler
    IL_002c:  nop
    IL_002d:  ret
  } // end of method SerialLcd::AddResponsePacket

  .method private hidebysig instance void 
          AddReportPacket(class Microsoft.Samples.SpaceInvaders.LcdPacket packet) cil managed
  {
    // Code size       52 (0x34)
    .maxstack  2
    .locals init ([0] object CS$2$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      object Microsoft.Samples.SpaceInvaders.SerialLcd::reportSignal
    IL_0006:  dup
    IL_0007:  stloc.0
    IL_0008:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_000d:  nop
    .try
    {
      IL_000e:  ldarg.0
      IL_000f:  ldfld      class [System]System.Collections.Generic.'Queue`1'<class Microsoft.Samples.SpaceInvaders.LcdPacket> Microsoft.Samples.SpaceInvaders.SerialLcd::reportQueue
      IL_0014:  ldarg.1
      IL_0015:  callvirt   instance void class [System]System.Collections.Generic.'Queue`1'<class Microsoft.Samples.SpaceInvaders.LcdPacket>::Enqueue(!0)
      IL_001a:  nop
      IL_001b:  ldarg.0
      IL_001c:  ldfld      object Microsoft.Samples.SpaceInvaders.SerialLcd::reportSignal
      IL_0021:  call       void [mscorlib]System.Threading.Monitor::Pulse(object)
      IL_0026:  nop
      IL_0027:  nop
      IL_0028:  leave.s    IL_0032

    }  // end .try
    finally
    {
      IL_002a:  ldloc.0
      IL_002b:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0030:  nop
      IL_0031:  endfinally
    }  // end handler
    IL_0032:  nop
    IL_0033:  ret
  } // end of method SerialLcd::AddReportPacket

  .method public hidebysig specialname instance bool 
          get_IsOpen() cil managed
  {
    // Code size       36 (0x24)
    .maxstack  2
    .locals init ([0] bool CS$1$0000,
             [1] bool CS$4$0001)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [System]System.IO.Ports.SerialPort Microsoft.Samples.SpaceInvaders.SerialLcd::com
    IL_0006:  ldnull
    IL_0007:  ceq
    IL_0009:  ldc.i4.0
    IL_000a:  ceq
    IL_000c:  stloc.1
    IL_000d:  ldloc.1
    IL_000e:  brtrue.s   IL_0014

    IL_0010:  ldc.i4.0
    IL_0011:  stloc.0
    IL_0012:  br.s       IL_0022

    IL_0014:  ldarg.0
    IL_0015:  ldfld      class [System]System.IO.Ports.SerialPort Microsoft.Samples.SpaceInvaders.SerialLcd::com
    IL_001a:  callvirt   instance bool [System]System.IO.Ports.SerialPort::get_IsOpen()
    IL_001f:  stloc.0
    IL_0020:  br.s       IL_0022

    IL_0022:  ldloc.0
    IL_0023:  ret
  } // end of method SerialLcd::get_IsOpen

  .method public hidebysig instance void 
          Reset() cil managed
  {
    // Code size       25 (0x19)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldstr      "Crystalfontz 633"
    IL_0006:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::WriteLine1(string)
    IL_000b:  pop
    IL_000c:  ldarg.0
    IL_000d:  ldstr      "HW v1.2  FW v1.0"
    IL_0012:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::WriteLine2(string)
    IL_0017:  pop
    IL_0018:  ret
  } // end of method SerialLcd::Reset

  .method public hidebysig instance void 
          Open() cil managed
  {
    // Code size       141 (0x8d)
    .maxstack  4
    .locals init ([0] bool CS$4$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [System]System.IO.Ports.SerialPort Microsoft.Samples.SpaceInvaders.SerialLcd::com
    IL_0006:  callvirt   instance bool [System]System.IO.Ports.SerialPort::get_IsOpen()
    IL_000b:  stloc.0
    IL_000c:  ldloc.0
    IL_000d:  brtrue.s   IL_008c

    IL_000f:  ldarg.0
    IL_0010:  ldfld      class [System]System.IO.Ports.SerialPort Microsoft.Samples.SpaceInvaders.SerialLcd::com
    IL_0015:  callvirt   instance void [System]System.IO.Ports.SerialPort::Open()
    IL_001a:  nop
    IL_001b:  ldarg.0
    IL_001c:  ldc.i4.s   15
    IL_001e:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SetLcdContrast(int32)
    IL_0023:  pop
    IL_0024:  ldarg.0
    IL_0025:  ldc.i4.s   100
    IL_0027:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::SetLcdBacklight(int32)
    IL_002c:  pop
    IL_002d:  ldarg.0
    IL_002e:  ldstr      "Ready..."
    IL_0033:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::WriteLine1(string)
    IL_0038:  pop
    IL_0039:  ldarg.0
    IL_003a:  ldstr      ""
    IL_003f:  call       instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::WriteLine2(string)
    IL_0044:  pop
    IL_0045:  ldarg.0
    IL_0046:  ldarg.0
    IL_0047:  ldftn      instance void Microsoft.Samples.SpaceInvaders.SerialLcd::ReportEventHandler()
    IL_004d:  newobj     instance void [mscorlib]System.Threading.ThreadStart::.ctor(object,
                                                                                     native int)
    IL_0052:  newobj     instance void [mscorlib]System.Threading.Thread::.ctor(class [mscorlib]System.Threading.ThreadStart)
    IL_0057:  stfld      class [mscorlib]System.Threading.Thread Microsoft.Samples.SpaceInvaders.SerialLcd::eventThread
    IL_005c:  ldarg.0
    IL_005d:  ldfld      class [mscorlib]System.Threading.Thread Microsoft.Samples.SpaceInvaders.SerialLcd::eventThread
    IL_0062:  callvirt   instance void [mscorlib]System.Threading.Thread::Start()
    IL_0067:  nop
    IL_0068:  ldarg.0
    IL_0069:  ldarg.0
    IL_006a:  ldftn      instance void Microsoft.Samples.SpaceInvaders.SerialLcd::Receive()
    IL_0070:  newobj     instance void [mscorlib]System.Threading.ThreadStart::.ctor(object,
                                                                                     native int)
    IL_0075:  newobj     instance void [mscorlib]System.Threading.Thread::.ctor(class [mscorlib]System.Threading.ThreadStart)
    IL_007a:  stfld      class [mscorlib]System.Threading.Thread Microsoft.Samples.SpaceInvaders.SerialLcd::receiveThread
    IL_007f:  ldarg.0
    IL_0080:  ldfld      class [mscorlib]System.Threading.Thread Microsoft.Samples.SpaceInvaders.SerialLcd::receiveThread
    IL_0085:  callvirt   instance void [mscorlib]System.Threading.Thread::Start()
    IL_008a:  nop
    IL_008b:  nop
    IL_008c:  ret
  } // end of method SerialLcd::Open

  .method public hidebysig instance void 
          Close() cil managed
  {
    // Code size       63 (0x3f)
    .maxstack  2
    .locals init ([0] bool CS$4$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [System]System.IO.Ports.SerialPort Microsoft.Samples.SpaceInvaders.SerialLcd::com
    IL_0006:  callvirt   instance bool [System]System.IO.Ports.SerialPort::get_IsOpen()
    IL_000b:  ldc.i4.0
    IL_000c:  ceq
    IL_000e:  stloc.0
    IL_000f:  ldloc.0
    IL_0010:  brtrue.s   IL_003e

    IL_0012:  ldarg.0
    IL_0013:  call       instance void Microsoft.Samples.SpaceInvaders.SerialLcd::Reset()
    IL_0018:  nop
    IL_0019:  ldarg.0
    IL_001a:  ldfld      class [System]System.IO.Ports.SerialPort Microsoft.Samples.SpaceInvaders.SerialLcd::com
    IL_001f:  callvirt   instance void [System]System.IO.Ports.SerialPort::Close()
    IL_0024:  nop
    IL_0025:  ldarg.0
    IL_0026:  ldfld      class [mscorlib]System.Threading.Thread Microsoft.Samples.SpaceInvaders.SerialLcd::receiveThread
    IL_002b:  callvirt   instance void [mscorlib]System.Threading.Thread::Abort()
    IL_0030:  nop
    IL_0031:  ldarg.0
    IL_0032:  ldfld      class [mscorlib]System.Threading.Thread Microsoft.Samples.SpaceInvaders.SerialLcd::eventThread
    IL_0037:  callvirt   instance void [mscorlib]System.Threading.Thread::Abort()
    IL_003c:  nop
    IL_003d:  nop
    IL_003e:  ret
  } // end of method SerialLcd::Close

  .property instance class [mscorlib]System.Collections.Generic.'List`1'<uint8>
          GetHardwareFirmwareVersion()
  {
    .get instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> Microsoft.Samples.SpaceInvaders.SerialLcd::get_GetHardwareFirmwareVersion()
  } // end of property SerialLcd::GetHardwareFirmwareVersion
  .property instance class [mscorlib]System.Collections.Generic.'List`1'<uint8>
          GetLastFanPulse()
  {
    .get instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> Microsoft.Samples.SpaceInvaders.SerialLcd::get_GetLastFanPulse()
  } // end of property SerialLcd::GetLastFanPulse
  .property instance valuetype Microsoft.Samples.SpaceInvaders.LcdKey
          Key()
  {
    .get instance valuetype Microsoft.Samples.SpaceInvaders.LcdKey Microsoft.Samples.SpaceInvaders.SerialLcd::get_Key()
    .set instance void Microsoft.Samples.SpaceInvaders.SerialLcd::set_Key(valuetype Microsoft.Samples.SpaceInvaders.LcdKey)
  } // end of property SerialLcd::Key
  .property instance bool IsOpen()
  {
    .get instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::get_IsOpen()
  } // end of property SerialLcd::IsOpen
} // end of class Microsoft.Samples.SpaceInvaders.SerialLcd

.class public auto ansi beforefieldinit Microsoft.Samples.SpaceInvaders.LcdPacket
       extends [mscorlib]System.Object
{
  .custom instance void [mscorlib]System.CLSCompliantAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .class auto ansi sealed nested public LcdPacketType
         extends [mscorlib]System.Enum
  {
    .field public specialname rtspecialname int32 value__
    .field public static literal valuetype Microsoft.Samples.SpaceInvaders.LcdPacket/LcdPacketType NormalResponse = int32(0x00000000)
    .field public static literal valuetype Microsoft.Samples.SpaceInvaders.LcdPacket/LcdPacketType NormalReport = int32(0x00000001)
    .field public static literal valuetype Microsoft.Samples.SpaceInvaders.LcdPacket/LcdPacketType ErrorResponse = int32(0x00000002)
  } // end of class LcdPacketType

  .field private static literal uint8 NORMAL_RESPONSE = uint8(0x40)
  .field private static literal uint8 NORMAL_REPORT = uint8(0x80)
  .field private static literal uint8 ERROR_RESPONSE = uint8(0xC0)
  .field private uint8 'type'
  .field private uint8 dataLength
  .field private class [mscorlib]System.Collections.Generic.'List`1'<uint8> data
  .field private uint16 _cyclicRedundancyCheck
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(uint8 'type',
                               uint8 dataLength,
                               class [mscorlib]System.Collections.Generic.'List`1'<uint8> data) cil managed
  {
    // Code size       30 (0x1e)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldarg.1
    IL_0009:  stfld      uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::'type'
    IL_000e:  ldarg.0
    IL_000f:  ldarg.2
    IL_0010:  stfld      uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::dataLength
    IL_0015:  ldarg.0
    IL_0016:  ldarg.3
    IL_0017:  stfld      class [mscorlib]System.Collections.Generic.'List`1'<uint8> Microsoft.Samples.SpaceInvaders.LcdPacket::data
    IL_001c:  nop
    IL_001d:  ret
  } // end of method LcdPacket::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(uint8 'type',
                               uint8 dataLength,
                               class [mscorlib]System.Collections.Generic.'List`1'<uint8> data,
                               uint16 cyclicRedundancyCheckValue) cil managed
  {
    // Code size       38 (0x26)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldarg.1
    IL_0009:  stfld      uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::'type'
    IL_000e:  ldarg.0
    IL_000f:  ldarg.2
    IL_0010:  stfld      uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::dataLength
    IL_0015:  ldarg.0
    IL_0016:  ldarg.3
    IL_0017:  stfld      class [mscorlib]System.Collections.Generic.'List`1'<uint8> Microsoft.Samples.SpaceInvaders.LcdPacket::data
    IL_001c:  ldarg.0
    IL_001d:  ldarg.s    cyclicRedundancyCheckValue
    IL_001f:  stfld      uint16 Microsoft.Samples.SpaceInvaders.LcdPacket::_cyclicRedundancyCheck
    IL_0024:  nop
    IL_0025:  ret
  } // end of method LcdPacket::.ctor

  .method public hidebysig virtual instance string 
          ToString() cil managed
  {
    // Code size       204 (0xcc)
    .maxstack  4
    .locals init ([0] class [mscorlib]System.Text.StringBuilder sb,
             [1] int32 i,
             [2] string CS$1$0000,
             [3] bool CS$4$0001)
    IL_0000:  newobj     instance void [mscorlib]System.Text.StringBuilder::.ctor()
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  ldstr      "Type: "
    IL_000c:  ldarg.0
    IL_000d:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::'type'
    IL_0012:  ldc.i4.s   16
    IL_0014:  call       string [mscorlib]System.Convert::ToString(uint8,
                                                                   int32)
    IL_0019:  ldstr      "\n"
    IL_001e:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0023:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0028:  pop
    IL_0029:  ldloc.0
    IL_002a:  ldstr      "DataLength: "
    IL_002f:  ldarg.0
    IL_0030:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::dataLength
    IL_0035:  ldc.i4.s   16
    IL_0037:  call       string [mscorlib]System.Convert::ToString(uint8,
                                                                   int32)
    IL_003c:  ldstr      "\n"
    IL_0041:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0046:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_004b:  pop
    IL_004c:  ldloc.0
    IL_004d:  ldstr      "Data: "
    IL_0052:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0057:  pop
    IL_0058:  ldc.i4.0
    IL_0059:  stloc.1
    IL_005a:  br.s       IL_0085

    IL_005c:  ldloc.0
    IL_005d:  ldarg.0
    IL_005e:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<uint8> Microsoft.Samples.SpaceInvaders.LcdPacket::data
    IL_0063:  ldloc.1
    IL_0064:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<uint8>::get_Item(int32)
    IL_0069:  ldc.i4.s   16
    IL_006b:  call       string [mscorlib]System.Convert::ToString(uint8,
                                                                   int32)
    IL_0070:  ldstr      ", "
    IL_0075:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_007a:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_007f:  pop
    IL_0080:  nop
    IL_0081:  ldloc.1
    IL_0082:  ldc.i4.1
    IL_0083:  add
    IL_0084:  stloc.1
    IL_0085:  ldloc.1
    IL_0086:  ldarg.0
    IL_0087:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::dataLength
    IL_008c:  clt
    IL_008e:  stloc.3
    IL_008f:  ldloc.3
    IL_0090:  brtrue.s   IL_005c

    IL_0092:  ldloc.0
    IL_0093:  ldstr      "\n"
    IL_0098:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_009d:  pop
    IL_009e:  ldloc.0
    IL_009f:  ldstr      "CyclicRedundancyCheck: "
    IL_00a4:  ldarg.0
    IL_00a5:  ldfld      uint16 Microsoft.Samples.SpaceInvaders.LcdPacket::_cyclicRedundancyCheck
    IL_00aa:  ldc.i4.s   16
    IL_00ac:  call       string [mscorlib]System.Convert::ToString(int32,
                                                                   int32)
    IL_00b1:  ldstr      "\n"
    IL_00b6:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_00bb:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_00c0:  pop
    IL_00c1:  ldloc.0
    IL_00c2:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_00c7:  stloc.2
    IL_00c8:  br.s       IL_00ca

    IL_00ca:  ldloc.2
    IL_00cb:  ret
  } // end of method LcdPacket::ToString

  .method public hidebysig specialname instance uint8 
          get_Type() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] uint8 CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::'type'
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method LcdPacket::get_Type

  .method public hidebysig specialname instance valuetype Microsoft.Samples.SpaceInvaders.LcdPacket/LcdPacketType 
          get_PacketType() cil managed
  {
    // Code size       81 (0x51)
    .maxstack  3
    .locals init ([0] valuetype Microsoft.Samples.SpaceInvaders.LcdPacket/LcdPacketType CS$1$0000,
             [1] int32 CS$4$0001,
             [2] int32 CS$0$0002)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::'type'
    IL_0006:  ldc.i4     0xc0
    IL_000b:  and
    IL_000c:  stloc.1
    IL_000d:  ldloc.1
    IL_000e:  stloc.2
    IL_000f:  ldloc.2
    IL_0010:  ldc.i4.s   64
    IL_0012:  beq.s      IL_0026

    IL_0014:  ldloc.2
    IL_0015:  ldc.i4     0x80
    IL_001a:  beq.s      IL_002a

    IL_001c:  ldloc.2
    IL_001d:  ldc.i4     0xc0
    IL_0022:  beq.s      IL_002e

    IL_0024:  br.s       IL_0032

    IL_0026:  ldc.i4.0
    IL_0027:  stloc.0
    IL_0028:  br.s       IL_004f

    IL_002a:  ldc.i4.1
    IL_002b:  stloc.0
    IL_002c:  br.s       IL_004f

    IL_002e:  ldc.i4.2
    IL_002f:  stloc.0
    IL_0030:  br.s       IL_004f

    IL_0032:  ldstr      "Unexpected Packet Type: "
    IL_0037:  ldarg.0
    IL_0038:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::'type'
    IL_003d:  ldc.i4.s   16
    IL_003f:  call       string [mscorlib]System.Convert::ToString(uint8,
                                                                   int32)
    IL_0044:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_0049:  newobj     instance void [mscorlib]System.Exception::.ctor(string)
    IL_004e:  throw

    IL_004f:  ldloc.0
    IL_0050:  ret
  } // end of method LcdPacket::get_PacketType

  .method public hidebysig specialname instance uint8 
          get_DataLength() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] uint8 CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::dataLength
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method LcdPacket::get_DataLength

  .method public hidebysig specialname instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> 
          get_Data() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] class [mscorlib]System.Collections.Generic.'List`1'<uint8> CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<uint8> Microsoft.Samples.SpaceInvaders.LcdPacket::data
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method LcdPacket::get_Data

  .method public hidebysig specialname instance uint16 
          get_CyclicRedundancyCheck() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] uint16 CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      uint16 Microsoft.Samples.SpaceInvaders.LcdPacket::_cyclicRedundancyCheck
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method LcdPacket::get_CyclicRedundancyCheck

  .property instance uint8 Type()
  {
    .get instance uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::get_Type()
  } // end of property LcdPacket::Type
  .property instance valuetype Microsoft.Samples.SpaceInvaders.LcdPacket/LcdPacketType
          PacketType()
  {
    .get instance valuetype Microsoft.Samples.SpaceInvaders.LcdPacket/LcdPacketType Microsoft.Samples.SpaceInvaders.LcdPacket::get_PacketType()
  } // end of property LcdPacket::PacketType
  .property instance uint8 DataLength()
  {
    .get instance uint8 Microsoft.Samples.SpaceInvaders.LcdPacket::get_DataLength()
  } // end of property LcdPacket::DataLength
  .property instance class [mscorlib]System.Collections.Generic.'List`1'<uint8>
          Data()
  {
    .get instance class [mscorlib]System.Collections.Generic.'List`1'<uint8> Microsoft.Samples.SpaceInvaders.LcdPacket::get_Data()
  } // end of property LcdPacket::Data
  .property instance uint16 CyclicRedundancyCheck()
  {
    .get instance uint16 Microsoft.Samples.SpaceInvaders.LcdPacket::get_CyclicRedundancyCheck()
  } // end of property LcdPacket::CyclicRedundancyCheck
} // end of class Microsoft.Samples.SpaceInvaders.LcdPacket

.class public auto ansi sealed beforefieldinit Microsoft.Samples.SpaceInvaders.CyclicRedundancyCheckGenerator
       extends [mscorlib]System.Object
{
  .custom instance void [mscorlib]System.CLSCompliantAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .field private static uint16[] CyclicRedundancyCheckLookupTable
  .method private hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  nop
    IL_0008:  ret
  } // end of method CyclicRedundancyCheckGenerator::.ctor

  .method public hidebysig static uint16 
          GenerateCyclicRedundancyCheck(uint8[] data,
                                        int32 dataLength,
                                        uint16 seed) cil managed
  {
    // Code size       50 (0x32)
    .maxstack  5
    .locals init ([0] uint16 newCyclicRedundancyCheck,
             [1] int32 i,
             [2] uint16 CS$1$0000,
             [3] bool CS$4$0001)
    IL_0000:  ldarg.2
    IL_0001:  stloc.0
    IL_0002:  ldc.i4.0
    IL_0003:  stloc.1
    IL_0004:  br.s       IL_0022

    IL_0006:  ldloc.0
    IL_0007:  ldc.i4.8
    IL_0008:  shr
    IL_0009:  ldsfld     uint16[] Microsoft.Samples.SpaceInvaders.CyclicRedundancyCheckGenerator::CyclicRedundancyCheckLookupTable
    IL_000e:  ldloc.0
    IL_000f:  ldarg.0
    IL_0010:  ldloc.1
    IL_0011:  ldelem.u1
    IL_0012:  xor
    IL_0013:  ldc.i4     0xff
    IL_0018:  and
    IL_0019:  ldelem.u2
    IL_001a:  xor
    IL_001b:  conv.u2
    IL_001c:  stloc.0
    IL_001d:  nop
    IL_001e:  ldloc.1
    IL_001f:  ldc.i4.1
    IL_0020:  add
    IL_0021:  stloc.1
    IL_0022:  ldloc.1
    IL_0023:  ldarg.1
    IL_0024:  clt
    IL_0026:  stloc.3
    IL_0027:  ldloc.3
    IL_0028:  brtrue.s   IL_0006

    IL_002a:  ldloc.0
    IL_002b:  not
    IL_002c:  conv.u2
    IL_002d:  stloc.2
    IL_002e:  br.s       IL_0030

    IL_0030:  ldloc.2
    IL_0031:  ret
  } // end of method CyclicRedundancyCheckGenerator::GenerateCyclicRedundancyCheck

  .method public hidebysig static uint16 
          GenerateCyclicRedundancyCheck(uint8[] data,
                                        int32 startIndex,
                                        int32 length,
                                        uint16 seed) cil managed
  {
    // Code size       56 (0x38)
    .maxstack  6
    .locals init ([0] uint16 newCyclicRedundancyCheck,
             [1] int32 i,
             [2] uint16 CS$1$0000,
             [3] bool CS$4$0001)
    IL_0000:  ldarg.3
    IL_0001:  stloc.0
    IL_0002:  ldc.i4.0
    IL_0003:  stloc.1
    IL_0004:  br.s       IL_0028

    IL_0006:  ldloc.0
    IL_0007:  ldc.i4.8
    IL_0008:  shr
    IL_0009:  ldsfld     uint16[] Microsoft.Samples.SpaceInvaders.CyclicRedundancyCheckGenerator::CyclicRedundancyCheckLookupTable
    IL_000e:  ldloc.0
    IL_000f:  ldarg.0
    IL_0010:  ldarg.1
    IL_0011:  ldloc.1
    IL_0012:  add
    IL_0013:  ldarg.0
    IL_0014:  ldlen
    IL_0015:  conv.i4
    IL_0016:  rem
    IL_0017:  ldelem.u1
    IL_0018:  xor
    IL_0019:  ldc.i4     0xff
    IL_001e:  and
    IL_001f:  ldelem.u2
    IL_0020:  xor
    IL_0021:  conv.u2
    IL_0022:  stloc.0
    IL_0023:  nop
    IL_0024:  ldloc.1
    IL_0025:  ldc.i4.1
    IL_0026:  add
    IL_0027:  stloc.1
    IL_0028:  ldloc.1
    IL_0029:  ldarg.2
    IL_002a:  clt
    IL_002c:  stloc.3
    IL_002d:  ldloc.3
    IL_002e:  brtrue.s   IL_0006

    IL_0030:  ldloc.0
    IL_0031:  not
    IL_0032:  conv.u2
    IL_0033:  stloc.2
    IL_0034:  br.s       IL_0036

    IL_0036:  ldloc.2
    IL_0037:  ret
  } // end of method CyclicRedundancyCheckGenerator::GenerateCyclicRedundancyCheck

  .method private hidebysig specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // Code size       27 (0x1b)
    .maxstack  8
    IL_0000:  ldc.i4     0x100
    IL_0005:  newarr     [mscorlib]System.UInt16
    IL_000a:  dup
    IL_000b:  ldtoken    field valuetype '<PrivateImplementationDetails>{D0554739-A3F9-4B53-8210-F567A008B2F2}'/'__StaticArrayInitTypeSize=512' '<PrivateImplementationDetails>{D0554739-A3F9-4B53-8210-F567A008B2F2}'::'$$method0x6000039-1'
    IL_0010:  call       void [mscorlib]System.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(class [mscorlib]System.Array,
                                                                                                        valuetype [mscorlib]System.RuntimeFieldHandle)
    IL_0015:  stsfld     uint16[] Microsoft.Samples.SpaceInvaders.CyclicRedundancyCheckGenerator::CyclicRedundancyCheckLookupTable
    IL_001a:  ret
  } // end of method CyclicRedundancyCheckGenerator::.cctor

} // end of class Microsoft.Samples.SpaceInvaders.CyclicRedundancyCheckGenerator

.class public auto ansi beforefieldinit Microsoft.Samples.SpaceInvaders.Shield
       extends [mscorlib]System.Object
{
  .field private class Microsoft.Samples.SpaceInvaders.ItemPosition _position
  .field private bool _shieldFull
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Microsoft.Samples.SpaceInvaders.ItemPosition ip) cil managed
  {
    // Code size       23 (0x17)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldarg.1
    IL_0009:  stfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Shield::_position
    IL_000e:  ldarg.0
    IL_000f:  ldc.i4.1
    IL_0010:  stfld      bool Microsoft.Samples.SpaceInvaders.Shield::_shieldFull
    IL_0015:  nop
    IL_0016:  ret
  } // end of method Shield::.ctor

  .method public hidebysig specialname instance class Microsoft.Samples.SpaceInvaders.ItemPosition 
          get_Position() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.ItemPosition CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Shield::_position
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method Shield::get_Position

  .method public hidebysig specialname instance void 
          set_Position(class Microsoft.Samples.SpaceInvaders.ItemPosition 'value') cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Shield::_position
    IL_0007:  ret
  } // end of method Shield::set_Position

  .method public hidebysig specialname instance bool 
          get_ShieldFull() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] bool CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      bool Microsoft.Samples.SpaceInvaders.Shield::_shieldFull
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method Shield::get_ShieldFull

  .method public hidebysig specialname instance void 
          set_ShieldFull(bool 'value') cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      bool Microsoft.Samples.SpaceInvaders.Shield::_shieldFull
    IL_0007:  ret
  } // end of method Shield::set_ShieldFull

  .property instance class Microsoft.Samples.SpaceInvaders.ItemPosition
          Position()
  {
    .custom instance void [mscorlib]System.CLSCompliantAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
    .get instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Shield::get_Position()
    .set instance void Microsoft.Samples.SpaceInvaders.Shield::set_Position(class Microsoft.Samples.SpaceInvaders.ItemPosition)
  } // end of property Shield::Position
  .property instance bool ShieldFull()
  {
    .get instance bool Microsoft.Samples.SpaceInvaders.Shield::get_ShieldFull()
    .set instance void Microsoft.Samples.SpaceInvaders.Shield::set_ShieldFull(bool)
  } // end of property Shield::ShieldFull
} // end of class Microsoft.Samples.SpaceInvaders.Shield

.class public auto ansi beforefieldinit Microsoft.Samples.SpaceInvaders.GameData
       extends [mscorlib]System.Object
{
  .field private class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent> _data
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  newobj     instance void class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent>::.ctor()
    IL_000d:  stfld      class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent> Microsoft.Samples.SpaceInvaders.GameData::_data
    IL_0012:  nop
    IL_0013:  ret
  } // end of method GameData::.ctor

  .method public hidebysig specialname instance class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent> 
          get_Events() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent> CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent> Microsoft.Samples.SpaceInvaders.GameData::_data
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method GameData::get_Events

  .property instance class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent>
          Events()
  {
    .custom instance void [mscorlib]System.CLSCompliantAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
    .get instance class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent> Microsoft.Samples.SpaceInvaders.GameData::get_Events()
  } // end of property GameData::Events
} // end of class Microsoft.Samples.SpaceInvaders.GameData

.class public auto ansi beforefieldinit Microsoft.Samples.SpaceInvaders.GameEvent
       extends [mscorlib]System.Object
{
  .field private valuetype [System]System.Diagnostics.TraceEventType _eventType
  .field private valuetype Microsoft.Samples.SpaceInvaders.GameDetail _id
  .field private string _message
  .field private int64 _ticks
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string eventType,
                               string id,
                               string message,
                               int64 ticks) cil managed
  {
    // Code size       80 (0x50)
    .maxstack  3
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldtoken    [System]System.Diagnostics.TraceEventType
    IL_000d:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_0012:  ldarg.1
    IL_0013:  call       object [mscorlib]System.Enum::Parse(class [mscorlib]System.Type,
                                                             string)
    IL_0018:  unbox      [System]System.Diagnostics.TraceEventType
    IL_001d:  ldind.i4
    IL_001e:  stfld      valuetype [System]System.Diagnostics.TraceEventType Microsoft.Samples.SpaceInvaders.GameEvent::_eventType
    IL_0023:  ldarg.0
    IL_0024:  ldtoken    Microsoft.Samples.SpaceInvaders.GameDetail
    IL_0029:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_002e:  ldarg.2
    IL_002f:  call       object [mscorlib]System.Enum::Parse(class [mscorlib]System.Type,
                                                             string)
    IL_0034:  unbox      Microsoft.Samples.SpaceInvaders.GameDetail
    IL_0039:  ldind.i4
    IL_003a:  stfld      valuetype Microsoft.Samples.SpaceInvaders.GameDetail Microsoft.Samples.SpaceInvaders.GameEvent::_id
    IL_003f:  ldarg.0
    IL_0040:  ldarg.3
    IL_0041:  stfld      string Microsoft.Samples.SpaceInvaders.GameEvent::_message
    IL_0046:  ldarg.0
    IL_0047:  ldarg.s    ticks
    IL_0049:  stfld      int64 Microsoft.Samples.SpaceInvaders.GameEvent::_ticks
    IL_004e:  nop
    IL_004f:  ret
  } // end of method GameEvent::.ctor

  .method public hidebysig specialname instance valuetype [System]System.Diagnostics.TraceEventType 
          get_TraceEventType() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] valuetype [System]System.Diagnostics.TraceEventType CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      valuetype [System]System.Diagnostics.TraceEventType Microsoft.Samples.SpaceInvaders.GameEvent::_eventType
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method GameEvent::get_TraceEventType

  .method public hidebysig specialname instance valuetype Microsoft.Samples.SpaceInvaders.GameDetail 
          get_GameDetail() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] valuetype Microsoft.Samples.SpaceInvaders.GameDetail CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      valuetype Microsoft.Samples.SpaceInvaders.GameDetail Microsoft.Samples.SpaceInvaders.GameEvent::_id
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method GameEvent::get_GameDetail

  .method public hidebysig specialname instance string 
          get_Message() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] string CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      string Microsoft.Samples.SpaceInvaders.GameEvent::_message
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method GameEvent::get_Message

  .method public hidebysig specialname instance int64 
          get_Ticks() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] int64 CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int64 Microsoft.Samples.SpaceInvaders.GameEvent::_ticks
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method GameEvent::get_Ticks

  .property instance valuetype [System]System.Diagnostics.TraceEventType
          TraceEventType()
  {
    .get instance valuetype [System]System.Diagnostics.TraceEventType Microsoft.Samples.SpaceInvaders.GameEvent::get_TraceEventType()
  } // end of property GameEvent::TraceEventType
  .property instance valuetype Microsoft.Samples.SpaceInvaders.GameDetail
          GameDetail()
  {
    .get instance valuetype Microsoft.Samples.SpaceInvaders.GameDetail Microsoft.Samples.SpaceInvaders.GameEvent::get_GameDetail()
  } // end of property GameEvent::GameDetail
  .property instance string Message()
  {
    .get instance string Microsoft.Samples.SpaceInvaders.GameEvent::get_Message()
  } // end of property GameEvent::Message
  .property instance int64 Ticks()
  {
    .get instance int64 Microsoft.Samples.SpaceInvaders.GameEvent::get_Ticks()
  } // end of property GameEvent::Ticks
} // end of class Microsoft.Samples.SpaceInvaders.GameEvent

.class public auto ansi sealed beforefieldinit Microsoft.Samples.SpaceInvaders.ListenerOperations
       extends [mscorlib]System.Object
{
  .method private hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  nop
    IL_0008:  ret
  } // end of method ListenerOperations::.ctor

  .method public hidebysig static class [System]System.Diagnostics.TraceSource 
          InitializeListener() cil managed
  {
    // Code size       34 (0x22)
    .maxstack  2
    .locals init ([0] class [System]System.Diagnostics.TraceSource ts,
             [1] class [System]System.Diagnostics.TraceSource CS$1$0000)
    IL_0000:  ldstr      "MySource"
    IL_0005:  newobj     instance void [System]System.Diagnostics.TraceSource::.ctor(string)
    IL_000a:  stloc.0
    IL_000b:  ldloc.0
    IL_000c:  ldstr      "error"
    IL_0011:  call       class [System]System.Diagnostics.TextWriterTraceListener Microsoft.Samples.SpaceInvaders.ListenerOperations::GetListener(string)
    IL_0016:  call       void Microsoft.Samples.SpaceInvaders.ListenerOperations::AddListenerToSource(class [System]System.Diagnostics.TraceSource,
                                                                                                      class [System]System.Diagnostics.TraceListener)
    IL_001b:  nop
    IL_001c:  ldloc.0
    IL_001d:  stloc.1
    IL_001e:  br.s       IL_0020

    IL_0020:  ldloc.1
    IL_0021:  ret
  } // end of method ListenerOperations::InitializeListener

  .method public hidebysig static void  RemoveListenerFromSource(class [System]System.Diagnostics.TraceSource ts,
                                                                 string name) cil managed
  {
    // Code size       116 (0x74)
    .maxstack  2
    .locals init ([0] class [System]System.Diagnostics.TraceListener tlNext,
             [1] class [mscorlib]System.Collections.IEnumerator CS$5$0000,
             [2] bool CS$4$0001,
             [3] class [mscorlib]System.IDisposable CS$0$0002)
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance class [System]System.Diagnostics.TraceListenerCollection [System]System.Diagnostics.TraceSource::get_Listeners()
    IL_0006:  callvirt   instance class [mscorlib]System.Collections.IEnumerator [System]System.Diagnostics.TraceListenerCollection::GetEnumerator()
    IL_000b:  stloc.1
    .try
    {
      IL_000c:  br.s       IL_004e

      IL_000e:  ldloc.1
      IL_000f:  callvirt   instance object [mscorlib]System.Collections.IEnumerator::get_Current()
      IL_0014:  castclass  [System]System.Diagnostics.TraceListener
      IL_0019:  stloc.0
      IL_001a:  ldloc.0
      IL_001b:  callvirt   instance string [System]System.Diagnostics.TraceListener::get_Name()
      IL_0020:  ldarg.1
      IL_0021:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                     string)
      IL_0026:  ldc.i4.0
      IL_0027:  ceq
      IL_0029:  stloc.2
      IL_002a:  ldloc.2
      IL_002b:  brtrue.s   IL_004d

      IL_002d:  ldloc.0
      IL_002e:  castclass  [System]System.Diagnostics.TextWriterTraceListener
      IL_0033:  callvirt   instance class [mscorlib]System.IO.TextWriter [System]System.Diagnostics.TextWriterTraceListener::get_Writer()
      IL_0038:  callvirt   instance void [mscorlib]System.IO.TextWriter::Close()
      IL_003d:  nop
      IL_003e:  ldarg.0
      IL_003f:  callvirt   instance class [System]System.Diagnostics.TraceListenerCollection [System]System.Diagnostics.TraceSource::get_Listeners()
      IL_0044:  ldloc.0
      IL_0045:  callvirt   instance void [System]System.Diagnostics.TraceListenerCollection::Remove(class [System]System.Diagnostics.TraceListener)
      IL_004a:  nop
      IL_004b:  leave.s    IL_0072

      IL_004d:  nop
      IL_004e:  ldloc.1
      IL_004f:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0054:  stloc.2
      IL_0055:  ldloc.2
      IL_0056:  brtrue.s   IL_000e

      IL_0058:  leave.s    IL_0071

    }  // end .try
    finally
    {
      IL_005a:  ldloc.1
      IL_005b:  isinst     [mscorlib]System.IDisposable
      IL_0060:  stloc.3
      IL_0061:  ldloc.3
      IL_0062:  ldnull
      IL_0063:  ceq
      IL_0065:  stloc.2
      IL_0066:  ldloc.2
      IL_0067:  brtrue.s   IL_0070

      IL_0069:  ldloc.3
      IL_006a:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_006f:  nop
      IL_0070:  endfinally
    }  // end handler
    IL_0071:  nop
    IL_0072:  nop
    IL_0073:  ret
  } // end of method ListenerOperations::RemoveListenerFromSource

  .method public hidebysig static void  AddListenerToSource(class [System]System.Diagnostics.TraceSource ts,
                                                            class [System]System.Diagnostics.TraceListener tl) cil managed
  {
    // Code size       104 (0x68)
    .maxstack  2
    .locals init ([0] class [System]System.Diagnostics.TraceListener tlNext,
             [1] class [mscorlib]System.Collections.IEnumerator CS$5$0000,
             [2] bool CS$4$0001,
             [3] class [mscorlib]System.IDisposable CS$0$0002)
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance class [System]System.Diagnostics.TraceListenerCollection [System]System.Diagnostics.TraceSource::get_Listeners()
    IL_0006:  callvirt   instance class [mscorlib]System.Collections.IEnumerator [System]System.Diagnostics.TraceListenerCollection::GetEnumerator()
    IL_000b:  stloc.1
    .try
    {
      IL_000c:  br.s       IL_0035

      IL_000e:  ldloc.1
      IL_000f:  callvirt   instance object [mscorlib]System.Collections.IEnumerator::get_Current()
      IL_0014:  castclass  [System]System.Diagnostics.TraceListener
      IL_0019:  stloc.0
      IL_001a:  ldarg.1
      IL_001b:  callvirt   instance string [System]System.Diagnostics.TraceListener::get_Name()
      IL_0020:  ldloc.0
      IL_0021:  callvirt   instance string [System]System.Diagnostics.TraceListener::get_Name()
      IL_0026:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                     string)
      IL_002b:  ldc.i4.0
      IL_002c:  ceq
      IL_002e:  stloc.2
      IL_002f:  ldloc.2
      IL_0030:  brtrue.s   IL_0034

      IL_0032:  leave.s    IL_0066

      IL_0034:  nop
      IL_0035:  ldloc.1
      IL_0036:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_003b:  stloc.2
      IL_003c:  ldloc.2
      IL_003d:  brtrue.s   IL_000e

      IL_003f:  leave.s    IL_0058

    }  // end .try
    finally
    {
      IL_0041:  ldloc.1
      IL_0042:  isinst     [mscorlib]System.IDisposable
      IL_0047:  stloc.3
      IL_0048:  ldloc.3
      IL_0049:  ldnull
      IL_004a:  ceq
      IL_004c:  stloc.2
      IL_004d:  ldloc.2
      IL_004e:  brtrue.s   IL_0057

      IL_0050:  ldloc.3
      IL_0051:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0056:  nop
      IL_0057:  endfinally
    }  // end handler
    IL_0058:  nop
    IL_0059:  ldarg.0
    IL_005a:  callvirt   instance class [System]System.Diagnostics.TraceListenerCollection [System]System.Diagnostics.TraceSource::get_Listeners()
    IL_005f:  ldarg.1
    IL_0060:  callvirt   instance int32 [System]System.Diagnostics.TraceListenerCollection::Add(class [System]System.Diagnostics.TraceListener)
    IL_0065:  pop
    IL_0066:  nop
    IL_0067:  ret
  } // end of method ListenerOperations::AddListenerToSource

  .method public hidebysig static void  StartGameTrace(class [System]System.Diagnostics.TraceSource ts) cil managed
  {
    // Code size       43 (0x2b)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.8
    IL_0002:  ldc.i4.8
    IL_0003:  ldstr      "-----------------------------"
    IL_0008:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                          int32,
                                                                                          string)
    IL_000d:  nop
    IL_000e:  ldarg.0
    IL_000f:  ldc.i4.8
    IL_0010:  ldc.i4.8
    IL_0011:  ldstr      "New Game Started!"
    IL_0016:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                          int32,
                                                                                          string)
    IL_001b:  nop
    IL_001c:  ldarg.0
    IL_001d:  ldc.i4.8
    IL_001e:  ldc.i4.8
    IL_001f:  ldstr      "-----------------------------"
    IL_0024:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                          int32,
                                                                                          string)
    IL_0029:  nop
    IL_002a:  ret
  } // end of method ListenerOperations::StartGameTrace

  .method public hidebysig static class [System]System.Diagnostics.TextWriterTraceListener 
          GetListener(string name) cil managed
  {
    // Code size       248 (0xf8)
    .maxstack  4
    .locals init ([0] class [System]System.Diagnostics.TextWriterTraceListener twtl,
             [1] class [System]System.Diagnostics.TextWriterTraceListener CS$1$0000,
             [2] bool CS$4$0001,
             [3] valuetype Microsoft.Samples.SpaceInvaders.GameDetail[] CS$0$0002)
    IL_0000:  ldarg.0
    IL_0001:  ldstr      "all"
    IL_0006:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_000b:  ldc.i4.0
    IL_000c:  ceq
    IL_000e:  stloc.2
    IL_000f:  ldloc.2
    IL_0010:  brtrue.s   IL_0036

    IL_0012:  ldstr      "all.log"
    IL_0017:  ldstr      "allfile"
    IL_001c:  newobj     instance void [System]System.Diagnostics.TextWriterTraceListener::.ctor(string,
                                                                                                 string)
    IL_0021:  stloc.0
    IL_0022:  ldloc.0
    IL_0023:  ldloc.0
    IL_0024:  callvirt   instance valuetype [System]System.Diagnostics.TraceOptions [System]System.Diagnostics.TraceListener::get_TraceOutputOptions()
    IL_0029:  ldc.i4.8
    IL_002a:  or
    IL_002b:  callvirt   instance void [System]System.Diagnostics.TraceListener::set_TraceOutputOptions(valuetype [System]System.Diagnostics.TraceOptions)
    IL_0030:  nop
    IL_0031:  br         IL_00e4

    IL_0036:  ldarg.0
    IL_0037:  ldstr      "error"
    IL_003c:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_0041:  ldc.i4.0
    IL_0042:  ceq
    IL_0044:  stloc.2
    IL_0045:  ldloc.2
    IL_0046:  brtrue.s   IL_0067

    IL_0048:  ldstr      "error.log"
    IL_004d:  ldstr      "errorfile"
    IL_0052:  newobj     instance void [System]System.Diagnostics.TextWriterTraceListener::.ctor(string,
                                                                                                 string)
    IL_0057:  stloc.0
    IL_0058:  ldloc.0
    IL_0059:  ldc.i4.3
    IL_005a:  newobj     instance void [System]System.Diagnostics.EventTypeFilter::.ctor(valuetype [System]System.Diagnostics.SourceLevels)
    IL_005f:  callvirt   instance void [System]System.Diagnostics.TraceListener::set_Filter(class [System]System.Diagnostics.TraceFilter)
    IL_0064:  nop
    IL_0065:  br.s       IL_00e4

    IL_0067:  ldarg.0
    IL_0068:  ldstr      "gamestats"
    IL_006d:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_0072:  ldc.i4.0
    IL_0073:  ceq
    IL_0075:  stloc.2
    IL_0076:  ldloc.2
    IL_0077:  brtrue.s   IL_008c

    IL_0079:  ldstr      "gameStats.log"
    IL_007e:  ldstr      "gamestats"
    IL_0083:  newobj     instance void [System]System.Diagnostics.DelimitedListTraceListener::.ctor(string,
                                                                                                    string)
    IL_0088:  stloc.0
    IL_0089:  nop
    IL_008a:  br.s       IL_00e4

    IL_008c:  ldarg.0
    IL_008d:  ldstr      "example"
    IL_0092:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_0097:  ldc.i4.0
    IL_0098:  ceq
    IL_009a:  stloc.2
    IL_009b:  ldloc.2
    IL_009c:  brtrue.s   IL_00d3

    IL_009e:  ldstr      "example.log"
    IL_00a3:  ldstr      "examplelog"
    IL_00a8:  newobj     instance void [System]System.Diagnostics.TextWriterTraceListener::.ctor(string,
                                                                                                 string)
    IL_00ad:  stloc.0
    IL_00ae:  ldloc.0
    IL_00af:  ldc.i4.3
    IL_00b0:  newarr     Microsoft.Samples.SpaceInvaders.GameDetail
    IL_00b5:  stloc.3
    IL_00b6:  ldloc.3
    IL_00b7:  ldc.i4.0
    IL_00b8:  ldc.i4.s   11
    IL_00ba:  stelem.i4
    IL_00bb:  ldloc.3
    IL_00bc:  ldc.i4.1
    IL_00bd:  ldc.i4.s   9
    IL_00bf:  stelem.i4
    IL_00c0:  ldloc.3
    IL_00c1:  ldc.i4.2
    IL_00c2:  ldc.i4.s   10
    IL_00c4:  stelem.i4
    IL_00c5:  ldloc.3
    IL_00c6:  newobj     instance void Microsoft.Samples.SpaceInvaders.GameDetailFilter::.ctor(valuetype Microsoft.Samples.SpaceInvaders.GameDetail[])
    IL_00cb:  callvirt   instance void [System]System.Diagnostics.TraceListener::set_Filter(class [System]System.Diagnostics.TraceFilter)
    IL_00d0:  nop
    IL_00d1:  br.s       IL_00e4

    IL_00d3:  ldstr      "demo.log"
    IL_00d8:  ldstr      "gamedemo"
    IL_00dd:  newobj     instance void [System]System.Diagnostics.DelimitedListTraceListener::.ctor(string,
                                                                                                    string)
    IL_00e2:  stloc.0
    IL_00e3:  nop
    IL_00e4:  ldloc.0
    IL_00e5:  ldloc.0
    IL_00e6:  callvirt   instance valuetype [System]System.Diagnostics.TraceOptions [System]System.Diagnostics.TraceListener::get_TraceOutputOptions()
    IL_00eb:  ldc.i4.4
    IL_00ec:  or
    IL_00ed:  callvirt   instance void [System]System.Diagnostics.TraceListener::set_TraceOutputOptions(valuetype [System]System.Diagnostics.TraceOptions)
    IL_00f2:  ldloc.0
    IL_00f3:  stloc.1
    IL_00f4:  br.s       IL_00f6

    IL_00f6:  ldloc.1
    IL_00f7:  ret
  } // end of method ListenerOperations::GetListener

  .method public hidebysig static void  Clear(class [System]System.Diagnostics.TraceSource ts) cil managed
  {
    // Code size       38 (0x26)
    .maxstack  2
    .try
    {
      IL_0000:  ldarg.0
      IL_0001:  callvirt   instance void [System]System.Diagnostics.TraceSource::Flush()
      IL_0006:  nop
      IL_0007:  ldarg.0
      IL_0008:  ldstr      "gamestats"
      IL_000d:  call       void Microsoft.Samples.SpaceInvaders.ListenerOperations::RemoveListenerFromSource(class [System]System.Diagnostics.TraceSource,
                                                                                                             string)
      IL_0012:  nop
      IL_0013:  ldarg.0
      IL_0014:  ldstr      "gamedemo"
      IL_0019:  call       void Microsoft.Samples.SpaceInvaders.ListenerOperations::RemoveListenerFromSource(class [System]System.Diagnostics.TraceSource,
                                                                                                             string)
      IL_001e:  nop
      IL_001f:  nop
      IL_0020:  leave.s    IL_0024

    }  // end .try
    finally
    {
      IL_0022:  nop
      IL_0023:  endfinally
    }  // end handler
    IL_0024:  nop
    IL_0025:  ret
  } // end of method ListenerOperations::Clear

} // end of class Microsoft.Samples.SpaceInvaders.ListenerOperations

.class public auto ansi beforefieldinit Microsoft.Samples.SpaceInvaders.GameDetailFilter
       extends [System]System.Diagnostics.TraceFilter
{
  .field private valuetype Microsoft.Samples.SpaceInvaders.GameDetail[] _details
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       46 (0x2e)
    .maxstack  4
    .locals init ([0] valuetype Microsoft.Samples.SpaceInvaders.GameDetail[] CS$0$0000)
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System]System.Diagnostics.TraceFilter::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldc.i4.5
    IL_0009:  newarr     Microsoft.Samples.SpaceInvaders.GameDetail
    IL_000e:  stloc.0
    IL_000f:  ldloc.0
    IL_0010:  ldc.i4.0
    IL_0011:  ldc.i4.s   11
    IL_0013:  stelem.i4
    IL_0014:  ldloc.0
    IL_0015:  ldc.i4.1
    IL_0016:  ldc.i4.1
    IL_0017:  stelem.i4
    IL_0018:  ldloc.0
    IL_0019:  ldc.i4.2
    IL_001a:  ldc.i4.s   10
    IL_001c:  stelem.i4
    IL_001d:  ldloc.0
    IL_001e:  ldc.i4.3
    IL_001f:  ldc.i4.s   9
    IL_0021:  stelem.i4
    IL_0022:  ldloc.0
    IL_0023:  ldc.i4.4
    IL_0024:  ldc.i4.8
    IL_0025:  stelem.i4
    IL_0026:  ldloc.0
    IL_0027:  stfld      valuetype Microsoft.Samples.SpaceInvaders.GameDetail[] Microsoft.Samples.SpaceInvaders.GameDetailFilter::_details
    IL_002c:  nop
    IL_002d:  ret
  } // end of method GameDetailFilter::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(valuetype Microsoft.Samples.SpaceInvaders.GameDetail[] details) cil managed
  {
    // Code size       16 (0x10)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System]System.Diagnostics.TraceFilter::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldarg.1
    IL_0009:  stfld      valuetype Microsoft.Samples.SpaceInvaders.GameDetail[] Microsoft.Samples.SpaceInvaders.GameDetailFilter::_details
    IL_000e:  nop
    IL_000f:  ret
  } // end of method GameDetailFilter::.ctor

  .method public hidebysig virtual instance bool 
          ShouldTrace(class [System]System.Diagnostics.TraceEventCache cache,
                      string source,
                      valuetype [System]System.Diagnostics.TraceEventType severity,
                      int32 id,
                      string formatOrMessage,
                      object[] args,
                      object data1,
                      object[] data) cil managed
  {
    // Code size       57 (0x39)
    .maxstack  2
    .locals init ([0] valuetype Microsoft.Samples.SpaceInvaders.GameDetail gd,
             [1] bool CS$1$0000,
             [2] valuetype Microsoft.Samples.SpaceInvaders.GameDetail[] CS$6$0001,
             [3] int32 CS$7$0002,
             [4] bool CS$4$0003)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      valuetype Microsoft.Samples.SpaceInvaders.GameDetail[] Microsoft.Samples.SpaceInvaders.GameDetailFilter::_details
    IL_0006:  stloc.2
    IL_0007:  ldc.i4.0
    IL_0008:  stloc.3
    IL_0009:  br.s       IL_0026

    IL_000b:  ldloc.2
    IL_000c:  ldloc.3
    IL_000d:  ldelem.i4
    IL_000e:  stloc.0
    IL_000f:  ldloc.0
    IL_0010:  ldarg.s    id
    IL_0012:  ceq
    IL_0014:  ldc.i4.0
    IL_0015:  ceq
    IL_0017:  stloc.s    CS$4$0003
    IL_0019:  ldloc.s    CS$4$0003
    IL_001b:  brtrue.s   IL_0021

    IL_001d:  ldc.i4.1
    IL_001e:  stloc.1
    IL_001f:  leave.s    IL_0036

    IL_0021:  nop
    IL_0022:  ldloc.3
    IL_0023:  ldc.i4.1
    IL_0024:  add
    IL_0025:  stloc.3
    IL_0026:  ldloc.3
    IL_0027:  ldloc.2
    IL_0028:  ldlen
    IL_0029:  conv.i4
    IL_002a:  clt
    IL_002c:  stloc.s    CS$4$0003
    IL_002e:  ldloc.s    CS$4$0003
    IL_0030:  brtrue.s   IL_000b

    IL_0032:  ldc.i4.0
    IL_0033:  stloc.1
    IL_0034:  br.s       IL_0036

    IL_0036:  nop
    IL_0037:  ldloc.1
    IL_0038:  ret
  } // end of method GameDetailFilter::ShouldTrace

} // end of class Microsoft.Samples.SpaceInvaders.GameDetailFilter

.class public auto ansi beforefieldinit Microsoft.Samples.SpaceInvaders.Invader
       extends [mscorlib]System.Object
{
  .custom instance void [mscorlib]System.CLSCompliantAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .field private class Microsoft.Samples.SpaceInvaders.ItemPosition _position
  .field private int32 _id
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Microsoft.Samples.SpaceInvaders.ItemPosition ip,
                               int32 id) cil managed
  {
    // Code size       23 (0x17)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldarg.1
    IL_0009:  stfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::_position
    IL_000e:  ldarg.0
    IL_000f:  ldarg.2
    IL_0010:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invader::_id
    IL_0015:  nop
    IL_0016:  ret
  } // end of method Invader::.ctor

  .method public hidebysig specialname instance class Microsoft.Samples.SpaceInvaders.ItemPosition 
          get_Position() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.ItemPosition CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::_position
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method Invader::get_Position

  .method public hidebysig specialname instance void 
          set_Position(class Microsoft.Samples.SpaceInvaders.ItemPosition 'value') cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::_position
    IL_0007:  ret
  } // end of method Invader::set_Position

  .method public hidebysig specialname instance int32 
          get_Identification() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] int32 CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invader::_id
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method Invader::get_Identification

  .method public hidebysig specialname instance void 
          set_Identification(int32 'value') cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invader::_id
    IL_0007:  ret
  } // end of method Invader::set_Identification

  .method public hidebysig instance bool 
          CanFire(class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> invaders) cil managed
  {
    // Code size       115 (0x73)
    .maxstack  2
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.Invader i,
             [1] bool CS$1$0000,
             [2] bool CS$4$0001,
             [3] valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader> CS$5$0002)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invader::_id
    IL_0006:  ldc.i4.s   32
    IL_0008:  cgt
    IL_000a:  ldc.i4.0
    IL_000b:  ceq
    IL_000d:  stloc.2
    IL_000e:  ldloc.2
    IL_000f:  brtrue.s   IL_0015

    IL_0011:  ldc.i4.1
    IL_0012:  stloc.1
    IL_0013:  br.s       IL_0070

    IL_0015:  ldarg.1
    IL_0016:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<!0> class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::GetEnumerator()
    IL_001b:  stloc.3
    .try
    {
      IL_001c:  br.s       IL_0055

      IL_001e:  ldloca.s   CS$5$0002
      IL_0020:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::get_Current()
      IL_0025:  stloc.0
      IL_0026:  ldloc.0
      IL_0027:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.Invader::get_Identification()
      IL_002c:  ldarg.0
      IL_002d:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invader::_id
      IL_0032:  ble.s      IL_004b

      IL_0034:  ldloc.0
      IL_0035:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.Invader::get_Identification()
      IL_003a:  ldarg.0
      IL_003b:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invader::_id
      IL_0040:  sub
      IL_0041:  ldc.i4.8
      IL_0042:  rem
      IL_0043:  ldc.i4.0
      IL_0044:  ceq
      IL_0046:  ldc.i4.0
      IL_0047:  ceq
      IL_0049:  br.s       IL_004c

      IL_004b:  ldc.i4.1
      IL_004c:  stloc.2
      IL_004d:  ldloc.2
      IL_004e:  brtrue.s   IL_0054

      IL_0050:  ldc.i4.0
      IL_0051:  stloc.1
      IL_0052:  leave.s    IL_0070

      IL_0054:  nop
      IL_0055:  ldloca.s   CS$5$0002
      IL_0057:  call       instance bool valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::MoveNext()
      IL_005c:  stloc.2
      IL_005d:  ldloc.2
      IL_005e:  brtrue.s   IL_001e

      IL_0060:  leave.s    IL_006b

    }  // end .try
    finally
    {
      IL_0062:  ldloca.s   CS$5$0002
      IL_0064:  call       instance void valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::Dispose()
      IL_0069:  nop
      IL_006a:  endfinally
    }  // end handler
    IL_006b:  nop
    IL_006c:  ldc.i4.1
    IL_006d:  stloc.1
    IL_006e:  br.s       IL_0070

    IL_0070:  nop
    IL_0071:  ldloc.1
    IL_0072:  ret
  } // end of method Invader::CanFire

  .property instance class Microsoft.Samples.SpaceInvaders.ItemPosition
          Position()
  {
    .get instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
    .set instance void Microsoft.Samples.SpaceInvaders.Invader::set_Position(class Microsoft.Samples.SpaceInvaders.ItemPosition)
  } // end of property Invader::Position
  .property instance int32 Identification()
  {
    .set instance void Microsoft.Samples.SpaceInvaders.Invader::set_Identification(int32)
    .get instance int32 Microsoft.Samples.SpaceInvaders.Invader::get_Identification()
  } // end of property Invader::Identification
} // end of class Microsoft.Samples.SpaceInvaders.Invader

.class public auto ansi sealed Microsoft.Samples.SpaceInvaders.ShipPosition
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.ShipPosition Initial = int32(0x00000000)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.ShipPosition MoveLeft = int32(0x00000001)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.ShipPosition MoveRight = int32(0x00000002)
} // end of class Microsoft.Samples.SpaceInvaders.ShipPosition

.class public auto ansi beforefieldinit Microsoft.Samples.SpaceInvaders.ItemPosition
       extends [mscorlib]System.Object
{
  .field private int32 _left
  .field private int32 _top
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(int32 left,
                               int32 top) cil managed
  {
    // Code size       23 (0x17)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldarg.1
    IL_0009:  stfld      int32 Microsoft.Samples.SpaceInvaders.ItemPosition::_left
    IL_000e:  ldarg.0
    IL_000f:  ldarg.2
    IL_0010:  stfld      int32 Microsoft.Samples.SpaceInvaders.ItemPosition::_top
    IL_0015:  nop
    IL_0016:  ret
  } // end of method ItemPosition::.ctor

  .method public hidebysig specialname instance int32 
          get_Left() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] int32 CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32 Microsoft.Samples.SpaceInvaders.ItemPosition::_left
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method ItemPosition::get_Left

  .method public hidebysig specialname instance void 
          set_Left(int32 'value') cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      int32 Microsoft.Samples.SpaceInvaders.ItemPosition::_left
    IL_0007:  ret
  } // end of method ItemPosition::set_Left

  .method public hidebysig specialname instance int32 
          get_Top() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] int32 CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32 Microsoft.Samples.SpaceInvaders.ItemPosition::_top
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method ItemPosition::get_Top

  .method public hidebysig specialname instance void 
          set_Top(int32 'value') cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      int32 Microsoft.Samples.SpaceInvaders.ItemPosition::_top
    IL_0007:  ret
  } // end of method ItemPosition::set_Top

  .property instance int32 Left()
  {
    .get instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
    .set instance void Microsoft.Samples.SpaceInvaders.ItemPosition::set_Left(int32)
  } // end of property ItemPosition::Left
  .property instance int32 Top()
  {
    .get instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
    .set instance void Microsoft.Samples.SpaceInvaders.ItemPosition::set_Top(int32)
  } // end of property ItemPosition::Top
} // end of class Microsoft.Samples.SpaceInvaders.ItemPosition

.class public auto ansi beforefieldinit Microsoft.Samples.SpaceInvaders.Letter
       extends [mscorlib]System.Object
{
  .field private valuetype [mscorlib]System.ConsoleColor _color
  .field private string[] _values
  .field private string _id
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string id,
                               valuetype [mscorlib]System.ConsoleColor color,
                               string[] values) cil managed
  {
    // Code size       30 (0x1e)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldarg.2
    IL_0009:  stfld      valuetype [mscorlib]System.ConsoleColor Microsoft.Samples.SpaceInvaders.Letter::_color
    IL_000e:  ldarg.0
    IL_000f:  ldarg.3
    IL_0010:  stfld      string[] Microsoft.Samples.SpaceInvaders.Letter::_values
    IL_0015:  ldarg.0
    IL_0016:  ldarg.1
    IL_0017:  stfld      string Microsoft.Samples.SpaceInvaders.Letter::_id
    IL_001c:  nop
    IL_001d:  ret
  } // end of method Letter::.ctor

  .method public hidebysig instance string[] 
          GetValues() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] string[] CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      string[] Microsoft.Samples.SpaceInvaders.Letter::_values
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method Letter::GetValues

  .method public hidebysig specialname instance string 
          get_Identification() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] string CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      string Microsoft.Samples.SpaceInvaders.Letter::_id
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method Letter::get_Identification

  .method public hidebysig specialname instance valuetype [mscorlib]System.ConsoleColor 
          get_Color() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] valuetype [mscorlib]System.ConsoleColor CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      valuetype [mscorlib]System.ConsoleColor Microsoft.Samples.SpaceInvaders.Letter::_color
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method Letter::get_Color

  .property instance string Identification()
  {
    .get instance string Microsoft.Samples.SpaceInvaders.Letter::get_Identification()
  } // end of property Letter::Identification
  .property instance valuetype [mscorlib]System.ConsoleColor
          Color()
  {
    .get instance valuetype [mscorlib]System.ConsoleColor Microsoft.Samples.SpaceInvaders.Letter::get_Color()
  } // end of property Letter::Color
} // end of class Microsoft.Samples.SpaceInvaders.Letter

.class public auto ansi sealed Microsoft.Samples.SpaceInvaders.GameState
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameState Waiting = int32(0x00000000)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameState Playing = int32(0x00000001)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameState Over = int32(0x00000002)
} // end of class Microsoft.Samples.SpaceInvaders.GameState

.class public auto ansi sealed Microsoft.Samples.SpaceInvaders.GameDetail
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameDetail ShipBulletMissed = int32(0x00000000)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameDetail ShipBulletHitInvader = int32(0x00000001)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameDetail ShipBulletHitShield = int32(0x00000002)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameDetail InvaderBulletMissed = int32(0x00000003)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameDetail InvaderBulletHitShip = int32(0x00000004)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameDetail InvaderBulletHitShield = int32(0x00000005)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameDetail BulletsCollided = int32(0x00000006)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameDetail StageCleared = int32(0x00000007)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameDetail GameStarted = int32(0x00000008)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameDetail ShipMovedLeft = int32(0x00000009)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameDetail ShipMovedRight = int32(0x0000000A)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameDetail ShipFired = int32(0x0000000B)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameDetail InvaderFired = int32(0x0000000C)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameDetail WrongKeyPressed = int32(0x0000000D)
  .field public static literal valuetype Microsoft.Samples.SpaceInvaders.GameDetail GameEnded = int32(0x0000000E)
} // end of class Microsoft.Samples.SpaceInvaders.GameDetail

.class public auto ansi beforefieldinit Microsoft.Samples.SpaceInvaders.Invaders
       extends [mscorlib]System.Object
{
  .custom instance void [mscorlib]System.CLSCompliantAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .field private static literal char halfShield = char(0x2591)
  .field private static literal char fullShield = char(0x2588)
  .field private static literal int32 initInvaderTime = int32(0x00000352)
  .field private class [System]System.Diagnostics.TraceSource ts
  .field private class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> highScores
  .field private class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> liShipBullets
  .field private class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> liInvaderBullets
  .field private class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> liInvaders
  .field private class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> liShieldPositions
  .field private string[] scoreNames
  .field private class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> letters
  .field private valuetype [mscorlib]System.ConsoleColor initialBackColor
  .field private valuetype [mscorlib]System.ConsoleColor initialForeColor
  .field private int32 initialWindowWidth
  .field private int32 initialWindowHeight
  .field private int32 initialBufferWidth
  .field private int32 initialBufferHeight
  .field private string initialTitle
  .field private class [System]System.Timers.Timer getSerialKeys
  .field private class [System]System.Timers.Timer clearLcdScreen
  .field private class [System]System.Timers.Timer shipBulletTimer
  .field private class [System]System.Timers.Timer HighScoreTimer
  .field private class [System]System.Timers.Timer shipDestroyedTimer
  .field private class [System]System.Timers.Timer explosionTimer
  .field private class [System]System.Timers.Timer invadersTimer
  .field private class [System]System.Timers.Timer invadersBulletTimer
  .field private int32 score
  .field private class Microsoft.Samples.SpaceInvaders.SerialLcd lcd
  .field private int32 maxInvaderLeft
  .field private int32 minInvaderLeft
  .field private bool invadersMoveRight
  .field private int32 iterationCount
  .field private class Microsoft.Samples.SpaceInvaders.ItemPosition currentShipPosition
  .field private class Microsoft.Samples.SpaceInvaders.ItemPosition invaderExplosion
  .field private int32 invaderExplosionState
  .field private int32 shipCount
  .field private bool highScoreDisplayed
  .field private bool shipBeingDestroyed
  .field private bool gettingName
  .field private bool demoMode
  .field private bool demoNotHighScore
  .field private valuetype Microsoft.Samples.SpaceInvaders.GameState gameOver
  .field private bool invadersReset
  .field private int32 shipExplosionState
  .field private bool movesInvalid
  .field private bool _mute
  .field private valuetype [mscorlib]System.DateTime iterationStartTime
  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    .custom instance void [mscorlib]System.STAThreadAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       25 (0x19)
    .maxstack  1
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.Invaders id)
    IL_0000:  call       class [System]System.Diagnostics.CorrelationManager [System]System.Diagnostics.Trace::get_CorrelationManager()
    IL_0005:  callvirt   instance void [System]System.Diagnostics.CorrelationManager::StartLogicalOperation()
    IL_000a:  nop
    IL_000b:  newobj     instance void Microsoft.Samples.SpaceInvaders.Invaders::.ctor()
    IL_0017:  nop
    IL_0018:  ret
  } // end of method Invaders::Main

  .method private hidebysig instance void 
          Run() cil managed
  {
    // Code size       977 (0x3d1)
    .maxstack  5
    .locals init ([0] class [System]System.Diagnostics.Stopwatch swEnterDemoMode,
             [1] valuetype [mscorlib]System.ConsoleKeyInfo cki,
             [2] bool CS$4$0000,
             [3] valuetype [mscorlib]System.ConsoleKey CS$4$0001,
             [4] valuetype [mscorlib]System.ConsoleKey CS$0$0002)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.0
    IL_0002:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::GetScores()
    IL_0007:  stfld      class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::highScores
    IL_000c:  ldarg.0
    IL_000d:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::Initialize()
    IL_0012:  nop
    IL_0013:  ldarg.0
    IL_0014:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::StartScreen()
    IL_0019:  nop
    IL_001a:  ldarg.0
    IL_001b:  newobj     instance void Microsoft.Samples.SpaceInvaders.SerialLcd::.ctor()
    IL_0020:  stfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
    IL_0025:  newobj     instance void [System]System.Diagnostics.Stopwatch::.ctor()
    IL_002a:  stloc.0
    IL_002b:  br         IL_03c9

    IL_0030:  ldloc.0
    IL_0031:  callvirt   instance bool [System]System.Diagnostics.Stopwatch::get_IsRunning()
    IL_0036:  stloc.2
    IL_0037:  ldloc.2
    IL_0038:  brtrue.s   IL_0042

    IL_003a:  ldloc.0
    IL_003b:  callvirt   instance void [System]System.Diagnostics.Stopwatch::Start()
    IL_0040:  nop
    IL_0041:  nop
    IL_0042:  br         IL_00f6

    IL_0047:  ldarg.0
    IL_0048:  ldfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
    IL_004d:  callvirt   instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::get_IsOpen()
    IL_0052:  ldc.i4.0
    IL_0053:  ceq
    IL_0055:  stloc.2
    IL_0056:  ldloc.2
    IL_0057:  brtrue.s   IL_0066

    IL_0059:  ldarg.0
    IL_005a:  ldfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
    IL_005f:  callvirt   instance void Microsoft.Samples.SpaceInvaders.SerialLcd::Reset()
    IL_0064:  nop
    IL_0065:  nop
    IL_0066:  ldarg.0
    IL_0067:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoNotHighScore
    IL_006c:  stloc.2
    IL_006d:  ldloc.2
    IL_006e:  brtrue.s   IL_00aa

    IL_0070:  ldloc.0
    IL_0071:  callvirt   instance int64 [System]System.Diagnostics.Stopwatch::get_ElapsedMilliseconds()
    IL_0076:  ldc.i4     0x1f40
    IL_007b:  conv.i8
    IL_007c:  cgt
    IL_007e:  ldc.i4.0
    IL_007f:  ceq
    IL_0081:  stloc.2
    IL_0082:  ldloc.2
    IL_0083:  brtrue.s   IL_00a7

    IL_0085:  ldarg.0
    IL_0086:  ldc.i4     0x1b58
    IL_008b:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ShowHighScores(int32)
    IL_0090:  nop
    IL_0091:  ldarg.0
    IL_0092:  ldc.i4.1
    IL_0093:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoNotHighScore
    IL_0098:  ldloc.0
    IL_0099:  callvirt   instance void [System]System.Diagnostics.Stopwatch::Reset()
    IL_009e:  nop
    IL_009f:  ldloc.0
    IL_00a0:  callvirt   instance void [System]System.Diagnostics.Stopwatch::Start()
    IL_00a5:  nop
    IL_00a6:  nop
    IL_00a7:  nop
    IL_00a8:  br.s       IL_00f5

    IL_00aa:  ldloc.0
    IL_00ab:  callvirt   instance int64 [System]System.Diagnostics.Stopwatch::get_ElapsedMilliseconds()
    IL_00b0:  ldc.i4     0x36b0
    IL_00b5:  conv.i8
    IL_00b6:  cgt
    IL_00b8:  ldc.i4.0
    IL_00b9:  ceq
    IL_00bb:  stloc.2
    IL_00bc:  ldloc.2
    IL_00bd:  brtrue.s   IL_00f4

    IL_00bf:  ldarg.0
    IL_00c0:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::HighScoreTimer
    IL_00c5:  ldc.i4.0
    IL_00c6:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_00cb:  ldarg.0
    IL_00cc:  ldc.i4     0x4e20
    IL_00d1:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::RunDemoMode(int32)
    IL_00d6:  nop
    IL_00d7:  ldloc.0
    IL_00d8:  callvirt   instance void [System]System.Diagnostics.Stopwatch::Reset()
    IL_00dd:  nop
    IL_00de:  ldloc.0
    IL_00df:  callvirt   instance void [System]System.Diagnostics.Stopwatch::Start()
    IL_00e4:  nop
    IL_00e5:  ldarg.0
    IL_00e6:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::StartScreen()
    IL_00eb:  nop
    IL_00ec:  ldarg.0
    IL_00ed:  ldc.i4.0
    IL_00ee:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoNotHighScore
    IL_00f3:  nop
    IL_00f4:  nop
    IL_00f5:  nop
    IL_00f6:  call       bool [mscorlib]System.Console::get_KeyAvailable()
    IL_00fb:  ldc.i4.0
    IL_00fc:  ceq
    IL_00fe:  stloc.2
    IL_00ff:  ldloc.2
    IL_0100:  brtrue     IL_0047

    IL_0105:  ldloc.0
    IL_0106:  callvirt   instance void [System]System.Diagnostics.Stopwatch::Reset()
    IL_010b:  nop
    IL_010c:  ldc.i4.1
    IL_010d:  call       valuetype [mscorlib]System.ConsoleKeyInfo [mscorlib]System.Console::ReadKey(bool)
    IL_0112:  stloc.1
    IL_0113:  ldarg.0
    IL_0114:  ldc.i4.0
    IL_0115:  stfld      valuetype Microsoft.Samples.SpaceInvaders.GameState Microsoft.Samples.SpaceInvaders.Invaders::gameOver
    IL_011a:  ldloca.s   cki
    IL_011c:  call       instance valuetype [mscorlib]System.ConsoleKey [mscorlib]System.ConsoleKeyInfo::get_Key()
    IL_0121:  stloc.3
    IL_0122:  ldloc.3
    IL_0123:  stloc.s    CS$0$0002
    IL_0125:  ldloc.s    CS$0$0002
    IL_0127:  ldc.i4.s   68
    IL_0129:  bgt.s      IL_0148

    IL_012b:  ldloc.s    CS$0$0002
    IL_012d:  ldc.i4.s   27
    IL_012f:  beq.s      IL_017c

    IL_0131:  ldloc.s    CS$0$0002
    IL_0133:  ldc.i4.s   67
    IL_0135:  sub
    IL_0136:  switch     ( 
                          IL_0350,
                          IL_02d1)
    IL_0143:  br         IL_0399

    IL_0148:  ldloc.s    CS$0$0002
    IL_014a:  ldc.i4.s   72
    IL_014c:  beq        IL_0359

    IL_0151:  ldloc.s    CS$0$0002
    IL_0153:  ldc.i4.s   77
    IL_0155:  sub
    IL_0156:  switch     ( 
                          IL_0373,
                          IL_0399,
                          IL_0347,
                          IL_0399,
                          IL_0384,
                          IL_0399,
                          IL_0280)
    IL_0177:  br         IL_0399

    IL_017c:  ldarg.0
    IL_017d:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::highScoreDisplayed
    IL_0182:  ldc.i4.0
    IL_0183:  ceq
    IL_0185:  stloc.2
    IL_0186:  ldloc.2
    IL_0187:  brtrue.s   IL_01c9

    IL_0189:  ldarg.0
    IL_018a:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::HighScoreTimer
    IL_018f:  ldc.i4.0
    IL_0190:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_0195:  ldarg.0
    IL_0196:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_019b:  call       void Microsoft.Samples.SpaceInvaders.ListenerOperations::Clear(class [System]System.Diagnostics.TraceSource)
    IL_01a0:  nop
    IL_01a1:  ldarg.0
    IL_01a2:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::StartScreen()
    IL_01a7:  nop
    IL_01a8:  ldarg.0
    IL_01a9:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_01ae:  ldnull
    IL_01af:  ceq
    IL_01b1:  ldc.i4.0
    IL_01b2:  ceq
    IL_01b4:  stloc.2
    IL_01b5:  ldloc.2
    IL_01b6:  brtrue.s   IL_01c4

    IL_01b8:  ldarg.0
    IL_01b9:  call       class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.ListenerOperations::InitializeListener()
    IL_01be:  stfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_01c3:  nop
    IL_01c4:  br         IL_03c8

    .try
    {
      IL_01c9:  ldarg.0
      IL_01ca:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
      IL_01cf:  callvirt   instance void [System]System.Diagnostics.TraceSource::Flush()
      IL_01d4:  nop
      IL_01d5:  nop
      IL_01d6:  leave.s    IL_01dc

    }  // end .try
    catch [mscorlib]System.Object 
    {
      IL_01d8:  pop
      IL_01d9:  nop
      IL_01da:  leave.s    IL_01dc

    }  // end handler
    IL_01dc:  nop
    IL_01dd:  call       void [mscorlib]System.Console::Clear()
    IL_01e2:  nop
    IL_01e3:  ldc.i4.7
    IL_01e4:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
    IL_01e9:  ldc.i4.1
    IL_01ea:  call       void [mscorlib]System.Console::set_CursorVisible(bool)
    IL_01ef:  ldarg.0
    IL_01f0:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::SetScores()
    IL_01f5:  nop
    IL_01f6:  call       class [System]System.Diagnostics.CorrelationManager [System]System.Diagnostics.Trace::get_CorrelationManager()
    IL_01fb:  callvirt   instance void [System]System.Diagnostics.CorrelationManager::StopLogicalOperation()
    IL_0200:  nop
    IL_0201:  ldarg.0
    IL_0202:  ldfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
    IL_0207:  callvirt   instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::get_IsOpen()
    IL_020c:  ldc.i4.0
    IL_020d:  ceq
    IL_020f:  stloc.2
    IL_0210:  ldloc.2
    IL_0211:  brtrue.s   IL_0220

    IL_0213:  ldarg.0
    IL_0214:  ldfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
    IL_0219:  callvirt   instance void Microsoft.Samples.SpaceInvaders.SerialLcd::Close()
    IL_021e:  nop
    IL_021f:  nop
    IL_0220:  ldarg.0
    IL_0221:  ldfld      valuetype [mscorlib]System.ConsoleColor Microsoft.Samples.SpaceInvaders.Invaders::initialBackColor
    IL_0226:  call       void [mscorlib]System.Console::set_BackgroundColor(valuetype [mscorlib]System.ConsoleColor)
    IL_022b:  ldarg.0
    IL_022c:  ldfld      valuetype [mscorlib]System.ConsoleColor Microsoft.Samples.SpaceInvaders.Invaders::initialForeColor
    IL_0231:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
    IL_0236:  ldarg.0
    IL_0237:  ldfld      string Microsoft.Samples.SpaceInvaders.Invaders::initialTitle
    IL_023c:  call       void [mscorlib]System.Console::set_Title(string)
    IL_0241:  ldarg.0
    IL_0242:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::initialBufferHeight
    IL_0247:  call       void [mscorlib]System.Console::set_BufferHeight(int32)
    IL_024c:  ldarg.0
    IL_024d:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::initialBufferWidth
    IL_0252:  call       void [mscorlib]System.Console::set_BufferWidth(int32)
    IL_0257:  ldarg.0
    IL_0258:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::initialWindowHeight
    IL_025d:  call       void [mscorlib]System.Console::set_WindowHeight(int32)
    IL_0262:  ldarg.0
    IL_0263:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::initialWindowWidth
    IL_0268:  call       void [mscorlib]System.Console::set_WindowWidth(int32)
    IL_026d:  ldc.i4.0
    IL_026e:  ldc.i4.0
    IL_026f:  call       void [mscorlib]System.Console::SetWindowPosition(int32,
                                                                          int32)
    IL_0274:  nop
    IL_0275:  call       void [mscorlib]System.Console::Clear()
    IL_027a:  nop
    IL_027b:  br         IL_03d0

    IL_0280:  ldarg.0
    IL_0281:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::HighScoreTimer
    IL_0286:  ldc.i4.0
    IL_0287:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_028c:  ldarg.0
    IL_028d:  ldc.i4.0
    IL_028e:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
    IL_0293:  ldarg.0
    IL_0294:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::StartGame()
    IL_0299:  nop
    IL_029a:  ldarg.0
    IL_029b:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::Play()
    IL_02a0:  nop
    IL_02a1:  br.s       IL_02a4

    IL_02a3:  nop
    IL_02a4:  ldarg.0
    IL_02a5:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::gettingName
    IL_02aa:  brtrue.s   IL_02c0

    IL_02ac:  ldarg.0
    IL_02ad:  ldfld      valuetype Microsoft.Samples.SpaceInvaders.GameState Microsoft.Samples.SpaceInvaders.Invaders::gameOver
    IL_02b2:  ldc.i4.2
    IL_02b3:  beq.s      IL_02c0

    IL_02b5:  ldarg.0
    IL_02b6:  ldfld      valuetype Microsoft.Samples.SpaceInvaders.GameState Microsoft.Samples.SpaceInvaders.Invaders::gameOver
    IL_02bb:  ldc.i4.1
    IL_02bc:  ceq
    IL_02be:  br.s       IL_02c1

    IL_02c0:  ldc.i4.1
    IL_02c1:  stloc.2
    IL_02c2:  ldloc.2
    IL_02c3:  brtrue.s   IL_02a3

    IL_02c5:  ldarg.0
    IL_02c6:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::StartScreen()
    IL_02cb:  nop
    IL_02cc:  br         IL_03c8

    IL_02d1:  ldarg.0
    IL_02d2:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::HighScoreTimer
    IL_02d7:  ldc.i4.0
    IL_02d8:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_02dd:  ldarg.0
    IL_02de:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_02e3:  call       void Microsoft.Samples.SpaceInvaders.ListenerOperations::Clear(class [System]System.Diagnostics.TraceSource)
    IL_02e8:  nop
    IL_02e9:  ldarg.0
    IL_02ea:  ldc.i4     0x7fffffff
    IL_02ef:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::RunDemoMode(int32)
    IL_02f4:  nop
    IL_02f5:  ldarg.0
    IL_02f6:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_02fb:  ldnull
    IL_02fc:  ceq
    IL_02fe:  ldc.i4.0
    IL_02ff:  ceq
    IL_0301:  stloc.2
    IL_0302:  ldloc.2
    IL_0303:  brtrue.s   IL_0311

    IL_0305:  ldarg.0
    IL_0306:  call       class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.ListenerOperations::InitializeListener()
    IL_030b:  stfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_0310:  nop
    IL_0311:  ldarg.0
    IL_0312:  ldc.i4.0
    IL_0313:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
    IL_0318:  ldarg.0
    IL_0319:  ldc.i4.0
    IL_031a:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::score
    IL_031f:  ldarg.0
    IL_0320:  ldc.i4.0
    IL_0321:  stfld      valuetype Microsoft.Samples.SpaceInvaders.GameState Microsoft.Samples.SpaceInvaders.Invaders::gameOver
    IL_0326:  ldarg.0
    IL_0327:  ldc.i4.0
    IL_0328:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::gettingName
    IL_032d:  ldarg.0
    IL_032e:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::Reset()
    IL_0333:  nop
    IL_0334:  ldarg.0
    IL_0335:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ClearLists()
    IL_033a:  nop
    IL_033b:  ldarg.0
    IL_033c:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::StartScreen()
    IL_0341:  nop
    IL_0342:  br         IL_03c8

    IL_0347:  ldarg.0
    IL_0348:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::OpenLcd()
    IL_034d:  nop
    IL_034e:  br.s       IL_03c8

    IL_0350:  ldarg.0
    IL_0351:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::CloseLcd()
    IL_0356:  nop
    IL_0357:  br.s       IL_03c8

    IL_0359:  ldarg.0
    IL_035a:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::HighScoreTimer
    IL_035f:  ldc.i4.0
    IL_0360:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_0365:  ldarg.0
    IL_0366:  ldc.i4     0x2ee0
    IL_036b:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ShowHighScores(int32)
    IL_0370:  nop
    IL_0371:  br.s       IL_03c8

    IL_0373:  ldarg.0
    IL_0374:  ldarg.0
    IL_0375:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::_mute
    IL_037a:  ldc.i4.0
    IL_037b:  ceq
    IL_037d:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::_mute
    IL_0382:  br.s       IL_03c8

    IL_0384:  ldarg.0
    IL_0385:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::HighScoreTimer
    IL_038a:  ldc.i4.0
    IL_038b:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_0390:  ldarg.0
    IL_0391:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::StartScreen()
    IL_0396:  nop
    IL_0397:  br.s       IL_03c8

    .try
    {
      IL_0399:  ldarg.0
      IL_039a:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
      IL_039f:  ldc.i4.2
      IL_03a0:  ldc.i4.s   13
      IL_03a2:  ldstr      "User pressed the wrong key: "
      IL_03a7:  ldloca.s   cki
      IL_03a9:  call       instance valuetype [mscorlib]System.ConsoleKey [mscorlib]System.ConsoleKeyInfo::get_Key()
      IL_03ae:  box        [mscorlib]System.ConsoleKey
      IL_03b3:  call       string [mscorlib]System.String::Concat(object,
                                                                  object)
      IL_03b8:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                            int32,
                                                                                            string)
      IL_03bd:  nop
      IL_03be:  nop
      IL_03bf:  leave.s    IL_03c5

    }  // end .try
    catch [mscorlib]System.Object 
    {
      IL_03c1:  pop
      IL_03c2:  nop
      IL_03c3:  leave.s    IL_03c5

    }  // end handler
    IL_03c5:  nop
    IL_03c6:  br.s       IL_03c8

    IL_03c8:  nop
    IL_03c9:  ldc.i4.1
    IL_03ca:  stloc.2
    IL_03cb:  br         IL_0030

    IL_03d0:  ret
  } // end of method Invaders::Run

  .method private hidebysig instance void 
          OpenLcd() cil managed
  {
    // Code size       77 (0x4d)
    .maxstack  4
    .locals init ([0] bool CS$4$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
    IL_0006:  callvirt   instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::get_IsOpen()
    IL_000b:  stloc.0
    IL_000c:  ldloc.0
    IL_000d:  brtrue.s   IL_004c

    IL_000f:  ldarg.0
    IL_0010:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::getSerialKeys
    IL_0015:  ldarg.0
    IL_0016:  ldftn      instance void Microsoft.Samples.SpaceInvaders.Invaders::OnSerialKeysEvent(object,
                                                                                                   class [System]System.Timers.ElapsedEventArgs)
    IL_001c:  newobj     instance void [System]System.Timers.ElapsedEventHandler::.ctor(object,
                                                                                        native int)
    IL_0021:  callvirt   instance void [System]System.Timers.Timer::add_Elapsed(class [System]System.Timers.ElapsedEventHandler)
    IL_0026:  nop
    IL_0027:  ldarg.0
    IL_0028:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::clearLcdScreen
    IL_002d:  ldarg.0
    IL_002e:  ldftn      instance void Microsoft.Samples.SpaceInvaders.Invaders::OnSerialLcdClearedEvent(object,
                                                                                                         class [System]System.Timers.ElapsedEventArgs)
    IL_0034:  newobj     instance void [System]System.Timers.ElapsedEventHandler::.ctor(object,
                                                                                        native int)
    IL_0039:  callvirt   instance void [System]System.Timers.Timer::add_Elapsed(class [System]System.Timers.ElapsedEventHandler)
    IL_003e:  nop
    IL_003f:  ldarg.0
    IL_0040:  ldfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
    IL_0045:  callvirt   instance void Microsoft.Samples.SpaceInvaders.SerialLcd::Open()
    IL_004a:  nop
    IL_004b:  nop
    IL_004c:  ret
  } // end of method Invaders::OpenLcd

  .method private hidebysig instance void 
          CloseLcd() cil managed
  {
    // Code size       80 (0x50)
    .maxstack  4
    .locals init ([0] bool CS$4$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
    IL_0006:  callvirt   instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::get_IsOpen()
    IL_000b:  ldc.i4.0
    IL_000c:  ceq
    IL_000e:  stloc.0
    IL_000f:  ldloc.0
    IL_0010:  brtrue.s   IL_004f

    IL_0012:  ldarg.0
    IL_0013:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::getSerialKeys
    IL_0018:  ldarg.0
    IL_0019:  ldftn      instance void Microsoft.Samples.SpaceInvaders.Invaders::OnSerialKeysEvent(object,
                                                                                                   class [System]System.Timers.ElapsedEventArgs)
    IL_001f:  newobj     instance void [System]System.Timers.ElapsedEventHandler::.ctor(object,
                                                                                        native int)
    IL_0024:  callvirt   instance void [System]System.Timers.Timer::remove_Elapsed(class [System]System.Timers.ElapsedEventHandler)
    IL_0029:  nop
    IL_002a:  ldarg.0
    IL_002b:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::clearLcdScreen
    IL_0030:  ldarg.0
    IL_0031:  ldftn      instance void Microsoft.Samples.SpaceInvaders.Invaders::OnSerialLcdClearedEvent(object,
                                                                                                         class [System]System.Timers.ElapsedEventArgs)
    IL_0037:  newobj     instance void [System]System.Timers.ElapsedEventHandler::.ctor(object,
                                                                                        native int)
    IL_003c:  callvirt   instance void [System]System.Timers.Timer::add_Elapsed(class [System]System.Timers.ElapsedEventHandler)
    IL_0041:  nop
    IL_0042:  ldarg.0
    IL_0043:  ldfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
    IL_0048:  callvirt   instance void Microsoft.Samples.SpaceInvaders.SerialLcd::Close()
    IL_004d:  nop
    IL_004e:  nop
    IL_004f:  ret
  } // end of method Invaders::CloseLcd

  .method private hidebysig instance void 
          RunDemoMode(int32 millisecondDuration) cil managed
  {
    // Code size       584 (0x248)
    .maxstack  3
    .locals init ([0] class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent> gameEvents,
             [1] class [System]System.Diagnostics.Stopwatch sw,
             [2] class [System]System.Diagnostics.Stopwatch swDuration,
             [3] class Microsoft.Samples.SpaceInvaders.GameEvent ge,
             [4] int32 invID,
             [5] class Microsoft.Samples.SpaceInvaders.Invader i,
             [6] valuetype [mscorlib]System.ConsoleKeyInfo cki,
             [7] class [mscorlib]System.Collections.Generic.'IEnumerator`1'<class Microsoft.Samples.SpaceInvaders.GameEvent> CS$5$0000,
             [8] bool CS$4$0001,
             [9] valuetype Microsoft.Samples.SpaceInvaders.GameDetail CS$4$0002,
             [10] valuetype Microsoft.Samples.SpaceInvaders.GameDetail CS$0$0003,
             [11] valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader> CS$5$0004,
             [12] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0005)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_0006:  ldstr      "gamedemo"
    IL_000b:  call       void Microsoft.Samples.SpaceInvaders.ListenerOperations::RemoveListenerFromSource(class [System]System.Diagnostics.TraceSource,
                                                                                                           string)
    IL_0010:  nop
    IL_0011:  ldarg.0
    IL_0012:  ldc.i4.1
    IL_0013:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
    .try
    {
      IL_0018:  ldarg.0
      IL_0019:  ldstr      "demo.log"
      IL_001e:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent> Microsoft.Samples.SpaceInvaders.Invaders::GetGameEvents(string)
      IL_0023:  stloc.0
      IL_0024:  nop
      IL_0025:  leave.s    IL_002d

    }  // end .try
    catch [mscorlib]System.Object 
    {
      IL_0027:  pop
      IL_0028:  leave      IL_0246

    }  // end handler
    IL_002d:  nop
    IL_002e:  newobj     instance void [System]System.Diagnostics.Stopwatch::.ctor()
    IL_0033:  stloc.1
    IL_0034:  ldloc.1
    IL_0035:  callvirt   instance void [System]System.Diagnostics.Stopwatch::Start()
    IL_003a:  nop
    IL_003b:  ldarg.0
    IL_003c:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::StartGame()
    IL_0041:  nop
    IL_0042:  ldarg.0
    IL_0043:  ldc.i4.0
    IL_0044:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawShip(valuetype Microsoft.Samples.SpaceInvaders.ShipPosition)
    IL_0049:  nop
    IL_004a:  ldarg.0
    IL_004b:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawHighScore()
    IL_0050:  nop
    IL_0051:  newobj     instance void [System]System.Diagnostics.Stopwatch::.ctor()
    IL_0056:  stloc.2
    IL_0057:  ldloc.2
    IL_0058:  callvirt   instance void [System]System.Diagnostics.Stopwatch::Start()
    IL_005d:  nop
    IL_005e:  ldloc.0
    IL_005f:  callvirt   instance class [mscorlib]System.Collections.Generic.'IList`1'<!1> class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent>::get_Values()
    IL_0064:  callvirt   instance class [mscorlib]System.Collections.Generic.'IEnumerator`1'<!0> class [mscorlib]System.Collections.Generic.'IEnumerable`1'<class Microsoft.Samples.SpaceInvaders.GameEvent>::GetEnumerator()
    IL_0069:  stloc.s    CS$5$0000
    .try
    {
      IL_006b:  br         IL_0218

      IL_0070:  ldloc.s    CS$5$0000
      IL_0072:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'IEnumerator`1'<class Microsoft.Samples.SpaceInvaders.GameEvent>::get_Current()
      IL_0077:  stloc.3
      IL_0078:  br         IL_020f

      IL_007d:  call       bool [mscorlib]System.Console::get_KeyAvailable()
      IL_0082:  brtrue.s   IL_0093

      IL_0084:  ldloc.2
      IL_0085:  callvirt   instance int64 [System]System.Diagnostics.Stopwatch::get_ElapsedMilliseconds()
      IL_008a:  ldarg.1
      IL_008b:  conv.i8
      IL_008c:  clt
      IL_008e:  ldc.i4.0
      IL_008f:  ceq
      IL_0091:  br.s       IL_0094

      IL_0093:  ldc.i4.1
      IL_0094:  stloc.s    CS$4$0001
      IL_0096:  ldloc.s    CS$4$0001
      IL_0098:  brtrue     IL_01ee

      IL_009d:  ldloc.1
      IL_009e:  callvirt   instance int64 [System]System.Diagnostics.Stopwatch::get_ElapsedTicks()
      IL_00a3:  ldloc.3
      IL_00a4:  callvirt   instance int64 Microsoft.Samples.SpaceInvaders.GameEvent::get_Ticks()
      IL_00a9:  cgt
      IL_00ab:  ldc.i4.0
      IL_00ac:  ceq
      IL_00ae:  stloc.s    CS$4$0001
      IL_00b0:  ldloc.s    CS$4$0001
      IL_00b2:  brtrue     IL_01eb

      IL_00b7:  ldloc.3
      IL_00b8:  callvirt   instance valuetype Microsoft.Samples.SpaceInvaders.GameDetail Microsoft.Samples.SpaceInvaders.GameEvent::get_GameDetail()
      IL_00bd:  stloc.s    CS$4$0002
      IL_00bf:  ldloc.s    CS$4$0002
      IL_00c1:  stloc.s    CS$0$0003
      IL_00c3:  ldloc.s    CS$0$0003
      IL_00c5:  ldc.i4.s   9
      IL_00c7:  sub
      IL_00c8:  switch     ( 
                            IL_018b,
                            IL_01b9,
                            IL_015e,
                            IL_00e2)
      IL_00dd:  br         IL_01e7

      .try
      {
        IL_00e2:  ldloc.3
        IL_00e3:  callvirt   instance string Microsoft.Samples.SpaceInvaders.GameEvent::get_Message()
        IL_00e8:  ldc.i4.0
        IL_00e9:  ldc.i4.3
        IL_00ea:  callvirt   instance string [mscorlib]System.String::Substring(int32,
                                                                                int32)
        IL_00ef:  callvirt   instance string [mscorlib]System.String::Trim()
        IL_00f4:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()
        IL_00f9:  call       int32 [mscorlib]System.Convert::ToInt32(string,
                                                                     class [mscorlib]System.IFormatProvider)
        IL_00fe:  stloc.s    invID
        IL_0100:  ldarg.0
        IL_0101:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
        IL_0106:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<!0> class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::GetEnumerator()
        IL_010b:  stloc.s    CS$5$0004
        .try
        {
          IL_010d:  br.s       IL_0138

          IL_010f:  ldloca.s   CS$5$0004
          IL_0111:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::get_Current()
          IL_0116:  stloc.s    i
          IL_0118:  ldloc.s    i
          IL_011a:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.Invader::get_Identification()
          IL_011f:  ldloc.s    invID
          IL_0121:  ceq
          IL_0123:  ldc.i4.0
          IL_0124:  ceq
          IL_0126:  stloc.s    CS$4$0001
          IL_0128:  ldloc.s    CS$4$0001
          IL_012a:  brtrue.s   IL_0137

          IL_012c:  ldarg.0
          IL_012d:  ldloc.s    i
          IL_012f:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ShootInvaderBullet(class Microsoft.Samples.SpaceInvaders.Invader)
          IL_0134:  nop
          IL_0135:  br.s       IL_0145

          IL_0137:  nop
          IL_0138:  ldloca.s   CS$5$0004
          IL_013a:  call       instance bool valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::MoveNext()
          IL_013f:  stloc.s    CS$4$0001
          IL_0141:  ldloc.s    CS$4$0001
          IL_0143:  brtrue.s   IL_010f

          IL_0145:  leave.s    IL_0150

        }  // end .try
        finally
        {
          IL_0147:  ldloca.s   CS$5$0004
          IL_0149:  call       instance void valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::Dispose()
          IL_014e:  nop
          IL_014f:  endfinally
        }  // end handler
        IL_0150:  nop
        IL_0151:  nop
        IL_0152:  leave.s    IL_0158

      }  // end .try
      catch [mscorlib]System.Object 
      {
        IL_0154:  pop
        IL_0155:  nop
        IL_0156:  leave.s    IL_0158

      }  // end handler
      IL_0158:  nop
      IL_0159:  br         IL_01e9

      IL_015e:  ldarg.0
      IL_015f:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::shipBeingDestroyed
      IL_0164:  stloc.s    CS$4$0001
      IL_0166:  ldloc.s    CS$4$0001
      IL_0168:  brtrue.s   IL_0189

      IL_016a:  ldarg.0
      IL_016b:  dup
      IL_016c:  stloc.s    CS$2$0005
      IL_016e:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
      IL_0173:  nop
      .try
      {
        IL_0174:  ldarg.0
        IL_0175:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ShootBullet()
        IL_017a:  nop
        IL_017b:  nop
        IL_017c:  leave.s    IL_0187

      }  // end .try
      finally
      {
        IL_017e:  ldloc.s    CS$2$0005
        IL_0180:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
        IL_0185:  nop
        IL_0186:  endfinally
      }  // end handler
      IL_0187:  nop
      IL_0188:  nop
      IL_0189:  br.s       IL_01e9

      IL_018b:  ldarg.0
      IL_018c:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::shipBeingDestroyed
      IL_0191:  stloc.s    CS$4$0001
      IL_0193:  ldloc.s    CS$4$0001
      IL_0195:  brtrue.s   IL_01b7

      IL_0197:  ldarg.0
      IL_0198:  dup
      IL_0199:  stloc.s    CS$2$0005
      IL_019b:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
      IL_01a0:  nop
      .try
      {
        IL_01a1:  ldarg.0
        IL_01a2:  ldc.i4.1
        IL_01a3:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawShip(valuetype Microsoft.Samples.SpaceInvaders.ShipPosition)
        IL_01a8:  nop
        IL_01a9:  nop
        IL_01aa:  leave.s    IL_01b5

      }  // end .try
      finally
      {
        IL_01ac:  ldloc.s    CS$2$0005
        IL_01ae:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
        IL_01b3:  nop
        IL_01b4:  endfinally
      }  // end handler
      IL_01b5:  nop
      IL_01b6:  nop
      IL_01b7:  br.s       IL_01e9

      IL_01b9:  ldarg.0
      IL_01ba:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::shipBeingDestroyed
      IL_01bf:  stloc.s    CS$4$0001
      IL_01c1:  ldloc.s    CS$4$0001
      IL_01c3:  brtrue.s   IL_01e5

      IL_01c5:  ldarg.0
      IL_01c6:  dup
      IL_01c7:  stloc.s    CS$2$0005
      IL_01c9:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
      IL_01ce:  nop
      .try
      {
        IL_01cf:  ldarg.0
        IL_01d0:  ldc.i4.2
        IL_01d1:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawShip(valuetype Microsoft.Samples.SpaceInvaders.ShipPosition)
        IL_01d6:  nop
        IL_01d7:  nop
        IL_01d8:  leave.s    IL_01e3

      }  // end .try
      finally
      {
        IL_01da:  ldloc.s    CS$2$0005
        IL_01dc:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
        IL_01e1:  nop
        IL_01e2:  endfinally
      }  // end handler
      IL_01e3:  nop
      IL_01e4:  nop
      IL_01e5:  br.s       IL_01e9

      IL_01e7:  br.s       IL_01e9

      IL_01e9:  br.s       IL_0217

      IL_01eb:  nop
      IL_01ec:  br.s       IL_020e

      IL_01ee:  call       bool [mscorlib]System.Console::get_KeyAvailable()
      IL_01f3:  ldc.i4.0
      IL_01f4:  ceq
      IL_01f6:  stloc.s    CS$4$0001
      IL_01f8:  ldloc.s    CS$4$0001
      IL_01fa:  brtrue.s   IL_0205

      IL_01fc:  ldc.i4.1
      IL_01fd:  call       valuetype [mscorlib]System.ConsoleKeyInfo [mscorlib]System.Console::ReadKey(bool)
      IL_0202:  stloc.s    cki
      IL_0204:  nop
      IL_0205:  ldarg.0
      IL_0206:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::Reset()
      IL_020b:  nop
      IL_020c:  leave.s    IL_0246

      IL_020e:  nop
      IL_020f:  ldc.i4.1
      IL_0210:  stloc.s    CS$4$0001
      IL_0212:  br         IL_007d

      IL_0217:  nop
      IL_0218:  ldloc.s    CS$5$0000
      IL_021a:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_021f:  stloc.s    CS$4$0001
      IL_0221:  ldloc.s    CS$4$0001
      IL_0223:  brtrue     IL_0070

      IL_0228:  leave.s    IL_023e

    }  // end .try
    finally
    {
      IL_022a:  ldloc.s    CS$5$0000
      IL_022c:  ldnull
      IL_022d:  ceq
      IL_022f:  stloc.s    CS$4$0001
      IL_0231:  ldloc.s    CS$4$0001
      IL_0233:  brtrue.s   IL_023d

      IL_0235:  ldloc.s    CS$5$0000
      IL_0237:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_023c:  nop
      IL_023d:  endfinally
    }  // end handler
    IL_023e:  nop
    IL_023f:  ldarg.0
    IL_0240:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::Reset()
    IL_0245:  nop
    IL_0246:  nop
    IL_0247:  ret
  } // end of method Invaders::RunDemoMode

  .method private hidebysig instance class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent> 
          GetGameEvents(string fileName) cil managed
  {
    // Code size       177 (0xb1)
    .maxstack  7
    .locals init ([0] string[] lines,
             [1] class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent> sd,
             [2] int64 startOfGame,
             [3] int64 currentTicks,
             [4] string line,
             [5] string[] vals,
             [6] class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent> CS$1$0000,
             [7] string[] CS$6$0001,
             [8] int32 CS$7$0002,
             [9] char[] CS$0$0003,
             [10] bool CS$4$0004)
    IL_0000:  ldarg.1
    IL_0001:  call       string[] [mscorlib]System.IO.File::ReadAllLines(string)
    IL_0006:  stloc.0
    IL_0007:  newobj     instance void class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent>::.ctor()
    IL_000c:  stloc.1
    IL_000d:  ldc.i4.0
    IL_000e:  conv.i8
    IL_000f:  stloc.2
    IL_0010:  ldc.i4.0
    IL_0011:  conv.i8
    IL_0012:  stloc.3
    IL_0013:  ldloc.0
    IL_0014:  stloc.s    CS$6$0001
    IL_0016:  ldc.i4.0
    IL_0017:  stloc.s    CS$7$0002
    IL_0019:  br.s       IL_0098

    IL_001b:  ldloc.s    CS$6$0001
    IL_001d:  ldloc.s    CS$7$0002
    IL_001f:  ldelem.ref
    IL_0020:  stloc.s    line
    IL_0022:  ldloc.s    line
    IL_0024:  ldc.i4.1
    IL_0025:  newarr     [mscorlib]System.Char
    IL_002a:  stloc.s    CS$0$0003
    IL_002c:  ldloc.s    CS$0$0003
    IL_002e:  ldc.i4.0
    IL_002f:  ldc.i4.s   59
    IL_0031:  stelem.i2
    IL_0032:  ldloc.s    CS$0$0003
    IL_0034:  ldc.i4.1
    IL_0035:  callvirt   instance string[] [mscorlib]System.String::Split(char[],
                                                                          valuetype [mscorlib]System.StringSplitOptions)
    IL_003a:  stloc.s    vals
    IL_003c:  ldloc.s    vals
    IL_003e:  ldc.i4.2
    IL_003f:  ldelem.ref
    IL_0040:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()
    IL_0045:  call       int32 [mscorlib]System.Convert::ToInt32(string,
                                                                 class [mscorlib]System.IFormatProvider)
    IL_004a:  ldc.i4.8
    IL_004b:  ceq
    IL_004d:  ldc.i4.0
    IL_004e:  ceq
    IL_0050:  stloc.s    CS$4$0004
    IL_0052:  ldloc.s    CS$4$0004
    IL_0054:  brtrue.s   IL_0066

    IL_0056:  ldloc.s    vals
    IL_0058:  ldc.i4.4
    IL_0059:  ldelem.ref
    IL_005a:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()
    IL_005f:  call       int64 [mscorlib]System.Convert::ToInt64(string,
                                                                 class [mscorlib]System.IFormatProvider)
    IL_0064:  stloc.2
    IL_0065:  nop
    IL_0066:  ldloc.s    vals
    IL_0068:  ldc.i4.4
    IL_0069:  ldelem.ref
    IL_006a:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()
    IL_006f:  call       int64 [mscorlib]System.Convert::ToInt64(string,
                                                                 class [mscorlib]System.IFormatProvider)
    IL_0074:  ldloc.2
    IL_0075:  sub
    IL_0076:  stloc.3
    IL_0077:  ldloc.1
    IL_0078:  ldloc.3
    IL_0079:  ldloc.s    vals
    IL_007b:  ldc.i4.1
    IL_007c:  ldelem.ref
    IL_007d:  ldloc.s    vals
    IL_007f:  ldc.i4.2
    IL_0080:  ldelem.ref
    IL_0081:  ldloc.s    vals
    IL_0083:  ldc.i4.3
    IL_0084:  ldelem.ref
    IL_0085:  ldloc.3
    IL_0086:  newobj     instance void Microsoft.Samples.SpaceInvaders.GameEvent::.ctor(string,
                                                                                        string,
                                                                                        string,
                                                                                        int64)
    IL_008b:  callvirt   instance void class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent>::Add(!0,
                                                                                                                                                           !1)
    IL_0090:  nop
    IL_0091:  nop
    IL_0092:  ldloc.s    CS$7$0002
    IL_0094:  ldc.i4.1
    IL_0095:  add
    IL_0096:  stloc.s    CS$7$0002
    IL_0098:  ldloc.s    CS$7$0002
    IL_009a:  ldloc.s    CS$6$0001
    IL_009c:  ldlen
    IL_009d:  conv.i4
    IL_009e:  clt
    IL_00a0:  stloc.s    CS$4$0004
    IL_00a2:  ldloc.s    CS$4$0004
    IL_00a4:  brtrue     IL_001b

    IL_00a9:  ldloc.1
    IL_00aa:  stloc.s    CS$1$0000
    IL_00ac:  br.s       IL_00ae

    IL_00ae:  ldloc.s    CS$1$0000
    IL_00b0:  ret
  } // end of method Invaders::GetGameEvents

  .method private hidebysig instance void 
          ShowHighScores(int32 millisecondDuration) cil managed
  {
    // Code size       359 (0x167)
    .maxstack  10
    .locals init ([0] int32 i,
             [1] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0000,
             [2] string[] CS$0$0001,
             [3] object[] CS$0$0002,
             [4] bool CS$4$0003)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::HighScoreTimer
    IL_0006:  ldc.i4.0
    IL_0007:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_000c:  ldarg.0
    IL_000d:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::HighScoreTimer
    IL_0012:  ldarg.1
    IL_0013:  conv.r8
    IL_0014:  callvirt   instance void [System]System.Timers.Timer::set_Interval(float64)
    IL_0019:  call       void [mscorlib]System.Console::Clear()
    IL_001e:  nop
    IL_001f:  ldarg.0
    IL_0020:  dup
    IL_0021:  stloc.1
    IL_0022:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0027:  nop
    .try
    {
      IL_0028:  ldarg.0
      IL_0029:  ldc.i4.s   12
      IL_002b:  ldc.i4.1
      IL_002c:  ldc.i4.s   15
      IL_002e:  ldc.i4.0
      IL_002f:  ldc.i4.0
      IL_0030:  ldc.i4.4
      IL_0031:  newarr     [mscorlib]System.String
      IL_0036:  stloc.2
      IL_0037:  ldloc.2
      IL_0038:  ldc.i4.0
      IL_0039:  ldstr      "H"
      IL_003e:  stelem.ref
      IL_003f:  ldloc.2
      IL_0040:  ldc.i4.1
      IL_0041:  ldstr      "I"
      IL_0046:  stelem.ref
      IL_0047:  ldloc.2
      IL_0048:  ldc.i4.2
      IL_0049:  ldstr      "G"
      IL_004e:  stelem.ref
      IL_004f:  ldloc.2
      IL_0050:  ldc.i4.3
      IL_0051:  ldstr      "H"
      IL_0056:  stelem.ref
      IL_0057:  ldloc.2
      IL_0058:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawLetters(int32,
                                                                                               int32,
                                                                                               int32,
                                                                                               int32,
                                                                                               bool,
                                                                                               string[])
      IL_005d:  nop
      IL_005e:  ldarg.0
      IL_005f:  ldc.i4.s   12
      IL_0061:  ldc.i4.s   9
      IL_0063:  ldc.i4.s   9
      IL_0065:  ldc.i4.0
      IL_0066:  ldc.i4.0
      IL_0067:  ldc.i4.6
      IL_0068:  newarr     [mscorlib]System.String
      IL_006d:  stloc.2
      IL_006e:  ldloc.2
      IL_006f:  ldc.i4.0
      IL_0070:  ldstr      "S"
      IL_0075:  stelem.ref
      IL_0076:  ldloc.2
      IL_0077:  ldc.i4.1
      IL_0078:  ldstr      "C"
      IL_007d:  stelem.ref
      IL_007e:  ldloc.2
      IL_007f:  ldc.i4.2
      IL_0080:  ldstr      "O"
      IL_0085:  stelem.ref
      IL_0086:  ldloc.2
      IL_0087:  ldc.i4.3
      IL_0088:  ldstr      "R"
      IL_008d:  stelem.ref
      IL_008e:  ldloc.2
      IL_008f:  ldc.i4.4
      IL_0090:  ldstr      "E"
      IL_0095:  stelem.ref
      IL_0096:  ldloc.2
      IL_0097:  ldc.i4.5
      IL_0098:  ldstr      "S"
      IL_009d:  stelem.ref
      IL_009e:  ldloc.2
      IL_009f:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawLetters(int32,
                                                                                               int32,
                                                                                               int32,
                                                                                               int32,
                                                                                               bool,
                                                                                               string[])
      IL_00a4:  nop
      IL_00a5:  ldc.i4.0
      IL_00a6:  stloc.0
      IL_00a7:  br         IL_0139

      IL_00ac:  ldc.i4.s   11
      IL_00ae:  ldc.i4.s   17
      IL_00b0:  ldloc.0
      IL_00b1:  ldc.i4.2
      IL_00b2:  mul
      IL_00b3:  add
      IL_00b4:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_00b9:  nop
      IL_00ba:  ldarg.0
      IL_00bb:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_CurrentCulture()
      IL_00c0:  ldstr      "{0,-8}"
      IL_00c5:  ldc.i4.1
      IL_00c6:  newarr     [mscorlib]System.Object
      IL_00cb:  stloc.3
      IL_00cc:  ldloc.3
      IL_00cd:  ldc.i4.0
      IL_00ce:  ldarg.0
      IL_00cf:  ldfld      string[] Microsoft.Samples.SpaceInvaders.Invaders::scoreNames
      IL_00d4:  ldloc.0
      IL_00d5:  ldelem.ref
      IL_00d6:  stelem.ref
      IL_00d7:  ldloc.3
      IL_00d8:  call       string [mscorlib]System.String::Format(class [mscorlib]System.IFormatProvider,
                                                                  string,
                                                                  object[])
      IL_00dd:  ldstr      "................................. "
      IL_00e2:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_CurrentCulture()
      IL_00e7:  ldstr      "{0}  {1:00000}"
      IL_00ec:  ldc.i4.2
      IL_00ed:  newarr     [mscorlib]System.Object
      IL_00f2:  stloc.3
      IL_00f3:  ldloc.3
      IL_00f4:  ldc.i4.0
      IL_00f5:  ldarg.0
      IL_00f6:  ldloc.0
      IL_00f7:  ldc.i4.1
      IL_00f8:  add
      IL_00f9:  ldc.i4.0
      IL_00fa:  call       instance string Microsoft.Samples.SpaceInvaders.Invaders::GetVal(int32,
                                                                                            int32)
      IL_00ff:  stelem.ref
      IL_0100:  ldloc.3
      IL_0101:  ldc.i4.1
      IL_0102:  ldarg.0
      IL_0103:  ldloc.0
      IL_0104:  ldc.i4.1
      IL_0105:  add
      IL_0106:  ldc.i4.1
      IL_0107:  call       instance string Microsoft.Samples.SpaceInvaders.Invaders::GetVal(int32,
                                                                                            int32)
      IL_010c:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_CurrentCulture()
      IL_0111:  call       int32 [mscorlib]System.Convert::ToInt32(string,
                                                                   class [mscorlib]System.IFormatProvider)
      IL_0116:  box        [mscorlib]System.Int32
      IL_011b:  stelem.ref
      IL_011c:  ldloc.3
      IL_011d:  call       string [mscorlib]System.String::Format(class [mscorlib]System.IFormatProvider,
                                                                  string,
                                                                  object[])
      IL_0122:  call       string [mscorlib]System.String::Concat(string,
                                                                  string,
                                                                  string)
      IL_0127:  ldarg.0
      IL_0128:  ldloc.0
      IL_0129:  call       instance valuetype [mscorlib]System.ConsoleColor Microsoft.Samples.SpaceInvaders.Invaders::GetNextColor(int32)
      IL_012e:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::WriteEntry(string,
                                                                                              valuetype [mscorlib]System.ConsoleColor)
      IL_0133:  nop
      IL_0134:  nop
      IL_0135:  ldloc.0
      IL_0136:  ldc.i4.1
      IL_0137:  add
      IL_0138:  stloc.0
      IL_0139:  ldloc.0
      IL_013a:  ldc.i4.s   10
      IL_013c:  clt
      IL_013e:  stloc.s    CS$4$0003
      IL_0140:  ldloc.s    CS$4$0003
      IL_0142:  brtrue     IL_00ac

      IL_0147:  nop
      IL_0148:  leave.s    IL_0152

    }  // end .try
    finally
    {
      IL_014a:  ldloc.1
      IL_014b:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0150:  nop
      IL_0151:  endfinally
    }  // end handler
    IL_0152:  nop
    IL_0153:  ldarg.0
    IL_0154:  ldc.i4.1
    IL_0155:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::highScoreDisplayed
    IL_015a:  ldarg.0
    IL_015b:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::HighScoreTimer
    IL_0160:  ldc.i4.1
    IL_0161:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_0166:  ret
  } // end of method Invaders::ShowHighScores

  .method private hidebysig instance string 
          GetVal(int32 element,
                 int32 index) cil managed
  {
    // Code size       19 (0x13)
    .maxstack  2
    .locals init ([0] string CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance !1 class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Item(!0)
    IL_000c:  ldarg.2
    IL_000d:  ldelem.ref
    IL_000e:  stloc.0
    IL_000f:  br.s       IL_0011

    IL_0011:  ldloc.0
    IL_0012:  ret
  } // end of method Invaders::GetVal

  .method private hidebysig instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> 
          GetScores() cil managed
  {
    // Code size       327 (0x147)
    .maxstack  9
    .locals init ([0] class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> scores,
             [1] class [mscorlib]Microsoft.Win32.RegistryKey rk,
             [2] int32 i,
             [3] string s,
             [4] class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> CS$1$0000,
             [5] char CS$0$0001,
             [6] int32 CS$0$0002,
             [7] string[] CS$0$0003,
             [8] bool CS$4$0004)
    IL_0000:  newobj     instance void class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::.ctor()
    IL_0005:  stloc.0
    IL_0006:  ldnull
    IL_0007:  stloc.1
    .try
    {
      .try
      {
        IL_0008:  ldsfld     class [mscorlib]Microsoft.Win32.RegistryKey [mscorlib]Microsoft.Win32.Registry::LocalMachine
        IL_000d:  ldstr      "Software\\Demos\\ConsoleInvaders"
        IL_0012:  callvirt   instance class [mscorlib]Microsoft.Win32.RegistryKey [mscorlib]Microsoft.Win32.RegistryKey::CreateSubKey(string)
        IL_0017:  stloc.1
        IL_0018:  ldc.i4.0
        IL_0019:  stloc.2
        IL_001a:  br         IL_00ad

        IL_001f:  ldc.i4.s   65
        IL_0021:  ldloc.2
        IL_0022:  add
        IL_0023:  conv.u2
        IL_0024:  stloc.s    CS$0$0001
        IL_0026:  ldloca.s   CS$0$0001
        IL_0028:  call       class [mscorlib]System.Threading.Thread [mscorlib]System.Threading.Thread::get_CurrentThread()
        IL_002d:  callvirt   instance class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Threading.Thread::get_CurrentCulture()
        IL_0032:  call       instance string [mscorlib]System.Char::ToString(class [mscorlib]System.IFormatProvider)
        IL_0037:  stloc.3
        IL_0038:  ldloc.0
        IL_0039:  ldloc.2
        IL_003a:  ldc.i4.1
        IL_003b:  add
        IL_003c:  ldloc.1
        IL_003d:  ldstr      "Score"
        IL_0042:  ldloc.2
        IL_0043:  ldc.i4.1
        IL_0044:  add
        IL_0045:  stloc.s    CS$0$0002
        IL_0047:  ldloca.s   CS$0$0002
        IL_0049:  call       class [mscorlib]System.Threading.Thread [mscorlib]System.Threading.Thread::get_CurrentThread()
        IL_004e:  callvirt   instance class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Threading.Thread::get_CurrentCulture()
        IL_0053:  call       instance string [mscorlib]System.Int32::ToString(class [mscorlib]System.IFormatProvider)
        IL_0058:  call       string [mscorlib]System.String::Concat(string,
                                                                    string)
        IL_005d:  ldc.i4.2
        IL_005e:  newarr     [mscorlib]System.String
        IL_0063:  stloc.s    CS$0$0003
        IL_0065:  ldloc.s    CS$0$0003
        IL_0067:  ldc.i4.0
        IL_0068:  ldloc.3
        IL_0069:  ldloc.3
        IL_006a:  ldloc.3
        IL_006b:  call       string [mscorlib]System.String::Concat(string,
                                                                    string,
                                                                    string)
        IL_0070:  stelem.ref
        IL_0071:  ldloc.s    CS$0$0003
        IL_0073:  ldc.i4.1
        IL_0074:  ldc.i4     0x1388
        IL_0079:  ldloc.2
        IL_007a:  ldc.i4     0x1f4
        IL_007f:  mul
        IL_0080:  sub
        IL_0081:  stloc.s    CS$0$0002
        IL_0083:  ldloca.s   CS$0$0002
        IL_0085:  call       class [mscorlib]System.Threading.Thread [mscorlib]System.Threading.Thread::get_CurrentThread()
        IL_008a:  callvirt   instance class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Threading.Thread::get_CurrentCulture()
        IL_008f:  call       instance string [mscorlib]System.Int32::ToString(class [mscorlib]System.IFormatProvider)
        IL_0094:  stelem.ref
        IL_0095:  ldloc.s    CS$0$0003
        IL_0097:  ldc.i4.0
        IL_0098:  callvirt   instance object [mscorlib]Microsoft.Win32.RegistryKey::GetValue(string,
                                                                                             object,
                                                                                             valuetype [mscorlib]Microsoft.Win32.RegistryValueOptions)
        IL_009d:  castclass  string[]
        IL_00a2:  callvirt   instance void class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::Add(!0,
                                                                                                                        !1)
        IL_00a7:  nop
        IL_00a8:  nop
        IL_00a9:  ldloc.2
        IL_00aa:  ldc.i4.1
        IL_00ab:  add
        IL_00ac:  stloc.2
        IL_00ad:  ldloc.2
        IL_00ae:  ldc.i4.s   10
        IL_00b0:  clt
        IL_00b2:  stloc.s    CS$4$0004
        IL_00b4:  ldloc.s    CS$4$0004
        IL_00b6:  brtrue     IL_001f

        IL_00bb:  nop
        IL_00bc:  leave.s    IL_0132

      }  // end .try
      catch [mscorlib]System.Object 
      {
        IL_00be:  pop
        IL_00bf:  ldc.i4.0
        IL_00c0:  stloc.2
        IL_00c1:  br.s       IL_0124

        IL_00c3:  ldc.i4.s   65
        IL_00c5:  ldloc.2
        IL_00c6:  add
        IL_00c7:  conv.u2
        IL_00c8:  stloc.s    CS$0$0001
        IL_00ca:  ldloca.s   CS$0$0001
        IL_00cc:  call       class [mscorlib]System.Threading.Thread [mscorlib]System.Threading.Thread::get_CurrentThread()
        IL_00d1:  callvirt   instance class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Threading.Thread::get_CurrentCulture()
        IL_00d6:  call       instance string [mscorlib]System.Char::ToString(class [mscorlib]System.IFormatProvider)
        IL_00db:  stloc.3
        IL_00dc:  ldloc.0
        IL_00dd:  ldloc.2
        IL_00de:  ldc.i4.1
        IL_00df:  add
        IL_00e0:  ldc.i4.2
        IL_00e1:  newarr     [mscorlib]System.String
        IL_00e6:  stloc.s    CS$0$0003
        IL_00e8:  ldloc.s    CS$0$0003
        IL_00ea:  ldc.i4.0
        IL_00eb:  ldloc.3
        IL_00ec:  ldloc.3
        IL_00ed:  ldloc.3
        IL_00ee:  call       string [mscorlib]System.String::Concat(string,
                                                                    string,
                                                                    string)
        IL_00f3:  stelem.ref
        IL_00f4:  ldloc.s    CS$0$0003
        IL_00f6:  ldc.i4.1
        IL_00f7:  ldc.i4     0x1388
        IL_00fc:  ldloc.2
        IL_00fd:  ldc.i4     0x1f4
        IL_0102:  mul
        IL_0103:  sub
        IL_0104:  stloc.s    CS$0$0002
        IL_0106:  ldloca.s   CS$0$0002
        IL_0108:  call       class [mscorlib]System.Threading.Thread [mscorlib]System.Threading.Thread::get_CurrentThread()
        IL_010d:  callvirt   instance class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Threading.Thread::get_CurrentCulture()
        IL_0112:  call       instance string [mscorlib]System.Int32::ToString(class [mscorlib]System.IFormatProvider)
        IL_0117:  stelem.ref
        IL_0118:  ldloc.s    CS$0$0003
        IL_011a:  callvirt   instance void class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::set_Item(!0,
                                                                                                                             !1)
        IL_011f:  nop
        IL_0120:  ldloc.2
        IL_0121:  ldc.i4.1
        IL_0122:  add
        IL_0123:  stloc.2
        IL_0124:  ldloc.2
        IL_0125:  ldc.i4.s   10
        IL_0127:  clt
        IL_0129:  stloc.s    CS$4$0004
        IL_012b:  ldloc.s    CS$4$0004
        IL_012d:  brtrue.s   IL_00c3

        IL_012f:  nop
        IL_0130:  leave.s    IL_0132

      }  // end handler
      IL_0132:  nop
      IL_0133:  leave.s    IL_013e

    }  // end .try
    finally
    {
      IL_0135:  ldloc.1
      IL_0136:  callvirt   instance void [mscorlib]Microsoft.Win32.RegistryKey::Close()
      IL_013b:  nop
      IL_013c:  nop
      IL_013d:  endfinally
    }  // end handler
    IL_013e:  nop
    IL_013f:  ldloc.0
    IL_0140:  stloc.s    CS$1$0000
    IL_0142:  br.s       IL_0144

    IL_0144:  ldloc.s    CS$1$0000
    IL_0146:  ret
  } // end of method Invaders::GetScores

  .method private hidebysig instance void 
          SetScores() cil managed
  {
    // Code size       282 (0x11a)
    .maxstack  4
    .locals init ([0] class [mscorlib]Microsoft.Win32.RegistryKey rk)
    IL_0000:  ldnull
    IL_0001:  stloc.0
    .try
    {
      .try
      {
        IL_0002:  ldsfld     class [mscorlib]Microsoft.Win32.RegistryKey [mscorlib]Microsoft.Win32.Registry::LocalMachine
        IL_0007:  ldstr      "Software\\Demos\\ConsoleInvaders"
        IL_000c:  ldc.i4.1
        IL_000d:  callvirt   instance class [mscorlib]Microsoft.Win32.RegistryKey [mscorlib]Microsoft.Win32.RegistryKey::OpenSubKey(string,
                                                                                                                                    bool)
        IL_0012:  stloc.0
        IL_0013:  ldloc.0
        IL_0014:  ldstr      "Score1"
        IL_0019:  ldarg.0
        IL_001a:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
        IL_001f:  ldc.i4.1
        IL_0020:  callvirt   instance !1 class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Item(!0)
        IL_0025:  callvirt   instance void [mscorlib]Microsoft.Win32.RegistryKey::SetValue(string,
                                                                                           object)
        IL_002a:  nop
        IL_002b:  ldloc.0
        IL_002c:  ldstr      "Score2"
        IL_0031:  ldarg.0
        IL_0032:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
        IL_0037:  ldc.i4.2
        IL_0038:  callvirt   instance !1 class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Item(!0)
        IL_003d:  callvirt   instance void [mscorlib]Microsoft.Win32.RegistryKey::SetValue(string,
                                                                                           object)
        IL_0042:  nop
        IL_0043:  ldloc.0
        IL_0044:  ldstr      "Score3"
        IL_0049:  ldarg.0
        IL_004a:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
        IL_004f:  ldc.i4.3
        IL_0050:  callvirt   instance !1 class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Item(!0)
        IL_0055:  callvirt   instance void [mscorlib]Microsoft.Win32.RegistryKey::SetValue(string,
                                                                                           object)
        IL_005a:  nop
        IL_005b:  ldloc.0
        IL_005c:  ldstr      "Score4"
        IL_0061:  ldarg.0
        IL_0062:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
        IL_0067:  ldc.i4.4
        IL_0068:  callvirt   instance !1 class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Item(!0)
        IL_006d:  callvirt   instance void [mscorlib]Microsoft.Win32.RegistryKey::SetValue(string,
                                                                                           object)
        IL_0072:  nop
        IL_0073:  ldloc.0
        IL_0074:  ldstr      "Score5"
        IL_0079:  ldarg.0
        IL_007a:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
        IL_007f:  ldc.i4.5
        IL_0080:  callvirt   instance !1 class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Item(!0)
        IL_0085:  callvirt   instance void [mscorlib]Microsoft.Win32.RegistryKey::SetValue(string,
                                                                                           object)
        IL_008a:  nop
        IL_008b:  ldloc.0
        IL_008c:  ldstr      "Score6"
        IL_0091:  ldarg.0
        IL_0092:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
        IL_0097:  ldc.i4.6
        IL_0098:  callvirt   instance !1 class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Item(!0)
        IL_009d:  callvirt   instance void [mscorlib]Microsoft.Win32.RegistryKey::SetValue(string,
                                                                                           object)
        IL_00a2:  nop
        IL_00a3:  ldloc.0
        IL_00a4:  ldstr      "Score7"
        IL_00a9:  ldarg.0
        IL_00aa:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
        IL_00af:  ldc.i4.7
        IL_00b0:  callvirt   instance !1 class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Item(!0)
        IL_00b5:  callvirt   instance void [mscorlib]Microsoft.Win32.RegistryKey::SetValue(string,
                                                                                           object)
        IL_00ba:  nop
        IL_00bb:  ldloc.0
        IL_00bc:  ldstr      "Score8"
        IL_00c1:  ldarg.0
        IL_00c2:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
        IL_00c7:  ldc.i4.8
        IL_00c8:  callvirt   instance !1 class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Item(!0)
        IL_00cd:  callvirt   instance void [mscorlib]Microsoft.Win32.RegistryKey::SetValue(string,
                                                                                           object)
        IL_00d2:  nop
        IL_00d3:  ldloc.0
        IL_00d4:  ldstr      "Score9"
        IL_00d9:  ldarg.0
        IL_00da:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
        IL_00df:  ldc.i4.s   9
        IL_00e1:  callvirt   instance !1 class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Item(!0)
        IL_00e6:  callvirt   instance void [mscorlib]Microsoft.Win32.RegistryKey::SetValue(string,
                                                                                           object)
        IL_00eb:  nop
        IL_00ec:  ldloc.0
        IL_00ed:  ldstr      "Score10"
        IL_00f2:  ldarg.0
        IL_00f3:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
        IL_00f8:  ldc.i4.s   10
        IL_00fa:  callvirt   instance !1 class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Item(!0)
        IL_00ff:  callvirt   instance void [mscorlib]Microsoft.Win32.RegistryKey::SetValue(string,
                                                                                           object)
        IL_0104:  nop
        IL_0105:  nop
        IL_0106:  leave.s    IL_010c

      }  // end .try
      catch [mscorlib]System.Object 
      {
        IL_0108:  pop
        IL_0109:  nop
        IL_010a:  leave.s    IL_010c

      }  // end handler
      IL_010c:  nop
      IL_010d:  leave.s    IL_0118

    }  // end .try
    finally
    {
      IL_010f:  ldloc.0
      IL_0110:  callvirt   instance void [mscorlib]Microsoft.Win32.RegistryKey::Close()
      IL_0115:  nop
      IL_0116:  nop
      IL_0117:  endfinally
    }  // end handler
    IL_0118:  nop
    IL_0119:  ret
  } // end of method Invaders::SetScores

  .method private hidebysig instance void 
          WriteScore(int32 scoreToWrite) cil managed
  {
    // Code size       332 (0x14c)
    .maxstack  6
    .locals init ([0] int32 valToWriteOver,
             [1] int32 i,
             [2] string initials,
             [3] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0000,
             [4] bool CS$4$0001,
             [5] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0002,
             [6] string[] CS$0$0003)
    IL_0000:  ldarg.0
    IL_0001:  dup
    IL_0002:  stloc.3
    IL_0003:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0008:  nop
    .try
    {
      IL_0009:  ldc.i4.0
      IL_000a:  stloc.0
      IL_000b:  ldc.i4.0
      IL_000c:  stloc.1
      IL_000d:  br.s       IL_0051

      IL_000f:  ldarg.1
      IL_0010:  ldarg.0
      IL_0011:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
      IL_0016:  callvirt   instance class [mscorlib]System.Collections.Generic.'IList`1'<!1> class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Values()
      IL_001b:  ldloc.1
      IL_001c:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'IList`1'<string[]>::get_Item(int32)
      IL_0021:  ldc.i4.1
      IL_0022:  ldelem.ref
      IL_0023:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()
      IL_0028:  call       int32 [mscorlib]System.Convert::ToInt32(string,
                                                                   class [mscorlib]System.IFormatProvider)
      IL_002d:  cgt
      IL_002f:  ldc.i4.0
      IL_0030:  ceq
      IL_0032:  stloc.s    CS$4$0001
      IL_0034:  ldloc.s    CS$4$0001
      IL_0036:  brtrue.s   IL_004c

      IL_0038:  ldarg.0
      IL_0039:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
      IL_003e:  callvirt   instance class [mscorlib]System.Collections.Generic.'IList`1'<!0> class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Keys()
      IL_0043:  ldloc.1
      IL_0044:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'IList`1'<int32>::get_Item(int32)
      IL_0049:  stloc.0
      IL_004a:  br.s       IL_0065

      IL_004c:  nop
      IL_004d:  ldloc.1
      IL_004e:  ldc.i4.1
      IL_004f:  add
      IL_0050:  stloc.1
      IL_0051:  ldloc.1
      IL_0052:  ldarg.0
      IL_0053:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
      IL_0058:  callvirt   instance int32 class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Count()
      IL_005d:  clt
      IL_005f:  stloc.s    CS$4$0001
      IL_0061:  ldloc.s    CS$4$0001
      IL_0063:  brtrue.s   IL_000f

      IL_0065:  ldloc.0
      IL_0066:  ldc.i4.0
      IL_0067:  cgt
      IL_0069:  ldc.i4.0
      IL_006a:  ceq
      IL_006c:  stloc.s    CS$4$0001
      IL_006e:  ldloc.s    CS$4$0001
      IL_0070:  brtrue     IL_013f

      IL_0075:  call       void [mscorlib]System.Console::Clear()
      IL_007a:  nop
      IL_007b:  ldarg.0
      IL_007c:  dup
      IL_007d:  stloc.s    CS$2$0002
      IL_007f:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
      IL_0084:  nop
      .try
      {
        IL_0085:  ldc.i4.s   15
        IL_0087:  ldc.i4.6
        IL_0088:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                              int32)
        IL_008d:  nop
        IL_008e:  ldc.i4.s   11
        IL_0090:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
        IL_0095:  ldstr      "You made the high score table!"
        IL_009a:  call       void [mscorlib]System.Console::Write(string)
        IL_009f:  nop
        IL_00a0:  ldc.i4.s   15
        IL_00a2:  call       int32 [mscorlib]System.Console::get_CursorTop()
        IL_00a7:  ldc.i4.2
        IL_00a8:  add
        IL_00a9:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                              int32)
        IL_00ae:  nop
        IL_00af:  ldstr      "Please enter your initals ==> AAA"
        IL_00b4:  call       void [mscorlib]System.Console::Write(string)
        IL_00b9:  nop
        IL_00ba:  call       int32 [mscorlib]System.Console::get_CursorLeft()
        IL_00bf:  ldc.i4.3
        IL_00c0:  sub
        IL_00c1:  call       int32 [mscorlib]System.Console::get_CursorTop()
        IL_00c6:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                              int32)
        IL_00cb:  nop
        IL_00cc:  nop
        IL_00cd:  leave.s    IL_00d8

      }  // end .try
      finally
      {
        IL_00cf:  ldloc.s    CS$2$0002
        IL_00d1:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
        IL_00d6:  nop
        IL_00d7:  endfinally
      }  // end handler
      IL_00d8:  nop
      IL_00d9:  ldarg.0
      IL_00da:  call       instance string Microsoft.Samples.SpaceInvaders.Invaders::CaptureInitials()
      IL_00df:  stloc.2
      IL_00e0:  ldc.i4.s   10
      IL_00e2:  stloc.1
      IL_00e3:  br.s       IL_0104

      IL_00e5:  ldarg.0
      IL_00e6:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
      IL_00eb:  ldloc.1
      IL_00ec:  ldarg.0
      IL_00ed:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
      IL_00f2:  ldloc.1
      IL_00f3:  ldc.i4.1
      IL_00f4:  sub
      IL_00f5:  callvirt   instance !1 class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Item(!0)
      IL_00fa:  callvirt   instance void class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::set_Item(!0,
                                                                                                                           !1)
      IL_00ff:  nop
      IL_0100:  ldloc.1
      IL_0101:  ldc.i4.1
      IL_0102:  sub
      IL_0103:  stloc.1
      IL_0104:  ldloc.1
      IL_0105:  ldloc.0
      IL_0106:  cgt
      IL_0108:  stloc.s    CS$4$0001
      IL_010a:  ldloc.s    CS$4$0001
      IL_010c:  brtrue.s   IL_00e5

      IL_010e:  ldarg.0
      IL_010f:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
      IL_0114:  ldloc.0
      IL_0115:  ldc.i4.2
      IL_0116:  newarr     [mscorlib]System.String
      IL_011b:  stloc.s    CS$0$0003
      IL_011d:  ldloc.s    CS$0$0003
      IL_011f:  ldc.i4.0
      IL_0120:  ldloc.2
      IL_0121:  stelem.ref
      IL_0122:  ldloc.s    CS$0$0003
      IL_0124:  ldc.i4.1
      IL_0125:  ldarga.s   scoreToWrite
      IL_0127:  call       class [mscorlib]System.Threading.Thread [mscorlib]System.Threading.Thread::get_CurrentThread()
      IL_012c:  callvirt   instance class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Threading.Thread::get_CurrentCulture()
      IL_0131:  call       instance string [mscorlib]System.Int32::ToString(class [mscorlib]System.IFormatProvider)
      IL_0136:  stelem.ref
      IL_0137:  ldloc.s    CS$0$0003
      IL_0139:  callvirt   instance void class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::set_Item(!0,
                                                                                                                           !1)
      IL_013e:  nop
      IL_013f:  nop
      IL_0140:  leave.s    IL_014a

    }  // end .try
    finally
    {
      IL_0142:  ldloc.3
      IL_0143:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0148:  nop
      IL_0149:  endfinally
    }  // end handler
    IL_014a:  nop
    IL_014b:  ret
  } // end of method Invaders::WriteScore

  .method private hidebysig instance string 
          CaptureInitials() cil managed
  {
    // Code size       735 (0x2df)
    .maxstack  4
    .locals init ([0] char curA,
             [1] char curB,
             [2] char curC,
             [3] int32 position,
             [4] valuetype [mscorlib]System.ConsoleKeyInfo cki,
             [5] string CS$1$0000,
             [6] valuetype [mscorlib]System.ConsoleKey CS$4$0001,
             [7] valuetype [mscorlib]System.ConsoleKey CS$0$0002,
             [8] bool CS$4$0003)
    IL_0000:  ldc.i4.s   65
    IL_0002:  stloc.0
    IL_0003:  ldc.i4.s   65
    IL_0005:  stloc.1
    IL_0006:  ldc.i4.s   65
    IL_0008:  stloc.2
    IL_0009:  ldc.i4.0
    IL_000a:  stloc.3
    IL_000b:  ldarg.0
    IL_000c:  ldc.i4.1
    IL_000d:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::gettingName
    IL_0012:  br         IL_02d4

    IL_0017:  ldc.i4.s   100
    IL_0019:  call       void [mscorlib]System.Console::set_CursorSize(int32)
    IL_001e:  ldc.i4.1
    IL_001f:  call       void [mscorlib]System.Console::set_CursorVisible(bool)
    IL_0024:  ldc.i4.1
    IL_0025:  call       valuetype [mscorlib]System.ConsoleKeyInfo [mscorlib]System.Console::ReadKey(bool)
    IL_002a:  stloc.s    cki
    IL_002c:  ldloca.s   cki
    IL_002e:  call       instance valuetype [mscorlib]System.ConsoleKey [mscorlib]System.ConsoleKeyInfo::get_Key()
    IL_0033:  stloc.s    CS$4$0001
    IL_0035:  ldloc.s    CS$4$0001
    IL_0037:  stloc.s    CS$0$0002
    IL_0039:  ldloc.s    CS$0$0002
    IL_003b:  ldc.i4.8
    IL_003c:  beq        IL_01c6

    IL_0041:  ldloc.s    CS$0$0002
    IL_0043:  ldc.i4.s   13
    IL_0045:  beq        IL_01ec

    IL_004a:  ldloc.s    CS$0$0002
    IL_004c:  ldc.i4.s   32
    IL_004e:  sub
    IL_004f:  switch     ( 
                          IL_01a7,
                          IL_0245,
                          IL_0245,
                          IL_0245,
                          IL_0245,
                          IL_0123,
                          IL_00d0,
                          IL_0165,
                          IL_007d)
    IL_0078:  br         IL_0245

    IL_007d:  ldloc.3
    IL_007e:  ldc.i4.0
    IL_007f:  ceq
    IL_0081:  ldc.i4.0
    IL_0082:  ceq
    IL_0084:  stloc.s    CS$4$0003
    IL_0086:  ldloc.s    CS$4$0003
    IL_0088:  brtrue.s   IL_0096

    IL_008a:  ldarg.0
    IL_008b:  ldloca.s   curA
    IL_008d:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::SetValUp(char&)
    IL_0092:  nop
    IL_0093:  nop
    IL_0094:  br.s       IL_00b9

    IL_0096:  ldloc.3
    IL_0097:  ldc.i4.1
    IL_0098:  ceq
    IL_009a:  ldc.i4.0
    IL_009b:  ceq
    IL_009d:  stloc.s    CS$4$0003
    IL_009f:  ldloc.s    CS$4$0003
    IL_00a1:  brtrue.s   IL_00af

    IL_00a3:  ldarg.0
    IL_00a4:  ldloca.s   curB
    IL_00a6:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::SetValUp(char&)
    IL_00ab:  nop
    IL_00ac:  nop
    IL_00ad:  br.s       IL_00b9

    IL_00af:  ldarg.0
    IL_00b0:  ldloca.s   curC
    IL_00b2:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::SetValUp(char&)
    IL_00b7:  nop
    IL_00b8:  nop
    IL_00b9:  call       int32 [mscorlib]System.Console::get_CursorLeft()
    IL_00be:  ldc.i4.1
    IL_00bf:  sub
    IL_00c0:  call       int32 [mscorlib]System.Console::get_CursorTop()
    IL_00c5:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_00ca:  nop
    IL_00cb:  br         IL_0245

    IL_00d0:  ldloc.3
    IL_00d1:  ldc.i4.0
    IL_00d2:  ceq
    IL_00d4:  ldc.i4.0
    IL_00d5:  ceq
    IL_00d7:  stloc.s    CS$4$0003
    IL_00d9:  ldloc.s    CS$4$0003
    IL_00db:  brtrue.s   IL_00e9

    IL_00dd:  ldarg.0
    IL_00de:  ldloca.s   curA
    IL_00e0:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::SetValDown(char&)
    IL_00e5:  nop
    IL_00e6:  nop
    IL_00e7:  br.s       IL_010c

    IL_00e9:  ldloc.3
    IL_00ea:  ldc.i4.1
    IL_00eb:  ceq
    IL_00ed:  ldc.i4.0
    IL_00ee:  ceq
    IL_00f0:  stloc.s    CS$4$0003
    IL_00f2:  ldloc.s    CS$4$0003
    IL_00f4:  brtrue.s   IL_0102

    IL_00f6:  ldarg.0
    IL_00f7:  ldloca.s   curB
    IL_00f9:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::SetValDown(char&)
    IL_00fe:  nop
    IL_00ff:  nop
    IL_0100:  br.s       IL_010c

    IL_0102:  ldarg.0
    IL_0103:  ldloca.s   curC
    IL_0105:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::SetValDown(char&)
    IL_010a:  nop
    IL_010b:  nop
    IL_010c:  call       int32 [mscorlib]System.Console::get_CursorLeft()
    IL_0111:  ldc.i4.1
    IL_0112:  sub
    IL_0113:  call       int32 [mscorlib]System.Console::get_CursorTop()
    IL_0118:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_011d:  nop
    IL_011e:  br         IL_0245

    IL_0123:  ldloc.3
    IL_0124:  ldc.i4.0
    IL_0125:  cgt
    IL_0127:  ldc.i4.0
    IL_0128:  ceq
    IL_012a:  stloc.s    CS$4$0003
    IL_012c:  ldloc.s    CS$4$0003
    IL_012e:  brtrue.s   IL_0149

    IL_0130:  ldloc.3
    IL_0131:  ldc.i4.1
    IL_0132:  sub
    IL_0133:  stloc.3
    IL_0134:  call       int32 [mscorlib]System.Console::get_CursorLeft()
    IL_0139:  ldc.i4.1
    IL_013a:  sub
    IL_013b:  call       int32 [mscorlib]System.Console::get_CursorTop()
    IL_0140:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_0145:  nop
    IL_0146:  nop
    IL_0147:  br.s       IL_0160

    IL_0149:  ldloc.3
    IL_014a:  ldc.i4.2
    IL_014b:  add
    IL_014c:  stloc.3
    IL_014d:  call       int32 [mscorlib]System.Console::get_CursorLeft()
    IL_0152:  ldc.i4.2
    IL_0153:  add
    IL_0154:  call       int32 [mscorlib]System.Console::get_CursorTop()
    IL_0159:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_015e:  nop
    IL_015f:  nop
    IL_0160:  br         IL_0245

    IL_0165:  ldloc.3
    IL_0166:  ldc.i4.2
    IL_0167:  clt
    IL_0169:  ldc.i4.0
    IL_016a:  ceq
    IL_016c:  stloc.s    CS$4$0003
    IL_016e:  ldloc.s    CS$4$0003
    IL_0170:  brtrue.s   IL_018b

    IL_0172:  ldloc.3
    IL_0173:  ldc.i4.1
    IL_0174:  add
    IL_0175:  stloc.3
    IL_0176:  call       int32 [mscorlib]System.Console::get_CursorLeft()
    IL_017b:  ldc.i4.1
    IL_017c:  add
    IL_017d:  call       int32 [mscorlib]System.Console::get_CursorTop()
    IL_0182:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_0187:  nop
    IL_0188:  nop
    IL_0189:  br.s       IL_01a2

    IL_018b:  ldloc.3
    IL_018c:  ldc.i4.2
    IL_018d:  sub
    IL_018e:  stloc.3
    IL_018f:  call       int32 [mscorlib]System.Console::get_CursorLeft()
    IL_0194:  ldc.i4.2
    IL_0195:  sub
    IL_0196:  call       int32 [mscorlib]System.Console::get_CursorTop()
    IL_019b:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_01a0:  nop
    IL_01a1:  nop
    IL_01a2:  br         IL_0245

    IL_01a7:  ldloc.3
    IL_01a8:  ldc.i4.1
    IL_01a9:  ceq
    IL_01ab:  ldc.i4.0
    IL_01ac:  ceq
    IL_01ae:  stloc.s    CS$4$0003
    IL_01b0:  ldloc.s    CS$4$0003
    IL_01b2:  brtrue.s   IL_01c4

    IL_01b4:  ldstr      " "
    IL_01b9:  call       void [mscorlib]System.Console::Write(string)
    IL_01be:  nop
    IL_01bf:  ldloc.3
    IL_01c0:  ldc.i4.1
    IL_01c1:  add
    IL_01c2:  stloc.3
    IL_01c3:  nop
    IL_01c4:  br.s       IL_0245

    IL_01c6:  ldloc.3
    IL_01c7:  ldc.i4.0
    IL_01c8:  cgt
    IL_01ca:  ldc.i4.0
    IL_01cb:  ceq
    IL_01cd:  stloc.s    CS$4$0003
    IL_01cf:  ldloc.s    CS$4$0003
    IL_01d1:  brtrue.s   IL_01ea

    IL_01d3:  call       int32 [mscorlib]System.Console::get_CursorLeft()
    IL_01d8:  ldc.i4.1
    IL_01d9:  sub
    IL_01da:  call       int32 [mscorlib]System.Console::get_CursorTop()
    IL_01df:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_01e4:  nop
    IL_01e5:  ldloc.3
    IL_01e6:  ldc.i4.1
    IL_01e7:  sub
    IL_01e8:  stloc.3
    IL_01e9:  nop
    IL_01ea:  br.s       IL_0245

    IL_01ec:  ldloc.3
    IL_01ed:  ldc.i4.2
    IL_01ee:  ceq
    IL_01f0:  ldc.i4.0
    IL_01f1:  ceq
    IL_01f3:  stloc.s    CS$4$0003
    IL_01f5:  ldloc.s    CS$4$0003
    IL_01f7:  brtrue.s   IL_023e

    IL_01f9:  ldc.i4.0
    IL_01fa:  call       void [mscorlib]System.Console::set_CursorVisible(bool)
    IL_01ff:  ldloca.s   curA
    IL_0201:  call       class [mscorlib]System.Threading.Thread [mscorlib]System.Threading.Thread::get_CurrentThread()
    IL_0206:  callvirt   instance class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Threading.Thread::get_CurrentCulture()
    IL_020b:  call       instance string [mscorlib]System.Char::ToString(class [mscorlib]System.IFormatProvider)
    IL_0210:  ldloca.s   curB
    IL_0212:  call       class [mscorlib]System.Threading.Thread [mscorlib]System.Threading.Thread::get_CurrentThread()
    IL_0217:  callvirt   instance class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Threading.Thread::get_CurrentCulture()
    IL_021c:  call       instance string [mscorlib]System.Char::ToString(class [mscorlib]System.IFormatProvider)
    IL_0221:  ldloca.s   curC
    IL_0223:  call       class [mscorlib]System.Threading.Thread [mscorlib]System.Threading.Thread::get_CurrentThread()
    IL_0228:  callvirt   instance class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Threading.Thread::get_CurrentCulture()
    IL_022d:  call       instance string [mscorlib]System.Char::ToString(class [mscorlib]System.IFormatProvider)
    IL_0232:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0237:  stloc.s    CS$1$0000
    IL_0239:  br         IL_02dc

    IL_023e:  ldloc.3
    IL_023f:  ldc.i4.1
    IL_0240:  add
    IL_0241:  stloc.3
    IL_0242:  nop
    IL_0243:  br.s       IL_0245

    IL_0245:  ldloca.s   cki
    IL_0247:  call       instance valuetype [mscorlib]System.ConsoleKey [mscorlib]System.ConsoleKeyInfo::get_Key()
    IL_024c:  ldc.i4.s   65
    IL_024e:  blt.s      IL_025d

    IL_0250:  ldloca.s   cki
    IL_0252:  call       instance valuetype [mscorlib]System.ConsoleKey [mscorlib]System.ConsoleKeyInfo::get_Key()
    IL_0257:  ldc.i4.s   90
    IL_0259:  cgt
    IL_025b:  br.s       IL_025e

    IL_025d:  ldc.i4.1
    IL_025e:  stloc.s    CS$4$0003
    IL_0260:  ldloc.s    CS$4$0003
    IL_0262:  brtrue.s   IL_02d3

    IL_0264:  ldloca.s   cki
    IL_0266:  call       instance valuetype [mscorlib]System.ConsoleKey [mscorlib]System.ConsoleKeyInfo::get_Key()
    IL_026b:  conv.u2
    IL_026c:  call       void [mscorlib]System.Console::Write(char)
    IL_0271:  nop
    IL_0272:  ldloc.3
    IL_0273:  ldc.i4.2
    IL_0274:  ceq
    IL_0276:  ldc.i4.0
    IL_0277:  ceq
    IL_0279:  stloc.s    CS$4$0003
    IL_027b:  ldloc.s    CS$4$0003
    IL_027d:  brtrue.s   IL_029d

    IL_027f:  call       int32 [mscorlib]System.Console::get_CursorLeft()
    IL_0284:  ldc.i4.1
    IL_0285:  sub
    IL_0286:  call       int32 [mscorlib]System.Console::get_CursorTop()
    IL_028b:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_0290:  nop
    IL_0291:  ldloca.s   cki
    IL_0293:  call       instance valuetype [mscorlib]System.ConsoleKey [mscorlib]System.ConsoleKeyInfo::get_Key()
    IL_0298:  conv.u2
    IL_0299:  stloc.2
    IL_029a:  nop
    IL_029b:  br.s       IL_02d2

    IL_029d:  ldloc.3
    IL_029e:  ldc.i4.0
    IL_029f:  ceq
    IL_02a1:  ldc.i4.0
    IL_02a2:  ceq
    IL_02a4:  stloc.s    CS$4$0003
    IL_02a6:  ldloc.s    CS$4$0003
    IL_02a8:  brtrue.s   IL_02b6

    IL_02aa:  ldloca.s   cki
    IL_02ac:  call       instance valuetype [mscorlib]System.ConsoleKey [mscorlib]System.ConsoleKeyInfo::get_Key()
    IL_02b1:  conv.u2
    IL_02b2:  stloc.0
    IL_02b3:  nop
    IL_02b4:  br.s       IL_02cd

    IL_02b6:  ldloc.3
    IL_02b7:  ldc.i4.1
    IL_02b8:  ceq
    IL_02ba:  ldc.i4.0
    IL_02bb:  ceq
    IL_02bd:  stloc.s    CS$4$0003
    IL_02bf:  ldloc.s    CS$4$0003
    IL_02c1:  brtrue.s   IL_02cd

    IL_02c3:  ldloca.s   cki
    IL_02c5:  call       instance valuetype [mscorlib]System.ConsoleKey [mscorlib]System.ConsoleKeyInfo::get_Key()
    IL_02ca:  conv.u2
    IL_02cb:  stloc.1
    IL_02cc:  nop
    IL_02cd:  ldloc.3
    IL_02ce:  ldc.i4.1
    IL_02cf:  add
    IL_02d0:  stloc.3
    IL_02d1:  nop
    IL_02d2:  nop
    IL_02d3:  nop
    IL_02d4:  ldc.i4.1
    IL_02d5:  stloc.s    CS$4$0003
    IL_02d7:  br         IL_0017

    IL_02dc:  ldloc.s    CS$1$0000
    IL_02de:  ret
  } // end of method Invaders::CaptureInitials

  .method private hidebysig instance void 
          SetValUp(char& curVal) cil managed
  {
    // Code size       37 (0x25)
    .maxstack  3
    .locals init ([0] bool CS$4$0000)
    IL_0000:  ldarg.1
    IL_0001:  ldind.u2
    IL_0002:  ldc.i4.s   90
    IL_0004:  clt
    IL_0006:  ldc.i4.0
    IL_0007:  ceq
    IL_0009:  stloc.0
    IL_000a:  ldloc.0
    IL_000b:  brtrue.s   IL_0017

    IL_000d:  ldarg.1
    IL_000e:  dup
    IL_000f:  ldind.u2
    IL_0010:  ldc.i4.1
    IL_0011:  add
    IL_0012:  conv.u2
    IL_0013:  stind.i2
    IL_0014:  nop
    IL_0015:  br.s       IL_001c

    IL_0017:  ldarg.1
    IL_0018:  ldc.i4.s   65
    IL_001a:  stind.i2
    IL_001b:  nop
    IL_001c:  ldarg.1
    IL_001d:  ldind.u2
    IL_001e:  call       void [mscorlib]System.Console::Write(char)
    IL_0023:  nop
    IL_0024:  ret
  } // end of method Invaders::SetValUp

  .method private hidebysig instance void 
          SetValDown(char& curVal) cil managed
  {
    // Code size       52 (0x34)
    .maxstack  3
    .locals init ([0] bool CS$4$0000)
    IL_0000:  ldarg.1
    IL_0001:  ldind.u2
    IL_0002:  box        [mscorlib]System.Char
    IL_0007:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()
    IL_000c:  call       int32 [mscorlib]System.Convert::ToInt32(object,
                                                                 class [mscorlib]System.IFormatProvider)
    IL_0011:  ldc.i4.s   65
    IL_0013:  cgt
    IL_0015:  ldc.i4.0
    IL_0016:  ceq
    IL_0018:  stloc.0
    IL_0019:  ldloc.0
    IL_001a:  brtrue.s   IL_0026

    IL_001c:  ldarg.1
    IL_001d:  dup
    IL_001e:  ldind.u2
    IL_001f:  ldc.i4.1
    IL_0020:  sub
    IL_0021:  conv.u2
    IL_0022:  stind.i2
    IL_0023:  nop
    IL_0024:  br.s       IL_002b

    IL_0026:  ldarg.1
    IL_0027:  ldc.i4.s   90
    IL_0029:  stind.i2
    IL_002a:  nop
    IL_002b:  ldarg.1
    IL_002c:  ldind.u2
    IL_002d:  call       void [mscorlib]System.Console::Write(char)
    IL_0032:  nop
    IL_0033:  ret
  } // end of method Invaders::SetValDown

  .method private hidebysig specialname instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> 
          get_HighScores() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init ([0] class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> CS$1$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::highScores
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method Invaders::get_HighScores

  .method private hidebysig instance void 
          Play() cil managed
  {
    // Code size       773 (0x305)
    .maxstack  9
    .locals init ([0] valuetype [mscorlib]System.ConsoleKeyInfo cki,
             [1] valuetype [mscorlib]System.ConsoleKeyInfo ckNext,
             [2] bool CS$4$0000,
             [3] valuetype [mscorlib]System.ConsoleKey CS$4$0001,
             [4] valuetype [mscorlib]System.ConsoleKey CS$0$0002,
             [5] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0003,
             [6] string[] CS$0$0004)
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.0
    IL_0002:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawShip(valuetype Microsoft.Samples.SpaceInvaders.ShipPosition)
    IL_0007:  nop
    IL_0008:  ldarg.0
    IL_0009:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawHighScore()
    IL_000e:  nop
    IL_000f:  br         IL_02fc

    IL_0014:  br.s       IL_0055

    IL_0016:  ldarg.0
    IL_0017:  ldfld      valuetype Microsoft.Samples.SpaceInvaders.GameState Microsoft.Samples.SpaceInvaders.Invaders::gameOver
    IL_001c:  ldc.i4.2
    IL_001d:  beq.s      IL_0032

    IL_001f:  ldarg.0
    IL_0020:  ldfld      valuetype Microsoft.Samples.SpaceInvaders.GameState Microsoft.Samples.SpaceInvaders.Invaders::gameOver
    IL_0025:  brfalse.s  IL_0032

    IL_0027:  ldarg.0
    IL_0028:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::gettingName
    IL_002d:  ldc.i4.0
    IL_002e:  ceq
    IL_0030:  br.s       IL_0033

    IL_0032:  ldc.i4.0
    IL_0033:  stloc.2
    IL_0034:  ldloc.2
    IL_0035:  brtrue.s   IL_0054

    IL_0037:  ldarg.0
    IL_0038:  ldc.i4     0x190
    IL_003d:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DisplayGameOver(int32)
    IL_0042:  nop
    IL_0043:  ldarg.0
    IL_0044:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_0049:  callvirt   instance void [System]System.Diagnostics.TraceSource::Flush()
    IL_004e:  nop
    IL_004f:  br         IL_0303

    IL_0054:  nop
    IL_0055:  call       bool [mscorlib]System.Console::get_KeyAvailable()
    IL_005a:  ldc.i4.0
    IL_005b:  ceq
    IL_005d:  stloc.2
    IL_005e:  ldloc.2
    IL_005f:  brtrue.s   IL_0016

    IL_0061:  ldc.i4.1
    IL_0062:  call       valuetype [mscorlib]System.ConsoleKeyInfo [mscorlib]System.Console::ReadKey(bool)
    IL_0067:  stloc.0
    IL_0068:  ldloca.s   cki
    IL_006a:  call       instance valuetype [mscorlib]System.ConsoleKey [mscorlib]System.ConsoleKeyInfo::get_Key()
    IL_006f:  stloc.3
    IL_0070:  ldloc.3
    IL_0071:  stloc.s    CS$0$0002
    IL_0073:  ldloc.s    CS$0$0002
    IL_0075:  ldc.i4.s   32
    IL_0077:  bgt.s      IL_0090

    IL_0079:  ldloc.s    CS$0$0002
    IL_007b:  ldc.i4.s   27
    IL_007d:  beq        IL_0149

    IL_0082:  ldloc.s    CS$0$0002
    IL_0084:  ldc.i4.s   32
    IL_0086:  beq        IL_011b

    IL_008b:  br         IL_02d4

    IL_0090:  ldloc.s    CS$0$0002
    IL_0092:  ldc.i4.s   37
    IL_0094:  sub
    IL_0095:  switch     ( 
                          IL_00bd,
                          IL_02d4,
                          IL_00ec)
    IL_00a6:  ldloc.s    CS$0$0002
    IL_00a8:  ldc.i4.s   77
    IL_00aa:  beq        IL_0155

    IL_00af:  ldloc.s    CS$0$0002
    IL_00b1:  ldc.i4.s   80
    IL_00b3:  beq        IL_0169

    IL_00b8:  br         IL_02d4

    IL_00bd:  ldarg.0
    IL_00be:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::shipBeingDestroyed
    IL_00c3:  stloc.2
    IL_00c4:  ldloc.2
    IL_00c5:  brtrue.s   IL_00e7

    IL_00c7:  ldarg.0
    IL_00c8:  dup
    IL_00c9:  stloc.s    CS$2$0003
    IL_00cb:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_00d0:  nop
    .try
    {
      IL_00d1:  ldarg.0
      IL_00d2:  ldc.i4.1
      IL_00d3:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawShip(valuetype Microsoft.Samples.SpaceInvaders.ShipPosition)
      IL_00d8:  nop
      IL_00d9:  nop
      IL_00da:  leave.s    IL_00e5

    }  // end .try
    finally
    {
      IL_00dc:  ldloc.s    CS$2$0003
      IL_00de:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00e3:  nop
      IL_00e4:  endfinally
    }  // end handler
    IL_00e5:  nop
    IL_00e6:  nop
    IL_00e7:  br         IL_02fb

    IL_00ec:  ldarg.0
    IL_00ed:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::shipBeingDestroyed
    IL_00f2:  stloc.2
    IL_00f3:  ldloc.2
    IL_00f4:  brtrue.s   IL_0116

    IL_00f6:  ldarg.0
    IL_00f7:  dup
    IL_00f8:  stloc.s    CS$2$0003
    IL_00fa:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_00ff:  nop
    .try
    {
      IL_0100:  ldarg.0
      IL_0101:  ldc.i4.2
      IL_0102:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawShip(valuetype Microsoft.Samples.SpaceInvaders.ShipPosition)
      IL_0107:  nop
      IL_0108:  nop
      IL_0109:  leave.s    IL_0114

    }  // end .try
    finally
    {
      IL_010b:  ldloc.s    CS$2$0003
      IL_010d:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0112:  nop
      IL_0113:  endfinally
    }  // end handler
    IL_0114:  nop
    IL_0115:  nop
    IL_0116:  br         IL_02fb

    IL_011b:  ldarg.0
    IL_011c:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::shipBeingDestroyed
    IL_0121:  stloc.2
    IL_0122:  ldloc.2
    IL_0123:  brtrue.s   IL_0144

    IL_0125:  ldarg.0
    IL_0126:  dup
    IL_0127:  stloc.s    CS$2$0003
    IL_0129:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_012e:  nop
    .try
    {
      IL_012f:  ldarg.0
      IL_0130:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ShootBullet()
      IL_0135:  nop
      IL_0136:  nop
      IL_0137:  leave.s    IL_0142

    }  // end .try
    finally
    {
      IL_0139:  ldloc.s    CS$2$0003
      IL_013b:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0140:  nop
      IL_0141:  endfinally
    }  // end handler
    IL_0142:  nop
    IL_0143:  nop
    IL_0144:  br         IL_02fb

    IL_0149:  ldarg.0
    IL_014a:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::EndGame()
    IL_014f:  nop
    IL_0150:  br         IL_0303

    IL_0155:  ldarg.0
    IL_0156:  ldarg.0
    IL_0157:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::_mute
    IL_015c:  ldc.i4.0
    IL_015d:  ceq
    IL_015f:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::_mute
    IL_0164:  br         IL_02fb

    IL_0169:  ldarg.0
    IL_016a:  ldc.i4.0
    IL_016b:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DisableTimers(bool)
    IL_0170:  nop
    IL_0171:  ldarg.0
    IL_0172:  dup
    IL_0173:  stloc.s    CS$2$0003
    IL_0175:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_017a:  nop
    .try
    {
      IL_017b:  ldarg.0
      IL_017c:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::HideInvaders()
      IL_0181:  nop
      IL_0182:  ldarg.0
      IL_0183:  ldc.i4.s   14
      IL_0185:  ldc.i4.s   12
      IL_0187:  ldc.i4.8
      IL_0188:  ldc.i4.0
      IL_0189:  ldc.i4.0
      IL_018a:  ldc.i4.6
      IL_018b:  newarr     [mscorlib]System.String
      IL_0190:  stloc.s    CS$0$0004
      IL_0192:  ldloc.s    CS$0$0004
      IL_0194:  ldc.i4.0
      IL_0195:  ldstr      "P"
      IL_019a:  stelem.ref
      IL_019b:  ldloc.s    CS$0$0004
      IL_019d:  ldc.i4.1
      IL_019e:  ldstr      "A"
      IL_01a3:  stelem.ref
      IL_01a4:  ldloc.s    CS$0$0004
      IL_01a6:  ldc.i4.2
      IL_01a7:  ldstr      "U"
      IL_01ac:  stelem.ref
      IL_01ad:  ldloc.s    CS$0$0004
      IL_01af:  ldc.i4.3
      IL_01b0:  ldstr      "S"
      IL_01b5:  stelem.ref
      IL_01b6:  ldloc.s    CS$0$0004
      IL_01b8:  ldc.i4.4
      IL_01b9:  ldstr      "E"
      IL_01be:  stelem.ref
      IL_01bf:  ldloc.s    CS$0$0004
      IL_01c1:  ldc.i4.5
      IL_01c2:  ldstr      "D"
      IL_01c7:  stelem.ref
      IL_01c8:  ldloc.s    CS$0$0004
      IL_01ca:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawLetters(int32,
                                                                                               int32,
                                                                                               int32,
                                                                                               int32,
                                                                                               bool,
                                                                                               string[])
      IL_01cf:  nop
      IL_01d0:  br         IL_0261

      IL_01d5:  ldc.i4.1
      IL_01d6:  call       valuetype [mscorlib]System.ConsoleKeyInfo [mscorlib]System.Console::ReadKey(bool)
      IL_01db:  stloc.1
      IL_01dc:  ldloca.s   ckNext
      IL_01de:  call       instance valuetype [mscorlib]System.ConsoleKey [mscorlib]System.ConsoleKeyInfo::get_Key()
      IL_01e3:  ldc.i4.s   80
      IL_01e5:  ceq
      IL_01e7:  ldc.i4.0
      IL_01e8:  ceq
      IL_01ea:  stloc.2
      IL_01eb:  ldloc.2
      IL_01ec:  brtrue.s   IL_020c

      IL_01ee:  ldarg.0
      IL_01ef:  ldfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
      IL_01f4:  callvirt   instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::get_IsOpen()
      IL_01f9:  ldc.i4.0
      IL_01fa:  ceq
      IL_01fc:  stloc.2
      IL_01fd:  ldloc.2
      IL_01fe:  brtrue.s   IL_020a

      IL_0200:  ldarg.0
      IL_0201:  ldnull
      IL_0202:  ldnull
      IL_0203:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::WriteLcdLine(string,
                                                                                                string)
      IL_0208:  nop
      IL_0209:  nop
      IL_020a:  br.s       IL_0268

      IL_020c:  ldloca.s   ckNext
      IL_020e:  call       instance valuetype [mscorlib]System.ConsoleKey [mscorlib]System.ConsoleKeyInfo::get_Key()
      IL_0213:  ldc.i4.s   27
      IL_0215:  ceq
      IL_0217:  ldc.i4.0
      IL_0218:  ceq
      IL_021a:  stloc.2
      IL_021b:  ldloc.2
      IL_021c:  brtrue.s   IL_022a

      IL_021e:  ldarg.0
      IL_021f:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::EndGame()
      IL_0224:  nop
      IL_0225:  leave      IL_0303

      IL_022a:  ldloca.s   ckNext
      IL_022c:  call       instance valuetype [mscorlib]System.ConsoleKey [mscorlib]System.ConsoleKeyInfo::get_Key()
      IL_0231:  ldc.i4.s   79
      IL_0233:  ceq
      IL_0235:  ldc.i4.0
      IL_0236:  ceq
      IL_0238:  stloc.2
      IL_0239:  ldloc.2
      IL_023a:  brtrue.s   IL_0246

      IL_023c:  ldarg.0
      IL_023d:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::OpenLcd()
      IL_0242:  nop
      IL_0243:  nop
      IL_0244:  br.s       IL_0260

      IL_0246:  ldloca.s   ckNext
      IL_0248:  call       instance valuetype [mscorlib]System.ConsoleKey [mscorlib]System.ConsoleKeyInfo::get_Key()
      IL_024d:  ldc.i4.s   67
      IL_024f:  ceq
      IL_0251:  ldc.i4.0
      IL_0252:  ceq
      IL_0254:  stloc.2
      IL_0255:  ldloc.2
      IL_0256:  brtrue.s   IL_0260

      IL_0258:  ldarg.0
      IL_0259:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::CloseLcd()
      IL_025e:  nop
      IL_025f:  nop
      IL_0260:  nop
      IL_0261:  ldc.i4.1
      IL_0262:  stloc.2
      IL_0263:  br         IL_01d5

      IL_0268:  ldarg.0
      IL_0269:  ldc.i4.s   14
      IL_026b:  ldc.i4.s   12
      IL_026d:  ldc.i4.8
      IL_026e:  ldc.i4.0
      IL_026f:  ldc.i4.1
      IL_0270:  ldc.i4.6
      IL_0271:  newarr     [mscorlib]System.String
      IL_0276:  stloc.s    CS$0$0004
      IL_0278:  ldloc.s    CS$0$0004
      IL_027a:  ldc.i4.0
      IL_027b:  ldstr      "P"
      IL_0280:  stelem.ref
      IL_0281:  ldloc.s    CS$0$0004
      IL_0283:  ldc.i4.1
      IL_0284:  ldstr      "A"
      IL_0289:  stelem.ref
      IL_028a:  ldloc.s    CS$0$0004
      IL_028c:  ldc.i4.2
      IL_028d:  ldstr      "U"
      IL_0292:  stelem.ref
      IL_0293:  ldloc.s    CS$0$0004
      IL_0295:  ldc.i4.3
      IL_0296:  ldstr      "S"
      IL_029b:  stelem.ref
      IL_029c:  ldloc.s    CS$0$0004
      IL_029e:  ldc.i4.4
      IL_029f:  ldstr      "E"
      IL_02a4:  stelem.ref
      IL_02a5:  ldloc.s    CS$0$0004
      IL_02a7:  ldc.i4.5
      IL_02a8:  ldstr      "D"
      IL_02ad:  stelem.ref
      IL_02ae:  ldloc.s    CS$0$0004
      IL_02b0:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawLetters(int32,
                                                                                               int32,
                                                                                               int32,
                                                                                               int32,
                                                                                               bool,
                                                                                               string[])
      IL_02b5:  nop
      IL_02b6:  ldarg.0
      IL_02b7:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ShowInvaders()
      IL_02bc:  nop
      IL_02bd:  nop
      IL_02be:  leave.s    IL_02c9

    }  // end .try
    finally
    {
      IL_02c0:  ldloc.s    CS$2$0003
      IL_02c2:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_02c7:  nop
      IL_02c8:  endfinally
    }  // end handler
    IL_02c9:  nop
    IL_02ca:  ldarg.0
    IL_02cb:  ldc.i4.1
    IL_02cc:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DisableTimers(bool)
    IL_02d1:  nop
    IL_02d2:  br.s       IL_02fb

    IL_02d4:  ldarg.0
    IL_02d5:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_02da:  ldc.i4.2
    IL_02db:  ldc.i4.s   13
    IL_02dd:  ldstr      "Invalid key: "
    IL_02e2:  ldloca.s   cki
    IL_02e4:  call       instance valuetype [mscorlib]System.ConsoleKey [mscorlib]System.ConsoleKeyInfo::get_Key()
    IL_02e9:  box        [mscorlib]System.ConsoleKey
    IL_02ee:  call       string [mscorlib]System.String::Concat(object,
                                                                object)
    IL_02f3:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                          int32,
                                                                                          string)
    IL_02f8:  nop
    IL_02f9:  br.s       IL_02fb

    IL_02fb:  nop
    IL_02fc:  ldc.i4.1
    IL_02fd:  stloc.2
    IL_02fe:  br         IL_0014

    IL_0303:  nop
    IL_0304:  ret
  } // end of method Invaders::Play

  .method private hidebysig instance void 
          EndGame() cil managed
  {
    // Code size       115 (0x73)
    .maxstack  4
    .locals init ([0] bool CS$4$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  brtrue.s   IL_002c

    IL_000a:  ldarg.0
    IL_000b:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_0010:  ldc.i4.8
    IL_0011:  ldc.i4.s   14
    IL_0013:  ldstr      "Game Ended, oh well..."
    IL_0018:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                          int32,
                                                                                          string)
    IL_001d:  nop
    IL_001e:  ldarg.0
    IL_001f:  ldstr      "Goodbye"
    IL_0024:  ldnull
    IL_0025:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::WriteLcdLine(string,
                                                                                              string)
    IL_002a:  nop
    IL_002b:  nop
    IL_002c:  ldarg.0
    IL_002d:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_0032:  call       void Microsoft.Samples.SpaceInvaders.ListenerOperations::Clear(class [System]System.Diagnostics.TraceSource)
    IL_0037:  nop
    IL_0038:  call       void [mscorlib]System.Console::Clear()
    IL_003d:  nop
    IL_003e:  ldarg.0
    IL_003f:  ldc.i4.0
    IL_0040:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DisableTimers(bool)
    IL_0045:  nop
    IL_0046:  ldarg.0
    IL_0047:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ClearLists()
    IL_004c:  nop
    IL_004d:  ldarg.0
    IL_004e:  ldc.i4.0
    IL_004f:  stfld      valuetype Microsoft.Samples.SpaceInvaders.GameState Microsoft.Samples.SpaceInvaders.Invaders::gameOver
    IL_0054:  ldarg.0
    IL_0055:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_005a:  ldnull
    IL_005b:  ceq
    IL_005d:  ldc.i4.0
    IL_005e:  ceq
    IL_0060:  stloc.0
    IL_0061:  ldloc.0
    IL_0062:  brtrue.s   IL_0070

    IL_0064:  ldarg.0
    IL_0065:  call       class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.ListenerOperations::InitializeListener()
    IL_006a:  stfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_006f:  nop
    IL_0070:  br.s       IL_0072

    IL_0072:  ret
  } // end of method Invaders::EndGame

  .method private hidebysig instance void 
          WriteLcdLine(string line1,
                       string line2) cil managed
  {
    // Code size       82 (0x52)
    .maxstack  3
    .locals init ([0] bool CS$4$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
    IL_0006:  callvirt   instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::get_IsOpen()
    IL_000b:  ldc.i4.0
    IL_000c:  ceq
    IL_000e:  stloc.0
    IL_000f:  ldloc.0
    IL_0010:  brtrue.s   IL_0051

    IL_0012:  ldarg.0
    IL_0013:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::clearLcdScreen
    IL_0018:  ldc.i4.0
    IL_0019:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_001e:  ldarg.0
    IL_001f:  ldfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
    IL_0024:  ldarg.0
    IL_0025:  ldarg.1
    IL_0026:  call       instance string Microsoft.Samples.SpaceInvaders.Invaders::CenterLcdLine(string)
    IL_002b:  callvirt   instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::WriteLine1(string)
    IL_0030:  pop
    IL_0031:  ldarg.0
    IL_0032:  ldfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
    IL_0037:  ldarg.0
    IL_0038:  ldarg.2
    IL_0039:  call       instance string Microsoft.Samples.SpaceInvaders.Invaders::CenterLcdLine(string)
    IL_003e:  callvirt   instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::WriteLine2(string)
    IL_0043:  pop
    IL_0044:  ldarg.0
    IL_0045:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::clearLcdScreen
    IL_004a:  ldc.i4.1
    IL_004b:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_0050:  nop
    IL_0051:  ret
  } // end of method Invaders::WriteLcdLine

  .method private hidebysig instance string 
          CenterLcdLine(string line) cil managed
  {
    // Code size       72 (0x48)
    .maxstack  2
    .locals init ([0] string centeredLine,
             [1] int32 left,
             [2] int32 i,
             [3] string CS$1$0000,
             [4] bool CS$4$0001)
    IL_0000:  ldarg.1
    IL_0001:  ldnull
    IL_0002:  ceq
    IL_0004:  ldc.i4.0
    IL_0005:  ceq
    IL_0007:  stloc.s    CS$4$0001
    IL_0009:  ldloc.s    CS$4$0001
    IL_000b:  brtrue.s   IL_0015

    IL_000d:  ldstr      ""
    IL_0012:  stloc.3
    IL_0013:  br.s       IL_0046

    IL_0015:  ldarg.1
    IL_0016:  stloc.0
    IL_0017:  ldc.i4.s   17
    IL_0019:  ldloc.0
    IL_001a:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_001f:  sub
    IL_0020:  ldc.i4.2
    IL_0021:  div
    IL_0022:  stloc.1
    IL_0023:  ldc.i4.0
    IL_0024:  stloc.2
    IL_0025:  br.s       IL_0038

    IL_0027:  ldstr      " "
    IL_002c:  ldloc.0
    IL_002d:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_0032:  stloc.0
    IL_0033:  nop
    IL_0034:  ldloc.2
    IL_0035:  ldc.i4.1
    IL_0036:  add
    IL_0037:  stloc.2
    IL_0038:  ldloc.2
    IL_0039:  ldloc.1
    IL_003a:  clt
    IL_003c:  stloc.s    CS$4$0001
    IL_003e:  ldloc.s    CS$4$0001
    IL_0040:  brtrue.s   IL_0027

    IL_0042:  ldloc.0
    IL_0043:  stloc.3
    IL_0044:  br.s       IL_0046

    IL_0046:  ldloc.3
    IL_0047:  ret
  } // end of method Invaders::CenterLcdLine

  .method private hidebysig instance void 
          DrawHighScore() cil managed
  {
    // Code size       75 (0x4b)
    .maxstack  3
    IL_0000:  ldc.i4.s   28
    IL_0002:  ldc.i4.0
    IL_0003:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_0008:  nop
    IL_0009:  ldc.i4.s   14
    IL_000b:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
    IL_0010:  ldstr      "HIGH SCORE "
    IL_0015:  call       void [mscorlib]System.Console::Write(string)
    IL_001a:  nop
    IL_001b:  ldc.i4.s   10
    IL_001d:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
    IL_0022:  ldstr      "{0:00000}"
    IL_0027:  ldarg.0
    IL_0028:  ldfld      class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::highScores
    IL_002d:  ldc.i4.1
    IL_002e:  callvirt   instance !1 class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Item(!0)
    IL_0033:  ldc.i4.1
    IL_0034:  ldelem.ref
    IL_0035:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()
    IL_003a:  call       int32 [mscorlib]System.Convert::ToInt32(string,
                                                                 class [mscorlib]System.IFormatProvider)
    IL_003f:  box        [mscorlib]System.Int32
    IL_0044:  call       void [mscorlib]System.Console::Write(string,
                                                              object)
    IL_0049:  nop
    IL_004a:  ret
  } // end of method Invaders::DrawHighScore

  .method private hidebysig instance void 
          HideInvaders() cil managed
  {
    // Code size       100 (0x64)
    .maxstack  6
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.Invader i,
             [1] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0000,
             [2] valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader> CS$5$0001,
             [3] bool CS$4$0002)
    IL_0000:  ldarg.0
    IL_0001:  dup
    IL_0002:  stloc.1
    IL_0003:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0008:  nop
    .try
    {
      IL_0009:  ldarg.0
      IL_000a:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
      IL_000f:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<!0> class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::GetEnumerator()
      IL_0014:  stloc.2
      .try
      {
        IL_0015:  br.s       IL_0040

        IL_0017:  ldloca.s   CS$5$0001
        IL_0019:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::get_Current()
        IL_001e:  stloc.0
        IL_001f:  ldc.i4.0
        IL_0020:  ldc.i4.0
        IL_0021:  ldc.i4.3
        IL_0022:  ldc.i4.1
        IL_0023:  ldloc.0
        IL_0024:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
        IL_0029:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
        IL_002e:  ldloc.0
        IL_002f:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
        IL_0034:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
        IL_0039:  call       void [mscorlib]System.Console::MoveBufferArea(int32,
                                                                           int32,
                                                                           int32,
                                                                           int32,
                                                                           int32,
                                                                           int32)
        IL_003e:  nop
        IL_003f:  nop
        IL_0040:  ldloca.s   CS$5$0001
        IL_0042:  call       instance bool valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::MoveNext()
        IL_0047:  stloc.3
        IL_0048:  ldloc.3
        IL_0049:  brtrue.s   IL_0017

        IL_004b:  leave.s    IL_0056

      }  // end .try
      finally
      {
        IL_004d:  ldloca.s   CS$5$0001
        IL_004f:  call       instance void valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::Dispose()
        IL_0054:  nop
        IL_0055:  endfinally
      }  // end handler
      IL_0056:  nop
      IL_0057:  nop
      IL_0058:  leave.s    IL_0062

    }  // end .try
    finally
    {
      IL_005a:  ldloc.1
      IL_005b:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0060:  nop
      IL_0061:  endfinally
    }  // end handler
    IL_0062:  nop
    IL_0063:  ret
  } // end of method Invaders::HideInvaders

  .method private hidebysig instance void 
          ShowInvaders() cil managed
  {
    // Code size       97 (0x61)
    .maxstack  6
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.Invader i,
             [1] valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader> CS$5$0000,
             [2] bool CS$4$0001)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_0006:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<!0> class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::GetEnumerator()
    IL_000b:  stloc.1
    .try
    {
      IL_000c:  br.s       IL_0049

      IL_000e:  ldloca.s   CS$5$0000
      IL_0010:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::get_Current()
      IL_0015:  stloc.0
      IL_0016:  ldarg.0
      IL_0017:  ldloc.0
      IL_0018:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_001d:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_0022:  ldloc.0
      IL_0023:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_0028:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_002d:  ldarg.0
      IL_002e:  ldloc.0
      IL_002f:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_0034:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_0039:  ldc.i4.2
      IL_003a:  sub
      IL_003b:  ldc.i4.3
      IL_003c:  div
      IL_003d:  call       instance valuetype [mscorlib]System.ConsoleColor Microsoft.Samples.SpaceInvaders.Invaders::GetNextColor(int32)
      IL_0042:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawInvader(int32,
                                                                                               int32,
                                                                                               valuetype [mscorlib]System.ConsoleColor)
      IL_0047:  nop
      IL_0048:  nop
      IL_0049:  ldloca.s   CS$5$0000
      IL_004b:  call       instance bool valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::MoveNext()
      IL_0050:  stloc.2
      IL_0051:  ldloc.2
      IL_0052:  brtrue.s   IL_000e

      IL_0054:  leave.s    IL_005f

    }  // end .try
    finally
    {
      IL_0056:  ldloca.s   CS$5$0000
      IL_0058:  call       instance void valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::Dispose()
      IL_005d:  nop
      IL_005e:  endfinally
    }  // end handler
    IL_005f:  nop
    IL_0060:  ret
  } // end of method Invaders::ShowInvaders

  .method private hidebysig instance void 
          ClearLists() cil managed
  {
    // Code size       45 (0x2d)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  newobj     instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::.ctor()
    IL_0006:  stfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
    IL_000b:  ldarg.0
    IL_000c:  newobj     instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::.ctor()
    IL_0011:  stfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
    IL_0016:  ldarg.0
    IL_0017:  newobj     instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::.ctor()
    IL_001c:  stfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_0021:  ldarg.0
    IL_0022:  newobj     instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::.ctor()
    IL_0027:  stfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
    IL_002c:  ret
  } // end of method Invaders::ClearLists

  .method private hidebysig instance void 
          WriteEntry(string entry,
                     valuetype [mscorlib]System.ConsoleColor foreColor) cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.2
    IL_0001:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
    IL_0006:  ldarg.1
    IL_0007:  call       void [mscorlib]System.Console::Write(string)
    IL_000c:  nop
    IL_000d:  ret
  } // end of method Invaders::WriteEntry

  .method private hidebysig instance void 
          Initialize() cil managed
  {
    // Code size       501 (0x1f5)
    .maxstack  4
    .locals init ([0] bool CS$4$0000)
    IL_0000:  ldarg.0
    IL_0001:  call       valuetype [mscorlib]System.ConsoleColor [mscorlib]System.Console::get_BackgroundColor()
    IL_0006:  stfld      valuetype [mscorlib]System.ConsoleColor Microsoft.Samples.SpaceInvaders.Invaders::initialBackColor
    IL_000b:  ldarg.0
    IL_000c:  call       valuetype [mscorlib]System.ConsoleColor [mscorlib]System.Console::get_ForegroundColor()
    IL_0011:  stfld      valuetype [mscorlib]System.ConsoleColor Microsoft.Samples.SpaceInvaders.Invaders::initialForeColor
    IL_0016:  ldarg.0
    IL_0017:  call       string [mscorlib]System.Console::get_Title()
    IL_001c:  stfld      string Microsoft.Samples.SpaceInvaders.Invaders::initialTitle
    IL_0021:  ldarg.0
    IL_0022:  call       int32 [mscorlib]System.Console::get_BufferHeight()
    IL_0027:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::initialBufferHeight
    IL_002c:  ldarg.0
    IL_002d:  call       int32 [mscorlib]System.Console::get_BufferWidth()
    IL_0032:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::initialBufferWidth
    IL_0037:  ldarg.0
    IL_0038:  call       int32 [mscorlib]System.Console::get_WindowHeight()
    IL_003d:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::initialWindowHeight
    IL_0042:  ldarg.0
    IL_0043:  call       int32 [mscorlib]System.Console::get_WindowWidth()
    IL_0048:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::initialWindowWidth
    IL_004d:  ldc.i4.0
    IL_004e:  call       void [mscorlib]System.Console::set_BackgroundColor(valuetype [mscorlib]System.ConsoleColor)
    IL_0053:  ldc.i4.0
    IL_0054:  ldc.i4.0
    IL_0055:  call       void [mscorlib]System.Console::SetWindowPosition(int32,
                                                                          int32)
    IL_005a:  nop
    IL_005b:  call       int32 [mscorlib]System.Console::get_WindowHeight()
    IL_0060:  ldc.i4.s   72
    IL_0062:  bgt.s      IL_0072

    IL_0064:  call       int32 [mscorlib]System.Console::get_WindowWidth()
    IL_0069:  ldc.i4.s   36
    IL_006b:  cgt
    IL_006d:  ldc.i4.0
    IL_006e:  ceq
    IL_0070:  br.s       IL_0073

    IL_0072:  ldc.i4.0
    IL_0073:  stloc.0
    IL_0074:  ldloc.0
    IL_0075:  brtrue.s   IL_0081

    IL_0077:  ldc.i4.s   10
    IL_0079:  ldc.i4.s   10
    IL_007b:  call       void [mscorlib]System.Console::SetWindowSize(int32,
                                                                      int32)
    IL_0080:  nop
    IL_0081:  ldc.i4.s   73
    IL_0083:  ldc.i4.s   37
    IL_0085:  call       void [mscorlib]System.Console::SetBufferSize(int32,
                                                                      int32)
    IL_008a:  nop
    IL_008b:  call       int32 [mscorlib]System.Console::get_BufferWidth()
    IL_0090:  call       int32 [mscorlib]System.Console::get_BufferHeight()
    IL_0095:  call       void [mscorlib]System.Console::SetWindowSize(int32,
                                                                      int32)
    IL_009a:  nop
    IL_009b:  call       void [mscorlib]System.Console::Clear()
    IL_00a0:  nop
    IL_00a1:  ldc.i4.0
    IL_00a2:  call       void [mscorlib]System.Console::set_CursorVisible(bool)
    IL_00a7:  ldstr      "Managed Space Invaders"
    IL_00ac:  call       void [mscorlib]System.Console::set_Title(string)
    IL_00b1:  ldarg.0
    IL_00b2:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::HighScoreTimer
    IL_00b7:  ldarg.0
    IL_00b8:  ldftn      instance void Microsoft.Samples.SpaceInvaders.Invaders::OnHighScoreTimedEvent(object,
                                                                                                       class [System]System.Timers.ElapsedEventArgs)
    IL_00be:  newobj     instance void [System]System.Timers.ElapsedEventHandler::.ctor(object,
                                                                                        native int)
    IL_00c3:  callvirt   instance void [System]System.Timers.Timer::add_Elapsed(class [System]System.Timers.ElapsedEventHandler)
    IL_00c8:  nop
    IL_00c9:  ldarg.0
    IL_00ca:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::shipBulletTimer
    IL_00cf:  ldarg.0
    IL_00d0:  ldftn      instance void Microsoft.Samples.SpaceInvaders.Invaders::OnBulletTimedEvent(object,
                                                                                                    class [System]System.Timers.ElapsedEventArgs)
    IL_00d6:  newobj     instance void [System]System.Timers.ElapsedEventHandler::.ctor(object,
                                                                                        native int)
    IL_00db:  callvirt   instance void [System]System.Timers.Timer::add_Elapsed(class [System]System.Timers.ElapsedEventHandler)
    IL_00e0:  nop
    IL_00e1:  ldarg.0
    IL_00e2:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
    IL_00e7:  ldarg.0
    IL_00e8:  ldftn      instance void Microsoft.Samples.SpaceInvaders.Invaders::OnInvadersTimedEvent(object,
                                                                                                      class [System]System.Timers.ElapsedEventArgs)
    IL_00ee:  newobj     instance void [System]System.Timers.ElapsedEventHandler::.ctor(object,
                                                                                        native int)
    IL_00f3:  callvirt   instance void [System]System.Timers.Timer::add_Elapsed(class [System]System.Timers.ElapsedEventHandler)
    IL_00f8:  nop
    IL_00f9:  ldarg.0
    IL_00fa:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersBulletTimer
    IL_00ff:  ldarg.0
    IL_0100:  ldftn      instance void Microsoft.Samples.SpaceInvaders.Invaders::OnInvadersBulletTimedEvent(object,
                                                                                                            class [System]System.Timers.ElapsedEventArgs)
    IL_0106:  newobj     instance void [System]System.Timers.ElapsedEventHandler::.ctor(object,
                                                                                        native int)
    IL_010b:  callvirt   instance void [System]System.Timers.Timer::add_Elapsed(class [System]System.Timers.ElapsedEventHandler)
    IL_0110:  nop
    IL_0111:  ldarg.0
    IL_0112:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::explosionTimer
    IL_0117:  ldarg.0
    IL_0118:  ldftn      instance void Microsoft.Samples.SpaceInvaders.Invaders::OnInvadersExplosion(object,
                                                                                                     class [System]System.Timers.ElapsedEventArgs)
    IL_011e:  newobj     instance void [System]System.Timers.ElapsedEventHandler::.ctor(object,
                                                                                        native int)
    IL_0123:  callvirt   instance void [System]System.Timers.Timer::add_Elapsed(class [System]System.Timers.ElapsedEventHandler)
    IL_0128:  nop
    IL_0129:  ldarg.0
    IL_012a:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::shipDestroyedTimer
    IL_012f:  ldarg.0
    IL_0130:  ldftn      instance void Microsoft.Samples.SpaceInvaders.Invaders::OnShipDestroyed(object,
                                                                                                 class [System]System.Timers.ElapsedEventArgs)
    IL_0136:  newobj     instance void [System]System.Timers.ElapsedEventHandler::.ctor(object,
                                                                                        native int)
    IL_013b:  callvirt   instance void [System]System.Timers.Timer::add_Elapsed(class [System]System.Timers.ElapsedEventHandler)
    IL_0140:  nop
    IL_0141:  ldarg.0
    IL_0142:  ldc.i4.s   10
    IL_0144:  newarr     [mscorlib]System.String
    IL_0149:  stfld      string[] Microsoft.Samples.SpaceInvaders.Invaders::scoreNames
    IL_014e:  ldarg.0
    IL_014f:  ldfld      string[] Microsoft.Samples.SpaceInvaders.Invaders::scoreNames
    IL_0154:  ldc.i4.0
    IL_0155:  ldstr      "First"
    IL_015a:  stelem.ref
    IL_015b:  ldarg.0
    IL_015c:  ldfld      string[] Microsoft.Samples.SpaceInvaders.Invaders::scoreNames
    IL_0161:  ldc.i4.1
    IL_0162:  ldstr      "Second"
    IL_0167:  stelem.ref
    IL_0168:  ldarg.0
    IL_0169:  ldfld      string[] Microsoft.Samples.SpaceInvaders.Invaders::scoreNames
    IL_016e:  ldc.i4.2
    IL_016f:  ldstr      "Third"
    IL_0174:  stelem.ref
    IL_0175:  ldarg.0
    IL_0176:  ldfld      string[] Microsoft.Samples.SpaceInvaders.Invaders::scoreNames
    IL_017b:  ldc.i4.3
    IL_017c:  ldstr      "Fourth"
    IL_0181:  stelem.ref
    IL_0182:  ldarg.0
    IL_0183:  ldfld      string[] Microsoft.Samples.SpaceInvaders.Invaders::scoreNames
    IL_0188:  ldc.i4.4
    IL_0189:  ldstr      "Fifth"
    IL_018e:  stelem.ref
    IL_018f:  ldarg.0
    IL_0190:  ldfld      string[] Microsoft.Samples.SpaceInvaders.Invaders::scoreNames
    IL_0195:  ldc.i4.5
    IL_0196:  ldstr      "Sixth"
    IL_019b:  stelem.ref
    IL_019c:  ldarg.0
    IL_019d:  ldfld      string[] Microsoft.Samples.SpaceInvaders.Invaders::scoreNames
    IL_01a2:  ldc.i4.6
    IL_01a3:  ldstr      "Seventh"
    IL_01a8:  stelem.ref
    IL_01a9:  ldarg.0
    IL_01aa:  ldfld      string[] Microsoft.Samples.SpaceInvaders.Invaders::scoreNames
    IL_01af:  ldc.i4.7
    IL_01b0:  ldstr      "Eighth"
    IL_01b5:  stelem.ref
    IL_01b6:  ldarg.0
    IL_01b7:  ldfld      string[] Microsoft.Samples.SpaceInvaders.Invaders::scoreNames
    IL_01bc:  ldc.i4.8
    IL_01bd:  ldstr      "Ninth"
    IL_01c2:  stelem.ref
    IL_01c3:  ldarg.0
    IL_01c4:  ldfld      string[] Microsoft.Samples.SpaceInvaders.Invaders::scoreNames
    IL_01c9:  ldc.i4.s   9
    IL_01cb:  ldstr      "Tenth"
    IL_01d0:  stelem.ref
    IL_01d1:  ldarg.0
    IL_01d2:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::MakeLetters()
    IL_01d7:  nop
    IL_01d8:  ldarg.0
    IL_01d9:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_01de:  ldnull
    IL_01df:  ceq
    IL_01e1:  ldc.i4.0
    IL_01e2:  ceq
    IL_01e4:  stloc.0
    IL_01e5:  ldloc.0
    IL_01e6:  brtrue.s   IL_01f4

    IL_01e8:  ldarg.0
    IL_01e9:  call       class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.ListenerOperations::InitializeListener()
    IL_01ee:  stfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_01f3:  nop
    IL_01f4:  ret
  } // end of method Invaders::Initialize

  .method private hidebysig instance void 
          MakeLetters() cil managed
  {
    // Code size       1404 (0x57c)
    .maxstack  7
    .locals init ([0] string[] CS$0$0000)
    IL_0000:  ldarg.0
    IL_0001:  newobj     instance void class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::.ctor()
    IL_0006:  stfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
    IL_000b:  ldarg.0
    IL_000c:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
    IL_0011:  ldstr      "S"
    IL_0016:  ldstr      "S"
    IL_001b:  ldc.i4.s   15
    IL_001d:  ldc.i4.7
    IL_001e:  newarr     [mscorlib]System.String
    IL_0023:  stloc.0
    IL_0024:  ldloc.0
    IL_0025:  ldc.i4.0
    IL_0026:  ldstr      "SSSSS"
    IL_002b:  stelem.ref
    IL_002c:  ldloc.0
    IL_002d:  ldc.i4.1
    IL_002e:  ldstr      "S   S"
    IL_0033:  stelem.ref
    IL_0034:  ldloc.0
    IL_0035:  ldc.i4.2
    IL_0036:  ldstr      "S"
    IL_003b:  stelem.ref
    IL_003c:  ldloc.0
    IL_003d:  ldc.i4.3
    IL_003e:  ldstr      "SSSSS"
    IL_0043:  stelem.ref
    IL_0044:  ldloc.0
    IL_0045:  ldc.i4.4
    IL_0046:  ldstr      "    S"
    IL_004b:  stelem.ref
    IL_004c:  ldloc.0
    IL_004d:  ldc.i4.5
    IL_004e:  ldstr      "S   S"
    IL_0053:  stelem.ref
    IL_0054:  ldloc.0
    IL_0055:  ldc.i4.6
    IL_0056:  ldstr      "SSSSS"
    IL_005b:  stelem.ref
    IL_005c:  ldloc.0
    IL_005d:  newobj     instance void Microsoft.Samples.SpaceInvaders.Letter::.ctor(string,
                                                                                     valuetype [mscorlib]System.ConsoleColor,
                                                                                     string[])
    IL_0062:  callvirt   instance void class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::Add(!0,
                                                                                                                                                           !1)
    IL_0067:  nop
    IL_0068:  ldarg.0
    IL_0069:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
    IL_006e:  ldstr      "P"
    IL_0073:  ldstr      "P"
    IL_0078:  ldc.i4.s   10
    IL_007a:  ldc.i4.7
    IL_007b:  newarr     [mscorlib]System.String
    IL_0080:  stloc.0
    IL_0081:  ldloc.0
    IL_0082:  ldc.i4.0
    IL_0083:  ldstr      "PPPPP"
    IL_0088:  stelem.ref
    IL_0089:  ldloc.0
    IL_008a:  ldc.i4.1
    IL_008b:  ldstr      "P   P"
    IL_0090:  stelem.ref
    IL_0091:  ldloc.0
    IL_0092:  ldc.i4.2
    IL_0093:  ldstr      "P   P"
    IL_0098:  stelem.ref
    IL_0099:  ldloc.0
    IL_009a:  ldc.i4.3
    IL_009b:  ldstr      "PPPPP"
    IL_00a0:  stelem.ref
    IL_00a1:  ldloc.0
    IL_00a2:  ldc.i4.4
    IL_00a3:  ldstr      "P"
    IL_00a8:  stelem.ref
    IL_00a9:  ldloc.0
    IL_00aa:  ldc.i4.5
    IL_00ab:  ldstr      "P"
    IL_00b0:  stelem.ref
    IL_00b1:  ldloc.0
    IL_00b2:  ldc.i4.6
    IL_00b3:  ldstr      "P"
    IL_00b8:  stelem.ref
    IL_00b9:  ldloc.0
    IL_00ba:  newobj     instance void Microsoft.Samples.SpaceInvaders.Letter::.ctor(string,
                                                                                     valuetype [mscorlib]System.ConsoleColor,
                                                                                     string[])
    IL_00bf:  callvirt   instance void class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::Add(!0,
                                                                                                                                                           !1)
    IL_00c4:  nop
    IL_00c5:  ldarg.0
    IL_00c6:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
    IL_00cb:  ldstr      "A"
    IL_00d0:  ldstr      "A"
    IL_00d5:  ldc.i4.s   12
    IL_00d7:  ldc.i4.7
    IL_00d8:  newarr     [mscorlib]System.String
    IL_00dd:  stloc.0
    IL_00de:  ldloc.0
    IL_00df:  ldc.i4.0
    IL_00e0:  ldstr      "  A"
    IL_00e5:  stelem.ref
    IL_00e6:  ldloc.0
    IL_00e7:  ldc.i4.1
    IL_00e8:  ldstr      " AAA"
    IL_00ed:  stelem.ref
    IL_00ee:  ldloc.0
    IL_00ef:  ldc.i4.2
    IL_00f0:  ldstr      " A A"
    IL_00f5:  stelem.ref
    IL_00f6:  ldloc.0
    IL_00f7:  ldc.i4.3
    IL_00f8:  ldstr      "AA AA"
    IL_00fd:  stelem.ref
    IL_00fe:  ldloc.0
    IL_00ff:  ldc.i4.4
    IL_0100:  ldstr      "AAAAA"
    IL_0105:  stelem.ref
    IL_0106:  ldloc.0
    IL_0107:  ldc.i4.5
    IL_0108:  ldstr      "A   A"
    IL_010d:  stelem.ref
    IL_010e:  ldloc.0
    IL_010f:  ldc.i4.6
    IL_0110:  ldstr      "A   A"
    IL_0115:  stelem.ref
    IL_0116:  ldloc.0
    IL_0117:  newobj     instance void Microsoft.Samples.SpaceInvaders.Letter::.ctor(string,
                                                                                     valuetype [mscorlib]System.ConsoleColor,
                                                                                     string[])
    IL_011c:  callvirt   instance void class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::Add(!0,
                                                                                                                                                           !1)
    IL_0121:  nop
    IL_0122:  ldarg.0
    IL_0123:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
    IL_0128:  ldstr      "C"
    IL_012d:  ldstr      "C"
    IL_0132:  ldc.i4.7
    IL_0133:  ldc.i4.7
    IL_0134:  newarr     [mscorlib]System.String
    IL_0139:  stloc.0
    IL_013a:  ldloc.0
    IL_013b:  ldc.i4.0
    IL_013c:  ldstr      "CCCCC"
    IL_0141:  stelem.ref
    IL_0142:  ldloc.0
    IL_0143:  ldc.i4.1
    IL_0144:  ldstr      "C   C"
    IL_0149:  stelem.ref
    IL_014a:  ldloc.0
    IL_014b:  ldc.i4.2
    IL_014c:  ldstr      "C"
    IL_0151:  stelem.ref
    IL_0152:  ldloc.0
    IL_0153:  ldc.i4.3
    IL_0154:  ldstr      "C"
    IL_0159:  stelem.ref
    IL_015a:  ldloc.0
    IL_015b:  ldc.i4.4
    IL_015c:  ldstr      "C"
    IL_0161:  stelem.ref
    IL_0162:  ldloc.0
    IL_0163:  ldc.i4.5
    IL_0164:  ldstr      "C   C"
    IL_0169:  stelem.ref
    IL_016a:  ldloc.0
    IL_016b:  ldc.i4.6
    IL_016c:  ldstr      "CCCCC"
    IL_0171:  stelem.ref
    IL_0172:  ldloc.0
    IL_0173:  newobj     instance void Microsoft.Samples.SpaceInvaders.Letter::.ctor(string,
                                                                                     valuetype [mscorlib]System.ConsoleColor,
                                                                                     string[])
    IL_0178:  callvirt   instance void class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::Add(!0,
                                                                                                                                                           !1)
    IL_017d:  nop
    IL_017e:  ldarg.0
    IL_017f:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
    IL_0184:  ldstr      "E"
    IL_0189:  ldstr      "E"
    IL_018e:  ldc.i4.s   9
    IL_0190:  ldc.i4.7
    IL_0191:  newarr     [mscorlib]System.String
    IL_0196:  stloc.0
    IL_0197:  ldloc.0
    IL_0198:  ldc.i4.0
    IL_0199:  ldstr      "EEEEE"
    IL_019e:  stelem.ref
    IL_019f:  ldloc.0
    IL_01a0:  ldc.i4.1
    IL_01a1:  ldstr      "E"
    IL_01a6:  stelem.ref
    IL_01a7:  ldloc.0
    IL_01a8:  ldc.i4.2
    IL_01a9:  ldstr      "E"
    IL_01ae:  stelem.ref
    IL_01af:  ldloc.0
    IL_01b0:  ldc.i4.3
    IL_01b1:  ldstr      "EEE"
    IL_01b6:  stelem.ref
    IL_01b7:  ldloc.0
    IL_01b8:  ldc.i4.4
    IL_01b9:  ldstr      "E"
    IL_01be:  stelem.ref
    IL_01bf:  ldloc.0
    IL_01c0:  ldc.i4.5
    IL_01c1:  ldstr      "E"
    IL_01c6:  stelem.ref
    IL_01c7:  ldloc.0
    IL_01c8:  ldc.i4.6
    IL_01c9:  ldstr      "EEEEE"
    IL_01ce:  stelem.ref
    IL_01cf:  ldloc.0
    IL_01d0:  newobj     instance void Microsoft.Samples.SpaceInvaders.Letter::.ctor(string,
                                                                                     valuetype [mscorlib]System.ConsoleColor,
                                                                                     string[])
    IL_01d5:  callvirt   instance void class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::Add(!0,
                                                                                                                                                           !1)
    IL_01da:  nop
    IL_01db:  ldarg.0
    IL_01dc:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
    IL_01e1:  ldstr      "I"
    IL_01e6:  ldstr      "I"
    IL_01eb:  ldc.i4.s   9
    IL_01ed:  ldc.i4.7
    IL_01ee:  newarr     [mscorlib]System.String
    IL_01f3:  stloc.0
    IL_01f4:  ldloc.0
    IL_01f5:  ldc.i4.0
    IL_01f6:  ldstr      "IIIII"
    IL_01fb:  stelem.ref
    IL_01fc:  ldloc.0
    IL_01fd:  ldc.i4.1
    IL_01fe:  ldstr      "  I"
    IL_0203:  stelem.ref
    IL_0204:  ldloc.0
    IL_0205:  ldc.i4.2
    IL_0206:  ldstr      "  I"
    IL_020b:  stelem.ref
    IL_020c:  ldloc.0
    IL_020d:  ldc.i4.3
    IL_020e:  ldstr      "  I"
    IL_0213:  stelem.ref
    IL_0214:  ldloc.0
    IL_0215:  ldc.i4.4
    IL_0216:  ldstr      "  I"
    IL_021b:  stelem.ref
    IL_021c:  ldloc.0
    IL_021d:  ldc.i4.5
    IL_021e:  ldstr      "  I"
    IL_0223:  stelem.ref
    IL_0224:  ldloc.0
    IL_0225:  ldc.i4.6
    IL_0226:  ldstr      "IIIII"
    IL_022b:  stelem.ref
    IL_022c:  ldloc.0
    IL_022d:  newobj     instance void Microsoft.Samples.SpaceInvaders.Letter::.ctor(string,
                                                                                     valuetype [mscorlib]System.ConsoleColor,
                                                                                     string[])
    IL_0232:  callvirt   instance void class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::Add(!0,
                                                                                                                                                           !1)
    IL_0237:  nop
    IL_0238:  ldarg.0
    IL_0239:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
    IL_023e:  ldstr      "N"
    IL_0243:  ldstr      "N"
    IL_0248:  ldc.i4.6
    IL_0249:  ldc.i4.7
    IL_024a:  newarr     [mscorlib]System.String
    IL_024f:  stloc.0
    IL_0250:  ldloc.0
    IL_0251:  ldc.i4.0
    IL_0252:  ldstr      "N   N"
    IL_0257:  stelem.ref
    IL_0258:  ldloc.0
    IL_0259:  ldc.i4.1
    IL_025a:  ldstr      "NN  N"
    IL_025f:  stelem.ref
    IL_0260:  ldloc.0
    IL_0261:  ldc.i4.2
    IL_0262:  ldstr      "NN  N"
    IL_0267:  stelem.ref
    IL_0268:  ldloc.0
    IL_0269:  ldc.i4.3
    IL_026a:  ldstr      "N N N"
    IL_026f:  stelem.ref
    IL_0270:  ldloc.0
    IL_0271:  ldc.i4.4
    IL_0272:  ldstr      "N  NN"
    IL_0277:  stelem.ref
    IL_0278:  ldloc.0
    IL_0279:  ldc.i4.5
    IL_027a:  ldstr      "N  NN"
    IL_027f:  stelem.ref
    IL_0280:  ldloc.0
    IL_0281:  ldc.i4.6
    IL_0282:  ldstr      "N   N"
    IL_0287:  stelem.ref
    IL_0288:  ldloc.0
    IL_0289:  newobj     instance void Microsoft.Samples.SpaceInvaders.Letter::.ctor(string,
                                                                                     valuetype [mscorlib]System.ConsoleColor,
                                                                                     string[])
    IL_028e:  callvirt   instance void class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::Add(!0,
                                                                                                                                                           !1)
    IL_0293:  nop
    IL_0294:  ldarg.0
    IL_0295:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
    IL_029a:  ldstr      "V"
    IL_029f:  ldstr      "V"
    IL_02a4:  ldc.i4.s   14
    IL_02a6:  ldc.i4.7
    IL_02a7:  newarr     [mscorlib]System.String
    IL_02ac:  stloc.0
    IL_02ad:  ldloc.0
    IL_02ae:  ldc.i4.0
    IL_02af:  ldstr      "V   V"
    IL_02b4:  stelem.ref
    IL_02b5:  ldloc.0
    IL_02b6:  ldc.i4.1
    IL_02b7:  ldstr      "V   V"
    IL_02bc:  stelem.ref
    IL_02bd:  ldloc.0
    IL_02be:  ldc.i4.2
    IL_02bf:  ldstr      "V   V"
    IL_02c4:  stelem.ref
    IL_02c5:  ldloc.0
    IL_02c6:  ldc.i4.3
    IL_02c7:  ldstr      "V   V"
    IL_02cc:  stelem.ref
    IL_02cd:  ldloc.0
    IL_02ce:  ldc.i4.4
    IL_02cf:  ldstr      "V   V"
    IL_02d4:  stelem.ref
    IL_02d5:  ldloc.0
    IL_02d6:  ldc.i4.5
    IL_02d7:  ldstr      " V V"
    IL_02dc:  stelem.ref
    IL_02dd:  ldloc.0
    IL_02de:  ldc.i4.6
    IL_02df:  ldstr      "  V"
    IL_02e4:  stelem.ref
    IL_02e5:  ldloc.0
    IL_02e6:  newobj     instance void Microsoft.Samples.SpaceInvaders.Letter::.ctor(string,
                                                                                     valuetype [mscorlib]System.ConsoleColor,
                                                                                     string[])
    IL_02eb:  callvirt   instance void class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::Add(!0,
                                                                                                                                                           !1)
    IL_02f0:  nop
    IL_02f1:  ldarg.0
    IL_02f2:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
    IL_02f7:  ldstr      "D"
    IL_02fc:  ldstr      "D"
    IL_0301:  ldc.i4.s   13
    IL_0303:  ldc.i4.7
    IL_0304:  newarr     [mscorlib]System.String
    IL_0309:  stloc.0
    IL_030a:  ldloc.0
    IL_030b:  ldc.i4.0
    IL_030c:  ldstr      "DDD"
    IL_0311:  stelem.ref
    IL_0312:  ldloc.0
    IL_0313:  ldc.i4.1
    IL_0314:  ldstr      "D  D"
    IL_0319:  stelem.ref
    IL_031a:  ldloc.0
    IL_031b:  ldc.i4.2
    IL_031c:  ldstr      "D   D"
    IL_0321:  stelem.ref
    IL_0322:  ldloc.0
    IL_0323:  ldc.i4.3
    IL_0324:  ldstr      "D   D"
    IL_0329:  stelem.ref
    IL_032a:  ldloc.0
    IL_032b:  ldc.i4.4
    IL_032c:  ldstr      "D   D"
    IL_0331:  stelem.ref
    IL_0332:  ldloc.0
    IL_0333:  ldc.i4.5
    IL_0334:  ldstr      "D  D"
    IL_0339:  stelem.ref
    IL_033a:  ldloc.0
    IL_033b:  ldc.i4.6
    IL_033c:  ldstr      "DDD"
    IL_0341:  stelem.ref
    IL_0342:  ldloc.0
    IL_0343:  newobj     instance void Microsoft.Samples.SpaceInvaders.Letter::.ctor(string,
                                                                                     valuetype [mscorlib]System.ConsoleColor,
                                                                                     string[])
    IL_0348:  callvirt   instance void class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::Add(!0,
                                                                                                                                                           !1)
    IL_034d:  nop
    IL_034e:  ldarg.0
    IL_034f:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
    IL_0354:  ldstr      "R"
    IL_0359:  ldstr      "R"
    IL_035e:  ldc.i4.s   11
    IL_0360:  ldc.i4.7
    IL_0361:  newarr     [mscorlib]System.String
    IL_0366:  stloc.0
    IL_0367:  ldloc.0
    IL_0368:  ldc.i4.0
    IL_0369:  ldstr      "RRRR"
    IL_036e:  stelem.ref
    IL_036f:  ldloc.0
    IL_0370:  ldc.i4.1
    IL_0371:  ldstr      "R  R"
    IL_0376:  stelem.ref
    IL_0377:  ldloc.0
    IL_0378:  ldc.i4.2
    IL_0379:  ldstr      "R   R"
    IL_037e:  stelem.ref
    IL_037f:  ldloc.0
    IL_0380:  ldc.i4.3
    IL_0381:  ldstr      "RRRRR"
    IL_0386:  stelem.ref
    IL_0387:  ldloc.0
    IL_0388:  ldc.i4.4
    IL_0389:  ldstr      "R   R"
    IL_038e:  stelem.ref
    IL_038f:  ldloc.0
    IL_0390:  ldc.i4.5
    IL_0391:  ldstr      "R   R"
    IL_0396:  stelem.ref
    IL_0397:  ldloc.0
    IL_0398:  ldc.i4.6
    IL_0399:  ldstr      "R   R"
    IL_039e:  stelem.ref
    IL_039f:  ldloc.0
    IL_03a0:  newobj     instance void Microsoft.Samples.SpaceInvaders.Letter::.ctor(string,
                                                                                     valuetype [mscorlib]System.ConsoleColor,
                                                                                     string[])
    IL_03a5:  callvirt   instance void class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::Add(!0,
                                                                                                                                                           !1)
    IL_03aa:  nop
    IL_03ab:  ldarg.0
    IL_03ac:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
    IL_03b1:  ldstr      "O"
    IL_03b6:  ldstr      "O"
    IL_03bb:  ldc.i4.7
    IL_03bc:  ldc.i4.7
    IL_03bd:  newarr     [mscorlib]System.String
    IL_03c2:  stloc.0
    IL_03c3:  ldloc.0
    IL_03c4:  ldc.i4.0
    IL_03c5:  ldstr      "OOOOO"
    IL_03ca:  stelem.ref
    IL_03cb:  ldloc.0
    IL_03cc:  ldc.i4.1
    IL_03cd:  ldstr      "O   O"
    IL_03d2:  stelem.ref
    IL_03d3:  ldloc.0
    IL_03d4:  ldc.i4.2
    IL_03d5:  ldstr      "O   O"
    IL_03da:  stelem.ref
    IL_03db:  ldloc.0
    IL_03dc:  ldc.i4.3
    IL_03dd:  ldstr      "O   O"
    IL_03e2:  stelem.ref
    IL_03e3:  ldloc.0
    IL_03e4:  ldc.i4.4
    IL_03e5:  ldstr      "O   O"
    IL_03ea:  stelem.ref
    IL_03eb:  ldloc.0
    IL_03ec:  ldc.i4.5
    IL_03ed:  ldstr      "O   O"
    IL_03f2:  stelem.ref
    IL_03f3:  ldloc.0
    IL_03f4:  ldc.i4.6
    IL_03f5:  ldstr      "OOOOO"
    IL_03fa:  stelem.ref
    IL_03fb:  ldloc.0
    IL_03fc:  newobj     instance void Microsoft.Samples.SpaceInvaders.Letter::.ctor(string,
                                                                                     valuetype [mscorlib]System.ConsoleColor,
                                                                                     string[])
    IL_0401:  callvirt   instance void class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::Add(!0,
                                                                                                                                                           !1)
    IL_0406:  nop
    IL_0407:  ldarg.0
    IL_0408:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
    IL_040d:  ldstr      "G"
    IL_0412:  ldstr      "G"
    IL_0417:  ldc.i4.s   9
    IL_0419:  ldc.i4.7
    IL_041a:  newarr     [mscorlib]System.String
    IL_041f:  stloc.0
    IL_0420:  ldloc.0
    IL_0421:  ldc.i4.0
    IL_0422:  ldstr      "GGGGG"
    IL_0427:  stelem.ref
    IL_0428:  ldloc.0
    IL_0429:  ldc.i4.1
    IL_042a:  ldstr      "G   G"
    IL_042f:  stelem.ref
    IL_0430:  ldloc.0
    IL_0431:  ldc.i4.2
    IL_0432:  ldstr      "G"
    IL_0437:  stelem.ref
    IL_0438:  ldloc.0
    IL_0439:  ldc.i4.3
    IL_043a:  ldstr      "G"
    IL_043f:  stelem.ref
    IL_0440:  ldloc.0
    IL_0441:  ldc.i4.4
    IL_0442:  ldstr      "G  GG"
    IL_0447:  stelem.ref
    IL_0448:  ldloc.0
    IL_0449:  ldc.i4.5
    IL_044a:  ldstr      "G   G"
    IL_044f:  stelem.ref
    IL_0450:  ldloc.0
    IL_0451:  ldc.i4.6
    IL_0452:  ldstr      "GGGGG"
    IL_0457:  stelem.ref
    IL_0458:  ldloc.0
    IL_0459:  newobj     instance void Microsoft.Samples.SpaceInvaders.Letter::.ctor(string,
                                                                                     valuetype [mscorlib]System.ConsoleColor,
                                                                                     string[])
    IL_045e:  callvirt   instance void class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::Add(!0,
                                                                                                                                                           !1)
    IL_0463:  nop
    IL_0464:  ldarg.0
    IL_0465:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
    IL_046a:  ldstr      "M"
    IL_046f:  ldstr      "M"
    IL_0474:  ldc.i4.s   15
    IL_0476:  ldc.i4.7
    IL_0477:  newarr     [mscorlib]System.String
    IL_047c:  stloc.0
    IL_047d:  ldloc.0
    IL_047e:  ldc.i4.0
    IL_047f:  ldstr      "M   M"
    IL_0484:  stelem.ref
    IL_0485:  ldloc.0
    IL_0486:  ldc.i4.1
    IL_0487:  ldstr      "MM MM"
    IL_048c:  stelem.ref
    IL_048d:  ldloc.0
    IL_048e:  ldc.i4.2
    IL_048f:  ldstr      "M M M"
    IL_0494:  stelem.ref
    IL_0495:  ldloc.0
    IL_0496:  ldc.i4.3
    IL_0497:  ldstr      "M M M"
    IL_049c:  stelem.ref
    IL_049d:  ldloc.0
    IL_049e:  ldc.i4.4
    IL_049f:  ldstr      "M   M"
    IL_04a4:  stelem.ref
    IL_04a5:  ldloc.0
    IL_04a6:  ldc.i4.5
    IL_04a7:  ldstr      "M   M"
    IL_04ac:  stelem.ref
    IL_04ad:  ldloc.0
    IL_04ae:  ldc.i4.6
    IL_04af:  ldstr      "M   M"
    IL_04b4:  stelem.ref
    IL_04b5:  ldloc.0
    IL_04b6:  newobj     instance void Microsoft.Samples.SpaceInvaders.Letter::.ctor(string,
                                                                                     valuetype [mscorlib]System.ConsoleColor,
                                                                                     string[])
    IL_04bb:  callvirt   instance void class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::Add(!0,
                                                                                                                                                           !1)
    IL_04c0:  nop
    IL_04c1:  ldarg.0
    IL_04c2:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
    IL_04c7:  ldstr      "U"
    IL_04cc:  ldstr      "U"
    IL_04d1:  ldc.i4.s   10
    IL_04d3:  ldc.i4.7
    IL_04d4:  newarr     [mscorlib]System.String
    IL_04d9:  stloc.0
    IL_04da:  ldloc.0
    IL_04db:  ldc.i4.0
    IL_04dc:  ldstr      "U   U"
    IL_04e1:  stelem.ref
    IL_04e2:  ldloc.0
    IL_04e3:  ldc.i4.1
    IL_04e4:  ldstr      "U   U"
    IL_04e9:  stelem.ref
    IL_04ea:  ldloc.0
    IL_04eb:  ldc.i4.2
    IL_04ec:  ldstr      "U   U"
    IL_04f1:  stelem.ref
    IL_04f2:  ldloc.0
    IL_04f3:  ldc.i4.3
    IL_04f4:  ldstr      "U   U"
    IL_04f9:  stelem.ref
    IL_04fa:  ldloc.0
    IL_04fb:  ldc.i4.4
    IL_04fc:  ldstr      "U   U"
    IL_0501:  stelem.ref
    IL_0502:  ldloc.0
    IL_0503:  ldc.i4.5
    IL_0504:  ldstr      "U   U"
    IL_0509:  stelem.ref
    IL_050a:  ldloc.0
    IL_050b:  ldc.i4.6
    IL_050c:  ldstr      " UUU"
    IL_0511:  stelem.ref
    IL_0512:  ldloc.0
    IL_0513:  newobj     instance void Microsoft.Samples.SpaceInvaders.Letter::.ctor(string,
                                                                                     valuetype [mscorlib]System.ConsoleColor,
                                                                                     string[])
    IL_0518:  callvirt   instance void class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::Add(!0,
                                                                                                                                                           !1)
    IL_051d:  nop
    IL_051e:  ldarg.0
    IL_051f:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
    IL_0524:  ldstr      "H"
    IL_0529:  ldstr      "H"
    IL_052e:  ldc.i4.s   10
    IL_0530:  ldc.i4.7
    IL_0531:  newarr     [mscorlib]System.String
    IL_0536:  stloc.0
    IL_0537:  ldloc.0
    IL_0538:  ldc.i4.0
    IL_0539:  ldstr      "H   H"
    IL_053e:  stelem.ref
    IL_053f:  ldloc.0
    IL_0540:  ldc.i4.1
    IL_0541:  ldstr      "H   H"
    IL_0546:  stelem.ref
    IL_0547:  ldloc.0
    IL_0548:  ldc.i4.2
    IL_0549:  ldstr      "H   H"
    IL_054e:  stelem.ref
    IL_054f:  ldloc.0
    IL_0550:  ldc.i4.3
    IL_0551:  ldstr      "HHHHH"
    IL_0556:  stelem.ref
    IL_0557:  ldloc.0
    IL_0558:  ldc.i4.4
    IL_0559:  ldstr      "H   H"
    IL_055e:  stelem.ref
    IL_055f:  ldloc.0
    IL_0560:  ldc.i4.5
    IL_0561:  ldstr      "H   H"
    IL_0566:  stelem.ref
    IL_0567:  ldloc.0
    IL_0568:  ldc.i4.6
    IL_0569:  ldstr      "H   H"
    IL_056e:  stelem.ref
    IL_056f:  ldloc.0
    IL_0570:  newobj     instance void Microsoft.Samples.SpaceInvaders.Letter::.ctor(string,
                                                                                     valuetype [mscorlib]System.ConsoleColor,
                                                                                     string[])
    IL_0575:  callvirt   instance void class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::Add(!0,
                                                                                                                                                           !1)
    IL_057a:  nop
    IL_057b:  ret
  } // end of method Invaders::MakeLetters

  .method private hidebysig instance void 
          Reset() cil managed
  {
    // Code size       16 (0x10)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.0
    IL_0002:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DisableTimers(bool)
    IL_0007:  nop
    IL_0008:  ldarg.0
    IL_0009:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ResetTimers()
    IL_000e:  nop
    IL_000f:  ret
  } // end of method Invaders::Reset

  .method private hidebysig instance void 
          DrawLetters(int32 left,
                      int32 top,
                      int32 leftAddition,
                      int32 sleep,
                      bool blackOut,
                      string[] rows) cil managed
  {
    .param [6]
    .custom instance void [mscorlib]System.ParamArrayAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       195 (0xc3)
    .maxstack  4
    .locals init ([0] int32 count,
             [1] int32 leftPos,
             [2] string row,
             [3] string s,
             [4] string[] CS$6$0000,
             [5] int32 CS$7$0001,
             [6] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0002,
             [7] string[] CS$6$0003,
             [8] int32 CS$7$0004,
             [9] bool CS$4$0005)
    IL_0000:  ldc.i4.0
    IL_0001:  stloc.0
    IL_0002:  ldarg.1
    IL_0003:  stloc.1
    IL_0004:  ldarg.s    rows
    IL_0006:  stloc.s    CS$6$0000
    IL_0008:  ldc.i4.0
    IL_0009:  stloc.s    CS$7$0001
    IL_000b:  br         IL_00b1

    IL_0010:  ldloc.s    CS$6$0000
    IL_0012:  ldloc.s    CS$7$0001
    IL_0014:  ldelem.ref
    IL_0015:  stloc.2
    IL_0016:  ldarg.0
    IL_0017:  dup
    IL_0018:  stloc.s    CS$2$0002
    IL_001a:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_001f:  nop
    .try
    {
      IL_0020:  ldarg.0
      IL_0021:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
      IL_0026:  ldloc.2
      IL_0027:  callvirt   instance !1 class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::get_Item(!0)
      IL_002c:  callvirt   instance string[] Microsoft.Samples.SpaceInvaders.Letter::GetValues()
      IL_0031:  stloc.s    CS$6$0003
      IL_0033:  ldc.i4.0
      IL_0034:  stloc.s    CS$7$0004
      IL_0036:  br.s       IL_0073

      IL_0038:  ldloc.s    CS$6$0003
      IL_003a:  ldloc.s    CS$7$0004
      IL_003c:  ldelem.ref
      IL_003d:  stloc.3
      IL_003e:  ldloc.1
      IL_003f:  ldarg.2
      IL_0040:  ldloc.0
      IL_0041:  add
      IL_0042:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_0047:  nop
      IL_0048:  ldarg.0
      IL_0049:  ldloc.3
      IL_004a:  ldarg.s    blackOut
      IL_004c:  brtrue.s   IL_0061

      IL_004e:  ldarg.0
      IL_004f:  ldfld      class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter> Microsoft.Samples.SpaceInvaders.Invaders::letters
      IL_0054:  ldloc.2
      IL_0055:  callvirt   instance !1 class [mscorlib]System.Collections.Generic.'Dictionary`2'<string,class Microsoft.Samples.SpaceInvaders.Letter>::get_Item(!0)
      IL_005a:  callvirt   instance valuetype [mscorlib]System.ConsoleColor Microsoft.Samples.SpaceInvaders.Letter::get_Color()
      IL_005f:  br.s       IL_0062

      IL_0061:  ldc.i4.0
      IL_0062:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::WriteEntry(string,
                                                                                              valuetype [mscorlib]System.ConsoleColor)
      IL_0067:  nop
      IL_0068:  ldloc.0
      IL_0069:  ldc.i4.1
      IL_006a:  add
      IL_006b:  stloc.0
      IL_006c:  nop
      IL_006d:  ldloc.s    CS$7$0004
      IL_006f:  ldc.i4.1
      IL_0070:  add
      IL_0071:  stloc.s    CS$7$0004
      IL_0073:  ldloc.s    CS$7$0004
      IL_0075:  ldloc.s    CS$6$0003
      IL_0077:  ldlen
      IL_0078:  conv.i4
      IL_0079:  clt
      IL_007b:  stloc.s    CS$4$0005
      IL_007d:  ldloc.s    CS$4$0005
      IL_007f:  brtrue.s   IL_0038

      IL_0081:  nop
      IL_0082:  leave.s    IL_008d

    }  // end .try
    finally
    {
      IL_0084:  ldloc.s    CS$2$0002
      IL_0086:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_008b:  nop
      IL_008c:  endfinally
    }  // end handler
    IL_008d:  nop
    IL_008e:  ldarg.s    sleep
    IL_0090:  ldc.i4.0
    IL_0091:  cgt
    IL_0093:  ldc.i4.0
    IL_0094:  ceq
    IL_0096:  stloc.s    CS$4$0005
    IL_0098:  ldloc.s    CS$4$0005
    IL_009a:  brtrue.s   IL_00a4

    IL_009c:  ldarg.s    sleep
    IL_009e:  call       void [mscorlib]System.Threading.Thread::Sleep(int32)
    IL_00a3:  nop
    IL_00a4:  ldloc.1
    IL_00a5:  ldarg.3
    IL_00a6:  add
    IL_00a7:  stloc.1
    IL_00a8:  ldc.i4.0
    IL_00a9:  stloc.0
    IL_00aa:  nop
    IL_00ab:  ldloc.s    CS$7$0001
    IL_00ad:  ldc.i4.1
    IL_00ae:  add
    IL_00af:  stloc.s    CS$7$0001
    IL_00b1:  ldloc.s    CS$7$0001
    IL_00b3:  ldloc.s    CS$6$0000
    IL_00b5:  ldlen
    IL_00b6:  conv.i4
    IL_00b7:  clt
    IL_00b9:  stloc.s    CS$4$0005
    IL_00bb:  ldloc.s    CS$4$0005
    IL_00bd:  brtrue     IL_0010

    IL_00c2:  ret
  } // end of method Invaders::DrawLetters

  .method private hidebysig instance void 
          StartScreen() cil managed
  {
    // Code size       397 (0x18d)
    .maxstack  9
    .locals init ([0] int32 i,
             [1] valuetype [mscorlib]System.ConsoleColor color,
             [2] string[] CS$0$0000,
             [3] object[] CS$0$0001,
             [4] bool CS$4$0002)
    IL_0000:  call       void [mscorlib]System.Console::Clear()
    IL_0005:  nop
    IL_0006:  ldarg.0
    IL_0007:  ldc.i4.s   11
    IL_0009:  ldc.i4.4
    IL_000a:  ldc.i4.s   12
    IL_000c:  ldc.i4.0
    IL_000d:  ldc.i4.0
    IL_000e:  ldc.i4.5
    IL_000f:  newarr     [mscorlib]System.String
    IL_0014:  stloc.2
    IL_0015:  ldloc.2
    IL_0016:  ldc.i4.0
    IL_0017:  ldstr      "S"
    IL_001c:  stelem.ref
    IL_001d:  ldloc.2
    IL_001e:  ldc.i4.1
    IL_001f:  ldstr      "P"
    IL_0024:  stelem.ref
    IL_0025:  ldloc.2
    IL_0026:  ldc.i4.2
    IL_0027:  ldstr      "A"
    IL_002c:  stelem.ref
    IL_002d:  ldloc.2
    IL_002e:  ldc.i4.3
    IL_002f:  ldstr      "C"
    IL_0034:  stelem.ref
    IL_0035:  ldloc.2
    IL_0036:  ldc.i4.4
    IL_0037:  ldstr      "E"
    IL_003c:  stelem.ref
    IL_003d:  ldloc.2
    IL_003e:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawLetters(int32,
                                                                                             int32,
                                                                                             int32,
                                                                                             int32,
                                                                                             bool,
                                                                                             string[])
    IL_0043:  nop
    IL_0044:  ldarg.0
    IL_0045:  ldc.i4.s   10
    IL_0047:  ldc.i4.s   12
    IL_0049:  ldc.i4.7
    IL_004a:  ldc.i4.0
    IL_004b:  ldc.i4.0
    IL_004c:  ldc.i4.8
    IL_004d:  newarr     [mscorlib]System.String
    IL_0052:  stloc.2
    IL_0053:  ldloc.2
    IL_0054:  ldc.i4.0
    IL_0055:  ldstr      "I"
    IL_005a:  stelem.ref
    IL_005b:  ldloc.2
    IL_005c:  ldc.i4.1
    IL_005d:  ldstr      "N"
    IL_0062:  stelem.ref
    IL_0063:  ldloc.2
    IL_0064:  ldc.i4.2
    IL_0065:  ldstr      "V"
    IL_006a:  stelem.ref
    IL_006b:  ldloc.2
    IL_006c:  ldc.i4.3
    IL_006d:  ldstr      "A"
    IL_0072:  stelem.ref
    IL_0073:  ldloc.2
    IL_0074:  ldc.i4.4
    IL_0075:  ldstr      "D"
    IL_007a:  stelem.ref
    IL_007b:  ldloc.2
    IL_007c:  ldc.i4.5
    IL_007d:  ldstr      "E"
    IL_0082:  stelem.ref
    IL_0083:  ldloc.2
    IL_0084:  ldc.i4.6
    IL_0085:  ldstr      "R"
    IL_008a:  stelem.ref
    IL_008b:  ldloc.2
    IL_008c:  ldc.i4.7
    IL_008d:  ldstr      "S"
    IL_0092:  stelem.ref
    IL_0093:  ldloc.2
    IL_0094:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawLetters(int32,
                                                                                             int32,
                                                                                             int32,
                                                                                             int32,
                                                                                             bool,
                                                                                             string[])
    IL_0099:  nop
    IL_009a:  ldc.i4.8
    IL_009b:  ldc.i4.s   22
    IL_009d:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_00a2:  nop
    IL_00a3:  ldarg.0
    IL_00a4:  ldstr      "Esc    End Game"
    IL_00a9:  ldc.i4.s   11
    IL_00ab:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::WriteEntry(string,
                                                                                            valuetype [mscorlib]System.ConsoleColor)
    IL_00b0:  nop
    IL_00b1:  ldc.i4.8
    IL_00b2:  ldc.i4.s   24
    IL_00b4:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_00b9:  nop
    IL_00ba:  ldarg.0
    IL_00bb:  ldstr      "S      Start New Game"
    IL_00c0:  ldc.i4.s   15
    IL_00c2:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::WriteEntry(string,
                                                                                            valuetype [mscorlib]System.ConsoleColor)
    IL_00c7:  nop
    IL_00c8:  ldc.i4.8
    IL_00c9:  ldc.i4.s   26
    IL_00cb:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_00d0:  nop
    IL_00d1:  ldarg.0
    IL_00d2:  ldstr      "P      Pause (In Game)"
    IL_00d7:  ldc.i4.s   10
    IL_00d9:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::WriteEntry(string,
                                                                                            valuetype [mscorlib]System.ConsoleColor)
    IL_00de:  nop
    IL_00df:  ldc.i4.8
    IL_00e0:  ldc.i4.s   28
    IL_00e2:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_00e7:  nop
    IL_00e8:  ldarg.0
    IL_00e9:  ldstr      "H      High Score Table"
    IL_00ee:  ldc.i4.s   12
    IL_00f0:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::WriteEntry(string,
                                                                                            valuetype [mscorlib]System.ConsoleColor)
    IL_00f5:  nop
    IL_00f6:  ldc.i4.8
    IL_00f7:  ldc.i4.s   30
    IL_00f9:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_00fe:  nop
    IL_00ff:  ldarg.0
    IL_0100:  ldstr      "M      Mute/Unmute Sound"
    IL_0105:  ldc.i4.s   13
    IL_0107:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::WriteEntry(string,
                                                                                            valuetype [mscorlib]System.ConsoleColor)
    IL_010c:  nop
    IL_010d:  ldc.i4.8
    IL_010e:  ldc.i4.s   22
    IL_0110:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_0115:  nop
    IL_0116:  ldc.i4.1
    IL_0117:  stloc.0
    IL_0118:  br.s       IL_017a

    IL_011a:  ldarg.0
    IL_011b:  ldloc.0
    IL_011c:  call       instance valuetype [mscorlib]System.ConsoleColor Microsoft.Samples.SpaceInvaders.Invaders::GetNextColor(int32)
    IL_0121:  stloc.1
    IL_0122:  ldarg.0
    IL_0123:  ldc.i4.s   50
    IL_0125:  ldloc.0
    IL_0126:  ldc.i4.s   21
    IL_0128:  add
    IL_0129:  ldloc.1
    IL_012a:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawInvader(int32,
                                                                                             int32,
                                                                                             valuetype [mscorlib]System.ConsoleColor)
    IL_012f:  nop
    IL_0130:  ldc.i4.s   55
    IL_0132:  ldloc.0
    IL_0133:  ldc.i4.s   21
    IL_0135:  add
    IL_0136:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_013b:  nop
    IL_013c:  ldarg.0
    IL_013d:  ldstr      " = "
    IL_0142:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_CurrentCulture()
    IL_0147:  ldstr      "{0:00}"
    IL_014c:  ldc.i4.1
    IL_014d:  newarr     [mscorlib]System.Object
    IL_0152:  stloc.3
    IL_0153:  ldloc.3
    IL_0154:  ldc.i4.0
    IL_0155:  ldloc.0
    IL_0156:  ldc.i4.5
    IL_0157:  mul
    IL_0158:  box        [mscorlib]System.Int32
    IL_015d:  stelem.ref
    IL_015e:  ldloc.3
    IL_015f:  call       string [mscorlib]System.String::Format(class [mscorlib]System.IFormatProvider,
                                                                string,
                                                                object[])
    IL_0164:  ldstr      " points"
    IL_0169:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_016e:  ldloc.1
    IL_016f:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::WriteEntry(string,
                                                                                            valuetype [mscorlib]System.ConsoleColor)
    IL_0174:  nop
    IL_0175:  nop
    IL_0176:  ldloc.0
    IL_0177:  ldc.i4.1
    IL_0178:  add
    IL_0179:  stloc.0
    IL_017a:  ldloc.0
    IL_017b:  ldc.i4.s   12
    IL_017d:  clt
    IL_017f:  stloc.s    CS$4$0002
    IL_0181:  ldloc.s    CS$4$0002
    IL_0183:  brtrue.s   IL_011a

    IL_0185:  ldarg.0
    IL_0186:  ldc.i4.0
    IL_0187:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::highScoreDisplayed
    IL_018c:  ret
  } // end of method Invaders::StartScreen

  .method private hidebysig instance void 
          StartGame() cil managed
  {
    // Code size       319 (0x13f)
    .maxstack  4
    .locals init ([0] bool CS$4$0000)
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.1
    IL_0002:  stfld      valuetype Microsoft.Samples.SpaceInvaders.GameState Microsoft.Samples.SpaceInvaders.Invaders::gameOver
    IL_0007:  ldarg.0
    IL_0008:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
    IL_000d:  stloc.0
    IL_000e:  ldloc.0
    IL_000f:  brtrue.s   IL_0082

    IL_0011:  ldarg.0
    IL_0012:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_0017:  call       void Microsoft.Samples.SpaceInvaders.ListenerOperations::StartGameTrace(class [System]System.Diagnostics.TraceSource)
    IL_001c:  nop
    IL_001d:  ldarg.0
    IL_001e:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_0023:  ldstr      "gamestats"
    IL_0028:  call       void Microsoft.Samples.SpaceInvaders.ListenerOperations::RemoveListenerFromSource(class [System]System.Diagnostics.TraceSource,
                                                                                                           string)
    IL_002d:  nop
    IL_002e:  ldstr      "gamestats.log"
    IL_0033:  call       void [mscorlib]System.IO.File::Delete(string)
    IL_0038:  nop
    IL_0039:  ldarg.0
    IL_003a:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_003f:  ldstr      "gamestats"
    IL_0044:  call       class [System]System.Diagnostics.TextWriterTraceListener Microsoft.Samples.SpaceInvaders.ListenerOperations::GetListener(string)
    IL_0049:  call       void Microsoft.Samples.SpaceInvaders.ListenerOperations::AddListenerToSource(class [System]System.Diagnostics.TraceSource,
                                                                                                      class [System]System.Diagnostics.TraceListener)
    IL_004e:  nop
    IL_004f:  ldarg.0
    IL_0050:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_0055:  ldstr      "gamedemo"
    IL_005a:  call       void Microsoft.Samples.SpaceInvaders.ListenerOperations::RemoveListenerFromSource(class [System]System.Diagnostics.TraceSource,
                                                                                                           string)
    IL_005f:  nop
    IL_0060:  ldstr      "demo.log"
    IL_0065:  call       void [mscorlib]System.IO.File::Delete(string)
    IL_006a:  nop
    IL_006b:  ldarg.0
    IL_006c:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_0071:  ldstr      "gamedemo"
    IL_0076:  call       class [System]System.Diagnostics.TextWriterTraceListener Microsoft.Samples.SpaceInvaders.ListenerOperations::GetListener(string)
    IL_007b:  call       void Microsoft.Samples.SpaceInvaders.ListenerOperations::AddListenerToSource(class [System]System.Diagnostics.TraceSource,
                                                                                                      class [System]System.Diagnostics.TraceListener)
    IL_0080:  nop
    IL_0081:  nop
    IL_0082:  ldarg.0
    IL_0083:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
    IL_0088:  stloc.0
    IL_0089:  ldloc.0
    IL_008a:  brtrue.s   IL_00ad

    IL_008c:  ldarg.0
    IL_008d:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_0092:  ldc.i4.8
    IL_0093:  ldc.i4.8
    IL_0094:  ldstr      "Game Started"
    IL_0099:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                          int32,
                                                                                          string)
    IL_009e:  nop
    IL_009f:  ldarg.0
    IL_00a0:  ldstr      "Good Luck!"
    IL_00a5:  ldnull
    IL_00a6:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::WriteLcdLine(string,
                                                                                              string)
    IL_00ab:  nop
    IL_00ac:  nop
    IL_00ad:  call       void [mscorlib]System.Console::Clear()
    IL_00b2:  nop
    IL_00b3:  ldarg.0
    IL_00b4:  ldc.i4.0
    IL_00b5:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::iterationCount
    IL_00ba:  ldarg.0
    IL_00bb:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ClearLists()
    IL_00c0:  nop
    IL_00c1:  ldarg.0
    IL_00c2:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::Reset()
    IL_00c7:  nop
    IL_00c8:  ldarg.0
    IL_00c9:  ldc.i4.0
    IL_00ca:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::highScoreDisplayed
    IL_00cf:  ldarg.0
    IL_00d0:  ldc.i4.0
    IL_00d1:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::shipBeingDestroyed
    IL_00d6:  ldarg.0
    IL_00d7:  ldc.i4.1
    IL_00d8:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::invadersMoveRight
    IL_00dd:  ldarg.0
    IL_00de:  ldc.i4.3
    IL_00df:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::shipCount
    IL_00e4:  ldarg.0
    IL_00e5:  ldc.i4.0
    IL_00e6:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::iterationCount
    IL_00eb:  ldarg.0
    IL_00ec:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ScoreUpdate()
    IL_00f1:  nop
    IL_00f2:  ldarg.0
    IL_00f3:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawReserveShips()
    IL_00f8:  nop
    IL_00f9:  ldarg.0
    IL_00fa:  ldarg.0
    IL_00fb:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::iterationCount
    IL_0100:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::InitializeInvaders(int32)
    IL_0105:  nop
    IL_0106:  ldarg.0
    IL_0107:  dup
    IL_0108:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::iterationCount
    IL_010d:  ldc.i4.1
    IL_010e:  add
    IL_010f:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::iterationCount
    IL_0114:  ldarg.0
    IL_0115:  call       valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
    IL_011a:  stfld      valuetype [mscorlib]System.DateTime Microsoft.Samples.SpaceInvaders.Invaders::iterationStartTime
    IL_011f:  ldarg.0
    IL_0120:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersBulletTimer
    IL_0125:  ldc.i4.1
    IL_0126:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_012b:  ldarg.0
    IL_012c:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::getSerialKeys
    IL_0131:  ldc.i4.1
    IL_0132:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_0137:  ldarg.0
    IL_0138:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawShields()
    IL_013d:  nop
    IL_013e:  ret
  } // end of method Invaders::StartGame

  .method private hidebysig instance void 
          DrawReserveShips() cil managed
  {
    // Code size       150 (0x96)
    .maxstack  7
    .locals init ([0] int32 i,
             [1] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0000,
             [2] bool CS$4$0001)
    IL_0000:  ldarg.0
    IL_0001:  dup
    IL_0002:  stloc.1
    IL_0003:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0008:  nop
    .try
    {
      IL_0009:  ldc.i4.s   11
      IL_000b:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
      IL_0010:  ldc.i4.2
      IL_0011:  stloc.0
      IL_0012:  br.s       IL_002e

      IL_0014:  ldc.i4.0
      IL_0015:  ldc.i4.0
      IL_0016:  ldc.i4.3
      IL_0017:  ldc.i4.1
      IL_0018:  call       int32 [mscorlib]System.Console::get_WindowWidth()
      IL_001d:  ldc.i4.3
      IL_001e:  sub
      IL_001f:  ldc.i4.3
      IL_0020:  ldloc.0
      IL_0021:  mul
      IL_0022:  sub
      IL_0023:  ldc.i4.0
      IL_0024:  call       void [mscorlib]System.Console::MoveBufferArea(int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32)
      IL_0029:  nop
      IL_002a:  ldloc.0
      IL_002b:  ldc.i4.1
      IL_002c:  sub
      IL_002d:  stloc.0
      IL_002e:  ldloc.0
      IL_002f:  ldc.i4.0
      IL_0030:  cgt
      IL_0032:  stloc.2
      IL_0033:  ldloc.2
      IL_0034:  brtrue.s   IL_0014

      IL_0036:  ldarg.0
      IL_0037:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::shipCount
      IL_003c:  ldc.i4.1
      IL_003d:  sub
      IL_003e:  stloc.0
      IL_003f:  br.s       IL_0081

      IL_0041:  call       int32 [mscorlib]System.Console::get_WindowWidth()
      IL_0046:  ldc.i4.3
      IL_0047:  sub
      IL_0048:  ldc.i4.3
      IL_0049:  ldloc.0
      IL_004a:  mul
      IL_004b:  sub
      IL_004c:  ldc.i4.0
      IL_004d:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_0052:  nop
      IL_0053:  ldstr      "{0}{1}{2}"
      IL_0058:  ldc.i4     0x2560
      IL_005d:  box        [mscorlib]System.Char
      IL_0062:  ldc.i4     0x2567
      IL_0067:  box        [mscorlib]System.Char
      IL_006c:  ldc.i4     0x2563
      IL_0071:  box        [mscorlib]System.Char
      IL_0076:  call       void [mscorlib]System.Console::Write(string,
                                                                object,
                                                                object,
                                                                object)
      IL_007b:  nop
      IL_007c:  nop
      IL_007d:  ldloc.0
      IL_007e:  ldc.i4.1
      IL_007f:  sub
      IL_0080:  stloc.0
      IL_0081:  ldloc.0
      IL_0082:  ldc.i4.0
      IL_0083:  cgt
      IL_0085:  stloc.2
      IL_0086:  ldloc.2
      IL_0087:  brtrue.s   IL_0041

      IL_0089:  nop
      IL_008a:  leave.s    IL_0094

    }  // end .try
    finally
    {
      IL_008c:  ldloc.1
      IL_008d:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0092:  nop
      IL_0093:  endfinally
    }  // end handler
    IL_0094:  nop
    IL_0095:  ret
  } // end of method Invaders::DrawReserveShips

  .method private hidebysig instance void 
          DrawShields() cil managed
  {
    // Code size       414 (0x19e)
    .maxstack  5
    .locals init ([0] int32 i,
             [1] int32 j,
             [2] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0000,
             [3] bool CS$4$0001)
    IL_0000:  ldarg.0
    IL_0001:  newobj     instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::.ctor()
    IL_0006:  stfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
    IL_000b:  ldarg.0
    IL_000c:  dup
    IL_000d:  stloc.2
    IL_000e:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0013:  nop
    .try
    {
      IL_0014:  ldc.i4.7
      IL_0015:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
      IL_001a:  ldc.i4.0
      IL_001b:  stloc.0
      IL_001c:  br         IL_0186

      IL_0021:  ldloc.0
      IL_0022:  ldc.i4.s   14
      IL_0024:  mul
      IL_0025:  ldc.i4.5
      IL_0026:  add
      IL_0027:  call       int32 [mscorlib]System.Console::get_WindowHeight()
      IL_002c:  ldc.i4.8
      IL_002d:  sub
      IL_002e:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_0033:  nop
      IL_0034:  ldstr      "{0}{0}{0}{0}{0}{0}"
      IL_0039:  ldc.i4     0x2588
      IL_003e:  box        [mscorlib]System.Char
      IL_0043:  call       void [mscorlib]System.Console::Write(string,
                                                                object)
      IL_0048:  nop
      IL_0049:  ldloc.0
      IL_004a:  ldc.i4.s   14
      IL_004c:  mul
      IL_004d:  ldc.i4.5
      IL_004e:  add
      IL_004f:  call       int32 [mscorlib]System.Console::get_WindowHeight()
      IL_0054:  ldc.i4.7
      IL_0055:  sub
      IL_0056:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_005b:  nop
      IL_005c:  ldstr      "{0}{0}  {0}{0}"
      IL_0061:  ldc.i4     0x2588
      IL_0066:  box        [mscorlib]System.Char
      IL_006b:  call       void [mscorlib]System.Console::Write(string,
                                                                object)
      IL_0070:  nop
      IL_0071:  ldloc.0
      IL_0072:  ldc.i4.s   14
      IL_0074:  mul
      IL_0075:  ldc.i4.5
      IL_0076:  add
      IL_0077:  call       int32 [mscorlib]System.Console::get_WindowHeight()
      IL_007c:  ldc.i4.6
      IL_007d:  sub
      IL_007e:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_0083:  nop
      IL_0084:  ldstr      "{0}{0}  {0}{0}"
      IL_0089:  ldc.i4     0x2588
      IL_008e:  box        [mscorlib]System.Char
      IL_0093:  call       void [mscorlib]System.Console::Write(string,
                                                                object)
      IL_0098:  nop
      IL_0099:  ldc.i4.5
      IL_009a:  stloc.1
      IL_009b:  br.s       IL_00c5

      IL_009d:  ldarg.0
      IL_009e:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
      IL_00a3:  ldloc.0
      IL_00a4:  ldc.i4.s   14
      IL_00a6:  mul
      IL_00a7:  ldloc.1
      IL_00a8:  add
      IL_00a9:  call       int32 [mscorlib]System.Console::get_WindowHeight()
      IL_00ae:  ldc.i4.8
      IL_00af:  sub
      IL_00b0:  newobj     instance void Microsoft.Samples.SpaceInvaders.ItemPosition::.ctor(int32,
                                                                                             int32)
      IL_00b5:  newobj     instance void Microsoft.Samples.SpaceInvaders.Shield::.ctor(class Microsoft.Samples.SpaceInvaders.ItemPosition)
      IL_00ba:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::Add(!0)
      IL_00bf:  nop
      IL_00c0:  nop
      IL_00c1:  ldloc.1
      IL_00c2:  ldc.i4.1
      IL_00c3:  add
      IL_00c4:  stloc.1
      IL_00c5:  ldloc.1
      IL_00c6:  ldc.i4.s   10
      IL_00c8:  cgt
      IL_00ca:  ldc.i4.0
      IL_00cb:  ceq
      IL_00cd:  stloc.3
      IL_00ce:  ldloc.3
      IL_00cf:  brtrue.s   IL_009d

      IL_00d1:  ldc.i4.0
      IL_00d2:  stloc.1
      IL_00d3:  br         IL_0173

      IL_00d8:  ldarg.0
      IL_00d9:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
      IL_00de:  ldloc.0
      IL_00df:  ldc.i4.s   14
      IL_00e1:  mul
      IL_00e2:  ldc.i4.5
      IL_00e3:  add
      IL_00e4:  call       int32 [mscorlib]System.Console::get_WindowHeight()
      IL_00e9:  ldc.i4.7
      IL_00ea:  ldloc.1
      IL_00eb:  sub
      IL_00ec:  sub
      IL_00ed:  newobj     instance void Microsoft.Samples.SpaceInvaders.ItemPosition::.ctor(int32,
                                                                                             int32)
      IL_00f2:  newobj     instance void Microsoft.Samples.SpaceInvaders.Shield::.ctor(class Microsoft.Samples.SpaceInvaders.ItemPosition)
      IL_00f7:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::Add(!0)
      IL_00fc:  nop
      IL_00fd:  ldarg.0
      IL_00fe:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
      IL_0103:  ldloc.0
      IL_0104:  ldc.i4.s   14
      IL_0106:  mul
      IL_0107:  ldc.i4.6
      IL_0108:  add
      IL_0109:  call       int32 [mscorlib]System.Console::get_WindowHeight()
      IL_010e:  ldc.i4.7
      IL_010f:  ldloc.1
      IL_0110:  sub
      IL_0111:  sub
      IL_0112:  newobj     instance void Microsoft.Samples.SpaceInvaders.ItemPosition::.ctor(int32,
                                                                                             int32)
      IL_0117:  newobj     instance void Microsoft.Samples.SpaceInvaders.Shield::.ctor(class Microsoft.Samples.SpaceInvaders.ItemPosition)
      IL_011c:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::Add(!0)
      IL_0121:  nop
      IL_0122:  ldarg.0
      IL_0123:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
      IL_0128:  ldloc.0
      IL_0129:  ldc.i4.s   14
      IL_012b:  mul
      IL_012c:  ldc.i4.s   9
      IL_012e:  add
      IL_012f:  call       int32 [mscorlib]System.Console::get_WindowHeight()
      IL_0134:  ldc.i4.7
      IL_0135:  ldloc.1
      IL_0136:  sub
      IL_0137:  sub
      IL_0138:  newobj     instance void Microsoft.Samples.SpaceInvaders.ItemPosition::.ctor(int32,
                                                                                             int32)
      IL_013d:  newobj     instance void Microsoft.Samples.SpaceInvaders.Shield::.ctor(class Microsoft.Samples.SpaceInvaders.ItemPosition)
      IL_0142:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::Add(!0)
      IL_0147:  nop
      IL_0148:  ldarg.0
      IL_0149:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
      IL_014e:  ldloc.0
      IL_014f:  ldc.i4.s   14
      IL_0151:  mul
      IL_0152:  ldc.i4.s   10
      IL_0154:  add
      IL_0155:  call       int32 [mscorlib]System.Console::get_WindowHeight()
      IL_015a:  ldc.i4.7
      IL_015b:  ldloc.1
      IL_015c:  sub
      IL_015d:  sub
      IL_015e:  newobj     instance void Microsoft.Samples.SpaceInvaders.ItemPosition::.ctor(int32,
                                                                                             int32)
      IL_0163:  newobj     instance void Microsoft.Samples.SpaceInvaders.Shield::.ctor(class Microsoft.Samples.SpaceInvaders.ItemPosition)
      IL_0168:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::Add(!0)
      IL_016d:  nop
      IL_016e:  nop
      IL_016f:  ldloc.1
      IL_0170:  ldc.i4.1
      IL_0171:  add
      IL_0172:  stloc.1
      IL_0173:  ldloc.1
      IL_0174:  ldc.i4.1
      IL_0175:  cgt
      IL_0177:  ldc.i4.0
      IL_0178:  ceq
      IL_017a:  stloc.3
      IL_017b:  ldloc.3
      IL_017c:  brtrue     IL_00d8

      IL_0181:  nop
      IL_0182:  ldloc.0
      IL_0183:  ldc.i4.1
      IL_0184:  add
      IL_0185:  stloc.0
      IL_0186:  ldloc.0
      IL_0187:  ldc.i4.5
      IL_0188:  clt
      IL_018a:  stloc.3
      IL_018b:  ldloc.3
      IL_018c:  brtrue     IL_0021

      IL_0191:  nop
      IL_0192:  leave.s    IL_019c

    }  // end .try
    finally
    {
      IL_0194:  ldloc.2
      IL_0195:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_019a:  nop
      IL_019b:  endfinally
    }  // end handler
    IL_019c:  nop
    IL_019d:  ret
  } // end of method Invaders::DrawShields

  .method private hidebysig instance void 
          ResolveShieldCollisions() cil managed
  {
    // Code size       521 (0x209)
    .maxstack  6
    .locals init ([0] int32 i,
             [1] bool destroyed,
             [2] class Microsoft.Samples.SpaceInvaders.ItemPosition ip,
             [3] valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition> CS$5$0000,
             [4] bool CS$4$0001,
             [5] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0002)
    IL_0000:  ldc.i4.0
    IL_0001:  stloc.0
    IL_0002:  br         IL_01f1

    IL_0007:  ldc.i4.0
    IL_0008:  stloc.1
    IL_0009:  ldarg.0
    IL_000a:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
    IL_000f:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<!0> class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::GetEnumerator()
    IL_0014:  stloc.3
    .try
    {
      IL_0015:  br         IL_00da

      IL_001a:  ldloca.s   CS$5$0000
      IL_001c:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Current()
      IL_0021:  stloc.2
      IL_0022:  ldloc.2
      IL_0023:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_0028:  ldarg.0
      IL_0029:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
      IL_002e:  ldloc.0
      IL_002f:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::get_Item(int32)
      IL_0034:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Shield::get_Position()
      IL_0039:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_003e:  bne.un.s   IL_0063

      IL_0040:  ldloc.2
      IL_0041:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_0046:  ldarg.0
      IL_0047:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
      IL_004c:  ldloc.0
      IL_004d:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::get_Item(int32)
      IL_0052:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Shield::get_Position()
      IL_0057:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_005c:  ceq
      IL_005e:  ldc.i4.0
      IL_005f:  ceq
      IL_0061:  br.s       IL_0064

      IL_0063:  ldc.i4.1
      IL_0064:  stloc.s    CS$4$0001
      IL_0066:  ldloc.s    CS$4$0001
      IL_0068:  brtrue.s   IL_00d9

      IL_006a:  ldarg.0
      IL_006b:  dup
      IL_006c:  stloc.s    CS$2$0002
      IL_006e:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
      IL_0073:  nop
      .try
      {
        IL_0074:  ldc.i4.0
        IL_0075:  ldc.i4.0
        IL_0076:  ldc.i4.1
        IL_0077:  ldc.i4.1
        IL_0078:  ldloc.2
        IL_0079:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
        IL_007e:  ldloc.2
        IL_007f:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
        IL_0084:  call       void [mscorlib]System.Console::MoveBufferArea(int32,
                                                                           int32,
                                                                           int32,
                                                                           int32,
                                                                           int32,
                                                                           int32)
        IL_0089:  nop
        IL_008a:  ldarg.0
        IL_008b:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
        IL_0090:  ldloc.0
        IL_0091:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::RemoveAt(int32)
        IL_0096:  nop
        IL_0097:  ldloc.0
        IL_0098:  ldc.i4.1
        IL_0099:  sub
        IL_009a:  stloc.0
        IL_009b:  ldc.i4.1
        IL_009c:  stloc.1
        IL_009d:  nop
        IL_009e:  leave.s    IL_00a9

      }  // end .try
      finally
      {
        IL_00a0:  ldloc.s    CS$2$0002
        IL_00a2:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
        IL_00a7:  nop
        IL_00a8:  endfinally
      }  // end handler
      IL_00a9:  nop
      IL_00aa:  ldarg.0
      IL_00ab:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
      IL_00b0:  stloc.s    CS$4$0001
      IL_00b2:  ldloc.s    CS$4$0001
      IL_00b4:  brtrue.s   IL_00ca

      IL_00b6:  ldarg.0
      IL_00b7:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
      IL_00bc:  ldc.i4.8
      IL_00bd:  ldc.i4.5
      IL_00be:  ldstr      "Invader bullet hit shield"
      IL_00c3:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                            int32,
                                                                                            string)
      IL_00c8:  nop
      IL_00c9:  nop
      IL_00ca:  ldarg.0
      IL_00cb:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
      IL_00d0:  ldloc.2
      IL_00d1:  callvirt   instance bool class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::Remove(!0)
      IL_00d6:  pop
      IL_00d7:  br.s       IL_00ea

      IL_00d9:  nop
      IL_00da:  ldloca.s   CS$5$0000
      IL_00dc:  call       instance bool valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition>::MoveNext()
      IL_00e1:  stloc.s    CS$4$0001
      IL_00e3:  ldloc.s    CS$4$0001
      IL_00e5:  brtrue     IL_001a

      IL_00ea:  leave.s    IL_00f5

    }  // end .try
    finally
    {
      IL_00ec:  ldloca.s   CS$5$0000
      IL_00ee:  call       instance void valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition>::Dispose()
      IL_00f3:  nop
      IL_00f4:  endfinally
    }  // end handler
    IL_00f5:  nop
    IL_00f6:  ldloc.1
    IL_00f7:  stloc.s    CS$4$0001
    IL_00f9:  ldloc.s    CS$4$0001
    IL_00fb:  brtrue     IL_01ec

    IL_0100:  ldarg.0
    IL_0101:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
    IL_0106:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<!0> class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::GetEnumerator()
    IL_010b:  stloc.3
    .try
    {
      IL_010c:  br         IL_01cf

      IL_0111:  ldloca.s   CS$5$0000
      IL_0113:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Current()
      IL_0118:  stloc.2
      IL_0119:  ldloc.2
      IL_011a:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_011f:  ldarg.0
      IL_0120:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
      IL_0125:  ldloc.0
      IL_0126:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::get_Item(int32)
      IL_012b:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Shield::get_Position()
      IL_0130:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_0135:  bne.un.s   IL_015a

      IL_0137:  ldloc.2
      IL_0138:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_013d:  ldarg.0
      IL_013e:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
      IL_0143:  ldloc.0
      IL_0144:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::get_Item(int32)
      IL_0149:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Shield::get_Position()
      IL_014e:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_0153:  ceq
      IL_0155:  ldc.i4.0
      IL_0156:  ceq
      IL_0158:  br.s       IL_015b

      IL_015a:  ldc.i4.1
      IL_015b:  stloc.s    CS$4$0001
      IL_015d:  ldloc.s    CS$4$0001
      IL_015f:  brtrue.s   IL_01ce

      IL_0161:  ldarg.0
      IL_0162:  dup
      IL_0163:  stloc.s    CS$2$0002
      IL_0165:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
      IL_016a:  nop
      .try
      {
        IL_016b:  ldc.i4.0
        IL_016c:  ldc.i4.0
        IL_016d:  ldc.i4.1
        IL_016e:  ldc.i4.1
        IL_016f:  ldloc.2
        IL_0170:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
        IL_0175:  ldloc.2
        IL_0176:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
        IL_017b:  call       void [mscorlib]System.Console::MoveBufferArea(int32,
                                                                           int32,
                                                                           int32,
                                                                           int32,
                                                                           int32,
                                                                           int32)
        IL_0180:  nop
        IL_0181:  ldarg.0
        IL_0182:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
        IL_0187:  ldloc.0
        IL_0188:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::RemoveAt(int32)
        IL_018d:  nop
        IL_018e:  ldloc.0
        IL_018f:  ldc.i4.1
        IL_0190:  sub
        IL_0191:  stloc.0
        IL_0192:  nop
        IL_0193:  leave.s    IL_019e

      }  // end .try
      finally
      {
        IL_0195:  ldloc.s    CS$2$0002
        IL_0197:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
        IL_019c:  nop
        IL_019d:  endfinally
      }  // end handler
      IL_019e:  nop
      IL_019f:  ldarg.0
      IL_01a0:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
      IL_01a5:  stloc.s    CS$4$0001
      IL_01a7:  ldloc.s    CS$4$0001
      IL_01a9:  brtrue.s   IL_01bf

      IL_01ab:  ldarg.0
      IL_01ac:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
      IL_01b1:  ldc.i4.8
      IL_01b2:  ldc.i4.2
      IL_01b3:  ldstr      "Interesting, shooting own shield\?"
      IL_01b8:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                            int32,
                                                                                            string)
      IL_01bd:  nop
      IL_01be:  nop
      IL_01bf:  ldarg.0
      IL_01c0:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_01c5:  ldloc.2
      IL_01c6:  callvirt   instance bool class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::Remove(!0)
      IL_01cb:  pop
      IL_01cc:  br.s       IL_01df

      IL_01ce:  nop
      IL_01cf:  ldloca.s   CS$5$0000
      IL_01d1:  call       instance bool valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition>::MoveNext()
      IL_01d6:  stloc.s    CS$4$0001
      IL_01d8:  ldloc.s    CS$4$0001
      IL_01da:  brtrue     IL_0111

      IL_01df:  leave.s    IL_01ea

    }  // end .try
    finally
    {
      IL_01e1:  ldloca.s   CS$5$0000
      IL_01e3:  call       instance void valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition>::Dispose()
      IL_01e8:  nop
      IL_01e9:  endfinally
    }  // end handler
    IL_01ea:  nop
    IL_01eb:  nop
    IL_01ec:  nop
    IL_01ed:  ldloc.0
    IL_01ee:  ldc.i4.1
    IL_01ef:  add
    IL_01f0:  stloc.0
    IL_01f1:  ldloc.0
    IL_01f2:  ldarg.0
    IL_01f3:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
    IL_01f8:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::get_Count()
    IL_01fd:  clt
    IL_01ff:  stloc.s    CS$4$0001
    IL_0201:  ldloc.s    CS$4$0001
    IL_0203:  brtrue     IL_0007

    IL_0208:  ret
  } // end of method Invaders::ResolveShieldCollisions

  .method private hidebysig instance void 
          InitializeInvaders(int32 topRow) cil managed
  {
    // Code size       287 (0x11f)
    .maxstack  4
    .locals init ([0] int32 initCursorLeft,
             [1] int32 initCursorTop,
             [2] int32 invaderCount,
             [3] int32 j,
             [4] valuetype [mscorlib]System.ConsoleColor foreColor,
             [5] int32 i,
             [6] int32 k,
             [7] int32 l,
             [8] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0000,
             [9] bool CS$4$0001)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
    IL_0006:  ldc.i4.0
    IL_0007:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_000c:  ldarg.0
    IL_000d:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
    IL_0012:  ldc.r8     850.
    IL_001b:  callvirt   instance void [System]System.Timers.Timer::set_Interval(float64)
    IL_0020:  ldarg.0
    IL_0021:  newobj     instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::.ctor()
    IL_0026:  stfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_002b:  ldarg.0
    IL_002c:  ldc.i4.0
    IL_002d:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::invadersMoveRight
    IL_0032:  call       int32 [mscorlib]System.Console::get_CursorLeft()
    IL_0037:  stloc.0
    IL_0038:  call       int32 [mscorlib]System.Console::get_CursorTop()
    IL_003d:  stloc.1
    IL_003e:  ldc.i4.0
    IL_003f:  stloc.2
    IL_0040:  ldarg.0
    IL_0041:  dup
    IL_0042:  stloc.s    CS$2$0000
    IL_0044:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0049:  nop
    .try
    {
      IL_004a:  ldc.i4.0
      IL_004b:  call       void [mscorlib]System.Console::set_BackgroundColor(valuetype [mscorlib]System.ConsoleColor)
      IL_0050:  ldarg.1
      IL_0051:  stloc.3
      IL_0052:  br         IL_00e8

      IL_0057:  ldarg.0
      IL_0058:  ldloc.3
      IL_0059:  ldc.i4.1
      IL_005a:  add
      IL_005b:  call       instance valuetype [mscorlib]System.ConsoleColor Microsoft.Samples.SpaceInvaders.Invaders::GetNextColor(int32)
      IL_0060:  stloc.s    foreColor
      IL_0062:  ldc.i4.0
      IL_0063:  stloc.s    i
      IL_0065:  br.s       IL_00d8

      IL_0067:  ldloc.s    i
      IL_0069:  ldc.i4.7
      IL_006a:  mul
      IL_006b:  ldc.i4.5
      IL_006c:  add
      IL_006d:  stloc.s    k
      IL_006f:  ldloc.3
      IL_0070:  ldc.i4.3
      IL_0071:  mul
      IL_0072:  ldc.i4.2
      IL_0073:  add
      IL_0074:  ldc.i4.3
      IL_0075:  add
      IL_0076:  stloc.s    l
      IL_0078:  ldloc.s    k
      IL_007a:  ldloc.s    l
      IL_007c:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_0081:  nop
      IL_0082:  ldloc.2
      IL_0083:  ldc.i4.1
      IL_0084:  add
      IL_0085:  stloc.2
      IL_0086:  ldarg.0
      IL_0087:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
      IL_008c:  ldloc.s    k
      IL_008e:  ldloc.s    l
      IL_0090:  newobj     instance void Microsoft.Samples.SpaceInvaders.ItemPosition::.ctor(int32,
                                                                                             int32)
      IL_0095:  ldloc.2
      IL_0096:  newobj     instance void Microsoft.Samples.SpaceInvaders.Invader::.ctor(class Microsoft.Samples.SpaceInvaders.ItemPosition,
                                                                                        int32)
      IL_009b:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::Add(!0)
      IL_00a0:  nop
      IL_00a1:  ldloc.s    foreColor
      IL_00a3:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
      IL_00a8:  ldstr      "{0}{1}{2}"
      IL_00ad:  ldc.i4     0x2559
      IL_00b2:  box        [mscorlib]System.Char
      IL_00b7:  ldc.i4     0x2565
      IL_00bc:  box        [mscorlib]System.Char
      IL_00c1:  ldc.i4     0x255c
      IL_00c6:  box        [mscorlib]System.Char
      IL_00cb:  call       void [mscorlib]System.Console::Write(string,
                                                                object,
                                                                object,
                                                                object)
      IL_00d0:  nop
      IL_00d1:  nop
      IL_00d2:  ldloc.s    i
      IL_00d4:  ldc.i4.1
      IL_00d5:  add
      IL_00d6:  stloc.s    i
      IL_00d8:  ldloc.s    i
      IL_00da:  ldc.i4.8
      IL_00db:  clt
      IL_00dd:  stloc.s    CS$4$0001
      IL_00df:  ldloc.s    CS$4$0001
      IL_00e1:  brtrue.s   IL_0067

      IL_00e3:  nop
      IL_00e4:  ldloc.3
      IL_00e5:  ldc.i4.1
      IL_00e6:  add
      IL_00e7:  stloc.3
      IL_00e8:  ldloc.3
      IL_00e9:  ldc.i4.5
      IL_00ea:  ldarg.1
      IL_00eb:  add
      IL_00ec:  clt
      IL_00ee:  stloc.s    CS$4$0001
      IL_00f0:  ldloc.s    CS$4$0001
      IL_00f2:  brtrue     IL_0057

      IL_00f7:  ldc.i4.0
      IL_00f8:  call       void [mscorlib]System.Console::set_BackgroundColor(valuetype [mscorlib]System.ConsoleColor)
      IL_00fd:  ldloc.0
      IL_00fe:  ldloc.1
      IL_00ff:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_0104:  nop
      IL_0105:  nop
      IL_0106:  leave.s    IL_0111

    }  // end .try
    finally
    {
      IL_0108:  ldloc.s    CS$2$0000
      IL_010a:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_010f:  nop
      IL_0110:  endfinally
    }  // end handler
    IL_0111:  nop
    IL_0112:  ldarg.0
    IL_0113:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
    IL_0118:  ldc.i4.1
    IL_0119:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_011e:  ret
  } // end of method Invaders::InitializeInvaders

  .method private hidebysig instance void 
          DrawInvader(int32 left,
                      int32 top,
                      valuetype [mscorlib]System.ConsoleColor foreColor) cil managed
  {
    // Code size       77 (0x4d)
    .maxstack  4
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0000)
    IL_0000:  ldarg.0
    IL_0001:  dup
    IL_0002:  stloc.0
    IL_0003:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0008:  nop
    .try
    {
      IL_0009:  ldarg.1
      IL_000a:  ldarg.2
      IL_000b:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_0010:  nop
      IL_0011:  ldarg.3
      IL_0012:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
      IL_0017:  ldstr      "{0}{1}{2}"
      IL_001c:  ldc.i4     0x2559
      IL_0021:  box        [mscorlib]System.Char
      IL_0026:  ldc.i4     0x2565
      IL_002b:  box        [mscorlib]System.Char
      IL_0030:  ldc.i4     0x255c
      IL_0035:  box        [mscorlib]System.Char
      IL_003a:  call       void [mscorlib]System.Console::Write(string,
                                                                object,
                                                                object,
                                                                object)
      IL_003f:  nop
      IL_0040:  nop
      IL_0041:  leave.s    IL_004b

    }  // end .try
    finally
    {
      IL_0043:  ldloc.0
      IL_0044:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0049:  nop
      IL_004a:  endfinally
    }  // end handler
    IL_004b:  nop
    IL_004c:  ret
  } // end of method Invaders::DrawInvader

  .method private hidebysig instance void 
          GenerateInvaderBullet() cil managed
  {
    // Code size       178 (0xb2)
    .maxstack  4
    .locals init ([0] class [mscorlib]System.Random r,
             [1] int32 next,
             [2] class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> InvadersCanFire,
             [3] class Microsoft.Samples.SpaceInvaders.Invader ipInvader,
             [4] int32 nextInvader,
             [5] class Microsoft.Samples.SpaceInvaders.Invader invader,
             [6] valuetype [mscorlib]System.DateTime CS$0$0000,
             [7] bool CS$4$0001,
             [8] valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader> CS$5$0002)
    IL_0000:  call       valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
    IL_0005:  stloc.s    CS$0$0000
    IL_0007:  ldloca.s   CS$0$0000
    IL_0009:  call       instance int32 [mscorlib]System.DateTime::get_Millisecond()
    IL_000e:  newobj     instance void [mscorlib]System.Random::.ctor(int32)
    IL_0013:  stloc.0
    IL_0014:  ldloc.0
    IL_0015:  ldc.i4     0x3e8
    IL_001a:  callvirt   instance int32 [mscorlib]System.Random::Next(int32)
    IL_001f:  stloc.1
    IL_0020:  ldloc.1
    IL_0021:  ldc.i4     0x3e8
    IL_0026:  ldc.i4.s   40
    IL_0028:  ldarg.0
    IL_0029:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::iterationCount
    IL_002e:  mul
    IL_002f:  sub
    IL_0030:  cgt
    IL_0032:  ldc.i4.0
    IL_0033:  ceq
    IL_0035:  stloc.s    CS$4$0001
    IL_0037:  ldloc.s    CS$4$0001
    IL_0039:  brtrue.s   IL_00b1

    IL_003b:  newobj     instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::.ctor()
    IL_0040:  stloc.2
    IL_0041:  ldarg.0
    IL_0042:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_0047:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<!0> class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::GetEnumerator()
    IL_004c:  stloc.s    CS$5$0002
    .try
    {
      IL_004e:  br.s       IL_0076

      IL_0050:  ldloca.s   CS$5$0002
      IL_0052:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::get_Current()
      IL_0057:  stloc.3
      IL_0058:  ldloc.3
      IL_0059:  ldarg.0
      IL_005a:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
      IL_005f:  callvirt   instance bool Microsoft.Samples.SpaceInvaders.Invader::CanFire(class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>)
      IL_0064:  ldc.i4.0
      IL_0065:  ceq
      IL_0067:  stloc.s    CS$4$0001
      IL_0069:  ldloc.s    CS$4$0001
      IL_006b:  brtrue.s   IL_0075

      IL_006d:  ldloc.2
      IL_006e:  ldloc.3
      IL_006f:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::Add(!0)
      IL_0074:  nop
      IL_0075:  nop
      IL_0076:  ldloca.s   CS$5$0002
      IL_0078:  call       instance bool valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::MoveNext()
      IL_007d:  stloc.s    CS$4$0001
      IL_007f:  ldloc.s    CS$4$0001
      IL_0081:  brtrue.s   IL_0050

      IL_0083:  leave.s    IL_008e

    }  // end .try
    finally
    {
      IL_0085:  ldloca.s   CS$5$0002
      IL_0087:  call       instance void valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::Dispose()
      IL_008c:  nop
      IL_008d:  endfinally
    }  // end handler
    IL_008e:  nop
    IL_008f:  ldloc.0
    IL_0090:  ldloc.2
    IL_0091:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Count()
    IL_0096:  callvirt   instance int32 [mscorlib]System.Random::Next(int32)
    IL_009b:  stloc.s    nextInvader
    IL_009d:  ldloc.2
    IL_009e:  ldloc.s    nextInvader
    IL_00a0:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Item(int32)
    IL_00a5:  stloc.s    invader
    IL_00a7:  ldarg.0
    IL_00a8:  ldloc.s    invader
    IL_00aa:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ShootInvaderBullet(class Microsoft.Samples.SpaceInvaders.Invader)
    IL_00af:  nop
    IL_00b0:  nop
    IL_00b1:  ret
  } // end of method Invaders::GenerateInvaderBullet

  .method private hidebysig instance void 
          ShootInvaderBullet(class Microsoft.Samples.SpaceInvaders.Invader invader) cil managed
  {
    // Code size       162 (0xa2)
    .maxstack  5
    .locals init ([0] bool CS$4$0000,
             [1] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0001)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
    IL_000c:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
    IL_0011:  ldc.i4.1
    IL_0012:  add
    IL_0013:  ldarg.1
    IL_0014:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
    IL_0019:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
    IL_001e:  ldc.i4.1
    IL_001f:  add
    IL_0020:  newobj     instance void Microsoft.Samples.SpaceInvaders.ItemPosition::.ctor(int32,
                                                                                           int32)
    IL_0025:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::Add(!0)
    IL_002a:  nop
    IL_002b:  ldarg.0
    IL_002c:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
    IL_0031:  stloc.0
    IL_0032:  ldloc.0
    IL_0033:  brtrue.s   IL_005a

    IL_0035:  ldarg.0
    IL_0036:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_003b:  ldc.i4.8
    IL_003c:  ldc.i4.s   12
    IL_003e:  ldarg.1
    IL_003f:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.Invader::get_Identification()
    IL_0044:  box        [mscorlib]System.Int32
    IL_0049:  ldstr      " Invader fired, will it hit\?\? (aaargh!)"
    IL_004e:  call       string [mscorlib]System.String::Concat(object,
                                                                object)
    IL_0053:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                          int32,
                                                                                          string)
    IL_0058:  nop
    IL_0059:  nop
    IL_005a:  ldarg.0
    IL_005b:  dup
    IL_005c:  stloc.1
    IL_005d:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0062:  nop
    .try
    {
      IL_0063:  ldarg.1
      IL_0064:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_0069:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_006e:  ldc.i4.1
      IL_006f:  add
      IL_0070:  ldarg.1
      IL_0071:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_0076:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_007b:  ldc.i4.1
      IL_007c:  add
      IL_007d:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_0082:  nop
      IL_0083:  ldc.i4.s   15
      IL_0085:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
      IL_008a:  ldc.i4     0x2551
      IL_008f:  call       void [mscorlib]System.Console::Write(char)
      IL_0094:  nop
      IL_0095:  nop
      IL_0096:  leave.s    IL_00a0

    }  // end .try
    finally
    {
      IL_0098:  ldloc.1
      IL_0099:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_009e:  nop
      IL_009f:  endfinally
    }  // end handler
    IL_00a0:  nop
    IL_00a1:  ret
  } // end of method Invaders::ShootInvaderBullet

  .method private hidebysig instance valuetype [mscorlib]System.ConsoleColor 
          GetNextColor(int32 j) cil managed
  {
    // Code size       122 (0x7a)
    .maxstack  1
    .locals init ([0] valuetype [mscorlib]System.ConsoleColor CS$1$0000,
             [1] int32 CS$4$0001,
             [2] int32 CS$0$0002)
    IL_0000:  ldarg.1
    IL_0001:  stloc.1
    IL_0002:  ldloc.1
    IL_0003:  stloc.2
    IL_0004:  ldloc.2
    IL_0005:  switch     ( 
                          IL_003c,
                          IL_0041,
                          IL_0046,
                          IL_004a,
                          IL_004f,
                          IL_0054,
                          IL_0059,
                          IL_005d,
                          IL_0061,
                          IL_0066,
                          IL_006b,
                          IL_0070)
    IL_003a:  br.s       IL_0074

    IL_003c:  ldc.i4.s   12
    IL_003e:  stloc.0
    IL_003f:  br.s       IL_0078

    IL_0041:  ldc.i4.s   15
    IL_0043:  stloc.0
    IL_0044:  br.s       IL_0078

    IL_0046:  ldc.i4.7
    IL_0047:  stloc.0
    IL_0048:  br.s       IL_0078

    IL_004a:  ldc.i4.s   14
    IL_004c:  stloc.0
    IL_004d:  br.s       IL_0078

    IL_004f:  ldc.i4.s   10
    IL_0051:  stloc.0
    IL_0052:  br.s       IL_0078

    IL_0054:  ldc.i4.s   11
    IL_0056:  stloc.0
    IL_0057:  br.s       IL_0078

    IL_0059:  ldc.i4.6
    IL_005a:  stloc.0
    IL_005b:  br.s       IL_0078

    IL_005d:  ldc.i4.2
    IL_005e:  stloc.0
    IL_005f:  br.s       IL_0078

    IL_0061:  ldc.i4.s   9
    IL_0063:  stloc.0
    IL_0064:  br.s       IL_0078

    IL_0066:  ldc.i4.s   13
    IL_0068:  stloc.0
    IL_0069:  br.s       IL_0078

    IL_006b:  ldc.i4.s   12
    IL_006d:  stloc.0
    IL_006e:  br.s       IL_0078

    IL_0070:  ldc.i4.4
    IL_0071:  stloc.0
    IL_0072:  br.s       IL_0078

    IL_0074:  ldc.i4.4
    IL_0075:  stloc.0
    IL_0076:  br.s       IL_0078

    IL_0078:  ldloc.0
    IL_0079:  ret
  } // end of method Invaders::GetNextColor

  .method private hidebysig instance void 
          DrawInvaderAt(class Microsoft.Samples.SpaceInvaders.Invader ip,
                        int32& invaderMaxLeft,
                        int32& invaderMinLeft) cil managed
  {
    // Code size       295 (0x127)
    .maxstack  6
    .locals init ([0] bool CS$4$0000,
             [1] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0001)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::invadersMoveRight
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  brtrue.s   IL_0076

    IL_000a:  ldarg.0
    IL_000b:  dup
    IL_000c:  stloc.1
    IL_000d:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0012:  nop
    .try
    {
      IL_0013:  ldc.i4.0
      IL_0014:  ldc.i4.0
      IL_0015:  ldc.i4.3
      IL_0016:  ldc.i4.1
      IL_0017:  ldarg.1
      IL_0018:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_001d:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_0022:  ldarg.1
      IL_0023:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_0028:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_002d:  call       void [mscorlib]System.Console::MoveBufferArea(int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32)
      IL_0032:  nop
      IL_0033:  ldarg.0
      IL_0034:  ldarg.1
      IL_0035:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_003a:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_003f:  ldc.i4.1
      IL_0040:  add
      IL_0041:  ldarg.1
      IL_0042:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_0047:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_004c:  ldarg.0
      IL_004d:  ldarg.1
      IL_004e:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_0053:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_0058:  ldc.i4.2
      IL_0059:  sub
      IL_005a:  ldc.i4.3
      IL_005b:  div
      IL_005c:  call       instance valuetype [mscorlib]System.ConsoleColor Microsoft.Samples.SpaceInvaders.Invaders::GetNextColor(int32)
      IL_0061:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawInvader(int32,
                                                                                               int32,
                                                                                               valuetype [mscorlib]System.ConsoleColor)
      IL_0066:  nop
      IL_0067:  nop
      IL_0068:  leave.s    IL_0072

    }  // end .try
    finally
    {
      IL_006a:  ldloc.1
      IL_006b:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0070:  nop
      IL_0071:  endfinally
    }  // end handler
    IL_0072:  nop
    IL_0073:  nop
    IL_0074:  br.s       IL_00e0

    IL_0076:  ldarg.0
    IL_0077:  dup
    IL_0078:  stloc.1
    IL_0079:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_007e:  nop
    .try
    {
      IL_007f:  ldc.i4.0
      IL_0080:  ldc.i4.0
      IL_0081:  ldc.i4.3
      IL_0082:  ldc.i4.1
      IL_0083:  ldarg.1
      IL_0084:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_0089:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_008e:  ldarg.1
      IL_008f:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_0094:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_0099:  call       void [mscorlib]System.Console::MoveBufferArea(int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32)
      IL_009e:  nop
      IL_009f:  ldarg.0
      IL_00a0:  ldarg.1
      IL_00a1:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_00a6:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_00ab:  ldc.i4.1
      IL_00ac:  sub
      IL_00ad:  ldarg.1
      IL_00ae:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_00b3:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_00b8:  ldarg.0
      IL_00b9:  ldarg.1
      IL_00ba:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_00bf:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_00c4:  ldc.i4.2
      IL_00c5:  sub
      IL_00c6:  ldc.i4.3
      IL_00c7:  div
      IL_00c8:  call       instance valuetype [mscorlib]System.ConsoleColor Microsoft.Samples.SpaceInvaders.Invaders::GetNextColor(int32)
      IL_00cd:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawInvader(int32,
                                                                                               int32,
                                                                                               valuetype [mscorlib]System.ConsoleColor)
      IL_00d2:  nop
      IL_00d3:  nop
      IL_00d4:  leave.s    IL_00de

    }  // end .try
    finally
    {
      IL_00d6:  ldloc.1
      IL_00d7:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00dc:  nop
      IL_00dd:  endfinally
    }  // end handler
    IL_00de:  nop
    IL_00df:  nop
    IL_00e0:  ldarg.2
    IL_00e1:  ldind.i4
    IL_00e2:  ldarg.1
    IL_00e3:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
    IL_00e8:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
    IL_00ed:  clt
    IL_00ef:  ldc.i4.0
    IL_00f0:  ceq
    IL_00f2:  stloc.0
    IL_00f3:  ldloc.0
    IL_00f4:  brtrue.s   IL_0103

    IL_00f6:  ldarg.2
    IL_00f7:  ldarg.1
    IL_00f8:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
    IL_00fd:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
    IL_0102:  stind.i4
    IL_0103:  ldarg.3
    IL_0104:  ldind.i4
    IL_0105:  ldarg.1
    IL_0106:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
    IL_010b:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
    IL_0110:  cgt
    IL_0112:  ldc.i4.0
    IL_0113:  ceq
    IL_0115:  stloc.0
    IL_0116:  ldloc.0
    IL_0117:  brtrue.s   IL_0126

    IL_0119:  ldarg.3
    IL_011a:  ldarg.1
    IL_011b:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
    IL_0120:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
    IL_0125:  stind.i4
    IL_0126:  ret
  } // end of method Invaders::DrawInvaderAt

  .method private hidebysig instance void 
          MoveInvadersDown() cil managed
  {
    // Code size       403 (0x193)
    .maxstack  6
    .locals init ([0] int32 temp,
             [1] int32 maxTop,
             [2] int32 i,
             [3] class Microsoft.Samples.SpaceInvaders.ItemPosition ip,
             [4] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0000,
             [5] bool CS$4$0001)
    IL_0000:  ldarg.0
    IL_0001:  dup
    IL_0002:  stloc.s    CS$2$0000
    IL_0004:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0009:  nop
    .try
    {
      IL_000a:  ldarg.0
      IL_000b:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
      IL_0010:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::get_Count()
      IL_0015:  ldc.i4.1
      IL_0016:  sub
      IL_0017:  stloc.0
      IL_0018:  ldarg.0
      IL_0019:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
      IL_001e:  ldarg.0
      IL_001f:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
      IL_0024:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Count()
      IL_0029:  ldc.i4.1
      IL_002a:  sub
      IL_002b:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Item(int32)
      IL_0030:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_0035:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_003a:  ldc.i4.3
      IL_003b:  add
      IL_003c:  stloc.1
      IL_003d:  ldloc.0
      IL_003e:  stloc.2
      IL_003f:  br.s       IL_00b0

      IL_0041:  ldloc.1
      IL_0042:  ldarg.0
      IL_0043:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
      IL_0048:  ldloc.2
      IL_0049:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::get_Item(int32)
      IL_004e:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Shield::get_Position()
      IL_0053:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_0058:  clt
      IL_005a:  stloc.s    CS$4$0001
      IL_005c:  ldloc.s    CS$4$0001
      IL_005e:  brtrue.s   IL_00ab

      IL_0060:  ldarg.0
      IL_0061:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
      IL_0066:  ldloc.2
      IL_0067:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::get_Item(int32)
      IL_006c:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Shield::get_Position()
      IL_0071:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_0076:  ldarg.0
      IL_0077:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
      IL_007c:  ldloc.2
      IL_007d:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::get_Item(int32)
      IL_0082:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Shield::get_Position()
      IL_0087:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_008c:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_0091:  nop
      IL_0092:  ldstr      " "
      IL_0097:  call       void [mscorlib]System.Console::Write(string)
      IL_009c:  nop
      IL_009d:  ldarg.0
      IL_009e:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield> Microsoft.Samples.SpaceInvaders.Invaders::liShieldPositions
      IL_00a3:  ldloc.2
      IL_00a4:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Shield>::RemoveAt(int32)
      IL_00a9:  nop
      IL_00aa:  nop
      IL_00ab:  nop
      IL_00ac:  ldloc.2
      IL_00ad:  ldc.i4.1
      IL_00ae:  sub
      IL_00af:  stloc.2
      IL_00b0:  ldloc.2
      IL_00b1:  ldc.i4.0
      IL_00b2:  clt
      IL_00b4:  ldc.i4.0
      IL_00b5:  ceq
      IL_00b7:  stloc.s    CS$4$0001
      IL_00b9:  ldloc.s    CS$4$0001
      IL_00bb:  brtrue.s   IL_0041

      IL_00bd:  ldarg.0
      IL_00be:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
      IL_00c3:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Count()
      IL_00c8:  ldc.i4.1
      IL_00c9:  sub
      IL_00ca:  stloc.2
      IL_00cb:  br.s       IL_012b

      IL_00cd:  ldarg.0
      IL_00ce:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
      IL_00d3:  ldloc.2
      IL_00d4:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Item(int32)
      IL_00d9:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_00de:  stloc.3
      IL_00df:  ldc.i4.0
      IL_00e0:  ldc.i4.0
      IL_00e1:  ldc.i4.3
      IL_00e2:  ldc.i4.1
      IL_00e3:  ldloc.3
      IL_00e4:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_00e9:  ldloc.3
      IL_00ea:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_00ef:  call       void [mscorlib]System.Console::MoveBufferArea(int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32)
      IL_00f4:  nop
      IL_00f5:  ldloc.3
      IL_00f6:  ldloc.3
      IL_00f7:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_00fc:  ldc.i4.3
      IL_00fd:  add
      IL_00fe:  callvirt   instance void Microsoft.Samples.SpaceInvaders.ItemPosition::set_Top(int32)
      IL_0103:  ldarg.0
      IL_0104:  ldloc.3
      IL_0105:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_010a:  ldloc.3
      IL_010b:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_0110:  ldarg.0
      IL_0111:  ldloc.3
      IL_0112:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_0117:  ldc.i4.2
      IL_0118:  sub
      IL_0119:  ldc.i4.3
      IL_011a:  div
      IL_011b:  call       instance valuetype [mscorlib]System.ConsoleColor Microsoft.Samples.SpaceInvaders.Invaders::GetNextColor(int32)
      IL_0120:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawInvader(int32,
                                                                                               int32,
                                                                                               valuetype [mscorlib]System.ConsoleColor)
      IL_0125:  nop
      IL_0126:  nop
      IL_0127:  ldloc.2
      IL_0128:  ldc.i4.1
      IL_0129:  sub
      IL_012a:  stloc.2
      IL_012b:  ldloc.2
      IL_012c:  ldc.i4.0
      IL_012d:  clt
      IL_012f:  ldc.i4.0
      IL_0130:  ceq
      IL_0132:  stloc.s    CS$4$0001
      IL_0134:  ldloc.s    CS$4$0001
      IL_0136:  brtrue.s   IL_00cd

      IL_0138:  nop
      IL_0139:  leave.s    IL_0144

    }  // end .try
    finally
    {
      IL_013b:  ldloc.s    CS$2$0000
      IL_013d:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0142:  nop
      IL_0143:  endfinally
    }  // end handler
    IL_0144:  nop
    IL_0145:  ldarg.0
    IL_0146:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_014b:  ldarg.0
    IL_014c:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_0151:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Count()
    IL_0156:  ldc.i4.1
    IL_0157:  sub
    IL_0158:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Item(int32)
    IL_015d:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
    IL_0162:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
    IL_0167:  ldarg.0
    IL_0168:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
    IL_016d:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
    IL_0172:  clt
    IL_0174:  stloc.s    CS$4$0001
    IL_0176:  ldloc.s    CS$4$0001
    IL_0178:  brtrue.s   IL_0183

    IL_017a:  ldarg.0
    IL_017b:  ldc.i4.0
    IL_017c:  stfld      valuetype Microsoft.Samples.SpaceInvaders.GameState Microsoft.Samples.SpaceInvaders.Invaders::gameOver
    IL_0181:  br.s       IL_0192

    IL_0183:  ldarg.0
    IL_0184:  ldarg.0
    IL_0185:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::invadersMoveRight
    IL_018a:  ldc.i4.0
    IL_018b:  ceq
    IL_018d:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::invadersMoveRight
    IL_0192:  ret
  } // end of method Invaders::MoveInvadersDown

  .method private hidebysig instance void 
          RedrawInvaders() cil managed
  {
    // Code size       293 (0x125)
    .maxstack  4
    .locals init ([0] int32 initCursorLeft,
             [1] int32 initCursorTop,
             [2] int32 tempInvaderMaxLeft,
             [3] int32 tempInvaderMinLeft,
             [4] class Microsoft.Samples.SpaceInvaders.Invader i,
             [5] class Microsoft.Samples.SpaceInvaders.Invader ip,
             [6] bool CS$4$0000,
             [7] valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader> CS$5$0001)
    IL_0000:  call       int32 [mscorlib]System.Console::get_CursorLeft()
    IL_0005:  stloc.0
    IL_0006:  call       int32 [mscorlib]System.Console::get_CursorTop()
    IL_000b:  stloc.1
    IL_000c:  ldc.i4.0
    IL_000d:  stloc.2
    IL_000e:  call       int32 [mscorlib]System.Console::get_WindowWidth()
    IL_0013:  stloc.3
    IL_0014:  ldarg.0
    IL_0015:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::invadersMoveRight
    IL_001a:  stloc.s    CS$4$0000
    IL_001c:  ldloc.s    CS$4$0000
    IL_001e:  brtrue.s   IL_009f

    IL_0020:  ldarg.0
    IL_0021:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::maxInvaderLeft
    IL_0026:  call       int32 [mscorlib]System.Console::get_WindowWidth()
    IL_002b:  ldc.i4.5
    IL_002c:  sub
    IL_002d:  clt
    IL_002f:  ldc.i4.0
    IL_0030:  ceq
    IL_0032:  stloc.s    CS$4$0000
    IL_0034:  ldloc.s    CS$4$0000
    IL_0036:  brtrue.s   IL_0094

    IL_0038:  ldarg.0
    IL_0039:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_003e:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<!0> class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::GetEnumerator()
    IL_0043:  stloc.s    CS$5$0001
    .try
    {
      IL_0045:  br.s       IL_0078

      IL_0047:  ldloca.s   CS$5$0001
      IL_0049:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::get_Current()
      IL_004e:  stloc.s    i
      IL_0050:  ldarg.0
      IL_0051:  ldloc.s    i
      IL_0053:  ldloca.s   tempInvaderMaxLeft
      IL_0055:  ldloca.s   tempInvaderMinLeft
      IL_0057:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawInvaderAt(class Microsoft.Samples.SpaceInvaders.Invader,
                                                                                                 int32&,
                                                                                                 int32&)
      IL_005c:  nop
      IL_005d:  ldloc.s    i
      IL_005f:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_0064:  ldloc.s    i
      IL_0066:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_006b:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_0070:  ldc.i4.1
      IL_0071:  add
      IL_0072:  callvirt   instance void Microsoft.Samples.SpaceInvaders.ItemPosition::set_Left(int32)
      IL_0077:  nop
      IL_0078:  ldloca.s   CS$5$0001
      IL_007a:  call       instance bool valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::MoveNext()
      IL_007f:  stloc.s    CS$4$0000
      IL_0081:  ldloc.s    CS$4$0000
      IL_0083:  brtrue.s   IL_0047

      IL_0085:  leave.s    IL_0090

    }  // end .try
    finally
    {
      IL_0087:  ldloca.s   CS$5$0001
      IL_0089:  call       instance void valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::Dispose()
      IL_008e:  nop
      IL_008f:  endfinally
    }  // end handler
    IL_0090:  nop
    IL_0091:  nop
    IL_0092:  br.s       IL_009c

    IL_0094:  ldarg.0
    IL_0095:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::MoveInvadersDown()
    IL_009a:  nop
    IL_009b:  nop
    IL_009c:  nop
    IL_009d:  br.s       IL_0116

    IL_009f:  ldarg.0
    IL_00a0:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::minInvaderLeft
    IL_00a5:  ldc.i4.3
    IL_00a6:  cgt
    IL_00a8:  ldc.i4.0
    IL_00a9:  ceq
    IL_00ab:  stloc.s    CS$4$0000
    IL_00ad:  ldloc.s    CS$4$0000
    IL_00af:  brtrue.s   IL_010d

    IL_00b1:  ldarg.0
    IL_00b2:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_00b7:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<!0> class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::GetEnumerator()
    IL_00bc:  stloc.s    CS$5$0001
    .try
    {
      IL_00be:  br.s       IL_00f1

      IL_00c0:  ldloca.s   CS$5$0001
      IL_00c2:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::get_Current()
      IL_00c7:  stloc.s    ip
      IL_00c9:  ldarg.0
      IL_00ca:  ldloc.s    ip
      IL_00cc:  ldloca.s   tempInvaderMaxLeft
      IL_00ce:  ldloca.s   tempInvaderMinLeft
      IL_00d0:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawInvaderAt(class Microsoft.Samples.SpaceInvaders.Invader,
                                                                                                 int32&,
                                                                                                 int32&)
      IL_00d5:  nop
      IL_00d6:  ldloc.s    ip
      IL_00d8:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_00dd:  ldloc.s    ip
      IL_00df:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_00e4:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_00e9:  ldc.i4.1
      IL_00ea:  sub
      IL_00eb:  callvirt   instance void Microsoft.Samples.SpaceInvaders.ItemPosition::set_Left(int32)
      IL_00f0:  nop
      IL_00f1:  ldloca.s   CS$5$0001
      IL_00f3:  call       instance bool valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::MoveNext()
      IL_00f8:  stloc.s    CS$4$0000
      IL_00fa:  ldloc.s    CS$4$0000
      IL_00fc:  brtrue.s   IL_00c0

      IL_00fe:  leave.s    IL_0109

    }  // end .try
    finally
    {
      IL_0100:  ldloca.s   CS$5$0001
      IL_0102:  call       instance void valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::Dispose()
      IL_0107:  nop
      IL_0108:  endfinally
    }  // end handler
    IL_0109:  nop
    IL_010a:  nop
    IL_010b:  br.s       IL_0115

    IL_010d:  ldarg.0
    IL_010e:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::MoveInvadersDown()
    IL_0113:  nop
    IL_0114:  nop
    IL_0115:  nop
    IL_0116:  ldarg.0
    IL_0117:  ldloc.3
    IL_0118:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::minInvaderLeft
    IL_011d:  ldarg.0
    IL_011e:  ldloc.2
    IL_011f:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::maxInvaderLeft
    IL_0124:  ret
  } // end of method Invaders::RedrawInvaders

  .method private hidebysig instance void 
          ShootBullet() cil managed
  {
    // Code size       260 (0x104)
    .maxstack  4
    .locals init ([0] bool CS$4$0000,
             [1] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0001)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
    IL_0006:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Count()
    IL_000b:  ldc.i4.1
    IL_000c:  ceq
    IL_000e:  ldc.i4.0
    IL_000f:  ceq
    IL_0011:  stloc.0
    IL_0012:  ldloc.0
    IL_0013:  brtrue.s   IL_001a

    IL_0015:  br         IL_0103

    IL_001a:  ldarg.0
    IL_001b:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::_mute
    IL_0020:  stloc.0
    IL_0021:  ldloc.0
    IL_0022:  brtrue.s   IL_0059

    IL_0024:  ldc.i4     0x514
    IL_0029:  ldc.i4.s   15
    IL_002b:  call       void [mscorlib]System.Console::Beep(int32,
                                                             int32)
    IL_0030:  nop
    IL_0031:  ldc.i4     0x514
    IL_0036:  ldc.i4.s   15
    IL_0038:  call       void [mscorlib]System.Console::Beep(int32,
                                                             int32)
    IL_003d:  nop
    IL_003e:  ldc.i4     0x500
    IL_0043:  ldc.i4.s   15
    IL_0045:  call       void [mscorlib]System.Console::Beep(int32,
                                                             int32)
    IL_004a:  nop
    IL_004b:  ldc.i4     0x4ec
    IL_0050:  ldc.i4.s   15
    IL_0052:  call       void [mscorlib]System.Console::Beep(int32,
                                                             int32)
    IL_0057:  nop
    IL_0058:  nop
    IL_0059:  ldc.i4.0
    IL_005a:  call       void [mscorlib]System.Console::set_BackgroundColor(valuetype [mscorlib]System.ConsoleColor)
    IL_005f:  ldarg.0
    IL_0060:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
    IL_0065:  stloc.0
    IL_0066:  ldloc.0
    IL_0067:  brtrue.s   IL_007e

    IL_0069:  ldarg.0
    IL_006a:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_006f:  ldc.i4.8
    IL_0070:  ldc.i4.s   11
    IL_0072:  ldstr      "Ship fired, best of luck!"
    IL_0077:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                          int32,
                                                                                          string)
    IL_007c:  nop
    IL_007d:  nop
    IL_007e:  ldarg.0
    IL_007f:  dup
    IL_0080:  stloc.1
    IL_0081:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0086:  nop
    .try
    {
      IL_0087:  ldarg.0
      IL_0088:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
      IL_008d:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_0092:  ldc.i4.1
      IL_0093:  add
      IL_0094:  ldarg.0
      IL_0095:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
      IL_009a:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_009f:  ldc.i4.1
      IL_00a0:  sub
      IL_00a1:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_00a6:  nop
      IL_00a7:  nop
      IL_00a8:  leave.s    IL_00b2

    }  // end .try
    finally
    {
      IL_00aa:  ldloc.1
      IL_00ab:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00b0:  nop
      IL_00b1:  endfinally
    }  // end handler
    IL_00b2:  nop
    IL_00b3:  ldarg.0
    IL_00b4:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
    IL_00b9:  ldarg.0
    IL_00ba:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
    IL_00bf:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
    IL_00c4:  ldc.i4.1
    IL_00c5:  add
    IL_00c6:  ldarg.0
    IL_00c7:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
    IL_00cc:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
    IL_00d1:  ldc.i4.1
    IL_00d2:  sub
    IL_00d3:  newobj     instance void Microsoft.Samples.SpaceInvaders.ItemPosition::.ctor(int32,
                                                                                           int32)
    IL_00d8:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::Add(!0)
    IL_00dd:  nop
    IL_00de:  ldc.i4.s   14
    IL_00e0:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
    IL_00e5:  ldstr      "|"
    IL_00ea:  call       void [mscorlib]System.Console::Write(string)
    IL_00ef:  nop
    IL_00f0:  ldc.i4.s   15
    IL_00f2:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
    IL_00f7:  ldarg.0
    IL_00f8:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::shipBulletTimer
    IL_00fd:  ldc.i4.1
    IL_00fe:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_0103:  ret
  } // end of method Invaders::ShootBullet

  .method private hidebysig instance void 
          DrawShip(valuetype Microsoft.Samples.SpaceInvaders.ShipPosition sp) cil managed
  {
    // Code size       435 (0x1b3)
    .maxstack  4
    .locals init ([0] bool CS$4$0000,
             [1] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0001)
    IL_0000:  ldarg.1
    IL_0001:  ldc.i4.0
    IL_0002:  ceq
    IL_0004:  ldc.i4.0
    IL_0005:  ceq
    IL_0007:  stloc.0
    IL_0008:  ldloc.0
    IL_0009:  brtrue.s   IL_004f

    IL_000b:  ldarg.0
    IL_000c:  dup
    IL_000d:  stloc.1
    IL_000e:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0013:  nop
    .try
    {
      IL_0014:  ldarg.0
      IL_0015:  call       int32 [mscorlib]System.Console::get_WindowWidth()
      IL_001a:  ldc.i4.2
      IL_001b:  div
      IL_001c:  ldc.i4.1
      IL_001d:  sub
      IL_001e:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::RedrawShip(int32)
      IL_0023:  nop
      IL_0024:  ldarg.0
      IL_0025:  call       int32 [mscorlib]System.Console::get_WindowWidth()
      IL_002a:  ldc.i4.2
      IL_002b:  div
      IL_002c:  ldc.i4.1
      IL_002d:  sub
      IL_002e:  call       int32 [mscorlib]System.Console::get_CursorTop()
      IL_0033:  newobj     instance void Microsoft.Samples.SpaceInvaders.ItemPosition::.ctor(int32,
                                                                                             int32)
      IL_0038:  stfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
      IL_003d:  nop
      IL_003e:  leave.s    IL_0048

    }  // end .try
    finally
    {
      IL_0040:  ldloc.1
      IL_0041:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0046:  nop
      IL_0047:  endfinally
    }  // end handler
    IL_0048:  nop
    IL_0049:  nop
    IL_004a:  br         IL_01b2

    IL_004f:  ldarg.1
    IL_0050:  ldc.i4.1
    IL_0051:  bne.un.s   IL_0066

    IL_0053:  ldarg.0
    IL_0054:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
    IL_0059:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
    IL_005e:  ldc.i4.2
    IL_005f:  cgt
    IL_0061:  ldc.i4.0
    IL_0062:  ceq
    IL_0064:  br.s       IL_0067

    IL_0066:  ldc.i4.1
    IL_0067:  stloc.0
    IL_0068:  ldloc.0
    IL_0069:  brtrue     IL_0100

    IL_006e:  ldarg.0
    IL_006f:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
    IL_0074:  stloc.0
    IL_0075:  ldloc.0
    IL_0076:  brtrue.s   IL_008d

    IL_0078:  ldarg.0
    IL_0079:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_007e:  ldc.i4.8
    IL_007f:  ldc.i4.s   9
    IL_0081:  ldstr      "Moving Left"
    IL_0086:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                          int32,
                                                                                          string)
    IL_008b:  nop
    IL_008c:  nop
    IL_008d:  ldarg.0
    IL_008e:  dup
    IL_008f:  stloc.1
    IL_0090:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0095:  nop
    .try
    {
      IL_0096:  ldarg.0
      IL_0097:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
      IL_009c:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_00a1:  ldarg.0
      IL_00a2:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
      IL_00a7:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_00ac:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_00b1:  nop
      IL_00b2:  ldstr      "   "
      IL_00b7:  call       void [mscorlib]System.Console::Write(string)
      IL_00bc:  nop
      IL_00bd:  ldarg.0
      IL_00be:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
      IL_00c3:  ldarg.0
      IL_00c4:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
      IL_00c9:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_00ce:  ldc.i4.1
      IL_00cf:  sub
      IL_00d0:  callvirt   instance void Microsoft.Samples.SpaceInvaders.ItemPosition::set_Left(int32)
      IL_00d5:  ldarg.0
      IL_00d6:  ldarg.0
      IL_00d7:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
      IL_00dc:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_00e1:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::RedrawShip(int32)
      IL_00e6:  nop
      IL_00e7:  nop
      IL_00e8:  leave.s    IL_00f2

    }  // end .try
    finally
    {
      IL_00ea:  ldloc.1
      IL_00eb:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00f0:  nop
      IL_00f1:  endfinally
    }  // end handler
    IL_00f2:  nop
    IL_00f3:  ldarg.0
    IL_00f4:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ResolveShipDestroyed()
    IL_00f9:  nop
    IL_00fa:  nop
    IL_00fb:  br         IL_01b2

    IL_0100:  ldarg.1
    IL_0101:  ldc.i4.2
    IL_0102:  bne.un.s   IL_011d

    IL_0104:  ldarg.0
    IL_0105:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
    IL_010a:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
    IL_010f:  call       int32 [mscorlib]System.Console::get_WindowWidth()
    IL_0114:  ldc.i4.4
    IL_0115:  sub
    IL_0116:  clt
    IL_0118:  ldc.i4.0
    IL_0119:  ceq
    IL_011b:  br.s       IL_011e

    IL_011d:  ldc.i4.1
    IL_011e:  stloc.0
    IL_011f:  ldloc.0
    IL_0120:  brtrue     IL_01b2

    IL_0125:  ldarg.0
    IL_0126:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
    IL_012b:  stloc.0
    IL_012c:  ldloc.0
    IL_012d:  brtrue.s   IL_0144

    IL_012f:  ldarg.0
    IL_0130:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_0135:  ldc.i4.8
    IL_0136:  ldc.i4.s   10
    IL_0138:  ldstr      "Moving Right"
    IL_013d:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                          int32,
                                                                                          string)
    IL_0142:  nop
    IL_0143:  nop
    IL_0144:  ldarg.0
    IL_0145:  dup
    IL_0146:  stloc.1
    IL_0147:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_014c:  nop
    .try
    {
      IL_014d:  ldarg.0
      IL_014e:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
      IL_0153:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_0158:  ldarg.0
      IL_0159:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
      IL_015e:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_0163:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_0168:  nop
      IL_0169:  ldstr      "   "
      IL_016e:  call       void [mscorlib]System.Console::Write(string)
      IL_0173:  nop
      IL_0174:  ldarg.0
      IL_0175:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
      IL_017a:  ldarg.0
      IL_017b:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
      IL_0180:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_0185:  ldc.i4.1
      IL_0186:  add
      IL_0187:  callvirt   instance void Microsoft.Samples.SpaceInvaders.ItemPosition::set_Left(int32)
      IL_018c:  ldarg.0
      IL_018d:  ldarg.0
      IL_018e:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
      IL_0193:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_0198:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::RedrawShip(int32)
      IL_019d:  nop
      IL_019e:  nop
      IL_019f:  leave.s    IL_01a9

    }  // end .try
    finally
    {
      IL_01a1:  ldloc.1
      IL_01a2:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_01a7:  nop
      IL_01a8:  endfinally
    }  // end handler
    IL_01a9:  nop
    IL_01aa:  ldarg.0
    IL_01ab:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ResolveShipDestroyed()
    IL_01b0:  nop
    IL_01b1:  nop
    IL_01b2:  ret
  } // end of method Invaders::DrawShip

  .method private hidebysig instance void 
          RedrawShip(int32 left) cil managed
  {
    // Code size       63 (0x3f)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  call       int32 [mscorlib]System.Console::get_WindowHeight()
    IL_0006:  ldc.i4.2
    IL_0007:  sub
    IL_0008:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                          int32)
    IL_000d:  nop
    IL_000e:  ldc.i4.s   11
    IL_0010:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
    IL_0015:  ldstr      "{0}{1}{2}"
    IL_001a:  ldc.i4     0x2560
    IL_001f:  box        [mscorlib]System.Char
    IL_0024:  ldc.i4     0x2567
    IL_0029:  box        [mscorlib]System.Char
    IL_002e:  ldc.i4     0x2563
    IL_0033:  box        [mscorlib]System.Char
    IL_0038:  call       void [mscorlib]System.Console::Write(string,
                                                              object,
                                                              object,
                                                              object)
    IL_003d:  nop
    IL_003e:  ret
  } // end of method Invaders::RedrawShip

  .method private hidebysig instance void 
          ScoreUpdate() cil managed
  {
    // Code size       159 (0x9f)
    .maxstack  5
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0000,
             [1] object[] CS$0$0001,
             [2] bool CS$4$0002)
    IL_0000:  ldarg.0
    IL_0001:  dup
    IL_0002:  stloc.0
    IL_0003:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0008:  nop
    .try
    {
      IL_0009:  ldc.i4.s   15
      IL_000b:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
      IL_0010:  ldc.i4.s   10
      IL_0012:  ldc.i4.0
      IL_0013:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_0018:  nop
      IL_0019:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_CurrentCulture()
      IL_001e:  ldstr      "{0:00000}"
      IL_0023:  ldc.i4.1
      IL_0024:  newarr     [mscorlib]System.Object
      IL_0029:  stloc.1
      IL_002a:  ldloc.1
      IL_002b:  ldc.i4.0
      IL_002c:  ldarg.0
      IL_002d:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::score
      IL_0032:  box        [mscorlib]System.Int32
      IL_0037:  stelem.ref
      IL_0038:  ldloc.1
      IL_0039:  call       string [mscorlib]System.String::Format(class [mscorlib]System.IFormatProvider,
                                                                  string,
                                                                  object[])
      IL_003e:  call       void [mscorlib]System.Console::Write(string)
      IL_0043:  nop
      IL_0044:  ldarg.0
      IL_0045:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::score
      IL_004a:  ldarg.0
      IL_004b:  call       instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
      IL_0050:  ldc.i4.1
      IL_0051:  callvirt   instance !1 class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>::get_Item(!0)
      IL_0056:  ldc.i4.1
      IL_0057:  ldelem.ref
      IL_0058:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()
      IL_005d:  call       int32 [mscorlib]System.Convert::ToInt32(string,
                                                                   class [mscorlib]System.IFormatProvider)
      IL_0062:  cgt
      IL_0064:  ldc.i4.0
      IL_0065:  ceq
      IL_0067:  stloc.2
      IL_0068:  ldloc.2
      IL_0069:  brtrue.s   IL_0092

      IL_006b:  ldc.i4.s   10
      IL_006d:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
      IL_0072:  ldc.i4.s   39
      IL_0074:  ldc.i4.0
      IL_0075:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_007a:  nop
      IL_007b:  ldstr      "{0:00000}"
      IL_0080:  ldarg.0
      IL_0081:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::score
      IL_0086:  box        [mscorlib]System.Int32
      IL_008b:  call       void [mscorlib]System.Console::Write(string,
                                                                object)
      IL_0090:  nop
      IL_0091:  nop
      IL_0092:  nop
      IL_0093:  leave.s    IL_009d

    }  // end .try
    finally
    {
      IL_0095:  ldloc.0
      IL_0096:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_009b:  nop
      IL_009c:  endfinally
    }  // end handler
    IL_009d:  nop
    IL_009e:  ret
  } // end of method Invaders::ScoreUpdate

  .method private hidebysig instance bool 
          ShootDownInvader(class Microsoft.Samples.SpaceInvaders.ItemPosition bullet,
                           class Microsoft.Samples.SpaceInvaders.Invader invader) cil managed
  {
    // Code size       1021 (0x3fd)
    .maxstack  6
    .locals init ([0] int32 row,
             [1] bool CS$1$0000,
             [2] bool CS$4$0001,
             [3] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0002,
             [4] int32 CS$4$0003,
             [5] int32 CS$0$0004)
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
    IL_0006:  ldarg.2
    IL_0007:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
    IL_000c:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
    IL_0011:  bne.un.s   IL_0040

    IL_0013:  ldarg.1
    IL_0014:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
    IL_0019:  ldarg.2
    IL_001a:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
    IL_001f:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
    IL_0024:  blt.s      IL_0040

    IL_0026:  ldarg.1
    IL_0027:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
    IL_002c:  ldarg.2
    IL_002d:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
    IL_0032:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
    IL_0037:  ldc.i4.3
    IL_0038:  add
    IL_0039:  clt
    IL_003b:  ldc.i4.0
    IL_003c:  ceq
    IL_003e:  br.s       IL_0041

    IL_0040:  ldc.i4.1
    IL_0041:  stloc.2
    IL_0042:  ldloc.2
    IL_0043:  brtrue     IL_03f7

    IL_0048:  ldarg.0
    IL_0049:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_004e:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Count()
    IL_0053:  ldc.i4.1
    IL_0054:  ceq
    IL_0056:  ldc.i4.0
    IL_0057:  ceq
    IL_0059:  stloc.2
    IL_005a:  ldloc.2
    IL_005b:  brtrue.s   IL_0079

    IL_005d:  ldarg.0
    IL_005e:  ldc.i4.1
    IL_005f:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::invadersReset
    IL_0064:  ldarg.0
    IL_0065:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
    IL_006a:  ldc.r8     850.
    IL_0073:  callvirt   instance void [System]System.Timers.Timer::set_Interval(float64)
    IL_0078:  nop
    IL_0079:  ldarg.0
    IL_007a:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
    IL_007f:  ldarg.1
    IL_0080:  callvirt   instance bool class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::Remove(!0)
    IL_0085:  pop
    IL_0086:  ldarg.0
    IL_0087:  dup
    IL_0088:  stloc.3
    IL_0089:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_008e:  nop
    .try
    {
      IL_008f:  ldc.i4.0
      IL_0090:  ldc.i4.0
      IL_0091:  ldc.i4.3
      IL_0092:  ldc.i4.1
      IL_0093:  ldarg.2
      IL_0094:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_0099:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_009e:  ldarg.2
      IL_009f:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_00a4:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_00a9:  call       void [mscorlib]System.Console::MoveBufferArea(int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32)
      IL_00ae:  nop
      IL_00af:  nop
      IL_00b0:  leave.s    IL_00ba

    }  // end .try
    finally
    {
      IL_00b2:  ldloc.3
      IL_00b3:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00b8:  nop
      IL_00b9:  endfinally
    }  // end handler
    IL_00ba:  nop
    IL_00bb:  ldarg.2
    IL_00bc:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
    IL_00c1:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
    IL_00c6:  ldc.i4.2
    IL_00c7:  sub
    IL_00c8:  ldc.i4.3
    IL_00c9:  div
    IL_00ca:  stloc.0
    IL_00cb:  ldarg.0
    IL_00cc:  dup
    IL_00cd:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::score
    IL_00d2:  ldloc.0
    IL_00d3:  ldc.i4.1
    IL_00d4:  add
    IL_00d5:  ldc.i4.5
    IL_00d6:  mul
    IL_00d7:  add
    IL_00d8:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::score
    IL_00dd:  ldarg.0
    IL_00de:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ScoreUpdate()
    IL_00e3:  nop
    IL_00e4:  ldarg.0
    IL_00e5:  dup
    IL_00e6:  stloc.3
    IL_00e7:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_00ec:  nop
    .try
    {
      IL_00ed:  ldarg.2
      IL_00ee:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_00f3:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_00f8:  ldarg.2
      IL_00f9:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
      IL_00fe:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_0103:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_0108:  nop
      IL_0109:  ldc.i4.s   11
      IL_010b:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
      IL_0110:  ldstr      "{0}{0}{0}"
      IL_0115:  ldc.i4     0x263c
      IL_011a:  box        [mscorlib]System.Char
      IL_011f:  call       void [mscorlib]System.Console::Write(string,
                                                                object)
      IL_0124:  nop
      IL_0125:  nop
      IL_0126:  leave.s    IL_0130

    }  // end .try
    finally
    {
      IL_0128:  ldloc.3
      IL_0129:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_012e:  nop
      IL_012f:  endfinally
    }  // end handler
    IL_0130:  nop
    IL_0131:  ldarg.0
    IL_0132:  ldarg.2
    IL_0133:  callvirt   instance class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invader::get_Position()
    IL_0138:  stfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::invaderExplosion
    IL_013d:  ldarg.0
    IL_013e:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_0143:  ldarg.2
    IL_0144:  callvirt   instance bool class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::Remove(!0)
    IL_0149:  pop
    IL_014a:  ldarg.0
    IL_014b:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::explosionTimer
    IL_0150:  ldc.i4.1
    IL_0151:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_0156:  ldarg.0
    IL_0157:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_015c:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Count()
    IL_0161:  ldc.i4.0
    IL_0162:  ceq
    IL_0164:  ldc.i4.0
    IL_0165:  ceq
    IL_0167:  stloc.2
    IL_0168:  ldloc.2
    IL_0169:  brtrue     IL_0202

    IL_016e:  ldc.i4     0x3e8
    IL_0173:  call       void [mscorlib]System.Threading.Thread::Sleep(int32)
    IL_0178:  nop
    IL_0179:  ldc.i4.0
    IL_017a:  ldc.i4.0
    IL_017b:  ldc.i4.3
    IL_017c:  ldc.i4.1
    IL_017d:  ldarg.0
    IL_017e:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::invaderExplosion
    IL_0183:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
    IL_0188:  ldarg.0
    IL_0189:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::invaderExplosion
    IL_018e:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
    IL_0193:  call       void [mscorlib]System.Console::MoveBufferArea(int32,
                                                                       int32,
                                                                       int32,
                                                                       int32,
                                                                       int32,
                                                                       int32)
    IL_0198:  nop
    IL_0199:  ldarg.0
    IL_019a:  dup
    IL_019b:  stloc.3
    IL_019c:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_01a1:  nop
    .try
    {
      IL_01a2:  ldarg.0
      IL_01a3:  ldarg.0
      IL_01a4:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::iterationCount
      IL_01a9:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::InitializeInvaders(int32)
      IL_01ae:  nop
      IL_01af:  ldarg.0
      IL_01b0:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawShields()
      IL_01b5:  nop
      IL_01b6:  nop
      IL_01b7:  leave.s    IL_01c1

    }  // end .try
    finally
    {
      IL_01b9:  ldloc.3
      IL_01ba:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_01bf:  nop
      IL_01c0:  endfinally
    }  // end handler
    IL_01c1:  nop
    IL_01c2:  ldarg.0
    IL_01c3:  dup
    IL_01c4:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::iterationCount
    IL_01c9:  ldc.i4.1
    IL_01ca:  add
    IL_01cb:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::iterationCount
    IL_01d0:  ldarg.0
    IL_01d1:  call       valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
    IL_01d6:  stfld      valuetype [mscorlib]System.DateTime Microsoft.Samples.SpaceInvaders.Invaders::iterationStartTime
    IL_01db:  ldarg.0
    IL_01dc:  ldc.i4.0
    IL_01dd:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::invadersReset
    IL_01e2:  ldarg.0
    IL_01e3:  ldc.i4.1
    IL_01e4:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::movesInvalid
    IL_01e9:  ldc.i4     0x7d0
    IL_01ee:  call       void [mscorlib]System.Threading.Thread::Sleep(int32)
    IL_01f3:  nop
    IL_01f4:  ldarg.0
    IL_01f5:  ldc.i4.0
    IL_01f6:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::movesInvalid
    IL_01fb:  ldc.i4.1
    IL_01fc:  stloc.1
    IL_01fd:  br         IL_03fb

    IL_0202:  ldarg.0
    IL_0203:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
    IL_0208:  callvirt   instance float64 [System]System.Timers.Timer::get_Interval()
    IL_020d:  box        [mscorlib]System.Double
    IL_0212:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()
    IL_0217:  call       int32 [mscorlib]System.Convert::ToInt32(object,
                                                                 class [mscorlib]System.IFormatProvider)
    IL_021c:  stloc.s    CS$4$0003
    IL_021e:  ldloc.s    CS$4$0003
    IL_0220:  stloc.s    CS$0$0004
    IL_0222:  ldloc.s    CS$0$0004
    IL_0224:  ldc.i4     0xaf
    IL_0229:  bgt.s      IL_024e

    IL_022b:  ldloc.s    CS$0$0004
    IL_022d:  ldc.i4.s   50
    IL_022f:  beq        IL_039d

    IL_0234:  ldloc.s    CS$0$0004
    IL_0236:  ldc.i4.s   90
    IL_0238:  beq        IL_0372

    IL_023d:  ldloc.s    CS$0$0004
    IL_023f:  ldc.i4     0xaf
    IL_0244:  beq        IL_0344

    IL_0249:  br         IL_03c8

    IL_024e:  ldloc.s    CS$0$0004
    IL_0250:  ldc.i4     0x226
    IL_0255:  bgt.s      IL_0271

    IL_0257:  ldloc.s    CS$0$0004
    IL_0259:  ldc.i4     0x15e
    IL_025e:  beq        IL_0315

    IL_0263:  ldloc.s    CS$0$0004
    IL_0265:  ldc.i4     0x226
    IL_026a:  beq.s      IL_02e6

    IL_026c:  br         IL_03c8

    IL_0271:  ldloc.s    CS$0$0004
    IL_0273:  ldc.i4     0x2bc
    IL_0278:  beq.s      IL_02b7

    IL_027a:  ldloc.s    CS$0$0004
    IL_027c:  ldc.i4     0x352
    IL_0281:  beq.s      IL_0288

    IL_0283:  br         IL_03c8

    IL_0288:  ldarg.0
    IL_0289:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_028e:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Count()
    IL_0293:  ldc.i4.s   35
    IL_0295:  clt
    IL_0297:  ldc.i4.0
    IL_0298:  ceq
    IL_029a:  stloc.2
    IL_029b:  ldloc.2
    IL_029c:  brtrue.s   IL_02b2

    IL_029e:  ldarg.0
    IL_029f:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
    IL_02a4:  ldc.r8     700.
    IL_02ad:  callvirt   instance void [System]System.Timers.Timer::set_Interval(float64)
    IL_02b2:  br         IL_03f3

    IL_02b7:  ldarg.0
    IL_02b8:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_02bd:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Count()
    IL_02c2:  ldc.i4.s   28
    IL_02c4:  clt
    IL_02c6:  ldc.i4.0
    IL_02c7:  ceq
    IL_02c9:  stloc.2
    IL_02ca:  ldloc.2
    IL_02cb:  brtrue.s   IL_02e1

    IL_02cd:  ldarg.0
    IL_02ce:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
    IL_02d3:  ldc.r8     550.
    IL_02dc:  callvirt   instance void [System]System.Timers.Timer::set_Interval(float64)
    IL_02e1:  br         IL_03f3

    IL_02e6:  ldarg.0
    IL_02e7:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_02ec:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Count()
    IL_02f1:  ldc.i4.s   20
    IL_02f3:  clt
    IL_02f5:  ldc.i4.0
    IL_02f6:  ceq
    IL_02f8:  stloc.2
    IL_02f9:  ldloc.2
    IL_02fa:  brtrue.s   IL_0310

    IL_02fc:  ldarg.0
    IL_02fd:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
    IL_0302:  ldc.r8     350.
    IL_030b:  callvirt   instance void [System]System.Timers.Timer::set_Interval(float64)
    IL_0310:  br         IL_03f3

    IL_0315:  ldarg.0
    IL_0316:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_031b:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Count()
    IL_0320:  ldc.i4.s   10
    IL_0322:  clt
    IL_0324:  ldc.i4.0
    IL_0325:  ceq
    IL_0327:  stloc.2
    IL_0328:  ldloc.2
    IL_0329:  brtrue.s   IL_033f

    IL_032b:  ldarg.0
    IL_032c:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
    IL_0331:  ldc.r8     175.
    IL_033a:  callvirt   instance void [System]System.Timers.Timer::set_Interval(float64)
    IL_033f:  br         IL_03f3

    IL_0344:  ldarg.0
    IL_0345:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_034a:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Count()
    IL_034f:  ldc.i4.5
    IL_0350:  clt
    IL_0352:  ldc.i4.0
    IL_0353:  ceq
    IL_0355:  stloc.2
    IL_0356:  ldloc.2
    IL_0357:  brtrue.s   IL_036d

    IL_0359:  ldarg.0
    IL_035a:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
    IL_035f:  ldc.r8     90.
    IL_0368:  callvirt   instance void [System]System.Timers.Timer::set_Interval(float64)
    IL_036d:  br         IL_03f3

    IL_0372:  ldarg.0
    IL_0373:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_0378:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Count()
    IL_037d:  ldc.i4.3
    IL_037e:  clt
    IL_0380:  ldc.i4.0
    IL_0381:  ceq
    IL_0383:  stloc.2
    IL_0384:  ldloc.2
    IL_0385:  brtrue.s   IL_039b

    IL_0387:  ldarg.0
    IL_0388:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
    IL_038d:  ldc.r8     50.
    IL_0396:  callvirt   instance void [System]System.Timers.Timer::set_Interval(float64)
    IL_039b:  br.s       IL_03f3

    IL_039d:  ldarg.0
    IL_039e:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_03a3:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Count()
    IL_03a8:  ldc.i4.2
    IL_03a9:  clt
    IL_03ab:  ldc.i4.0
    IL_03ac:  ceq
    IL_03ae:  stloc.2
    IL_03af:  ldloc.2
    IL_03b0:  brtrue.s   IL_03c6

    IL_03b2:  ldarg.0
    IL_03b3:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
    IL_03b8:  ldc.r8     40.
    IL_03c1:  callvirt   instance void [System]System.Timers.Timer::set_Interval(float64)
    IL_03c6:  br.s       IL_03f3

    IL_03c8:  ldarg.0
    IL_03c9:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_03ce:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::get_Count()
    IL_03d3:  ldc.i4.1
    IL_03d4:  clt
    IL_03d6:  ldc.i4.0
    IL_03d7:  ceq
    IL_03d9:  stloc.2
    IL_03da:  ldloc.2
    IL_03db:  brtrue.s   IL_03f1

    IL_03dd:  ldarg.0
    IL_03de:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
    IL_03e3:  ldc.r8     850.
    IL_03ec:  callvirt   instance void [System]System.Timers.Timer::set_Interval(float64)
    IL_03f1:  br.s       IL_03f3

    IL_03f3:  ldc.i4.1
    IL_03f4:  stloc.1
    IL_03f5:  br.s       IL_03fb

    IL_03f7:  ldc.i4.0
    IL_03f8:  stloc.1
    IL_03f9:  br.s       IL_03fb

    IL_03fb:  ldloc.1
    IL_03fc:  ret
  } // end of method Invaders::ShootDownInvader

  .method private hidebysig instance void 
          ResolveBulletCollisions() cil managed
  {
    // Code size       261 (0x105)
    .maxstack  7
    .locals init ([0] int32 i,
             [1] class Microsoft.Samples.SpaceInvaders.ItemPosition ipib,
             [2] valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition> CS$5$0000,
             [3] bool CS$4$0001)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
    IL_0006:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Count()
    IL_000b:  ldc.i4.1
    IL_000c:  sub
    IL_000d:  stloc.0
    IL_000e:  br         IL_00f6

    IL_0013:  ldarg.0
    IL_0014:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
    IL_0019:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<!0> class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::GetEnumerator()
    IL_001e:  stloc.2
    .try
    {
      IL_001f:  br         IL_00d7

      IL_0024:  ldloca.s   CS$5$0000
      IL_0026:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Current()
      IL_002b:  stloc.1
      IL_002c:  ldarg.0
      IL_002d:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_0032:  ldloc.0
      IL_0033:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_0038:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_003d:  ldloc.1
      IL_003e:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_0043:  ceq
      IL_0045:  ldc.i4.0
      IL_0046:  ceq
      IL_0048:  stloc.3
      IL_0049:  ldloc.3
      IL_004a:  brtrue     IL_00d6

      IL_004f:  ldloc.1
      IL_0050:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_0055:  ldarg.0
      IL_0056:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_005b:  ldloc.0
      IL_005c:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_0061:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_0066:  ceq
      IL_0068:  ldc.i4.0
      IL_0069:  ceq
      IL_006b:  stloc.3
      IL_006c:  ldloc.3
      IL_006d:  brtrue.s   IL_00d5

      IL_006f:  ldarg.0
      IL_0070:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
      IL_0075:  stloc.3
      IL_0076:  ldloc.3
      IL_0077:  brtrue.s   IL_008d

      IL_0079:  ldarg.0
      IL_007a:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
      IL_007f:  ldc.i4.8
      IL_0080:  ldc.i4.6
      IL_0081:  ldstr      "Bullets collided"
      IL_0086:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                            int32,
                                                                                            string)
      IL_008b:  nop
      IL_008c:  nop
      IL_008d:  ldc.i4.0
      IL_008e:  ldc.i4.0
      IL_008f:  ldc.i4.1
      IL_0090:  ldc.i4.1
      IL_0091:  ldarg.0
      IL_0092:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_0097:  ldloc.0
      IL_0098:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_009d:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_00a2:  ldarg.0
      IL_00a3:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_00a8:  ldloc.0
      IL_00a9:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_00ae:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_00b3:  call       void [mscorlib]System.Console::MoveBufferArea(int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32)
      IL_00b8:  nop
      IL_00b9:  ldarg.0
      IL_00ba:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
      IL_00bf:  ldloc.1
      IL_00c0:  callvirt   instance bool class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::Remove(!0)
      IL_00c5:  pop
      IL_00c6:  ldarg.0
      IL_00c7:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_00cc:  ldloc.0
      IL_00cd:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::RemoveAt(int32)
      IL_00d2:  nop
      IL_00d3:  br.s       IL_00e5

      IL_00d5:  nop
      IL_00d6:  nop
      IL_00d7:  ldloca.s   CS$5$0000
      IL_00d9:  call       instance bool valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition>::MoveNext()
      IL_00de:  stloc.3
      IL_00df:  ldloc.3
      IL_00e0:  brtrue     IL_0024

      IL_00e5:  leave.s    IL_00f0

    }  // end .try
    finally
    {
      IL_00e7:  ldloca.s   CS$5$0000
      IL_00e9:  call       instance void valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition>::Dispose()
      IL_00ee:  nop
      IL_00ef:  endfinally
    }  // end handler
    IL_00f0:  nop
    IL_00f1:  nop
    IL_00f2:  ldloc.0
    IL_00f3:  ldc.i4.1
    IL_00f4:  sub
    IL_00f5:  stloc.0
    IL_00f6:  ldloc.0
    IL_00f7:  ldc.i4.0
    IL_00f8:  clt
    IL_00fa:  ldc.i4.0
    IL_00fb:  ceq
    IL_00fd:  stloc.3
    IL_00fe:  ldloc.3
    IL_00ff:  brtrue     IL_0013

    IL_0104:  ret
  } // end of method Invaders::ResolveBulletCollisions

  .method private hidebysig instance void 
          InvaderDestroyed() cil managed
  {
    // Code size       591 (0x24f)
    .maxstack  7
    .locals init ([0] bool invaderShot,
             [1] int32 i,
             [2] class Microsoft.Samples.SpaceInvaders.Invader ipInvader,
             [3] valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader> CS$5$0000,
             [4] bool CS$4$0001,
             [5] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0002)
    IL_0000:  ldc.i4.0
    IL_0001:  stloc.0
    IL_0002:  ldc.i4.0
    IL_0003:  stloc.1
    IL_0004:  br         IL_0214

    IL_0009:  ldarg.0
    IL_000a:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader> Microsoft.Samples.SpaceInvaders.Invaders::liInvaders
    IL_000f:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<!0> class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.Invader>::GetEnumerator()
    IL_0014:  stloc.3
    .try
    {
      IL_0015:  br         IL_009e

      IL_001a:  ldloca.s   CS$5$0000
      IL_001c:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::get_Current()
      IL_0021:  stloc.2
      IL_0022:  ldarg.0
      IL_0023:  ldarg.0
      IL_0024:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_0029:  ldloc.1
      IL_002a:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_002f:  ldloc.2
      IL_0030:  call       instance bool Microsoft.Samples.SpaceInvaders.Invaders::ShootDownInvader(class Microsoft.Samples.SpaceInvaders.ItemPosition,
                                                                                                    class Microsoft.Samples.SpaceInvaders.Invader)
      IL_0035:  stloc.0
      IL_0036:  ldloc.0
      IL_0037:  ldc.i4.0
      IL_0038:  ceq
      IL_003a:  stloc.s    CS$4$0001
      IL_003c:  ldloc.s    CS$4$0001
      IL_003e:  brtrue.s   IL_009d

      IL_0040:  ldarg.0
      IL_0041:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
      IL_0046:  stloc.s    CS$4$0001
      IL_0048:  ldloc.s    CS$4$0001
      IL_004a:  brtrue.s   IL_006d

      IL_004c:  ldarg.0
      IL_004d:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
      IL_0052:  ldc.i4.8
      IL_0053:  ldc.i4.1
      IL_0054:  ldstr      "Good shot! Invader destroyed"
      IL_0059:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                            int32,
                                                                                            string)
      IL_005e:  nop
      IL_005f:  ldarg.0
      IL_0060:  ldstr      "DIRECT HIT!"
      IL_0065:  ldnull
      IL_0066:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::WriteLcdLine(string,
                                                                                                string)
      IL_006b:  nop
      IL_006c:  nop
      IL_006d:  ldarg.0
      IL_006e:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::_mute
      IL_0073:  stloc.s    CS$4$0001
      IL_0075:  ldloc.s    CS$4$0001
      IL_0077:  brtrue.s   IL_009b

      IL_0079:  ldc.i4.s   100
      IL_007b:  ldc.i4.s   15
      IL_007d:  call       void [mscorlib]System.Console::Beep(int32,
                                                               int32)
      IL_0082:  nop
      IL_0083:  ldc.i4.s   120
      IL_0085:  ldc.i4.s   15
      IL_0087:  call       void [mscorlib]System.Console::Beep(int32,
                                                               int32)
      IL_008c:  nop
      IL_008d:  ldc.i4     0x8c
      IL_0092:  ldc.i4.s   15
      IL_0094:  call       void [mscorlib]System.Console::Beep(int32,
                                                               int32)
      IL_0099:  nop
      IL_009a:  nop
      IL_009b:  br.s       IL_00ae

      IL_009d:  nop
      IL_009e:  ldloca.s   CS$5$0000
      IL_00a0:  call       instance bool valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::MoveNext()
      IL_00a5:  stloc.s    CS$4$0001
      IL_00a7:  ldloc.s    CS$4$0001
      IL_00a9:  brtrue     IL_001a

      IL_00ae:  leave.s    IL_00b9

    }  // end .try
    finally
    {
      IL_00b0:  ldloca.s   CS$5$0000
      IL_00b2:  call       instance void valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.Invader>::Dispose()
      IL_00b7:  nop
      IL_00b8:  endfinally
    }  // end handler
    IL_00b9:  nop
    IL_00ba:  ldloc.0
    IL_00bb:  stloc.s    CS$4$0001
    IL_00bd:  ldloc.s    CS$4$0001
    IL_00bf:  brtrue     IL_020f

    IL_00c4:  ldarg.0
    IL_00c5:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
    IL_00ca:  ldloc.1
    IL_00cb:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
    IL_00d0:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
    IL_00d5:  ldc.i4.3
    IL_00d6:  cgt
    IL_00d8:  stloc.s    CS$4$0001
    IL_00da:  ldloc.s    CS$4$0001
    IL_00dc:  brtrue     IL_016c

    IL_00e1:  ldarg.0
    IL_00e2:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
    IL_00e7:  stloc.s    CS$4$0001
    IL_00e9:  ldloc.s    CS$4$0001
    IL_00eb:  brtrue.s   IL_0112

    IL_00ed:  ldarg.0
    IL_00ee:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_00f3:  ldc.i4.8
    IL_00f4:  ldc.i4.0
    IL_00f5:  ldstr      "Talk about terrible, you missed them!"
    IL_00fa:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                          int32,
                                                                                          string)
    IL_00ff:  nop
    IL_0100:  ldarg.0
    IL_0101:  ldstr      "Missed!"
    IL_0106:  ldstr      "Practice maybe\?"
    IL_010b:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::WriteLcdLine(string,
                                                                                              string)
    IL_0110:  nop
    IL_0111:  nop
    IL_0112:  ldarg.0
    IL_0113:  dup
    IL_0114:  stloc.s    CS$2$0002
    IL_0116:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_011b:  nop
    .try
    {
      IL_011c:  ldc.i4.0
      IL_011d:  ldc.i4.0
      IL_011e:  ldc.i4.1
      IL_011f:  ldc.i4.1
      IL_0120:  ldarg.0
      IL_0121:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_0126:  ldloc.1
      IL_0127:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_012c:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_0131:  ldarg.0
      IL_0132:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_0137:  ldloc.1
      IL_0138:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_013d:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_0142:  call       void [mscorlib]System.Console::MoveBufferArea(int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32)
      IL_0147:  nop
      IL_0148:  ldarg.0
      IL_0149:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_014e:  ldloc.1
      IL_014f:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::RemoveAt(int32)
      IL_0154:  nop
      IL_0155:  ldloc.1
      IL_0156:  ldc.i4.1
      IL_0157:  sub
      IL_0158:  stloc.1
      IL_0159:  nop
      IL_015a:  leave.s    IL_0165

    }  // end .try
    finally
    {
      IL_015c:  ldloc.s    CS$2$0002
      IL_015e:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0163:  nop
      IL_0164:  endfinally
    }  // end handler
    IL_0165:  nop
    IL_0166:  nop
    IL_0167:  br         IL_020e

    IL_016c:  ldarg.0
    IL_016d:  dup
    IL_016e:  stloc.s    CS$2$0002
    IL_0170:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0175:  nop
    .try
    {
      IL_0176:  ldc.i4.0
      IL_0177:  ldc.i4.0
      IL_0178:  ldc.i4.1
      IL_0179:  ldc.i4.1
      IL_017a:  ldarg.0
      IL_017b:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_0180:  ldloc.1
      IL_0181:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_0186:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_018b:  ldarg.0
      IL_018c:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_0191:  ldloc.1
      IL_0192:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_0197:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_019c:  call       void [mscorlib]System.Console::MoveBufferArea(int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32)
      IL_01a1:  nop
      IL_01a2:  ldarg.0
      IL_01a3:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_01a8:  ldloc.1
      IL_01a9:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_01ae:  ldarg.0
      IL_01af:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_01b4:  ldloc.1
      IL_01b5:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_01ba:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_01bf:  ldc.i4.1
      IL_01c0:  sub
      IL_01c1:  callvirt   instance void Microsoft.Samples.SpaceInvaders.ItemPosition::set_Top(int32)
      IL_01c6:  ldarg.0
      IL_01c7:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_01cc:  ldloc.1
      IL_01cd:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_01d2:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_01d7:  ldarg.0
      IL_01d8:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_01dd:  ldloc.1
      IL_01de:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_01e3:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_01e8:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_01ed:  nop
      IL_01ee:  ldc.i4.s   14
      IL_01f0:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
      IL_01f5:  ldstr      "|"
      IL_01fa:  call       void [mscorlib]System.Console::Write(string)
      IL_01ff:  nop
      IL_0200:  nop
      IL_0201:  leave.s    IL_020c

    }  // end .try
    finally
    {
      IL_0203:  ldloc.s    CS$2$0002
      IL_0205:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_020a:  nop
      IL_020b:  endfinally
    }  // end handler
    IL_020c:  nop
    IL_020d:  nop
    IL_020e:  nop
    IL_020f:  nop
    IL_0210:  ldloc.1
    IL_0211:  ldc.i4.1
    IL_0212:  add
    IL_0213:  stloc.1
    IL_0214:  ldloc.1
    IL_0215:  ldarg.0
    IL_0216:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
    IL_021b:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Count()
    IL_0220:  clt
    IL_0222:  stloc.s    CS$4$0001
    IL_0224:  ldloc.s    CS$4$0001
    IL_0226:  brtrue     IL_0009

    IL_022b:  ldarg.0
    IL_022c:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
    IL_0231:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Count()
    IL_0236:  ldc.i4.0
    IL_0237:  ceq
    IL_0239:  ldc.i4.0
    IL_023a:  ceq
    IL_023c:  stloc.s    CS$4$0001
    IL_023e:  ldloc.s    CS$4$0001
    IL_0240:  brtrue.s   IL_024e

    IL_0242:  ldarg.0
    IL_0243:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::shipBulletTimer
    IL_0248:  ldc.i4.0
    IL_0249:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_024e:  ret
  } // end of method Invaders::InvaderDestroyed

  .method private hidebysig instance void 
          ResolveShipDestroyed() cil managed
  {
    // Code size       384 (0x180)
    .maxstack  6
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.ItemPosition ip,
             [1] class Microsoft.Samples.SpaceInvaders.ItemPosition ipi,
             [2] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0000,
             [3] valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition> CS$5$0001,
             [4] bool CS$4$0002,
             [5] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0003,
             [6] valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition> CS$5$0004)
    IL_0000:  ldarg.0
    IL_0001:  dup
    IL_0002:  stloc.2
    IL_0003:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0008:  nop
    .try
    {
      IL_0009:  ldarg.0
      IL_000a:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
      IL_000f:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<!0> class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::GetEnumerator()
      IL_0014:  stloc.3
      .try
      {
        IL_0015:  br         IL_0157

        IL_001a:  ldloca.s   CS$5$0001
        IL_001c:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Current()
        IL_0021:  stloc.0
        IL_0022:  ldloc.0
        IL_0023:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
        IL_0028:  ldarg.0
        IL_0029:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
        IL_002e:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
        IL_0033:  ceq
        IL_0035:  ldc.i4.0
        IL_0036:  ceq
        IL_0038:  stloc.s    CS$4$0002
        IL_003a:  ldloc.s    CS$4$0002
        IL_003c:  brtrue     IL_0156

        IL_0041:  ldloc.0
        IL_0042:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
        IL_0047:  ldarg.0
        IL_0048:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
        IL_004d:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
        IL_0052:  blt.s      IL_006b

        IL_0054:  ldloc.0
        IL_0055:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
        IL_005a:  ldarg.0
        IL_005b:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
        IL_0060:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
        IL_0065:  ldc.i4.2
        IL_0066:  add
        IL_0067:  cgt
        IL_0069:  br.s       IL_006c

        IL_006b:  ldc.i4.1
        IL_006c:  stloc.s    CS$4$0002
        IL_006e:  ldloc.s    CS$4$0002
        IL_0070:  brtrue     IL_0155

        IL_0075:  ldarg.0
        IL_0076:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
        IL_007b:  stloc.s    CS$4$0002
        IL_007d:  ldloc.s    CS$4$0002
        IL_007f:  brtrue.s   IL_00a6

        IL_0081:  ldarg.0
        IL_0082:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
        IL_0087:  ldc.i4.8
        IL_0088:  ldc.i4.4
        IL_0089:  ldstr      "Silly, silly, silly... AVOID the bullets"
        IL_008e:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                              int32,
                                                                                              string)
        IL_0093:  nop
        IL_0094:  ldarg.0
        IL_0095:  ldstr      "DOH!"
        IL_009a:  ldstr      "Move, silly!"
        IL_009f:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::WriteLcdLine(string,
                                                                                                  string)
        IL_00a4:  nop
        IL_00a5:  nop
        IL_00a6:  ldarg.0
        IL_00a7:  ldc.i4.1
        IL_00a8:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::shipBeingDestroyed
        IL_00ad:  ldarg.0
        IL_00ae:  dup
        IL_00af:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::shipCount
        IL_00b4:  ldc.i4.1
        IL_00b5:  sub
        IL_00b6:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::shipCount
        IL_00bb:  ldarg.0
        IL_00bc:  dup
        IL_00bd:  stloc.s    CS$2$0003
        IL_00bf:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
        IL_00c4:  nop
        .try
        {
          IL_00c5:  ldarg.0
          IL_00c6:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
          IL_00cb:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<!0> class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::GetEnumerator()
          IL_00d0:  stloc.s    CS$5$0004
          .try
          {
            IL_00d2:  br.s       IL_00f3

            IL_00d4:  ldloca.s   CS$5$0004
            IL_00d6:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Current()
            IL_00db:  stloc.1
            IL_00dc:  ldc.i4.0
            IL_00dd:  ldc.i4.0
            IL_00de:  ldc.i4.1
            IL_00df:  ldc.i4.1
            IL_00e0:  ldloc.1
            IL_00e1:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
            IL_00e6:  ldloc.1
            IL_00e7:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
            IL_00ec:  call       void [mscorlib]System.Console::MoveBufferArea(int32,
                                                                               int32,
                                                                               int32,
                                                                               int32,
                                                                               int32,
                                                                               int32)
            IL_00f1:  nop
            IL_00f2:  nop
            IL_00f3:  ldloca.s   CS$5$0004
            IL_00f5:  call       instance bool valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition>::MoveNext()
            IL_00fa:  stloc.s    CS$4$0002
            IL_00fc:  ldloc.s    CS$4$0002
            IL_00fe:  brtrue.s   IL_00d4

            IL_0100:  leave.s    IL_010b

          }  // end .try
          finally
          {
            IL_0102:  ldloca.s   CS$5$0004
            IL_0104:  call       instance void valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition>::Dispose()
            IL_0109:  nop
            IL_010a:  endfinally
          }  // end handler
          IL_010b:  nop
          IL_010c:  nop
          IL_010d:  leave.s    IL_0118

        }  // end .try
        finally
        {
          IL_010f:  ldloc.s    CS$2$0003
          IL_0111:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
          IL_0116:  nop
          IL_0117:  endfinally
        }  // end handler
        IL_0118:  nop
        IL_0119:  ldarg.0
        IL_011a:  newobj     instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::.ctor()
        IL_011f:  stfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
        IL_0124:  ldarg.0
        IL_0125:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersBulletTimer
        IL_012a:  ldc.i4.0
        IL_012b:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
        IL_0130:  ldarg.0
        IL_0131:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
        IL_0136:  ldc.i4.0
        IL_0137:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
        IL_013c:  ldarg.0
        IL_013d:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::shipBulletTimer
        IL_0142:  ldc.i4.0
        IL_0143:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
        IL_0148:  ldarg.0
        IL_0149:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::shipDestroyedTimer
        IL_014e:  ldc.i4.1
        IL_014f:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
        IL_0154:  nop
        IL_0155:  nop
        IL_0156:  nop
        IL_0157:  ldloca.s   CS$5$0001
        IL_0159:  call       instance bool valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition>::MoveNext()
        IL_015e:  stloc.s    CS$4$0002
        IL_0160:  ldloc.s    CS$4$0002
        IL_0162:  brtrue     IL_001a

        IL_0167:  leave.s    IL_0172

      }  // end .try
      finally
      {
        IL_0169:  ldloca.s   CS$5$0001
        IL_016b:  call       instance void valuetype [mscorlib]System.Collections.Generic.'List`1'/Enumerator<class Microsoft.Samples.SpaceInvaders.ItemPosition>::Dispose()
        IL_0170:  nop
        IL_0171:  endfinally
      }  // end handler
      IL_0172:  nop
      IL_0173:  nop
      IL_0174:  leave.s    IL_017e

    }  // end .try
    finally
    {
      IL_0176:  ldloc.2
      IL_0177:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_017c:  nop
      IL_017d:  endfinally
    }  // end handler
    IL_017e:  nop
    IL_017f:  ret
  } // end of method Invaders::ResolveShipDestroyed

  .method private hidebysig instance void 
          DisableTimers(bool enable) cil managed
  {
    // Code size       82 (0x52)
    .maxstack  2
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0000)
    IL_0000:  ldarg.0
    IL_0001:  dup
    IL_0002:  stloc.0
    IL_0003:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0008:  nop
    .try
    {
      IL_0009:  ldarg.0
      IL_000a:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersBulletTimer
      IL_000f:  ldarg.1
      IL_0010:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
      IL_0015:  ldarg.0
      IL_0016:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
      IL_001b:  ldarg.1
      IL_001c:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
      IL_0021:  ldarg.0
      IL_0022:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::shipBulletTimer
      IL_0027:  ldarg.1
      IL_0028:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
      IL_002d:  ldarg.0
      IL_002e:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::shipDestroyedTimer
      IL_0033:  ldc.i4.0
      IL_0034:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
      IL_0039:  ldarg.0
      IL_003a:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::explosionTimer
      IL_003f:  ldc.i4.0
      IL_0040:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
      IL_0045:  nop
      IL_0046:  leave.s    IL_0050

    }  // end .try
    finally
    {
      IL_0048:  ldloc.0
      IL_0049:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_004e:  nop
      IL_004f:  endfinally
    }  // end handler
    IL_0050:  nop
    IL_0051:  ret
  } // end of method Invaders::DisableTimers

  .method private hidebysig instance void 
          ResetTimers() cil managed
  {
    // Code size       101 (0x65)
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersBulletTimer
    IL_0006:  ldc.r8     90.
    IL_000f:  callvirt   instance void [System]System.Timers.Timer::set_Interval(float64)
    IL_0014:  ldarg.0
    IL_0015:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
    IL_001a:  ldc.r8     850.
    IL_0023:  callvirt   instance void [System]System.Timers.Timer::set_Interval(float64)
    IL_0028:  ldarg.0
    IL_0029:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::shipBulletTimer
    IL_002e:  ldc.r8     70.
    IL_0037:  callvirt   instance void [System]System.Timers.Timer::set_Interval(float64)
    IL_003c:  ldarg.0
    IL_003d:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::shipDestroyedTimer
    IL_0042:  ldc.r8     250.
    IL_004b:  callvirt   instance void [System]System.Timers.Timer::set_Interval(float64)
    IL_0050:  ldarg.0
    IL_0051:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::explosionTimer
    IL_0056:  ldc.r8     35.
    IL_005f:  callvirt   instance void [System]System.Timers.Timer::set_Interval(float64)
    IL_0064:  ret
  } // end of method Invaders::ResetTimers

  .method private hidebysig instance void 
          DisplayGameOver(int32 preSleep) cil managed
  {
    // Code size       297 (0x129)
    .maxstack  9
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0000,
             [1] bool CS$4$0001,
             [2] string[] CS$0$0002)
    IL_0000:  ldarg.0
    IL_0001:  dup
    IL_0002:  stloc.0
    IL_0003:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0008:  nop
    .try
    {
      IL_0009:  ldarg.0
      IL_000a:  ldfld      valuetype Microsoft.Samples.SpaceInvaders.GameState Microsoft.Samples.SpaceInvaders.Invaders::gameOver
      IL_000f:  ldc.i4.0
      IL_0010:  ceq
      IL_0012:  ldc.i4.0
      IL_0013:  ceq
      IL_0015:  stloc.1
      IL_0016:  ldloc.1
      IL_0017:  brtrue     IL_011c

      IL_001c:  ldarg.0
      IL_001d:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
      IL_0022:  stloc.1
      IL_0023:  ldloc.1
      IL_0024:  brtrue     IL_0106

      IL_0029:  ldarg.0
      IL_002a:  ldc.i4.2
      IL_002b:  stfld      valuetype Microsoft.Samples.SpaceInvaders.GameState Microsoft.Samples.SpaceInvaders.Invaders::gameOver
      IL_0030:  ldarg.0
      IL_0031:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::Reset()
      IL_0036:  nop
      IL_0037:  ldarg.1
      IL_0038:  ldc.i4.0
      IL_0039:  cgt
      IL_003b:  ldc.i4.0
      IL_003c:  ceq
      IL_003e:  stloc.1
      IL_003f:  ldloc.1
      IL_0040:  brtrue.s   IL_0049

      IL_0042:  ldarg.1
      IL_0043:  call       void [mscorlib]System.Threading.Thread::Sleep(int32)
      IL_0048:  nop
      IL_0049:  call       void [mscorlib]System.Console::Clear()
      IL_004e:  nop
      IL_004f:  ldarg.0
      IL_0050:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ScoreUpdate()
      IL_0055:  nop
      IL_0056:  ldarg.0
      IL_0057:  ldarg.0
      IL_0058:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::score
      IL_005d:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::WriteScore(int32)
      IL_0062:  nop
      IL_0063:  call       void [mscorlib]System.Console::Clear()
      IL_0068:  nop
      IL_0069:  ldarg.0
      IL_006a:  ldc.i4.s   22
      IL_006c:  call       int32 [mscorlib]System.Console::get_WindowHeight()
      IL_0071:  ldc.i4.2
      IL_0072:  div
      IL_0073:  ldc.i4.s   13
      IL_0075:  sub
      IL_0076:  ldc.i4.8
      IL_0077:  ldc.i4     0x15e
      IL_007c:  ldc.i4.0
      IL_007d:  ldc.i4.4
      IL_007e:  newarr     [mscorlib]System.String
      IL_0083:  stloc.2
      IL_0084:  ldloc.2
      IL_0085:  ldc.i4.0
      IL_0086:  ldstr      "G"
      IL_008b:  stelem.ref
      IL_008c:  ldloc.2
      IL_008d:  ldc.i4.1
      IL_008e:  ldstr      "A"
      IL_0093:  stelem.ref
      IL_0094:  ldloc.2
      IL_0095:  ldc.i4.2
      IL_0096:  ldstr      "M"
      IL_009b:  stelem.ref
      IL_009c:  ldloc.2
      IL_009d:  ldc.i4.3
      IL_009e:  ldstr      "E"
      IL_00a3:  stelem.ref
      IL_00a4:  ldloc.2
      IL_00a5:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawLetters(int32,
                                                                                               int32,
                                                                                               int32,
                                                                                               int32,
                                                                                               bool,
                                                                                               string[])
      IL_00aa:  nop
      IL_00ab:  ldarg.0
      IL_00ac:  ldc.i4.s   22
      IL_00ae:  call       int32 [mscorlib]System.Console::get_WindowHeight()
      IL_00b3:  ldc.i4.2
      IL_00b4:  div
      IL_00b5:  ldc.i4.3
      IL_00b6:  sub
      IL_00b7:  ldc.i4.8
      IL_00b8:  ldc.i4     0x15e
      IL_00bd:  ldc.i4.0
      IL_00be:  ldc.i4.4
      IL_00bf:  newarr     [mscorlib]System.String
      IL_00c4:  stloc.2
      IL_00c5:  ldloc.2
      IL_00c6:  ldc.i4.0
      IL_00c7:  ldstr      "O"
      IL_00cc:  stelem.ref
      IL_00cd:  ldloc.2
      IL_00ce:  ldc.i4.1
      IL_00cf:  ldstr      "V"
      IL_00d4:  stelem.ref
      IL_00d5:  ldloc.2
      IL_00d6:  ldc.i4.2
      IL_00d7:  ldstr      "E"
      IL_00dc:  stelem.ref
      IL_00dd:  ldloc.2
      IL_00de:  ldc.i4.3
      IL_00df:  ldstr      "R"
      IL_00e4:  stelem.ref
      IL_00e5:  ldloc.2
      IL_00e6:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawLetters(int32,
                                                                                               int32,
                                                                                               int32,
                                                                                               int32,
                                                                                               bool,
                                                                                               string[])
      IL_00eb:  nop
      IL_00ec:  ldarg.0
      IL_00ed:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DisplayGameStatistics()
      IL_00f2:  nop
      IL_00f3:  ldarg.0
      IL_00f4:  ldc.i4.0
      IL_00f5:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::score
      IL_00fa:  ldc.i4     0x2710
      IL_00ff:  call       void [mscorlib]System.Threading.Thread::Sleep(int32)
      IL_0104:  nop
      IL_0105:  nop
      IL_0106:  ldarg.0
      IL_0107:  ldc.i4.0
      IL_0108:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::score
      IL_010d:  ldarg.0
      IL_010e:  ldc.i4.0
      IL_010f:  stfld      valuetype Microsoft.Samples.SpaceInvaders.GameState Microsoft.Samples.SpaceInvaders.Invaders::gameOver
      IL_0114:  ldarg.0
      IL_0115:  ldc.i4.0
      IL_0116:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::gettingName
      IL_011b:  nop
      IL_011c:  nop
      IL_011d:  leave.s    IL_0127

    }  // end .try
    finally
    {
      IL_011f:  ldloc.0
      IL_0120:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0125:  nop
      IL_0126:  endfinally
    }  // end handler
    IL_0127:  nop
    IL_0128:  ret
  } // end of method Invaders::DisplayGameOver

  .method private hidebysig instance void 
          DisplayGameStatistics() cil managed
  {
    // Code size       1057 (0x421)
    .maxstack  7
    .locals init ([0] string[] data,
             [1] class Microsoft.Samples.SpaceInvaders.GameData gd,
             [2] int32 startValue,
             [3] int32 i,
             [4] string[] vals,
             [5] int64 itemKey,
             [6] int32 totalShipShotsFired,
             [7] int32 totalShipShotsHitInvaders,
             [8] int32 totalShipShotsHitShield,
             [9] int32 totalShipMoves,
             [10] class Microsoft.Samples.SpaceInvaders.GameEvent ge,
             [11] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0000,
             [12] char[] CS$0$0001,
             [13] bool CS$4$0002,
             [14] class [mscorlib]System.Collections.Generic.'IEnumerator`1'<class Microsoft.Samples.SpaceInvaders.GameEvent> CS$5$0003,
             [15] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0004)
    IL_0000:  ldarg.0
    IL_0001:  dup
    IL_0002:  stloc.s    CS$2$0000
    IL_0004:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0009:  nop
    .try
    {
      .try
      {
        IL_000a:  ldarg.0
        IL_000b:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
        IL_0010:  callvirt   instance void [System]System.Diagnostics.TraceSource::Flush()
        IL_0015:  nop
        IL_0016:  nop
        IL_0017:  leave.s    IL_007d

      }  // end .try
      finally
      {
        IL_0019:  ldarg.0
        IL_001a:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
        IL_001f:  callvirt   instance class [System]System.Diagnostics.TraceListenerCollection [System]System.Diagnostics.TraceSource::get_Listeners()
        IL_0024:  ldstr      "gamestats"
        IL_0029:  callvirt   instance class [System]System.Diagnostics.TraceListener [System]System.Diagnostics.TraceListenerCollection::get_Item(string)
        IL_002e:  callvirt   instance void [System]System.Diagnostics.TraceListener::Close()
        IL_0033:  nop
        IL_0034:  ldarg.0
        IL_0035:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
        IL_003a:  callvirt   instance class [System]System.Diagnostics.TraceListenerCollection [System]System.Diagnostics.TraceSource::get_Listeners()
        IL_003f:  ldstr      "gamestats"
        IL_0044:  callvirt   instance void [System]System.Diagnostics.TraceListenerCollection::Remove(string)
        IL_0049:  nop
        IL_004a:  ldarg.0
        IL_004b:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
        IL_0050:  callvirt   instance class [System]System.Diagnostics.TraceListenerCollection [System]System.Diagnostics.TraceSource::get_Listeners()
        IL_0055:  ldstr      "gamedemo"
        IL_005a:  callvirt   instance class [System]System.Diagnostics.TraceListener [System]System.Diagnostics.TraceListenerCollection::get_Item(string)
        IL_005f:  callvirt   instance void [System]System.Diagnostics.TraceListener::Close()
        IL_0064:  nop
        IL_0065:  ldarg.0
        IL_0066:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
        IL_006b:  callvirt   instance class [System]System.Diagnostics.TraceListenerCollection [System]System.Diagnostics.TraceSource::get_Listeners()
        IL_0070:  ldstr      "gamedemo"
        IL_0075:  callvirt   instance void [System]System.Diagnostics.TraceListenerCollection::Remove(string)
        IL_007a:  nop
        IL_007b:  nop
        IL_007c:  endfinally
      }  // end handler
      IL_007d:  nop
      .try
      {
        IL_007e:  ldstr      "gamestats.log"
        IL_0083:  call       string[] [mscorlib]System.IO.File::ReadAllLines(string)
        IL_0088:  stloc.0
        IL_0089:  newobj     instance void Microsoft.Samples.SpaceInvaders.GameData::.ctor()
        IL_008e:  stloc.1
        IL_008f:  ldc.i4.0
        IL_0090:  stloc.2
        IL_0091:  ldloc.0
        IL_0092:  ldlen
        IL_0093:  conv.i4
        IL_0094:  ldc.i4.1
        IL_0095:  sub
        IL_0096:  stloc.3
        IL_0097:  br.s       IL_00d7

        IL_0099:  ldloc.0
        IL_009a:  ldloc.3
        IL_009b:  ldelem.ref
        IL_009c:  ldc.i4.1
        IL_009d:  newarr     [mscorlib]System.Char
        IL_00a2:  stloc.s    CS$0$0001
        IL_00a4:  ldloc.s    CS$0$0001
        IL_00a6:  ldc.i4.0
        IL_00a7:  ldc.i4.s   59
        IL_00a9:  stelem.i2
        IL_00aa:  ldloc.s    CS$0$0001
        IL_00ac:  ldc.i4.1
        IL_00ad:  callvirt   instance string[] [mscorlib]System.String::Split(char[],
                                                                              valuetype [mscorlib]System.StringSplitOptions)
        IL_00b2:  stloc.s    vals
        IL_00b4:  ldloc.s    vals
        IL_00b6:  ldc.i4.2
        IL_00b7:  ldelem.ref
        IL_00b8:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()
        IL_00bd:  call       int32 [mscorlib]System.Convert::ToInt32(string,
                                                                     class [mscorlib]System.IFormatProvider)
        IL_00c2:  ldc.i4.8
        IL_00c3:  ceq
        IL_00c5:  ldc.i4.0
        IL_00c6:  ceq
        IL_00c8:  stloc.s    CS$4$0002
        IL_00ca:  ldloc.s    CS$4$0002
        IL_00cc:  brtrue.s   IL_00d2

        IL_00ce:  ldloc.3
        IL_00cf:  stloc.2
        IL_00d0:  br.s       IL_00e4

        IL_00d2:  nop
        IL_00d3:  ldloc.3
        IL_00d4:  ldc.i4.1
        IL_00d5:  sub
        IL_00d6:  stloc.3
        IL_00d7:  ldloc.3
        IL_00d8:  ldc.i4.0
        IL_00d9:  clt
        IL_00db:  ldc.i4.0
        IL_00dc:  ceq
        IL_00de:  stloc.s    CS$4$0002
        IL_00e0:  ldloc.s    CS$4$0002
        IL_00e2:  brtrue.s   IL_0099

        IL_00e4:  ldloc.2
        IL_00e5:  stloc.3
        IL_00e6:  br.s       IL_0163

        IL_00e8:  ldloc.0
        IL_00e9:  ldloc.3
        IL_00ea:  ldelem.ref
        IL_00eb:  ldc.i4.1
        IL_00ec:  newarr     [mscorlib]System.Char
        IL_00f1:  stloc.s    CS$0$0001
        IL_00f3:  ldloc.s    CS$0$0001
        IL_00f5:  ldc.i4.0
        IL_00f6:  ldc.i4.s   59
        IL_00f8:  stelem.i2
        IL_00f9:  ldloc.s    CS$0$0001
        IL_00fb:  ldc.i4.1
        IL_00fc:  callvirt   instance string[] [mscorlib]System.String::Split(char[],
                                                                              valuetype [mscorlib]System.StringSplitOptions)
        IL_0101:  stloc.s    vals
        IL_0103:  ldloc.s    vals
        IL_0105:  ldc.i4.4
        IL_0106:  ldelem.ref
        IL_0107:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()
        IL_010c:  call       int64 [mscorlib]System.Convert::ToInt64(string,
                                                                     class [mscorlib]System.IFormatProvider)
        IL_0111:  stloc.s    itemKey
        IL_0113:  br.s       IL_0138

        IL_0115:  ldloc.1
        IL_0116:  callvirt   instance class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent> Microsoft.Samples.SpaceInvaders.GameData::get_Events()
        IL_011b:  ldloc.s    itemKey
        IL_011d:  callvirt   instance bool class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent>::ContainsKey(!0)
        IL_0122:  ldc.i4.0
        IL_0123:  ceq
        IL_0125:  stloc.s    CS$4$0002
        IL_0127:  ldloc.s    CS$4$0002
        IL_0129:  brtrue.s   IL_0135

        IL_012b:  ldloc.s    itemKey
        IL_012d:  ldc.i4.1
        IL_012e:  conv.i8
        IL_012f:  add
        IL_0130:  stloc.s    itemKey
        IL_0132:  nop
        IL_0133:  br.s       IL_0137

        IL_0135:  br.s       IL_013d

        IL_0137:  nop
        IL_0138:  ldc.i4.1
        IL_0139:  stloc.s    CS$4$0002
        IL_013b:  br.s       IL_0115

        IL_013d:  ldloc.1
        IL_013e:  callvirt   instance class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent> Microsoft.Samples.SpaceInvaders.GameData::get_Events()
        IL_0143:  ldloc.s    itemKey
        IL_0145:  ldloc.s    vals
        IL_0147:  ldc.i4.1
        IL_0148:  ldelem.ref
        IL_0149:  ldloc.s    vals
        IL_014b:  ldc.i4.2
        IL_014c:  ldelem.ref
        IL_014d:  ldloc.s    vals
        IL_014f:  ldc.i4.3
        IL_0150:  ldelem.ref
        IL_0151:  ldloc.s    itemKey
        IL_0153:  newobj     instance void Microsoft.Samples.SpaceInvaders.GameEvent::.ctor(string,
                                                                                            string,
                                                                                            string,
                                                                                            int64)
        IL_0158:  callvirt   instance void class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent>::Add(!0,
                                                                                                                                                               !1)
        IL_015d:  nop
        IL_015e:  nop
        IL_015f:  ldloc.3
        IL_0160:  ldc.i4.1
        IL_0161:  add
        IL_0162:  stloc.3
        IL_0163:  ldloc.3
        IL_0164:  ldloc.0
        IL_0165:  ldlen
        IL_0166:  conv.i4
        IL_0167:  clt
        IL_0169:  stloc.s    CS$4$0002
        IL_016b:  ldloc.s    CS$4$0002
        IL_016d:  brtrue     IL_00e8

        IL_0172:  ldc.i4.0
        IL_0173:  stloc.s    totalShipShotsFired
        IL_0175:  ldc.i4.0
        IL_0176:  stloc.s    totalShipShotsHitInvaders
        IL_0178:  ldc.i4.0
        IL_0179:  stloc.s    totalShipShotsHitShield
        IL_017b:  ldc.i4.0
        IL_017c:  stloc.s    totalShipMoves
        IL_017e:  ldloc.1
        IL_017f:  callvirt   instance class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent> Microsoft.Samples.SpaceInvaders.GameData::get_Events()
        IL_0184:  callvirt   instance class [mscorlib]System.Collections.Generic.'IList`1'<!1> class [System]System.Collections.Generic.'SortedList`2'<int64,class Microsoft.Samples.SpaceInvaders.GameEvent>::get_Values()
        IL_0189:  callvirt   instance class [mscorlib]System.Collections.Generic.'IEnumerator`1'<!0> class [mscorlib]System.Collections.Generic.'IEnumerable`1'<class Microsoft.Samples.SpaceInvaders.GameEvent>::GetEnumerator()
        IL_018e:  stloc.s    CS$5$0003
        .try
        {
          IL_0190:  br.s       IL_0210

          IL_0192:  ldloc.s    CS$5$0003
          IL_0194:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'IEnumerator`1'<class Microsoft.Samples.SpaceInvaders.GameEvent>::get_Current()
          IL_0199:  stloc.s    ge
          IL_019b:  ldloc.s    ge
          IL_019d:  callvirt   instance valuetype Microsoft.Samples.SpaceInvaders.GameDetail Microsoft.Samples.SpaceInvaders.GameEvent::get_GameDetail()
          IL_01a2:  ldc.i4.s   11
          IL_01a4:  ceq
          IL_01a6:  ldc.i4.0
          IL_01a7:  ceq
          IL_01a9:  stloc.s    CS$4$0002
          IL_01ab:  ldloc.s    CS$4$0002
          IL_01ad:  brtrue.s   IL_01b5

          IL_01af:  ldloc.s    totalShipShotsFired
          IL_01b1:  ldc.i4.1
          IL_01b2:  add
          IL_01b3:  stloc.s    totalShipShotsFired
          IL_01b5:  ldloc.s    ge
          IL_01b7:  callvirt   instance valuetype Microsoft.Samples.SpaceInvaders.GameDetail Microsoft.Samples.SpaceInvaders.GameEvent::get_GameDetail()
          IL_01bc:  ldc.i4.1
          IL_01bd:  ceq
          IL_01bf:  ldc.i4.0
          IL_01c0:  ceq
          IL_01c2:  stloc.s    CS$4$0002
          IL_01c4:  ldloc.s    CS$4$0002
          IL_01c6:  brtrue.s   IL_01ce

          IL_01c8:  ldloc.s    totalShipShotsHitInvaders
          IL_01ca:  ldc.i4.1
          IL_01cb:  add
          IL_01cc:  stloc.s    totalShipShotsHitInvaders
          IL_01ce:  ldloc.s    ge
          IL_01d0:  callvirt   instance valuetype Microsoft.Samples.SpaceInvaders.GameDetail Microsoft.Samples.SpaceInvaders.GameEvent::get_GameDetail()
          IL_01d5:  ldc.i4.2
          IL_01d6:  ceq
          IL_01d8:  ldc.i4.0
          IL_01d9:  ceq
          IL_01db:  stloc.s    CS$4$0002
          IL_01dd:  ldloc.s    CS$4$0002
          IL_01df:  brtrue.s   IL_01e7

          IL_01e1:  ldloc.s    totalShipShotsHitShield
          IL_01e3:  ldc.i4.1
          IL_01e4:  add
          IL_01e5:  stloc.s    totalShipShotsHitShield
          IL_01e7:  ldloc.s    ge
          IL_01e9:  callvirt   instance valuetype Microsoft.Samples.SpaceInvaders.GameDetail Microsoft.Samples.SpaceInvaders.GameEvent::get_GameDetail()
          IL_01ee:  ldc.i4.s   9
          IL_01f0:  beq.s      IL_0202

          IL_01f2:  ldloc.s    ge
          IL_01f4:  callvirt   instance valuetype Microsoft.Samples.SpaceInvaders.GameDetail Microsoft.Samples.SpaceInvaders.GameEvent::get_GameDetail()
          IL_01f9:  ldc.i4.s   10
          IL_01fb:  ceq
          IL_01fd:  ldc.i4.0
          IL_01fe:  ceq
          IL_0200:  br.s       IL_0203

          IL_0202:  ldc.i4.0
          IL_0203:  stloc.s    CS$4$0002
          IL_0205:  ldloc.s    CS$4$0002
          IL_0207:  brtrue.s   IL_020f

          IL_0209:  ldloc.s    totalShipMoves
          IL_020b:  ldc.i4.1
          IL_020c:  add
          IL_020d:  stloc.s    totalShipMoves
          IL_020f:  nop
          IL_0210:  ldloc.s    CS$5$0003
          IL_0212:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
          IL_0217:  stloc.s    CS$4$0002
          IL_0219:  ldloc.s    CS$4$0002
          IL_021b:  brtrue     IL_0192

          IL_0220:  leave.s    IL_0236

        }  // end .try
        finally
        {
          IL_0222:  ldloc.s    CS$5$0003
          IL_0224:  ldnull
          IL_0225:  ceq
          IL_0227:  stloc.s    CS$4$0002
          IL_0229:  ldloc.s    CS$4$0002
          IL_022b:  brtrue.s   IL_0235

          IL_022d:  ldloc.s    CS$5$0003
          IL_022f:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
          IL_0234:  nop
          IL_0235:  endfinally
        }  // end handler
        IL_0236:  nop
        IL_0237:  ldarg.0
        IL_0238:  dup
        IL_0239:  stloc.s    CS$2$0004
        IL_023b:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
        IL_0240:  nop
        .try
        {
          IL_0241:  ldc.i4.s   10
          IL_0243:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
          IL_0248:  ldc.i4.s   30
          IL_024a:  ldc.i4.s   24
          IL_024c:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                                int32)
          IL_0251:  nop
          IL_0252:  ldstr      "Game  Statistics"
          IL_0257:  call       void [mscorlib]System.Console::Write(string)
          IL_025c:  nop
          IL_025d:  ldc.i4.s   12
          IL_025f:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
          IL_0264:  ldc.i4.s   17
          IL_0266:  ldc.i4.s   25
          IL_0268:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                                int32)
          IL_026d:  nop
          IL_026e:  ldstr      "------------------------------------------"
          IL_0273:  call       void [mscorlib]System.Console::Write(string)
          IL_0278:  nop
          IL_0279:  ldc.i4.s   17
          IL_027b:  ldc.i4.s   26
          IL_027d:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                                int32)
          IL_0282:  nop
          IL_0283:  ldstr      "-                                        -"
          IL_0288:  call       void [mscorlib]System.Console::Write(string)
          IL_028d:  nop
          IL_028e:  ldc.i4.s   17
          IL_0290:  ldc.i4.s   27
          IL_0292:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                                int32)
          IL_0297:  nop
          IL_0298:  ldstr      "-                                        -"
          IL_029d:  call       void [mscorlib]System.Console::Write(string)
          IL_02a2:  nop
          IL_02a3:  ldc.i4.s   17
          IL_02a5:  ldc.i4.s   28
          IL_02a7:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                                int32)
          IL_02ac:  nop
          IL_02ad:  ldstr      "-                                        -"
          IL_02b2:  call       void [mscorlib]System.Console::Write(string)
          IL_02b7:  nop
          IL_02b8:  ldc.i4.s   17
          IL_02ba:  ldc.i4.s   29
          IL_02bc:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                                int32)
          IL_02c1:  nop
          IL_02c2:  ldstr      "-                                        -"
          IL_02c7:  call       void [mscorlib]System.Console::Write(string)
          IL_02cc:  nop
          IL_02cd:  ldc.i4.s   17
          IL_02cf:  ldc.i4.s   30
          IL_02d1:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                                int32)
          IL_02d6:  nop
          IL_02d7:  ldstr      "-                                        -"
          IL_02dc:  call       void [mscorlib]System.Console::Write(string)
          IL_02e1:  nop
          IL_02e2:  ldc.i4.s   17
          IL_02e4:  ldc.i4.s   31
          IL_02e6:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                                int32)
          IL_02eb:  nop
          IL_02ec:  ldstr      "-                                        -"
          IL_02f1:  call       void [mscorlib]System.Console::Write(string)
          IL_02f6:  nop
          IL_02f7:  ldc.i4.s   17
          IL_02f9:  ldc.i4.s   32
          IL_02fb:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                                int32)
          IL_0300:  nop
          IL_0301:  ldstr      "------------------------------------------"
          IL_0306:  call       void [mscorlib]System.Console::Write(string)
          IL_030b:  nop
          IL_030c:  ldc.i4.s   11
          IL_030e:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
          IL_0313:  ldc.i4.s   19
          IL_0315:  ldc.i4.s   26
          IL_0317:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                                int32)
          IL_031c:  nop
          IL_031d:  ldstr      "{0,-30}{1}"
          IL_0322:  ldstr      "Total Ship Moves"
          IL_0327:  ldloc.s    totalShipMoves
          IL_0329:  box        [mscorlib]System.Int32
          IL_032e:  call       void [mscorlib]System.Console::Write(string,
                                                                    object,
                                                                    object)
          IL_0333:  nop
          IL_0334:  ldc.i4.s   19
          IL_0336:  ldc.i4.s   28
          IL_0338:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                                int32)
          IL_033d:  nop
          IL_033e:  ldstr      "{0,-30}{1}"
          IL_0343:  ldstr      "Total Shots Fired"
          IL_0348:  ldloc.s    totalShipShotsFired
          IL_034a:  box        [mscorlib]System.Int32
          IL_034f:  call       void [mscorlib]System.Console::Write(string,
                                                                    object,
                                                                    object)
          IL_0354:  nop
          IL_0355:  ldc.i4.s   19
          IL_0357:  ldc.i4.s   29
          IL_0359:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                                int32)
          IL_035e:  nop
          IL_035f:  ldstr      "{0,-30}{1}"
          IL_0364:  ldstr      "Invaders Destroyed"
          IL_0369:  ldloc.s    totalShipShotsHitInvaders
          IL_036b:  box        [mscorlib]System.Int32
          IL_0370:  call       void [mscorlib]System.Console::Write(string,
                                                                    object,
                                                                    object)
          IL_0375:  nop
          IL_0376:  ldc.i4.s   19
          IL_0378:  ldc.i4.s   30
          IL_037a:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                                int32)
          IL_037f:  nop
          IL_0380:  ldstr      "{0,-30}{1:p}"
          IL_0385:  ldstr      "Accuracy"
          IL_038a:  ldloc.s    totalShipShotsHitInvaders
          IL_038c:  box        [mscorlib]System.Int32
          IL_0391:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()
          IL_0396:  call       float64 [mscorlib]System.Convert::ToDouble(object,
                                                                          class [mscorlib]System.IFormatProvider)
          IL_039b:  ldloc.s    totalShipShotsFired
          IL_039d:  box        [mscorlib]System.Int32
          IL_03a2:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()
          IL_03a7:  call       float64 [mscorlib]System.Convert::ToDouble(object,
                                                                          class [mscorlib]System.IFormatProvider)
          IL_03ac:  div
          IL_03ad:  box        [mscorlib]System.Double
          IL_03b2:  call       void [mscorlib]System.Console::Write(string,
                                                                    object,
                                                                    object)
          IL_03b7:  nop
          IL_03b8:  ldc.i4.s   19
          IL_03ba:  ldc.i4.s   31
          IL_03bc:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                                int32)
          IL_03c1:  nop
          IL_03c2:  ldstr      "{0,-30}{1:0.00}"
          IL_03c7:  ldstr      "Average score per alien"
          IL_03cc:  ldarg.0
          IL_03cd:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::score
          IL_03d2:  box        [mscorlib]System.Int32
          IL_03d7:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()
          IL_03dc:  call       float64 [mscorlib]System.Convert::ToDouble(object,
                                                                          class [mscorlib]System.IFormatProvider)
          IL_03e1:  ldloc.s    totalShipShotsHitInvaders
          IL_03e3:  box        [mscorlib]System.Int32
          IL_03e8:  call       class [mscorlib]System.Globalization.CultureInfo [mscorlib]System.Globalization.CultureInfo::get_InvariantCulture()
          IL_03ed:  call       float64 [mscorlib]System.Convert::ToDouble(object,
                                                                          class [mscorlib]System.IFormatProvider)
          IL_03f2:  div
          IL_03f3:  box        [mscorlib]System.Double
          IL_03f8:  call       void [mscorlib]System.Console::Write(string,
                                                                    object,
                                                                    object)
          IL_03fd:  nop
          IL_03fe:  nop
          IL_03ff:  leave.s    IL_040a

        }  // end .try
        finally
        {
          IL_0401:  ldloc.s    CS$2$0004
          IL_0403:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
          IL_0408:  nop
          IL_0409:  endfinally
        }  // end handler
        IL_040a:  nop
        IL_040b:  nop
        IL_040c:  leave.s    IL_0412

      }  // end .try
      catch [mscorlib]System.IndexOutOfRangeException 
      {
        IL_040e:  pop
        IL_040f:  nop
        IL_0410:  leave.s    IL_0412

      }  // end handler
      IL_0412:  nop
      IL_0413:  nop
      IL_0414:  leave.s    IL_041f

    }  // end .try
    finally
    {
      IL_0416:  ldloc.s    CS$2$0000
      IL_0418:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_041d:  nop
      IL_041e:  endfinally
    }  // end handler
    IL_041f:  nop
    IL_0420:  ret
  } // end of method Invaders::DisplayGameStatistics

  .method private hidebysig instance void 
          OnBulletTimedEvent(object source,
                             class [System]System.Timers.ElapsedEventArgs e) cil managed
  {
    // Code size       90 (0x5a)
    .maxstack  2
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0000,
             [1] bool CS$4$0001)
    IL_0000:  ldarg.0
    IL_0001:  dup
    IL_0002:  stloc.0
    IL_0003:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0008:  nop
    .try
    {
      IL_0009:  ldarg.0
      IL_000a:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::movesInvalid
      IL_000f:  stloc.1
      IL_0010:  ldloc.1
      IL_0011:  brtrue.s   IL_004c

      IL_0013:  ldarg.0
      IL_0014:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liShipBullets
      IL_0019:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Count()
      IL_001e:  ldc.i4.0
      IL_001f:  ceq
      IL_0021:  ldc.i4.0
      IL_0022:  ceq
      IL_0024:  stloc.1
      IL_0025:  ldloc.1
      IL_0026:  brtrue.s   IL_0036

      IL_0028:  ldarg.0
      IL_0029:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::shipBulletTimer
      IL_002e:  ldc.i4.0
      IL_002f:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
      IL_0034:  leave.s    IL_0058

      IL_0036:  ldarg.0
      IL_0037:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ResolveBulletCollisions()
      IL_003c:  nop
      IL_003d:  ldarg.0
      IL_003e:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ResolveShieldCollisions()
      IL_0043:  nop
      IL_0044:  ldarg.0
      IL_0045:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::InvaderDestroyed()
      IL_004a:  nop
      IL_004b:  nop
      IL_004c:  nop
      IL_004d:  leave.s    IL_0057

    }  // end .try
    finally
    {
      IL_004f:  ldloc.0
      IL_0050:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0055:  nop
      IL_0056:  endfinally
    }  // end handler
    IL_0057:  nop
    IL_0058:  nop
    IL_0059:  ret
  } // end of method Invaders::OnBulletTimedEvent

  .method private hidebysig instance void 
          OnInvadersTimedEvent(object source,
                               class [System]System.Timers.ElapsedEventArgs e) cil managed
  {
    // Code size       189 (0xbd)
    .maxstack  2
    .locals init ([0] bool CS$4$0000,
             [1] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0001)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::invadersReset
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  brtrue     IL_00bc

    IL_000d:  ldarg.2
    IL_000e:  callvirt   instance valuetype [mscorlib]System.DateTime [System]System.Timers.ElapsedEventArgs::get_SignalTime()
    IL_0013:  ldarg.0
    IL_0014:  ldfld      valuetype [mscorlib]System.DateTime Microsoft.Samples.SpaceInvaders.Invaders::iterationStartTime
    IL_0019:  call       bool [mscorlib]System.DateTime::op_GreaterThanOrEqual(valuetype [mscorlib]System.DateTime,
                                                                               valuetype [mscorlib]System.DateTime)
    IL_001e:  ldc.i4.0
    IL_001f:  ceq
    IL_0021:  stloc.0
    IL_0022:  ldloc.0
    IL_0023:  brtrue     IL_00bb

    IL_0028:  ldarg.0
    IL_0029:  dup
    IL_002a:  stloc.1
    IL_002b:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0030:  nop
    .try
    {
      IL_0031:  ldarg.0
      IL_0032:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::movesInvalid
      IL_0037:  stloc.0
      IL_0038:  ldloc.0
      IL_0039:  brtrue.s   IL_00ae

      IL_003b:  ldarg.0
      IL_003c:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::_mute
      IL_0041:  stloc.0
      IL_0042:  ldloc.0
      IL_0043:  brtrue.s   IL_009f

      IL_0045:  ldarg.0
      IL_0046:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersBulletTimer
      IL_004b:  callvirt   instance float64 [System]System.Timers.Timer::get_Interval()
      IL_0050:  ldc.r8     90.
      IL_0059:  cgt.un
      IL_005b:  stloc.0
      IL_005c:  ldloc.0
      IL_005d:  brtrue.s   IL_0093

      IL_005f:  ldarg.0
      IL_0060:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersBulletTimer
      IL_0065:  callvirt   instance float64 [System]System.Timers.Timer::get_Interval()
      IL_006a:  ldc.r8     50.
      IL_0073:  cgt.un
      IL_0075:  stloc.0
      IL_0076:  ldloc.0
      IL_0077:  brtrue.s   IL_0085

      IL_0079:  ldc.i4.s   40
      IL_007b:  ldc.i4.5
      IL_007c:  call       void [mscorlib]System.Console::Beep(int32,
                                                               int32)
      IL_0081:  nop
      IL_0082:  nop
      IL_0083:  br.s       IL_0090

      IL_0085:  ldc.i4.s   40
      IL_0087:  ldc.i4.s   15
      IL_0089:  call       void [mscorlib]System.Console::Beep(int32,
                                                               int32)
      IL_008e:  nop
      IL_008f:  nop
      IL_0090:  nop
      IL_0091:  br.s       IL_009e

      IL_0093:  ldc.i4.s   40
      IL_0095:  ldc.i4.s   30
      IL_0097:  call       void [mscorlib]System.Console::Beep(int32,
                                                               int32)
      IL_009c:  nop
      IL_009d:  nop
      IL_009e:  nop
      IL_009f:  ldarg.0
      IL_00a0:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::RedrawInvaders()
      IL_00a5:  nop
      IL_00a6:  ldarg.0
      IL_00a7:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::InvaderDestroyed()
      IL_00ac:  nop
      IL_00ad:  nop
      IL_00ae:  nop
      IL_00af:  leave.s    IL_00b9

    }  // end .try
    finally
    {
      IL_00b1:  ldloc.1
      IL_00b2:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00b7:  nop
      IL_00b8:  endfinally
    }  // end handler
    IL_00b9:  nop
    IL_00ba:  nop
    IL_00bb:  nop
    IL_00bc:  ret
  } // end of method Invaders::OnInvadersTimedEvent

  .method private hidebysig instance void 
          OnShipDestroyed(object source,
                          class [System]System.Timers.ElapsedEventArgs e) cil managed
  {
    // Code size       447 (0x1bf)
    .maxstack  3
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0000,
             [1] bool CS$4$0001,
             [2] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0002)
    IL_0000:  ldarg.0
    IL_0001:  dup
    IL_0002:  stloc.0
    IL_0003:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0008:  nop
    .try
    {
      IL_0009:  ldarg.0
      IL_000a:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::shipExplosionState
      IL_000f:  ldc.i4.4
      IL_0010:  clt
      IL_0012:  ldc.i4.0
      IL_0013:  ceq
      IL_0015:  stloc.1
      IL_0016:  ldloc.1
      IL_0017:  brtrue     IL_010a

      IL_001c:  ldarg.0
      IL_001d:  dup
      IL_001e:  stloc.2
      IL_001f:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
      IL_0024:  nop
      .try
      {
        IL_0025:  ldarg.0
        IL_0026:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::_mute
        IL_002b:  stloc.1
        IL_002c:  ldloc.1
        IL_002d:  brtrue.s   IL_0058

        IL_002f:  ldc.i4.s   50
        IL_0031:  ldc.i4.s   30
        IL_0033:  call       void [mscorlib]System.Console::Beep(int32,
                                                                 int32)
        IL_0038:  nop
        IL_0039:  ldc.i4.s   46
        IL_003b:  ldc.i4.s   30
        IL_003d:  call       void [mscorlib]System.Console::Beep(int32,
                                                                 int32)
        IL_0042:  nop
        IL_0043:  ldc.i4.s   42
        IL_0045:  ldc.i4.s   30
        IL_0047:  call       void [mscorlib]System.Console::Beep(int32,
                                                                 int32)
        IL_004c:  nop
        IL_004d:  ldc.i4.s   46
        IL_004f:  ldc.i4.s   30
        IL_0051:  call       void [mscorlib]System.Console::Beep(int32,
                                                                 int32)
        IL_0056:  nop
        IL_0057:  nop
        IL_0058:  ldarg.0
        IL_0059:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
        IL_005e:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
        IL_0063:  ldarg.0
        IL_0064:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
        IL_0069:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
        IL_006e:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                              int32)
        IL_0073:  nop
        IL_0074:  ldarg.0
        IL_0075:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::shipExplosionState
        IL_007a:  ldc.i4.0
        IL_007b:  ceq
        IL_007d:  ldc.i4.0
        IL_007e:  ceq
        IL_0080:  stloc.1
        IL_0081:  ldloc.1
        IL_0082:  brtrue.s   IL_008c

        IL_0084:  ldc.i4.6
        IL_0085:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
        IL_008a:  br.s       IL_00d5

        IL_008c:  ldarg.0
        IL_008d:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::shipExplosionState
        IL_0092:  ldc.i4.1
        IL_0093:  ceq
        IL_0095:  ldc.i4.0
        IL_0096:  ceq
        IL_0098:  stloc.1
        IL_0099:  ldloc.1
        IL_009a:  brtrue.s   IL_00a5

        IL_009c:  ldc.i4.s   14
        IL_009e:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
        IL_00a3:  br.s       IL_00d5

        IL_00a5:  ldarg.0
        IL_00a6:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::shipExplosionState
        IL_00ab:  ldc.i4.2
        IL_00ac:  ceq
        IL_00ae:  ldc.i4.0
        IL_00af:  ceq
        IL_00b1:  stloc.1
        IL_00b2:  ldloc.1
        IL_00b3:  brtrue.s   IL_00be

        IL_00b5:  ldc.i4.s   10
        IL_00b7:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
        IL_00bc:  br.s       IL_00d5

        IL_00be:  ldarg.0
        IL_00bf:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::shipExplosionState
        IL_00c4:  ldc.i4.3
        IL_00c5:  ceq
        IL_00c7:  ldc.i4.0
        IL_00c8:  ceq
        IL_00ca:  stloc.1
        IL_00cb:  ldloc.1
        IL_00cc:  brtrue.s   IL_00d5

        IL_00ce:  ldc.i4.s   12
        IL_00d0:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
        IL_00d5:  ldstr      "{0}{0}{0}"
        IL_00da:  ldc.i4     0x263c
        IL_00df:  box        [mscorlib]System.Char
        IL_00e4:  call       void [mscorlib]System.Console::Write(string,
                                                                  object)
        IL_00e9:  nop
        IL_00ea:  nop
        IL_00eb:  leave.s    IL_00f5

      }  // end .try
      finally
      {
        IL_00ed:  ldloc.2
        IL_00ee:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
        IL_00f3:  nop
        IL_00f4:  endfinally
      }  // end handler
      IL_00f5:  nop
      IL_00f6:  ldarg.0
      IL_00f7:  dup
      IL_00f8:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::shipExplosionState
      IL_00fd:  ldc.i4.1
      IL_00fe:  add
      IL_00ff:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::shipExplosionState
      IL_0104:  nop
      IL_0105:  br         IL_01b1

      IL_010a:  ldarg.0
      IL_010b:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::shipCount
      IL_0110:  ldc.i4.0
      IL_0111:  ceq
      IL_0113:  ldc.i4.0
      IL_0114:  ceq
      IL_0116:  stloc.1
      IL_0117:  ldloc.1
      IL_0118:  brtrue.s   IL_0126

      IL_011a:  ldarg.0
      IL_011b:  ldc.i4.0
      IL_011c:  stfld      valuetype Microsoft.Samples.SpaceInvaders.GameState Microsoft.Samples.SpaceInvaders.Invaders::gameOver
      IL_0121:  leave      IL_01bd

      IL_0126:  ldarg.0
      IL_0127:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::shipDestroyedTimer
      IL_012c:  ldc.i4.0
      IL_012d:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
      IL_0132:  ldarg.0
      IL_0133:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
      IL_0138:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_013d:  ldarg.0
      IL_013e:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::currentShipPosition
      IL_0143:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_0148:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_014d:  nop
      IL_014e:  ldc.i4     0x5dc
      IL_0153:  call       void [mscorlib]System.Threading.Thread::Sleep(int32)
      IL_0158:  nop
      IL_0159:  ldstr      "   "
      IL_015e:  call       void [mscorlib]System.Console::Write(string)
      IL_0163:  nop
      IL_0164:  ldc.i4     0x5dc
      IL_0169:  call       void [mscorlib]System.Threading.Thread::Sleep(int32)
      IL_016e:  nop
      IL_016f:  ldarg.0
      IL_0170:  ldc.i4.0
      IL_0171:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::shipExplosionState
      IL_0176:  ldarg.0
      IL_0177:  ldc.i4.0
      IL_0178:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawShip(valuetype Microsoft.Samples.SpaceInvaders.ShipPosition)
      IL_017d:  nop
      IL_017e:  ldarg.0
      IL_017f:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawReserveShips()
      IL_0184:  nop
      IL_0185:  ldarg.0
      IL_0186:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersBulletTimer
      IL_018b:  ldc.i4.1
      IL_018c:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
      IL_0191:  ldarg.0
      IL_0192:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
      IL_0197:  ldc.i4.1
      IL_0198:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
      IL_019d:  ldarg.0
      IL_019e:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::shipBulletTimer
      IL_01a3:  ldc.i4.1
      IL_01a4:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
      IL_01a9:  ldarg.0
      IL_01aa:  ldc.i4.0
      IL_01ab:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::shipBeingDestroyed
      IL_01b0:  nop
      IL_01b1:  nop
      IL_01b2:  leave.s    IL_01bc

    }  // end .try
    finally
    {
      IL_01b4:  ldloc.0
      IL_01b5:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_01ba:  nop
      IL_01bb:  endfinally
    }  // end handler
    IL_01bc:  nop
    IL_01bd:  nop
    IL_01be:  ret
  } // end of method Invaders::OnShipDestroyed

  .method private hidebysig instance void 
          OnInvadersExplosion(object source,
                              class [System]System.Timers.ElapsedEventArgs e) cil managed
  {
    // Code size       211 (0xd3)
    .maxstack  6
    .locals init ([0] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0000,
             [1] bool CS$4$0001)
    IL_0000:  ldarg.0
    IL_0001:  dup
    IL_0002:  stloc.0
    IL_0003:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0008:  nop
    .try
    {
      IL_0009:  ldarg.0
      IL_000a:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::invaderExplosion
      IL_000f:  ldnull
      IL_0010:  ceq
      IL_0012:  stloc.1
      IL_0013:  ldloc.1
      IL_0014:  brtrue     IL_00c6

      IL_0019:  ldarg.0
      IL_001a:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::invaderExplosionState
      IL_001f:  ldc.i4.2
      IL_0020:  clt
      IL_0022:  ldc.i4.0
      IL_0023:  ceq
      IL_0025:  stloc.1
      IL_0026:  ldloc.1
      IL_0027:  brtrue.s   IL_008a

      IL_0029:  ldarg.0
      IL_002a:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::invaderExplosion
      IL_002f:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_0034:  ldarg.0
      IL_0035:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::invaderExplosion
      IL_003a:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_003f:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_0044:  nop
      IL_0045:  ldarg.0
      IL_0046:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::invaderExplosionState
      IL_004b:  ldc.i4.0
      IL_004c:  ceq
      IL_004e:  ldc.i4.0
      IL_004f:  ceq
      IL_0051:  stloc.1
      IL_0052:  ldloc.1
      IL_0053:  brtrue.s   IL_005d

      IL_0055:  ldc.i4.6
      IL_0056:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
      IL_005b:  br.s       IL_0064

      IL_005d:  ldc.i4.s   14
      IL_005f:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
      IL_0064:  ldstr      "{0}{0}{0}"
      IL_0069:  ldc.i4     0x263c
      IL_006e:  box        [mscorlib]System.Char
      IL_0073:  call       void [mscorlib]System.Console::Write(string,
                                                                object)
      IL_0078:  nop
      IL_0079:  ldarg.0
      IL_007a:  dup
      IL_007b:  ldfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::invaderExplosionState
      IL_0080:  ldc.i4.1
      IL_0081:  add
      IL_0082:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::invaderExplosionState
      IL_0087:  nop
      IL_0088:  br.s       IL_00c5

      IL_008a:  ldarg.0
      IL_008b:  ldc.i4.0
      IL_008c:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::invaderExplosionState
      IL_0091:  ldc.i4.0
      IL_0092:  ldc.i4.0
      IL_0093:  ldc.i4.3
      IL_0094:  ldc.i4.1
      IL_0095:  ldarg.0
      IL_0096:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::invaderExplosion
      IL_009b:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_00a0:  ldarg.0
      IL_00a1:  ldfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::invaderExplosion
      IL_00a6:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_00ab:  call       void [mscorlib]System.Console::MoveBufferArea(int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32)
      IL_00b0:  nop
      IL_00b1:  ldarg.0
      IL_00b2:  ldnull
      IL_00b3:  stfld      class Microsoft.Samples.SpaceInvaders.ItemPosition Microsoft.Samples.SpaceInvaders.Invaders::invaderExplosion
      IL_00b8:  ldarg.0
      IL_00b9:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::explosionTimer
      IL_00be:  ldc.i4.0
      IL_00bf:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
      IL_00c4:  nop
      IL_00c5:  nop
      IL_00c6:  nop
      IL_00c7:  leave.s    IL_00d1

    }  // end .try
    finally
    {
      IL_00c9:  ldloc.0
      IL_00ca:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00cf:  nop
      IL_00d0:  endfinally
    }  // end handler
    IL_00d1:  nop
    IL_00d2:  ret
  } // end of method Invaders::OnInvadersExplosion

  .method private hidebysig instance void 
          OnInvadersBulletTimedEvent(object source,
                                     class [System]System.Timers.ElapsedEventArgs e) cil managed
  {
    // Code size       402 (0x192)
    .maxstack  7
    .locals init ([0] int32 i,
             [1] bool CS$4$0000,
             [2] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0001)
    IL_0000:  ldarg.2
    IL_0001:  callvirt   instance valuetype [mscorlib]System.DateTime [System]System.Timers.ElapsedEventArgs::get_SignalTime()
    IL_0006:  ldarg.0
    IL_0007:  ldfld      valuetype [mscorlib]System.DateTime Microsoft.Samples.SpaceInvaders.Invaders::iterationStartTime
    IL_000c:  call       bool [mscorlib]System.DateTime::op_GreaterThanOrEqual(valuetype [mscorlib]System.DateTime,
                                                                               valuetype [mscorlib]System.DateTime)
    IL_0011:  ldc.i4.0
    IL_0012:  ceq
    IL_0014:  stloc.1
    IL_0015:  ldloc.1
    IL_0016:  brtrue     IL_0191

    IL_001b:  ldarg.0
    IL_001c:  dup
    IL_001d:  stloc.2
    IL_001e:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_0023:  nop
    .try
    {
      IL_0024:  ldarg.0
      IL_0025:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::movesInvalid
      IL_002a:  stloc.1
      IL_002b:  ldloc.1
      IL_002c:  brtrue     IL_0184

      IL_0031:  ldarg.0
      IL_0032:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ResolveBulletCollisions()
      IL_0037:  nop
      IL_0038:  ldarg.0
      IL_0039:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ResolveShieldCollisions()
      IL_003e:  nop
      IL_003f:  ldc.i4.0
      IL_0040:  stloc.0
      IL_0041:  br         IL_0155

      IL_0046:  ldarg.0
      IL_0047:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
      IL_004c:  ldloc.0
      IL_004d:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_0052:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_0057:  call       int32 [mscorlib]System.Console::get_WindowHeight()
      IL_005c:  ldc.i4.2
      IL_005d:  sub
      IL_005e:  clt
      IL_0060:  stloc.1
      IL_0061:  ldloc.1
      IL_0062:  brtrue.s   IL_00c5

      IL_0064:  ldarg.0
      IL_0065:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
      IL_006a:  stloc.1
      IL_006b:  ldloc.1
      IL_006c:  brtrue.s   IL_0082

      IL_006e:  ldarg.0
      IL_006f:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
      IL_0074:  ldc.i4.8
      IL_0075:  ldc.i4.3
      IL_0076:  ldstr      "Invader bullet missed"
      IL_007b:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                            int32,
                                                                                            string)
      IL_0080:  nop
      IL_0081:  nop
      IL_0082:  ldc.i4.0
      IL_0083:  ldc.i4.0
      IL_0084:  ldc.i4.1
      IL_0085:  ldc.i4.1
      IL_0086:  ldarg.0
      IL_0087:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
      IL_008c:  ldloc.0
      IL_008d:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_0092:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_0097:  ldarg.0
      IL_0098:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
      IL_009d:  ldloc.0
      IL_009e:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_00a3:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_00a8:  call       void [mscorlib]System.Console::MoveBufferArea(int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32)
      IL_00ad:  nop
      IL_00ae:  ldarg.0
      IL_00af:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
      IL_00b4:  ldloc.0
      IL_00b5:  callvirt   instance void class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::RemoveAt(int32)
      IL_00ba:  nop
      IL_00bb:  ldloc.0
      IL_00bc:  ldc.i4.1
      IL_00bd:  sub
      IL_00be:  stloc.0
      IL_00bf:  nop
      IL_00c0:  br         IL_0150

      IL_00c5:  ldc.i4.0
      IL_00c6:  ldc.i4.0
      IL_00c7:  ldc.i4.1
      IL_00c8:  ldc.i4.1
      IL_00c9:  ldarg.0
      IL_00ca:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
      IL_00cf:  ldloc.0
      IL_00d0:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_00d5:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_00da:  ldarg.0
      IL_00db:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
      IL_00e0:  ldloc.0
      IL_00e1:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_00e6:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_00eb:  call       void [mscorlib]System.Console::MoveBufferArea(int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32,
                                                                         int32)
      IL_00f0:  nop
      IL_00f1:  ldarg.0
      IL_00f2:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
      IL_00f7:  ldloc.0
      IL_00f8:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_00fd:  ldarg.0
      IL_00fe:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
      IL_0103:  ldloc.0
      IL_0104:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_0109:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_010e:  ldc.i4.1
      IL_010f:  add
      IL_0110:  callvirt   instance void Microsoft.Samples.SpaceInvaders.ItemPosition::set_Top(int32)
      IL_0115:  ldarg.0
      IL_0116:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
      IL_011b:  ldloc.0
      IL_011c:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_0121:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Left()
      IL_0126:  ldarg.0
      IL_0127:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
      IL_012c:  ldloc.0
      IL_012d:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Item(int32)
      IL_0132:  callvirt   instance int32 Microsoft.Samples.SpaceInvaders.ItemPosition::get_Top()
      IL_0137:  call       void [mscorlib]System.Console::SetCursorPosition(int32,
                                                                            int32)
      IL_013c:  nop
      IL_013d:  ldc.i4.s   15
      IL_013f:  call       void [mscorlib]System.Console::set_ForegroundColor(valuetype [mscorlib]System.ConsoleColor)
      IL_0144:  ldc.i4     0x2551
      IL_0149:  call       void [mscorlib]System.Console::Write(char)
      IL_014e:  nop
      IL_014f:  nop
      IL_0150:  nop
      IL_0151:  ldloc.0
      IL_0152:  ldc.i4.1
      IL_0153:  add
      IL_0154:  stloc.0
      IL_0155:  ldloc.0
      IL_0156:  ldarg.0
      IL_0157:  ldfld      class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition> Microsoft.Samples.SpaceInvaders.Invaders::liInvaderBullets
      IL_015c:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.'List`1'<class Microsoft.Samples.SpaceInvaders.ItemPosition>::get_Count()
      IL_0161:  clt
      IL_0163:  stloc.1
      IL_0164:  ldloc.1
      IL_0165:  brtrue     IL_0046

      IL_016a:  ldarg.0
      IL_016b:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
      IL_0170:  stloc.1
      IL_0171:  ldloc.1
      IL_0172:  brtrue.s   IL_017c

      IL_0174:  ldarg.0
      IL_0175:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::GenerateInvaderBullet()
      IL_017a:  nop
      IL_017b:  nop
      IL_017c:  ldarg.0
      IL_017d:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ResolveShipDestroyed()
      IL_0182:  nop
      IL_0183:  nop
      IL_0184:  nop
      IL_0185:  leave.s    IL_018f

    }  // end .try
    finally
    {
      IL_0187:  ldloc.2
      IL_0188:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_018d:  nop
      IL_018e:  endfinally
    }  // end handler
    IL_018f:  nop
    IL_0190:  nop
    IL_0191:  ret
  } // end of method Invaders::OnInvadersBulletTimedEvent

  .method private hidebysig instance void 
          OnHighScoreTimedEvent(object source,
                                class [System]System.Timers.ElapsedEventArgs e) cil managed
  {
    // Code size       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::StartScreen()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::HighScoreTimer
    IL_000d:  ldc.i4.0
    IL_000e:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_0013:  ret
  } // end of method Invaders::OnHighScoreTimedEvent

  .method private hidebysig instance void 
          OnSerialLcdClearedEvent(object source,
                                  class [System]System.Timers.ElapsedEventArgs e) cil managed
  {
    // Code size       47 (0x2f)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
    IL_0006:  ldstr      ""
    IL_000b:  callvirt   instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::WriteLine1(string)
    IL_0010:  pop
    IL_0011:  ldarg.0
    IL_0012:  ldfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
    IL_0017:  ldstr      ""
    IL_001c:  callvirt   instance bool Microsoft.Samples.SpaceInvaders.SerialLcd::WriteLine2(string)
    IL_0021:  pop
    IL_0022:  ldarg.0
    IL_0023:  ldfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::clearLcdScreen
    IL_0028:  ldc.i4.0
    IL_0029:  callvirt   instance void [System]System.Timers.Timer::set_Enabled(bool)
    IL_002e:  ret
  } // end of method Invaders::OnSerialLcdClearedEvent

  .method private hidebysig instance void 
          OnSerialKeysEvent(object source,
                            class [System]System.Timers.ElapsedEventArgs e) cil managed
  {
    // Code size       281 (0x119)
    .maxstack  4
    .locals init ([0] valuetype Microsoft.Samples.SpaceInvaders.LcdKey CS$4$0000,
             [1] valuetype Microsoft.Samples.SpaceInvaders.LcdKey CS$0$0001,
             [2] bool CS$4$0002,
             [3] class Microsoft.Samples.SpaceInvaders.Invaders CS$2$0003)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
    IL_0006:  callvirt   instance valuetype Microsoft.Samples.SpaceInvaders.LcdKey Microsoft.Samples.SpaceInvaders.SerialLcd::get_Key()
    IL_000b:  stloc.0
    IL_000c:  ldloc.0
    IL_000d:  stloc.1
    IL_000e:  ldloc.1
    IL_000f:  ldc.i4.1
    IL_0010:  sub
    IL_0011:  switch     ( 
                          IL_0033,
                          IL_0038,
                          IL_003d,
                          IL_006a,
                          IL_0097,
                          IL_00cc)
    IL_002e:  br         IL_0116

    IL_0033:  br         IL_0118

    IL_0038:  br         IL_0118

    IL_003d:  ldarg.0
    IL_003e:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::shipBeingDestroyed
    IL_0043:  stloc.2
    IL_0044:  ldloc.2
    IL_0045:  brtrue.s   IL_0065

    IL_0047:  ldarg.0
    IL_0048:  dup
    IL_0049:  stloc.3
    IL_004a:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_004f:  nop
    .try
    {
      IL_0050:  ldarg.0
      IL_0051:  ldc.i4.1
      IL_0052:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawShip(valuetype Microsoft.Samples.SpaceInvaders.ShipPosition)
      IL_0057:  nop
      IL_0058:  nop
      IL_0059:  leave.s    IL_0063

    }  // end .try
    finally
    {
      IL_005b:  ldloc.3
      IL_005c:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_0061:  nop
      IL_0062:  endfinally
    }  // end handler
    IL_0063:  nop
    IL_0064:  nop
    IL_0065:  br         IL_0118

    IL_006a:  ldarg.0
    IL_006b:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::shipBeingDestroyed
    IL_0070:  stloc.2
    IL_0071:  ldloc.2
    IL_0072:  brtrue.s   IL_0092

    IL_0074:  ldarg.0
    IL_0075:  dup
    IL_0076:  stloc.3
    IL_0077:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_007c:  nop
    .try
    {
      IL_007d:  ldarg.0
      IL_007e:  ldc.i4.2
      IL_007f:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DrawShip(valuetype Microsoft.Samples.SpaceInvaders.ShipPosition)
      IL_0084:  nop
      IL_0085:  nop
      IL_0086:  leave.s    IL_0090

    }  // end .try
    finally
    {
      IL_0088:  ldloc.3
      IL_0089:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_008e:  nop
      IL_008f:  endfinally
    }  // end handler
    IL_0090:  nop
    IL_0091:  nop
    IL_0092:  br         IL_0118

    IL_0097:  ldarg.0
    IL_0098:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::shipBeingDestroyed
    IL_009d:  stloc.2
    IL_009e:  ldloc.2
    IL_009f:  brtrue.s   IL_00be

    IL_00a1:  ldarg.0
    IL_00a2:  dup
    IL_00a3:  stloc.3
    IL_00a4:  call       void [mscorlib]System.Threading.Monitor::Enter(object)
    IL_00a9:  nop
    .try
    {
      IL_00aa:  ldarg.0
      IL_00ab:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ShootBullet()
      IL_00b0:  nop
      IL_00b1:  nop
      IL_00b2:  leave.s    IL_00bc

    }  // end .try
    finally
    {
      IL_00b4:  ldloc.3
      IL_00b5:  call       void [mscorlib]System.Threading.Monitor::Exit(object)
      IL_00ba:  nop
      IL_00bb:  endfinally
    }  // end handler
    IL_00bc:  nop
    IL_00bd:  nop
    IL_00be:  ldarg.0
    IL_00bf:  ldfld      class Microsoft.Samples.SpaceInvaders.SerialLcd Microsoft.Samples.SpaceInvaders.Invaders::lcd
    IL_00c4:  ldc.i4.0
    IL_00c5:  callvirt   instance void Microsoft.Samples.SpaceInvaders.SerialLcd::set_Key(valuetype Microsoft.Samples.SpaceInvaders.LcdKey)
    IL_00ca:  br.s       IL_0118

    IL_00cc:  call       void [mscorlib]System.Console::Clear()
    IL_00d1:  nop
    IL_00d2:  ldarg.0
    IL_00d3:  ldc.i4.0
    IL_00d4:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::DisableTimers(bool)
    IL_00d9:  nop
    IL_00da:  ldarg.0
    IL_00db:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::ClearLists()
    IL_00e0:  nop
    IL_00e1:  ldarg.0
    IL_00e2:  ldfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
    IL_00e7:  stloc.2
    IL_00e8:  ldloc.2
    IL_00e9:  brtrue.s   IL_010d

    IL_00eb:  ldarg.0
    IL_00ec:  ldfld      class [System]System.Diagnostics.TraceSource Microsoft.Samples.SpaceInvaders.Invaders::ts
    IL_00f1:  ldc.i4.8
    IL_00f2:  ldc.i4.s   14
    IL_00f4:  ldstr      "Game Ended"
    IL_00f9:  callvirt   instance void [System]System.Diagnostics.TraceSource::TraceEvent(valuetype [System]System.Diagnostics.TraceEventType,
                                                                                          int32,
                                                                                          string)
    IL_00fe:  nop
    IL_00ff:  ldarg.0
    IL_0100:  ldstr      "Game Ended"
    IL_0105:  ldnull
    IL_0106:  call       instance void Microsoft.Samples.SpaceInvaders.Invaders::WriteLcdLine(string,
                                                                                              string)
    IL_010b:  nop
    IL_010c:  nop
    IL_010d:  ldc.i4.0
    IL_010e:  call       void [mscorlib]System.Environment::Exit(int32)
    IL_0113:  nop
    IL_0114:  br.s       IL_0118

    IL_0116:  br.s       IL_0118

    IL_0118:  ret
  } // end of method Invaders::OnSerialKeysEvent

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       243 (0xf3)
    .maxstack  3
    IL_0000:  ldarg.0
    IL_0001:  ldc.r8     60.
    IL_000a:  newobj     instance void [System]System.Timers.Timer::.ctor(float64)
    IL_000f:  stfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::getSerialKeys
    IL_0014:  ldarg.0
    IL_0015:  ldc.r8     1500.
    IL_001e:  newobj     instance void [System]System.Timers.Timer::.ctor(float64)
    IL_0023:  stfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::clearLcdScreen
    IL_0028:  ldarg.0
    IL_0029:  ldc.r8     70.
    IL_0032:  newobj     instance void [System]System.Timers.Timer::.ctor(float64)
    IL_0037:  stfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::shipBulletTimer
    IL_003c:  ldarg.0
    IL_003d:  ldc.r8     14000.
    IL_0046:  newobj     instance void [System]System.Timers.Timer::.ctor(float64)
    IL_004b:  stfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::HighScoreTimer
    IL_0050:  ldarg.0
    IL_0051:  ldc.r8     250.
    IL_005a:  newobj     instance void [System]System.Timers.Timer::.ctor(float64)
    IL_005f:  stfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::shipDestroyedTimer
    IL_0064:  ldarg.0
    IL_0065:  ldc.r8     35.
    IL_006e:  newobj     instance void [System]System.Timers.Timer::.ctor(float64)
    IL_0073:  stfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::explosionTimer
    IL_0078:  ldarg.0
    IL_0079:  newobj     instance void [System]System.Timers.Timer::.ctor()
    IL_007e:  stfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersTimer
    IL_0083:  ldarg.0
    IL_0084:  ldc.r8     90.
    IL_008d:  newobj     instance void [System]System.Timers.Timer::.ctor(float64)
    IL_0092:  stfld      class [System]System.Timers.Timer Microsoft.Samples.SpaceInvaders.Invaders::invadersBulletTimer
    IL_0097:  ldarg.0
    IL_0098:  ldc.i4.0
    IL_0099:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::score
    IL_009e:  ldarg.0
    IL_009f:  ldc.i4.0
    IL_00a0:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::iterationCount
    IL_00a5:  ldarg.0
    IL_00a6:  ldc.i4.0
    IL_00a7:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::invaderExplosionState
    IL_00ac:  ldarg.0
    IL_00ad:  ldc.i4.3
    IL_00ae:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::shipCount
    IL_00b3:  ldarg.0
    IL_00b4:  ldc.i4.0
    IL_00b5:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::highScoreDisplayed
    IL_00ba:  ldarg.0
    IL_00bb:  ldc.i4.0
    IL_00bc:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::shipBeingDestroyed
    IL_00c1:  ldarg.0
    IL_00c2:  ldc.i4.0
    IL_00c3:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::gettingName
    IL_00c8:  ldarg.0
    IL_00c9:  ldc.i4.0
    IL_00ca:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoMode
    IL_00cf:  ldarg.0
    IL_00d0:  ldc.i4.0
    IL_00d1:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::demoNotHighScore
    IL_00d6:  ldarg.0
    IL_00d7:  ldc.i4.0
    IL_00d8:  stfld      valuetype Microsoft.Samples.SpaceInvaders.GameState Microsoft.Samples.SpaceInvaders.Invaders::gameOver
    IL_00dd:  ldarg.0
    IL_00de:  ldc.i4.0
    IL_00df:  stfld      bool Microsoft.Samples.SpaceInvaders.Invaders::invadersReset
    IL_00e4:  ldarg.0
    IL_00e5:  ldc.i4.0
    IL_00e6:  stfld      int32 Microsoft.Samples.SpaceInvaders.Invaders::shipExplosionState
    IL_00eb:  ldarg.0
    IL_00ec:  call       instance void [mscorlib]System.Object::.ctor()
    IL_00f1:  nop
    IL_00f2:  ret
  } // end of method Invaders::.ctor

  .property instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]>
          HighScores()
  {
    .get instance class [System]System.Collections.Generic.'SortedList`2'<int32,string[]> Microsoft.Samples.SpaceInvaders.Invaders::get_HighScores()
  } // end of property Invaders::HighScores
} // end of class Microsoft.Samples.SpaceInvaders.Invaders

.class private auto ansi '<PrivateImplementationDetails>{D0554739-A3F9-4B53-8210-F567A008B2F2}'
       extends [mscorlib]System.Object
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .class explicit ansi sealed nested private '__StaticArrayInitTypeSize=512'
         extends [mscorlib]System.ValueType
  {
    .pack 1
    .size 512
  } // end of class '__StaticArrayInitTypeSize=512'

  .field static assembly valuetype '<PrivateImplementationDetails>{D0554739-A3F9-4B53-8210-F567A008B2F2}'/'__StaticArrayInitTypeSize=512' '$$method0x6000039-1' at I_000031A0
} // end of class '<PrivateImplementationDetails>{D0554739-A3F9-4B53-8210-F567A008B2F2}'


// =============================================================

.data cil I_000031A0 = bytearray (
                 00 00 89 11 12 23 9B 32 24 46 AD 57 36 65 BF 74  // .....#.2$F.W6e.t
                 48 8C C1 9D 5A AF D3 BE 6C CA E5 DB 7E E9 F7 F8  // H...Z...l...~...
                 81 10 08 01 93 33 1A 22 A5 56 2C 47 B7 75 3E 64  // .....3.".V,G.u>d
                 C9 9C 40 8D DB BF 52 AE ED DA 64 CB FF F9 76 E8  // ..@...R...d...v.
                 02 21 8B 30 10 02 99 13 26 67 AF 76 34 44 BD 55  // .!.0....&g.v4D.U
                 4A AD C3 BC 58 8E D1 9F 6E EB E7 FA 7C C8 F5 D9  // J...X...n...|...
                 83 31 0A 20 91 12 18 03 A7 77 2E 66 B5 54 3C 45  // .1. .....w.f.T<E
                 CB BD 42 AC D9 9E 50 8F EF FB 66 EA FD D8 74 C9  // ..B...P...f...t.
                 04 42 8D 53 16 61 9F 70 20 04 A9 15 32 27 BB 36  // .B.S.a.p ...2'.6
                 4C CE C5 DF 5E ED D7 FC 68 88 E1 99 7A AB F3 BA  // L...^...h...z...
                 85 52 0C 43 97 71 1E 60 A1 14 28 05 B3 37 3A 26  // .R.C.q.`..(..7:&
                 CD DE 44 CF DF FD 56 EC E9 98 60 89 FB BB 72 AA  // ..D...V...`...r.
                 06 63 8F 72 14 40 9D 51 22 25 AB 34 30 06 B9 17  // .c.r.@.Q"%.40...
                 4E EF C7 FE 5C CC D5 DD 6A A9 E3 B8 78 8A F1 9B  // N...\...j...x...
                 87 73 0E 62 95 50 1C 41 A3 35 2A 24 B1 16 38 07  // .s.b.P.A.5*$..8.
                 CF FF 46 EE DD DC 54 CD EB B9 62 A8 F9 9A 70 8B  // ..F...T...b...p.
                 08 84 81 95 1A A7 93 B6 2C C2 A5 D3 3E E1 B7 F0  // ........,...>...
                 40 08 C9 19 52 2B DB 3A 64 4E ED 5F 76 6D FF 7C  // @...R+.:dN._vm.|
                 89 94 00 85 9B B7 12 A6 AD D2 24 C3 BF F1 36 E0  // ..........$...6.
                 C1 18 48 09 D3 3B 5A 2A E5 5E 6C 4F F7 7D 7E 6C  // ..H..;Z*.^lO.}~l
                 0A A5 83 B4 18 86 91 97 2E E3 A7 F2 3C C0 B5 D1  // ............<...
                 42 29 CB 38 50 0A D9 1B 66 6F EF 7E 74 4C FD 5D  // B).8P...fo.~tL.]
                 8B B5 02 A4 99 96 10 87 AF F3 26 E2 BD D0 34 C1  // ..........&...4.
                 C3 39 4A 28 D1 1A 58 0B E7 7F 6E 6E F5 5C 7C 4D  // .9J(..X...nn.\|M
                 0C C6 85 D7 1E E5 97 F4 28 80 A1 91 3A A3 B3 B2  // ........(...:...
                 44 4A CD 5B 56 69 DF 78 60 0C E9 1D 72 2F FB 3E  // DJ.[Vi.x`...r/.>
                 8D D6 04 C7 9F F5 16 E4 A9 90 20 81 BB B3 32 A2  // .......... ...2.
                 C5 5A 4C 4B D7 79 5E 68 E1 1C 68 0D F3 3F 7A 2E  // .ZLK.y^h..h..?z.
                 0E E7 87 F6 1C C4 95 D5 2A A1 A3 B0 38 82 B1 93  // ........*...8...
                 46 6B CF 7A 54 48 DD 59 62 2D EB 3C 70 0E F9 1F  // Fk.zTH.Yb-.<p...
                 8F F7 06 E6 9D D4 14 C5 AB B1 22 A0 B9 92 30 83  // .........."...0.
                 C7 7B 4E 6A D5 58 5C 49 E3 3D 6A 2C F1 1E 78 0F) // .{Nj.X\I.=j,..x.
// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file out.res
