Imports Microsoft.VisualBasic
Imports System
Imports MultiDateEditor
Namespace DoubledMonthDateEdit
	Partial Public Class MainForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.radioGroupCalendarMode = New DevExpress.XtraEditors.RadioGroup()
			Me.checkEditShowTime = New DevExpress.XtraEditors.CheckEdit()
			Me.radioGroupMultiEditorType = New DevExpress.XtraEditors.RadioGroup()
			Me.multiDateEditForTest = New MultiDateEditor.MultiDateEdit()
			CType(Me.radioGroupCalendarMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.checkEditShowTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.radioGroupMultiEditorType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.multiDateEditForTest.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.multiDateEditForTest.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' radioGroupCalendarMode
			' 
			Me.radioGroupCalendarMode.Location = New System.Drawing.Point(15, 113)
			Me.radioGroupCalendarMode.Name = "radioGroupCalendarMode"
			Me.radioGroupCalendarMode.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() { New DevExpress.XtraEditors.Controls.RadioGroupItem("Vista", "Vista mode"), New DevExpress.XtraEditors.Controls.RadioGroupItem("General", "General mode")})
'			Me.radioGroupCalendarMode.Properties.EditValueChanged += New System.EventHandler(Me.radioGroupCalendarMode_Properties_EditValueChanged);
			Me.radioGroupCalendarMode.Size = New System.Drawing.Size(136, 48)
			Me.radioGroupCalendarMode.TabIndex = 2
			' 
			' checkEditShowTime
			' 
			Me.checkEditShowTime.Location = New System.Drawing.Point(13, 88)
			Me.checkEditShowTime.Name = "checkEditShowTime"
			Me.checkEditShowTime.Properties.Caption = "Show time in Vista Mode"
			Me.checkEditShowTime.Size = New System.Drawing.Size(138, 19)
			Me.checkEditShowTime.TabIndex = 3
'			Me.checkEditShowTime.EditValueChanged += New System.EventHandler(Me.checkEditShowTime_EditValueChanged);
			' 
			' radioGroupMultiEditorType
			' 
			Me.radioGroupMultiEditorType.Location = New System.Drawing.Point(157, 113)
			Me.radioGroupMultiEditorType.Name = "radioGroupMultiEditorType"
			Me.radioGroupMultiEditorType.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() { New DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Single"), New DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Double"), New DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Triple")})
'			Me.radioGroupMultiEditorType.Properties.EditValueChanged += New System.EventHandler(Me.radioGroupMultiEditorType_Properties_EditValueChanged);
			Me.radioGroupMultiEditorType.Size = New System.Drawing.Size(166, 48)
			Me.radioGroupMultiEditorType.TabIndex = 4
			' 
			' multiDateEditForTest
			' 
			Me.multiDateEditForTest.EditValue = Nothing
			Me.multiDateEditForTest.Location = New System.Drawing.Point(12, 5)
			Me.multiDateEditForTest.Name = "multiDateEditForTest"
			Me.multiDateEditForTest.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.multiDateEditForTest.Properties.MultiEditorType = MultiDateEditor.MultiDateEditOptions.Triple
			Me.multiDateEditForTest.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True
			Me.multiDateEditForTest.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.False
			Me.multiDateEditForTest.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
			Me.multiDateEditForTest.Size = New System.Drawing.Size(311, 20)
			Me.multiDateEditForTest.TabIndex = 5
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(344, 170)
			Me.Controls.Add(Me.multiDateEditForTest)
			Me.Controls.Add(Me.radioGroupMultiEditorType)
			Me.Controls.Add(Me.checkEditShowTime)
			Me.Controls.Add(Me.radioGroupCalendarMode)
			Me.Name = "MainForm"
			Me.Text = "Application main form"
			CType(Me.radioGroupCalendarMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.checkEditShowTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.radioGroupMultiEditorType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.multiDateEditForTest.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.multiDateEditForTest.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents radioGroupCalendarMode As DevExpress.XtraEditors.RadioGroup
		Private WithEvents checkEditShowTime As DevExpress.XtraEditors.CheckEdit
		Private WithEvents radioGroupMultiEditorType As DevExpress.XtraEditors.RadioGroup
		Private multiDateEditForTest As MultiDateEdit
	End Class
End Namespace

