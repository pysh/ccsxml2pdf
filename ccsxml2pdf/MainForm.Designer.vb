'
' Сделано в SharpDevelop.
' Пользователь: pnosov
' Дата: 30.01.2013
' Время: 11:20
' 
' Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
'
Partial Class MainForm
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim listViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Электронные", System.Windows.Forms.HorizontalAlignment.Left)
		Dim listViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Почта России", System.Windows.Forms.HorizontalAlignment.Left)
		Dim listViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Зарплатные", System.Windows.Forms.HorizontalAlignment.Left)
		Dim listViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Стандартный Продукт", System.Windows.Forms.HorizontalAlignment.Left)
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
		Dim designerSettings1 As FastReport.Design.DesignerSettings = New FastReport.Design.DesignerSettings()
		Dim designerRestrictions1 As FastReport.Design.DesignerRestrictions = New FastReport.Design.DesignerRestrictions()
		Dim emailSettings1 As FastReport.Export.Email.EmailSettings = New FastReport.Export.Email.EmailSettings()
		Dim previewSettings1 As FastReport.PreviewSettings = New FastReport.PreviewSettings()
		Dim reportSettings1 As FastReport.ReportSettings = New FastReport.ReportSettings()
		Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.toolStripButton1 = New System.Windows.Forms.ToolStripButton()
		Me.toolStripButton2 = New System.Windows.Forms.ToolStripButton()
		Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.toolStripButton3 = New System.Windows.Forms.ToolStripButton()
		Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.btnOpenReportDesigner = New System.Windows.Forms.ToolStripButton()
		Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
		Me.cbProcessPriority = New System.Windows.Forms.ToolStripComboBox()
		Me.toolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
		Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
		Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.status1 = New System.Windows.Forms.ToolStripStatusLabel()
		Me.toolStripProgressText = New System.Windows.Forms.ToolStripStatusLabel()
		Me.toolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
		Me.panel1 = New System.Windows.Forms.Panel()
		Me.cbPaperPlain = New System.Windows.Forms.ComboBox()
		Me.label2 = New System.Windows.Forms.Label()
		Me.cbPaperPreprint = New System.Windows.Forms.ComboBox()
		Me.label1 = New System.Windows.Forms.Label()
		Me.chkPreview = New System.Windows.Forms.CheckBox()
		Me.pictureBox1 = New System.Windows.Forms.PictureBox()
		Me.cbPrinters = New System.Windows.Forms.ComboBox()
		Me.btnConvert = New System.Windows.Forms.Button()
		Me.btnClearList = New System.Windows.Forms.Button()
		Me.btnAddFiles = New System.Windows.Forms.Button()
		Me.listView1 = New System.Windows.Forms.ListView()
		Me.СolumnHeader1 = New System.Windows.Forms.ColumnHeader()
		Me.imglstFileStates = New System.Windows.Forms.ImageList(Me.components)
		Me.imgLstFileChk = New System.Windows.Forms.ImageList(Me.components)
		Me.dataSet1 = New System.Data.DataSet()
		Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.environmentSettings1 = New FastReport.EnvironmentSettings()
		Me.toolStrip1.SuspendLayout
		Me.statusStrip1.SuspendLayout
		Me.panel1.SuspendLayout
		CType(Me.pictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.dataSet1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'toolStrip1
		'
		Me.toolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
		Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButton1, Me.toolStripButton2, Me.toolStripSeparator1, Me.toolStripButton3, Me.toolStripSeparator2, Me.btnOpenReportDesigner, Me.toolStripSeparator3, Me.cbProcessPriority, Me.toolStripLabel1, Me.toolStripSeparator4})
		Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.toolStrip1.Name = "toolStrip1"
		Me.toolStrip1.Size = New System.Drawing.Size(844, 39)
		Me.toolStrip1.TabIndex = 0
		Me.toolStrip1.Text = "toolStrip1"
		'
		'toolStripButton1
		'
		Me.toolStripButton1.Image = Global.ccsxml2pdf.Resource1.Add
		Me.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Transparent
		Me.toolStripButton1.Name = "toolStripButton1"
		Me.toolStripButton1.Size = New System.Drawing.Size(130, 36)
		Me.toolStripButton1.Text = "Добавить файлы"
		AddHandler Me.toolStripButton1.Click, AddressOf Me.BtnAddFilesClick
		'
		'toolStripButton2
		'
		Me.toolStripButton2.Image = Global.ccsxml2pdf.Resource1.Delete
		Me.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Transparent
		Me.toolStripButton2.Name = "toolStripButton2"
		Me.toolStripButton2.Size = New System.Drawing.Size(129, 36)
		Me.toolStripButton2.Text = "Очистить список"
		AddHandler Me.toolStripButton2.Click, AddressOf Me.BtnClearListClick
		'
		'toolStripSeparator1
		'
		Me.toolStripSeparator1.Name = "toolStripSeparator1"
		Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 39)
		'
		'toolStripButton3
		'
		Me.toolStripButton3.Image = Global.ccsxml2pdf.Resource1.Page_White_Acrobat_32x32
		Me.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Transparent
		Me.toolStripButton3.Name = "toolStripButton3"
		Me.toolStripButton3.Size = New System.Drawing.Size(78, 36)
		Me.toolStripButton3.Text = "Запуск"
		AddHandler Me.toolStripButton3.Click, AddressOf Me.BtnConvertClick
		'
		'toolStripSeparator2
		'
		Me.toolStripSeparator2.Name = "toolStripSeparator2"
		Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 39)
		'
		'btnOpenReportDesigner
		'
		Me.btnOpenReportDesigner.Image = Global.ccsxml2pdf.Resource1.Page_White_Edit
		Me.btnOpenReportDesigner.ImageTransparentColor = System.Drawing.Color.Transparent
		Me.btnOpenReportDesigner.Name = "btnOpenReportDesigner"
		Me.btnOpenReportDesigner.Size = New System.Drawing.Size(155, 36)
		Me.btnOpenReportDesigner.Text = "Редактировать отчет"
		AddHandler Me.btnOpenReportDesigner.Click, AddressOf Me.BtnOpenReportDesignerClick
		'
		'toolStripSeparator3
		'
		Me.toolStripSeparator3.Name = "toolStripSeparator3"
		Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 39)
		'
		'cbProcessPriority
		'
		Me.cbProcessPriority.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.cbProcessPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbProcessPriority.Name = "cbProcessPriority"
		Me.cbProcessPriority.Size = New System.Drawing.Size(121, 39)
		AddHandler Me.cbProcessPriority.SelectedIndexChanged, AddressOf Me.CbProcessPriority_SelectedIndexChanged
		'
		'toolStripLabel1
		'
		Me.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.toolStripLabel1.Name = "toolStripLabel1"
		Me.toolStripLabel1.Size = New System.Drawing.Size(62, 36)
		Me.toolStripLabel1.Text = "Приоритет"
		AddHandler Me.toolStripLabel1.DoubleClick, AddressOf Me.ToolStripLabel1_DoubleClick
		'
		'toolStripSeparator4
		'
		Me.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.toolStripSeparator4.Name = "toolStripSeparator4"
		Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 39)
		'
		'statusStrip1
		'
		Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status1, Me.toolStripProgressText, Me.toolStripProgressBar1})
		Me.statusStrip1.Location = New System.Drawing.Point(0, 381)
		Me.statusStrip1.Name = "statusStrip1"
		Me.statusStrip1.Size = New System.Drawing.Size(844, 22)
		Me.statusStrip1.TabIndex = 1
		Me.statusStrip1.Text = "statusStrip1"
		'
		'status1
		'
		Me.status1.Name = "status1"
		Me.status1.Size = New System.Drawing.Size(604, 17)
		Me.status1.Spring = true
		Me.status1.Text = "Ready."
		Me.status1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'toolStripProgressText
		'
		Me.toolStripProgressText.Name = "toolStripProgressText"
		Me.toolStripProgressText.Size = New System.Drawing.Size(23, 17)
		Me.toolStripProgressText.Text = "0/0"
		'
		'toolStripProgressBar1
		'
		Me.toolStripProgressBar1.Name = "toolStripProgressBar1"
		Me.toolStripProgressBar1.Size = New System.Drawing.Size(200, 16)
		Me.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
		'
		'panel1
		'
		Me.panel1.Controls.Add(Me.cbPaperPlain)
		Me.panel1.Controls.Add(Me.label2)
		Me.panel1.Controls.Add(Me.cbPaperPreprint)
		Me.panel1.Controls.Add(Me.label1)
		Me.panel1.Controls.Add(Me.chkPreview)
		Me.panel1.Controls.Add(Me.pictureBox1)
		Me.panel1.Controls.Add(Me.cbPrinters)
		Me.panel1.Controls.Add(Me.btnConvert)
		Me.panel1.Controls.Add(Me.btnClearList)
		Me.panel1.Controls.Add(Me.btnAddFiles)
		Me.panel1.Dock = System.Windows.Forms.DockStyle.Left
		Me.panel1.Location = New System.Drawing.Point(0, 39)
		Me.panel1.Name = "panel1"
		Me.panel1.Size = New System.Drawing.Size(331, 342)
		Me.panel1.TabIndex = 2
		'
		'cbPaperPlain
		'
		Me.cbPaperPlain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbPaperPlain.FormattingEnabled = true
		Me.cbPaperPlain.Location = New System.Drawing.Point(89, 87)
		Me.cbPaperPlain.Name = "cbPaperPlain"
		Me.cbPaperPlain.Size = New System.Drawing.Size(224, 21)
		Me.cbPaperPlain.TabIndex = 9
		AddHandler Me.cbPaperPlain.SelectionChangeCommitted, AddressOf Me.CbPaperPlain_SelectionChangeCommitted
		'
		'label2
		'
		Me.label2.Location = New System.Drawing.Point(34, 90)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(49, 18)
		Me.label2.TabIndex = 8
		Me.label2.Text = "Бумага"
		'
		'cbPaperPreprint
		'
		Me.cbPaperPreprint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbPaperPreprint.FormattingEnabled = true
		Me.cbPaperPreprint.Location = New System.Drawing.Point(89, 60)
		Me.cbPaperPreprint.Name = "cbPaperPreprint"
		Me.cbPaperPreprint.Size = New System.Drawing.Size(224, 21)
		Me.cbPaperPreprint.TabIndex = 7
		AddHandler Me.cbPaperPreprint.SelectionChangeCommitted, AddressOf Me.CbPaperPreprint_SelectionChangeCommitted
		'
		'label1
		'
		Me.label1.Location = New System.Drawing.Point(34, 63)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(49, 18)
		Me.label1.TabIndex = 6
		Me.label1.Text = "Бланки"
		'
		'chkPreview
		'
		Me.chkPreview.Location = New System.Drawing.Point(89, 114)
		Me.chkPreview.Name = "chkPreview"
		Me.chkPreview.Size = New System.Drawing.Size(140, 24)
		Me.chkPreview.TabIndex = 5
		Me.chkPreview.Text = "Предпросмотр отчета"
		Me.chkPreview.UseVisualStyleBackColor = true
		'
		'pictureBox1
		'
		Me.pictureBox1.Image = Global.ccsxml2pdf.Resource1.Printer
		Me.pictureBox1.Location = New System.Drawing.Point(11, 33)
		Me.pictureBox1.Name = "pictureBox1"
		Me.pictureBox1.Size = New System.Drawing.Size(16, 16)
		Me.pictureBox1.TabIndex = 4
		Me.pictureBox1.TabStop = false
		'
		'cbPrinters
		'
		Me.cbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbPrinters.FormattingEnabled = true
		Me.cbPrinters.Location = New System.Drawing.Point(33, 33)
		Me.cbPrinters.Name = "cbPrinters"
		Me.cbPrinters.Size = New System.Drawing.Size(280, 21)
		Me.cbPrinters.TabIndex = 3
		AddHandler Me.cbPrinters.SelectedIndexChanged, AddressOf Me.CbPrintersSelectedIndexChanged
		'
		'btnConvert
		'
		Me.btnConvert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.btnConvert.Image = Global.ccsxml2pdf.Resource1.Page_White_Acrobat_32x32
		Me.btnConvert.ImageAlign = System.Drawing.ContentAlignment.TopCenter
		Me.btnConvert.Location = New System.Drawing.Point(229, 276)
		Me.btnConvert.Name = "btnConvert"
		Me.btnConvert.Size = New System.Drawing.Size(84, 55)
		Me.btnConvert.TabIndex = 2
		Me.btnConvert.Text = "Поехали!"
		Me.btnConvert.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnConvert.UseVisualStyleBackColor = true
		AddHandler Me.btnConvert.Click, AddressOf Me.BtnConvertClick
		'
		'btnClearList
		'
		Me.btnClearList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.btnClearList.Image = Global.ccsxml2pdf.Resource1.Delete
		Me.btnClearList.ImageAlign = System.Drawing.ContentAlignment.TopCenter
		Me.btnClearList.Location = New System.Drawing.Point(120, 276)
		Me.btnClearList.Name = "btnClearList"
		Me.btnClearList.Size = New System.Drawing.Size(103, 55)
		Me.btnClearList.TabIndex = 1
		Me.btnClearList.Text = "Очистить список"
		Me.btnClearList.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnClearList.UseVisualStyleBackColor = true
		AddHandler Me.btnClearList.Click, AddressOf Me.BtnClearListClick
		'
		'btnAddFiles
		'
		Me.btnAddFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.btnAddFiles.Image = Global.ccsxml2pdf.Resource1.Add
		Me.btnAddFiles.ImageAlign = System.Drawing.ContentAlignment.TopCenter
		Me.btnAddFiles.Location = New System.Drawing.Point(12, 276)
		Me.btnAddFiles.Name = "btnAddFiles"
		Me.btnAddFiles.Size = New System.Drawing.Size(102, 55)
		Me.btnAddFiles.TabIndex = 0
		Me.btnAddFiles.Text = "Добавить файлы"
		Me.btnAddFiles.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnAddFiles.UseVisualStyleBackColor = true
		AddHandler Me.btnAddFiles.Click, AddressOf Me.BtnAddFilesClick
		'
		'listView1
		'
		Me.listView1.AllowDrop = true
		Me.listView1.BackColor = System.Drawing.SystemColors.Window
		Me.listView1.CheckBoxes = true
		Me.listView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.СolumnHeader1})
		Me.listView1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.listView1.FullRowSelect = true
		Me.listView1.GridLines = true
		listViewGroup1.Header = "Электронные"
		listViewGroup1.Name = "grpEmail"
		listViewGroup2.Header = "Почта России"
		listViewGroup2.Name = "grpRusPost"
		listViewGroup3.Header = "Зарплатные"
		listViewGroup3.Name = "grpSalary"
		listViewGroup4.Header = "Стандартный Продукт"
		listViewGroup4.Name = "grpStandardProduct"
		Me.listView1.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {listViewGroup1, listViewGroup2, listViewGroup3, listViewGroup4})
		Me.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
		Me.listView1.HideSelection = false
		Me.listView1.Location = New System.Drawing.Point(331, 39)
		Me.listView1.MultiSelect = false
		Me.listView1.Name = "listView1"
		Me.listView1.Size = New System.Drawing.Size(513, 342)
		Me.listView1.SmallImageList = Me.imglstFileStates
		Me.listView1.StateImageList = Me.imgLstFileChk
		Me.listView1.TabIndex = 20
		Me.listView1.UseCompatibleStateImageBehavior = false
		Me.listView1.View = System.Windows.Forms.View.Details
		AddHandler Me.listView1.SelectedIndexChanged, AddressOf Me.ListView1SelectedIndexChanged
		AddHandler Me.listView1.DragDrop, AddressOf Me.ListView1DragDrop
		AddHandler Me.listView1.DragEnter, AddressOf Me.ListView1DragEnter
		'
		'СolumnHeader1
		'
		Me.СolumnHeader1.Text = "Имя файла"
		Me.СolumnHeader1.Width = 509
		'
		'imglstFileStates
		'
		Me.imglstFileStates.ImageStream = CType(resources.GetObject("imglstFileStates.ImageStream"),System.Windows.Forms.ImageListStreamer)
		Me.imglstFileStates.TransparentColor = System.Drawing.Color.Transparent
		Me.imglstFileStates.Images.SetKeyName(0, "page_white")
		Me.imglstFileStates.Images.SetKeyName(1, "printer")
		Me.imglstFileStates.Images.SetKeyName(2, "accept")
		Me.imglstFileStates.Images.SetKeyName(3, "page_white_go")
		Me.imglstFileStates.Images.SetKeyName(4, "error")
		Me.imglstFileStates.Images.SetKeyName(5, "exclamation")
		'
		'imgLstFileChk
		'
		Me.imgLstFileChk.ImageStream = CType(resources.GetObject("imgLstFileChk.ImageStream"),System.Windows.Forms.ImageListStreamer)
		Me.imgLstFileChk.TransparentColor = System.Drawing.Color.Transparent
		Me.imgLstFileChk.Images.SetKeyName(0, "control_play.png")
		Me.imgLstFileChk.Images.SetKeyName(1, "control_pause.png")
		'
		'dataSet1
		'
		Me.dataSet1.DataSetName = "NewDataSet"
		'
		'openFileDialog1
		'
		Me.openFileDialog1.DefaultExt = "xml"
		Me.openFileDialog1.Filter = "XML файлы (*.xml)|*.xml|Все файлы (*.*)|*.*"
		Me.openFileDialog1.Multiselect = true
		Me.openFileDialog1.Title = "Выберите XML файлы для преобразования"
		'
		'environmentSettings1
		'
		designerSettings1.ApplicationConnection = Nothing
		designerSettings1.DefaultFont = New System.Drawing.Font("Arial", 10!)
		designerSettings1.Icon = Nothing
		designerSettings1.Restrictions = designerRestrictions1
		designerSettings1.Text = ""
		Me.environmentSettings1.DesignerSettings = designerSettings1
		emailSettings1.Address = ""
		emailSettings1.Host = ""
		emailSettings1.MessageTemplate = ""
		emailSettings1.Name = ""
		emailSettings1.Password = ""
		emailSettings1.UserName = ""
		Me.environmentSettings1.EmailSettings = emailSettings1
		previewSettings1.Icon = CType(resources.GetObject("previewSettings1.Icon"),System.Drawing.Icon)
		previewSettings1.Text = ""
		Me.environmentSettings1.PreviewSettings = previewSettings1
		reportSettings1.DefaultLanguage = FastReport.Language.Vb
		reportSettings1.ShowProgress = false
		Me.environmentSettings1.ReportSettings = reportSettings1
		Me.environmentSettings1.UIStyle = FastReport.Utils.UIStyle.VisualStudio2005
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(844, 403)
		Me.Controls.Add(Me.listView1)
		Me.Controls.Add(Me.panel1)
		Me.Controls.Add(Me.statusStrip1)
		Me.Controls.Add(Me.toolStrip1)
		Me.Name = "MainForm"
		Me.Text = "STMT_2014"
		Me.toolStrip1.ResumeLayout(false)
		Me.toolStrip1.PerformLayout
		Me.statusStrip1.ResumeLayout(false)
		Me.statusStrip1.PerformLayout
		Me.panel1.ResumeLayout(false)
		CType(Me.pictureBox1,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.dataSet1,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private imgLstFileChk As System.Windows.Forms.ImageList
	Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
	Private toolStripLabel1 As System.Windows.Forms.ToolStripLabel
	Private toolStripProgressText As System.Windows.Forms.ToolStripStatusLabel
	Private cbProcessPriority As System.Windows.Forms.ToolStripComboBox
	Private cbPaperPlain As System.Windows.Forms.ComboBox
	Private cbPaperPreprint As System.Windows.Forms.ComboBox
	Private label1 As System.Windows.Forms.Label
	Private label2 As System.Windows.Forms.Label
	Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
	Private toolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
	Private environmentSettings1 As FastReport.EnvironmentSettings
	Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
	Private toolStripButton3 As System.Windows.Forms.ToolStripButton
	Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Private toolStripButton2 As System.Windows.Forms.ToolStripButton
	Private toolStripButton1 As System.Windows.Forms.ToolStripButton
	Private chkPreview As System.Windows.Forms.CheckBox
	Private pictureBox1 As System.Windows.Forms.PictureBox
	Private btnOpenReportDesigner As System.Windows.Forms.ToolStripButton
	Private cbPrinters As System.Windows.Forms.ComboBox
	Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
	Private status1 As System.Windows.Forms.ToolStripStatusLabel
	Private dataSet1 As System.Data.DataSet
	Private imglstFileStates As System.Windows.Forms.ImageList
	Private btnAddFiles As System.Windows.Forms.Button
	Private btnClearList As System.Windows.Forms.Button
	Private btnConvert As System.Windows.Forms.Button
	Private СolumnHeader1 As System.Windows.Forms.ColumnHeader
	Private listView1 As System.Windows.Forms.ListView
	Private panel1 As System.Windows.Forms.Panel
	Private statusStrip1 As System.Windows.Forms.StatusStrip
	Private toolStrip1 As System.Windows.Forms.ToolStrip
End Class
