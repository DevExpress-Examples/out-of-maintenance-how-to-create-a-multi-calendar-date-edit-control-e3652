Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports MultiDateEditor
Imports DevExpress.XtraEditors.Popup

Namespace MultiDateEditor
	'editor MultiDateEdit
	Public Class MultiDateEdit
		Inherits DateEdit
		' static constructor
		Shared Sub New()
			RepositoryItemMultiDateEdit.RegisterMultiDateEdte()
		End Sub

		' public constructor
		Public Sub New()
		End Sub

		' ovverride property
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemMultiDateEdit.MultiDateEditorName
			End Get
		End Property

		' property as corresponded repositoryitem
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemMultiDateEdit
			Get
				Return TryCast(MyBase.Properties, RepositoryItemMultiDateEdit)
			End Get
		End Property

		' custom methods
		Protected MultiDateEditPopupForm As PopupBaseForm

		Protected Overrides Function CreatePopupForm() As PopupBaseForm
			If Properties.IsVistaDisplayMode() Then
				MultiDateEditPopupForm = New VistaPopupMultiDateEditForm(Me)
			Else
				MultiDateEditPopupForm = New PopupMultiDateEditForm(Me)
			End If
			Return MultiDateEditPopupForm
		End Function
	End Class
End Namespace
