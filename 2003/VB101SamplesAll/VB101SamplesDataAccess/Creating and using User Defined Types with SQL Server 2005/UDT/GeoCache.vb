Imports System
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server

<Serializable()> _
<Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)> _
Public Structure GeoCache
    Implements INullable

    ''' <summary>
    ''' This is an overloaded method that allows us to display the data stored
    ''' in the user defined type.
    ''' </summary>
    '' Replace the followng code with your code
    Public Overrides Function ToString() As String

        If Me.m_Null Then
            Return Nothing
        Else
            Return Me.LATITUDE.ToString() & ":" & Me.LONGITUDE.ToString()
        End If
    End Function

    Public ReadOnly Property IsNull() As Boolean Implements INullable.IsNull
        Get
            ' Put your code here
            Return m_Null
        End Get
    End Property

    Public Shared ReadOnly Property Null() As GeoCache
        Get
            Dim h As GeoCache = New GeoCache
            h.m_Null = True
            Return h
        End Get
    End Property

    ''' <summary>
    ''' This property handles access to the private longitude variable
    ''' </summary>
    Public Property LONGITUDE() As Double

        Get
            Return m_longitude
        End Get

        Set(ByVal value As Double)

            m_longitude = value
        End Set

    End Property

    ''' <summary>
    ''' This property handles access ot the private latitude variable
    ''' </summary>
    Public Property LATITUDE() As Double

        Get
            Return m_latitude
        End Get
        Set(ByVal value As Double)
            m_latitude = value

        End Set
    End Property

    Public Shared Function Parse(ByVal s As SqlString) As GeoCache
        If s.IsNull Then
            Return Null
        End If

        Dim u As GeoCache = New GeoCache
        ' Put your code here
        Dim str As String = s.ToString()
        Dim latlong() As String = str.Split(",".ToCharArray())

        u.LATITUDE = Double.Parse(latlong(0))
        u.LONGITUDE = Double.Parse(latlong(1))


        Return u
    End Function


    Private m_Null As Boolean
    Private m_longitude As Double
    Private m_latitude As Double

End Structure

