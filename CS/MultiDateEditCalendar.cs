using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using System.Drawing;

namespace MultiDateEditor
{
    // my multi date edit calendar class
    public class MultiDateEditCalendar : DateEditCalendar
    {
        //constructor
        public MultiDateEditCalendar(RepositoryItemDateEdit item, object editValue) : base(item, editValue) { }

        // new property
        protected internal Rectangle CalendarsRecr { get { return base.CalendarsRect; } }

        protected override void ChangeEditDateCore(int yearOffset, int monthOffset, int daysOffset)
        {
            int iCalendarsCount = (int)(Properties as RepositoryItemMultiDateEdit).MultiEditorType;
            base.ChangeEditDateCore(yearOffset, iCalendarsCount * monthOffset, daysOffset);
        }

        protected override DateEditInfoArgs CreateInfoArgs()
        {
            return new MultiDateEditInfoArgs(this);
        }
    }
}
