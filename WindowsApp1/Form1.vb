Imports DirectShowLib

Imports System.Runtime.InteropServices
Public Class Form1
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim hr As Integer

        Dim ev As EventCode

        Dim fg As FilterGraph

        Dim ifg2 As IFilterGraph2

        Dim imc As IMediaControl

        Dim ime As IMediaEvent

        ' Get a filtergraph object

        fg = New FilterGraph

        ifg2 = DirectCast(fg, IFilterGraph2)

        ' Get the IMediaControl interface from the fg object

        imc = DirectCast(fg, IMediaControl)

        ' Get the IMediaEvent interface from the fg object

        ime = DirectCast(fg, IMediaEvent)

        ' Build the graph
        'E:\keyfc\Air\动画\[FLsnow][DVDRIP][AIR][Collection]\MAIN MOVIE\[FLsnow][AIR TV][DVDRip][03][XVID+MP3].mkv

        hr = ifg2.RenderFile("C:\Users\15388\Videos\Captures\aa.avi", "")

        DsError.ThrowExceptionForHR(hr)

        ' Run the graph

        hr = imc.Run()

        DsError.ThrowExceptionForHR(hr)

        ' Wait for the entire file to finish playing

        hr = ime.WaitForCompletion(-1, ev)

        DsError.ThrowExceptionForHR(hr)

        ' Release the graph (and all its interfaces)

        Marshal.ReleaseComObject(fg)

    End Sub


End Class
