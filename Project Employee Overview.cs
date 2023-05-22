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
    public partial class Project_Employees : Form
    {
        //bool loadedform and reference variable established for the DataSet
        bool loadedform = false;
        ProjectsDataSet projectsData;
        public Project_Employees(ProjectsDataSet projectsDataSet)
        {//Wired the parameter to the reference variable, Set the ListView View style to Details, loaded the columns into lvProjects, and set loadedform bool to true.
            InitializeComponent();
            projectsData = projectsDataSet;
            lvProjects.View = View.Details;
            lvTasks.View = View.Details;
            ProjectListViewColumns();
            FillProjectList();
            loadedform = true;
        }

        private void ProjectListViewColumns()
        {//Filled the list view columns in seperate methods for flexibility with the Task List View Columns.

            lvProjects.Columns.Add("Project Name", 100);
            lvProjects.Columns.Add("Status", 80);
            lvProjects.Columns.Add("Project Start Date", 100);
            lvProjects.Columns.Add("Project End Date", 100);
        }
        private void TaskListViewColumns()
        {
            lvTasks.Columns.Add("Employee Name", 100);
            lvTasks.Columns.Add("Task Name", 100);
            lvTasks.Columns.Add("Date", 100);
            lvTasks.Columns.Add("Hours Worked", 100);

        }

        private void FillProjectList()
        {//Clears lbProject just in case.
            lvProjects.Items.Clear();
            //Starts in Projects, adds the items to the ListViewItem and makes the listview item's tag the projectID for use with the Task listview.
            foreach (ProjectsDataSet.ProjectsRow project in projectsData.Projects)
            {
                ListViewItem projectitm = new ListViewItem(project.ProjectName);
                //I made a switch statement for this because I felt it was unacceptable to leave it in the raw number format. I'm rather happy that it works.
                //I also figured since I was just going to add the 4 StatusIDs myself anyways that it would be easier to just pull the exact ID's for the program.
                switch (project.StatusID)
                {
                    case 1:
                        projectitm.SubItems.Add("Pending");
                        break;
                    case 2:
                        projectitm.SubItems.Add("Underway");
                        break;
                    case 3:
                        projectitm.SubItems.Add("Delayed");
                        break;
                    case 4:
                        projectitm.SubItems.Add("Completed");
                        break;
                }
                projectitm.SubItems.Add(project.ProjectStart.ToShortDateString());
                projectitm.SubItems.Add(project.ProjectEnd.ToShortDateString());
                projectitm.Tag = project.ProjectID;
                lvProjects.Items.Add(projectitm);
            }
        }

        private void FillTaskList(int projectID)
        {
            //I chose two list views for this because I like the columns, they allow me to convey data better
            //Method scope hoursWorked so that with each selection the decimal resets to zero.
            decimal hoursWorked = 0m;
            foreach (ProjectsDataSet.TasksRow TasksRow in projectsData.Tasks)
            {
                if (TasksRow.ProjectID == projectID)
                {
                    int taskID = TasksRow.TaskID;

                    foreach (ProjectsDataSet.WorkEntriesRow workEntry in projectsData.WorkEntries)
                    {
                        if (workEntry.TaskID == taskID)
                        {//Data row using the parent relationship to find Employee's Name
                            DataRow employee = workEntry.GetParentRow("FK_WorkEntries_Employees");
                            //Used a 5th Column called FullName to find the full employee name.
                            ListViewItem workEntryitm = new ListViewItem(employee[4].ToString());
                            workEntryitm.SubItems.Add(TasksRow.TaskName);
                            workEntryitm.SubItems.Add(workEntry.WorkDate.ToShortDateString());
                            workEntryitm.SubItems.Add(workEntry.HoursWorked.ToString());
                            hoursWorked += workEntry.HoursWorked;
                            lvTasks.Items.Add(workEntryitm);
                        }
                    }
                }
            }
            

            lblProjectHours.Text = "Total Hours Worked for this project is " + hoursWorked + " hours";
        }

        private void lvProjects_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {//The event handler that fills the task listview when the project listview is clicked.
            if (loadedform == true)
            {//Clear list view items and columns each time for multiple Item selection changes.
                lvTasks.Items.Clear();
                lvTasks.Columns.Clear();
                TaskListViewColumns();
                //wired the previously tagged projectID from the ListViewItem to an int which is then used to Fill the Task ListView
                int projectID = (int)e.Item.Tag;

                FillTaskList(projectID);
            }
        }
    }
}
