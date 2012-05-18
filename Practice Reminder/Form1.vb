Public Class Form1
    'Settings dialog button
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dialog1.ShowDialog()
    End Sub
    'timer to run the different parts of the program
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        tpsf()
        petw()
        Labls()
        practice()
        howmuch()
        autoerease()
        My.Settings.Save()

    End Sub
    'button to show the form in the system tray icon's right click menu
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    'button to exit from the system tray icon's right click menu
    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Me.Show()
    End Sub
    'finds the minutes that have currently been practiced this week
    Private Sub tpsf()
        Label16.Text = Val(Label8.Text) + Val(Label9.Text) + Val(Label10.Text) + Val(Label11.Text) + Val(Label12.Text) + Val(Label13.Text) + Val(Label14.Text)

    End Sub
    'tells if your done practicing for the week
    Private Sub petw()
        If Val(Label16.Text) = My.Settings.mintopractice = True Then
            Label17.Text = "You're done practicing for the week."
        Else
            Label17.Text = "You still need to practice this week."
        End If
    End Sub
    'figures out which day it is to set the time that has been practiced today and preforms validation to make sure there is a number in the text box
    Private Sub mpt()
        If Now.DayOfWeek = DayOfWeek.Monday And String.IsNullOrEmpty(TextBox1.Text) = False Then My.Settings.mon = TextBox1.Text
        If Now.DayOfWeek = DayOfWeek.Tuesday And String.IsNullOrEmpty(TextBox1.Text) = False Then My.Settings.tue = TextBox1.Text
        If Now.DayOfWeek = DayOfWeek.Wednesday And String.IsNullOrEmpty(TextBox1.Text) = False Then My.Settings.wed = TextBox1.Text
        If Now.DayOfWeek = DayOfWeek.Thursday And String.IsNullOrEmpty(TextBox1.Text) = False Then My.Settings.thu = TextBox1.Text
        If Now.DayOfWeek = DayOfWeek.Friday And String.IsNullOrEmpty(TextBox1.Text) = False Then My.Settings.fri = TextBox1.Text
        If Now.DayOfWeek = DayOfWeek.Saturday And String.IsNullOrEmpty(TextBox1.Text) = False Then My.Settings.sat = TextBox1.Text
        If Now.DayOfWeek = DayOfWeek.Sunday And String.IsNullOrEmpty(TextBox1.Text) = False Then My.Settings.sun = TextBox1.Text
        If String.IsNullOrEmpty(TextBox1.Text) Then MsgBox("Enter a number first!", , "Enter a number!!!")
    End Sub
    'shows how much you've practiced today
    Private Sub Labls()
        Label8.Text = My.Settings.mon
        Label9.Text = My.Settings.tue
        Label10.Text = My.Settings.wed
        Label11.Text = My.Settings.thu
        Label12.Text = My.Settings.fri
        Label13.Text = My.Settings.sat
        Label14.Text = My.Settings.sun

    End Sub
    'tells when its time to practice
    Private Sub practice()
        If My.Settings.tmr = Now.ToLongTimeString And Val(Label16.Text) = My.Settings.mintopractice = False Then
            Dialog2.Show()

        End If
    End Sub
    'hides this form
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub
    'sets todays practice time to the value in textbox1
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        mpt()
    End Sub
    'show how much to practice each day
    Private Sub howmuch()
        'label20
        Label20.Text = Val(My.Settings.mintopractice) \ (7 - Val(Now.DayOfWeek))
    End Sub
    'automatically erases the values on monday 
    Private Sub autoerease()
        If Now.DayOfWeek = DayOfWeek.Monday And Now.ToLongTimeString = "1:00:00 AM" Then
            My.Settings.mon = Val("0")
            My.Settings.tue = Val("0")
            My.Settings.wed = Val("0")
            My.Settings.thu = Val("0")
            My.Settings.fri = Val("0")
            My.Settings.sat = Val("0")
            My.Settings.sun = Val("0")
        End If
    End Sub

End Class
