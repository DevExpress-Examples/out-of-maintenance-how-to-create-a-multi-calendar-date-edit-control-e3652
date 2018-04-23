Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.ViewInfo
Imports System.Drawing

Namespace MultiDateEditor
	Friend Class MultiDateEditInfoArgs
		Inherits DateEditInfoArgs
		' constructor
		Public Sub New(ByVal OwnerCalendar As MultiDateEditCalendar)
			MyBase.New(OwnerCalendar)
		End Sub

		Protected Sub SetMonthYearButtonState(ByVal DMState As Boolean, ByVal IMState As Boolean, ByVal DYState As Boolean, ByVal IYState As Boolean)
			ShowDecMonth = DMState
			ShowIncMonth = IMState
			ShowDecYear = DYState
			ShowIncYear = IYState
			DecMonthInfo.State = If(DMState = True, DevExpress.Utils.Drawing.ObjectState.Normal, DevExpress.Utils.Drawing.ObjectState.Disabled)
			IncMonthInfo.State = If(IMState = True, DevExpress.Utils.Drawing.ObjectState.Normal, DevExpress.Utils.Drawing.ObjectState.Disabled)
			DecYearInfo.State = If(DYState = True, DevExpress.Utils.Drawing.ObjectState.Normal, DevExpress.Utils.Drawing.ObjectState.Disabled)
			IncYearInfo.State = If(IYState = True, DevExpress.Utils.Drawing.ObjectState.Normal, DevExpress.Utils.Drawing.ObjectState.Disabled)
		End Sub

		Protected Overrides Sub CalcHeaderInfo()
			MyBase.CalcHeaderInfo()
			Dim currentCalendar As MultiDateEditCalendar = TryCast(Calendar, MultiDateEditCalendar)
			Dim currentRepository As RepositoryItemMultiDateEdit = TryCast(currentCalendar.Properties, RepositoryItemMultiDateEdit)
			If currentRepository.MultiEditorType <> MultiDateEditOptions.Single Then
				If Bounds.X = currentCalendar.CalendarsRecr.Left Then ' its a first calendar
					SetMonthYearButtonState(True, False, False, False)
					EditYear = Rectangle.Empty
					EditMonth.X = Bounds.Width - EditMonth.Width - Bounds.X
					DecMonthInfo.Bounds = New Rectangle(EditMonth.X - DecMonthInfo.Bounds.Width - Bounds.X, DecMonthInfo.Bounds.Y, DecMonthInfo.Bounds.Width, DecMonthInfo.Bounds.Height)
				ElseIf (Bounds.X + Bounds.Width) = currentCalendar.CalendarsRecr.Right Then ' its a last calendar
					SetMonthYearButtonState(False, True, True, True)
					DecYearInfo.Bounds = New Rectangle(EditYear.X - IncYearInfo.Bounds.Width, IncYearInfo.Bounds.Y, IncYearInfo.Bounds.Width, IncYearInfo.Bounds.Height)

				Else
					SetMonthYearButtonState(False, False, False, False)
					EditMonth.X = Bounds.X + (Bounds.Width - EditMonth.Width) / 2
					EditYear = Rectangle.Empty
				End If
			End If
		End Sub
	End Class
End Namespace
