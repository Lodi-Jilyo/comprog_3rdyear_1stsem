Public Class Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Username cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MessageBox.Show("Age cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Please select a gender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If String.IsNullOrWhiteSpace(TextBox5.Text) Then
            MessageBox.Show("Address cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If ComboBox2.SelectedIndex = -1 Then
            MessageBox.Show("Please select an event type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If String.IsNullOrWhiteSpace(TextBox4.Text) Then
            MessageBox.Show("Number of guests cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim pricePerDay As Double = 10000
        Dim totalPrice As Double = 0
        totalPrice += pricePerDay
        'THing
        Dim selectedServices As New List(Of String)
        If chkCatering.Checked Then
            selectedServices.Add("Catering")
            totalPrice += 20000 ' Catering cost
        End If

        If chkClown.Checked Then
            selectedServices.Add("Clown")
            totalPrice += 10000 ' Clown cost
        End If

        If chkSinger.Checked Then
            selectedServices.Add("Singer")
            totalPrice += 7000 ' Singer cost
        End If

        If chkDancer.Checked Then
            selectedServices.Add("Dancer")
            totalPrice += 7000 ' Dancer cost
        End If

        If chkVideoke.Checked Then
            selectedServices.Add("Videoke")
            totalPrice += 1000 ' Videoke cost
        End If
        Dim noOfGuests As Double
        If Double.TryParse(TextBox4.Text, noOfGuests) Then
            Dim multiplierfr As Double = Math.Ceiling(noOfGuests / 50)
            totalPrice *= multiplierfr

        End If

        Dim selectedDateBday As DateTime = DateTimePicker1.Value
        Dim selectedDateEventDate As DateTime = DateTimePicker2.Value
        For Each student As Form1.Customer In Form1.listCustomer
            If student.GetEventDate().Date = selectedDateEventDate.Date Then
                MessageBox.Show("The event date is already taken by another student. Please select a different date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            If student.GetName() = TextBox1.Text AndAlso student.GetPass() = TextBox2.Text Then
                MessageBox.Show("A user with the same name and password already exists. Please use different credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Next
        Dim paymentAmount As String = InputBox("Price is: " & totalPrice, "Payment")

        If Not String.IsNullOrWhiteSpace(paymentAmount) AndAlso IsNumeric(paymentAmount) Then
            Dim amount As Decimal = Decimal.Parse(paymentAmount)
            If amount >= totalPrice Then
                MessageBox.Show("Payment successful! Change: " & (amount - totalPrice).ToString("C"), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)


                Dim newCustomer As New Form1.Customer
                newCustomer.SetUserCredentials(TextBox1.Text, TextBox2.Text)
                newCustomer.SetInfo(TextBox3.Text, ComboBox1.Text, TextBox5.Text)
                newCustomer.SetEventInfo(ComboBox2.Text, TextBox4.Text)
                newCustomer.SetBirthDate(selectedDateBday)
                newCustomer.SetEventDate(selectedDateEventDate)
                newCustomer.SetServices(selectedServices)

                Form1.listCustomer.Add(newCustomer)
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                ComboBox1.SelectedIndex = -1
                TextBox5.Clear()
                DateTimePicker1.Value = DateTime.Now
                DateTimePicker2.Value = DateTime.Now
                Me.Close()
            Else
                MessageBox.Show("Insufficient Payment. Please pay at least: " & totalPrice.ToString("C"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Else
            MessageBox.Show("Invalid payment amount entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Form1.TextBox1.Clear()
        Form1.TextBox2.Clear()
    End Sub

    '---------FOR DESIGN--------
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MinimizeBox = False
        Me.MaximizeBox = False

        '------
        Me.BackColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")
        Panel1.BackColor = Drawing.ColorTranslator.FromHtml("#112D4E")
        Panel2.BackColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")
        Panel3.BackColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")

        Label11.ForeColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")
        Label12.ForeColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")
        Label15.ForeColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")

        Button1.BackColor = Drawing.ColorTranslator.FromHtml("#3F72AF")
        Button1.ForeColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")

        'Radius
        Dim radius As Integer = 20 ' Adjust the corner radius
        Dim borderColor As Color = Drawing.ColorTranslator.FromHtml("#112D4E")
        Dim borderWidth As Integer = 3 ' Adjust the border thickness

        ApplyRoundedCornersWithBorder(Panel2, radius, borderColor, borderWidth)
        ApplyRoundedCornersWithBorder(Panel3, radius, borderColor, borderWidth)

        ApplyRoundedCorners(Button1, 20, Color.Black, 5)
    End Sub

    'Button Hover
    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Dim btn As Button = CType(sender, Button)
        btn.BackColor = Drawing.ColorTranslator.FromHtml("#F9F7F7")
        btn.ForeColor = Drawing.ColorTranslator.FromHtml("#112D4E")
    End Sub
    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
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