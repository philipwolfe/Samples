Option Strict On
Option Explicit On


Public Class ServiceOrbling
    Implements ILocalOrbling

    Private m_ServiceProxy As OrblingProxy
    Private m_ServiceName As String

    Public Sub New(ByVal serviceName As String)
        m_ServiceName = serviceName
    End Sub

    Private Sub Initialize()
        If m_ServiceProxy Is Nothing Then
            m_ServiceProxy = New OrblingProxy(m_ServiceName)
        End If
    End Sub

    'GetName Method

    Function GetName() As String Implements ILocalOrbling.GetName
        Return m_ServiceName
    End Function


    'GetType Method

    Function GetConnectionType() As OrblingType Implements ILocalOrbling.GetConnectionType
        Return OrblingType.Service
    End Function

    Public Function GetInformation(ByVal options As OrbOptionValues) As OrbDisplay Implements ILocalOrbling.GetInformation

        Me.Initialize()

        'Options going to a service must be serialized first

        Dim optionsList As New OrbOptionValues
        optionsList.ComponentProperties = OrbOption.SerializeOptions(options.ComponentProperties)

        Return m_ServiceProxy.GetInformation(optionsList)
    End Function

    Public Function GetOptions() As OrbOptions Implements ILocalOrbling.GetOptions
        Me.Initialize()

        'Options coming from a service must be de-serialized first

        Dim optionsList As OrbOptions = m_ServiceProxy.GetOptions()
        optionsList.ComponentProperties = OrbOption.DeserializeOptions(optionsList.ComponentProperties)

        Return optionsList

    End Function

    Public Function GetTime() As System.TimeSpan Implements ILocalOrbling.GetTime

        Me.Initialize()

        Return m_ServiceProxy.GetTime()
    End Function
End Class
