Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dt As DataTable
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim str As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PayrollDataSet.payroll_emp' table. You can move, or remove it, as needed.
        Me.Payroll_empTableAdapter.Fill(Me.PayrollDataSet.payroll_emp)
        conn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\folders\MIS\Employee_PsyRoll\Employee_PsyRoll\Payroll.mdf;Integrated Security=True"

    End Sub

    Private Overloads Sub Insert(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()
        str = "insert into payroll_emp values('" & TextBox1.Text & "','" & TextBox2.Text & "' ,'" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "' , '" & TextBox8.Text & "' )"
        cmd = New SqlCommand(str, conn)
        If cmd.ExecuteNonQuery() Then
            MsgBox("successfully inserted")
        End If
        cmd.Dispose()

        conn.Close()
    End Sub

    Private Overloads Sub Update(sender As Object, e As EventArgs) Handles Button2.Click
        conn.Open()
        str = "update payroll_emp set Emp_ID='" & TextBox1.Text & "', Emp_Name='" & TextBox2.Text & "' , Basic_Pay='" & TextBox3.Text & "',HRA='" & TextBox4.Text & "',DA='" & TextBox5.Text & "',PF='" & TextBox6.Text & "',Gross_Pay='" & TextBox7.Text & "' , Net_Pay='" & TextBox8.Text & "' where Emp_ID =" & TextBox1.Text & ""
        cmd = New SqlCommand(str, conn)
        If cmd.ExecuteNonQuery() Then
            MsgBox("successfully updated")
        End If
        cmd.Dispose()
        conn.Close()
    End Sub

    Private Overloads Sub Delete(sender As Object, e As EventArgs) Handles Button3.Click
        conn.Open()
        str = "Delete from payroll_emp where Emp_ID ='" & TextBox1.Text & "'"
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
        str = "select * from payroll_emp"
        cmd = New SqlCommand(str, conn)
        da = New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        DataGridView1.DataSource = dt
        cmd.Dispose()
        conn.Close()
    End Sub

    Private Overloads Sub Calculate(sender As Object, e As EventArgs) Handles Button5.Click
        Dim BP, HRA, DA, PF, total, add As Integer
        BP = TextBox3.Text
        HRA = TextBox4.Text
        DA = TextBox5.Text
        PF = TextBox6.Text
        total = BP + HRA + DA
        TextBox7.Text = total
        add = PF + total
        TextBox8.Text = add
    End Sub
End Class
