using BDOPlanner.Models;
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
using BDOPlanner.ExternalSources;

namespace BDOPlanner.UserControls
{
    public partial class UserControlEvent : UserControl
    {
        public GameEvent gameEvent { get; set; }
        private const int lastBossNotify = 0;
        private const int lastWarNotify = 900000;

        public UserControlEvent(GameEvent gameevent, Image image)
        {
            InitializeComponent();
            this.gameEvent = gameevent;
            pbEvent.Image = image;
            pbEvent.SizeMode = PictureBoxSizeMode.StretchImage;
            lblName.Text = gameevent.Name;
            DateTime dtNow = DateTime.Now;
            DateTime dateTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.StartOfWeek(DayOfWeek.Monday).Day, gameevent.Hour, gameevent.Minute, 0);
            dateTime = dateTime.AddDays(gameEvent.Day == 0 ? 7 : gameEvent.Day);
            lblTime.Text = dateTime.ToShortTimeString();

            int interval = Convert.ToInt32((dateTime - dtNow).TotalMilliseconds);
            if (interval > (gameevent.Type == GameEvent.EventType.Boss ? lastBossNotify : lastWarNotify))
            {
                timer = new Timer();
                timer.Interval = interval - (gameevent.Type == GameEvent.EventType.Boss ? lastBossNotify : lastWarNotify);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            else
                this.BackColor = Color.Green;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ExternalSources.SoundPlayerContainer.PlayNotifySound();
            this.BackColor = Color.Green;
            timer.Stop();
        }

        Timer timer;

    }
}
