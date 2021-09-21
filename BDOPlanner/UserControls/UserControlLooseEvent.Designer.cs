
namespace BDOPlanner.UserControls
{
    partial class UserControlLooseEvent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbEvent = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // pbEvent
            // 
            this.pbEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbEvent.Location = new System.Drawing.Point(0, 0);
            this.pbEvent.Margin = new System.Windows.Forms.Padding(0);
            this.pbEvent.Name = "pbEvent";
            this.pbEvent.Size = new System.Drawing.Size(86, 86);
            this.pbEvent.TabIndex = 0;
            this.pbEvent.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(0, 86);
            this.lblName.MaximumSize = new System.Drawing.Size(86, 42);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(86, 42);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Kzarka";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UserControlDailyEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbEvent);
            this.Name = "UserControlDailyEvent";
            this.Size = new System.Drawing.Size(86, 128);
            ((System.ComponentModel.ISupportInitialize)(this.pbEvent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbEvent;
        private System.Windows.Forms.Label lblName;
    }
}
