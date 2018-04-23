Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports System.Drawing

Namespace MultiDateEditor
	' my multi date edit calendar class
	Public Class MultiDateEditCalendar
		Inherits DateEditCalendar
		'constructor
		Public Sub New(ByVal item As RepositoryItemDateEdit, ByVal editValue As Object)
			MyBase.New(item, editValue)
		End Sub

		' new property
		Protected Friend ReadOnly Property CalendarsRecr() As Rectangle
			Get
				Return MyBase.CalendarsRect
			End Get
		End Property

		Protected Overrides Sub ChangeEditDateCore(ByVal yearOffset As Integer, ByVal monthOffset As Integer, ByVal daysOffset As Integer)
			Dim iCalendarsCount As Integer = CInt(Fix((TryCast(Properties, RepositoryItemMultiDateEdit)).MultiEditorType))
			MyBase.ChangeEditDateCore(yearOffset, iCalendarsCount * monthOffset, daysOffset)
		End Sub

		Protected Overrides Function CreateInfoArgs() As DateEditInfoArgs
			Return New MultiDateEditInfoArgs(Me)
		End Function
	End Class
End Namespace
