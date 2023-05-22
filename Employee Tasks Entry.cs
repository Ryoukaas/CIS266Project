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
    public partial class Employee_Tasks_Entry : Form
    {//This form was created because I could not conceive a way to create a form that would meet the specific viewing needs for Form 3 that would also act as accurate data entry. I tried to make it more user friendly in the process.
        bool formLoaded = false;
        public Employee_Tasks_Entry(ProjectsDataSet projectsData)
        {
            InitializeComponent();
            projectsDataSet = null;

            projectsDataSet = projectsData;
            employeesBindingSource.DataSource = projectsDataSet;
            FillProjectListBox();
            formLoaded = true;
            lvTasks.View = View.Details;
        }

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {//I left these save events in despite my Hot Keyed save option because I wanted to leave the option for those who aren't very computer savvy.
            try
            {


                this.Validate();
                this.employeesBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.projectsDataSet);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Error!");
            }

        }
     private void FillProjectListBox()
        {//Giving the list box it's data.
            lbProjects.DataSource = projectsDataSet.Projects;
            lbProjects.ValueMember = "ProjectID";
            lbProjects.DisplayMember = "ProjectName";

        }
        private void FillListView()
        {//Giving the ListView to hold task names and their respective IDs to be available.
            lvTasks.Columns.Add("Task Name", 100);
            lvTasks.Columns.Add("TaskID", 75);
        }

        private void lbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {//So I wanted to make it user friendly, but you cant do that with a gridview very easily, so I created these to help find taskIDs since thats the only questionable input here.
            
            //Formloaded bool and Listbox Selected index to avoid errors.
            if (lbProjects.SelectedIndex != -1 && formLoaded == true)
            {
                //Clear and reset the columns and items for each selection
                lvTasks.Items.Clear();
                lvTasks.Columns.Clear();
                FillListView();
                int projectID = (int)lbProjects.SelectedValue;
                foreach (ProjectsDataSet.TasksRow task in projectsDataSet.Tasks)
                {
                    if(task.ProjectID==projectID)
                    {
                        
                        ListViewItem itmTask = new ListViewItem(task.TaskName);
                        itmTask.SubItems.Add(task.TaskID.ToString());

                        lvTasks.Items.Add(itmTask);
                    }
                }
                
            }
                

        }

    
    }
}
