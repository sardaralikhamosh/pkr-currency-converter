Public Class MainForm
    Private converter As New CurrencyConverter()
    
    Private Async Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Visible = True
        Dim success As Boolean = Await converter.GetExchangeRates()
        ProgressBar1.Visible = False
        
        If success Then
            cmbCurrency.DataSource = converter.ExchangeRates.Keys.ToList()
        Else
            MessageBox.Show("Failed to load exchange rates")
        End If
    End Sub
    
    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        Try
            Dim amount As Decimal = Decimal.Parse(txtAmount.Text)
            Dim targetCurrency As String = cmbCurrency.SelectedItem.ToString()
            Dim convertedAmount As Decimal = converter.ConvertCurrency(amount, targetCurrency)
            lblResult.Text = $"{amount} PKR = {convertedAmount} {targetCurrency}"
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
End Class