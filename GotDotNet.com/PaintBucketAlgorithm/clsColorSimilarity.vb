'Class for color similarities calculating and color conversions
Public Class ColorSimilarity

	Structure CMYK
		Dim C As Single
		Dim M As Single
		Dim Y As Single
		Dim K As Single
	End Structure

	Protected Shared Function RGBtoCMYK(ByRef r As Byte, ByRef g As Byte, ByRef b As Byte) As CMYK
		Dim Y, C, M, K As Decimal
		K = Max(r, g)
		K = Max(b, K)
		K = 100 - System.Math.Round(K / 10 * 4)

		While (K > 100)
			K = System.Math.Round(K / 8)
		End While

		If (K < 0) Then K = 0
		C = 0
		M = 0
		Y = 0
		C = C - System.Math.Round(r / 10 * 4)
		If (C < 0) Then
			M = M - C
			Y = Y - C
			C = 0
		End If
		M = M - System.Math.Round(g / 10 * 4)
		If (M < 0) Then
			C = C - M
			Y = Y - M
			M = 0
		End If
		Y = Y - System.Math.Round(b / 10 * 4)
		If (Y < 0) Then
			C = C - Y
			M = M - Y
			Y = 0
		End If
		Dim col As New CMYK
		col.K = IIf(K > 100, 100, K)
		col.C = IIf(C > 100, 100, C)
		col.M = IIf(M > 100, 100, M)
		col.Y = IIf(Y > 100, 100, Y)
		Return col
	End Function

	Private Shared Function Max(ByRef n1 As Decimal, ByRef n2 As Decimal) As Decimal
		If n1 >= n2 Then
			Max = n1
		Else
			Max = n2
		End If
	End Function

	Public Shared Function GetNearestWebColor(ByVal clr As Color) As Byte()
		Dim tmp(2) As Byte
		tmp(0) = GetNearNumber(clr.R)
		tmp(1) = GetNearNumber(clr.G)
		tmp(2) = GetNearNumber(clr.B)
		Return tmp
	End Function

	Private Shared Function GetNearNumber(ByVal RGB As Byte) As Byte
		If RGB <= 25 Then Return 0
		Return (Fix((RGB - 25) / 51) + 1)
	End Function

	Public Shared Function GetNearPercentHSB(ByVal color1 As Color, ByVal color2 As Color) As Single
		Dim tmp As Single
		tmp += GetPercent(color1.GetHue, color2.GetHue)
		tmp += GetPercent(color1.GetSaturation, color2.GetSaturation, 1)
		tmp += GetPercent(color1.GetBrightness, color2.GetBrightness, 1)

		Return Math.Abs(100 - (tmp / 3))
	End Function

	Public Shared Function GetNearPercentRGB(ByVal color1 As Color, ByVal color2 As Color) As Single
		Dim tmp As Single
		tmp += GetPercent(color1.R, color2.R, 255)
		tmp += GetPercent(color1.G, color2.G, 255)
		tmp += GetPercent(color1.B, color2.B, 255)

		Return Math.Abs(100 - (tmp / 3))
	End Function

	Public Shared Function GetNearRGBVectorial(ByVal color1 As Color, ByVal color2 As Color) As Single
		Dim tmp As Decimal
		tmp = (CDec(color1.R) - CDec(color2.R)) ^ 2
		tmp += (CDec(color1.G) - CDec(color2.G)) ^ 2
		tmp += (CDec(color1.B) - CDec(color2.B)) ^ 2

		Return 100 - (((tmp ^ (1 / 2)) / 441.67295593006372) * 100)
	End Function

	Public Shared Function GetNearHSBVectorial(ByVal color1 As Color, ByVal color2 As Color) As Single
		Dim tmp As Decimal
		tmp = (CDec(color1.GetHue) - CDec(color2.GetHue)) ^ 2
		tmp += (CDec(color1.GetSaturation) - CDec(color2.GetSaturation)) ^ 2
		tmp += (CDec(color1.GetBrightness) - CDec(color2.GetBrightness)) ^ 2

		Return 100 - (((tmp ^ (1 / 2)) / 509.11688245431424) * 100)
	End Function

	Public Shared Function GetNearPercentCMYK(ByVal color1 As Color, ByVal color2 As Color) As Single
		Dim tmp As Single
		Dim cm1, cm2 As CMYK
		cm1 = RGBtoCMYK(color1.R, color1.G, color1.B)
		cm2 = RGBtoCMYK(color2.R, color2.G, color2.B)

		tmp += GetPercent(cm1.C, cm2.C, 100)
		tmp += GetPercent(cm1.M, cm2.M, 100)
		tmp += GetPercent(cm1.Y, cm2.Y, 100)
		tmp += GetPercent(cm1.K, cm2.K, 100)
		Return Math.Abs(100 - (tmp / 4))
	End Function

	Private Shared Function GetPercent(ByVal var1 As Int16, ByVal var2 As Int16, Optional ByVal maxvar As Int16 = 360) As Single
		Return Math.Abs(((Math.Abs(CDec(var1) - CDec(var2)) / maxvar) * 100))
	End Function

	Public Shared Function IsEqual(ByVal clr1 As Color, ByVal clr2 As Color) As Boolean
		If (clr1.R = clr2.R) And (clr1.R = clr2.R) And (clr1.R = clr2.R) And (clr1.R = clr2.R) Then
			Return True
		ElseIf clr1.Name = clr2.Name Then
			Return True
		ElseIf clr1.GetHashCode = clr2.GetHashCode Then
			Return True
		Else
			Return False
		End If
	End Function

End Class