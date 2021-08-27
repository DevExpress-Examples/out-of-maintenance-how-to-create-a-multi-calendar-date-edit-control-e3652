<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128619810/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3652)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainForm.cs](./CS/MainForm.cs) (VB: [MainForm.vb](./VB/MainForm.vb))
* [MultiDateEdit.cs](./CS/MultiDateEdit.cs) (VB: [MultiDateEdit.vb](./VB/MultiDateEdit.vb))
* [MultiDateEditCalendar.cs](./CS/MultiDateEditCalendar.cs) (VB: [VistaMultiDateEditCalendar.vb](./VB/VistaMultiDateEditCalendar.vb))
* [MultiDateEditInfoArgs.cs](./CS/MultiDateEditInfoArgs.cs) (VB: [VistaMultiDateEditInfoArgs.vb](./VB/VistaMultiDateEditInfoArgs.vb))
* [PopupMultiDateEditForm.cs](./CS/PopupMultiDateEditForm.cs) (VB: [PopupMultiDateEditForm.vb](./VB/PopupMultiDateEditForm.vb))
* [RepositoryItemMultiDateEdit.cs](./CS/RepositoryItemMultiDateEdit.cs) (VB: [RepositoryItemMultiDateEdit.vb](./VB/RepositoryItemMultiDateEdit.vb))
* [VistaMultiDateEditCalendar.cs](./CS/VistaMultiDateEditCalendar.cs) (VB: [VistaMultiDateEditCalendar.vb](./VB/VistaMultiDateEditCalendar.vb))
* [VistaMultiDateEditCalendarPainter.cs](./CS/VistaMultiDateEditCalendarPainter.cs) (VB: [VistaMultiDateEditCalendarPainter.vb](./VB/VistaMultiDateEditCalendarPainter.vb))
* [VistaMultiDateEditInfoArgs.cs](./CS/VistaMultiDateEditInfoArgs.cs) (VB: [VistaMultiDateEditInfoArgs.vb](./VB/VistaMultiDateEditInfoArgs.vb))
* [VistaPopupMultiDateEditForm.cs](./CS/VistaPopupMultiDateEditForm.cs) (VB: [VistaPopupMultiDateEditForm.vb](./VB/VistaPopupMultiDateEditForm.vb))
<!-- default file list end -->
# How to create a multi calendar date edit control


<p>This example demonstrates how to create a <strong>multi calendar</strong> date edit control that allows one to display many calendars in the same popup window.</p><p>In this example we have created a <strong>RepositoryItemDateEdit </strong>descendant with an additional <strong>MultiEditorType </strong>property that defines the number of displayed calendars.</p><p>This property can be set to a value from the following collections:<u> Single, Double, Triple</u></p><br />
<p>All calendars in the popup form display months in the <strong>ascending </strong>order from the current date month.</p><br />
<p>For example, if the current date value is 1 january 2011, then other calendars display information about February 2011 and March 2011 in Triple mode, or only February 2011 in Double mode.</p><p>The order of these months is maintained when scrolling the months in the popup window.</p>

<br/>


