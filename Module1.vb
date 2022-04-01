Imports VB_ChromaSampleApp.ChromaSDK

Module Module1

    Sub Main()

        Dim color1 As Integer = &HFF0000
        Dim color2 As Integer = &HFF
        Dim result As Integer = ChromaAnimationAPI.AddColor(color1, color2)

    End Sub

End Module
