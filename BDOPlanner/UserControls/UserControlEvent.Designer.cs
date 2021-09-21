
namespace BDOPlanner.UserControls
{
    partial class UserControlEvent
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
            this.lblTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // pbEvent
            // 
            this.pbEvent.Location = new System.Drawing.Point(0, 0);
            this.pbEvent.Name = "pbEvent";
            this.pbEvent.Size = new System.Drawing.Size(60, 60);
            this.pbEvent.TabIndex = 0;
            this.pbEvent.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(0, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Kzarka";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(0, 75);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(60, 15);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "Kzarka";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControlEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbEvent);
            this.Name = "UserControlEvent";
            this.Size = new System.Drawing.Size(60, 93);
            ((System.ComponentModel.ISupportInitialize)(this.pbEvent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbEvent;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblName;
    }
}
