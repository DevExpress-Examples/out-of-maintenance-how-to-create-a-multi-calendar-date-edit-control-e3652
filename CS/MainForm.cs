using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Win;

namespace DoubledMonthDateEdit
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            radioGroupCalendarMode.SelectedIndex = 0;
            radioGroupMultiEditorType.SelectedIndex = 0;
        }


        private void checkEditShowTime_EditValueChanged(object sender, EventArgs e)
        {
            if ((multiDateEditForTest as IPopupControl).PopupWindow != null)
            {
                (multiDateEditForTest as IPopupControl).PopupWindow.Dispose();
            }
            if ((bool)checkEditShowTime.EditValue == true)
            {
                multiDateEditForTest.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
            }
            else
            {
                multiDateEditForTest.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.False;            
            }
        }

        private void radioGroupMultiEditorType_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if ((multiDateEditForTest as IPopupControl).PopupWindow != null)
            {
                (multiDateEditForTest as IPopupControl).PopupWindow.Dispose();
            }
            multiDateEditForTest.Properties.MultiEditorType = (MultiDateEditor.MultiDateEditOptions)radioGroupMultiEditorType.EditValue;
        }

        private void radioGroupCalendarMode_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if (radioGroupCalendarMode.EditValue.ToString() == "Vista")
            {
                multiDateEditForTest.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            }
            else
            {
                multiDateEditForTest.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            }
        }
    }
}
