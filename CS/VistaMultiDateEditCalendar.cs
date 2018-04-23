using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using System.Drawing;
using DevExpress.XtraEditors.Calendar;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;

namespace MultiDateEditor
{
    public class VistaMultiDateEditCalendar : VistaDateEditCalendar
    {
        public VistaMultiDateEditCalendar(RepositoryItemDateEdit item, object editValue) : base(item, editValue) { }

        static internal DateTime GetFirstMonthDate(DateTime date) { return new DateTime(date.Year, date.Month, 1, date.Hour, date.Minute, date.Second, date.Millisecond); }

        // new property
        protected new internal Rectangle CalendarsRect { get { return base.CalendarsRect; } }

        // override metods
        protected override DateEditPainter CreatePainter()
        {
            return new VistaMultiDateEditCalendarPainter(this);
        }

        protected override DateEditInfoArgs CreateInfoArgs()
        {
            return new VistaMultiDateEditInfoArgs(this);
        }

        protected internal new bool SwitchState
        {
            get { return base.SwitchState; }
            set { base.SwitchState = value; }
        }

        protected internal new VistaDateEditClockPainter ClockPainter
        {
            get { return new VistaMultiDateEditClockPainter(this); }
        }

        protected internal new TimeEdit TimeEdit
        {
            get { return base.TimeEdit; }
        }

        protected internal new int LockAnimation
        {
            get { return base.LockAnimation; }
            set { base.LockAnimation = value; }
        }

        protected internal new Rectangle CaptionRect { get { return base.CaptionRect; } }
        protected internal new Rectangle CaptionButtonRect { get { return base.CaptionButtonRect; } }
        protected internal new Rectangle CurrentDateButtonRect { get { return base.CurrentDateButtonRect; } }
        protected internal new Rectangle CurrentDateRect { get { return base.CurrentDateRect; } }

        internal new object HotObject
        {
            get { return base.HotObject; }
        }

        protected override void OnHotObjectChanged(CalendarHitInfo prevInfo, CalendarHitInfo currInfo)
        {
            foreach (VistaMultiDateEditInfoArgs vdi in Calendars)
            {
                CalendarHitInfo hitInfo = (vdi.Calendar as VistaMultiDateEditCalendar).HotObject as CalendarHitInfo;
                if (vdi.Bounds.Contains(hitInfo.Pt) || hitInfo.InfoType == CalendarHitInfoType.Clear || hitInfo.InfoType == CalendarHitInfoType.Ok || hitInfo.InfoType == CalendarHitInfoType.Cancel)// if (vdi.Bounds.Contains(hitInfo.Pt))//if(vdi.Bounds.Contains(currInfo.Pt))
                {
                    vdi.UpdateExistingCellsState();
                    vdi.OnAnimationChanged(prevInfo, currInfo);
                    if (currInfo != null)
                    {
                        if (currInfo.InfoType == CalendarHitInfoType.LeftArrow && vdi.LeftArrowInfo.State != ObjectState.Pressed)
                            vdi.LeftArrowInfo.State = ObjectState.Hot;
                        if (currInfo.InfoType == CalendarHitInfoType.RightArrow && vdi.RightArrowInfo.State != ObjectState.Pressed)
                            vdi.RightArrowInfo.State = ObjectState.Hot;
                    }
                    if (hitInfo.HitObject is DayNumberCellInfo)
                        (hitInfo.HitObject as DayNumberCellInfo).State = ObjectState.Hot;
                    break;
                }
            }
        }

        protected override void OnHotObjectChanging(CalendarHitInfo prevInfo, CalendarHitInfo currInfo)
        {
           foreach (VistaMultiDateEditInfoArgs vdi in Calendars)
            {
                CalendarHitInfo hitInfo = (vdi.Calendar as VistaMultiDateEditCalendar).HotObject as CalendarHitInfo;
                if (vdi.Bounds.Contains(hitInfo.Pt) || hitInfo.InfoType == CalendarHitInfoType.Clear || hitInfo.InfoType == CalendarHitInfoType.Ok || hitInfo.InfoType == CalendarHitInfoType.Cancel)
                {
                    vdi.UpdateExistingCellsState();
                    vdi.OnAnimationChanging(prevInfo, currInfo);
                    vdi.LeftArrowInfo.State = ObjectState.Normal;
                    vdi.RightArrowInfo.State = ObjectState.Normal;
                    if (hitInfo.HitObject is DayNumberCellInfo)
                        (hitInfo.HitObject as DayNumberCellInfo).State = ObjectState.Normal;
                    break;
                }
            }
        }

        protected override DateTime UpdateDateTime(int dir)
        {
            if (View == DateEditCalendarViewType.MonthInfo)
            {
                dir *= (int)(Properties as RepositoryItemMultiDateEdit).MultiEditorType;
                int month = DateTime.Month, year = DateTime.Year, day = DateTime.Day;
                if (View == DateEditCalendarViewType.MonthInfo)
                {
                    month += dir;
                    if (month >= 13)
                    {
                        month = month % 12;
                        if (year < 9999) year++;
                    }
                    else if (month <= 0)
                    {
                        month = month == 0 ? 12 : -month;
                        if (year > 0) year--;
                    }
                }
                else if (View == DateEditCalendarViewType.YearInfo)
                {
                    year += dir;
                }
                else if (View == DateEditCalendarViewType.YearsInfo)
                {
                    if ((DateTime.Year == 10 && dir < 0) || (DateTime.Year == 1 && dir > 0)) year += 9 * dir;
                    else year += 10 * dir;
                }
                else if (View == DateEditCalendarViewType.YearsGroupInfo)
                {
                    if ((DateTime.Year == 10 && dir < 0) || (DateTime.Year == 1 && dir > 0)) year += 99 * dir;
                    else year += 100 * dir;
                }
                if (year <= 0) year = 1;
                if (year > 9999) year = 9999;
                if (TimeEdit == null) return new DateTime(year, month, CorrectDay(year, month, day), DateTime.Hour, DateTime.Minute, DateTime.Second);
                return new DateTime(year, month, CorrectDay(year, month, day), TimeEdit.Time.Hour, TimeEdit.Time.Minute, TimeEdit.Time.Second);
            }
            else
                return base.UpdateDateTime(dir);
        }

        protected override void OnViewChanged(DateEditCalendarViewType prevView, DateEditCalendarViewType currView, bool shouldUpdateLayout)
        {
            base.OnViewChanged(prevView, currView, shouldUpdateLayout);
            VistaPopupMultiDateEditForm CurrentPopupForm = Parent as VistaPopupMultiDateEditForm;
            CurrentPopupForm.Size = CurrentPopupForm.CalcMultiEditPopupFormSize(this.CalcBestSize(null));
            LayoutChangedCore();
        }
    }
}
