CALL "%VS80ComnTools%\vsvars32.bat"
Xcopy "C:\Windows Workflow Foundation\StarterKits\Web Workflow Approvals\Web Workflow Approvals Starter Kit.zip" "%DevEnvDir%\ProjectTemplates\CSharp\Starter Kits" /y
CALL devenv /installvstemplates

