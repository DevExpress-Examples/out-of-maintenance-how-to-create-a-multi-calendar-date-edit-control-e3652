<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128619810/15.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3652)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/DXApplication1/Form1.cs) (VB: [Form1.vb](./VB/DXApplication1/Form1.vb))
<!-- default file list end -->
# How to create a multi calendar date edit control


<p>This example demonstrates how to create a <strong>multi calendar</strong> date edit control that allows one to display many calendars in the same popup window.</p><p>In this example we have created a <strong>RepositoryItemDateEdit </strong>descendant with an additional <strong>MultiEditorType </strong>property that defines the number of displayed calendars.</p><p>This property can be set to a value from the following collections:<u> Single, Double, Triple</u></p><br />
<p>All calendars in the popup form display months in the <strong>ascending </strong>order from the current date month.</p><br />
<p>For example, if the current date value is 1 january 2011, then other calendars display information about February 2011 and March 2011 in Triple mode, or only February 2011 in Double mode.</p><p>The order of these months is maintained when scrolling the months in the popup window.</p>


<h3>Description</h3>

Starting with 15.2, DateEdit supports the capability to display some&nbsp;months together.&nbsp;To&nbsp;enable this feature, you can use the RepositoryItemDateEdit.ColumnCount or RepositoryItemDateEdit.RowCount&nbsp;properties.

<br/>


