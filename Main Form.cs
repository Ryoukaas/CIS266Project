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

    public partial class MainForm : Form
    {//Katelyn Griffin 6/15/2022 Final Project for CIS 262

        //Calling the DataSet to the main form.
        ProjectsDataSet projectData;


  

       
        //Get DataSet Data Method
        private void GetData()
        {
            ProjectsDataSetTableAdapters.EmployeesTableAdapter EmployeeTA = new ProjectsDataSetTableAdapters.EmployeesTableAdapter();
            ProjectsDataSetTableAdapters.ProjectsTableAdapter ProjectTA = new ProjectsDataSetTableAdapters.ProjectsTableAdapter();
            ProjectsDataSetTableAdapters.StatusTableAdapter StatusTA = new ProjectsDataSetTableAdapters.StatusTableAdapter();
            ProjectsDataSetTableAdapters.TasksTableAdapter TasksTA = new ProjectsDataSetTableAdapters.TasksTableAdapter();
            ProjectsDataSetTableAdapters.WorkEntriesTableAdapter WorkEntriesTA = new ProjectsDataSetTableAdapters.WorkEntriesTableAdapter();

            try
            {//Fill the data into the projectData object.
                EmployeeTA.Fill(projectData.Employees);
                ProjectTA.Fill(projectData.Projects);
                StatusTA.Fill(projectData.Status);
                TasksTA.Fill(projectData.Tasks);
                WorkEntriesTA.Fill(projectData.WorkEntries);
            }
            catch(Exception ex)
            {//If exception occurs show in a message box
                MessageBox.Show(ex.Message, "Error loading data!");
            }
        }
        //Save the Data to the Database method, using the table manager to handle the data.
        private void SaveData()
        {

            ProjectsDataSetTableAdapters.EmployeesTableAdapter EmployeeTA = new ProjectsDataSetTableAdapters.EmployeesTableAdapter();
            ProjectsDataSetTableAdapters.ProjectsTableAdapter ProjectTA = new ProjectsDataSetTableAdapters.ProjectsTableAdapter();
            ProjectsDataSetTableAdapters.StatusTableAdapter StatusTA = new ProjectsDataSetTableAdapters.StatusTableAdapter();
            ProjectsDataSetTableAdapters.TasksTableAdapter TasksTA = new ProjectsDataSetTableAdapters.TasksTableAdapter();
            ProjectsDataSetTableAdapters.WorkEntriesTableAdapter WorkEntriesTA = new ProjectsDataSetTableAdapters.WorkEntriesTableAdapter();
            ProjectsDataSetTableAdapters.TableAdapterManager DataManager = new ProjectsDataSetTableAdapters.TableAdapterManager();

            DataManager.EmployeesTableAdapter = EmployeeTA;
            DataManager.ProjectsTableAdapter = ProjectTA;
            DataManager.StatusTableAdapter = StatusTA;
            DataManager.TasksTableAdapter = TasksTA;
            DataManager.WorkEntriesTableAdapter = WorkEntriesTA;
            try
            {//Data Manager updates all the entries in the database.
                DataManager.UpdateAll(projectData);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving data!");
            }

        }
        public string MenuLabeler
        {//Turns the label for the status strip into a property to use repeatedly.
            set
            {
                menuLabel.Text = value;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            projectData = new ProjectsDataSet();
            GetData();
            MenuLabeler = "Welcome to the Company Database! Please use the navigation at the top of the window to get started!";
        }
        //I went and figured out how to do this as well. Though I decided to center the text of the status strip, because I liked it better.
        private void timer1_Tick(object sender, EventArgs e)
        {
            todaysDateLabel.Text = DateTime.Now.ToString();
        }

        //And of course I made a method for turning this into the Mdi parent for each form.

        private void OpenForm(Form OpenForm)
        {
            OpenForm.MdiParent = this;
            OpenForm.Show();
            MenuLabeler = OpenForm.Text + " has been opened!";
        }

        private void projectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new ProjectTasks(projectData));
        }

       

        private void saveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {//I figured out how to Hot key this one! It made doing my data testing quite a bit quicker when there was data entries involved!
            SaveData();
        }

        private void projectTaskOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new Project_Employees(projectData));
        }

        private void employeeHoursEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new Employee_Tasks_Entry(projectData));
        }

        private void employeeHoursOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new Employee_Tasks_View(projectData));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yes I looked this one up, I wanted to add it.
            MessageBoxButtons boxButtons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show("Are you sure you want to Quit?", "Exit Warning",boxButtons);
            if (result == DialogResult.Yes)
            {
             
                this.Close();
            }
        
        }

        private void closeWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {//I just like this button so I made it part of the main form.
            foreach (Form c in this.MdiChildren)
            {
                c.Close();
            }
        }
        //I added these because a couple extra lines of code wasn't that hard to add.
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
