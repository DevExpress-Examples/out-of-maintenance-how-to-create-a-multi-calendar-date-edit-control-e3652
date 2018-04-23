# How to create a multi calendar date edit control


<p>This example demonstrates how to create a <strong>multi calendar</strong> date edit control that allows one to display many calendars in the same popup window.</p><p>In this example we have created a <strong>RepositoryItemDateEdit </strong>descendant with an additional <strong>MultiEditorType </strong>property that defines the number of displayed calendars.</p><p>This property can be set to a value from the following collections:<u> Single, Double, Triple</u></p><br />
<p>All calendars in the popup form display months in the <strong>ascending </strong>order from the current date month.</p><br />
<p>For example, if the current date value is 1 january 2011, then other calendars display information about February 2011 and March 2011 in Triple mode, or only February 2011 in Double mode.</p><p>The order of these months is maintained when scrolling the months in the popup window.</p>


<h3>Description</h3>

Starting with 15.2, DateEdit supports the capability to display some&nbsp;months together.&nbsp;To&nbsp;enable this feature, you can use the RepositoryItemDateEdit.ColumnCount or RepositoryItemDateEdit.RowCount&nbsp;properties.

<br/>


