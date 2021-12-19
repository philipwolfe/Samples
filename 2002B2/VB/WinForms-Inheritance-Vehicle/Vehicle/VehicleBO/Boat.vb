
Namespace VehicleDemo
    'For boats we need to override the implementation of the 
    'ComputeRange function to extend the range of the vehicle
    Public Class Boat
        Inherits Vehicle

        'We need to override the ComputeRange function to add support for boats
        'For boats we want to increase the couputed range.  We will call the
        'ComputeRange function on MyBase which is the Vehicle class
        Overrides Function ComputeRange() As Integer
            'If this is a sailboat then we double the calculated range
            ComputeRange = MyBase.ComputeRange * 2
        End Function

    End Class
    
End Namespace