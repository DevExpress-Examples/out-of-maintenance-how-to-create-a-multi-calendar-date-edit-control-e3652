using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using System.ComponentModel;
using DevExpress.XtraEditors;

namespace MultiDateEditor
{
    public enum MultiDateEditOptions { 
        Single = 1, Double = 2, Triple = 3
    }

    // repository item for MultiDateEdit
    public class RepositoryItemMultiDateEdit : RepositoryItemDateEdit
    {
        // static constructor which calls static registration method
        static RepositoryItemMultiDateEdit() { RegisterMultiDateEdte(); }

        // static register method
        public static void RegisterMultiDateEdte()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(
                MultiDateEditorName,
                typeof(MultiDateEdit),
                typeof(RepositoryItemMultiDateEdit),
                typeof(DateEditViewInfo),
                new ButtonEditPainter(),
                true,
                null));
        }

        // internal editor name
        internal const string MultiDateEditorName = "MultiDateEdit";

        // public constructor
        public RepositoryItemMultiDateEdit() 
        { 
            MultiEditorType = MultiDateEditOptions.Triple;
            VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            VistaEditTime = DevExpress.Utils.DefaultBoolean.False;
        }

        // new property type of multi date editor
        protected MultiDateEditOptions multiCalendarsCount;
        [Description("Gets or sets count of calendars in multi date editor."), Category(CategoryName.Appearance), DefaultValue(MultiDateEditOptions.Single)]
        public MultiDateEditOptions MultiEditorType
        {
            get { return multiCalendarsCount; }
            set { multiCalendarsCount = value; }
        }


        // ovverride property
        public override string EditorTypeName {
            get { return MultiDateEditorName; }
        }

        protected internal new bool IsVistaDisplayMode() {
            return base.IsVistaDisplayMode();
        }

        protected internal new bool GetVistaEditTime()
        {
            return base.GetVistaEditTime();
        }

        public override DevExpress.Utils.DefaultBoolean VistaEditTime {
            get
            {
                if (multiCalendarsCount == MultiDateEditOptions.Single)
                    return base.VistaEditTime;
                else
                    return DevExpress.Utils.DefaultBoolean.False;
            }
            set
            {
                base.VistaEditTime = value;
            }
        }
    }
}
