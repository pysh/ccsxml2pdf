'
' Сделано в SharpDevelop.
' Пользователь: pnosov
' Дата: 03.12.2012
' Время: 17:39
' 
' Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
'
Public Class Ini
        Private Declare Ansi Function GetPrivateProfileString _
      Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
      (ByVal lpApplicationName As String, _
      ByVal lpKeyName As String, ByVal lpDefault As String, _
      ByVal lpReturnedString As System.Text.StringBuilder, _
      ByVal nSize As Integer, ByVal lpFileName As String) _
      As Integer
        Private Declare Ansi Function WritePrivateProfileString _
          Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
          (ByVal lpApplicationName As String, _
          ByVal lpKeyName As String, ByVal lpString As String, _
          ByVal lpFileName As String) As Integer
        Private Declare Ansi Function GetPrivateProfileInt _
          Lib "kernel32.dll" Alias "GetPrivateProfileIntA" _
          (ByVal lpApplicationName As String, _
          ByVal lpKeyName As String, ByVal nDefault As Integer, _
          ByVal lpFileName As String) As Integer
        Private Declare Ansi Function FlushPrivateProfileString _
          Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
          (ByVal lpApplicationName As Integer, _
          ByVal lpKeyName As Integer, ByVal lpString As Integer, _
          ByVal lpFileName As String) As Integer
        Dim strFilename As String

        ' Constructor, accepting a filename
        Public Sub New(ByVal FileName As String)
            strFilename = FileName
        End Sub

        ' Read-only filename property
        ReadOnly Property FileName() As String
            Get
                Return strFilename
            End Get
        End Property

        Public Function GetString(ByVal section As String, ByVal key As String, ByVal [default] As String) As String
            ' Returns a string from your INI file
            Dim intCharCount As Integer
            Dim objResult As New System.Text.StringBuilder(1024)
            intCharCount = GetPrivateProfileString(Section, Key, [default], objResult, objResult.Capacity, strFilename)
            If intCharCount > 0 Then
                GetString = Left(objResult.ToString, intCharCount)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetInteger(ByVal section As String, _
          ByVal key As String, ByVal [default] As Int32) As Integer
            ' Returns an integer from your INI file
            Return GetPrivateProfileInt(section, key, _
               [default], strFilename)
        End Function

        Public Function GetBoolean(ByVal section As String, _
          ByVal key As String, ByVal [default] As Boolean) As Boolean
            ' Returns a boolean from your INI file
            Return (GetPrivateProfileInt(section, Key, _
               CInt([default]), strFilename) = 1)
        End Function

        Public Sub WriteString(ByVal section As String, _
          ByVal key As String, ByVal value As String)
            ' Writes a string to your INI file
            WritePrivateProfileString(section, key, Value, strFilename)
            Flush()
        End Sub

        Public Sub WriteInteger(ByVal section As String, _
          ByVal key As String, ByVal value As Integer)
            ' Writes an integer to your INI file
            WriteString(section, key, CStr(Value))
            Flush()
        End Sub

        Public Sub WriteBoolean(ByVal section As String, ByVal key As String, ByVal value As Boolean)
            ' Writes a boolean to your INI file
            Dim Sendval As String = "0"
            If value Then Sendval = "1"
            WriteString(section, key, Sendval)
            Flush()
        End Sub

        Private Sub Flush()
            ' Stores all the cached changes to your INI file
            FlushPrivateProfileString(0, 0, 0, strFilename)
        End Sub
End Class