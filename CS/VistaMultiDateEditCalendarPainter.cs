using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing.Animation;
using DevExpress.Utils;
using DevExpress.XtraEditors.Calendar;
using DevExpress.Utils.Drawing;
using DevExpress.Skins;
using DevExpress.XtraEditors.Controls;
using System.Drawing;

namespace MultiDateEditor
{
    public class VistaMultiDateEditCalendarPainter : VistaDateEditPainter
    {
        // constructor
        public VistaMultiDateEditCalendarPainter(VistaMultiDateEditCalendar OwnerEdit) : base(OwnerEdit) { }

        //methods
        public override void DrawObject(DevExpress.Utils.Drawing.ObjectInfoArgs e)
        {
            VistaDateEditInfoArgs vdi = e as VistaDateEditInfoArgs;
            VistaMultiDateEditCalendar currentCalendar = vdi.Calendar as VistaMultiDateEditCalendar;
            vdi.ClockTextRect = Rectangle.Empty;
            if (vdi != null)
            {
                vdi.Appearance.FillRectangle(e.Cache, e.Bounds);
                vdi.Appearance.FillRectangle(e.Cache, new Rectangle(e.Bounds.X, e.Bounds.Y + e.Bounds.Height, e.Bounds.Width, currentCalendar.Parent.Size.Height - e.Bounds.Height));
            }
            if (vdi == null || (currentCalendar.View == DateEditCalendarViewType.MonthInfo && !currentCalendar.SwitchState))
            {
                CalendarObjectInfoArgs ee = e as CalendarObjectInfoArgs;
                DrawContent(ee);
            }
            if (currentCalendar.SwitchState) DrawSwitchState(vdi);
            else if (currentCalendar.View == DateEditCalendarViewType.YearInfo) DrawYearInfo(vdi);
            else if (currentCalendar.View == DateEditCalendarViewType.YearsInfo) DrawYearsInfo(vdi);
            else if (currentCalendar.View == DateEditCalendarViewType.YearsGroupInfo) DrawYearsGroupInfo(vdi);
            if ((currentCalendar.Properties as RepositoryItemMultiDateEdit).GetVistaEditTime()) currentCalendar.ClockPainter.DrawObject(vdi);            
        }

        protected override void DrawCaption(VistaDateEditInfoArgs vdi)
        {
            VistaMultiDateEditCalendar currentCalendar = Calendar as VistaMultiDateEditCalendar;
            if (currentCalendar.LockAnimation == 0 && XtraAnimator.Current.DrawFrame(vdi.Cache, currentCalendar, vdi.captionId))
            {
                return;
            }
            AppearanceObject app = GetCaptionAppearance(vdi);

            if (IsHot(vdi, CalendarHitInfoType.Caption))
            {
                ObjectPainter.DrawObject(vdi.Cache, SkinElementPainter.Default, GetButtonElementInfo(vdi, (vdi as VistaMultiDateEditInfoArgs).CaptionButtonRect));
            }
            vdi.Graphics.DrawString((vdi as VistaMultiDateEditInfoArgs).CaptionString, app.Font, app.GetForeBrush(vdi.Cache), (vdi as VistaMultiDateEditInfoArgs).CaptionRect, app.TextOptions.GetStringFormat());
        }

        public override void DrawArrows(VistaDateEditInfoArgs vdi)
        {
            if (vdi.LeftArrowInfo.State != ObjectState.Disabled)
            {
                vdi.LeftArrowInfo.Cache = vdi.Cache;
                ButtonPainter.DrawObject(vdi.LeftArrowInfo);
            }
            if (vdi.RightArrowInfo.State != ObjectState.Disabled)
            {
                vdi.RightArrowInfo.Cache = vdi.Cache;
                ButtonPainter.DrawObject(vdi.RightArrowInfo);
            }            
        }

        protected override void DrawCurrentDate(VistaDateEditInfoArgs vdi)
        {
            if (!(vdi as VistaMultiDateEditInfoArgs).CurrentDateRect.IsEmpty)
            {
                VistaMultiDateEditCalendar currentCalendar = Calendar as VistaMultiDateEditCalendar;
                if (currentCalendar.LockAnimation == 0 && XtraAnimator.Current.DrawFrame(vdi.Cache, currentCalendar, vdi.currentDateId))
                {
                    return;
                }
                if (!currentCalendar.Properties.ShowToday) return;
                AppearanceObject app = GetCurrentDateAppearance(vdi);
                if (IsHot(vdi, CalendarHitInfoType.CurrentDate))
                {
                    ObjectPainter.DrawObject(vdi.Cache, SkinElementPainter.Default, GetButtonElementInfo(vdi, (vdi as VistaMultiDateEditInfoArgs).CurrentDateButtonRect));
                }
                vdi.Graphics.DrawString((vdi as VistaMultiDateEditInfoArgs).CurrentDateString, app.Font, app.GetForeBrush(vdi.Cache), (vdi as VistaMultiDateEditInfoArgs).CurrentDateRect, app.TextOptions.GetStringFormat());
            }
        }
    }

    public class VistaMultiDateEditClockPainter : VistaDateEditClockPainter
    { 
        // constructors
        public VistaMultiDateEditClockPainter(VistaMultiDateEditCalendar calendar) : base(calendar) { }
    
        // override methods
        protected override void DrawClockText(VistaDateEditInfoArgs e) { }    
    }
}
