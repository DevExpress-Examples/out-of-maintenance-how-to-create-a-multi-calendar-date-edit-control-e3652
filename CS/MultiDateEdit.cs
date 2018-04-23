

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.ComponentModel;
using MultiDateEditor;
using DevExpress.XtraEditors.Popup;

namespace MultiDateEditor
{
    //editor MultiDateEdit
    public class MultiDateEdit : DateEdit
    {
        // static constructor
        static MultiDateEdit() { RepositoryItemMultiDateEdit.RegisterMultiDateEdte(); }

        // public constructor
        public MultiDateEdit() { }

        // ovverride property
        public override string EditorTypeName
        {
            get { return RepositoryItemMultiDateEdit.MultiDateEditorName; }
        }

        // property as corresponded repositoryitem
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]

        public new RepositoryItemMultiDateEdit Properties
        {
            get { return base.Properties as RepositoryItemMultiDateEdit; }
        }

        // custom methods
        protected PopupBaseForm MultiDateEditPopupForm;

        protected override PopupBaseForm CreatePopupForm()
        {
            if (Properties.IsVistaDisplayMode())
                MultiDateEditPopupForm = new VistaPopupMultiDateEditForm(this);
            else
                MultiDateEditPopupForm = new PopupMultiDateEditForm(this);
            return MultiDateEditPopupForm;
        }
    }
}
