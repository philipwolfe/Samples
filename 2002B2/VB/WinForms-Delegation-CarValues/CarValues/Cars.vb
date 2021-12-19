Public Class Car
    Delegate Function BookValue(ByVal Make As String, ByVal Model As String, ByVal Year As String) As Double
    
    Public Enum ConditionEnum
        condMint
        condVeryGood
        condGood
        condPoor
        condJunk
    End Enum
    
    Public Function CalculateTotal(ByVal CurrentValue As BookValue, ByVal Make As String, ByVal Model As String, ByVal Year As String, ByVal CurrentCondition As ConditionEnum) As Double
        
        '*** In this sample, only current condition is used to determine the current  ***
        '*** value of the car.  The current value is determined by multiplying the    ***
        '*** the book value by a percentage (based on condition) and then subtracting ***
        '*** that amount from the book value.                                         ***
        
        Select Case CurrentCondition
            Case ConditionEnum.condMint
                CalculateTotal = CurrentValue.Invoke(Make, Model, Year)
            Case ConditionEnum.condVeryGood
                CalculateTotal = CurrentValue.Invoke(Make, Model, Year) - (CurrentValue.Invoke(Make, Model, Year) * 0.2)
            Case ConditionEnum.condGood
                CalculateTotal = CurrentValue.Invoke(Make, Model, Year) - (CurrentValue.Invoke(Make, Model, Year) * 0.4)
            Case ConditionEnum.condPoor
                CalculateTotal = CurrentValue.Invoke(Make, Model, Year) - (CurrentValue.Invoke(Make, Model, Year) * 0.6)
            Case ConditionEnum.condJunk
                CalculateTotal = CurrentValue.Invoke(Make, Model, Year) - (CurrentValue.Invoke(Make, Model, Year) * 0.9)
        End Select
    End Function
    
    
End Class
