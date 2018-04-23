Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.XtraEditors.Controls
Imports System.Drawing

Namespace MultiDateEditor
	' new popup form fo Vista mode
	Public Class VistaPopupMultiDateEditForm
		Inherits VistaPopupDateEditForm
		' constructor
		Public Sub New(ByVal OwnerEdit As MultiDateEdit)
			MyBase.New(OwnerEdit)
		End Sub

		' methods
		Protected Overrides Function CreateCalendar() As DateEditCalendar
			Dim newCalendar As New VistaMultiDateEditCalendar(OwnerEdit.Properties, OwnerEdit.EditValue)
			AddHandler newCalendar.OkClick, AddressOf newCalendar_OkClick
			Return newCalendar
		End Function

		Private Sub newCalendar_OkClick(ByVal sender As Object, ByVal e As EventArgs)
			If OwnerEdit IsNot Nothing Then
				OwnerEdit.ClosePopup()
			End If
		End Sub

		Protected Friend Function CalcMultiEditPopupFormSize(ByVal currentSize As Size) As Size
			Dim returnedSize As Size = MyBase.CalcFormSize(currentSize)
			If Calendar.View = DateEditCalendarViewType.MonthInfo Then
				returnedSize.Width *= CInt(Fix((TryCast(OwnerEdit.Properties, RepositoryItemMultiDateEdit)).MultiEditorType))
			End If
			Return returnedSize
		End Function

		Public Overrides Overloads Function CalcFormSize(ByVal contentSize As Size) As Size
			Return CalcMultiEditPopupFormSize(contentSize)
		End Function
	End Class
End Namespace
