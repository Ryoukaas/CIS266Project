
alter table dbo.WorkEntries
add constraint [Error: Only one entry per Employee for an individual task per day. ] Unique (HoursWorked, EmployeeID, TaskID)
go 
alter table dbo.WorkEntries
drop constraint UnEntries