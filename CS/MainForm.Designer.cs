using MultiDateEditor;
namespace DoubledMonthDateEdit
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioGroupCalendarMode = new DevExpress.XtraEditors.RadioGroup();
            this.checkEditShowTime = new DevExpress.XtraEditors.CheckEdit();
            this.radioGroupMultiEditorType = new DevExpress.XtraEditors.RadioGroup();
            this.multiDateEditForTest = new MultiDateEditor.MultiDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupCalendarMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditShowTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupMultiEditorType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiDateEditForTest.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiDateEditForTest.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radioGroupCalendarMode
            // 
            this.radioGroupCalendarMode.Location = new System.Drawing.Point(15, 113);
            this.radioGroupCalendarMode.Name = "radioGroupCalendarMode";
            this.radioGroupCalendarMode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Vista", "Vista mode"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("General", "General mode")});
            this.radioGroupCalendarMode.Properties.EditValueChanged += new System.EventHandler(this.radioGroupCalendarMode_Properties_EditValueChanged);
            this.radioGroupCalendarMode.Size = new System.Drawing.Size(136, 48);
            this.radioGroupCalendarMode.TabIndex = 2;
            // 
            // checkEditShowTime
            // 
            this.checkEditShowTime.Location = new System.Drawing.Point(13, 88);
            this.checkEditShowTime.Name = "checkEditShowTime";
            this.checkEditShowTime.Properties.Caption = "Show time in Vista Mode";
            this.checkEditShowTime.Size = new System.Drawing.Size(138, 19);
            this.checkEditShowTime.TabIndex = 3;
            this.checkEditShowTime.EditValueChanged += new System.EventHandler(this.checkEditShowTime_EditValueChanged);
            // 
            // radioGroupMultiEditorType
            // 
            this.radioGroupMultiEditorType.Location = new System.Drawing.Point(157, 113);
            this.radioGroupMultiEditorType.Name = "radioGroupMultiEditorType";
            this.radioGroupMultiEditorType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Single"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Double"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Triple")});
            this.radioGroupMultiEditorType.Properties.EditValueChanged += new System.EventHandler(this.radioGroupMultiEditorType_Properties_EditValueChanged);
            this.radioGroupMultiEditorType.Size = new System.Drawing.Size(166, 48);
            this.radioGroupMultiEditorType.TabIndex = 4;
            // 
            // multiDateEditForTest
            // 
            this.multiDateEditForTest.EditValue = null;
            this.multiDateEditForTest.Location = new System.Drawing.Point(12, 5);
            this.multiDateEditForTest.Name = "multiDateEditForTest";
            this.multiDateEditForTest.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.multiDateEditForTest.Properties.MultiEditorType = MultiDateEditor.MultiDateEditOptions.Triple;
            this.multiDateEditForTest.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.multiDateEditForTest.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.False;
            this.multiDateEditForTest.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.multiDateEditForTest.Size = new System.Drawing.Size(311, 20);
            this.multiDateEditForTest.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 170);
            this.Controls.Add(this.multiDateEditForTest);
            this.Controls.Add(this.radioGroupMultiEditorType);
            this.Controls.Add(this.checkEditShowTime);
            this.Controls.Add(this.radioGroupCalendarMode);
            this.Name = "MainForm";
            this.Text = "Application main form";
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupCalendarMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditShowTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupMultiEditorType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiDateEditForTest.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiDateEditForTest.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup radioGroupCalendarMode;
        private DevExpress.XtraEditors.CheckEdit checkEditShowTime;
        private DevExpress.XtraEditors.RadioGroup radioGroupMultiEditorType;
        private MultiDateEdit multiDateEditForTest;
    }
}

