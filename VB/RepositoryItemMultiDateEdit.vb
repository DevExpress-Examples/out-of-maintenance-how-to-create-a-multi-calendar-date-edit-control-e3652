Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Imports System.ComponentModel
Imports DevExpress.XtraEditors

Namespace MultiDateEditor
	Public Enum MultiDateEditOptions
		[Single] = 1
		[Double] = 2
		Triple = 3
	End Enum

	' repository item for MultiDateEdit
	Public Class RepositoryItemMultiDateEdit
		Inherits RepositoryItemDateEdit
		' static constructor which calls static registration method
		Shared Sub New()
			RegisterMultiDateEdte()
		End Sub

		' static register method
		Public Shared Sub RegisterMultiDateEdte()
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(MultiDateEditorName, GetType(MultiDateEdit), GetType(RepositoryItemMultiDateEdit), GetType(DateEditViewInfo), New ButtonEditPainter(), True))
		End Sub

		' internal editor name
		Friend Const MultiDateEditorName As String = "MultiDateEdit"

		' public constructor
		Public Sub New()
			MultiEditorType = MultiDateEditOptions.Triple
			VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True
			VistaEditTime = DevExpress.Utils.DefaultBoolean.False
		End Sub

		' new property type of multi date editor
		Protected multiCalendarsCount As MultiDateEditOptions
		<Description("Gets or sets count of calendars in multi date editor."), Category(CategoryName.Appearance), DefaultValue(MultiDateEditOptions.Single)> _
		Public Property MultiEditorType() As MultiDateEditOptions
			Get
				Return multiCalendarsCount
			End Get
			Set(ByVal value As MultiDateEditOptions)
				multiCalendarsCount = value
			End Set
		End Property


		' ovverride property
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return MultiDateEditorName
			End Get
		End Property

		Protected Friend Shadows Function IsVistaDisplayMode() As Boolean
			Return MyBase.IsVistaDisplayMode()
		End Function

		Protected Friend Shadows Function GetVistaEditTime() As Boolean
			Return MyBase.GetVistaEditTime()
		End Function

		Public Overrides Property VistaEditTime() As DevExpress.Utils.DefaultBoolean
			Get
				If multiCalendarsCount = MultiDateEditOptions.Single Then
					Return MyBase.VistaEditTime
				Else
					Return DevExpress.Utils.DefaultBoolean.False
				End If
			End Get
			Set(ByVal value As DevExpress.Utils.DefaultBoolean)
				MyBase.VistaEditTime = value
			End Set
		End Property
	End Class
End Namespace
