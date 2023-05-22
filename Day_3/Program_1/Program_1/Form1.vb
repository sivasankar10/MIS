Imports System.Data.SqlClient

Public Class Form1
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dt As DataTable
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim str As String
    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DetailsDataSet1.details' table. You can move, or remove it, as needed.
        Me.DetailsTableAdapter.Fill(Me.DetailsDataSet1.details)
        conn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\folders\MIS\Program_1\Program_1\details.mdf;Integrated Security=True"
    End Sub
    Private Overloads Sub Insert(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()
        str = "insert into details values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "', '" & DateTimePicker1.Value.Date & "', '" & RichTextBox1.Text & "' , '" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "' , '" & RichTextBox2.Text & "' )"
        cmd = New SqlCommand(str, conn)
        If cmd.ExecuteNonQuery() Then
            MsgBox("successfully inserted")
        End If
        cmd.Dispose()

        conn.Close()
    End Sub
    Private Overloads Sub Update(sender As Object, e As EventArgs) Handles Button2.Click
        conn.Open()
        str = "update details set Name='" & TextBox1.Text & "', Regno=" & TextBox2.Text & "  where Regno =" & TextBox2.Text & ""
        cmd = New SqlCommand(str, conn)
        If cmd.ExecuteNonQuery() Then
            MsgBox("successfully updated")
        End If
        cmd.Dispose()
        conn.Close()
    End Sub
    Private Overloads Sub Delete(sender As Object, e As EventArgs) Handles Button3.Click
        conn.Open()
        str = "Delete from details where Regno ='" & TextBox2.Text & "'"
        cmd = New SqlCommand(str, conn)
        If cmd.ExecuteNonQuery() Then
            MsgBox("successfully deleted")
        End If
        cmd.Dispose()
        conn.Close()
    End Sub
    Private Overloads Sub View(sender As Object, e As EventArgs) Handles Button4.Click
        DataGridView1.Visible = True
        conn.Open()
        str = "select * from details"
        cmd = New SqlCommand(str, conn)
        da = New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        DataGridView1.DataSource = dt
        cmd.Dispose()
        conn.Close()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub
End Class
