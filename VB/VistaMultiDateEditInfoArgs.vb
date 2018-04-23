Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.ViewInfo
Imports System.Drawing
Imports DevExpress.XtraEditors.Calendar
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Utils.Drawing.Animation
Imports System.Globalization

Namespace MultiDateEditor
	Public Class VistaMultiDateEditInfoArgs
		Inherits VistaDateEditInfoArgs
		' constructor
		Friend CurrentDateButtonRect As Rectangle = Rectangle.Empty
		Friend CurrentDateRect As Rectangle = Rectangle.Empty
		Friend CaptionButtonRect As Rectangle = Rectangle.Empty
		Friend CaptionRect As Rectangle = Rectangle.Empty
		Friend captionStringSize As Size = Size.Empty

		Friend Shadows ReadOnly Property CaptionString() As String
			Get
				If Calendar.View = DateEditCalendarViewType.MonthInfo Then
					Return CurrentMonth.ToString(CultureInfo.CurrentCulture.DateTimeFormat.YearMonthPattern)
				End If
				If Calendar.View = DateEditCalendarViewType.YearInfo Then
					Return CurrentMonth.Year.ToString()
				End If
				If Calendar.View = DateEditCalendarViewType.YearsInfo Then
					Return ((CurrentMonth.Year / 10) * 10).ToString() & "-" & (((CurrentMonth.Year / 10) * 10) + 9).ToString()
				End If
				If Calendar.View = DateEditCalendarViewType.YearsGroupInfo Then
					Return ((CurrentMonth.Year / 100) * 100).ToString() & "-" & (((CurrentMonth.Year / 100) * 100) + 99).ToString()
				End If
				Return String.Empty
			End Get
		End Property
		Public Sub New(ByVal OwnerCalendar As VistaMultiDateEditCalendar)
			MyBase.New(OwnerCalendar)
		End Sub

		Protected Sub SetHeaderElementsState(ByVal ShowLeftArrow As Boolean, ByVal showRightArrow As Boolean)
			If ShowLeftArrow = False Then
				LeftArrowInfo.State = ObjectState.Disabled
				LeftArrowInfo.Bounds = Rectangle.Empty
			End If
			If showRightArrow = False Then
				RightArrowInfo.State = ObjectState.Disabled
				RightArrowInfo.Bounds = Rectangle.Empty
			End If
		End Sub

		Protected Overrides Sub CalcHeaderInfo()
			MyBase.CalcHeaderInfo()
			Dim currentCalendar As VistaMultiDateEditCalendar = TryCast(Calendar, VistaMultiDateEditCalendar)
			Dim currentRepository As RepositoryItemMultiDateEdit = TryCast(currentCalendar.Properties, RepositoryItemMultiDateEdit)

			CurrentDateButtonRect = (TryCast(Calendar, VistaMultiDateEditCalendar)).CurrentDateButtonRect
			CurrentDateRect = (TryCast(Calendar, VistaMultiDateEditCalendar)).CurrentDateRect
			CaptionRect = New Rectangle(New Point(Content.Left + (Content.Width - captionStringSize.Width) / 2, CurrentDateRect.Bottom + DistanceFromCurrentDateToCaption), captionStringSize)
			CaptionButtonRect = GetButtonRect(CaptionRect)

			If currentRepository.MultiEditorType <> MultiDateEditOptions.Single AndAlso Calendar.View = DateEditCalendarViewType.MonthInfo Then
				If Bounds.X = currentCalendar.CalendarsRect.Left Then ' its a first calendar
					SetHeaderElementsState(True, False)
				ElseIf (Bounds.X + Bounds.Width) = currentCalendar.CalendarsRect.Right Then ' its a last calendar
					SetHeaderElementsState(False, True)
					CurrentDateButtonRect = Rectangle.Empty
					CurrentDateRect = Rectangle.Empty
				Else
					SetHeaderElementsState(False, False)
					CurrentDateButtonRect = Rectangle.Empty
					CurrentDateRect = Rectangle.Empty
				End If
			End If
		End Sub

		Protected Overrides Sub CalcClockInfo()
			MyBase.CalcClockInfo()
			Dim currentCalendar As VistaMultiDateEditCalendar = TryCast(Calendar, VistaMultiDateEditCalendar)
			Dim currentRepository As RepositoryItemMultiDateEdit = TryCast(currentCalendar.Properties, RepositoryItemMultiDateEdit)
			If currentCalendar.TimeEdit IsNot Nothing Then
				currentCalendar.TimeEdit.Visible = (currentRepository.MultiEditorType = MultiDateEditOptions.Single)
			End If
		End Sub

		Protected Overrides Sub CalcElementSize()
			MyBase.CalcElementSize()
			captionStringSize = CalcStringSize(HeaderAppearance, CaptionString)
		End Sub

		' methods
		Public Overrides Function GetHitInfo(ByVal e As System.Windows.Forms.MouseEventArgs) As CalendarHitInfo
			Dim hitInfo As New CalendarHitInfo(e.Location)
			Dim currentCalendar As VistaMultiDateEditCalendar = TryCast(Calendar, VistaMultiDateEditCalendar)
			If CurrentDateButtonRect.Contains(e.Location) Then
				hitInfo.InfoType = CalendarHitInfoType.CurrentDate
				hitInfo.Bounds = CurrentDateButtonRect
			ElseIf (TryCast(currentCalendar.Properties, RepositoryItemMultiDateEdit)).GetVistaEditTime() AndAlso OkButtonRect.Contains(e.Location) Then
				hitInfo.InfoType = CalendarHitInfoType.Ok
				hitInfo.Bounds = OkButtonRect
			ElseIf (TryCast(currentCalendar.Properties, RepositoryItemMultiDateEdit)).GetVistaEditTime() AndAlso CancelButtonRect.Contains(e.Location) Then
				hitInfo.InfoType = CalendarHitInfoType.Cancel
				hitInfo.Bounds = CancelButtonRect
			ElseIf CaptionButtonRect.Contains(e.Location) Then
				hitInfo.InfoType = CalendarHitInfoType.Caption
				hitInfo.Bounds = CaptionButtonRect
			ElseIf LeftArrowInfo.Bounds.Contains(e.Location) Then
				hitInfo.InfoType = CalendarHitInfoType.LeftArrow
				hitInfo.Bounds = LeftArrowInfo.Bounds
			ElseIf RightArrowInfo.Bounds.Contains(e.Location) Then
				hitInfo.InfoType = CalendarHitInfoType.RightArrow
				hitInfo.Bounds = RightArrowInfo.Bounds
			ElseIf ClearButtonRect.Contains(e.Location) Then ' && Calendar.Properties.ShowClear)
				hitInfo.InfoType = CalendarHitInfoType.Clear
				hitInfo.Bounds = ClearButtonRect
			Else
				For Each cell As DayNumberCellInfo In DayCells
					If cell.Bounds.Contains(e.Location) Then
						hitInfo.InfoType = CalendarHitInfoType.Item
						hitInfo.Bounds = cell.Bounds
						hitInfo.HitObject = cell
						hitInfo.HitDate = cell.Date
						Exit For
					End If
				Next cell
			End If
			Return hitInfo
		End Function

		Public Overrides Sub OnCurrentDateAnimationChanged(ByVal prevState As ObjectState, ByVal currState As ObjectState)
			Dim bmp As Bitmap = XtraAnimator.Current.CreateBitmap(Painter, Me, CurrentDateButtonRect, True)
			XtraAnimator.Current.AddBitmapAnimation(Calendar, currentDateId, XtraAnimator.Current.CalcAnimationLength(prevState, currState), CurrentDateButtonRect, bmp, New BitmapAnimationImageCallback(AddressOf RequestCurrentDateButtonDestinationImage))
		End Sub

		Public Overrides Sub OnCaptionAnimationChanged(ByVal prevState As ObjectState, ByVal currState As ObjectState)
			Dim bmp As Bitmap = XtraAnimator.Current.CreateBitmap(Painter, Me, CaptionButtonRect, True)
			XtraAnimator.Current.AddBitmapAnimation(Calendar, captionId, XtraAnimator.Current.CalcAnimationLength(prevState, currState), CaptionButtonRect, bmp, New BitmapAnimationImageCallback(AddressOf RequestCaptionButtonDestinationImage))
		End Sub

		Private Function RequestButtonDestinationImage(ByVal info As BaseAnimationInfo, ByVal rect As Rectangle) As Bitmap
			Dim currentCalendar As VistaMultiDateEditCalendar = TryCast(Calendar, VistaMultiDateEditCalendar)
			currentCalendar.LockAnimation += 1
			Dim bmp As Bitmap = XtraAnimator.Current.CreateBitmap(Painter, Me, rect, True)
			currentCalendar.LockAnimation -= 1
			Return bmp
		End Function

		Private Function RequestCaptionButtonDestinationImage(ByVal info As BaseAnimationInfo) As Bitmap
			Return RequestButtonDestinationImage(info, CaptionButtonRect)
		End Function

		Private Function RequestCurrentDateButtonDestinationImage(ByVal info As BaseAnimationInfo) As Bitmap
			Return RequestButtonDestinationImage(info, CurrentDateButtonRect)
		End Function
	End Class
End Namespace
