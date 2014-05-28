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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
		Dim listViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Электронные", System.Windows.Forms.HorizontalAlignment.Left)
		Dim listViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Почта России", System.Windows.Forms.HorizontalAlignment.Left)
		Dim listViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Зарплатные", System.Windows.Forms.HorizontalAlignment.Left)
		Dim designerSettings1 As FastReport.Design.DesignerSettings = New FastReport.Design.DesignerSettings()
		Dim designerRestrictions1 As FastReport.Design.DesignerRestrictions = New FastReport.Design.DesignerRestrictions()
		Dim emailSettings1 As FastReport.Export.Email.EmailSettings = New FastReport.Export.Email.EmailSettings()
		Dim previewSettings1 As FastReport.PreviewSettings = New FastReport.PreviewSettings()
		Dim reportSettings1 As FastReport.ReportSettings = New FastReport.ReportSettings()
		Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.btnOpenReportDesigner = New System.Windows.Forms.ToolStripButton()
		Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.status1 = New System.Windows.Forms.ToolStripStatusLabel()
		Me.panel1 = New System.Windows.Forms.Panel()
		Me.pictureBox1 = New System.Windows.Forms.PictureBox()
		Me.cbPrinters = New System.Windows.Forms.ComboBox()
		Me.btnConvert = New System.Windows.Forms.Button()
		Me.btnClearList = New System.Windows.Forms.Button()
		Me.btnAddFiles = New System.Windows.Forms.Button()
		Me.listView1 = New System.Windows.Forms.ListView()
		Me.СolumnHeader1 = New System.Windows.Forms.ColumnHeader()
		Me.imglstFileStates = New System.Windows.Forms.ImageList(Me.components)
		Me.report1 = New FastReport.Report()
		Me.dataSet1 = New System.Data.DataSet()
		Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.environmentSettings1 = New FastReport.EnvironmentSettings()
		Me.toolStrip1.SuspendLayout
		Me.statusStrip1.SuspendLayout
		Me.panel1.SuspendLayout
		CType(Me.pictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.report1,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.dataSet1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'toolStrip1
		'
		Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpenReportDesigner})
		Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.toolStrip1.Name = "toolStrip1"
		Me.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
		Me.toolStrip1.Size = New System.Drawing.Size(651, 25)
		Me.toolStrip1.TabIndex = 0
		Me.toolStrip1.Text = "toolStrip1"
		'
		'btnOpenReportDesigner
		'
		Me.btnOpenReportDesigner.Image = CType(resources.GetObject("btnOpenReportDesigner.Image"),System.Drawing.Image)
		Me.btnOpenReportDesigner.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnOpenReportDesigner.Name = "btnOpenReportDesigner"
		Me.btnOpenReportDesigner.Size = New System.Drawing.Size(139, 22)
		Me.btnOpenReportDesigner.Text = "Редактировать отчет"
		AddHandler Me.btnOpenReportDesigner.Click, AddressOf Me.BtnOpenReportDesignerClick
		'
		'statusStrip1
		'
		Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status1})
		Me.statusStrip1.Location = New System.Drawing.Point(0, 341)
		Me.statusStrip1.Name = "statusStrip1"
		Me.statusStrip1.Size = New System.Drawing.Size(651, 22)
		Me.statusStrip1.TabIndex = 1
		Me.statusStrip1.Text = "statusStrip1"
		'
		'status1
		'
		Me.status1.Name = "status1"
		Me.status1.Size = New System.Drawing.Size(636, 17)
		Me.status1.Spring = true
		Me.status1.Text = "Ready."
		Me.status1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'panel1
		'
		Me.panel1.Controls.Add(Me.pictureBox1)
		Me.panel1.Controls.Add(Me.cbPrinters)
		Me.panel1.Controls.Add(Me.btnConvert)
		Me.panel1.Controls.Add(Me.btnClearList)
		Me.panel1.Controls.Add(Me.btnAddFiles)
		Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.panel1.Location = New System.Drawing.Point(0, 289)
		Me.panel1.Name = "panel1"
		Me.panel1.Size = New System.Drawing.Size(651, 52)
		Me.panel1.TabIndex = 2
		'
		'pictureBox1
		'
		Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"),System.Drawing.Image)
		Me.pictureBox1.Location = New System.Drawing.Point(301, 19)
		Me.pictureBox1.Name = "pictureBox1"
		Me.pictureBox1.Size = New System.Drawing.Size(16, 16)
		Me.pictureBox1.TabIndex = 4
		Me.pictureBox1.TabStop = false
		'
		'cbPrinters
		'
		Me.cbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbPrinters.FormattingEnabled = true
		Me.cbPrinters.Location = New System.Drawing.Point(323, 19)
		Me.cbPrinters.Name = "cbPrinters"
		Me.cbPrinters.Size = New System.Drawing.Size(177, 21)
		Me.cbPrinters.TabIndex = 3
		AddHandler Me.cbPrinters.SelectedIndexChanged, AddressOf Me.CbPrintersSelectedIndexChanged
		'
		'btnConvert
		'
		Me.btnConvert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnConvert.Location = New System.Drawing.Point(555, 17)
		Me.btnConvert.Name = "btnConvert"
		Me.btnConvert.Size = New System.Drawing.Size(84, 23)
		Me.btnConvert.TabIndex = 2
		Me.btnConvert.Text = "Поехали!"
		Me.btnConvert.UseVisualStyleBackColor = true
		AddHandler Me.btnConvert.Click, AddressOf Me.BtnConvertClick
		'
		'btnClearList
		'
		Me.btnClearList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.btnClearList.Location = New System.Drawing.Point(120, 17)
		Me.btnClearList.Name = "btnClearList"
		Me.btnClearList.Size = New System.Drawing.Size(104, 23)
		Me.btnClearList.TabIndex = 1
		Me.btnClearList.Text = "Очистить список"
		Me.btnClearList.UseVisualStyleBackColor = true
		AddHandler Me.btnClearList.Click, AddressOf Me.BtnClearListClick
		'
		'btnAddFiles
		'
		Me.btnAddFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.btnAddFiles.Location = New System.Drawing.Point(12, 17)
		Me.btnAddFiles.Name = "btnAddFiles"
		Me.btnAddFiles.Size = New System.Drawing.Size(102, 23)
		Me.btnAddFiles.TabIndex = 0
		Me.btnAddFiles.Text = "Добавить файлы"
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
		listViewGroup1.Header = "Электронные"
		listViewGroup1.Name = "grpEmail"
		listViewGroup2.Header = "Почта России"
		listViewGroup2.Name = "grpRusPost"
		listViewGroup3.Header = "Зарплатные"
		listViewGroup3.Name = "grpSalary"
		Me.listView1.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {listViewGroup1, listViewGroup2, listViewGroup3})
		Me.listView1.Location = New System.Drawing.Point(0, 25)
		Me.listView1.MultiSelect = false
		Me.listView1.Name = "listView1"
		Me.listView1.Size = New System.Drawing.Size(651, 264)
		Me.listView1.StateImageList = Me.imglstFileStates
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
		Me.СolumnHeader1.Width = 634
		'
		'imglstFileStates
		'
		Me.imglstFileStates.ImageStream = CType(resources.GetObject("imglstFileStates.ImageStream"),System.Windows.Forms.ImageListStreamer)
		Me.imglstFileStates.TransparentColor = System.Drawing.Color.Transparent
		Me.imglstFileStates.Images.SetKeyName(0, "page_white.png")
		Me.imglstFileStates.Images.SetKeyName(1, "cog.png")
		Me.imglstFileStates.Images.SetKeyName(2, "accept.png")
		'
		'report1
		'
		Me.report1.ReportResourceString = ""
		Me.report1.StoreInResources = false
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
		designerSettings1.Icon = CType(resources.GetObject("designerSettings1.Icon"),System.Drawing.Icon)
		designerSettings1.Restrictions = designerRestrictions1
		designerSettings1.Text = "STMT. Редактор отчета"
		Me.environmentSettings1.DesignerSettings = designerSettings1
		emailSettings1.Address = ""
		emailSettings1.Host = ""
		emailSettings1.MessageTemplate = ""
		emailSettings1.Name = ""
		emailSettings1.Password = ""
		emailSettings1.UserName = ""
		Me.environmentSettings1.EmailSettings = emailSettings1
		previewSettings1.Icon = CType(resources.GetObject("previewSettings1.Icon"),System.Drawing.Icon)
		previewSettings1.Text = "STMT. Отчет об операциях"
		Me.environmentSettings1.PreviewSettings = previewSettings1
		reportSettings1.DefaultLanguage = FastReport.Language.Vb
		reportSettings1.ShowPerformance = true
		reportSettings1.ShowProgress = false
		Me.environmentSettings1.ReportSettings = reportSettings1
		Me.environmentSettings1.UIStyle = FastReport.Utils.UIStyle.Office2007Black
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(651, 363)
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
		CType(Me.report1,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.dataSet1,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private pictureBox1 As System.Windows.Forms.PictureBox
	Private btnOpenReportDesigner As System.Windows.Forms.ToolStripButton
	Private environmentSettings1 As FastReport.EnvironmentSettings
	Private cbPrinters As System.Windows.Forms.ComboBox
	Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
	Private status1 As System.Windows.Forms.ToolStripStatusLabel
	Private dataSet1 As System.Data.DataSet
	Private report1 As FastReport.Report
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
