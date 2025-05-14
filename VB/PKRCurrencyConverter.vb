Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class CurrencyConverter
    Private Const API_KEY As String = "YOUR_API_KEY" ' Get from exchangerate-api.com or similar
    Private Const BASE_URL As String = "https://v6.exchangerate-api.com/v6/{0}/latest/PKR"
    
    Private ExchangeRates As Dictionary(Of String, Decimal)
    
    Public Async Function GetExchangeRates() As Task(Of Boolean)
        Try
            Dim url As String = String.Format(BASE_URL, API_KEY)
            Dim client As New WebClient()
            Dim json As String = Await client.DownloadStringTaskAsync(url)
            
            Dim data As JObject = JObject.Parse(json)
            If data("result").ToString() = "success" Then
                ExchangeRates = data("conversion_rates").ToObject(Of Dictionary(Of String, Decimal))()
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show("Error fetching rates: " & ex.Message)
        End Try
        Return False
    End Function
    
    Public Function ConvertCurrency(amount As Decimal, targetCurrency As String) As Decimal
        If ExchangeRates Is Nothing OrElse Not ExchangeRates.ContainsKey(targetCurrency) Then
            Throw New ArgumentException("Invalid currency or rates not loaded")
        End If
        Return amount * ExchangeRates(targetCurrency)
    End Function
End Class