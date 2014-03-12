Public Class fmrMain


    Private Sub btnTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrans.Click
        Dim strUnTrans, strInput, strOutput As String
        Dim intSpace, intLen As Integer
        strOutput = ""
        strInput = txtInput.Text.ToUpper
        intSpace = strInput.IndexOf(" ")
        If intSpace <= -1 Then
            strUnTrans = strInput
            strOutput = strOutput & output(strUnTrans) & " "
        Else

            While intSpace > -1

                intLen = strInput.Length - 1
                strUnTrans = (strInput.Substring(0, (intSpace)))
                strInput = strInput.Substring((intSpace + 1), (intLen - (intSpace)))
                strOutput = strOutput & output(strUnTrans) & " "
                intSpace = strInput.IndexOf(" ")
            End While
            strOutput = strOutput & output(strInput)
        End If
        Me.rtbOut.Text = strOutput


        

    End Sub

    Private Function translate(ByVal intVowel As Integer, ByVal strWord As String, ByVal intLen As Integer)
        Dim strFirst As String
        Dim count As Integer
        While count < intVowel
            strFirst = strWord.Substring(0, 1)
            strWord = strWord.Substring(1, (intLen)) & strFirst
            count += 1
        End While
        strWord = strWord & "AY"
        Return strWord


    End Function

    Private Sub btnClr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClr.Click, NewToolStripMenuItem.Click
        rtbOut.Text = ""
        txtInput.Text = ""

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click, ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Function output(ByVal strUntrans As String) As String
        Dim strOutput As String
        Dim intSize, intA, intE, intI, intO, intU As Integer

        intSize = Len(strUntrans) - 1

        intA = strUntrans.IndexOf("A")
        If intA < 0 Then
            intA = 10000
        End If

        intE = strUntrans.IndexOf("E")
        If intE < 0 Then
            intE = 10000
        End If

        intI = strUntrans.IndexOf("I")
        If intI < 0 Then
            intI = 10000
        End If

        intO = strUntrans.IndexOf("O")
        If intO < 0 Then
            intO = 10000
        End If

        intU = strUntrans.IndexOf("U")
        If intU < 0 Then
            intU = 10000
        End If

        If intA < intE And intA < intI And intA < intO And intA < intU Then
            strOutput = translate(intA, strUntrans, intSize)
        ElseIf intE < intI And intE < intO And intE < intU Then
            strOutput = translate(intE, strUntrans, intSize)
        ElseIf intI < intO And intI < intU Then
            strOutput = translate(intI, strUntrans, intSize)
        ElseIf intO < intU Then
            strOutput = translate(intO, strUntrans, intSize)
        Else
            strOutput = translate(intU, strUntrans, intSize)
        End If
        Return strOutput
    End Function


    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        txtInput.Copy()
        rtbOut.Copy()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        txtInput.Cut()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        txtInput.Paste()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("Iglatinpay Anslatortray created by Joshua Hitchcock", "About", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
