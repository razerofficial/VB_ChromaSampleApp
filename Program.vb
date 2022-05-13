Imports VB_ChromaSampleApp.ChromaSDK
Imports System
Imports System.Threading

Module Program

    Private Const MAX_ITEMS As Integer = 47

    Private Function PrintLegend(app As SampleApp, selectedIndex As Integer, supportsStreaming As Boolean, platform As Byte)

        Console.WriteLine("VB CHROMA SAMPLE APP")
        Console.WriteLine("Use `UP` and `DOWN` arrows to select an animation and press `ENTER` to execute.")
        If (supportsStreaming) Then
            Console.Write("Use `P` to switch streaming platforms. ")
        End If
        Console.WriteLine("Use `ESC` to QUIT.")

        Dim startIndex As Integer = 1

        If (supportsStreaming) Then
            startIndex = -9
            Console.WriteLine("Streaming Info (SUPPORTED):")
            Dim status As ChromaSDK.Stream.StreamStatusType = ChromaAnimationAPI.CoreStreamGetStatus()
            Console.WriteLine(String.Format("Status: {0}", ChromaAnimationAPI.CoreStreamGetStatusString(status)))
            Console.WriteLine(String.Format("Shortcode: {0}", app.GetShortcode()))
            Console.WriteLine(String.Format("Stream Id: {0}", app.GetStreamId()))
            Console.WriteLine(String.Format("Stream Key: {0}", app.GetStreamKey()))
            Console.WriteLine(String.Format("Stream Focus: {0}", app.GetStreamFocus()))
            Console.WriteLine()
        End If

        For index As Integer = startIndex To MAX_ITEMS Step 1
            If index.Equals(selectedIndex) Then
                Console.Write("[*] ")
            Else
                Console.Write("[ ] ")
            End If
            Console.Write("{0, 8}", app.GetEffectName(index, platform))

            If (index > 0) Then
                If (index Mod 4).Equals(0) Then
                    Console.WriteLine()
                Else
                    Console.Write(ControlChars.Tab & ControlChars.Tab)
                End If
            End If
        Next

        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("Press ENTER to play selection.")
        Return Nothing
    End Function

    Sub Main()

        Dim sampleApp As SampleApp = New SampleApp()
        sampleApp.Start()

        If sampleApp.GetInitResult().Equals(RazerErrors.RZRESULT_SUCCESS) Then

            Dim supportsStreaming As Boolean = ChromaAnimationAPI.CoreStreamSupportsStreaming()

            Dim startIndex As Integer = 1

            If supportsStreaming Then
                startIndex = -9
            End If

            Dim selectedIndex As Integer = 1

            If supportsStreaming Then
                selectedIndex = -9
            End If

            Dim platform As Byte = 0

            Dim inputTimer As DateTime = DateTime.MinValue

            While (True)
                If inputTimer < DateTime.Now Then
                    Console.Clear()
                    PrintLegend(sampleApp, selectedIndex, supportsStreaming, platform)
                    inputTimer = DateTime.Now + TimeSpan.FromMilliseconds(100)
                End If
                Dim keyInfo As ConsoleKeyInfo = Console.ReadKey()

                If keyInfo.Key.Equals(ConsoleKey.UpArrow) Then
                    If selectedIndex > startIndex Then
                        selectedIndex = selectedIndex - 1
                    End If
                ElseIf keyInfo.Key.Equals(ConsoleKey.DownArrow) Then
                    If selectedIndex < MAX_ITEMS Then
                        selectedIndex = selectedIndex + 1
                    End If
                ElseIf keyInfo.Key.Equals(ConsoleKey.Escape) Then
                    Exit While
                ElseIf keyInfo.Key.Equals(ConsoleKey.P) Then
                    platform = (platform + 1) Mod 4 REM PC, AMAZON LUNA, MS GAME PASS, NVIDIA GFN
                ElseIf keyInfo.Key.Equals(ConsoleKey.Enter) Then
                    sampleApp.ExecuteItem(selectedIndex, supportsStreaming, platform)
                End If
                Thread.Sleep(1)
            End While

            sampleApp.OnApplicationQuit()

        End If

        Console.WriteLine("{0}", "C# Chroma Sample App [EXIT]")

    End Sub

End Module
