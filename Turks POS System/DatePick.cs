using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turks_POS_System
{
    public partial class DatePick : Form
    {
        DateTime now = DateTime.Now;
        Label day;
        FlowLayoutPanel week;

        public DatePick()
        {
            InitializeComponent();
            lbl_monthyr.Text = now.ToString("MMMM") + " " + now.Year.ToString();

            string n = lbl_monthyr.Text.Substring(0, lbl_monthyr.Text.IndexOf(" "));
            DateTime myDate = DateTime.Parse("1." + n + " 2008");
            string m = myDate.ToString("MM");
            string n2 = lbl_monthyr.Text.Remove(0, lbl_monthyr.Text.IndexOf(' ') + 1);
            DateTime myDate2 = DateTime.ParseExact(n2, "yyyy", System.Globalization.CultureInfo.InvariantCulture);
            string y = myDate2.ToString("yyyy");

            //MessageBox.Show(m +" "+ y);
            List<DateTime> lt = new List<DateTime>();
            lt = GetDates(Convert.ToInt32(y), Convert.ToInt32(m));
            List<String> daysname = new List<String>();
            List<String> daysnum = new List<String>();
            foreach (DateTime d in lt)
            {
                daysname.Add(d.ToString("dddd"));
                List<String> temp = new List<String>();
                temp.Add(d.ToString("d"));
                List<String> temp2 = new List<String>();
                foreach (string s in temp)
                {
                    temp2.Add(s.Split('/')[0]);
                }
                foreach (string s in temp2)
                {
                    daysnum.Add(s.TrimStart(new Char[] {'0'}));
                }
            }

            //GET PAST DATES
            m = myDate.AddMonths(-1).ToString("MM");
            y = myDate2.Year.ToString();

            List<DateTime> lt2 = new List<DateTime>();
            lt2 = GetDates(Convert.ToInt32(y), Convert.ToInt32(m));
            List<String> daysname2 = new List<String>();
            List<String> daysnum2 = new List<String>();
            foreach (DateTime d in lt2)
            {
                daysname2.Add(d.ToString("dddd"));
                List<String> temp = new List<String>();
                temp.Add(d.ToString("d"));
                List<String> temp2 = new List<String>();
                foreach (string s in temp)
                {
                    temp2.Add(s.Split('/')[0]);
                }
                foreach (string s in temp2)
                {
                    daysnum2.Add(s.TrimStart(new Char[] { '0' }));
                }
            }
            //END OF GET PAST DATES

            //GET FUTURE DATES
            m = myDate.AddMonths(+1).ToString("MM");
            y = myDate2.Year.ToString();

            List<DateTime> lt3 = new List<DateTime>();
            lt3 = GetDates(Convert.ToInt32(y), Convert.ToInt32(m));
            List<String> daysname3 = new List<String>();
            List<String> daysnum3 = new List<String>();
            foreach (DateTime d in lt3)
            {
                daysname3.Add(d.ToString("dddd"));
                List<String> temp = new List<String>();
                temp.Add(d.ToString("d"));
                List<String> temp2 = new List<String>();
                foreach (string s in temp)
                {
                    temp2.Add(s.Split('/')[0]);
                }
                foreach (string s in temp2)
                {
                    daysnum3.Add(s.TrimStart(new Char[] { '0' }));
                }
            }
            //END OF GET FUTURE DATES

            string[] dnum = daysnum.ToArray();
            string[] dname = daysname.ToArray();
            string[] dnum2 = daysnum2.ToArray();
            string[] dname2 = daysname2.ToArray();
            string[] dnum3 = daysnum3.ToArray();
            string[] dname3 = daysname3.ToArray();

            int i = 0;
            string[] pdays = new string[10];
            string[] fdays = new string[10];
            if (daysname.First() == "Sunday")
            {
                int cnt = 0;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Monday")
            {
                int cnt = 1;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Tuesday")
            {
                int cnt = 2;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Wednesday")
            {
                int cnt = 3;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Thursday")
            {
                int cnt = 4;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Friday")
            {
                int cnt = 5;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Saturday")
            {
                int cnt = 6;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            int c = 0;
            int num = 1;

            week = new FlowLayoutPanel();
            week.Height = 41;
            week.Width = 580;
            week.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            week.Margin = new Padding(0, 5, 0, 0);
            week.Name = "panel_week" + (num);
            week.Click += week_Click;

            for (i = 0; i<pdays.Length; i++)
            {
                day = new Label();
                day.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                day.AutoSize = false;
                day.TextAlign = ContentAlignment.MiddleCenter;
                day.Width = 63;
                day.Height = 39;
                day.Font = new Font("Sans Serif", 20);
                day.Text = pdays[i];
                day.Margin = new Padding(0, 0, 19, 0);
                day.ForeColor = System.Drawing.Color.Gray;
                day.Click += day_Click;
                if (c == 6)
                {
                    week.Controls.Add(day);
                    dates_layout.Controls.Add(week);
                    num++;
                    c = 0;
                    week = new FlowLayoutPanel();
                    week.Height = 41;
                    week.Width = 580;
                    week.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    week.Margin = new Padding(0, 5, 0, 0);
                    week.Name = "panel_week" + (num);
                    week.Click += week_Click;
                }
                else
                {
                    week.Controls.Add(day);
                    c++;
                }
            }

            foreach (string s in daysnum)
            {
                day = new Label();
                day.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                day.AutoSize = false;
                day.TextAlign = ContentAlignment.MiddleCenter;
                day.Width = 63;
                day.Height = 39;
                day.Font = new Font("Sans Serif", 20);
                day.Text = s;
                day.Margin = new Padding(0, 0, 19, 0);
                day.Click += day_Click;
                if (c == 6)
                {
                    week.Controls.Add(day);
                    dates_layout.Controls.Add(week);
                    num++;
                    c = 0;
                    week = new FlowLayoutPanel();
                    week.Height = 41;
                    week.Width = 580;
                    week.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    week.Margin = new Padding(0, 5, 0, 0);
                    week.Name = "panel_week" + (num);
                    week.Click += week_Click;
                }
                else
                {
                    week.Controls.Add(day);
                    c++;
                }
            }

            for (i = 0; i < fdays.Length; i++)
            {
                day = new Label();
                day.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                day.AutoSize = false;
                day.TextAlign = ContentAlignment.MiddleCenter;
                day.Width = 63;
                day.Height = 39;
                day.Font = new Font("Sans Serif", 20);
                day.Text = fdays[i];
                day.Margin = new Padding(0, 0, 19, 0);
                day.ForeColor = System.Drawing.Color.Gray;
                day.Click += day_Click;
                if (c == 6)
                {
                    week.Controls.Add(day);
                    dates_layout.Controls.Add(week);
                    num++;
                    c = 0;
                    week = new FlowLayoutPanel();
                    week.Height = 41;
                    week.Width = 580;
                    week.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    week.Margin = new Padding(0, 5, 0, 0);
                    week.Name = "panel_week" + (num);
                    week.Click += week_Click;
                }
                else
                {
                    week.Controls.Add(day);
                    c++;
                }
            }
            //var message = string.Join(Environment.NewLine, daysnum);
            //MessageBox.Show(message);
        }

        public static List<DateTime> GetDates(int year, int month)
        {
            var dates = new List<DateTime>();

            // Loop from the first day of the month until we hit the next month, moving forward a day at a time
            for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                dates.Add(date);
            }

            return dates;
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            string m = "";
            string y = "";
            string n = lbl_monthyr.Text.Substring(0, lbl_monthyr.Text.IndexOf(" "));
            DateTime myDate = DateTime.ParseExact(n, "MMMM", System.Globalization.CultureInfo.InvariantCulture);
            string n2 = lbl_monthyr.Text.Remove(0, lbl_monthyr.Text.IndexOf(' ') + 1);
            DateTime myDate2 = DateTime.ParseExact(n2, "yyyy", System.Globalization.CultureInfo.InvariantCulture);

            if (myDate.ToString("MMMM") == "November" && myDate2.Year.ToString() == "2099")
                btn_right.Enabled = false;

            if (myDate.ToString("MMMM") == "January" && myDate2.Year.ToString() == "2019")
                btn_left.Enabled = true;

            if (myDate.ToString("MMMM") == "December")
            {
                lbl_monthyr.Text = myDate.AddMonths(1).ToString("MMMM") + " " + myDate2.AddYears(1).ToString("yyyy");
                m = myDate.AddMonths(1).ToString("MM");
                y = myDate2.AddYears(1).ToString("yyyy");
            }
            else
            {
                lbl_monthyr.Text = myDate.AddMonths(1).ToString("MMMM") + " " + myDate2.Year.ToString();
                m = myDate.AddMonths(1).ToString("MM");
                y = myDate2.Year.ToString();
            }

            //MessageBox.Show(m +" "+ y);
            List<DateTime> lt = new List<DateTime>();
            lt = GetDates(Convert.ToInt32(y), Convert.ToInt32(m));
            List<String> daysname = new List<String>();
            List<String> daysnum = new List<String>();
            foreach (DateTime d in lt)
            {
                daysname.Add(d.ToString("dddd"));
                List<String> temp = new List<String>();
                temp.Add(d.ToString("d"));
                List<String> temp2 = new List<String>();
                foreach (string s in temp)
                {
                    temp2.Add(s.Split('/')[0]);
                }
                foreach (string s in temp2)
                {
                    daysnum.Add(s.TrimStart(new Char[] { '0' }));
                }
            }

            //GET PAST DATES
            m = myDate.ToString("MM");
            y = myDate2.Year.ToString();

            List<DateTime> lt2 = new List<DateTime>();
            lt2 = GetDates(Convert.ToInt32(y), Convert.ToInt32(m));
            List<String> daysname2 = new List<String>();
            List<String> daysnum2 = new List<String>();
            foreach (DateTime d in lt2)
            {
                daysname2.Add(d.ToString("dddd"));
                List<String> temp = new List<String>();
                temp.Add(d.ToString("d"));
                List<String> temp2 = new List<String>();
                foreach (string s in temp)
                {
                    temp2.Add(s.Split('/')[0]);
                }
                foreach (string s in temp2)
                {
                    daysnum2.Add(s.TrimStart(new Char[] { '0' }));
                }
            }
            //END OF GET PAST DATES

            //GET FUTURE DATES
            m = myDate.AddMonths(+1).ToString("MM");
            y = myDate2.Year.ToString();

            List<DateTime> lt3 = new List<DateTime>();
            lt3 = GetDates(Convert.ToInt32(y), Convert.ToInt32(m));
            List<String> daysname3 = new List<String>();
            List<String> daysnum3 = new List<String>();
            foreach (DateTime d in lt3)
            {
                daysname3.Add(d.ToString("dddd"));
                List<String> temp = new List<String>();
                temp.Add(d.ToString("d"));
                List<String> temp2 = new List<String>();
                foreach (string s in temp)
                {
                    temp2.Add(s.Split('/')[0]);
                }
                foreach (string s in temp2)
                {
                    daysnum3.Add(s.TrimStart(new Char[] { '0' }));
                }
            }
            //END OF GET FUTURE DATES

            string[] dnum = daysnum.ToArray();
            string[] dname = daysname.ToArray();
            string[] dnum2 = daysnum2.ToArray();
            string[] dname2 = daysname2.ToArray();
            string[] dnum3 = daysnum3.ToArray();
            string[] dname3 = daysname3.ToArray();

            int i = 0;
            string[] pdays = new string[10];
            string[] fdays = new string[10];
            if (daysname.First() == "Sunday")
            {
                int cnt = 0;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Monday")
            {
                int cnt = 1;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Tuesday")
            {
                int cnt = 2;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Wednesday")
            {
                int cnt = 3;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Thursday")
            {
                int cnt = 4;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Friday")
            {
                int cnt = 5;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Saturday")
            {
                int cnt = 6;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }

            dates_layout.Controls.Clear();
            int c = 0;
            int num = 1;

            week = new FlowLayoutPanel();
            week.Height = 41;
            week.Width = 580;
            week.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            week.Margin = new Padding(0, 5, 0, 0);
            week.Name = "panel_week" + (num);
            week.Click += week_Click;

            for (i = 0; i < pdays.Length; i++)
            {
                day = new Label();
                day.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                day.AutoSize = false;
                day.TextAlign = ContentAlignment.MiddleCenter;
                day.Width = 63;
                day.Height = 39;
                day.Font = new Font("Sans Serif", 20);
                day.Text = pdays[i];
                day.Margin = new Padding(0, 0, 19, 0);
                day.ForeColor = System.Drawing.Color.Gray;
                day.Click += day_Click;
                if (c == 6)
                {
                    week.Controls.Add(day);
                    dates_layout.Controls.Add(week);
                    num++;
                    c = 0;
                    week = new FlowLayoutPanel();
                    week.Height = 41;
                    week.Width = 580;
                    week.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    week.Margin = new Padding(0, 5, 0, 0);
                    week.Name = "panel_week" + (num);
                    week.Click += week_Click;
                }
                else
                {
                    week.Controls.Add(day);
                    c++;
                }
            }

            foreach (string s in daysnum)
            {
                day = new Label();
                day.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                day.AutoSize = false;
                day.TextAlign = ContentAlignment.MiddleCenter;
                day.Width = 63;
                day.Height = 39;
                day.Font = new Font("Sans Serif", 20);
                day.Text = s;
                day.Margin = new Padding(0, 0, 19, 0);
                day.Click += day_Click;
                if (c == 6)
                {
                    week.Controls.Add(day);
                    dates_layout.Controls.Add(week);
                    num++;
                    c = 0;
                    week = new FlowLayoutPanel();
                    week.Height = 41;
                    week.Width = 580;
                    week.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    week.Margin = new Padding(0, 5, 0, 0);
                    week.Name = "panel_week" + (num);
                    week.Click += week_Click;
                }
                else
                {
                    week.Controls.Add(day);
                    c++;
                }
            }

            for (i = 0; i < fdays.Length; i++)
            {
                day = new Label();
                day.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                day.AutoSize = false;
                day.TextAlign = ContentAlignment.MiddleCenter;
                day.Width = 63;
                day.Height = 39;
                day.Font = new Font("Sans Serif", 20);
                day.Text = fdays[i];
                day.Margin = new Padding(0, 0, 19, 0);
                day.ForeColor = System.Drawing.Color.Gray;
                day.Click += day_Click;
                if (c == 6)
                {
                    week.Controls.Add(day);
                    dates_layout.Controls.Add(week);
                    num++;
                    c = 0;
                    week = new FlowLayoutPanel();
                    week.Height = 41;
                    week.Width = 580;
                    week.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    week.Margin = new Padding(0, 5, 0, 0);
                    week.Name = "panel_week" + (num);
                    week.Click += week_Click;
                }
                else
                {
                    week.Controls.Add(day);
                    c++;
                }
            }
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            string m = "";
            string y = "";
            string n = lbl_monthyr.Text.Substring(0, lbl_monthyr.Text.IndexOf(" "));
            DateTime myDate = DateTime.ParseExact(n, "MMMM", System.Globalization.CultureInfo.InvariantCulture);
            string n2 = lbl_monthyr.Text.Remove(0, lbl_monthyr.Text.IndexOf(' ') + 1);
            DateTime myDate2 = DateTime.ParseExact(n2, "yyyy", System.Globalization.CultureInfo.InvariantCulture);

            if (myDate.ToString("MMMM") == "December" && myDate2.Year.ToString() == "2099")
                btn_right.Enabled = true;

            if (myDate.ToString("MMMM") == "February" && myDate2.Year.ToString() == "2019")
                btn_left.Enabled = false;

            if (myDate.ToString("MMMM") == "January")
            {
                lbl_monthyr.Text = myDate.AddMonths(-1).ToString("MMMM") + " " + myDate2.AddYears(-1).ToString("yyyy");
                m = myDate.AddMonths(-1).ToString("MM");
                y = myDate2.AddYears(-1).ToString("yyyy");
            }
            else
            {
                lbl_monthyr.Text = myDate.AddMonths(-1).ToString("MMMM") + " " + myDate2.Year.ToString();
                m = myDate.AddMonths(-1).ToString("MM");
                y = myDate2.Year.ToString();
            }

            //MessageBox.Show(m + " " + y);
            List<DateTime> lt = new List<DateTime>();
            lt = GetDates(Convert.ToInt32(y), Convert.ToInt32(m));
            List<String> daysname = new List<String>();
            List<String> daysnum = new List<String>();
            foreach (DateTime d in lt)
            {
                daysname.Add(d.ToString("dddd"));
                List<String> temp = new List<String>();
                temp.Add(d.ToString("d"));
                List<String> temp2 = new List<String>();
                foreach (string s in temp)
                {
                    temp2.Add(s.Split('/')[0]);
                }
                foreach (string s in temp2)
                {
                    daysnum.Add(s.TrimStart(new Char[] { '0' }));
                }
            }

            //GET PAST DATES
            m = myDate.AddMonths(-2).ToString("MM");
            y = myDate2.Year.ToString();

            List<DateTime> lt2 = new List<DateTime>();
            lt2 = GetDates(Convert.ToInt32(y), Convert.ToInt32(m));
            List<String> daysname2 = new List<String>();
            List<String> daysnum2 = new List<String>();
            foreach (DateTime d in lt2)
            {
                daysname2.Add(d.ToString("dddd"));
                List<String> temp = new List<String>();
                temp.Add(d.ToString("d"));
                List<String> temp2 = new List<String>();
                foreach (string s in temp)
                {
                    temp2.Add(s.Split('/')[0]);
                }
                foreach (string s in temp2)
                {
                    daysnum2.Add(s.TrimStart(new Char[] { '0' }));
                }
            }
            //END OF GET PAST DATES

            //GET FUTURE DATES
            m = myDate.AddMonths(+1).ToString("MM");
            y = myDate2.Year.ToString();

            List<DateTime> lt3 = new List<DateTime>();
            lt3 = GetDates(Convert.ToInt32(y), Convert.ToInt32(m));
            List<String> daysname3 = new List<String>();
            List<String> daysnum3 = new List<String>();
            foreach (DateTime d in lt3)
            {
                daysname3.Add(d.ToString("dddd"));
                List<String> temp = new List<String>();
                temp.Add(d.ToString("d"));
                List<String> temp2 = new List<String>();
                foreach (string s in temp)
                {
                    temp2.Add(s.Split('/')[0]);
                }
                foreach (string s in temp2)
                {
                    daysnum3.Add(s.TrimStart(new Char[] { '0' }));
                }
            }
            //END OF GET FUTURE DATES

            string[] dnum = daysnum.ToArray();
            string[] dname = daysname.ToArray();
            string[] dnum2 = daysnum2.ToArray();
            string[] dname2 = daysname2.ToArray();
            string[] dnum3 = daysnum3.ToArray();
            string[] dname3 = daysname3.ToArray();

            int i = 0;
            string[] pdays = new string[10];
            string[] fdays = new string[10];
            if (daysname.First() == "Sunday")
            {
                int cnt = 0;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Monday")
            {
                int cnt = 1;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Tuesday")
            {
                int cnt = 2;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Wednesday")
            {
                int cnt = 3;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Thursday")
            {
                int cnt = 4;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Friday")
            {
                int cnt = 5;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }
            else if (daysname.First() == "Saturday")
            {
                int cnt = 6;

                for (i = 0; i < cnt; i++)
                {
                    pdays[i] = dnum2[dnum2.Length - (i + 1)];
                }
                pdays = pdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Reverse(pdays, 0, pdays.Length);

                if (daysname.Last() == "Sunday")
                {
                    int cnt2 = 6;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Monday")
                {
                    int cnt2 = 5;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Tuesday")
                {
                    int cnt2 = 4;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Wednesday")
                {
                    int cnt2 = 3;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Thursday")
                {
                    int cnt2 = 2;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Friday")
                {
                    int cnt2 = 1;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else if (daysname.Last() == "Saturday")
                {
                    int cnt2 = 0;

                    for (i = 0; i < cnt2; i++)
                    {
                        fdays[i] = dnum3[i];
                    }
                    fdays = fdays.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
            }

            dates_layout.Controls.Clear();
            int c = 0;
            int num = 1;

            week = new FlowLayoutPanel();
            week.Height = 41;
            week.Width = 580;
            week.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            week.Margin = new Padding(0, 5, 0, 0);
            week.Name = "panel_week" + (num);
            week.Click += week_Click;

            for (i = 0; i < pdays.Length; i++)
            {
                day = new Label();
                day.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                day.AutoSize = false;
                day.TextAlign = ContentAlignment.MiddleCenter;
                day.Width = 63;
                day.Height = 39;
                day.Font = new Font("Sans Serif", 20);
                day.Text = pdays[i];
                day.Margin = new Padding(0, 0, 19, 0);
                day.ForeColor = System.Drawing.Color.Gray;
                day.Click += day_Click;
                if (c == 6)
                {
                    week.Controls.Add(day);
                    dates_layout.Controls.Add(week);
                    num++;
                    c = 0;
                    week = new FlowLayoutPanel();
                    week.Height = 41;
                    week.Width = 580;
                    week.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    week.Margin = new Padding(0, 5, 0, 0);
                    week.Name = "panel_week" + (num);
                    week.Click += week_Click;
                }
                else
                {
                    week.Controls.Add(day);
                    c++;
                }
            }

            foreach (string s in daysnum)
            {
                day = new Label();
                day.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                day.AutoSize = false;
                day.TextAlign = ContentAlignment.MiddleCenter;
                day.Width = 63;
                day.Height = 39;
                day.Font = new Font("Sans Serif", 20);
                day.Text = s;
                day.Margin = new Padding(0, 0, 19, 0);
                day.Click += day_Click;
                if (c == 6)
                {
                    week.Controls.Add(day);
                    dates_layout.Controls.Add(week);
                    num++;
                    c = 0;
                    week = new FlowLayoutPanel();
                    week.Height = 41;
                    week.Width = 580;
                    week.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    week.Margin = new Padding(0, 5, 0, 0);
                    week.Name = "panel_week" + (num);
                    week.Click += week_Click;
                }
                else
                {
                    week.Controls.Add(day);
                    c++;
                }
            }

            for (i = 0; i < fdays.Length; i++)
            {
                day = new Label();
                day.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                day.AutoSize = false;
                day.TextAlign = ContentAlignment.MiddleCenter;
                day.Width = 63;
                day.Height = 39;
                day.Font = new Font("Sans Serif", 20);
                day.Text = fdays[i];
                day.Margin = new Padding(0, 0, 19, 0);
                day.ForeColor = System.Drawing.Color.Gray;
                day.Click += day_Click;
                if (c == 6)
                {
                    week.Controls.Add(day);
                    dates_layout.Controls.Add(week);
                    num++;
                    c = 0;
                    week = new FlowLayoutPanel();
                    week.Height = 41;
                    week.Width = 580;
                    week.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    week.Margin = new Padding(0, 5, 0, 0);
                    week.Name = "panel_week" + (num);
                    week.Click += week_Click;
                }
                else
                {
                    week.Controls.Add(day);
                    c++;
                }
            }
        }

        private string _date;
        void day_Click(object sender, EventArgs e)
        {
            if(Sen == "btn_seldate")
            {
                Label theLabel = (Label)sender;
                string day = theLabel.Text;
                if (Convert.ToInt32(day) < 10)
                {
                    day = "0" + day;
                }
                string monthyr = lbl_monthyr.Text;
                string[] split = monthyr.Split(' ');
                string month = "";
                if ((Convert.ToDateTime("01-" + split[0] + "-2011").Month) > 9)
                {
                    month = (Convert.ToDateTime("01-" + split[0] + "-2011").Month).ToString();
                }
                else
                {
                    month = "0" + (Convert.ToDateTime("01-" + split[0] + "-2011").Month).ToString();
                }
                string year = split[1];

                if (theLabel.ForeColor == System.Drawing.Color.Gray)
                {
                    if (Convert.ToInt32(theLabel.Text) < 10)
                    {
                        DateTime myDate = DateTime.Parse("1." + split[0] + " 2008");
                        month = myDate.AddMonths(+1).ToString("MM");
                        if (month == "01")
                        {
                            year = (Convert.ToInt32(year) + 1).ToString();
                        }
                    }
                    else if (Convert.ToInt32(theLabel.Text) > 20)
                    {
                        DateTime myDate = DateTime.Parse("1." + split[0] + " 2008");
                        month = myDate.AddMonths(-1).ToString("MM");
                        if (month == "12")
                        {
                            year = (Convert.ToInt32(year) - 1).ToString();
                        }
                    }
                }

                string date = day + "/" + month + "/" + year;
                Date = date;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else if(Sen == "btn_seldate2")
            {
                this.week_Click(sender, e);
            }
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private string _sen;
        public string Sen
        {
            get { return _sen; }
            set { _sen = value; }
        }

        void week_Click(object sender, EventArgs e)
        {
            Control check = (Control)sender;
            string panel_name = "";
            if (check is Label)
            {
                string parent_name = ((Label)sender).Parent.Name;
                panel_name = parent_name;
            }
            else if (check is FlowLayoutPanel)
            {
                string name = ((FlowLayoutPanel)sender).Name;
                panel_name = name;
            }

            FlowLayoutPanel p = new FlowLayoutPanel();
            foreach (Control c in dates_layout.Controls)
            {
                p = (dates_layout.Controls.Find(panel_name, true).First() as FlowLayoutPanel);
            }

            List<String> days = new List<String>();
            foreach(Control c in p.Controls)
            {
                if(c is Label)
                {
                    string monthyr = lbl_monthyr.Text;
                    string[] split = monthyr.Split(' ');
                    string month = "";
                    if ((Convert.ToDateTime("01-" + split[0] + "-2011").Month) > 9)
                    {
                        month = (Convert.ToDateTime("01-" + split[0] + "-2011").Month).ToString();
                    }
                    else
                    {
                        month = "0" + (Convert.ToDateTime("01-" + split[0] + "-2011").Month).ToString();
                    }
                    string year = split[1];

                    string d = "";
                    d = ((Label)c).Text;
                    if (Convert.ToInt32(d) < 10)
                    {
                        d = "0" + d;
                    }
                    if (((Label)c).ForeColor == System.Drawing.Color.Gray)
                    {
                        if (Convert.ToInt32(((Label)c).Text) < 10)
                        {
                            DateTime myDate = DateTime.Parse("1." + split[0] + " 2008");
                            month = myDate.AddMonths(1).ToString("MM");
                            if (month == "01")
                            {
                                year = (Convert.ToInt32(year) + 1).ToString();
                            }
                        }
                        else if (Convert.ToInt32(((Label)c).Text) > 20)
                        {
                            DateTime myDate = DateTime.Parse("1." + split[0] + " 2008");
                            month = myDate.AddMonths(-1).ToString("MM");
                            if (month == "12")
                            {
                                year = (Convert.ToInt32(year) - 1).ToString();
                            }
                        }
                    }
                    string date = d + "/" + month + "/" + year;
                    days.Add(date);
                }
            }

            var message = string.Join(",", days);
            string weekdays = message;
            WeekDays = weekdays;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private string _wd;
        public string WeekDays
        {
            get { return _wd; }
            set { _wd = value; }
        }
    }
}
