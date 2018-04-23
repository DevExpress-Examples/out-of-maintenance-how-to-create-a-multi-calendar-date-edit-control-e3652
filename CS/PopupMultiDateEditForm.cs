using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Controls;
using System.Drawing;

namespace MultiDateEditor
{
    // my popup form for MultiDateEdit
    public class PopupMultiDateEditForm : PopupDateEditForm
    {
        // constructor
        public PopupMultiDateEditForm(MultiDateEdit OwnerEdit) : base(OwnerEdit) { }

        // override methods
        protected override DateEditCalendar CreateCalendar()
        {
            return new MultiDateEditCalendar(OwnerEdit.Properties, OwnerEdit.EditValue);
        }

        public override Size CalcFormSize(Size contentSize)
        {
            Size returnedSize = base.CalcFormSize(contentSize);
            returnedSize.Width *= (int)(OwnerEdit.Properties as RepositoryItemMultiDateEdit).MultiEditorType;
            return returnedSize;
        }
    }
}
