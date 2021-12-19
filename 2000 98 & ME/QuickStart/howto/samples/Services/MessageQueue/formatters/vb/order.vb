Imports System

Public Class Order
	protected id As Int64
	protected description As String
	
	public property OrderId As Int64
		get
			return me.id
		end get
		set
			me.id = value
		end set
	end property

	public property ItemDescription As String
		get
			return me.description
		end get 
		set
			me.description= value
		end set
        end property
end class