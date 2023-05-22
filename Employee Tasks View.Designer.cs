
namespace CIS266Project
{
    partial class Employee_Tasks_View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee_Tasks_View));
            this.lvEmployees = new System.Windows.Forms.ListView();
            this.lvTasks = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHours = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvEmployees
            // 
            this.lvEmployees.HideSelection = false;
            this.lvEmployees.Location = new System.Drawing.Point(25, 12);
            this.lvEmployees.Name = "lvEmployees";
            this.lvEmployees.Size = new System.Drawing.Size(357, 133);
            this.lvEmployees.TabIndex = 0;
            this.lvEmployees.UseCompatibleStateImageBehavior = false;
            this.lvEmployees.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvEmployees_ItemSelectionChanged);
            // 
            // lvTasks
            // 
            this.lvTasks.HideSelection = false;
            this.lvTasks.Location = new System.Drawing.Point(25, 186);
            this.lvTasks.Name = "lvTasks";
            this.lvTasks.Size = new System.Drawing.Size(539, 252);
            this.lvTasks.TabIndex = 1;
            this.lvTasks.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 91);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.Location = new System.Drawing.Point(22, 165);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(186, 18);
            this.lblHours.TabIndex = 3;
            this.lblHours.Text = "Employee Has Worked:";
            // 
            // Employee_Tasks_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 450);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvTasks);
            this.Controls.Add(this.lvEmployees);
            this.Name = "Employee_Tasks_View";
            this.Text = "Employee Task Entry Overview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvEmployees;
        private System.Windows.Forms.ListView lvTasks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHours;
    }
}