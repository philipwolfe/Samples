'The vehicle class is a base (or parent) class which provides a base
'implementation of the common properties and methods of a vehicle.  The
'MustInherit keyword in the class declaration means that this class can
'not be be created directly.
Namespace VehicleDemo
    
    Public MustInherit Class Vehicle
        'Property holders
        Private mMilesPerGallon As Integer
        Private mFuelCapacity As Integer
        
        Public Property FuelCapacity() As Integer
            Set
                mFuelCapacity = Value
            End Set
            Get
                FuelCapacity = mFuelCapacity
            End Get
        End Property
        Public Property MilesPerGallon() As Integer
            Set
                mMilesPerGallon = Value
            End Set
            Get
                MilesPerGallon = mMilesPerGallon
            End Get
        End Property
        
        'The ComputeRange function is maked as Overridable which means that classes which 
        'inherit the Vehicle class can override the implementation of this function.
        Public Overridable Function ComputeRange() As Integer
            
            ComputeRange = mMilesPerGallon * mFuelCapacity
            
        End Function
        
    End Class
End Namespace