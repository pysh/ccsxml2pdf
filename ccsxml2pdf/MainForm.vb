'
' Сделано в SharpDevelop.
' Пользователь: pnosov
' Дата: 30.01.2013
' Время: 11:20
' 
' Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
'

Imports System.Drawing.Printing

Public Partial Class MainForm
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
		FillPrinterList ()
	End Sub
	
	Sub FillPrinterList()
		Dim PrinterName As String
		cbPrinters.Items.Clear
		For each PrinterName In System.Drawing.Printing.PrinterSettings.InstalledPrinters
			cbPrinters.Items.Add(PrinterName)
		Next PrinterName
	End Sub
	
	Sub RegisterDataset()
		Dim strReportFileName As String
		Dim strXMLFileName As String

		strReportFileName = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "stmt.frx")
		strXMLFileName = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "test.xml")
		WriteTrace ("...")
		Me.Refresh
		dataSet1.Clear
		dataSet1.ReadXml(strXMLFileName)
		report1.Clear
		report1.Load(strReportFileName)
		report1.RegisterData(dataSet1)
		WriteTrace ("XML загружен")
		Me.Refresh
		report1.Design
	End Sub
	
	
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
            Next
            listView1.Columns.Item(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            listView1.EndUpdate            
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
		intGroupIndex = GetGroupIndex(IO.Path.GetFileName(strFileName))
		lvg = listView1.Groups.Item(intGroupIndex)
		lvi = New ListViewItem(New String(){strFileName, intGroupIndex.ToString})
		lvi.Group = lvg
		lvi.StateImageIndex=0
		listView1.Items.Add(lvi)
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
        End Try
        ' Find subfolders in current folder and search them for files too.
        Try
            Dim Dirs As String() = System.IO.Directory.GetDirectories(Directory, "*")
            Dim Dir As String
            For Each Dir In Dirs
                FindFiles(Dir)
            Next
        Catch
        End Try
    End Sub	
    
    Function GetDTInterval(ByVal dtFrom As Date, ByVal dtTo As Date) As String
        Dim timeSec As Long, timeMin As Long, timeHour As Long
        timeSec = DateDiff(DateInterval.Second, dtFrom, dtTo)
        timeHour = timeSec \ 3600
        timeMin = (timeSec Mod 3600) \ 60
        timeSec = (timeSec Mod 3600) Mod 60
        GetDTInterval = String.Format("{0}:{1}:{2}", Format(timeHour, "00"), Format(timeMin, "00"), Format(timeSec, "00"))
    End Function    
    
    
    #Region "Обработка нажатий кнопок"
	Sub BtnAddFilesClick(sender As Object, e As EventArgs)
		Dim q As String
        OpenFileDialog1.Multiselect = True
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each q In OpenFileDialog1.FileNames
				AddFile(q)
            Next
        End If
	End Sub

	Sub BtnClearListClick(sender As Object, e As EventArgs)
		Me.ListView1.Items.Clear()
	End Sub

	Sub BtnConvertClick(sender As Object, e As EventArgs)
		' Dim f As Long
		Dim fle As String
		Dim ccsFile as String
        Dim dtFrom As DateTime = DateAndTime.Now
        Dim lvi As ListViewItem
        Dim intType As Integer
		'Dim strReportFileName As String = IO.Path.ChangeExtension(Application.ExecutablePath, "frx")        

        'report1.Clear
        'report1.Load(strReportFileName)
        'report1.PrintSettings.Printer = cbPrinters.Text

        For Each lvi In Me.listView1.Items
        	fle=lvi.SubItems(0).Text
        	intType = GetGroupIndex(IO.Path.GetFileName(fle))
        	ccsFile=io.Path.Combine(io.Path.GetDirectoryName(fle),"ccs.dtd")
        	'msgbox(ccsFile)
        	If not(System.IO.File.Exists(ccsFile)) Then io.File.Create(ccsFile).Close
            lvi.EnsureVisible
            lvi.StateImageIndex=1
            WriteTrace(fle)
            GenerateReport(fle, intType)
            lvi.StateImageIndex=2
            'DoEvent
            me.Refresh
            'convertXMLtoMDB(a.ToString)
        Next lvi
        ' report1.Design
		WriteTrace(String.Format("Выполнено за {0}", GetDTInterval(dtFrom, DateAndTime.Now)))
        ' MsgBox(String.Format("Выполнено за {0}", GetDTInterval(dtFrom, DateAndTime.Now)), MsgBoxStyle.Information)
	End Sub    
	#End Region
	
	Function GenerateReport(strXmlFileName As String, intType As Integer) As Boolean
		If System.IO.File.Exists(strXmlFileName) Then
'			Dim dtFrom As Date
'			Dim dtTo As Date
'			Dim strEmail As String
'			Dim strReportName As String
			Dim strReportFileName As String = "" ' = IO.Path.ChangeExtension(Application.ExecutablePath, "frx")
			'Dim strDictonaryFileName As String = IO.Path.ChangeExtension(Application.ExecutablePath, "frd")
			'Dim strDTDFileName As String = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "CCS.dtd")
			
			Select Case intType
				Case 0 ' e-mail
					strReportFileName = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "stmt_email.frx")
				Case 1 ' Russian Post
					strReportFileName = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "stmt_post.frx")
				Case 2 ' Salary
					strReportFileName = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "ccsxml2pdf.frx")
			End Select
			
			
			report1.Clear
			WriteTrace ("Loading report...")
			report1.Load(strReportFileName)
			
			WriteTrace ("Register data...")
			
'			-------
			dataSet1.Clear
			dataSet1.ReadXml(strXMLFileName)
			report1.RegisterData(dataSet1)
'			-- OR --
'			Dim conn As FastReport.Data.XmlDataConnection = report1.Dictionary.Connections.Item(0)
'			conn.XmlFile = strXmlFileName
'			--------
			report1.PrintSettings.Printer = cbPrinters.Text
			' report1.Design()
			WriteTrace ("Prepare report...")
			Try
				report1.Prepare(False)
			Catch ex As Exception
				MsgBox(ex.Message, MsgBoxStyle.Critical)
			End Try

			' Не печатать отчет, не содержащий ни одного листа.
			If (report1.PreparedPages.Count > 0) AndAlso (report1.ReportInfo.Name <> "<empty>") Then
'				Dim tblGC As Data.DataTable = dataSet1.Tables("G_CLIENT")
'				dtFrom = tblGC.CreateDataReader("STMT_DATE_FROM")
'				dtTo = dataSet1.Tables("G_CLIENT").Columns("STMT_DATE_TO")
'				strEmail = dataSet1.Tables("G_CLIENT").Columns("PARAMETER_B")
'				If intType = 0 OrElse intType=2 Then
'					strReportName = String.Format("{0}={1:yyyymmdd}={2:yyyymmdd}",strEmail, dtFrom, dtTo)
'				Else
'					strReportName = IO.Path.GetFileName(strXmlFileName)
'				End If
'				report1.Name = strReportName
				report1.PrintSettings.ShowDialog = False
				
'				--------
				report1.PrintPrepared()
'				- OR --
'				report1.ShowPrepared()
'				--------

				'report1.SavePrepared(IO.Path.ChangeExtension(strXmlFileName, "fpx"))
				'ExportReportToPDF (report1, IO.Path.ChangeExtension(strXmlFileName, ".+.pdf"))
				Return True
			End If
				Return False
			'If ExportReportToPDF (report1,"C:\result.pdf") Then Return True Else Return False
		End If
	End Function
	
	Function ExportReportToPDF(ByRef Rep As FastReport.Report, strPDFFileName As String) As Boolean
		' создаем экземпляр экспорта в HTML
		Dim export As New FastReport.Export.Pdf.PDFExport
		export.Compressed = False
		Try
			export.Export(report1, strPDFFileName)
			Return True
		Catch
			Return False
		End Try		
	End Function
	
	Sub CbPrintersSelectedIndexChanged(sender As Object, e As EventArgs)
		
	End Sub
	
	Sub BtnOpenReportDesignerClick(sender As Object, e As EventArgs)
		Try
			report1.Design()
		Catch ex As Exception
			MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
'			Throw
		End Try
	End Sub
	
	
	
	Function GetGroupIndex(strFileName As String) As Integer
		If strFileName Like "*__E_48*" Then
			Return 2
		ElseIf strFileName Like "*_C_*" Then
			Return 1
		ElseIf strFileName Like "*_E_*" Then
			Return 0
		Else
			Return -1
		End If
	End Function
	
	
'	Sub BtnOpenXMLClick(sender As Object, e As EventArgs)
'		Dim strXMLFileName As String = "\\rccf.ru\profiles\Office Users\pnosov\My Documents\SharpDevelop Projects\stmt_2013\TEST_XML\04\168137_001_E_31011001920.xml"
'		Dim strReportFileName As String = "U:\My Documents\SharpDevelop Projects\STMT\STMT\stmt_2013_xml.frx"
'		report1.Load(strReportFileName)
'		Dim conn As FastReport.Data.XmlDataConnection = report1.Dictionary.Connections.Item(0)
'		conn.XmlFile = strXmlFileName
'		Debug.WriteLine (conn.ConnectionString)
'		report1.Design()
'	End Sub

	
	
	Sub ListView1SelectedIndexChanged(sender As Object, e As EventArgs)
		If listView1.SelectedIndices.Count>0 Then
			Dim idx As Integer = listView1.SelectedIndices.Item(0)
			If idx >= 0 Then
				WriteTrace (listView1.Items(idx).Text)
			End If
		End If
	End Sub
End Class