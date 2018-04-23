Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.XtraEditors.Controls
Imports System.Drawing

Namespace MultiDateEditor
	' my popup form for MultiDateEdit
	Public Class PopupMultiDateEditForm
		Inherits PopupDateEditForm
		' constructor
		Public Sub New(ByVal OwnerEdit As MultiDateEdit)
			MyBase.New(OwnerEdit)
		End Sub

		' override methods
		Protected Overrides Function CreateCalendar() As DateEditCalendar
			Return New MultiDateEditCalendar(OwnerEdit.Properties, OwnerEdit.EditValue)
		End Function

		Public Overrides Overloads Function CalcFormSize(ByVal contentSize As Size) As Size
			Dim returnedSize As Size = MyBase.CalcFormSize(contentSize)
			returnedSize.Width *= CInt(Fix((TryCast(OwnerEdit.Properties, RepositoryItemMultiDateEdit)).MultiEditorType))
			Return returnedSize
		End Function
	End Class
End Namespace
