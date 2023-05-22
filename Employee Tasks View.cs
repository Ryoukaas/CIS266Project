using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIS266Project
{

    public partial class Employee_Tasks_View : Form
    {//Requisite reference variable for the dataset and formLoaded bool for selected item Event Handler
        ProjectsDataSet projectsData;
        bool formLoaded = false;
        public Employee_Tasks_View(ProjectsDataSet projectsDataSet)
        {//Setting the List Views to details by default, connecting the reference to the parameter to be called in the Main Form.
            InitializeComponent();
            lvTasks.View = View.Details;
            lvEmployees.View = View.Details;
            projectsData = projectsDataSet;
            FillEmployeeColumns();
            FillEmployeeList();
            //Formloaded checker to avoid errors on load.
            formLoaded = true;
        }

        //Columns for the Employee List View, I didn't include the two together in one method because I want to be able to refresh the columns with each item selection.
        private void FillEmployeeColumns()
        {
            lvEmployees.Columns.Add("Employee Name", 120);
            lvEmployees.Columns.Add("Title", 120);
            lvEmployees.Columns.Add("Employee ID", 100);
        }
        private void FillTaskColumns()
        {
            lvTasks.Columns.Add("Project", 120);
            lvTasks.Columns.Add("Task Name", 120);
            lvTasks.Columns.Add("Date", 100);
            lvTasks.Columns.Add("Hours", 100);
        }

        private void FillEmployeeList()
        {//Rather straight forward fill in for Employee information. I did add a FullName to the Dataset for ease of use.
            foreach(ProjectsDataSet.EmployeesRow employee in projectsData.Employees)
            {
                ListViewItem itmEmployee = new ListViewItem(employee.FullName);
                itmEmployee.SubItems.Add(employee.Title);
                itmEmployee.SubItems.Add(employee.EmployeeID.ToString());
                itmEmployee.Tag = employee.EmployeeID;

                lvEmployees.Items.Add(itmEmployee);

            }
        }

        private void FillTaskList(int employeeID)
        {//This looks like my other one because they are essentially the same code with a different pathway to get there
            //Edit: this one was interesting because it forced me to remember that just because I call the data in a different order doesn't mean I can associate that data to the ListView in the order I need.
            //I had to start in WorkEntries because that was the only place I had a real EmployeeID consistently available for filtering the data put into the ListView 
            decimal hoursWorked = 0m;
            
            foreach(ProjectsDataSet.WorkEntriesRow workEntries in projectsData.WorkEntries)
            {
                if(workEntries.EmployeeID == employeeID)
                {
                    
                    foreach (ProjectsDataSet.TasksRow tasks in projectsData.Tasks)
                    {
                        if(tasks.TaskID==workEntries.TaskID)
                        {
                            DataRow ProjectName = tasks.GetParentRow("FK_Tasks_Projects");
                            ListViewItem itmWorkedEntries = new ListViewItem(ProjectName[1].ToString());
                            itmWorkedEntries.SubItems.Add(tasks.TaskName);
                            itmWorkedEntries.SubItems.Add(workEntries.WorkDate.ToShortDateString());
                            itmWorkedEntries.SubItems.Add(workEntries.HoursWorked.ToString());
                            hoursWorked += workEntries.HoursWorked;
                            lvTasks.Items.Add(itmWorkedEntries);
                        }

                    }

                }
                
            }
            //My hours tracker put to it's proper label.
            lblHours.Text ="Total number of Hours Worked is " + hoursWorked.ToString() + " hours.";
            
            
            

        }

        private void lvEmployees_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if(formLoaded==true)
            {
                lvTasks.Columns.Clear();
                lvTasks.Items.Clear();
                FillTaskColumns();
                //Employee tag from the ListView to wire the FillTaskList correctly
                int employeeid = (int)e.Item.Tag;
                FillTaskList(employeeid);
            }
        }
    }
}
