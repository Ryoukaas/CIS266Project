
namespace CIS266Project
{
    partial class Project_Employees
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.projectsDataSet = new CIS266Project.ProjectsDataSet();
            this.projectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projectsTableAdapter = new CIS266Project.ProjectsDataSetTableAdapters.ProjectsTableAdapter();
            this.tableAdapterManager = new CIS266Project.ProjectsDataSetTableAdapters.TableAdapterManager();
            this.workEntriesTableAdapter = new CIS266Project.ProjectsDataSetTableAdapters.WorkEntriesTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.workEntriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lvTasks = new System.Windows.Forms.ListView();
            this.lvProjects = new System.Windows.Forms.ListView();
            this.lblProjectHours = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.projectsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workEntriesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // projectsDataSet
            // 
            this.projectsDataSet.DataSetName = "ProjectsDataSet";
            this.projectsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // projectsBindingSource
            // 
            this.projectsBindingSource.DataMember = "Projects";
            this.projectsBindingSource.DataSource = this.projectsDataSet;
            // 
            // projectsTableAdapter
            // 
            this.projectsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.EmployeesTableAdapter = null;
            this.tableAdapterManager.ProjectsTableAdapter = this.projectsTableAdapter;
            this.tableAdapterManager.StatusTableAdapter = null;
            this.tableAdapterManager.TasksTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = CIS266Project.ProjectsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.WorkEntriesTableAdapter = this.workEntriesTableAdapter;
            // 
            // workEntriesTableAdapter
            // 
            this.workEntriesTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please select a Project from the list below.";
            // 
            // workEntriesBindingSource
            // 
            this.workEntriesBindingSource.DataMember = "WorkEntries";
            this.workEntriesBindingSource.DataSource = this.projectsDataSet;
            // 
            // lvTasks
            // 
            this.lvTasks.HideSelection = false;
            this.lvTasks.Location = new System.Drawing.Point(433, 38);
            this.lvTasks.Name = "lvTasks";
            this.lvTasks.Size = new System.Drawing.Size(405, 378);
            this.lvTasks.TabIndex = 16;
            this.lvTasks.UseCompatibleStateImageBehavior = false;
            // 
            // lvProjects
            // 
            this.lvProjects.HideSelection = false;
            this.lvProjects.Location = new System.Drawing.Point(12, 38);
            this.lvProjects.Name = "lvProjects";
            this.lvProjects.Size = new System.Drawing.Size(384, 332);
            this.lvProjects.TabIndex = 17;
            this.lvProjects.UseCompatibleStateImageBehavior = false;
            this.lvProjects.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvProjects_ItemSelectionChanged);
            // 
            // lblProjectHours
            // 
            this.lblProjectHours.AutoSize = true;
            this.lblProjectHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectHours.Location = new System.Drawing.Point(9, 409);
            this.lblProjectHours.Name = "lblProjectHours";
            this.lblProjectHours.Size = new System.Drawing.Size(0, 18);
            this.lblProjectHours.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(388, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Looking to add data? Use the Edit Menu to find the correct Data Entry Windows!\r\n";
            // 
            // Project_Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProjectHours);
            this.Controls.Add(this.lvProjects);
            this.Controls.Add(this.lvTasks);
            this.Controls.Add(this.label1);
            this.Name = "Project_Employees";
            this.Text = "Project Employee Tasks Overview";
            ((System.ComponentModel.ISupportInitialize)(this.projectsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workEntriesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProjectsDataSet projectsDataSet;
        private System.Windows.Forms.BindingSource projectsBindingSource;
        private ProjectsDataSetTableAdapters.ProjectsTableAdapter projectsTableAdapter;
        private ProjectsDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private ProjectsDataSetTableAdapters.WorkEntriesTableAdapter workEntriesTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource workEntriesBindingSource;
        private System.Windows.Forms.ListView lvTasks;
        private System.Windows.Forms.ListView lvProjects;
        private System.Windows.Forms.Label lblProjectHours;
        private System.Windows.Forms.Label label2;
    }
}