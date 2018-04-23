Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Utils.Win

Namespace DoubledMonthDateEdit
	Partial Public Class MainForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
			radioGroupCalendarMode.SelectedIndex = 0
			radioGroupMultiEditorType.SelectedIndex = 0
		End Sub


		Private Sub checkEditShowTime_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkEditShowTime.EditValueChanged
			If (TryCast(multiDateEditForTest, IPopupControl)).PopupWindow IsNot Nothing Then
				TryCast(multiDateEditForTest, IPopupControl).PopupWindow.Dispose()
			End If
			If CBool(checkEditShowTime.EditValue) = True Then
				multiDateEditForTest.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True
			Else
				multiDateEditForTest.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.False
			End If
		End Sub

		Private Sub radioGroupMultiEditorType_Properties_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioGroupMultiEditorType.Properties.EditValueChanged
			If (TryCast(multiDateEditForTest, IPopupControl)).PopupWindow IsNot Nothing Then
				TryCast(multiDateEditForTest, IPopupControl).PopupWindow.Dispose()
			End If
			multiDateEditForTest.Properties.MultiEditorType = CType(radioGroupMultiEditorType.EditValue, MultiDateEditor.MultiDateEditOptions)
		End Sub

		Private Sub radioGroupCalendarMode_Properties_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioGroupCalendarMode.Properties.EditValueChanged
			If radioGroupCalendarMode.EditValue.ToString() = "Vista" Then
				multiDateEditForTest.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True
			Else
				multiDateEditForTest.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False
			End If
		End Sub
	End Class
End Namespace
