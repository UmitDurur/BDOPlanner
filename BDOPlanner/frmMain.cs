using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Runtime.InteropServices;
using BDOPlanner.UserControls;
using BDOPlanner.Models;
using BDOPlanner.ExternalSources;

namespace BDOPlanner
{
    public partial class frmMain : Form, IMessageFilter
    {
        public frmMain()
        {
            InitializeComponent();

            #region Form
            Application.AddMessageFilter(this);

            controlsToMove.Add(this);
            controlsToMove.Add(this.pnlHeader);//Add whatever controls here you want to move the form when it is clicked and dragged
            controlsToMove.Add(this.lblHeader);
            #endregion


            this.Icon = Properties.Resources.appicon;

            //db file location
            connection = new SQLiteConnection(string.Format(@"Data Source={0}\BDOPlanner\database.db;", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)));


            imageListEvent = new ImageList();
            imageListEvent.ImageSize = new Size(86, 86);
            imageListEvent.ColorDepth = ColorDepth.Depth32Bit;

            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory() + @"/Resources/");
            FileInfo[] files = directoryInfo.GetFiles("*.png");
            for (int i = 0; i < files.Length; i++)
            {
                int index = files[i].Name.LastIndexOf('.');
                imageListEvent.Images.Add(Image.FromFile(@"Resources/" + files[i].Name));
                imageListEvent.Images.SetKeyName(i, files[i].Name.Substring(0, index));
            }

            btnHide.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            UpdateDailyRoutines();
            UpdateIntervalRoutines();
            UpdateWeeklyRoutines();
            UpdateDailyEvent();
        }

        private void UpdateIntervalRoutines()
        {
            flowIntervalEvents.Controls.Clear();
            List<SQLiteParameter> sqliteParameters = new List<SQLiteParameter>();


            #region Interval Events
            string queryString = @"
                SELECT i.id,i.name,i.image_url,i.interval,
                    CASE
                        WHEN i.lastcompletion IS NULL
                            THEN datetime('2000-01-01 00:00:00')
                        ELSE datetime(i.lastcompletion,'unixepoch')
                    END as date
                FROM    interval_events i 
            ";
            command = new SQLiteCommand();
            command.CommandText = queryString;
            command.Connection = connection;
            command.Parameters.AddRange(sqliteParameters.ToArray());
            connection.Open();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                IntervalEvent intervalevent = new IntervalEvent();
                intervalevent.ID = Convert.ToInt32(reader["id"]);
                intervalevent.Name = reader["name"].ToString();
                intervalevent.ImageURL = reader["image_url"].ToString();
                intervalevent.LastCompletion = Convert.ToDateTime(reader["date"]);
                intervalevent.Interval = Convert.ToInt32(reader["interval"]);



                int imageindex = imageListEvent.Images.IndexOfKey(intervalevent.ImageURL);

                UserControlEventWInterval ucIntervalRoutine = new UserControlEventWInterval(intervalevent, imageListEvent.Images[imageindex >= 0 ? imageindex : imageListEvent.Images.IndexOfKey("notfound")]);
                ucIntervalRoutine.DoubleClick += UcIntervalRoutine_DoubleClick;
                foreach (Control c in ucIntervalRoutine.Controls)
                    c.DoubleClick += new EventHandler(UcIntervalRoutine_DoubleClick);
                flowIntervalEvents.Controls.Add(ucIntervalRoutine);
            }
            #endregion

            connection.Close();
        }

        SQLiteConnection connection;
        SQLiteCommand command;
        private ImageList imageListEvent;

        private void UcEvent_Click(object sender, EventArgs e)
        {

        }


        private void UpdateDailyEvent()
        {
            #region Daily Event

            flowEvent.Controls.Clear();
            DateTime dtNow = DateTime.Now;
            List<SQLiteParameter> sqliteParameters = new List<SQLiteParameter>();
            sqliteParameters.Add(new SQLiteParameter("@today", dtNow.DayOfWeekEx().ToString()));
            sqliteParameters.Add(new SQLiteParameter("@tomorrow", dtNow.AddDays(1).DayOfWeekEx().ToString()));
            string queryString = @"
                SELECT e.event_name,e.event_type,e.image_url,t.day,t.hour,t.minute 
                FROM    event_times t
                inner join events e on t.event_id=e.id
                where   day=@today 
                        OR  day=@tomorrow
                order by CASE 
                            WHEN @tomorrow > @today THEN day END ASC ,
                         CASE 
                            WHEN @today > @tomorrow THEN day END DESC ,
                        hour ASC
            ";
            command = new SQLiteCommand();
            command.CommandText = queryString;
            command.Connection = connection;
            command.Parameters.AddRange(sqliteParameters.ToArray());
            connection.Open();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GameEvent gameevent = new GameEvent();
                gameevent.Name = reader["event_name"].ToString();
                gameevent.Type = (GameEvent.EventType)Convert.ToInt32(reader["event_type"]);
                gameevent.ImageURL = reader["image_url"].ToString();
                gameevent.Day = Convert.ToInt32(reader["day"]);
                gameevent.Hour = Convert.ToInt32(reader["hour"]);
                gameevent.Minute = Convert.ToInt32(reader["minute"]);


                int imageindex = imageListEvent.Images.IndexOfKey(gameevent.ImageURL);

                UserControlEvent ucEvent = new UserControlEvent(gameevent, imageListEvent.Images[imageindex >= 0 ? imageindex : imageListEvent.Images.IndexOfKey("notfound")]);
                ucEvent.Click += UcEvent_Click;
                foreach (Control c in ucEvent.Controls)
                    c.Click += new EventHandler(UcEvent_Click);
                flowEvent.Controls.Add(ucEvent);
            }

            connection.Close();
            #endregion

        }

        private void UpdateWeeklyRoutines()
        {
            flowWeeklyRoutines.Controls.Clear();
            List<SQLiteParameter> sqliteParameters = new List<SQLiteParameter>();
            sqliteParameters.Add(new SQLiteParameter("@today", Convert.ToDateTime(DateTime.Now).ToString()));


            #region Weekly To-Do
            string queryString = @"
                SELECT w.weekly_id,w.weekly_name,w.image_url,
                    CASE
                        WHEN wl1.wdate IS NULL
                            THEN datetime('2000-01-01 00:00:00')
                        ELSE datetime(wl1.wdate,'unixepoch')
                    END as wdate
                FROM    weekly_to_do w 
                LEFT JOIN weekly_log wl1 ON (w.weekly_id=wl1.weekly_id)
                LEFT OUTER JOIN weekly_log wl2 ON (w.weekly_id=wl2.weekly_id AND 
                        (wl1.wdate<wl2.wdate OR (wl1.wdate=wl2.wdate AND wl1.weekly_log_id<wl2.weekly_log_id)))
                where wl2.weekly_log_id IS NULL;
            ";
            command = new SQLiteCommand();
            command.CommandText = queryString;
            command.Connection = connection;
            command.Parameters.AddRange(sqliteParameters.ToArray());
            connection.Open();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                WeeklyEvent weeklyevent = new WeeklyEvent();
                weeklyevent.ID = Convert.ToInt32(reader["weekly_id"]);
                weeklyevent.Name = reader["weekly_name"].ToString();
                weeklyevent.ImageURL = reader["image_url"].ToString();
                weeklyevent.LastCompletion = Convert.ToDateTime(reader["wdate"]);

                int imageindex = imageListEvent.Images.IndexOfKey(weeklyevent.ImageURL);

                UserControlLooseEvent ucWeeklyEvent = new UserControlLooseEvent(weeklyevent, imageListEvent.Images[imageindex >= 0 ? imageindex : imageListEvent.Images.IndexOfKey("notfound")]);
                ucWeeklyEvent.DoubleClick += UcWeeklyEvent_Click;
                foreach (Control c in ucWeeklyEvent.Controls)
                    c.DoubleClick += new EventHandler(UcWeeklyEvent_Click);
                flowWeeklyRoutines.Controls.Add(ucWeeklyEvent);
            }
            #endregion
            connection.Close();

        }

        private void UcWeeklyEvent_Click(object sender, EventArgs e)
        {

            while (((Control)sender).GetType() != typeof(UserControlLooseEvent))
                sender = ((Control)sender).Parent;
            UserControlLooseEvent senderEvent = sender as UserControlLooseEvent;
            WeeklyEvent weeklyEvent = (WeeklyEvent)senderEvent.modelEvent;

            DateTime dt = DateTime.Now;
            List<SQLiteParameter> sqliteParameters = new List<SQLiteParameter>();

            sqliteParameters.Add(new SQLiteParameter("@id", weeklyEvent.ID));
            sqliteParameters.Add(new SQLiteParameter("@startofweek", dt.StartOfWeek(DayOfWeek.Monday)));


            #region Weekly To-Do
            string queryString = "";
            if (weeklyEvent.LastCompletion != dt.StartOfWeek(DayOfWeek.Monday))
                queryString += @"insert into weekly_log('weekly_id','wdate') 
                                            values(@id,strftime('%s',@startofweek))
            ";
            else
                queryString += @"delete from weekly_log 
                                where   weekly_id=@id
                                AND     wdate=strftime('%s',@startofweek)
";

            command = new SQLiteCommand();
            command.CommandText = queryString;
            command.Connection = connection;
            command.Parameters.AddRange(sqliteParameters.ToArray());
            connection.Open();
            int result = command.ExecuteNonQuery();

            #endregion
            connection.Close();
            UpdateRoutineState(senderEvent, weeklyEvent);
            //UpdateWeeklyRoutines();
        }

        private void UpdateDailyRoutines()
        {
            flowRoutines.Controls.Clear();
            List<SQLiteParameter> sqliteParameters = new List<SQLiteParameter>();


            #region Daily To-Do
            string queryString = @"
                SELECT d.daily_id,d.daily_name,d.image_url,
                    CASE
                        WHEN dl1.date IS NULL
                            THEN datetime('2000-01-01 00:00:00')
                        ELSE datetime(dl1.date,'unixepoch')
                    END as date
                FROM    daily_to_do d 
                LEFT JOIN daily_log dl1 ON (d.daily_id=dl1.daily_id)
                LEFT OUTER JOIN daily_log dl2 ON (d.daily_id=dl2.daily_id AND 
                        (dl1.date<dl2.date OR (dl1.date=dl2.date AND dl1.daily_log_id<dl2.daily_log_id)))
                where dl2.daily_log_id IS NULL;
            ";
            command = new SQLiteCommand();
            command.CommandText = queryString;
            command.Connection = connection;
            command.Parameters.AddRange(sqliteParameters.ToArray());
            connection.Open();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DailyEvent dailyevent = new DailyEvent();
                dailyevent.ID = Convert.ToInt32(reader["daily_id"]);
                dailyevent.Name = reader["daily_name"].ToString();
                dailyevent.ImageURL = reader["image_url"].ToString();
                dailyevent.LastCompletion = Convert.ToDateTime(reader["date"]);


                int imageindex = imageListEvent.Images.IndexOfKey(dailyevent.ImageURL);

                UserControlLooseEvent ucDailyRoutine = new UserControlLooseEvent(dailyevent, imageListEvent.Images[imageindex >= 0 ? imageindex : imageListEvent.Images.IndexOfKey("notfound")]);
                ucDailyRoutine.DoubleClick += UcDailyRoutine_Click;
                foreach (Control c in ucDailyRoutine.Controls)
                    c.DoubleClick += new EventHandler(UcDailyRoutine_Click);
                flowRoutines.Controls.Add(ucDailyRoutine);
            }
            #endregion

            connection.Close();

        }

        private void UcIntervalRoutine_DoubleClick(object sender, EventArgs e)
        {
            while (((Control)sender).GetType() != typeof(UserControlEventWInterval))
                sender = ((Control)sender).Parent;
            UserControlEventWInterval senderEvent = sender as UserControlEventWInterval;
            IntervalEvent intervalEvent = (IntervalEvent)senderEvent.intervalEvent;

            DateTime dt = DateTime.Now;
            List<SQLiteParameter> sqliteParameters = new List<SQLiteParameter>();

            sqliteParameters.Add(new SQLiteParameter("@id", intervalEvent.ID));


            #region Weekly To-Do
            string queryString = "";
            if (intervalEvent.LastCompletion.AddMinutes(intervalEvent.Interval) > dt)
                sqliteParameters.Add(new SQLiteParameter("@date", dt.AddMinutes((intervalEvent.Interval*-1))));
            else
                sqliteParameters.Add(new SQLiteParameter("@date", dt));

            queryString += @"update interval_events set lastcompletion=strftime('%s',@date) where id=@id";
            command = new SQLiteCommand();
            command.CommandText = queryString;
            command.Connection = connection;
            command.Parameters.AddRange(sqliteParameters.ToArray());
            connection.Open();
            int result = command.ExecuteNonQuery();

            #endregion
            connection.Close();
            UpdateRoutineState(senderEvent, intervalEvent);
            //UpdateDailyRoutines();
        }


        /*private void UcDailyRoutine_Click(object sender, EventArgs e)
        {
            while (((Control)sender).GetType() != typeof(UserControlLooseEvent))
                sender = ((Control)sender).Parent;
            DailyEvent dailyEvent = (DailyEvent)(sender as UserControlLooseEvent).modelEvent;

            DateTime dt = DateTime.Now;
            List<SQLiteParameter> sqliteParameters = new List<SQLiteParameter>();

            sqliteParameters.Add(new SQLiteParameter("@id", dailyEvent.ID));
            sqliteParameters.Add(new SQLiteParameter("@day", dailyEvent.LastCompletion == Convert.ToInt32(dt.Day) ? -1 : Convert.ToInt32(dt.Day)));


            #region Weekly To-Do
            string queryString = @"
                UPDATE daily_to_do set last_comp_day=@day 
                where id=@id
            ";
            command = new SQLiteCommand();
            command.CommandText = queryString;
            command.Connection = connection;
            command.Parameters.AddRange(sqliteParameters.ToArray());
            connection.Open();
            int result = (int)command.ExecuteNonQuery();

            #endregion
            connection.Close();
            UpdateDailyRoutines();
        }*/
        private void UcDailyRoutine_Click(object sender, EventArgs e)
        {
            while (((Control)sender).GetType() != typeof(UserControlLooseEvent))
                sender = ((Control)sender).Parent;
            UserControlLooseEvent senderEvent = sender as UserControlLooseEvent;
            DailyEvent dailyEvent = (DailyEvent)senderEvent.modelEvent;

            DateTime dt = DateTime.Now;
            List<SQLiteParameter> sqliteParameters = new List<SQLiteParameter>();

            sqliteParameters.Add(new SQLiteParameter("@id", dailyEvent.ID));
            sqliteParameters.Add(new SQLiteParameter("@today", dt.Date));


            #region Weekly To-Do
            string queryString = "";
            if (dailyEvent.LastCompletion != dt.Date)
                queryString += @"insert into daily_log('daily_id','date') 
                                            values(@id,strftime('%s',@today))
            ";
            else
                queryString += @"delete from daily_log 
                                where   daily_id=@id
                                AND     date=strftime('%s',@today)
";

            command = new SQLiteCommand();
            command.CommandText = queryString;
            command.Connection = connection;
            command.Parameters.AddRange(sqliteParameters.ToArray());
            connection.Open();
            int result = command.ExecuteNonQuery();

            #endregion
            connection.Close();
            UpdateRoutineState(senderEvent, dailyEvent);
            //UpdateDailyRoutines();
        }



        private void UpdateRoutineState(UserControl target, IEvent targetEvent)
        {
            DateTime dt = DateTime.Now;
            List<SQLiteParameter> sqliteParameters = new List<SQLiteParameter>();

            sqliteParameters.Add(new SQLiteParameter("@id", targetEvent.ID));
            try
            {


                #region Weekly To-Do
                string queryString = "";

                if (targetEvent.GetType() == typeof(DailyEvent))
                    queryString = @"
                        SELECT 
                     datetime(dl.date,'unixepoch') as date
                FROM    daily_log dl
                        WHERE daily_id=@id 
                ORDER BY daily_log_id desc LIMIT 1
";
                else if (targetEvent.GetType() == typeof(WeeklyEvent)) queryString = @"
                        SELECT 
                     datetime(wl.wdate,'unixepoch') as date
                FROM    weekly_log wl
                        WHERE weekly_id=@id 
                ORDER BY weekly_log_id desc LIMIT 1
";
                else if (targetEvent.GetType() == typeof(IntervalEvent)) queryString = @"
                        SELECT 
                     datetime(ie.lastcompletion,'unixepoch') as date
                FROM    interval_events ie
                        WHERE id=@id 
                ORDER BY id desc LIMIT 1
";

                command = new SQLiteCommand();
                command.CommandText = queryString;
                command.Connection = connection;
                command.Parameters.AddRange(sqliteParameters.ToArray());
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
                DateTime result;
                if (reader.HasRows)
                {
                    reader.Read();
                    result = Convert.ToDateTime(reader["date"]);
                    #endregion
                    reader.Close();
                }
                else
                    result = new DateTime();
                connection.Close();
                if (target.GetType() == typeof(UserControlLooseEvent))
                    (target as UserControlLooseEvent).UpdateLastTime(result);
                else if (target.GetType() == typeof(UserControlEventWInterval))
                    (target as UserControlEventWInterval).UpdateLastTime(result);
            }
            catch { }
        }

        #region Form
        private void btnHide_Click(object sender, EventArgs e)
        {
            if (flowLeft.Width == 100)
            {
                flowLeft.Width = 2;
                pnlContent.Width += 98;
            }
            else
            {
                flowLeft.Width = 100;
                pnlContent.Width -= 98;
            }
            btnHide.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
        }

        #region Drag-Move form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();


        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN &&
                 controlsToMove.Contains(Control.FromHandle(m.HWnd)))
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                return true;
            }
            return false;
        }

        #endregion
        #region Notify
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                AppNotifyIcon.Visible = true;
            }
        }

        private void AppNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            AppNotifyIcon.Visible = false;
        }

        #endregion

        #endregion

        private void btnEvents_Click(object sender, EventArgs e)
        {

            DateTime dtNow = DateTime.Now;
            MessageBox.Show((dtNow - dtNow.StartOfWeek(DayOfWeek.Monday)).Days.ToString());
        }
    }
}
