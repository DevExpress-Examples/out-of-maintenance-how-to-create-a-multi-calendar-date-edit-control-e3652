using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.ViewInfo;
using System.Drawing;
using DevExpress.XtraEditors.Calendar;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Drawing.Animation;
using System.Globalization;

namespace MultiDateEditor
{
    public class VistaMultiDateEditInfoArgs : VistaDateEditInfoArgs
    {
        // constructor
        internal Rectangle CurrentDateButtonRect = Rectangle.Empty;
        internal Rectangle CurrentDateRect = Rectangle.Empty;
        internal Rectangle CaptionButtonRect = Rectangle.Empty;
        internal Rectangle CaptionRect = Rectangle.Empty;
        internal Size captionStringSize = Size.Empty;

        internal new string CaptionString
        {
            get
            {
                if (Calendar.View == DateEditCalendarViewType.MonthInfo)
                    return CurrentMonth.ToString(CultureInfo.CurrentCulture.DateTimeFormat.YearMonthPattern);
                if (Calendar.View == DateEditCalendarViewType.YearInfo)
                    return CurrentMonth.Year.ToString();
                if (Calendar.View == DateEditCalendarViewType.YearsInfo)
                    return ((CurrentMonth.Year / 10) * 10).ToString() + "-" + (((CurrentMonth.Year / 10) * 10) + 9).ToString();
                if (Calendar.View == DateEditCalendarViewType.YearsGroupInfo)
                    return ((CurrentMonth.Year / 100) * 100).ToString() + "-" + (((CurrentMonth.Year / 100) * 100) + 99).ToString();
                return string.Empty;
            }
        }
        public VistaMultiDateEditInfoArgs(VistaMultiDateEditCalendar OwnerCalendar) : base(OwnerCalendar) { }

        protected void SetHeaderElementsState(bool ShowLeftArrow, bool showRightArrow)
        {
            if (ShowLeftArrow == false)
            {
                LeftArrowInfo.State = ObjectState.Disabled;
                LeftArrowInfo.Bounds = Rectangle.Empty;
            }
            if (showRightArrow == false)
            {
                RightArrowInfo.State = ObjectState.Disabled;
                RightArrowInfo.Bounds = Rectangle.Empty;
            }
        }
        
        protected override void CalcHeaderInfo()
        {
            base.CalcHeaderInfo();
            VistaMultiDateEditCalendar currentCalendar = Calendar as VistaMultiDateEditCalendar;
            RepositoryItemMultiDateEdit currentRepository = currentCalendar.Properties as RepositoryItemMultiDateEdit;

            CurrentDateButtonRect = (Calendar as VistaMultiDateEditCalendar).CurrentDateButtonRect;
            CurrentDateRect = (Calendar as VistaMultiDateEditCalendar).CurrentDateRect;
            CaptionRect = new Rectangle(new Point(Content.Left + (Content.Width - captionStringSize.Width) / 2, CurrentDateRect.Bottom + DistanceFromCurrentDateToCaption), captionStringSize);
            CaptionButtonRect = GetButtonRect(CaptionRect);

            if (currentRepository.MultiEditorType != MultiDateEditOptions.Single && Calendar.View == DateEditCalendarViewType.MonthInfo) 
            {
                if (Bounds.X == currentCalendar.CalendarsRect.Left) // its a first calendar
                {
                    SetHeaderElementsState(true, false);
                }
                else if ((Bounds.X + Bounds.Width) == currentCalendar.CalendarsRect.Right) // its a last calendar
                {
                    SetHeaderElementsState(false, true);
                    CurrentDateButtonRect = Rectangle.Empty;
                    CurrentDateRect = Rectangle.Empty;
                }
                else
                {
                    SetHeaderElementsState(false, false);
                    CurrentDateButtonRect = Rectangle.Empty;
                    CurrentDateRect = Rectangle.Empty;
                }
            }            
        }

        protected override void CalcClockInfo()
        {
            base.CalcClockInfo();
            VistaMultiDateEditCalendar currentCalendar = Calendar as VistaMultiDateEditCalendar;
            RepositoryItemMultiDateEdit currentRepository = currentCalendar.Properties as RepositoryItemMultiDateEdit;
            if (currentCalendar.TimeEdit != null) {
                currentCalendar.TimeEdit.Visible = (currentRepository.MultiEditorType == MultiDateEditOptions.Single);
            }
        }

        protected override void CalcElementSize()
        {
            base.CalcElementSize();
            captionStringSize = CalcStringSize(HeaderAppearance, CaptionString);
        }

        // methods
        public override CalendarHitInfo GetHitInfo(System.Windows.Forms.MouseEventArgs e)
        {
            CalendarHitInfo hitInfo = new CalendarHitInfo(e.Location);
            VistaMultiDateEditCalendar currentCalendar = Calendar as VistaMultiDateEditCalendar;
            if (CurrentDateButtonRect.Contains(e.Location))
            {
                hitInfo.InfoType = CalendarHitInfoType.CurrentDate;
                hitInfo.Bounds = CurrentDateButtonRect;
            }
            else if ((currentCalendar.Properties as RepositoryItemMultiDateEdit).GetVistaEditTime() && OkButtonRect.Contains(e.Location))
            {
                hitInfo.InfoType = CalendarHitInfoType.Ok;
                hitInfo.Bounds = OkButtonRect;
            }
            else if ((currentCalendar.Properties as RepositoryItemMultiDateEdit).GetVistaEditTime() && CancelButtonRect.Contains(e.Location))
            {
                hitInfo.InfoType = CalendarHitInfoType.Cancel;
                hitInfo.Bounds = CancelButtonRect;
            }
            else if (CaptionButtonRect.Contains(e.Location))
            {
                hitInfo.InfoType = CalendarHitInfoType.Caption;
                hitInfo.Bounds = CaptionButtonRect;
            }
            else if (LeftArrowInfo.Bounds.Contains(e.Location))
            {
                hitInfo.InfoType = CalendarHitInfoType.LeftArrow;
                hitInfo.Bounds = LeftArrowInfo.Bounds;
            }
            else if (RightArrowInfo.Bounds.Contains(e.Location))
            {
                hitInfo.InfoType = CalendarHitInfoType.RightArrow;
                hitInfo.Bounds = RightArrowInfo.Bounds;
            }
            else if (ClearButtonRect.Contains(e.Location))// && Calendar.Properties.ShowClear)
            {
                hitInfo.InfoType = CalendarHitInfoType.Clear;
                hitInfo.Bounds = ClearButtonRect;
            }
            else
            {
                foreach (DayNumberCellInfo cell in DayCells)
                {
                    if (cell.Bounds.Contains(e.Location))
                    {
                        hitInfo.InfoType = CalendarHitInfoType.Item;
                        hitInfo.Bounds = cell.Bounds;
                        hitInfo.HitObject = cell;
                        hitInfo.HitDate = cell.Date;
                        break;
                    }
                }
            }
            return hitInfo;
        }

        public override void OnCurrentDateAnimationChanged(ObjectState prevState, ObjectState currState)
        {
            Bitmap bmp = XtraAnimator.Current.CreateBitmap(Painter, this, CurrentDateButtonRect, true);
            XtraAnimator.Current.AddBitmapAnimation(Calendar, currentDateId, XtraAnimator.Current.CalcAnimationLength(prevState, currState), CurrentDateButtonRect, bmp, new BitmapAnimationImageCallback(RequestCurrentDateButtonDestinationImage));
        }

        public override void OnCaptionAnimationChanged(ObjectState prevState, ObjectState currState)
        {
            Bitmap bmp = XtraAnimator.Current.CreateBitmap(Painter, this, CaptionButtonRect, true);
            XtraAnimator.Current.AddBitmapAnimation(Calendar, captionId, XtraAnimator.Current.CalcAnimationLength(prevState, currState), CaptionButtonRect, bmp, new BitmapAnimationImageCallback(RequestCaptionButtonDestinationImage));
        }

        Bitmap RequestButtonDestinationImage(BaseAnimationInfo info, Rectangle rect)
        {
            VistaMultiDateEditCalendar currentCalendar = Calendar as VistaMultiDateEditCalendar;
            currentCalendar.LockAnimation++;
            Bitmap bmp = XtraAnimator.Current.CreateBitmap(Painter, this, rect, true);
            currentCalendar.LockAnimation--;
            return bmp;
        }

        Bitmap RequestCaptionButtonDestinationImage(BaseAnimationInfo info)
        {
            return RequestButtonDestinationImage(info, CaptionButtonRect);
        }

        Bitmap RequestCurrentDateButtonDestinationImage(BaseAnimationInfo info)
        {
            return RequestButtonDestinationImage(info, CurrentDateButtonRect);
        }
    }
}
