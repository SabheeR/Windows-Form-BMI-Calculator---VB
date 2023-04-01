Imports System.Formats
Imports System.Timers

Public Class Form1
    Private tmr As Timer = New Timer()
    'Private Sub Timer(sender As Object, e As EventArgs) Handles Me.Shown
    '    tmr.Interval = 2000
    '    tmr.Start()
    'AddHandler() tmr.Elapsed, AddressOf tmr_Tick
    'End Sub
    'Private Sub tmr_Tick(ByVal sender As Object, ByVal e As EventArgs)
    '    tmr.Stop()
    '    Home.Show()
    'Me.Close()
    'End Sub
    Private Sub SplashScreen1_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.Refresh()
        System.Threading.Thread.Sleep(2000)
        Home.Show()
        Me.Hide()
    End Sub
End Class
