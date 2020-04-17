CALL "%VS80ComnTools%\vsvars32.bat"
del "%DevEnvDir%\ProjectTemplates\CSharp\Starter Kits\Web Workflow Approvals Starter Kit.zip"
CALL devenv /installvstemplates
