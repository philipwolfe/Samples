'*****************************************************************************
' Copyright (C) 1999-2002, Microsoft Corporation.  All Rights Reserved.
'*****************************************************************************

Module ImageIndexData
    ' This module stores datas for the imagestrip bitmap resource.  Indices
    ' into the image strip are determined by (VB_IMG_xxx + VB_IMG_ACC_xxx)
    ' where VB_IMG is the element group and VB_IMG_ACC is the accessibility
    ' offset of that element.  For each element group the are six
    ' accessibilities.

    Public Const VB_IMG_IMGLIST_WIDTH As Integer = 16   'Icon width.

    Public Const VB_IMG_NONE As Integer = -1
    Public Const VB_IMG_UNKNOWN As Integer = -1

    'The accessibility offsets.
    Public Const VB_IMG_ACC_PUBLIC As Integer = 0
    Public Const VB_IMG_ACC_INTERNAL As Integer = 1
    Public Const VB_IMG_ACC_FRIEND As Integer = 2
    Public Const VB_IMG_ACC_PROTECTED As Integer = 3
    Public Const VB_IMG_ACC_PROTECTEDFRIEND As Integer = 3
    Public Const VB_IMG_ACC_PRIVATE As Integer = 4
    Public Const VB_IMG_ACC_SHORTCUT As Integer = 5

    Public Const VB_IMG_ACC_TYPE_COUNT As Integer = 6   'The size of each element group.

    'The element groups.
    Public Const VB_IMG_CLASS As Integer = (VB_IMG_ACC_TYPE_COUNT * 0)
    Public Const VB_IMG_CONSTANT As Integer = (VB_IMG_ACC_TYPE_COUNT * 1)
    Public Const VB_IMG_DELEGATE As Integer = (VB_IMG_ACC_TYPE_COUNT * 2)
    Public Const VB_IMG_ENUM As Integer = (VB_IMG_ACC_TYPE_COUNT * 3)
    Public Const VB_IMG_ENUMMEMBER As Integer = (VB_IMG_ACC_TYPE_COUNT * 4)
    Public Const VB_IMG_EVENT As Integer = (VB_IMG_ACC_TYPE_COUNT * 5)
    Public Const VB_IMG_EXCEPTION As Integer = (VB_IMG_ACC_TYPE_COUNT * 6)
    Public Const VB_IMG_FIELD As Integer = (VB_IMG_ACC_TYPE_COUNT * 7)
    Public Const VB_IMG_INTERFACE As Integer = (VB_IMG_ACC_TYPE_COUNT * 8)
    Public Const VB_IMG_MACRO As Integer = (VB_IMG_ACC_TYPE_COUNT * 9)
    Public Const VB_IMG_MAP As Integer = (VB_IMG_ACC_TYPE_COUNT * 10)
    Public Const VB_IMG_MAPITEM As Integer = (VB_IMG_ACC_TYPE_COUNT * 11)
    Public Const VB_IMG_METHOD As Integer = (VB_IMG_ACC_TYPE_COUNT * 12)
    Public Const VB_IMG_OVERLOAD As Integer = (VB_IMG_ACC_TYPE_COUNT * 13)
    Public Const VB_IMG_MODULE As Integer = (VB_IMG_ACC_TYPE_COUNT * 14)
    Public Const VB_IMG_NAMESPACE As Integer = (VB_IMG_ACC_TYPE_COUNT * 15)
    Public Const VB_IMG_OPERATOR As Integer = (VB_IMG_ACC_TYPE_COUNT * 16)
    Public Const VB_IMG_PROPERTY As Integer = (VB_IMG_ACC_TYPE_COUNT * 17)
    Public Const VB_IMG_STRUCT As Integer = (VB_IMG_ACC_TYPE_COUNT * 18)
    Public Const VB_IMG_TEMPLATE As Integer = (VB_IMG_ACC_TYPE_COUNT * 19)
    Public Const VB_IMG_TYPEDEF As Integer = (VB_IMG_ACC_TYPE_COUNT * 20)
    Public Const VB_IMG_TYPE As Integer = (VB_IMG_ACC_TYPE_COUNT * 21)
    Public Const VB_IMG_UNION As Integer = (VB_IMG_ACC_TYPE_COUNT * 22)
    Public Const VB_IMG_VARIABLE As Integer = (VB_IMG_ACC_TYPE_COUNT * 23)
    Public Const VB_IMG_VALUETYPE As Integer = (VB_IMG_ACC_TYPE_COUNT * 24)
    Public Const VB_IMG_INTRINSIC As Integer = (VB_IMG_ACC_TYPE_COUNT * 25)

    'The end of the image strip contains miscellaneous icons.  At this point,
    'the accessiblity offsets become meaningless.
    Public Const VB_IMG_ERROR As Integer = (VB_IMG_ACC_TYPE_COUNT * 26)
    Public Const VB_IMG_ASSEMBLY As Integer = (VB_IMG_ERROR + 6)
    Public Const VB_IMG_LIBRARY As Integer = (VB_IMG_ERROR + 7)
    Public Const VB_IMG_VBPROJECT As Integer = (VB_IMG_ERROR + 8)
    Public Const VB_IMG_CSHARPPROJECT As Integer = (VB_IMG_ERROR + 10)
    Public Const VB_IMG_OPEN_FOLDER As Integer = (VB_IMG_ERROR + 15)
    Public Const VB_IMG_CLOSED_FOLDER As Integer = (VB_IMG_ERROR + 16)
    Public Const VB_IMG_ARROW As Integer = (VB_IMG_ERROR + 17)

End Module
