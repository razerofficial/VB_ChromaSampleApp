Imports VB_ChromaSampleApp.ChromaSDK
Imports System
Imports System.Threading

Module Program

    Private Const MAX_ITEMS As Integer = 47

    Private Function PrintLegend(app As SampleApp, selectedIndex As Integer)

        Console.WriteLine("VB CHROMA SAMPLE APP")
        Console.WriteLine()
        Console.WriteLine("Use UP and DOWN arrows to select an animation and press ENTER.")
        Console.WriteLine()

        Dim startIndex As Integer = 1

        If (ChromaAnimationAPI.CoreStreamSupportsStreaming()) Then
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
            Console.Write("{0, 8}", app.GetEffectName(index))

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

        Dim startIndex As Integer = 1

        If ChromaAnimationAPI.CoreStreamSupportsStreaming() Then
            startIndex = -9
        End If

        If sampleApp.GetInitResult().Equals(RazerErrors.RZRESULT_SUCCESS) Then
            Dim selectedIndex As Integer = 1

            If (ChromaAnimationAPI.CoreStreamSupportsStreaming()) Then
                selectedIndex = -9
            End If

            Dim inputTimer As DateTime = DateTime.MinValue

            While (True)
                If inputTimer < DateTime.Now Then
                    Console.Clear()
                    PrintLegend(sampleApp, selectedIndex)
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
                ElseIf keyInfo.Key.Equals(ConsoleKey.Enter) Then
                    sampleApp.ExecuteItem(selectedIndex)
                End If
                Thread.Sleep(1)
            End While

            ChromaAnimationAPI.StopAll()
            ChromaAnimationAPI.CloseAll()
            sampleApp.OnApplicationQuit()

        End If

        Console.WriteLine("{0}", "C# Chroma Sample App [EXIT]")

    End Sub

End Module
