Imports System

Public Class Customer
	protected last As String
	protected first As String
	
	public Property LastName as string
                get
			return me.last
                End get
                set
			Me.last = value
                End set
        end property 
        
	public property FirstName as string 
		get
			return me.first
		end get 
		set
			me.first = value
		end set
        end property

	public readonly property FullName as string
		get
			return (FirstName + LastName)
		end get
	end property
End Class