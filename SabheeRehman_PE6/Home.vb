Public Class Home
    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnCalc.Enabled = False
    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        'Calculates BMI
        'and Display BMI in lblBMI
        Dim decHeight As Decimal
        Dim decWeight As Decimal
        Dim blnNumberInNumIsValid As Boolean = False
        Dim blnSysSelected As Boolean = False
        Dim intSysChoice As Integer
        Dim strSelectedSys As String = ""
        Dim decBMI As Decimal

        'Check to see if number is valid or not
        blnNumberInNumIsValid = ValidateNumberInNum()

        'Check to see if a system was selected
        intSysChoice = ValidateSysSelection(blnSysSelected, strSelectedSys)

        'If number is entered, Calculate BMI
        If blnNumberInNumIsValid Then
            decHeight = Convert.ToDecimal(txtHeight.Text)

            decWeight = Convert.ToDecimal(txtWeight.Text)

            intSysChoice = lstSystem.SelectedIndex

            Select Case intSysChoice
                Case 0
                    decBMI = ImperialBMI(decHeight, decWeight)

                Case 1
                    decBMI = MetricBMI(decHeight, decWeight)
            End Select
        End If

        'display BMI
        lblBMI.Text = "BMI is " & decBMI.ToString("N2")
    End Sub

    Private Function ValidateNumberInNum() As Boolean
        'Validate Input

        Dim decHeight As Decimal
        Dim decWeight As Decimal
        Dim blnValidityCheck As Boolean = False
        Dim strNumberInDataMessage As String = "Please enter the valid number (s)"
        Dim strMessageBoxTitle As String = "Error"

        Try

            decHeight = Convert.ToDecimal(txtHeight.Text)
            decWeight = Convert.ToDecimal(txtWeight.Text)

            If decHeight > 0 And decWeight > 0 Then
                blnValidityCheck = True
            Else
                MsgBox(strNumberInDataMessage,, strMessageBoxTitle)
                txtHeight.Focus()
                txtHeight.Clear()
                txtWeight.Clear()
            End If

        Catch ex As FormatException
            MsgBox(strNumberInDataMessage,, strMessageBoxTitle)
            txtHeight.Focus()
            txtHeight.Clear()
            txtWeight.Clear()

        Catch ex As OverflowException
            MsgBox(strNumberInDataMessage,, strMessageBoxTitle)
            txtHeight.Focus()
            txtHeight.Clear()
            txtWeight.Clear()

        Catch ex As SystemException
            MsgBox(strNumberInDataMessage,, strMessageBoxTitle)
            txtHeight.Focus()
            txtHeight.Clear()
            txtWeight.Clear()
        End Try
        Return blnValidityCheck

    End Function

    Private Function ValidateSysSelection(ByRef blnSys As Boolean, ByRef strSys As String) As Integer
        'Ensures a System Type is Selected
        Dim intsysType As Integer

        Try
            intsysType = Convert.ToInt32(lstSystem.SelectedIndex)
            strSys = lstSystem.SelectedIndex.ToString()
            blnSys = True

        Catch ex As SystemException
            MsgBox("Select a System", , "Error")
            blnSys = False

        End Try

        Return intsysType

    End Function

    Private Function ImperialBMI(ByRef decHInches As Decimal, ByRef decWInPounds As Decimal) As Decimal
        'Imperial BMI
        Dim decBMI As Decimal
        decBMI = (decWInPounds / (decHInches * decHInches)) * 703
        Return decBMI

    End Function

    Private Function MetricBMI(ByRef decHM As Decimal, ByRef decWInKg As Decimal) As Decimal
        'Metric BMI
        Dim decBMI As Decimal
        decBMI = decWInKg / (decHM * decHM)
        Return decBMI

    End Function
    Private Sub lstSystem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSystem.SelectedIndexChanged
        'handler lets other items become visible

        Dim intSysChoice As Integer
        intSysChoice = lstSystem.SelectedIndex
        Select Case intSysChoice
            Case 0
                Visibility()

            Case 1
                Visibility()
        End Select

    End Sub

    Private Sub Visibility()
        'Set Visibility to True
        lblHeight.Visible = True
        lblWeight.Visible = True
        txtHeight.Visible = True
        txtWeight.Visible = True
        btnCalc.Visible = True
        lblBMI.Visible = True

        'clear the labels and textbox
        txtHeight.Text = ""
        txtWeight.Text = ""
        lblBMI.Text = ""

        txtHeight.Focus()
    End Sub
    'If input is entered in Text Box, it will allow the user to click button
    Private Sub txtHeight_TextChanged(sender As Object, e As EventArgs) Handles txtHeight.TextChanged
        If txtHeight.Text <> String.Empty And txtWeight.Text <> String.Empty And lstSystem.SelectedItem <> String.Empty Then
            btnCalc.Enabled = True
        End If
    End Sub

    Private Sub txtWeight_TextChanged(sender As Object, e As EventArgs) Handles txtWeight.TextChanged
        If txtHeight.Text <> String.Empty And txtWeight.Text <> String.Empty And lstSystem.SelectedItem <> String.Empty Then
            btnCalc.Enabled = True
        End If
    End Sub
End Class