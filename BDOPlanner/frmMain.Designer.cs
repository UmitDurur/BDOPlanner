
namespace BDOPlanner
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.flowLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDaily = new System.Windows.Forms.Button();
            this.btnWeekly = new System.Windows.Forms.Button();
            this.btnEvents = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.flowRoutines = new System.Windows.Forms.FlowLayoutPanel();
            this.flowWeeklyRoutines = new System.Windows.Forms.FlowLayoutPanel();
            this.flowEvent = new System.Windows.Forms.FlowLayoutPanel();
            this.AppNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.flowIntervalEvents = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLeft.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLeft
            // 
            this.flowLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.flowLeft.Controls.Add(this.btnDaily);
            this.flowLeft.Controls.Add(this.btnWeekly);
            this.flowLeft.Controls.Add(this.btnEvents);
            this.flowLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLeft.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLeft.Location = new System.Drawing.Point(0, 29);
            this.flowLeft.Margin = new System.Windows.Forms.Padding(0);
            this.flowLeft.Name = "flowLeft";
            this.flowLeft.Size = new System.Drawing.Size(100, 653);
            this.flowLeft.TabIndex = 2;
            // 
            // btnDaily
            // 
            this.btnDaily.FlatAppearance.BorderSize = 0;
            this.btnDaily.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDaily.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDaily.ForeColor = System.Drawing.Color.White;
            this.btnDaily.Location = new System.Drawing.Point(0, 0);
            this.btnDaily.Margin = new System.Windows.Forms.Padding(0);
            this.btnDaily.Name = "btnDaily";
            this.btnDaily.Size = new System.Drawing.Size(100, 25);
            this.btnDaily.TabIndex = 0;
            this.btnDaily.Text = "Daily";
            this.btnDaily.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDaily.UseVisualStyleBackColor = true;
            // 
            // btnWeekly
            // 
            this.btnWeekly.FlatAppearance.BorderSize = 0;
            this.btnWeekly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeekly.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnWeekly.ForeColor = System.Drawing.Color.White;
            this.btnWeekly.Location = new System.Drawing.Point(0, 25);
            this.btnWeekly.Margin = new System.Windows.Forms.Padding(0);
            this.btnWeekly.Name = "btnWeekly";
            this.btnWeekly.Size = new System.Drawing.Size(100, 25);
            this.btnWeekly.TabIndex = 1;
            this.btnWeekly.Text = "Weekly";
            this.btnWeekly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWeekly.UseVisualStyleBackColor = true;
            // 
            // btnEvents
            // 
            this.btnEvents.FlatAppearance.BorderSize = 0;
            this.btnEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvents.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEvents.ForeColor = System.Drawing.Color.White;
            this.btnEvents.Location = new System.Drawing.Point(0, 50);
            this.btnEvents.Margin = new System.Windows.Forms.Padding(0);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Size = new System.Drawing.Size(100, 25);
            this.btnEvents.TabIndex = 2;
            this.btnEvents.Text = "Events";
            this.btnEvents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEvents.UseVisualStyleBackColor = true;
            this.btnEvents.Click += new System.EventHandler(this.btnEvents_Click);
            // 
            // btnHide
            // 
            this.btnHide.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHide.Image = global::BDOPlanner.Properties.Resources.collapse;
            this.btnHide.Location = new System.Drawing.Point(5, 655);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(30, 25);
            this.btnHide.TabIndex = 99;
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHeader.Location = new System.Drawing.Point(3, 3);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(98, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "BDO Planner";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlHeader.Controls.Add(this.btnMinimize);
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1038, 29);
            this.pnlHeader.TabIndex = 3;
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(993, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(20, 23);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.Text = "_";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1013, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.flowIntervalEvents);
            this.pnlContent.Controls.Add(this.flowRoutines);
            this.pnlContent.Controls.Add(this.flowWeeklyRoutines);
            this.pnlContent.Controls.Add(this.flowEvent);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlContent.Location = new System.Drawing.Point(97, 29);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(941, 653);
            this.pnlContent.TabIndex = 4;
            // 
            // flowRoutines
            // 
            this.flowRoutines.AutoScroll = true;
            this.flowRoutines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowRoutines.Location = new System.Drawing.Point(0, 0);
            this.flowRoutines.Name = "flowRoutines";
            this.flowRoutines.Size = new System.Drawing.Size(941, 417);
            this.flowRoutines.TabIndex = 1;
            // 
            // flowWeeklyRoutines
            // 
            this.flowWeeklyRoutines.AutoScroll = true;
            this.flowWeeklyRoutines.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowWeeklyRoutines.Location = new System.Drawing.Point(0, 417);
            this.flowWeeklyRoutines.Name = "flowWeeklyRoutines";
            this.flowWeeklyRoutines.Size = new System.Drawing.Size(941, 135);
            this.flowWeeklyRoutines.TabIndex = 0;
            // 
            // flowEvent
            // 
            this.flowEvent.AutoScroll = true;
            this.flowEvent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowEvent.Location = new System.Drawing.Point(0, 552);
            this.flowEvent.Name = "flowEvent";
            this.flowEvent.Size = new System.Drawing.Size(941, 101);
            this.flowEvent.TabIndex = 0;
            // 
            // AppNotifyIcon
            // 
            this.AppNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.AppNotifyIcon.BalloonTipText = "BDO Planner Minimized";
            this.AppNotifyIcon.BalloonTipTitle = "BDO Planner";
            this.AppNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("AppNotifyIcon.Icon")));
            this.AppNotifyIcon.Text = "BDO Planner";
            this.AppNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AppNotifyIcon_MouseDoubleClick);
            // 
            // flowIntervalEvents
            // 
            this.flowIntervalEvents.AutoScroll = true;
            this.flowIntervalEvents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowIntervalEvents.Location = new System.Drawing.Point(0, 282);
            this.flowIntervalEvents.Name = "flowIntervalEvents";
            this.flowIntervalEvents.Size = new System.Drawing.Size(941, 135);
            this.flowIntervalEvents.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 682);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.flowLeft);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BDO Planner";
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.flowLeft.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLeft;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDaily;
        private System.Windows.Forms.Button btnWeekly;
        private System.Windows.Forms.Button btnEvents;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.FlowLayoutPanel flowEvent;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.NotifyIcon AppNotifyIcon;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.FlowLayoutPanel flowRoutines;
        private System.Windows.Forms.FlowLayoutPanel flowWeeklyRoutines;
        private System.Windows.Forms.FlowLayoutPanel flowIntervalEvents;
    }
}