Imports System.IO
Public Class Form1
    Dim table As New DataTable()
    Dim rowCount As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DataGridView1.Rows.Add(TextBox1.Text, TextBox2.Text, TextBox3.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim writer As TextWriter = New StreamWriter("D:\data.txt")
        Dim success As Boolean = False
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 2 Step +1
                For j As Integer = 0 To DataGridView1.Columns.Count - 1 Step +1
                    writer.Write(vbTab & DataGridView1.Rows(i).Cells(j).Value.ToString() & vbTab & "|")
                Next
                writer.WriteLine("")
            Next
            success = True
        Catch ex As Exception
            success = False
        End Try

        writer.Close()

        If success Then
            MessageBox.Show("Data Exported successfully")
        Else
            MessageBox.Show("Error exporting data")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim lines() As String
        Dim vals() As String

        lines = File.ReadAllLines("D:\data.txt")
        For i As Integer = 0 To lines.Length - 1 Step +1
            vals = lines(i).ToString().Split("|")
            Dim row(vals.Length - 1) As String

            For j As Integer = 0 To vals.Length - 1 Step +1
                row(j) = vals(j).Trim()
            Next
            DataGridView1.Rows.Add(row)
        Next
    End Sub
    Private Sub DisplayRowCount()
        If DataGridView1 IsNot Nothing Then
            rowCount = DataGridView1.RowCount - 1
            Label6.Text = rowCount.ToString()
        Else
            MessageBox.Show("DataGridView1 is not initialized.")
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayRowCount()
    End Sub

    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        DisplayRowCount()
    End Sub
End Class
