Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tempInfo() As String = Form1.customerCurrentUser.GetInfo
        Dim tempEventInfo() As String = Form1.customerCurrentUser.GetEventInfo
        Dim selectedServices As List(Of String) = Form1.customerCurrentUser.GetServices()
        Label8.Text = Form1.customerCurrentUser.GetName
        Label5.Text = tempInfo(0)
        Label6.Text = tempInfo(1)
        Label7.Text = tempInfo(2)
        Label9.Text = Form1.customerCurrentUser.GetBirthDate().ToShortDateString()
        Label14.Text = Form1.customerCurrentUser.GetEventDate().ToShortDateString()

        'event stuff
        Label11.Text = tempEventInfo(0)
        Label12.Text = tempEventInfo(1)
        Label13.Text = String.Join(Environment.NewLine, selectedServices)
        Label13.Visible = True

        Label9.Visible = True
        Label8.Visible = True
        Label5.Visible = True
        Label6.Visible = True
        Label7.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.TextBox1.Clear()
        Form1.TextBox2.Clear()
        Form1.Show()
        Me.Close()
    End Sub

    '---------FOR DESIGN--------
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Button1.Text = " "

        Me.BackColor = Drawing.ColorTranslator.FromHtml("#3F72AF")
        Panel1.BackColor = Drawing.ColorTranslator.FromHtml("#112D4E")
        Panel2.BackColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")

        Label15.ForeColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")
        Label11.ForeColor = Drawing.ColorTranslator.FromHtml("#FADA7A")
        Label14.ForeColor = Drawing.ColorTranslator.FromHtml("#FADA7A")

        Button3.ForeColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")



        'Radius
        Dim radius As Integer = 20 ' Adjust the corner radius
        Dim borderColor As Color = Drawing.ColorTranslator.FromHtml("#112D4E")
        Dim borderWidth As Integer = 3 ' Adjust the border thickness

        ApplyRoundedCornersWithBorder(Panel2, radius, borderColor, borderWidth)

        'For Timer
        Dim delayTimer As New Timer()
        delayTimer.Interval = 500
        AddHandler delayTimer.Tick, Sub()
                                        Button1.PerformClick()
                                        delayTimer.Stop()
                                    End Sub
        delayTimer.Start()
    End Sub

    'Button Hover
    Private Sub Button3_MouseEnter(sender As Object, e As EventArgs) Handles Button3.MouseEnter
        Dim btn As Button = CType(sender, Button)
        btn.BackColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")
        btn.ForeColor = Drawing.ColorTranslator.FromHtml("#112D4E")
    End Sub
    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Dim btn As Button = CType(sender, Button)
        btn.BackColor = Drawing.ColorTranslator.FromHtml("#112D4E")
        btn.ForeColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")
    End Sub

    '----------Design Functions----------
    'Panel Radius
    Private Sub ApplyRoundedCornersWithBorder(panel As Panel, radius As Integer, borderColor As Color, borderWidth As Integer)
        Dim path As New Drawing2D.GraphicsPath()
        Dim rect As New Rectangle(0, 0, panel.Width, panel.Height)

        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90) ' Top-left
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90) ' Top-right
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90) ' Bottom-right
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90) ' Bottom-left
        path.CloseFigure()

        panel.Region = New Region(path)

        AddHandler panel.Paint, Sub(sender As Object, e As PaintEventArgs)
                                    Using borderPen As New Pen(borderColor, borderWidth)
                                        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                                        Dim borderRect = New Rectangle(borderWidth \ 2, borderWidth \ 2, panel.Width - borderWidth, panel.Height - borderWidth)
                                        e.Graphics.DrawPath(borderPen, CreateRoundedRectanglePath(borderRect, radius))
                                    End Using
                                End Sub
    End Sub

    Private Function CreateRoundedRectanglePath(rect As Rectangle, radius As Integer) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath()
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90) ' Top-left
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90) ' Top-right
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90) ' Bottom-right
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90) ' Bottom-left
        path.CloseFigure()
        Return path
    End Function
End Class