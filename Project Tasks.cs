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
    public partial class ProjectTasks : Form
    {
        //This form is first one I did after the main form because I predicted it would be the easiest because I could use the DataObjects Detils and GridView. It also let me see their limitations as the first thing I tried to do was wire StatusID to StatusName
        //I could not for the life of me get it to work. I felt like we HAD done that, but I think we had done that with a list box. So I decided the simplest way was to communicate what each of 4 StatusID's ment as that was the only confusing part of entry inputs.

        
        public ProjectTasks(ProjectsDataSet projectsData)
        {
            InitializeComponent();
            projectsDataSet = null;

            projectsDataSet = projectsData;
            projectsBindingSource.DataSource = projectsDataSet;
            //I thought about it and decided that using a label key for the StatusID would work just as well as any horrid attempt on my part to mess with the grid view.

        }

        private void projectsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {//Left the save in for people who dont read menus.
            try
            {
                this.Validate();
                this.projectsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.projectsDataSet);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving Data!");
            }

        }


    }
}
