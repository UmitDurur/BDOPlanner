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
    public partial class UserControlLooseEvent : UserControl
    {
        public IEvent modelEvent { get; set; }

        public UserControlLooseEvent(IEvent modelEvent, Image image)
        {
            InitializeComponent();
            this.modelEvent = modelEvent;
            pbEvent.Image = image;
            pbEvent.SizeMode = PictureBoxSizeMode.StretchImage;
            lblName.Text = modelEvent.Name;
            //if (modelEvent.LastCompletion == (modelEvent.GetType() == typeof(DailyEvent) ? DateTime.Now.Date : ExternalSources.WeekOfYear.GetWeekOfYear(DateTime.Now)))
           
            UpdateEvent();
        }
        public void UpdateLastTime(DateTime dt)
        {
            this.modelEvent.LastCompletion = dt.Date;
            UpdateEvent();
        }

        public void UpdateEvent()
        {
            bool isCompleted = false;
            if (modelEvent.LastCompletion == (modelEvent.GetType() == typeof(DailyEvent) ? DateTime.Now.Date : DateTime.Now.StartOfWeek(DayOfWeek.Monday)))
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
    }
}
