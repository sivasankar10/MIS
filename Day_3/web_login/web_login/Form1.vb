Imports System.Data.SqlClient
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dt As DataTable
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim str As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet.login_view' table. You can move, or remove it, as needed.
        Me.Login_viewTableAdapter.Fill(Me.Database1DataSet.login_view)
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\folders\MIS\web_login\web_login\Database1.mdf;Integrated Security=True"

    End Sub
    Private Overloads Sub Login(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()
        str = "Select * from login_view where Username='" & TextBox1.Text & "' and Password ='" & TextBox2.Text & "'"
        cmd = New SqlCommand(str, con)
        da = New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        If (dt.Rows.Count > 0) Then
            MsgBox("Entry accessed")
            Form2.Show()
        Else
            MsgBox("Invalid Username & Password")
        End If
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        con.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
