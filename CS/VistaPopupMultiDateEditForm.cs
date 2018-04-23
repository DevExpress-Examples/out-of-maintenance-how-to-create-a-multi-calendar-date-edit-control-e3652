using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Controls;
using System.Drawing;

namespace MultiDateEditor
{
    // new popup form fo Vista mode
    public class VistaPopupMultiDateEditForm : VistaPopupDateEditForm
    {
        // constructor
        public VistaPopupMultiDateEditForm(MultiDateEdit OwnerEdit) : base(OwnerEdit) { }

        // methods
        protected override DateEditCalendar CreateCalendar()
        {
            VistaMultiDateEditCalendar newCalendar = new VistaMultiDateEditCalendar(OwnerEdit.Properties, OwnerEdit.EditValue);
            newCalendar.OkClick += new EventHandler(newCalendar_OkClick);
            return newCalendar;
        }

        void newCalendar_OkClick(object sender, EventArgs e)
        {
            if (OwnerEdit != null)
                OwnerEdit.ClosePopup();
        }

        protected internal Size CalcMultiEditPopupFormSize(Size currentSize)
        {
            Size returnedSize = base.CalcFormSize(currentSize);
            if (Calendar.View == DateEditCalendarViewType.MonthInfo)
            {
                returnedSize.Width *= (int)(OwnerEdit.Properties as RepositoryItemMultiDateEdit).MultiEditorType;
            }
            return returnedSize;            
        }

        public override Size CalcFormSize(Size contentSize)
        {
            return CalcMultiEditPopupFormSize(contentSize);            
        }
    }
}
