Public Class Functions
	Public Shared FunctionsObject As Functions = New Functions

    Public Function GetDecimal(ByVal param As Double) As Double
        Dim result As Double = 0.0
        Dim tempstr As String

        tempstr = param.ToString()

        tempstr = tempstr.Split(".")(1)
        tempstr = "0." + tempstr
        result = Double.Parse(tempstr)

        Return result
    End Function

    Public Function GethrefFromImgLink(ByVal str As String) As String
        Dim ret As String = ""

        If str = "" Then
            Return ret
        End If

        Dim startidx As Integer = str.IndexOf("webimage/") + "webimage/".Length
        Dim endidx As Integer = str.IndexOf("-0-feed?")

        Return "www.wish.com/product/" + GetStringInRange(startidx, endidx, str)
    End Function

    Public Function GetStringTime(ByVal time As Integer, ByVal abbreviate As Boolean) As String
		If time >= 1000 Then
			If (time / 1000) >= 60 Then
				If ((time / 1000) / 60) >= 60 Then
					Return "Just close the application, please."
				Else
					Dim decimalToUse As Double = GetDecimal(((time / 1000) / 60).ToString())
					Dim timeAsResult As String = (((time / 1000) / 60) - decimalToUse).ToString()
					Return IIf(abbreviate, timeAsResult + "m " + (decimalToUse * 60).ToString("#####.#") + "s", timeAsResult + " minute(s) " + (decimalToUse * 60).ToString("#####.#") + " second(s)")
				End If
			Else
				Dim decimalToUse As Double = GetDecimal((time / 1000).ToString())
				Dim timeAsResult As String = ((time / 1000) - decimalToUse).ToString()
				Return IIf(abbreviate, timeAsResult + "s " + (decimalToUse * 1000).ToString() + "ms", timeAsResult + " second(s) " + (decimalToUse * 1000).ToString() + " milliseconds")
			End If
		Else
			Return IIf(abbreviate, time.ToString() + "ms", time.ToString() + " millisecond(s)")
		End If
		Return ""
	End Function

	Public Function GetCurrencyString(ByVal currencyStr As String) As String
		Select Case currencyStr
			Case "NOK"
				Return "krNOK"
			Case "CAD"
				Return "$CAD"
			Case "BRL"
				Return "R$BRL"
			Case "AED"
				Return "د.إ.‏AED"
			Case "ALL"
				Return "LekëALL"
			Case "ARS"
				Return "$ARS"
			Case "AUD"
				Return "$AUD"
			Case "BAM"
				Return "KMBAM"
			Case "BBD"
				Return "$BBD"
			Case "BGN"
				Return "лв.BGN"
			Case "BMD"
				Return "$BMD"
			Case "BRL"
				Return "R$BRL"
			Case "CHF"
				Return "CHFCHF"
			Case "CLP"
				Return "$CLP"
			Case "CLP"
				Return "$CLP"
			Case "COP"
				Return "$COP"
			Case "CRC"
				Return "₡CRC"
			Case "CZK"
				Return "KčCZK"
			Case "DKK"
				Return "kr.DKK"
			Case "DOP"
				Return "RD$DOP"
			Case "EGP"
				Return "ج.م.‏EGP"
			Case "EUR"
				Return "€EUR"
			Case "GBP"
				Return "£GBP"
			Case "HKD"
				Return "HK$HKD"
			Case "HRK"
				Return "HRKHRK"
			Case "HUF"
				Return "FtHUF"
			Case "IDR"
				Return "RpIDR"
			Case "ILS"
				Return "₪ILS"
			Case "INR"
				Return "₹INR"
			Case "JMD"
				Return "$JMD"
			Case "JOD"
				Return "د.أ.‏JOD"
			Case "JPY"
				Return "￥JPY"
			Case "KRW"
				Return "₩KRW"
			Case "KWD"
				Return "د.ك.‏KWD"
			Case "MAD"
				Return "د.م.‏MAD"
			Case "MDL"
				Return "LMDL"
			Case "MXN"
				Return "$MXN"
			Case "MYR"
				Return "RMMYR"
			Case "NZD"
				Return "$NZD"
			Case "PEN"
				Return "S/.PEN"
			Case "PHP"
				Return "₱PHP"
			Case "PKR"
				Return "RsPKR"
			Case "PLN"
				Return "złPLN"
			Case "RON"
				Return "RONRON"
			Case "RSD"
				Return "RSDRSD"
			Case "RUB"
				Return "₽RUB"
			Case "SAR"
				Return "ر.س.‏SAR"
			Case "SEK"
				Return "krSEK"
			Case "SGD"
				Return "$SGD"
			Case "THB"
				Return "THBTHB"
			Case "TRY"
				Return "₺TRY"
			Case "TWD"
				Return "$TWD"
			Case "UAH"
				Return "₴UAH"
			Case "USD"
				Return "$"
			Case "VEF"
				Return "Bs.VEF"
			Case "VND"
				Return "₫VND"
			Case "ZAR"
				Return "RZAR"
		End Select
		Return ""
	End Function

	Public Function SortWishItemByPrice(ByVal listOfItems As List(Of WishItem)) As List(Of WishItem)
		Return (From item As WishItem In listOfItems Order By item.getsetPrice Descending Select item).ToList()
	End Function

	'Needs the innerhtml of "feed-product-item".
	Public Function GetImageLink(strparam As String) As String
		Dim result As String = ""
		If strparam = "" Then
			Return result
		End If

		Dim startidx As Integer = strparam.IndexOf("http")
		Dim endidx As Integer = strparam.IndexOf(");'") - 1

		result = GetStringInRange(startidx, endidx, strparam)

		Return result
	End Function

	Public Function GetStringInRange(fromidx As Integer, toidx As Integer, strparam As String) As String
		Dim result As String = ""
		If fromidx > toidx Then
			Return result
		ElseIf toidx > strparam.Length Then
			Return result
		ElseIf toidx < 0 Or fromidx < 0 Then
			Return result
		End If

		result = strparam.Remove(0, fromidx)
		result = result.Remove(toidx - fromidx, strparam.Length - toidx)
		Return result
	End Function

	Public Function GetPrice(fromidx As Integer, strparam As String) As String
		Dim result As String = ""
		If strparam = "" Then
			Return result
		End If

		If strparam.Contains("shipping") Then
			result = strparam.Insert(strparam.IndexOf("krNOK"), " ")
			result = result.Split(" ")(1)
			result = result.Split(vbCrLf)(2)
		Else
			result = strparam.Insert(strparam.IndexOf("krNOK"), " ")
			result = result.Split(" ")(1)
		End If

		Return result
	End Function

	Public Function GetLink(strparam As String) As String
		Dim result As String = ""

		result = strparam.Split("Link:")(1)
		result = result.Remove(0, 5)
		result.Trim()

		Return result
	End Function
End Class