Imports System.Runtime.InteropServices

Module ChromaAnimationAPI

#If X64 Then
    Const DLL_NAME As String = "CChromaEditorLibrary64"
#Else
    Const DLL_NAME As String = "CChromaEditorLibrary"
#End If

    REM /// <summary>
    REM /// Return the sum of colors
    REM /// EXPORT_API int PluginAddColor(const int color1, const int color2);
    REM /// </summary>
    <DllImport(DLL_NAME, CallingConvention:=CallingConvention.Cdecl)>
    Private Function PluginAddColor(color1 As Integer, color2 As Integer) As Integer
    End Function

    REM /// <summary>
    REM /// Return the sum of colors
    REM /// </summary>
    Public Function AddColor(color1 As Integer, color2 As Integer) As Integer
        Dim result As Integer = PluginAddColor(color1, color2)
        Return result
    End Function

End Module
