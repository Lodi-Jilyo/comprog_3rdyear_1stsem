Imports System.Drawing.Drawing2D
Imports Microsoft.Win32

Public Class Form1
    Public listCustomer As New List(Of Customer)
    Public customerCurrentUser As Customer

    Public Sub New()
        InitializeComponent()
        Dim cust1 As New Customer("Jose", "1234", 18, New DateTime(2003, 12, 1), "Male", "Gyattown",
                                 "Wedding", 100, New DateTime(2025, 12, 1))
        Dim cust2 As New Customer("Juana", "abcd", 18, New DateTime(2002, 12, 1), "Female", "Skibidi",
                                 "Birthday", 300, New DateTime(2024, 12, 1))
        Dim cust3 As New Customer("Me", "aguy", 18, New DateTime(2001, 12, 1), "Male", "Ohio",
                                 "Wedding", 200, New DateTime(2025, 12, 5))

        cust1.SetServices(New List(Of String) From {"Catering", "Videoke"})
        cust2.SetServices(New List(Of String) From {"Clown", "Singer"})
        cust3.SetServices(New List(Of String) From {"Catering", "Dancer", "Videoke"})
        listCustomer.Add(cust1)
        listCustomer.Add(cust2)
        listCustomer.Add(cust3)
    End Sub

    Class Customer
        Private services As New List(Of String)
        Private strName As String
        Private strPass As String
        Private dblAgeNo As String
        Private strSex As String
        Private strAddress As String
        Private dtpBirthday As DateTime

        'Event stuff
        Private strType As String
        Private dblNoGuests As String
        Private dtpEventDate As DateTime
        Public Sub New(ByVal strTempName As String, ByVal strTempPass As String, ByVal Age As String, ByVal BirthdayDate As DateTime, ByVal Sex As String, ByVal Address As String,
                       ByVal Type As String, ByVal NoGuests As String, ByVal EventDate As DateTime)
            strName = strTempName
            strPass = strTempPass
            dblAgeNo = Age
            dtpBirthday = BirthdayDate
            strSex = Sex
            strAddress = Address

            'Event Stuff
            strType = Type
            dblNoGuests = NoGuests
            dtpEventDate = EventDate

        End Sub
        Public Sub New()

        End Sub

        'test
        Public Sub SetServices(selectedServices As List(Of String))
            services = selectedServices
        End Sub

        Public Function GetServices() As List(Of String)
            Return services
        End Function

        Public Sub SetUserCredentials(ByVal strTempName As String, ByVal strTempPass As String)
            strName = strTempName
            strPass = strTempPass
        End Sub
        Public Sub SetInfo(ByVal Age As String, ByVal Sex As String, ByVal Address As String)
            dblAgeNo = Age
            strSex = Sex
            strAddress = Address
        End Sub
        'event stuff
        Public Sub SetEventInfo(ByVal Type As String, ByVal NoGuests As String)
            strType = Type
            dblNoGuests = NoGuests
        End Sub

        'event stuff
        Public Sub SetEventDate(ByVal EventDate As DateTime)
            dtpEventDate = EventDate
        End Sub
        Public Sub SetBirthDate(ByVal BirthdayDate As DateTime)
            dtpBirthday = BirthdayDate
        End Sub
        Public Function GetName() As String

            Return strName
        End Function
        Public Function GetPass() As String

            Return strPass
        End Function

        Public Function GetInfo() As Array
            Dim arrayInfo(3) As String
            arrayInfo(0) = dblAgeNo
            arrayInfo(1) = strSex
            arrayInfo(2) = strAddress
            Return arrayInfo
        End Function
        'event stuff
        Public Function GetEventInfo() As Array
            Dim arrayEventInfo(2) As String
            arrayEventInfo(0) = strType
            arrayEventInfo(1) = dblNoGuests
            Return arrayEventInfo
        End Function
        'event stuff
        Public Function GetEventDate() As DateTime
            Return dtpEventDate
        End Function
        Public Function GetBirthDate() As DateTime
            Return dtpBirthday

        End Function
    End Class

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Username cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim intCounter = 0
        Do While intCounter < listCustomer.Count
            If TextBox1.Text = listCustomer(intCounter).GetName() And TextBox2.Text = listCustomer(intCounter).GetPass() Then
                MsgBox("Log-in Success")
                Form2.Show()
                Me.Hide()
                customerCurrentUser = listCustomer(intCounter)
                Return
            End If
            intCounter += 1
        Loop

        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form3.ShowDialog()
    End Sub

    '-----------For Design
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        'Colors
        Me.BackColor = Drawing.ColorTranslator.FromHtml("#DBE2EF")
        Panel1.BackColor = Drawing.ColorTranslator.FromHtml("#112D4E")
        Panel2.BackColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")

        Label1.ForeColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")

        Button1.BackColor = Drawing.ColorTranslator.FromHtml("#3F72AF")
        Button1.ForeColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")
        Button2.ForeColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")

        'Radius
        Dim radius As Integer = 20 ' Adjust the corner radius
        Dim borderColor As Color = Drawing.ColorTranslator.FromHtml("#112D4E")
        Dim borderWidth As Integer = 3 ' Adjust the border thickness

        ApplyRoundedCornersWithBorder(Panel2, radius, borderColor, borderWidth)

        ApplyRoundedCorners(Button1, 20, Color.Black, 5)
    End Sub

    'Button Hover
    Private Sub Button_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter, Button2.MouseEnter
        Dim btn As Button = CType(sender, Button)
        btn.BackColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")
        btn.ForeColor = Drawing.ColorTranslator.FromHtml("#3F72AF")
    End Sub
    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Dim btn As Button = CType(sender, Button)
        btn.BackColor = Drawing.ColorTranslator.FromHtml("#3F72AF")
        btn.ForeColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")
    End Sub
    Private Sub Button_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
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

    'Button Radius
    Private Sub ApplyRoundedCorners(button As Button, radius As Integer, borderColor As Color, borderWidth As Integer)
        Dim path As New Drawing2D.GraphicsPath()
        path.AddArc(0, 0, radius, radius, 180, 90) ' Top-left corner
        path.AddArc(button.Width - radius, 0, radius, radius, 270, 90) ' Top-right corner
        path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90) ' Bottom-right corner
        path.AddArc(0, button.Height - radius, radius, radius, 90, 90) ' Bottom-left corner
        path.CloseFigure()

        button.Region = New Region(path)

        AddHandler button.Paint, Sub(sender As Object, e As PaintEventArgs)
                                     e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                                     Using pen As New Pen(borderColor, borderWidth)
                                         e.Graphics.DrawPath(pen, path)
                                     End Using
                                 End Sub
    End Sub
End Class