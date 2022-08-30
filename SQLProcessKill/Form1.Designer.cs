namespace SQLProcessKill
{
    partial class Form1
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
            this.lstProcesses = new System.Windows.Forms.ListView();
            this.colProcessId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBlocked = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDBname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCommand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastExecution = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.chkShowMore = new System.Windows.Forms.CheckBox();
            this.chkBlocking = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstProcesses
            // 
            this.lstProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProcessId,
            this.colStatus,
            this.colHost,
            this.colBlocked,
            this.colDBname,
            this.colCommand,
            this.colLastExecution});
            this.lstProcesses.FullRowSelect = true;
            this.lstProcesses.HideSelection = false;
            this.lstProcesses.Location = new System.Drawing.Point(12, 27);
            this.lstProcesses.MultiSelect = false;
            this.lstProcesses.Name = "lstProcesses";
            this.lstProcesses.Size = new System.Drawing.Size(650, 340);
            this.lstProcesses.TabIndex = 0;
            this.lstProcesses.UseCompatibleStateImageBehavior = false;
            this.lstProcesses.View = System.Windows.Forms.View.Details;
            // 
            // colProcessId
            // 
            this.colProcessId.Text = "ID";
            this.colProcessId.Width = 40;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 130;
            // 
            // colHost
            // 
            this.colHost.Text = "Hostname";
            this.colHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colHost.Width = 120;
            // 
            // colBlocked
            // 
            this.colBlocked.Text = "Blocked By";
            this.colBlocked.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colBlocked.Width = 80;
            // 
            // colDBname
            // 
            this.colDBname.Text = "Database";
            this.colDBname.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDBname.Width = 130;
            // 
            // colCommand
            // 
            this.colCommand.Text = "Command";
            this.colCommand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCommand.Width = 80;
            // 
            // colLastExecution
            // 
            this.colLastExecution.Text = "Last Command Time";
            this.colLastExecution.Width = 150;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(192, 375);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(137, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh List";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(346, 375);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Kill Selected Processes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkShowAll
            // 
            this.chkShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.Location = new System.Drawing.Point(13, 380);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(67, 17);
            this.chkShowAll.TabIndex = 3;
            this.chkShowAll.Text = "Show All";
            this.chkShowAll.UseVisualStyleBackColor = true;
            this.chkShowAll.CheckedChanged += new System.EventHandler(this.chkShowAll_CheckedChanged);
            // 
            // chkShowMore
            // 
            this.chkShowMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowMore.AutoSize = true;
            this.chkShowMore.Location = new System.Drawing.Point(87, 380);
            this.chkShowMore.Name = "chkShowMore";
            this.chkShowMore.Size = new System.Drawing.Size(80, 17);
            this.chkShowMore.TabIndex = 4;
            this.chkShowMore.Text = "Show More";
            this.chkShowMore.UseVisualStyleBackColor = true;
            this.chkShowMore.CheckedChanged += new System.EventHandler(this.chkShowMore_CheckedChanged);
            // 
            // chkBlocking
            // 
            this.chkBlocking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBlocking.AutoSize = true;
            this.chkBlocking.Location = new System.Drawing.Point(574, 379);
            this.chkBlocking.Name = "chkBlocking";
            this.chkBlocking.Size = new System.Drawing.Size(88, 17);
            this.chkBlocking.TabIndex = 5;
            this.chkBlocking.Text = "Show Blocks";
            this.chkBlocking.UseVisualStyleBackColor = true;
            this.chkBlocking.CheckedChanged += new System.EventHandler(this.chkBlocking_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(674, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Image = global::SQLProcessKill.Properties.Resources.settings1;
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.connectionToolStripMenuItem.Text = "Settings";
            this.connectionToolStripMenuItem.Click += new System.EventHandler(this.connectionToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 410);
            this.Controls.Add(this.chkBlocking);
            this.Controls.Add(this.chkShowMore);
            this.Controls.Add(this.chkShowAll);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstProcesses);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SQL Process Kill";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstProcesses;
        private System.Windows.Forms.ColumnHeader colProcessId;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colHost;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chkShowAll;
        private System.Windows.Forms.ColumnHeader colBlocked;
        private System.Windows.Forms.ColumnHeader colDBname;
        private System.Windows.Forms.ColumnHeader colCommand;
        private System.Windows.Forms.ColumnHeader colLastExecution;
        private System.Windows.Forms.CheckBox chkShowMore;
        private System.Windows.Forms.CheckBox chkBlocking;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
    }
}

