using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.ViewInfo;
using System.Drawing;

namespace MultiDateEditor
{
    class MultiDateEditInfoArgs : DateEditInfoArgs
    {
        // constructor
        public MultiDateEditInfoArgs(MultiDateEditCalendar OwnerCalendar) : base(OwnerCalendar) { }

        protected void SetMonthYearButtonState(bool DMState, bool IMState, bool DYState, bool IYState)
        {
            ShowDecMonth = DMState;
            ShowIncMonth = IMState;
            ShowDecYear = DYState;
            ShowIncYear = IYState;
            DecMonthInfo.State = DMState == true ? DevExpress.Utils.Drawing.ObjectState.Normal : DevExpress.Utils.Drawing.ObjectState.Disabled;
            IncMonthInfo.State = IMState == true ? DevExpress.Utils.Drawing.ObjectState.Normal : DevExpress.Utils.Drawing.ObjectState.Disabled;
            DecYearInfo.State = DYState == true ? DevExpress.Utils.Drawing.ObjectState.Normal : DevExpress.Utils.Drawing.ObjectState.Disabled;
            IncYearInfo.State = IYState == true ? DevExpress.Utils.Drawing.ObjectState.Normal : DevExpress.Utils.Drawing.ObjectState.Disabled;
        }

        protected override void CalcHeaderInfo()
        {
            base.CalcHeaderInfo();
            MultiDateEditCalendar currentCalendar = Calendar as MultiDateEditCalendar;
            RepositoryItemMultiDateEdit currentRepository = currentCalendar.Properties as RepositoryItemMultiDateEdit;
            if (currentRepository.MultiEditorType != MultiDateEditOptions.Single)
            {
                if (Bounds.X == currentCalendar.CalendarsRecr.Left) // its a first calendar
                {
                    SetMonthYearButtonState(true, false, false, false);
                    EditYear = Rectangle.Empty;
                    EditMonth.X = Bounds.Width - EditMonth.Width - Bounds.X;
                    DecMonthInfo.Bounds = new Rectangle(EditMonth.X - DecMonthInfo.Bounds.Width - Bounds.X, DecMonthInfo.Bounds.Y, DecMonthInfo.Bounds.Width, DecMonthInfo.Bounds.Height);
                }
                else if ((Bounds.X + Bounds.Width) == currentCalendar.CalendarsRecr.Right) // its a last calendar
                {
                    SetMonthYearButtonState(false, true, true, true);
                    DecYearInfo.Bounds = new Rectangle(EditYear.X - IncYearInfo.Bounds.Width, IncYearInfo.Bounds.Y, IncYearInfo.Bounds.Width, IncYearInfo.Bounds.Height);

                }
                else
                {
                    SetMonthYearButtonState(false, false, false, false);
                    EditMonth.X = Bounds.X + (Bounds.Width - EditMonth.Width) / 2;
                    EditYear = Rectangle.Empty;
                }
            }
        }
    }
}
