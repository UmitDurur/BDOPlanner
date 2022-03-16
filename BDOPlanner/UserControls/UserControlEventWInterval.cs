using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BDOPlanner.Models;
using BDOPlanner.ExternalSources;

namespace BDOPlanner.UserControls
{
    public partial class UserControlEventWInterval : UserControl
    {
        public IntervalEvent intervalEvent { get; set; }

        public UserControlEventWInterval(IntervalEvent modelEvent, Image image)
        {
            InitializeComponent();
            this.intervalEvent = modelEvent;
            pbEvent.Image = image;
            pbEvent.SizeMode = PictureBoxSizeMode.StretchImage;
            lblName.Text = modelEvent.Name;

            SetTimerUpdate();
        }
        public void UpdateLastTime(DateTime dt)
        {
            this.intervalEvent.LastCompletion = dt;
            SetTimerUpdate();
            
        }

        private void SetTimerUpdate()
        {
            DateTime dtNow = DateTime.Now;
            DateTime dateTime = intervalEvent.LastCompletion;
            dateTime = dateTime.AddMinutes(intervalEvent.Interval);
            lblTime.Text = dateTime.ToShortTimeString();
            int currentinterval=0;
            try
            {
                currentinterval = Convert.ToInt32((dateTime - dtNow).TotalMilliseconds);
            }
            catch {
                currentinterval = 0;
            }
            if (currentinterval > 0)
            {
                timer = new Timer();
                timer.Interval = currentinterval;
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            UpdateEvent();
        }

        public void UpdateEvent()
        {
            bool isCompleted = false;
            if (intervalEvent.LastCompletion.AddMinutes(intervalEvent.Interval) > DateTime.Now)
            {
                isCompleted = true;
            }
            if (isCompleted)
            {
                this.BackColor = Color.FromArgb(255, 84, 171, 145);
                this.ForeColor = Color.Black;
            }
            else
            {
                this.BackColor = Color.FromArgb(255, 158, 58, 58);
                this.ForeColor = Color.Wheat;
            }
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            ExternalSources.SoundPlayerContainer.PlayNotifySound();
            UpdateEvent();
        }

        Timer timer;
    }
}
