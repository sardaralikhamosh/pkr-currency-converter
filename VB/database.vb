Public Class LocalCurrencyConverter
    Private ExchangeRates As New Dictionary(Of String, Decimal)
    
    Public Sub New()
        ' Initialize with some base rates (you would need to update these periodically)
        ExchangeRates.Add("USD", 0.0036)
        ExchangeRates.Add("EUR", 0.0033)
        ExchangeRates.Add("GBP", 0.0028)
        ExchangeRates.Add("JPY", 0.53)
        ' Add more currencies as needed
    End Sub
    
    Public Sub UpdateRate(currencyCode As String, newRate As Decimal)
        If ExchangeRates.ContainsKey(currencyCode) Then
            ExchangeRates(currencyCode) = newRate
        Else
            ExchangeRates.Add(currencyCode, newRate)
        End If
    End Sub
    
    Public Function Convert(amount As Decimal, targetCurrency As String) As Decimal
        If ExchangeRates.ContainsKey(targetCurrency) Then
            Return amount * ExchangeRates(targetCurrency)
        Else
            Throw New ArgumentException("Currency not supported")
        End If
    End Function
End Class