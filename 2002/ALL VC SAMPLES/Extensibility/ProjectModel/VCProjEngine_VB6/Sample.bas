Attribute VB_Name = "VCProjEngine"
Option Explicit

Sub Main()

On Error GoTo ErrorHandler
'Create a project engine
Dim projEngine As VCProjectEngineObject
Set projEngine = New VCProjectEngineObject

'Load a project, change the name, add a configuration
Dim project As VCProject
Set project = projEngine.LoadProject("MyProject.vcproj")
If Not project Is Nothing Then
    'Change the project's name
    project.Name = "Voila"
    'Add a new configuration
    project.AddConfiguration ("Whichever name")
    
    'Get the debug configuration and change the type to application
    Dim configuration As VCConfiguration
    Set configuration = project.Configurations.Item("Debug")
    If Not configuration Is Nothing Then
        configuration.ConfigurationType = ConfigurationTypes.typeApplication
    Else
        Debug.Print "I Couldn't find the configuration"
    End If
    
    'Get the linker tool from the configration.
    Dim LinkerTool As VCLinkerTool
    Set LinkerTool = configuration.Tools.Item("VCLinkerTool")
    If Not LinkerTool Is Nothing Then
        'Change the ShowProgress property to "Display All Progress Messages
        LinkerTool.ShowProgress = linkProgressOption.linkProgressAll
    Else
        Debug.Print "I Couldn't find the linkerTool"
    End If
    'Add a cpp file called New.cpp
    If project.CanAddFile("New.cpp") Then
        project.AddFile ("New.cpp")
    Else
        Debug.Print "I Couldn't add the file"
    End If
    
    'Access the files collection
    Dim filesCollection As IVCCollection
    Set filesCollection = project.Files
    If Not filesCollection Is Nothing Then
        'Access a cpp file called Existing.cpp that is already in the project.
        Dim file As VCFile
        Set file = filesCollection.Item("Existing.cpp")
        If Not file Is Nothing Then
            'Access the release configuration of this file.
            Dim fileConfiguration As VCFileConfiguration
            Set fileConfiguration = file.FileConfigurations.Item("Release|Win32")
            'Get the compiler tool associated with this file.
            Dim compilerTool As VCCLCompilerTool
            Set compilerTool = fileConfiguration.Tool
            'Change the optimization property to Full Optimization (/Ox)
            compilerTool.Optimization = optimizeOption.optimizeFull
        Else
           Debug.Print "I Couldn't find the file"
        End If
        'Save the project, then remove it.
	project.ProjectFile = "MyNewProject.vcproj"
        project.Save ()
    Else
        Debug.Print "I Couldn't find the file collection"
    End If
Else
    Debug.Print "I Couldn't find the project"
End If

Exit Sub

ErrorHandler:

    Debug.Print "Operation failed for the following reason:" & Err.Description

End Sub
