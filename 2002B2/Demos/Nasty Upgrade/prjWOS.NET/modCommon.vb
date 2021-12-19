Option Strict Off
Option Explicit On
Module modCommon
	
	Public intTypeWO As Short
	Public intTypeTask As Short
	Public intTypeEquip As Short
	
	Public strPlantPass As String ' this variable is used to pass plant value to MDI frame
	Public intPlantPass As Short ' this variable is used to pass plant value to MDI frame
	Public strActiveFormName As String
	Public intReport As Short ' 1 - Equipment List
	' 2 - WO(Task) List
	' 3 - History detail
	' 4 - History Summary
End Module