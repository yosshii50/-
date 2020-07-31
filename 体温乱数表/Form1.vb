Public Class Form1

    Dim LabelCtlList As List(Of Label)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LabelCtlList = CreateLabelControl(Me, Label1)

    End Sub

    Private Function CreateLabelControl(ByVal BaseForm As Form, ByVal BaseControl As Label) As List(Of Label)

        Dim WrkList As New List(Of Label)
        WrkList.Add(BaseControl)

        For WrkY As Integer = 0 To 10
            For WrkX As Integer = 0 To 10

                Dim WrkControl As Label

                '左上端は基準コントロールなので何もしない
                If WrkY = 0 And WrkX = 0 Then
                    Continue For
                End If

                'コントロール生成
                WrkControl = New Label
                WrkList.Add(WrkControl)

                If WrkY = 0 Then
                    '列タイトルの番号
                    WrkControl.Text = WrkX
                ElseIf WrkX = 0 Then
                    '行タイトルの番号
                    WrkControl.Text = WrkY
                End If

                WrkControl.AutoSize = WrkList(0).AutoSize
                WrkControl.BorderStyle = WrkList(0).BorderStyle
                WrkControl.TextAlign = WrkList(0).TextAlign
                WrkControl.Size = WrkList(0).Size

                WrkControl.Location = New Point(WrkList(0).Left + WrkX * WrkList(0).Width, WrkList(0).Top + WrkY * WrkList(0).Height)

                'フォームに追加
                BaseForm.Controls.Add(WrkControl)
            Next
        Next

        Return WrkList
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Call ResetLabelTest(LabelCtlList, CDbl(TextBox1.Text), CDbl(TextBox2.Text), CDbl(TextBox3.Text))

    End Sub

    Private Sub ResetLabelTest(ByVal WrkList As List(Of Label), ByVal StartNo As Double, ByVal EndNo As Double, ByVal StepNo As Double)

        Static rnd As New System.Random(Now.Second * 100 + Now.Minute + Now.Hour)

        For Each WrkLabel As Label In WrkList

            If WrkList(0).Top = WrkLabel.Top Then
                Continue For
            End If
            If WrkList(0).Left = WrkLabel.Left Then
                Continue For
            End If

            Dim TmpDbl As Double

            TmpDbl = EndNo - StartNo
            TmpDbl = TmpDbl / StepNo
            TmpDbl = Math.Truncate(TmpDbl)
            TmpDbl = rnd.Next(TmpDbl + 1)
            TmpDbl = TmpDbl * StepNo
            TmpDbl = StartNo + TmpDbl

            WrkLabel.Text = TmpDbl

        Next

    End Sub

End Class
