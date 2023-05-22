Imports System.Data.SqlClient

Public Class Form1
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dt As DataTable
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim str As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MarklistDataSet.marksheet' table. You can move, or remove it, as needed.
        Me.MarksheetTableAdapter.Fill(Me.MarklistDataSet.marksheet)
        conn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\folders\MIS\studentmarksheet\studentmarksheet\marklist.mdf;Integrated Security=True"
    End Sub

    Private Overloads Sub Insert(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()
        str = "insert into marksheet values('" & TextBox1.Text & "','" & TextBox2.Text & "' ,'" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "' , '" & TextBox8.Text & "' , '" & TextBox9.Text & "' ,'" & TextBox10.Text & "')"
        cmd = New SqlCommand(str, conn)
        If cmd.ExecuteNonQuery() Then
            MsgBox("successfully inserted")
        End If
        cmd.Dispose()

        conn.Close()
    End Sub

    Private Overloads Sub Update(sender As Object, e As EventArgs) Handles Button2.Click
        conn.Open()
        str = "update marksheet set Reg_no='" & TextBox2.Text & "', Name='" & TextBox1.Text & "' , Dept='" & TextBox3.Text & "',Tamil='" & TextBox4.Text & "',English='" & TextBox5.Text & "', Maths='" & TextBox6.Text & "', Science='" & TextBox7.Text & "' , Social='" & TextBox8.Text & "', Average='" & TextBox9.Text & "', Result='" & TextBox10.Text & "' where Regno =" & TextBox2.Text & ""
        cmd = New SqlCommand(str, conn)
        If cmd.ExecuteNonQuery() Then
            MsgBox("successfully updated")
        End If
        cmd.Dispose()
        conn.Close()
    End Sub

    Private Overloads Sub Delete(sender As Object, e As EventArgs) Handles Button3.Click
        conn.Open()
        str = "Delete from marksheet where Reg_no='" & TextBox2.Text & "'"
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
        str = "select * from marksheet"
        cmd = New SqlCommand(str, conn)
        da = New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        DataGridView1.DataSource = dt
        cmd.Dispose()
        conn.Close()
    End Sub
    Private Sub Grade(sender As Object, e As EventArgs) Handles Button5.Click
        Dim sm1, sm2, sm3, sm4, sm5, total, avg As Integer
        sm1 = TextBox4.Text
        sm2 = TextBox5.Text
        sm3 = TextBox6.Text
        sm4 = TextBox7.Text
        sm5 = TextBox8.Text
        total = sm1 + sm2 + sm3 + sm4 + sm5
        avg = total / 5
        TextBox9.Text = avg

        If sm1 > 100 Or sm2 > 100 Or sm3 > 100 Or sm4 > 100 Or sm5 > 100 Then
            MsgBox("Enter mark out Of 100")
        End If
        If sm1 > 34 And sm2 > 34 And sm3 > 34 And sm4 > 34 And sm5 < 34 Then
            TextBox9.Text = ""
            TextBox10.Text = "Fail"
        ElseIf sm1 > 34 And sm2 > 34 And sm3 > 34 And sm4 < 34 And sm5 > 34 Then
            TextBox9.Text = ""
            TextBox10.Text = "Fail"
        End If

        If sm1 > 34 Then
            If sm2 > 34 Then
                If sm3 > 34 Then
                    If sm4 > 34 Then
                        If sm5 > 34 Then
                            TextBox10.Text = "Pass"
                        Else
                            TextBox9.Text = ""
                            TextBox10.Text = "Fail"
                        End If
                    Else
                        TextBox9.Text = ""
                        TextBox10.Text = "Fail"
                    End If
                Else
                    TextBox9.Text = ""
                    TextBox10.Text = "Fail"
                End If
            Else
                TextBox9.Text = ""
                TextBox10.Text = "Fail"
            End If
        Else
            TextBox9.Text = ""
            TextBox10.Text = "Fail"
        End If

    End Sub
End Class
