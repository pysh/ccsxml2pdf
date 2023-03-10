'
' Сделано в SharpDevelop.
' Пользователь: pnosov
' Дата: 30.01.2013
' Время: 11:20
' 
' Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
'
Option Compare Text

Imports System.Drawing.Printing
Imports System.Globalization
Imports Microsoft.WindowsAPICodePack.Taskbar

Public Partial Class MainForm
    Private iniFile As New ini(IO.Path.ChangeExtension(Application.ExecutablePath, "ini"))
    Private report1 As New FastReport.Report()
    ' Private myProc As Process = Process.GetCurrentProcess
    
    Private Structure myPapperSource
        Private SourceID As Integer
        Private SourceName As String
    End Structure

'    Public Structure structProcessPriority
'        Public PriorityID As Integer
'        Public PriorityName As String
'    End Structure

    Private Enum ReportGenerationResults As Integer
        Ok = 0
        IsEmpty = 1
        InvalidXml = 2
        XmlNotFound = -1
    End Enum
    
    Private frPDFExport As New FastReport.Export.Pdf.PDFExport
    
    Public Sub New()
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        Me.InitializeComponent()
        Me.Text = String.Format("{0}  v.{1}", Application.ProductName, Application.ProductVersion)

        dataSet1.ReadXml(IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "ccs_null.xml"))
        dataSet1.Clear()

        FillProcessPriority()
        LoadProcessPriority()
        ' Application.CurrentCulture = CultureInfo.GetCultureInfo("En-en")
        '
        ' TODO : Add constructor code after InitializeComponents
        '
        'Dim strLastPrinterRussianPost As String = iniFile.GetString("Printers", "Printer_RussianPost", "")
        'Dim strLastPrinterEmail As String = iniFile.GetString("Printers", "Printer_Email", "")
        'Dim strLastPrinterSalary As String = iniFile.GetString("Printers", "Printer_Salary", "")
        FillPrinterList ()
        FillReportsList ()
    End Sub
    
    Private Sub FillReportsList
        cbReports.Items.Clear
        cbReports.Items.Add("Авто")
        Dim dirInfo As IO.DirectoryInfo = New IO.DirectoryInfo(IO.Path.GetDirectoryName(Application.ExecutablePath)) '   System.IO.Directory.GetFiles(IO.Path.GetDirectoryName(Application.ExecutablePath), "*.frx")
        For Each fInfo As IO.FileInfo In dirInfo.EnumerateFiles("*.frx", IO.SearchOption.TopDirectoryOnly)
            cbReports.Items.Add(fInfo.Name)
        Next
        cbReports.SelectedIndex = 0
    End Sub
    
    Private Sub FillProcessPriority
        Dim PriorityList As New List(Of DictionaryEntry)
        PriorityList.Add(New DictionaryEntry(256, "Реального времени"))
        PriorityList.Add(New DictionaryEntry(128, "Высокий"))
        PriorityList.Add(New DictionaryEntry(32768, "Выше среднего"))
        PriorityList.Add(New DictionaryEntry(32, "Средний"))
        PriorityList.Add(New DictionaryEntry(16384, "Ниже среднего"))
        PriorityList.Add(New DictionaryEntry(64, "Низкий"))

        cbProcessPriority.ComboBox.DataSource = PriorityList
        cbProcessPriority.ComboBox.DisplayMember = "Value"
        cbProcessPriority.ComboBox.ValueMember = "Key"
    End Sub
    
    Private Sub LoadProcessPriority
        Dim myProcess As Process = Process.GetCurrentProcess
        Dim iPC As ProcessPriorityClass = iniFile.GetInteger("Settings", "ProcessPriority", CInt(ProcessPriorityClass.Normal))
'        Dim iBP As Integer = iniFile.GetString("Settings","BasePriority", 8)
        myProcess.PriorityClass = iPC
        cbProcessPriority.SelectedIndex = -1
        For Each i As DictionaryEntry In cbProcessPriority.Items
            If CType(i, DictionaryEntry).Key = iPC Then
                cbProcessPriority.SelectedItem = i
                Exit For
            End If
        Next
    End Sub

    Private Sub SaveProcessPriority(Optional intPriority As ProcessPriorityClass = 0)
        If intPriority = 0 Then intPriority = Process.GetCurrentProcess.PriorityClass
        iniFile.WriteInteger("Settings", "ProcessPriority",intPriority)
    End Sub

    Sub FillPrinterList()
        Dim PrinterName As String
        cbPrinters.Items.Clear
        For each PrinterName In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            cbPrinters.Items.Add(PrinterName)
        Next PrinterName
        PrinterName = iniFile.GetString("Settings", "Printer","")
        cbPrinters.SelectedItem = PrinterName
    End Sub
    
'    Sub RegisterDataset()
'        Dim strReportFileName As String
'        Dim strXMLFileName As String
'        
'        strReportFileName = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "stmt.frx")
'        strXMLFileName = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "test.xml")
'        WriteTrace ("...")
'        Me.Refresh
'        dataSet1.Clear
'        dataSet1.ReadXml(strXMLFileName)
'        If report1.FileName = strReportFileName Then
'            report1.Dictionary.ClearRegisteredData
'        Else
'        report1.Clear
'        report1.Load(strReportFileName)
'        End If
'        report1.RegisterData(dataSet1)
'        WriteTrace ("XML загружен")
'        WriteLog("XML загружен", strXMLFileName)
'        Me.Refresh
'        report1.Design
'   End Sub


    #Region "Drag'n'Drop"
    Sub ListView1DragDrop(sender As Object, e As DragEventArgs)
        ' Accept on files and folders.
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            Dim Items() As String = CType(e.Data.GetData(DataFormats.FileDrop), System.String())
            Dim File As String
            listView1.BeginUpdate
            For Each File In Items
                ' Let's see if we are dealing with a file or a folder.
                If System.IO.File.Exists(File) Then
                    ' It's a file, so we add it to the listbox.
                    IF io.path.GetExtension(File)=".xml" Then AddFile(File)
                ElseIf System.IO.Directory.Exists(File) Then
                    ' It's a folder, so we must search it for files.
                    FindFiles(File)
                End If
                toolStripProgressText.Text = String.Format("{0}/{1}", 0, Me.listView1.Items.Count)
            Next
            listView1.Columns.Item(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            listView1.EndUpdate
            toolStripProgressText.Text = String.Format("{0}/{1}", 0, Me.listView1.Items.Count)
        End If
    End Sub

    Sub ListView1DragEnter(sender As Object, e As DragEventArgs)
        ' Let's allow files to be dropped.
        Writetrace("DragEnter")
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    # End Region
    
    Private Sub AddFile(ByVal strFileName As String)
        Dim intGroupIndex As Integer
        Dim lvi As ListViewItem
        Dim lvg As ListViewGroup
        intGroupIndex = GetGroupIndex(IO.Path.GetFileName(strFileName).ToUpper(CultureInfo.CurrentCulture))
        lvg = listView1.Groups.Item(intGroupIndex)
        lvi = New ListViewItem(New String(){strFileName, intGroupIndex.ToString(CultureInfo.CurrentCulture)})
        lvi.Group = lvg
        lvi.ImageIndex=0
        listView1.Items.Add(lvi)
    End Sub
    
    Shared Public Sub WriteLog(strMessage As String, strXmlFileName As String)
        Dim strLogFileName As String = IO.Path.Combine(IO.Path.GetDirectoryName(strXmlFileName),"xml2pdf.log")
        Using writer As IO.StreamWriter = New IO.StreamWriter(strLogFileName, True)
            writer.WriteLine(Join({Now, strXmlFileName, strMessage}, ";"))
        End Using
    End Sub

    Private Sub WriteTrace(ByVal strMsg As String)
        status1.Text = strMsg
        Me.Refresh()
    End Sub

    Private Sub FindFiles(ByVal Directory As String)
        ' Find files in current folder.
        Try
            Dim Files As String() = System.IO.Directory.GetFiles(Directory, "*.xml")
            Dim File As String
            For Each File In Files
                AddFile(File)
            Next
        Catch
            Throw
        End Try
        ' Find subfolders in current folder and search them for files too.
        Try
            Dim Dirs As String() = System.IO.Directory.GetDirectories(Directory, "*")
            Dim Dir As String
            For Each Dir In Dirs
                FindFiles(Dir)
            Next
        Catch
            Throw
        End Try
    End Sub    
    
    Shared Function GetDTInterval(ByVal dtFrom As Date, ByVal dtTo As Date) As String
        Dim timeSec As Long, timeMin As Long, timeHour As Long
        timeSec = DateDiff(DateInterval.Second, dtFrom, dtTo)
        timeHour = timeSec \ 3600
        timeMin = (timeSec Mod 3600) \ 60
        timeSec = (timeSec Mod 3600) Mod 60
        Return String.Format("{0}:{1}:{2}", Format(timeHour, "00"), Format(timeMin, "00"), Format(timeSec, "00"))
    End Function
    
    
    #Region "Обработка нажатий кнопок"
    Sub BtnAddFilesClick(sender As Object, e As EventArgs)
        Dim q As String
        OpenFileDialog1.Multiselect = True
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            For Each q In OpenFileDialog1.FileNames
                AddFile(q)
            Next
        End If
    End Sub
    
    Sub BtnClearListClick(sender As Object, e As EventArgs)
        With listView1
            .BeginUpdate
            .Items.Clear()
            .EndUpdate
        End With
    End Sub

    Sub BtnConvertClick(sender As Object, e As EventArgs)
        ' bgw1.RunWorkerAsync()
        ProcessFileList()
    End Sub
    #End Region
    
    Private Sub ProcessFileList()
        ' Dim f As Long
        Dim strXMLFileName As String
        Dim ccsFile as String
        Dim dtFrom As DateTime = DateAndTime.Now
        Dim lvi As ListViewItem
        Dim intType As Integer
        Dim ReportGenerationResult As Integer
        Dim intOK As Integer = 0
        Dim intEmpty As Integer = 0
        Dim intInvalid As Integer = 0
        Dim intError As Integer = 0
        'Dim strReportFileName As String = IO.Path.ChangeExtension(Application.ExecutablePath, "frx")
        'report1.Clear
        'report1.Load(strReportFileName)
        'report1.PrintSettings.Printer = cbPrinters.Text
        toolStripProgressBar1.Maximum = CInt(IIf(Me.listView1.Items.Count < 1, 0, Me.listView1.Items.Count-1))
        For Each lvi In Me.listView1.Items
            If TaskbarManager.IsPlatformSupported Then
                TaskbarManager.Instance.SetOverlayIcon(Me.Handle, Resource1.printer_ico, "Печать")
            End If
            strXMLFileName=lvi.SubItems(0).Text
            intType = GetGroupIndex(IO.Path.GetFileName(strXMLFileName).ToUpper(CultureInfo.CurrentCulture))
            ccsFile=io.Path.Combine(io.Path.GetDirectoryName(strXMLFileName),"ccs.dtd")
            'msgbox(ccsFile)
            If not(System.IO.File.Exists(ccsFile)) Then io.File.Create(ccsFile).Close
            listView1.BeginUpdate
            '            lvi.EnsureVisible
            listView1.EnsureVisible(listView1.Items.IndexOf(lvi))
            lvi.ImageIndex=1
            WriteTrace(strXMLFileName)
            listView1.EndUpdate
            ReportGenerationResult = GenerateReport(strXMLFileName, intType)
            listView1.BeginUpdate
            Select Case ReportGenerationResult
                Case ReportGenerationResults.Ok
                    lvi.ImageIndex=2
                    WriteLog("Печать завершена", strXMLFileName)
                    intOK +=1
                Case ReportGenerationResults.IsEmpty 
                	lvi.ImageIndex=3
                	intEmpty +=1
                Case ReportGenerationResults.InvalidXML
                	lvi.ImageIndex=4
                	intInvalid +=1
                Case ReportGenerationResults.XMLNotFound
                	lvi.ImageIndex=5
                	intError +=1
            End Select
            listView1.EndUpdate
            ' Обновляем статистику
            toolStripProgressBar1.Value = Me.listView1.Items.IndexOf(lvi)
            toolStripProgressText.Text = String.Format("{0}/{1} (Пустые: {2}, Ошибки: {3}, Неверный XML: {4})", Me.listView1.Items.IndexOf(lvi)+1, Me.listView1.Items.Count, intEmpty, intError, intInvalid)
            lblStatOK.Text = intOK.ToString(CultureInfo.CurrentCulture)
            lblStatIsEmpty.Text = intEmpty.ToString(CultureInfo.CurrentCulture)
            lblStatInvalidXML.Text = intInvalid.ToString(CultureInfo.CurrentCulture)
            lblStatError.Text = intError.ToString(CultureInfo.CurrentCulture)
            lblStatTotal.Text = Me.listView1.Items.Count.ToString(CultureInfo.CurrentCulture)
            
            If TaskbarManager.IsPlatformSupported Then
                TaskbarManager.Instance.SetProgressValue(toolStripProgressBar1.Value, toolStripProgressBar1.Maximum, Me.Handle)
            End If
            'My.Application.DoEvents
            'convertXMLtoMDB(a.ToString)
        Next lvi
        If TaskbarManager.IsPlatformSupported Then
            ' TaskbarManager.Instance.SetOverlayIcon(Me.Handle, Icon.,"")
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress, Me.Handle)
        End If
        ' report1.Design
        WriteTrace(String.Format(CultureInfo.CurrentCulture,"Выполнено за {0}", GetDTInterval(dtFrom, DateAndTime.Now)))
        ' MsgBox(String.Format("Выполнено за {0}", GetDTInterval(dtFrom, DateAndTime.Now)), MsgBoxStyle.Information)
    End Sub

    Function GetReportName(reportType As Integer) As String
        Dim strReportFileName As String = ""
        If cbReports.SelectedIndex=0 Then
            Select Case reportType
                Case 0 ' e-mail
                    strReportFileName = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "ccs_email.frx")
                Case 1 ' Russian Post
                    strReportFileName = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "ccs_post.frx")
                Case 2 ' Salary
                    strReportFileName = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "ccs_salary.frx")
                Case 3 ' e-mail
                    strReportFileName = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "ccs_email.frx")
            End Select
        Else
            strReportFileName = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), cbReports.Text)
        End If
        Return strReportFileName
    End Function
    
    Function GenerateReport(strXmlFileName As String, reportType As Integer) As Integer
        Dim RetVal As Integer = -1
        If Not System.IO.File.Exists(strXmlFileName) Then
            RetVal = ReportGenerationResults.XMLNotFound ' Отсутствует XML-файл
        Else
            Dim strReportFileName As String = GetReportName(reportType) ' = IO.Path.ChangeExtension(Application.ExecutablePath, "frx")
            'Dim strDictonaryFileName As String = IO.Path.ChangeExtension(Application.ExecutablePath, "frd")
            'Dim strDTDFileName As String = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "CCS.dtd")
            dataSet1.Clear
                If (Not ReadDataSet(dataSet1, strXMLFileName)) orElse (Not dataSet1.Tables.Contains("G_CLIENT")) OrElse (dataSet1.Tables("G_CLIENT").Rows.Count < 1) Then
                    RetVal = ReportGenerationResults.InvalidXML 'Неизвестный формат файла (Нет таблицы G_CLIENT)
                Else
                    ' Открытие шаблона отчета
                    If report1.FileName = strReportFileName Then
                        report1.Dictionary.ClearRegisteredData
                    Else
                        report1.Clear
                        Application.DoEvents
                        WriteTrace ("Loading report...")
                        report1.Load(strReportFileName)
                    End If
    
    '                --------
    '                Dim conn As FastReport.Data.XmlDataConnection = report1.Dictionary.Connections.Item(0)
    '                conn.XmlFile = strXmlFileName
    '                --------
                    report1.PrintSettings.Printer = cbPrinters.Text
    '                If Not report1.Parameters.Contains("prm_DataSourceFileName") Then report1.Parameters.Add("prm_DataSourceFileName")
                    report1.SetParameterValue("prm_DataSourceFileName", strXmlFileName)
                    report1.ReportInfo.Name = "<empty>"
                    Application.DoEvents()
    
                    ' *** Регистрация данных ***
                    Try
                        WriteTrace ("Register data...")
                        report1.RegisterData(dataSet1)
                    Catch ex As Exception
                        WriteLog("Generic Exception Handler (DataSet.ReadXML): " &  ex.ToString(), strXMLFileName)
                        Throw
                    End Try
                    ' *** Подготовка отчета ***
                    WriteTrace ("Prepare report...")
                    WriteLog("Подготовка отчета", strXMLFileName)
                    Try
                        report1.Prepare(False)
                    Catch ex As Exception
                        WriteLog("Generic Exception Handler (Report.Prepare): {0}" & ex.ToString(), strXMLFileName)
                        ' MsgBox(ex.Message, MsgBoxStyle.Critical)
                        Throw
                    End Try
                    ' Не печатать отчет, не содержащий ни одного листа.
                    If not ((report1.PreparedPages.Count > 0) AndAlso (report1.ReportInfo.Name <> "<empty>")) Then
                        RetVal = ReportGenerationResults.IsEmpty ' Пустой отчет
                        WriteLog("Отчет пустой, пропускаем", strXMLFileName)
                    Else
                        If Me.chkPreview.Checked Then
                            report1.PrintSettings.ShowDialog = True
                            WriteLog("Просмотр отчета", strXMLFileName)
                            report1.ShowPrepared()
                        Else
                            If iniFile.GetBoolean("Settings", "UseInternalPDFExport", False) Then
                                Dim strPDFFileName As String = IO.path.Combine(IO.Path.GetDirectoryName(strXmlFileName), report1.ReportInfo.Name & ".pdf")
                                If ExportReportToPdf(report1, strPDFFileName) then
                                    WriteLog("Отчет экспортирован", strXMLFileName)
                                Else
                                    WriteLog("Ошибка экспорта: " & strPDFFileName, strXMLFileName)
                                End If
                            Else
                                report1.PrintSettings.ShowDialog = False
                                report1.PrintPrepared()
                                WriteLog("Отчет отправлен на печать", strXMLFileName)
                            End If
                        End If
                        RetVal = ReportGenerationResults.Ok ' Ок
                    End If
                End If
        End If
        Return RetVal
    End Function
    
    Shared Function ReadDataSet(ds As Data.DataSet, strXmlFileName As String) As Boolean
        Try
            ds.ReadXml(strXmlFileName)
            Return True
        Catch ex As Exception
            Return False
            Throw
        End Try
    End Function
    
    Private Function ExportReportToPdf(rep As FastReport.Report, strPdfFileName As String) As Boolean
        frPDFExport.PrintOptimized = True
        frPDFExport.Compressed = True
        Try
            frPDFExport.Export(rep, strPdfFileName)
            Return True
        Catch
            Return False
            Throw
        End Try
    End Function

    Sub CBPrintersSelectedIndexChanged(sender As Object, e As EventArgs)
        ' Dim ppi As New List(Of System.Collections.DictionaryEntry)
        Dim strPrinterName As String = cbPrinters.Text ' CType(cbPrinters.SelectedItem, String)
        iniFile.WriteString("Settings", "Printer", cbPrinters.Text)
        If cbPrinters.Text <> "" Then
            cbPaperPreprint.BeginUpdate
            cbPaperPlain.BeginUpdate
            cbPaperPreprint.DataSource = GetPaperSources(strPrinterName)
            cbPaperPreprint.DisplayMember = "Value"
            cbPaperPreprint.ValueMember = "Key"
            cbPaperPlain.DataSource = GetPaperSources(strPrinterName)
            cbPaperPlain.DisplayMember = "Value"
            cbPaperPlain.ValueMember = "Key"
            cbPaperPreprint.SelectedValue = iniFile.GetInteger(strPrinterName, "PaperPreprint", 15)
            cbPaperPlain.SelectedValue = iniFile.GetInteger(strPrinterName, "PaperPlain", 15)
            cbPaperPreprint.EndUpdate
            cbPaperPlain.EndUpdate
        End If
    End Sub
    
    
    Private Sub CBPaperPreprintSelectedIndexChanged(sender As Object, e As EventArgs)
        Dim strPrinterName As String = CType(cbPrinters.SelectedItem, String)
        Dim value As DictionaryEntry = CType(Me.cbPaperPreprint.SelectedItem, DictionaryEntry)
        If strPrinterName <> "" Then
            iniFile.WriteInteger(strPrinterName, "PaperPreprint", CType(value.Key, Integer))
        End If
    End Sub
    
    Sub CBPaperPlainSelectedIndexChanged(sender As Object, e As EventArgs)
        Dim strPrinterName As String = CType(cbPrinters.SelectedItem, String)
        Dim value As DictionaryEntry = CType(Me.cbPaperPlain.SelectedItem, DictionaryEntry)
        If strPrinterName <> "" Then
            iniFile.WriteInteger(strPrinterName, "PaperPlain", CType(value.Key, Integer))
        End If
    End Sub
    
    Sub BtnOpenReportDesignerClick(sender As Object, e As EventArgs)
        Try
            report1.Design()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Throw
        End Try
    End Sub
    
    
    
    Shared Function GetGroupIndex(strFileName As String) As Integer
        If strFileName Like "*__E_48*" Then
            Return 2
        ElseIf strFileName Like "*_C_*" Then
            Return 1
        ElseIf strFileName Like "*_E_*" Then
            Return 0
        ElseIf strFileName Like "*-P-*" Then
            Return 3
        Else
            Return -1
        End If
    End Function
    
    
'    Sub BtnOpenXMLClick(sender As Object, e As EventArgs)
'        Dim strXMLFileName As String = "\\rccf.ru\profiles\Office Users\pnosov\My Documents\SharpDevelop Projects\stmt_2013\TEST_XML\04\168137_001_E_31011001920.xml"
'        Dim strReportFileName As String = "U:\My Documents\SharpDevelop Projects\STMT\STMT\stmt_2013_xml.frx"
'        report1.Load(strReportFileName)
'        Dim conn As FastReport.Data.XmlDataConnection = report1.Dictionary.Connections.Item(0)
'        conn.XmlFile = strXmlFileName
'        Debug.WriteLine (conn.ConnectionString)
'        report1.Design()
'    End Sub



    Sub ListView1SelectedIndexChanged(sender As Object, e As EventArgs)
        If listView1.SelectedIndices.Count>0 Then
            Dim idx As Integer = listView1.SelectedIndices.Item(0)
            If idx >= 0 Then
                WriteTrace (listView1.Items(idx).Text)
            End If
        End If
    End Sub

    Function GetPaperSources(strPrinterName As String) As List(Of System.Collections.DictionaryEntry)
        Dim PaperSourceItems = New List(Of System.Collections.DictionaryEntry)
        Dim d As New PrintDocument()
        d.PrinterSettings.PrinterName=strPrinterName
        For Each ps As PaperSource In d.PrinterSettings.PaperSources
            PaperSourceItems.Add(New DictionaryEntry(ps.RawKind, String.Format("{0} ({1})", ps.SourceName, ps.RawKind)))
        Next
        If PaperSourceItems.Count = 0 Then
            PaperSourceItems.Add(New DictionaryEntry(15, "Автовыбор (15)"))
        End If
        Return PaperSourceItems
    End Function
    
    
    Private Shared Sub WriteProcessInfo()
        Dim myProcess As Process = Process.GetCurrentProcess
        Dim strInfo As String = ""
        strInfo = strInfo & vbcrlf & String.Format(CultureInfo.CurrentCulture, "  physical memory usage: {0}", myProcess.WorkingSet64)
        strInfo = strInfo & vbcrlf & String.Format(CultureInfo.CurrentCulture, "  base priority: {0}", myProcess.BasePriority)
        strInfo = strInfo & vbcrlf & String.Format(CultureInfo.CurrentCulture, "  priority class: {0}", myProcess.PriorityClass)
        strInfo = strInfo & vbcrlf & String.Format(CultureInfo.CurrentCulture, "  user processor time: {0}", myProcess.UserProcessorTime)
        strInfo = strInfo & vbcrlf & String.Format(CultureInfo.CurrentCulture, "  privileged processor time: {0}", myProcess.PrivilegedProcessorTime)
        strInfo = strInfo & vbcrlf & String.Format(CultureInfo.CurrentCulture, "  total processor time: {0}", myProcess.TotalProcessorTime)
        strInfo = strInfo & vbcrlf & String.Format(CultureInfo.CurrentCulture, "  PagedSystemMemorySize64: {0}", myProcess.PagedSystemMemorySize64)
        strInfo = strInfo & vbcrlf & String.Format(CultureInfo.CurrentCulture, "  PagedMemorySize64: {0}", myProcess.PagedMemorySize64)
        Debug.WriteLine(strInfo)
        MsgBox(strInfo)
    End Sub

    Sub CbProcessPriority_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim p As System.Diagnostics.Process = System.Diagnostics.Process.GetCurrentProcess
        If cbProcessPriority.ComboBox.SelectedIndex > 0 Then
            Dim iPC As Integer = CType(CType(cbProcessPriority.SelectedItem, DictionaryEntry).Key, Integer)
            If Process.GetCurrentProcess.PriorityClass.IsDefined(GetType(ProcessPriorityClass), iPC) Then
                Process.GetCurrentProcess.PriorityClass = iPC
                SaveProcessPriority
            End If
        End If
    End Sub
    
    
    
    
    
    
    Sub ToolStripLabel1_DoubleClick(sender As Object, e As EventArgs)
        WriteProcessInfo()
    End Sub

    
    Sub Bgw1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        ProcessFileList()
    End Sub

End Class