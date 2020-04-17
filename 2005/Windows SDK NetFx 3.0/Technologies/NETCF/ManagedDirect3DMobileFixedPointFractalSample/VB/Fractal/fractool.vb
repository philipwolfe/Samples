'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------

'-----------------------------------------------------------------------------
' File: Fractool.vb
'
' Desc: Create fractals.
'
' Copyright (c) Microsoft Corporation. All rights reserved.
'-----------------------------------------------------------------------------
Imports System

Namespace Microsoft.Samples.MD3DM

    ' This class generates a 2D array of elevation points using
    ' midpoint displacement and random additions in two dimensions.
    Public Class ElevationPoints
        'fractal terrain goes here. It is (2^maxlevel+1)^2 in bufferSize.
        Private heights(,) As Double

        'These values govern the topology of the fractal mesh
        Private maxlevel As Integer
        Private addition As Boolean
        Private sigma As Double
        Private shape As Double
        
        'Gausian number generator.
        Private Gauss As GaussGen
        
        Private Function f3(ByVal delta As Double, ByVal x0 As Double, _
            ByVal x1 As Double, ByVal x2 As Double) As Double 
            Return(x0 + x1 + x2) / 3 + delta * Gauss.GaussianNumber
        
        End Function 'f3
        
        Private Function f4(ByVal delta As Double, ByVal x0 As Double, _
            ByVal x1 As Double, ByVal x2 As Double, ByVal x3 As Double) _
            As Double 
            Return(x0 + x1 + x2 + x3) / 4 + delta * Gauss.GaussianNumber
        
        End Function 'f4
         
        Public Function GetHeights() As Double(,)
            Return heights
        End Function

        ' Constrcutor. Pass in parameters
        ' levelMax : determines the bufferSize of the fractal mesh
        ' add :  Use random additions?
        ' sd : initial standard deviation
        ' fractalDimension : Determines general shape of mesh
        Public Sub New(ByVal levelMax As Integer, ByVal add As Boolean, _
            ByVal sd As Double, ByVal fractalDimension As Double) 
            maxlevel = levelMax
            addition = add
            sigma = sd
            shape = fractalDimension
        
        End Sub 'New
        

        ' Constructor : uses arbitrary defualts
        Public Sub New() 
            maxlevel = 5
            addition = True
            sigma = 0.5
            shape = 0.5
        
        End Sub 'New
        
        ' Generates a fractal mesh 2^maxelvel+1 in bufferSize
        ' cribbed from "The Science of Fractal Images"
        Public Sub CalcMidpointFM2D() 
            'tracks standard deviation
            Dim delta As Double
            'Integers
            Dim N, stage As Integer
            'Array indices
            Dim x, y, BigD, d As Integer 
            'Initialize gaussian number widget
            Gauss = New GaussGen()
            N = CType(Fix(Math.Pow(2, maxlevel)), Integer)
            delta = sigma
            
            'Allocate dump for data
            heights = New Double(N + 1, N + 1) {}
            'Init starting corner points in grid
            heights(0, 0) = delta * Gauss.GaussianNumber
            heights(0, N) = delta * Gauss.GaussianNumber
            heights(N, 0) = delta * Gauss.GaussianNumber
            heights(N, N) = delta * Gauss.GaussianNumber
            BigD = N
            d = CType(N / 2, Integer)
            stage = 1
            
            While stage <= maxlevel
                delta = delta * Math.Pow(0.5, 0.5 * shape)
                For x = d To N-d Step BigD
                    For y = d To N-d Step BigD
                        heights(x, y) = f4(delta, _
                            heights(x+d, y+d), heights(x+d, y-d), _
                            heights(x-d, y+d), heights(x-d, y-d))
                    Next y         
                Next x

                If addition Then
                    For x = 0 To N Step BigD
                        For y = 0 To N Step BigD
                            heights(x, y) = heights(x, y) + _
                                delta * Gauss.GaussianNumber                
                        Next y
                    Next x
                End If
                
                
                delta = delta * Math.Pow(0.5, 0.5 * shape)

                For x = d to N-d Step BigD
                    heights(x, 0) = f3(delta, _
                        heights(x + d, 0), heights(x - d, 0), _
                        heights(x, d))
                    heights(x, N) = f3(delta, _
                        heights(x + d, N), heights(x - d, N), _
                        heights(x, N-d))
                    heights(0, x) = f3(delta, _
                        heights(0, x + d), heights(0, x - d), _
                        heights(d, x))
                    heights(N, x) = f3(delta, _
                        heights(N, x+d), heights(N, x - d), _
                        heights(N - d, x))
                Next x

                For x = d To N-d Step BigD
                    For y = BigD to N-d Step BigD
                        heights(x, y) = f4(delta, _
                            heights(x, y + d), heights(x, y - d), _
                            heights(x + d, y), heights(x - d, y))
                    Next y
                Next x

                For x = BigD To N-d Step BigD
                    For y = d To N-d Step BigD
                        heights(x, y) = f4(delta, _
                            heights(x, y + d), heights(x, y - d), _
                            heights(x + d, y), heights(x - d, y))
                    Next y
                Next x

                If addition Then
                    For x = 0 To N Step BigD
                        For y = 0 To N Step BigD
                            heights(x, y) = heights(x, y) + _
                                delta * Gauss.GaussianNumber
                        Next y
                    Next x

                    For x = d To N-d Step BigD
                        For y = d To N-d Step BigD
                            heights(x, y) = heights(x, y) + _
                                delta * Gauss.GaussianNumber
                        Next y
                    Next x
                End If
                
                
                
                BigD = CType(BigD / 2, Integer)
                d = CType(d / 2, Integer)
                stage += 1
            End While
        
        End Sub 'CalcMidpointFM2D
    End Class 'ElevationPoints


    Class GaussGen
        Private Arand As Integer
        Private GaussAdd, numer, denom As Double
        Private rand As Random
        
        ' Constructor; Initialize the Gausian number system
        Public Sub New() 
            rand = New Random(CType(DateTime.Now.Ticks And _
                &H7FFFFFFF, Integer))
            Arand = CType(Fix(Math.Pow(2, 31)) - 1, Integer)
            GaussAdd = Math.Sqrt(12)
            numer = GaussAdd + GaussAdd
            denom = System.Convert.ToDouble(4) * Arand
        
        End Sub 'New
        
        ' Return a Gaussian number
        Public ReadOnly Property GaussianNumber() As Double 
            Get
                Dim i As Integer
                Dim sum As Double = 0
                For i = 1 To 4
                    sum += rand.Next(Arand)
                Next i
                Return sum * numer / denom - GaussAdd
            End Get
        End Property
    End Class 'GaussGen
End Namespace
