Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Namespace ChromaSDK

    Public Class Keyboard

        REM //! Definitions of keys.
        Public Enum RZKEY
            RZKEY_ESC = &H1                 REM /*!< Esc (VK_ESCAPE) */
            RZKEY_F1 = &H3                  REM /*!< F1 (VK_F1) */
            RZKEY_F2 = &H4                  REM /*!< F2 (VK_F2) */
            RZKEY_F3 = &H5                  REM /*!< F3 (VK_F3) */
            RZKEY_F4 = &H6                  REM /*!< F4 (VK_F4) */
            RZKEY_F5 = &H7                  REM /*!< F5 (VK_F5) */
            RZKEY_F6 = &H8                  REM /*!< F6 (VK_F6) */
            RZKEY_F7 = &H9                  REM /*!< F7 (VK_F7) */
            RZKEY_F8 = &HA                  REM /*!< F8 (VK_F8) */
            RZKEY_F9 = &HB                  REM /*!< F9 (VK_F9) */
            RZKEY_F10 = &HC                 REM /*!< F10 (VK_F10) */
            RZKEY_F11 = &HD                 REM /*!< F11 (VK_F11) */
            RZKEY_F12 = &HE                 REM /*!< F12 (VK_F12) */
            RZKEY_1 = &H102                   REM /*!< 1 (VK_1) */
            RZKEY_2 = &H103                   REM /*!< 2 (VK_2) */
            RZKEY_3 = &H104                   REM /*!< 3 (VK_3) */
            RZKEY_4 = &H105                   REM /*!< 4 (VK_4) */
            RZKEY_5 = &H106                   REM /*!< 5 (VK_5) */
            RZKEY_6 = &H107                   REM /*!< 6 (VK_6) */
            RZKEY_7 = &H108                   REM /*!< 7 (VK_7) */
            RZKEY_8 = &H109                   REM /*!< 8 (VK_8) */
            RZKEY_9 = &H10A                   REM /*!< 9 (VK_9) */
            RZKEY_0 = &H10B                   REM /*!< 0 (VK_0) */
            RZKEY_A = &H302                   REM /*!< A (VK_A) */
            RZKEY_B = &H407                   REM /*!< B (VK_B) */
            RZKEY_C = &H405                   REM /*!< C (VK_C) */
            RZKEY_D = &H304                   REM /*!< D (VK_D) */
            RZKEY_E = &H204                   REM /*!< E (VK_E) */
            RZKEY_F = &H305                   REM /*!< F (VK_F) */
            RZKEY_G = &H306                   REM /*!< G (VK_G) */
            RZKEY_H = &H307                   REM /*!< H (VK_H) */
            RZKEY_I = &H209                   REM /*!< I (VK_I) */
            RZKEY_J = &H308                   REM /*!< J (VK_J) */
            RZKEY_K = &H309                   REM /*!< K (VK_K) */
            RZKEY_L = &H30A                   REM /*!< L (VK_L) */
            RZKEY_M = &H409                   REM /*!< M (VK_M) */
            RZKEY_N = &H408                   REM /*!< N (VK_N) */
            RZKEY_O = &H20A                   REM /*!< O (VK_O) */
            RZKEY_P = &H20B                   REM /*!< P (VK_P) */
            RZKEY_Q = &H202                   REM /*!< Q (VK_Q) */
            RZKEY_R = &H205                   REM /*!< R (VK_R) */
            RZKEY_S = &H303                   REM /*!< S (VK_S) */
            RZKEY_T = &H206                   REM /*!< T (VK_T) */
            RZKEY_U = &H208                   REM /*!< U (VK_U) */
            RZKEY_V = &H406                   REM /*!< V (VK_V) */
            RZKEY_W = &H203                   REM /*!< W (VK_W) */
            RZKEY_X = &H404                   REM /*!< X (VK_X) */
            RZKEY_Y = &H207                   REM /*!< Y (VK_Y) */
            RZKEY_Z = &H403                   REM /*!< Z (VK_Z) */
            RZKEY_NUMLOCK = &H112             REM /*!< Numlock (VK_NUMLOCK) */
            RZKEY_NUMPAD0 = &H513             REM /*!< Numpad 0 (VK_NUMPAD0) */
            RZKEY_NUMPAD1 = &H412             REM /*!< Numpad 1 (VK_NUMPAD1) */
            RZKEY_NUMPAD2 = &H413             REM /*!< Numpad 2 (VK_NUMPAD2) */
            RZKEY_NUMPAD3 = &H414             REM /*!< Numpad 3 (VK_NUMPAD3) */
            RZKEY_NUMPAD4 = &H312             REM /*!< Numpad 4 (VK_NUMPAD4) */
            RZKEY_NUMPAD5 = &H313             REM /*!< Numpad 5 (VK_NUMPAD5) */
            RZKEY_NUMPAD6 = &H314             REM /*!< Numpad 6 (VK_NUMPAD6) */
            RZKEY_NUMPAD7 = &H212             REM /*!< Numpad 7 (VK_NUMPAD7) */
            RZKEY_NUMPAD8 = &H213             REM /*!< Numpad 8 (VK_NUMPAD8) */
            RZKEY_NUMPAD9 = &H214             REM /*!< Numpad 9 (VK_ NUMPAD9*/
            RZKEY_NUMPAD_DIVIDE = &H113       REM /*!< Divide (VK_DIVIDE) */
            RZKEY_NUMPAD_MULTIPLY = &H114     REM /*!< Multiply (VK_MULTIPLY) */
            RZKEY_NUMPAD_SUBTRACT = &H115     REM /*!< Subtract (VK_SUBTRACT) */
            RZKEY_NUMPAD_ADD = &H215          REM /*!< Add (VK_ADD) */
            RZKEY_NUMPAD_ENTER = &H415        REM /*!< Enter (VK_RETURN - Extended) */
            RZKEY_NUMPAD_DECIMAL = &H514      REM /*!< Decimal (VK_DECIMAL) */
            RZKEY_PRINTSCREEN = &HF         REM /*!< Print Screen (VK_PRINT) */
            RZKEY_SCROLL = &H10              REM /*!< Scroll Lock (VK_SCROLL) */
            RZKEY_PAUSE = &H11               REM /*!< Pause (VK_PAUSE) */
            RZKEY_INSERT = &H10F              REM /*!< Insert (VK_INSERT) */
            RZKEY_HOME = &H110                REM /*!< Home (VK_HOME) */
            RZKEY_PAGEUP = &H111              REM /*!< Page Up (VK_PRIOR) */
            RZKEY_DELETE = &H20F              REM /*!< Delete (VK_DELETE) */
            RZKEY_END = &H210                 REM /*!< End (VK_END) */
            RZKEY_PAGEDOWN = &H211            REM /*!< Page Down (VK_NEXT) */
            RZKEY_UP = &H410                  REM /*!< Up (VK_UP) */
            RZKEY_LEFT = &H50F                REM /*!< Left (VK_LEFT) */
            RZKEY_DOWN = &H510                REM /*!< Down (VK_DOWN) */
            RZKEY_RIGHT = &H511               REM /*!< Right (VK_RIGHT) */
            RZKEY_TAB = &H201                 REM /*!< Tab (VK_TAB) */
            RZKEY_CAPSLOCK = &H301            REM /*!< Caps Lock(VK_CAPITAL) */
            RZKEY_BACKSPACE = &H10E           REM /*!< Backspace (VK_BACK) */
            RZKEY_ENTER = &H30E               REM /*!< Enter (VK_RETURN) */
            RZKEY_LCTRL = &H501               REM /*!< Left Control(VK_LCONTROL) */
            RZKEY_LWIN = &H502                REM /*!< Left Window (VK_LWIN) */
            RZKEY_LALT = &H503                REM /*!< Left Alt (VK_LMENU) */
            RZKEY_SPACE = &H507               REM /*!< Spacebar (VK_SPACE) */
            RZKEY_RALT = &H50B                REM /*!< Right Alt (VK_RMENU) */
            RZKEY_FN = &H50C                  REM /*!< Function key. */
            RZKEY_RMENU = &H50D               REM /*!< Right Menu (VK_APPS) */
            RZKEY_RCTRL = &H50E               REM /*!< Right Control (VK_RCONTROL) */
            RZKEY_LSHIFT = &H401              REM /*!< Left Shift (VK_LSHIFT) */
            RZKEY_RSHIFT = &H40E              REM /*!< Right Shift (VK_RSHIFT) */
            RZKEY_MACRO1 = &H100              REM /*!< Macro Key 1 */
            RZKEY_MACRO2 = &H200              REM /*!< Macro Key 2 */
            RZKEY_MACRO3 = &H300              REM /*!< Macro Key 3 */
            RZKEY_MACRO4 = &H400              REM /*!< Macro Key 4 */
            RZKEY_MACRO5 = &H500              REM /*!< Macro Key 5 */
            RZKEY_OEM_1 = &H101               REM /*!< ~ (tilde/半角/全角) (VK_OEM_3) */
            RZKEY_OEM_2 = &H10C               REM /*!< -- (minus) (VK_OEM_MINUS) */
            RZKEY_OEM_3 = &H10D               REM /*!< = (equal) (VK_OEM_PLUS) */
            RZKEY_OEM_4 = &H20C               REM /*!< [ (left sqaure bracket) (VK_OEM_4) */
            RZKEY_OEM_5 = &H20D               REM /*!< ] (right square bracket) (VK_OEM_6) */
            RZKEY_OEM_6 = &H20E               REM /*!< \ (backslash) (VK_OEM_5) */
            RZKEY_OEM_7 = &H30B               REM /*!< ; (semi-colon) (VK_OEM_1) */
            RZKEY_OEM_8 = &H30C               REM /*!< ' (apostrophe) (VK_OEM_7) */
            RZKEY_OEM_9 = &H40A               REM /*!< , (comma) (VK_OEM_COMMA) */
            RZKEY_OEM_10 = &H40B              REM /*!< . (period) (VK_OEM_PERIOD) */
            RZKEY_OEM_11 = &H40C              REM /*!< / (forward slash) (VK_OEM_2) */
            RZKEY_EUR_1 = &H30D               REM /*!< "#" (VK_OEM_5) */
            RZKEY_EUR_2 = &H402               REM /*!< \ (VK_OEM_102) */
            RZKEY_JPN_1 = &H15               REM /*!< ¥ (&HFF) */
            RZKEY_JPN_2 = &H40D               REM /*!< \ (&HC1) */
            RZKEY_JPN_3 = &H504               REM /*!< 無変換 (VK_OEM_PA1) */
            RZKEY_JPN_4 = &H509               REM /*!< 変換 (&HFF) */
            RZKEY_JPN_5 = &H50A               REM /*!< ひらがな/カタカナ (&HFF) */
            RZKEY_KOR_1 = &H15               REM /*!< | (&HFF) */
            RZKEY_KOR_2 = &H30D               REM /*!< (VK_OEM_5) */
            RZKEY_KOR_3 = &H402               REM /*!< (VK_OEM_102) */
            RZKEY_KOR_4 = &H40D               REM /*!< (&HC1) */
            RZKEY_KOR_5 = &H504               REM /*!< (VK_OEM_PA1) */
            RZKEY_KOR_6 = &H509               REM /*!< 한/영 (&HFF) */
            RZKEY_KOR_7 = &H50A               REM /*!< (&HFF) */
            RZKEY_INVALID = &HFFFF              REM /*!< Invalid keys. */
        End Enum

        REM //! Definition of LEDs.
        Public Enum RZLED
            RZLED_LOGO = &HE0014                 REM /*!< Razer logo */
        End Enum
    End Class

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Public Structure APPINFOTYPE
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=256)>
        Public Title As String REM //TCHAR Title[256];

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=1024)>
        Public Description As String REM //TCHAR Description[1024];

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=256)>
        Public Author_Name As String REM //TCHAR Name[256];

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=256)>
        Public Author_Contact As String REM //TCHAR Contact[256];

        Public SupportedDevice As UInt32 REM //DWORD SupportedDevice;

        Public Category As UInt32 REM //DWORD Category;
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure FChromaSDKGuid
        Public Data As Guid
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure DEVICE_INFO_TYPE
        Public DeviceType As Integer
        Public Connected As UInteger
    End Structure

    Public Enum EFFECT_TYPE
        CHROMA_NONE = 0            REM //!< No effect.
        CHROMA_WAVE                REM //!< Wave effect (This effect type has deprecated and should not be used).
        CHROMA_SPECTRUMCYCLING     REM //!< Spectrum cycling effect (This effect type has deprecated and should not be used).
        CHROMA_BREATHING           REM //!< Breathing effect (This effect type has deprecated and should not be used).
        CHROMA_BLINKING            REM //!< Blinking effect (This effect type has deprecated and should not be used).
        CHROMA_REACTIVE            REM //!< Reactive effect (This effect type has deprecated and should not be used).
        CHROMA_STATIC              REM //!< Static effect.
        CHROMA_CUSTOM              REM //!< Custom effect. For mice, please see Mouse::CHROMA_CUSTOM2.
        CHROMA_RESERVED            REM //!< Reserved
        CHROMA_INVALID             REM //!< Invalid effect.
    End Enum

    Namespace Stream

        Public Enum StreamStatusType
            READY = 0                  REM // ready for commands
            AUTHORIZING = 1            REM // the session is being authorized
            BROADCASTING = 2           REM // the session is being broadcast
            WATCHING = 3               REM // A stream is being watched
            NOT_AUTHORIZED = 4         REM // The session is not authorized
            BROADCAST_DUPLICATE = 5    REM // The session has duplicate broadcasters
            SERVICE_OFFLINE = 6        REM // The service is offline
        End Enum

        Public Class _Default
            Const LENGTH_SHORTCODE As UInteger = 6
            Const LENGTH_STREAM_ID As UInteger = 48
            Const LENGTH_STREAM_KEY As UInteger = 48
            Const LENGTH_STREAM_FOCUS As UInteger = 48

            Public Shared Function GetDefaultString(length As UInteger) As String
                Dim result As String = String.Empty
                For i As UInteger = 0 To length Step 1
                    result += " "
                Next
                Return result
            End Function

            Public Shared ReadOnly Shortcode As String = GetDefaultString(LENGTH_SHORTCODE)
            Public Shared ReadOnly StreamId As String = GetDefaultString(LENGTH_STREAM_ID)
            Public Shared ReadOnly StreamKey As String = GetDefaultString(LENGTH_STREAM_KEY)
            Public Shared ReadOnly StreamFocus As String = GetDefaultString(LENGTH_STREAM_FOCUS)
        End Class
    End Namespace

    Module ChromaAnimationAPI

#If X64 Then
        Const DLL_NAME As String = "CChromaEditorLibrary64"
#Else
        Const DLL_NAME As String = "CChromaEditorLibrary"
#End If

#Region "Data Structures"

        Public Enum DeviceType
            Invalid = -1
            DE_1D = 0
            DE_2D = 1
            MAX = 2
        End Enum

        Public Enum Device
            Invalid = -1
            ChromaLink = 0
            Headset = 1
            Keyboard = 2
            Keypad = 3
            Mouse = 4
            Mousepad = 5
            MAX = 6
        End Enum

        Public Enum Device1D
            Invalid = -1
            ChromaLink = 0
            Headset = 1
            Mousepad = 2
            MAX = 3
        End Enum

        Public Enum Device2D
            Invalid = -1
            Keyboard = 0
            Keypad = 1
            Mouse = 2
            MAX = 3
        End Enum

        Public Class FChromaSDKDeviceFrameIndex
            REM // Index corresponds to EChromaSDKDeviceEnum
            Public _mFrameIndex() As Integer = New Integer() {0, 0, 0, 0, 0, 0}

            Public Function FChromaSDKDeviceFrameIndex()
                _mFrameIndex(Device.ChromaLink) = 0
                _mFrameIndex(Device.Headset) = 0
                _mFrameIndex(Device.Keyboard) = 0
                _mFrameIndex(Device.Keypad) = 0
                _mFrameIndex(Device.Mouse) = 0
                _mFrameIndex(Device.Mousepad) = 0
                Return Nothing
            End Function
        End Class

        Public Enum EChromaSDKSceneBlend
            SB_None
            SB_Invert
            SB_Threshold
            SB_Lerp
        End Enum

        Public Enum EChromaSDKSceneMode
            SM_Replace
            SM_Max
            SM_Min
            SM_Average
            SM_Multiply
            SM_Add
            SM_Subtract
        End Enum

        Public Class FChromaSDKSceneEffect
            Public _mAnimation As String = ""
            Public _mState As Boolean = False
            Public _mPrimaryColor As Integer = 0
            Public _mSecondaryColor As Integer = 0
            Public _mSpeed As Integer = 1
            Public _mBlend As EChromaSDKSceneBlend = EChromaSDKSceneBlend.SB_None
            Public _mMode As EChromaSDKSceneMode = EChromaSDKSceneMode.SM_Replace

            Public _mFrameIndex As FChromaSDKDeviceFrameIndex = New FChromaSDKDeviceFrameIndex()
        End Class

        Public Class FChromaSDKScene
            Public _mEffects As List(Of FChromaSDKSceneEffect) = New List(Of FChromaSDKSceneEffect)
        End Class

#End Region

#Region "Helpers (handle path conversions)"

        REM /// <summary>
        REM /// Helper to convert path string to IntPtr
        REM /// </summary>
        REM /// <param name="path"></param>
        REM /// <returns></returns>
        Private Function GetPathIntPtr(path As String) As IntPtr
            If (String.IsNullOrEmpty(path)) Then
                Return IntPtr.Zero
            End If
            Dim fi As FileInfo = New FileInfo(path)
            Dim array As Byte() = ASCIIEncoding.ASCII.GetBytes(fi.FullName + "\0")
            Dim lpData As IntPtr = Marshal.AllocHGlobal(array.Length)
            Marshal.Copy(array, 0, lpData, array.Length)
            Return lpData
        End Function

        REM /// <summary>
        REM /// Helper to Ascii path string to IntPtr
        REM /// </summary>
        REM /// <param name="str"></param>
        REM /// <returns></returns>
        Private Function GetAsciiIntPtr(str As String) As IntPtr
            If (String.IsNullOrEmpty(str)) Then
                Return IntPtr.Zero
            End If
            Dim array As Byte() = ASCIIEncoding.ASCII.GetBytes(str + "\0")
            Dim lpData As IntPtr = Marshal.AllocHGlobal(array.Length)
            Marshal.Copy(array, 0, lpData, array.Length)
            Return lpData
        End Function

        REM /// <summary>
        REM /// Helper to Unicode path string to IntPtr
        REM /// </summary>
        REM /// <param name="str"></param>
        REM /// <returns></returns>
        Private Function GetUnicodeIntPtr(str As String) As IntPtr
            If (String.IsNullOrEmpty(str)) Then
                Return IntPtr.Zero
            End If
            Dim array As Byte() = UnicodeEncoding.Unicode.GetBytes(str + "\0")
            Dim lpData As IntPtr = Marshal.AllocHGlobal(array.Length)
            Marshal.Copy(array, 0, lpData, array.Length)
            Return lpData
        End Function

        REM /// <summary>
        REM /// Helper to recycle the IntPtr
        REM /// </summary>
        REM /// <param name="lpData"></param>
        Private Function FreeIntPtr(lpData As IntPtr)
            If (lpData <> IntPtr.Zero) Then
                Marshal.FreeHGlobal(lpData)
            End If
            Return Nothing
        End Function

#End Region

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

End Namespace
