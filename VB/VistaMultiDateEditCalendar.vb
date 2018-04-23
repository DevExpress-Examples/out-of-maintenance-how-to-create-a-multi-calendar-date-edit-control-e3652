Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports System.Drawing
Imports DevExpress.XtraEditors.Calendar
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors

Namespace MultiDateEditor
	Public Class VistaMultiDateEditCalendar
		Inherits VistaDateEditCalendar
		Public Sub New(ByVal item As RepositoryItemDateEdit, ByVal editValue As Object)
			MyBase.New(item, editValue)
		End Sub

		Friend Shared Function GetFirstMonthDate(ByVal [date] As DateTime) As DateTime
			Return New DateTime([date].Year, [date].Month, 1, [date].Hour, [date].Minute, [date].Second, [date].Millisecond)
		End Function

		' new property
		Protected Friend Shadows ReadOnly Property CalendarsRect() As Rectangle
			Get
				Return MyBase.CalendarsRect
			End Get
		End Property

		' override metods
		Protected Overrides Function CreatePainter() As DateEditPainter
			Return New VistaMultiDateEditCalendarPainter(Me)
		End Function

		Protected Overrides Function CreateInfoArgs() As DateEditInfoArgs
			Return New VistaMultiDateEditInfoArgs(Me)
		End Function

		Protected Friend Shadows Property SwitchState() As Boolean
			Get
				Return MyBase.SwitchState
			End Get
			Set(ByVal value As Boolean)
				MyBase.SwitchState = value
			End Set
		End Property

		Protected Friend Shadows ReadOnly Property ClockPainter() As VistaDateEditClockPainter
			Get
				Return New VistaMultiDateEditClockPainter(Me)
			End Get
		End Property

		Protected Friend Shadows ReadOnly Property TimeEdit() As TimeEdit
			Get
				Return MyBase.TimeEdit
			End Get
		End Property

		Protected Friend Shadows Property LockAnimation() As Integer
			Get
				Return MyBase.LockAnimation
			End Get
			Set(ByVal value As Integer)
				MyBase.LockAnimation = value
			End Set
		End Property

		Protected Friend Shadows ReadOnly Property CaptionRect() As Rectangle
			Get
				Return MyBase.CaptionRect
			End Get
		End Property
		Protected Friend Shadows ReadOnly Property CaptionButtonRect() As Rectangle
			Get
				Return MyBase.CaptionButtonRect
			End Get
		End Property
		Protected Friend Shadows ReadOnly Property CurrentDateButtonRect() As Rectangle
			Get
				Return MyBase.CurrentDateButtonRect
			End Get
		End Property
		Protected Friend Shadows ReadOnly Property CurrentDateRect() As Rectangle
			Get
				Return MyBase.CurrentDateRect
			End Get
		End Property

		Friend Shadows ReadOnly Property HotObject() As Object
			Get
				Return MyBase.HotObject
			End Get
		End Property

		Protected Overrides Sub OnHotObjectChanged(ByVal prevInfo As CalendarHitInfo, ByVal currInfo As CalendarHitInfo)
			For Each vdi As VistaMultiDateEditInfoArgs In Calendars
				Dim hitInfo As CalendarHitInfo = TryCast((TryCast(vdi.Calendar, VistaMultiDateEditCalendar)).HotObject, CalendarHitInfo)
				If vdi.Bounds.Contains(hitInfo.Pt) OrElse hitInfo.InfoType = CalendarHitInfoType.Clear OrElse hitInfo.InfoType = CalendarHitInfoType.Ok OrElse hitInfo.InfoType = CalendarHitInfoType.Cancel Then ' if (vdi.Bounds.Contains(hitInfo.Pt))//if(vdi.Bounds.Contains(currInfo.Pt))
					vdi.UpdateExistingCellsState()
					vdi.OnAnimationChanged(prevInfo, currInfo)
					If currInfo IsNot Nothing Then
						If currInfo.InfoType = CalendarHitInfoType.LeftArrow AndAlso vdi.LeftArrowInfo.State <> ObjectState.Pressed Then
							vdi.LeftArrowInfo.State = ObjectState.Hot
						End If
						If currInfo.InfoType = CalendarHitInfoType.RightArrow AndAlso vdi.RightArrowInfo.State <> ObjectState.Pressed Then
							vdi.RightArrowInfo.State = ObjectState.Hot
						End If
					End If
					If TypeOf hitInfo.HitObject Is DayNumberCellInfo Then
						TryCast(hitInfo.HitObject, DayNumberCellInfo).State = ObjectState.Hot
					End If
					Exit For
				End If
			Next vdi
		End Sub

		Protected Overrides Sub OnHotObjectChanging(ByVal prevInfo As CalendarHitInfo, ByVal currInfo As CalendarHitInfo)
		   For Each vdi As VistaMultiDateEditInfoArgs In Calendars
				Dim hitInfo As CalendarHitInfo = TryCast((TryCast(vdi.Calendar, VistaMultiDateEditCalendar)).HotObject, CalendarHitInfo)
				If vdi.Bounds.Contains(hitInfo.Pt) OrElse hitInfo.InfoType = CalendarHitInfoType.Clear OrElse hitInfo.InfoType = CalendarHitInfoType.Ok OrElse hitInfo.InfoType = CalendarHitInfoType.Cancel Then
					vdi.UpdateExistingCellsState()
					vdi.OnAnimationChanging(prevInfo, currInfo)
					vdi.LeftArrowInfo.State = ObjectState.Normal
					vdi.RightArrowInfo.State = ObjectState.Normal
					If TypeOf hitInfo.HitObject Is DayNumberCellInfo Then
						TryCast(hitInfo.HitObject, DayNumberCellInfo).State = ObjectState.Normal
					End If
					Exit For
				End If
		   Next vdi
		End Sub

		Protected Overrides Function UpdateDateTime(ByVal dir As Integer) As DateTime
			If View = DateEditCalendarViewType.MonthInfo Then
				dir *= CInt(Fix((TryCast(Properties, RepositoryItemMultiDateEdit)).MultiEditorType))
				Dim month As Integer = DateTime.Month, year As Integer = DateTime.Year, day As Integer = DateTime.Day
				If View = DateEditCalendarViewType.MonthInfo Then
					month += dir
					If month >= 13 Then
						month = month Mod 12
						If year < 9999 Then
							year += 1
						End If
					ElseIf month <= 0 Then
						month = If(month = 0, 12, -month)
						If year > 0 Then
							year -= 1
						End If
					End If
				ElseIf View = DateEditCalendarViewType.YearInfo Then
					year += dir
				ElseIf View = DateEditCalendarViewType.YearsInfo Then
					If (DateTime.Year = 10 AndAlso dir < 0) OrElse (DateTime.Year = 1 AndAlso dir > 0) Then
						year += 9 * dir
					Else
						year += 10 * dir
					End If
				ElseIf View = DateEditCalendarViewType.YearsGroupInfo Then
					If (DateTime.Year = 10 AndAlso dir < 0) OrElse (DateTime.Year = 1 AndAlso dir > 0) Then
						year += 99 * dir
					Else
						year += 100 * dir
					End If
				End If
				If year <= 0 Then
					year = 1
				End If
				If year > 9999 Then
					year = 9999
				End If
				If TimeEdit Is Nothing Then
					Return New DateTime(year, month, CorrectDay(year, month, day), DateTime.Hour, DateTime.Minute, DateTime.Second)
				End If
				Return New DateTime(year, month, CorrectDay(year, month, day), TimeEdit.Time.Hour, TimeEdit.Time.Minute, TimeEdit.Time.Second)
			Else
				Return MyBase.UpdateDateTime(dir)
			End If
		End Function

		Protected Overrides Overloads Sub OnViewChanged(ByVal prevView As DateEditCalendarViewType, ByVal currView As DateEditCalendarViewType, ByVal shouldUpdateLayout As Boolean)
			MyBase.OnViewChanged(prevView, currView, shouldUpdateLayout)
			Dim CurrentPopupForm As VistaPopupMultiDateEditForm = TryCast(Parent, VistaPopupMultiDateEditForm)
			CurrentPopupForm.Size = CurrentPopupForm.CalcMultiEditPopupFormSize(Me.CalcBestSize(Nothing))
			LayoutChangedCore()
		End Sub
	End Class
End Namespace
