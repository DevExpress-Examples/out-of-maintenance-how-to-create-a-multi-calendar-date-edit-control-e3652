Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.Utils.Drawing.Animation
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Calendar
Imports DevExpress.Utils.Drawing
Imports DevExpress.Skins
Imports DevExpress.XtraEditors.Controls
Imports System.Drawing

Namespace MultiDateEditor
	Public Class VistaMultiDateEditCalendarPainter
		Inherits VistaDateEditPainter
		' constructor
		Public Sub New(ByVal OwnerEdit As VistaMultiDateEditCalendar)
			MyBase.New(OwnerEdit)
		End Sub

		'methods
		Public Overrides Overloads Sub DrawObject(ByVal e As DevExpress.Utils.Drawing.ObjectInfoArgs)
			Dim vdi As VistaDateEditInfoArgs = TryCast(e, VistaDateEditInfoArgs)
			Dim currentCalendar As VistaMultiDateEditCalendar = TryCast(vdi.Calendar, VistaMultiDateEditCalendar)
			vdi.ClockTextRect = Rectangle.Empty
			If vdi IsNot Nothing Then
				vdi.Appearance.FillRectangle(e.Cache, e.Bounds)
				vdi.Appearance.FillRectangle(e.Cache, New Rectangle(e.Bounds.X, e.Bounds.Y + e.Bounds.Height, e.Bounds.Width, currentCalendar.Parent.Size.Height - e.Bounds.Height))
			End If
			If vdi Is Nothing OrElse (currentCalendar.View = DateEditCalendarViewType.MonthInfo AndAlso (Not currentCalendar.SwitchState)) Then
				Dim ee As CalendarObjectInfoArgs = TryCast(e, CalendarObjectInfoArgs)
				DrawContent(ee)
			End If
			If currentCalendar.SwitchState Then
				DrawSwitchState(vdi)
			ElseIf currentCalendar.View = DateEditCalendarViewType.YearInfo Then
				DrawYearInfo(vdi)
			ElseIf currentCalendar.View = DateEditCalendarViewType.YearsInfo Then
				DrawYearsInfo(vdi)
			ElseIf currentCalendar.View = DateEditCalendarViewType.YearsGroupInfo Then
				DrawYearsGroupInfo(vdi)
			End If
			If (TryCast(currentCalendar.Properties, RepositoryItemMultiDateEdit)).GetVistaEditTime() Then
				currentCalendar.ClockPainter.DrawObject(vdi)
			End If
		End Sub

		Protected Overrides Overloads Sub DrawCaption(ByVal vdi As VistaDateEditInfoArgs)
			Dim currentCalendar As VistaMultiDateEditCalendar = TryCast(Calendar, VistaMultiDateEditCalendar)
			If currentCalendar.LockAnimation = 0 AndAlso XtraAnimator.Current.DrawFrame(vdi.Cache, currentCalendar, vdi.captionId) Then
				Return
			End If
			Dim app As AppearanceObject = GetCaptionAppearance(vdi)

			If IsHot(vdi, CalendarHitInfoType.Caption) Then
				ObjectPainter.DrawObject(vdi.Cache, SkinElementPainter.Default, GetButtonElementInfo(vdi, (TryCast(vdi, VistaMultiDateEditInfoArgs)).CaptionButtonRect))
			End If
			vdi.Graphics.DrawString((TryCast(vdi, VistaMultiDateEditInfoArgs)).CaptionString, app.Font, app.GetForeBrush(vdi.Cache), (TryCast(vdi, VistaMultiDateEditInfoArgs)).CaptionRect, app.TextOptions.GetStringFormat())
		End Sub

		Public Overrides Sub DrawArrows(ByVal vdi As VistaDateEditInfoArgs)
			If vdi.LeftArrowInfo.State <> ObjectState.Disabled Then
				vdi.LeftArrowInfo.Cache = vdi.Cache
				ButtonPainter.DrawObject(vdi.LeftArrowInfo)
			End If
			If vdi.RightArrowInfo.State <> ObjectState.Disabled Then
				vdi.RightArrowInfo.Cache = vdi.Cache
				ButtonPainter.DrawObject(vdi.RightArrowInfo)
			End If
		End Sub

		Protected Overrides Sub DrawCurrentDate(ByVal vdi As VistaDateEditInfoArgs)
			If Not(TryCast(vdi, VistaMultiDateEditInfoArgs)).CurrentDateRect.IsEmpty Then
				Dim currentCalendar As VistaMultiDateEditCalendar = TryCast(Calendar, VistaMultiDateEditCalendar)
				If currentCalendar.LockAnimation = 0 AndAlso XtraAnimator.Current.DrawFrame(vdi.Cache, currentCalendar, vdi.currentDateId) Then
					Return
				End If
				If (Not currentCalendar.Properties.ShowToday) Then
					Return
				End If
				Dim app As AppearanceObject = GetCurrentDateAppearance(vdi)
				If IsHot(vdi, CalendarHitInfoType.CurrentDate) Then
					ObjectPainter.DrawObject(vdi.Cache, SkinElementPainter.Default, GetButtonElementInfo(vdi, (TryCast(vdi, VistaMultiDateEditInfoArgs)).CurrentDateButtonRect))
				End If
				vdi.Graphics.DrawString((TryCast(vdi, VistaMultiDateEditInfoArgs)).CurrentDateString, app.Font, app.GetForeBrush(vdi.Cache), (TryCast(vdi, VistaMultiDateEditInfoArgs)).CurrentDateRect, app.TextOptions.GetStringFormat())
			End If
		End Sub
	End Class

	Public Class VistaMultiDateEditClockPainter
		Inherits VistaDateEditClockPainter
		' constructors
		Public Sub New(ByVal calendar As VistaMultiDateEditCalendar)
			MyBase.New(calendar)
		End Sub

		' override methods
		Protected Overrides Sub DrawClockText(ByVal e As VistaDateEditInfoArgs)
		End Sub
	End Class
End Namespace
