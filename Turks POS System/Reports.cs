using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text.RegularExpressions;

namespace Turks_POS_System
{
    public partial class Reports : UserControl
    {
        public SQLiteConnection myConnection;
        Items_inv_Pita inv_pita = new Items_inv_Pita();
        Cash_Dem cash_dem = new Cash_Dem();
        private string d;
        private string datesel;
        private string weeksel;

        public Reports()
        {
            InitializeComponent();
            tab_daily.BackColor = SystemColors.Control;
            btn_update.Visible = false;
            lbl_none.Visible = false;
            btn_create.Visible = false;

            panel_daily.Visible = true;
            panel_weekly.Visible = false;
            panel_monthly.Visible = false;
            panel_yearly.Visible = false;
            
            btn_seldate.Visible = false;
            btn_seldate2.Visible = false;
            panel_dailysalesreport.Visible = false;
            panel_dailygraphs.Visible = false;
            panel_weeklygraphs.Visible = false;
            panel_monthlygraphs.Visible = false;
            panel_yearlygraphs.Visible = false;

            monthly_cbmonth.Visible = false;
            monthly_cbyear.Visible = false;

            yearly_cbyear.Visible = false;

            //dispTbl();
        }

        private void tab_daily_Click(object sender, EventArgs e)
        {
            tab_daily.BackColor = SystemColors.Control;
            tab_weekly.BackColor = SystemColors.ActiveBorder;
            tab_monthly.BackColor = SystemColors.ActiveBorder;
            tab_yearly.BackColor = SystemColors.ActiveBorder;

            panel_daily.Visible = true;
            panel_weekly.Visible = false;
            panel_monthly.Visible = false;
            panel_yearly.Visible = false;

            panel_dailysalesreport.Visible = false;
            panel_dailygraphs.Visible = false;
            panel_weeklygraphs.Visible = false;
            panel_monthlygraphs.Visible = false;
            panel_yearlygraphs.Visible = false;

            items_inv_layout.Controls.Clear();
            cash_dem_layout.Controls.Clear();

            daily_graphs.BackColor = SystemColors.ActiveBorder;
            daily_salesreport.BackColor = SystemColors.ActiveBorder;
            weekly_graphs.BackColor = SystemColors.ActiveBorder;
            monthly_graphs.BackColor = SystemColors.ActiveBorder;
            yearly_graphs.BackColor = SystemColors.ActiveBorder;

            monthly_cbmonth.Visible = false;
            monthly_cbyear.Visible = false;

            yearly_cbyear.Visible = false;
        }

        private void tab_weekly_Click(object sender, EventArgs e)
        {
            btn_seldate.Visible = false;
            btn_seldate2.Visible = false;

            tab_daily.BackColor = SystemColors.ActiveBorder;
            tab_weekly.BackColor = SystemColors.Control;
            tab_monthly.BackColor = SystemColors.ActiveBorder;
            tab_yearly.BackColor = SystemColors.ActiveBorder;

            panel_daily.Visible = false;
            panel_weekly.Visible = true;
            panel_monthly.Visible = false;
            panel_yearly.Visible = false;

            btn_update.Visible = false;
            lbl_none.Visible = false;
            btn_create.Visible = false;

            panel_dailysalesreport.Visible = false;
            panel_dailygraphs.Visible = false;
            panel_weeklygraphs.Visible = false;
            panel_monthlygraphs.Visible = false;
            panel_yearlygraphs.Visible = false;

            daily_graphs.BackColor = SystemColors.ActiveBorder;
            daily_salesreport.BackColor = SystemColors.ActiveBorder;
            weekly_graphs.BackColor = SystemColors.ActiveBorder;
            monthly_graphs.BackColor = SystemColors.ActiveBorder;
            yearly_graphs.BackColor = SystemColors.ActiveBorder;

            monthly_cbmonth.Visible = false;
            monthly_cbyear.Visible = false;

            yearly_cbyear.Visible = false;
        }

        private void tab_monthly_Click(object sender, EventArgs e)
        {
            btn_seldate.Visible = false;
            btn_seldate2.Visible = false;

            tab_daily.BackColor = SystemColors.ActiveBorder;
            tab_weekly.BackColor = SystemColors.ActiveBorder;
            tab_monthly.BackColor = SystemColors.Control;
            tab_yearly.BackColor = SystemColors.ActiveBorder;

            panel_daily.Visible = false;
            panel_weekly.Visible = false;
            panel_monthly.Visible = true;
            panel_yearly.Visible = false;

            btn_update.Visible = false;
            lbl_none.Visible = false;
            btn_create.Visible = false;

            panel_dailysalesreport.Visible = false;
            panel_dailygraphs.Visible = false;
            panel_weeklygraphs.Visible = false;
            panel_monthlygraphs.Visible = false;
            panel_yearlygraphs.Visible = false;

            daily_graphs.BackColor = SystemColors.ActiveBorder;
            daily_salesreport.BackColor = SystemColors.ActiveBorder;
            weekly_graphs.BackColor = SystemColors.ActiveBorder;
            monthly_graphs.BackColor = SystemColors.ActiveBorder;
            yearly_graphs.BackColor = SystemColors.ActiveBorder;

            monthly_cbmonth.Visible = false;
            monthly_cbyear.Visible = false;

            yearly_cbyear.Visible = false;
        }

        private void tab_yearly_Click(object sender, EventArgs e)
        {
            btn_seldate.Visible = false;
            btn_seldate2.Visible = false;

            tab_daily.BackColor = SystemColors.ActiveBorder;
            tab_weekly.BackColor = SystemColors.ActiveBorder;
            tab_monthly.BackColor = SystemColors.ActiveBorder;
            tab_yearly.BackColor = SystemColors.Control;

            panel_daily.Visible = false;
            panel_weekly.Visible = false;
            panel_monthly.Visible = false;
            panel_yearly.Visible = true;

            btn_update.Visible = false;
            lbl_none.Visible = false;
            btn_create.Visible = false;

            panel_dailysalesreport.Visible = false;
            panel_dailygraphs.Visible = false;
            panel_weeklygraphs.Visible = false;
            panel_monthlygraphs.Visible = false;
            panel_yearlygraphs.Visible = false;

            daily_graphs.BackColor = SystemColors.ActiveBorder;
            daily_salesreport.BackColor = SystemColors.ActiveBorder;
            weekly_graphs.BackColor = SystemColors.ActiveBorder;
            monthly_graphs.BackColor = SystemColors.ActiveBorder;
            yearly_graphs.BackColor = SystemColors.ActiveBorder;

            monthly_cbmonth.Visible = false;
            monthly_cbyear.Visible = false;

            yearly_cbyear.Visible = false;
        }

        private void daily_salesreport_Click(object sender, EventArgs e)
        {
            daily_graphs.BackColor = SystemColors.ActiveBorder;
            daily_salesreport.BackColor = SystemColors.Control;
            btn_seldate.Visible = true;
            btn_seldate2.Visible = false;
            panel_dailysalesreport.Visible = true;
            panel_dailygraphs.Visible = false;
            panel_weeklygraphs.Visible = false;
            panel_monthlygraphs.Visible = false;
            panel_yearlygraphs.Visible = false;

            monthly_cbmonth.Visible = false;
            monthly_cbyear.Visible = false;

            yearly_cbyear.Visible = false;
        }

        private void daily_graphs_Click(object sender, EventArgs e)
        {
            daily_graphs.BackColor = SystemColors.Control;
            daily_salesreport.BackColor = SystemColors.ActiveBorder;
            btn_seldate.Visible = true;
            btn_seldate2.Visible = false;
            panel_dailysalesreport.Visible = false;
            panel_dailygraphs.Visible = true;
            panel_weeklygraphs.Visible = false;
            panel_monthlygraphs.Visible = false;
            panel_yearlygraphs.Visible = false;

            monthly_cbmonth.Visible = false;
            monthly_cbyear.Visible = false;

            yearly_cbyear.Visible = false;
        }

        private void weekly_graphs_Click(object sender, EventArgs e)
        {
            weekly_graphs.BackColor = SystemColors.Control;
            btn_seldate.Visible = false;
            btn_seldate2.Visible = true;
            panel_dailygraphs.Visible = false;
            panel_weeklygraphs.Visible = true;
            panel_monthlygraphs.Visible = false;
            panel_yearlygraphs.Visible = false;

            monthly_cbmonth.Visible = false;
            monthly_cbyear.Visible = false;

            yearly_cbyear.Visible = false;
        }

        private void monthly_graphs_Click(object sender, EventArgs e)
        {
            monthly_graphs.BackColor = SystemColors.Control;
            btn_seldate.Visible = false;
            btn_seldate2.Visible = false;
            panel_dailygraphs.Visible = false;
            panel_weeklygraphs.Visible = false;
            panel_monthlygraphs.Visible = true;
            panel_yearlygraphs.Visible = false;

            monthly_cbmonth.Visible = false;
            monthly_cbyear.Visible = true;

            yearly_cbyear.Visible = false;

            System.Object[] ItemObject = new System.Object[81];
            for (int i = 0; i < ItemObject.Length; i++)
            {
                ItemObject[i] = (2019 + i).ToString();
            }
            monthly_cbyear.Items.AddRange(ItemObject);
        }

        private void yearly_graphs_Click(object sender, EventArgs e)
        {
            yearly_graphs.BackColor = SystemColors.Control;
            btn_seldate.Visible = false;
            btn_seldate2.Visible = false;
            panel_dailygraphs.Visible = false;
            panel_weeklygraphs.Visible = false;
            panel_monthlygraphs.Visible = false;
            panel_yearlygraphs.Visible = true;

            monthly_cbmonth.Visible = false;
            monthly_cbyear.Visible = false;

            yearly_cbyear.Visible = true;

            System.Object[] ItemObject = new System.Object[81];
            for (int i = 0; i < ItemObject.Length; i++)
            {
                ItemObject[i] = (2019 + i).ToString();
            }
            yearly_cbyear.Items.AddRange(ItemObject);
        }

        public void dispRep()
        {
            string date = datesel;
            d = date;
            items_inv_layout.Controls.Clear();
            cash_dem_layout.Controls.Clear();

            string amtbpd = "";
            string amtcpd = "";
            string amtkw = "";
            string amthw = "";
            string amtbpdwd = "";
            string amtcpdwd = "";
            string amtkwwd = "";
            string amthwwd = "";
            string amtbpdwfnd = "";
            string amtcpdwfnd = "";
            string amtkwwfnd = "";
            string amthwwfnd = "";
            string amtbdor = "";
            string amtcdor = "";
            string amtkor = "";
            string amthr = "";
            string amtbdorwd = "";
            string amtcdorwd = "";
            string amtkorwd = "";
            string amthrwd = "";
            string amtbds = "";
            string amtcds = "";
            string amtbdswd = "";
            string amtcdswd = "";
            string amtbcp = "";
            string amtbkp = "";
            string amtckp = "";
            string amtbcpwd = "";
            string amtbkpwd = "";
            string amtckpwd = "";
            string amtcheeseout = "";
            string amtgsauceout = "";
            string amtcsauceout = "";
            string amthsauceout = "";
            string amtlemonadeout = "";
            string amtnesteaout = "";
            string amtwaterout = "";
            string amtsodaout = "";
            string amtturksfriesout = "";
            string amtextrariceout = "";

            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            string qry = "SELECT * FROM tbl_transactions WHERE date = '" + date + "'";
            string qry2 = "SELECT COUNT(*) FROM tbl_transactions WHERE date = '" + date + "'";
            SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
            SQLiteCommand myCommand2 = new SQLiteCommand(qry2, myConnection);

            openConnection();
            SQLiteDataReader result = myCommand.ExecuteReader();
            int check = Convert.ToInt32(myCommand2.ExecuteScalar());

            btn_update.Visible = true;
            lbl_none.Visible = false;
            btn_create.Visible = false;
            string reported = "";
            string bpd = "";
            string cpd = "";
            string kw = "";
            string hw = "";
            string bpdwd = "";
            string cpdwd = "";
            string kwwd = "";
            string hwwd = "";
            string bpdwfnd = "";
            string cpdwfnd = "";
            string kwwfnd = "";
            string hwwfnd = "";
            string bdor = "";
            string cdor = "";
            string kor = "";
            string hr = "";
            string bdorwd = "";
            string cdorwd = "";
            string korwd = "";
            string hrwd = "";
            string bds = "";
            string cds = "";
            string bdswd = "";
            string cdswd = "";
            string bcp = "";
            string bkp = "";
            string ckp = "";
            string bcpwd = "";
            string bkpwd = "";
            string ckpwd = "";
            string pitaout = "";
            string riceout = "";
            string kebabout = "";
            string mealboxout = "";
            string beefout = "";
            string chickenout = "";
            string hotdogout = "";
            string bsteakout = "";
            string csteakout = "";
            string platterboxout = "";
            string minipitaout = "";
            string friesbagsout = "";
            string minicupsout = "";
            string conesout = "";
            string cupsout = "";
            string cheeseout = "";
            string gsauceout = "";
            string csauceout = "";
            string hsauceout = "";
            string lemonadeout = "";
            string nesteaout = "";
            string waterout = "";
            string sodaout = "";
            string turksfriesout = "";
            string extrariceout = "";
            if (result.HasRows)
            {
                while (result.Read())
                {
                    reported = result["reported"].ToString();
                    bpd = result["bpd"].ToString();
                    cpd = result["cpd"].ToString();
                    kw = result["kw"].ToString();
                    hw = result["hw"].ToString();
                    bpdwd = result["bpdwd"].ToString();
                    cpdwd = result["cpdwd"].ToString();
                    kwwd = result["kwwd"].ToString();
                    hwwd = result["hwwd"].ToString();
                    bpdwfnd = result["bpdwfnd"].ToString();
                    cpdwfnd = result["cpdwfnd"].ToString();
                    kwwfnd = result["kwwfnd"].ToString();
                    hwwfnd = result["hwwfnd"].ToString();
                    bdor = result["bdor"].ToString();
                    cdor = result["cdor"].ToString();
                    kor = result["kor"].ToString();
                    hr = result["hr"].ToString();
                    bdorwd = result["bdorwd"].ToString();
                    cdorwd = result["cdorwd"].ToString();
                    korwd = result["korwd"].ToString();
                    hrwd = result["hrwd"].ToString();
                    bds = result["bds"].ToString();
                    cds = result["cds"].ToString();
                    bdswd = result["bdswd"].ToString();
                    cdswd = result["cdswd"].ToString();
                    bcp = result["bcp"].ToString();
                    bkp = result["bkp"].ToString();
                    ckp = result["ckp"].ToString();
                    bcpwd = result["bcpwd"].ToString();
                    bkpwd = result["bkpwd"].ToString();
                    ckpwd = result["ckpwd"].ToString();
                    pitaout = result["pitaout"].ToString();
                    riceout = result["riceout"].ToString();
                    kebabout = result["kebabout"].ToString();
                    mealboxout = result["mealboxout"].ToString();
                    beefout = result["beefout"].ToString();
                    hotdogout = result["hotdogout"].ToString();
                    bsteakout = result["bsteakout"].ToString();
                    csteakout = result["csteakout"].ToString();
                    platterboxout = result["platterboxout"].ToString();
                    minipitaout = result["minipitaout"].ToString();
                    friesbagsout = result["friesbagsout"].ToString();
                    minicupsout = result["minicupsout"].ToString();
                    conesout = result["conesout"].ToString();
                    cupsout = result["cupsout"].ToString();
                    cheeseout = result["cheeseout"].ToString();
                    gsauceout = result["gsauceout"].ToString();
                    csauceout = result["csauceout"].ToString();
                    hsauceout = result["hsauceout"].ToString();
                    lemonadeout = result["lemonadeout"].ToString();
                    nesteaout = result["nesteaout"].ToString();
                    waterout = result["waterout"].ToString();
                    sodaout = result["sodaout"].ToString();
                    turksfriesout = result["turksfriesout"].ToString();
                    extrariceout = result["extrariceout"].ToString();
                }
            }

            if (check != 0 && reported == "reported")
            {
                amtbpd = (Convert.ToInt32(bpd) * 60).ToString();
                amtcpd = (Convert.ToInt32(cpd) * 60).ToString();
                amtkw = (Convert.ToInt32(kw) * 60).ToString();
                amthw = (Convert.ToInt32(hw) * 60).ToString();
                amtbpdwd = (Convert.ToInt32(bpdwd) * 80).ToString();
                amtcpdwd = (Convert.ToInt32(cpdwd) * 80).ToString();
                amtkwwd = (Convert.ToInt32(kwwd) * 80).ToString();
                amthwwd = (Convert.ToInt32(hwwd) * 80).ToString();
                amtbpdwfnd = (Convert.ToInt32(bpdwfnd) * 110).ToString();
                amtcpdwfnd = (Convert.ToInt32(cpdwfnd) * 110).ToString();
                amtkwwfnd = (Convert.ToInt32(kwwfnd) * 110).ToString();
                amthwwfnd = (Convert.ToInt32(hwwfnd) * 110).ToString();
                amtbdor = (Convert.ToInt32(bdor) * 99).ToString();
                amtcdor = (Convert.ToInt32(cdor) * 99).ToString();
                amtkor = (Convert.ToInt32(kor) * 99).ToString();
                amthr = (Convert.ToInt32(hr) * 99).ToString();
                amtbdorwd = (Convert.ToInt32(bdorwd) * 119).ToString();
                amtcdorwd = (Convert.ToInt32(cdorwd) * 119).ToString();
                amtkorwd = (Convert.ToInt32(korwd) * 119).ToString();
                amthrwd = (Convert.ToInt32(hrwd) * 119).ToString();
                amtbds = (Convert.ToInt32(bds) * 185).ToString();
                amtcds = (Convert.ToInt32(cds) * 145).ToString();
                amtbdswd = (Convert.ToInt32(bdswd) * 205).ToString();
                amtcdswd = (Convert.ToInt32(cdswd) * 165).ToString();
                amtbcp = (Convert.ToInt32(bcp) * 150).ToString();
                amtbkp = (Convert.ToInt32(bkp) * 150).ToString();
                amtckp = (Convert.ToInt32(ckp) * 150).ToString();
                amtbcpwd = (Convert.ToInt32(bcpwd) * 170).ToString();
                amtbkpwd = (Convert.ToInt32(bkpwd) * 170).ToString();
                amtckpwd = (Convert.ToInt32(ckpwd) * 170).ToString();
                amtcheeseout = (Convert.ToInt32(cheeseout) * 15).ToString();
                amtgsauceout = (Convert.ToInt32(gsauceout) * 10).ToString();
                amtcsauceout = (Convert.ToInt32(csauceout) * 10).ToString();
                amthsauceout = (Convert.ToInt32(hsauceout) * 10).ToString();
                amtlemonadeout = (Convert.ToInt32(lemonadeout) * 30).ToString();
                amtnesteaout = (Convert.ToInt32(nesteaout) * 30).ToString();
                amtwaterout = (Convert.ToInt32(waterout) * 20).ToString();
                amtsodaout = (Convert.ToInt32(sodaout) * 42).ToString();
                amtturksfriesout = (Convert.ToInt32(turksfriesout) * 40).ToString();
                amtextrariceout = (Convert.ToInt32(extrariceout) * 25).ToString();

                if (bpd == "0")
                {
                    inv_pita.lbl_pitaoutsolobeef.Text = "";
                    inv_pita.lbl_pitasoloamountbeef.Text = "";
                }
                else
                {
                    inv_pita.lbl_pitaoutsolobeef.Text = bpd;
                    inv_pita.lbl_pitasoloamountbeef.Text = amtbpd;
                }
                if (cpd == "0")
                {
                    inv_pita.lbl_pitaoutsolochicken.Text = "";
                    inv_pita.lbl_pitasoloamountchicken.Text = "";
                }
                else
                {
                    inv_pita.lbl_pitaoutsolochicken.Text = cpd;
                    inv_pita.lbl_pitasoloamountchicken.Text = amtcpd;
                }
                if (kw == "0")
                {
                    inv_pita.lbl_pitaoutsolokebab.Text = "";
                    inv_pita.lbl_pitasoloamountkebab.Text = "";
                }
                else
                {
                    inv_pita.lbl_pitaoutsolokebab.Text = kw;
                    inv_pita.lbl_pitasoloamountkebab.Text = amtkw;
                }
                if (hw == "0")
                {
                    inv_pita.lbl_pitaoutsolohotdog.Text = "";
                    inv_pita.lbl_pitasoloamounthotdog.Text = "";
                }
                else
                {
                    inv_pita.lbl_pitaoutsolohotdog.Text = hw;
                    inv_pita.lbl_pitasoloamounthotdog.Text = amthw;
                }
                if (bpdwd == "0")
                {
                    inv_pita.lbl_pitaoutduobeef.Text = "";
                    inv_pita.lbl_pitaduoamountbeef.Text = "";
                }
                else
                {
                    inv_pita.lbl_pitaoutduobeef.Text = bpdwd;
                    inv_pita.lbl_pitaduoamountbeef.Text = amtbpdwd;
                }
                if (cpdwd == "0")
                {
                    inv_pita.lbl_pitaoutduochicken.Text = "";
                    inv_pita.lbl_pitaduoamountchicken.Text = "";
                }
                else
                {
                    inv_pita.lbl_pitaoutduochicken.Text = cpdwd;
                    inv_pita.lbl_pitaduoamountchicken.Text = amtcpdwd;
                }
                if (kwwd == "0")
                {
                    inv_pita.lbl_pitaoutduokebab.Text = "";
                    inv_pita.lbl_pitaduoamountkebab.Text = "";
                }
                else
                {
                    inv_pita.lbl_pitaoutduokebab.Text = kwwd;
                    inv_pita.lbl_pitaduoamountkebab.Text = amtkwwd;
                }
                if (hwwd == "0")
                {
                    inv_pita.lbl_pitaoutduohotdog.Text = "";
                    inv_pita.lbl_pitaduoamounthotdog.Text = "";
                }
                else
                {
                    inv_pita.lbl_pitaoutduohotdog.Text = hwwd;
                    inv_pita.lbl_pitaduoamounthotdog.Text = amthwwd;
                }
                if (bpdwfnd == "0")
                {
                    inv_pita.lbl_pitaouttriobeef.Text = "";
                    inv_pita.lbl_pitatrioamountbeef.Text = "";
                }
                else
                {
                    inv_pita.lbl_pitaouttriobeef.Text = bpdwfnd;
                    inv_pita.lbl_pitatrioamountbeef.Text = amtbpdwfnd;
                }
                if (cpdwfnd == "0")
                {
                    inv_pita.lbl_pitaouttriochicken.Text = "";
                    inv_pita.lbl_pitatrioamountchicken.Text = "";
                }
                else
                {
                    inv_pita.lbl_pitaouttriochicken.Text = cpdwfnd;
                    inv_pita.lbl_pitatrioamountchicken.Text = amtcpdwfnd;
                }
                if (kwwfnd == "0")
                {
                    inv_pita.lbl_pitaouttriokebab.Text = "";
                    inv_pita.lbl_pitatrioamountkebab.Text = "";
                }
                else
                {
                    inv_pita.lbl_pitaouttriokebab.Text = kwwfnd;
                    inv_pita.lbl_pitatrioamountkebab.Text = amtkwwfnd;
                }
                if (hwwfnd == "0")
                {
                    inv_pita.lbl_pitaouttriohotdog.Text = "";
                    inv_pita.lbl_pitatrioamounthotdog.Text = "";
                }
                else
                {
                    inv_pita.lbl_pitaouttriohotdog.Text = hwwfnd;
                    inv_pita.lbl_pitatrioamounthotdog.Text = amthwwfnd;
                }
                if (bdor == "0")
                {
                    inv_pita.lbl_doneroutsolobeef.Text = "";
                    inv_pita.lbl_donersoloamountbeef.Text = "";
                }
                else
                {
                    inv_pita.lbl_doneroutsolobeef.Text = bdor;
                    inv_pita.lbl_donersoloamountbeef.Text = amtbdor;
                }
                if (cdor == "0")
                {
                    inv_pita.lbl_doneroutsolochicken.Text = "";
                    inv_pita.lbl_donersoloamountchicken.Text = "";
                }
                else
                {
                    inv_pita.lbl_doneroutsolochicken.Text = cdor;
                    inv_pita.lbl_donersoloamountchicken.Text = amtcdor;
                }
                if (kor == "0")
                {
                    inv_pita.lbl_doneroutsolokebab.Text = "";
                    inv_pita.lbl_donersoloamountkebab.Text = "";
                }
                else
                {
                    inv_pita.lbl_doneroutsolokebab.Text = kor;
                    inv_pita.lbl_donersoloamountkebab.Text = amtkor;
                }
                if (hr == "0")
                {
                    inv_pita.lbl_doneroutsolohotdog.Text = "";
                    inv_pita.lbl_donersoloamounthotdog.Text = "";
                }
                else
                {
                    inv_pita.lbl_doneroutsolohotdog.Text = hr;
                    inv_pita.lbl_donersoloamounthotdog.Text = amtkor;
                }
                if (bdorwd == "0")
                {
                    inv_pita.lbl_doneroutduobeef.Text = "";
                    inv_pita.lbl_donerduoamountbeef.Text = "";
                }
                else
                {
                    inv_pita.lbl_doneroutduobeef.Text = bdorwd;
                    inv_pita.lbl_donerduoamountbeef.Text = amtbdorwd;
                }
                if (cdorwd == "0")
                {
                    inv_pita.lbl_doneroutduochicken.Text = "";
                    inv_pita.lbl_donerduoamountchicken.Text = "";
                }
                else
                {
                    inv_pita.lbl_doneroutduochicken.Text = cdorwd;
                    inv_pita.lbl_donerduoamountchicken.Text = amtcdorwd;
                }
                if (korwd == "0")
                {
                    inv_pita.lbl_doneroutduokebab.Text = "";
                    inv_pita.lbl_donerduoamountkebab.Text = "";
                }
                else
                {
                    inv_pita.lbl_doneroutduokebab.Text = korwd;
                    inv_pita.lbl_donerduoamountkebab.Text = amtkorwd;
                }
                if (hrwd == "0")
                {
                    inv_pita.lbl_doneroutduohotdog.Text = "";
                    inv_pita.lbl_donerduoamounthotdog.Text = "";
                }
                else
                {
                    inv_pita.lbl_doneroutduohotdog.Text = hrwd;
                    inv_pita.lbl_donerduoamounthotdog.Text = amthrwd;
                }
                if (bds == "0")
                {
                    inv_pita.lbl_steakoutsolobeef.Text = "";
                    inv_pita.lbl_steaksoloamountbeef.Text = "";
                }
                else
                {
                    inv_pita.lbl_steakoutsolobeef.Text = bds;
                    inv_pita.lbl_steaksoloamountbeef.Text = amtbds;
                }
                if (cds == "0")
                {
                    inv_pita.lbl_steakoutsolochicken.Text = "";
                    inv_pita.lbl_steaksoloamountchicken.Text = "";
                }
                else
                {
                    inv_pita.lbl_steakoutsolochicken.Text = cds;
                    inv_pita.lbl_steaksoloamountchicken.Text = amtcds;
                }
                if (bdswd == "0")
                {
                    inv_pita.lbl_steakoutduobeef.Text = "";
                    inv_pita.lbl_steakduoamountbeef.Text = "";
                }
                else
                {
                    inv_pita.lbl_steakoutduobeef.Text = bdswd;
                    inv_pita.lbl_steakduoamountbeef.Text = amtbdswd;
                }
                if (cdswd == "0")
                {
                    inv_pita.lbl_steakoutduochicken.Text = "";
                    inv_pita.lbl_steakduoamountchicken.Text = "";
                }
                else
                {
                    inv_pita.lbl_steakoutduochicken.Text = cdswd;
                    inv_pita.lbl_steakduoamountchicken.Text = amtcdswd;
                }
                if (bcp == "0")
                {
                    inv_pita.lbl_platteroutsolobc.Text = "";
                    inv_pita.lbl_plattersoloamountbc.Text = "";
                }
                else
                {
                    inv_pita.lbl_platteroutsolobc.Text = bcp;
                    inv_pita.lbl_plattersoloamountbc.Text = amtbcp;
                }
                if (bkp == "0")
                {
                    inv_pita.lbl_platteroutsolobk.Text = "";
                    inv_pita.lbl_plattersoloamountbk.Text = "";
                }
                else
                {
                    inv_pita.lbl_platteroutsolobk.Text = bkp;
                    inv_pita.lbl_plattersoloamountbk.Text = amtbkp;
                }
                if (ckp == "0")
                {
                    inv_pita.lbl_platteroutsolock.Text = "";
                    inv_pita.lbl_plattersoloamountck.Text = "";
                }
                else
                {
                    inv_pita.lbl_platteroutsolock.Text = ckp;
                    inv_pita.lbl_plattersoloamountck.Text = amtckp;
                }
                if (bcpwd == "0")
                {
                    inv_pita.lbl_platteroutduobf.Text = "";
                    inv_pita.lbl_donerduoamountbc.Text = "";
                }
                else
                {
                    inv_pita.lbl_platteroutduobf.Text = bcpwd;
                    inv_pita.lbl_donerduoamountbc.Text = amtbcpwd;
                }
                if (bkpwd == "0")
                {
                    inv_pita.lbl_platteroutduobk.Text = "";
                    inv_pita.lbl_donerduoamountbk.Text = "";
                }
                else
                {
                    inv_pita.lbl_platteroutduobk.Text = bkpwd;
                    inv_pita.lbl_donerduoamountbk.Text = amtbkpwd;
                }
                if (ckpwd == "0")
                {
                    inv_pita.lbl_platteroutduock.Text = "";
                    inv_pita.lbl_donerduoamountck.Text = "";
                }
                else
                {
                    inv_pita.lbl_platteroutduock.Text = ckpwd;
                    inv_pita.lbl_donerduoamountck.Text = amtckpwd;
                }
                if (pitaout == "0")
                {
                    inv_pita.lbl_pitaout.Text = "";
                }
                else
                {
                    inv_pita.lbl_pitaout.Text = pitaout;
                }
                if (riceout == "0")
                {
                    inv_pita.inp_riceout.Text = "";
                }
                else
                {
                    inv_pita.inp_riceout.Text = riceout;
                }
                if (kebabout == "0")
                {
                    inv_pita.lbl_kebabout.Text = "";
                }
                else
                {
                    inv_pita.lbl_kebabout.Text = kebabout;
                }
                if (mealboxout == "0")
                {
                    inv_pita.lbl_mealbout.Text = "";
                }
                else
                {
                    inv_pita.lbl_mealbout.Text = mealboxout;
                }
                if (beefout == "0")
                {
                    inv_pita.lbl_beefout.Text = "";
                }
                else
                {
                    inv_pita.lbl_beefout.Text = beefout;
                }
                if (chickenout == "0")
                {
                    inv_pita.lbl_chickenout.Text = "";
                }
                else
                {
                    inv_pita.lbl_chickenout.Text = chickenout;
                }
                if (hotdogout == "0")
                {
                    inv_pita.lbl_hotdogout.Text = "";
                }
                else
                {
                    inv_pita.lbl_hotdogout.Text = hotdogout;
                }
                if (bsteakout == "0")
                {
                    inv_pita.lbl_beefsteakout.Text = "";
                }
                else
                {
                    inv_pita.lbl_beefsteakout.Text = bsteakout;
                }
                if (csteakout == "0")
                {
                    inv_pita.lbl_chickensteakout.Text = "";
                }
                else
                {
                    inv_pita.lbl_chickensteakout.Text = csteakout;
                }
                if (platterboxout == "0")
                {
                    inv_pita.lbl_platterboxout.Text = "";
                }
                else
                {
                    inv_pita.lbl_platterboxout.Text = platterboxout;
                }
                if (minipitaout == "0")
                {
                    inv_pita.lbl_minipitaout.Text = "";
                }
                else
                {
                    inv_pita.lbl_minipitaout.Text = minipitaout;
                }
                if (friesbagsout == "0")
                {
                    inv_pita.lbl_friesbagsout.Text = "";
                }
                else
                {
                    inv_pita.lbl_friesbagsout.Text = friesbagsout;
                }
                if (minicupsout == "0")
                {
                    inv_pita.lbl_minicupsout.Text = "";
                }
                else
                {
                    inv_pita.lbl_minicupsout.Text = minicupsout;
                }
                if (conesout == "0")
                {
                    inv_pita.lbl_conesout.Text = "";
                }
                else
                {
                    inv_pita.lbl_conesout.Text = conesout;
                }
                if (cupsout == "0")
                {
                    inv_pita.lbl_cupsout.Text = "";
                }
                else
                {
                    inv_pita.lbl_cupsout.Text = cupsout;
                }
                if (cheeseout == "0")
                {
                    inv_pita.lbl_slicedcheeseout.Text = "";
                    inv_pita.lbl_extrasamountscheese.Text = "";
                }
                else
                {
                    inv_pita.lbl_slicedcheeseout.Text = cheeseout;
                    inv_pita.lbl_extrasamountscheese.Text = amtcheeseout;
                }
                if (gsauceout == "0")
                {
                    inv_pita.lbl_garlicsauceout.Text = "";
                    inv_pita.lbl_extrasamountgsauce.Text = "";
                }
                else
                {
                    inv_pita.lbl_garlicsauceout.Text = gsauceout;
                    inv_pita.lbl_extrasamountgsauce.Text = amtgsauceout;
                }
                if (csauceout == "0")
                {
                    inv_pita.lbl_cheesesauceout.Text = "";
                    inv_pita.lbl_extrasamountcsauce.Text = "";
                }
                else
                {
                    inv_pita.lbl_cheesesauceout.Text = csauceout;
                    inv_pita.lbl_extrasamountcsauce.Text = amtcsauceout;
                }
                if (hsauceout == "0")
                {
                    inv_pita.lbl_hotsauceout.Text = "";
                    inv_pita.lbl_extrasamounthsauce.Text = "";
                }
                else
                {
                    inv_pita.lbl_hotsauceout.Text = hsauceout;
                    inv_pita.lbl_extrasamounthsauce.Text = amthsauceout;
                }
                if (lemonadeout == "0")
                {
                    inv_pita.lbl_lemonadeout.Text = "";
                    inv_pita.lbl_drinksamountlemonade.Text = "";
                }
                else
                {
                    inv_pita.lbl_lemonadeout.Text = lemonadeout;
                    inv_pita.lbl_drinksamountlemonade.Text = amtlemonadeout;
                }
                if (nesteaout == "0")
                {
                    inv_pita.lbl_nesteaout.Text = "";
                    inv_pita.lbl_drinksamountnestea.Text = "";
                }
                else
                {
                    inv_pita.lbl_nesteaout.Text = nesteaout;
                    inv_pita.lbl_drinksamountnestea.Text = amtnesteaout;
                }
                if (waterout == "0")
                {
                    inv_pita.lbl_waterout.Text = "";
                    inv_pita.lbl_drinksamountwater.Text = "";
                }
                else
                {
                    inv_pita.lbl_waterout.Text = waterout;
                    inv_pita.lbl_drinksamountwater.Text = amtwaterout;
                }
                if (sodaout == "0")
                {
                    inv_pita.lbl_sodaincanout.Text = "";
                    inv_pita.lbl_drinksamountsodaincan.Text = "";
                }
                else
                {
                    inv_pita.lbl_sodaincanout.Text = sodaout;
                    inv_pita.lbl_drinksamountsodaincan.Text = amtsodaout;
                }
                if (extrariceout == "0")
                {
                    inv_pita.lbl_extrariceout.Text = "";
                    inv_pita.lbl_extrasamountxrice.Text = "";
                }
                else
                {
                    inv_pita.lbl_extrariceout.Text = extrariceout;
                    inv_pita.lbl_extrasamountxrice.Text = amtextrariceout;
                }
                if (turksfriesout == "0")
                {
                    inv_pita.lbl_turksfriesout.Text = "";
                    inv_pita.lbl_extrasamounttfries.Text = "";
                }
                else
                {
                    inv_pita.lbl_turksfriesout.Text = turksfriesout;
                    inv_pita.lbl_extrasamounttfries.Text = amtturksfriesout;
                }

                inv_pita.lbl_totalamt.Text = (Convert.ToInt32(amtbpd) + Convert.ToInt32(amtcpd) + Convert.ToInt32(amtkw) + Convert.ToInt32(amthw) + Convert.ToInt32(amtbpdwd) + Convert.ToInt32(amtcpdwd) + Convert.ToInt32(amtkwwd) + Convert.ToInt32(amthwwd) + Convert.ToInt32(amtbpdwfnd) + Convert.ToInt32(amtcpdwfnd) + Convert.ToInt32(amtkwwfnd) + Convert.ToInt32(amthwwfnd) + Convert.ToInt32(amtbdor)
            + Convert.ToInt32(amtcdor) + Convert.ToInt32(amtkor) + Convert.ToInt32(amthr) + Convert.ToInt32(amtbdorwd) + Convert.ToInt32(amtcdorwd) + Convert.ToInt32(amtkorwd) + Convert.ToInt32(amthrwd) + Convert.ToInt32(amtbds) + Convert.ToInt32(amtcds) + Convert.ToInt32(amtbdswd) + Convert.ToInt32(amtcdswd) + Convert.ToInt32(amtbcp) + Convert.ToInt32(amtbkp) + Convert.ToInt32(amtckp) + Convert.ToInt32(amtbcpwd)
            + Convert.ToInt32(amtbkpwd) + Convert.ToInt32(amtckpwd) + Convert.ToInt32(amtcheeseout) + Convert.ToInt32(amtgsauceout) + Convert.ToInt32(amtcsauceout) + Convert.ToInt32(amthsauceout) + Convert.ToInt32(amtlemonadeout) + Convert.ToInt32(amtnesteaout) + Convert.ToInt32(amtwaterout)
            + Convert.ToInt32(amtsodaout) + Convert.ToInt32(amtturksfriesout) + Convert.ToInt32(amtextrariceout)).ToString();

                string total_sales = (Convert.ToInt32(amtbpd) + Convert.ToInt32(amtcpd) + Convert.ToInt32(amtkw) + Convert.ToInt32(amthw) + Convert.ToInt32(amtbpdwd) + Convert.ToInt32(amtcpdwd) + Convert.ToInt32(amtkwwd) + Convert.ToInt32(amthwwd) + Convert.ToInt32(amtbpdwfnd) + Convert.ToInt32(amtcpdwfnd) + Convert.ToInt32(amtkwwfnd) + Convert.ToInt32(amthwwfnd) + Convert.ToInt32(amtbdor)
            + Convert.ToInt32(amtcdor) + Convert.ToInt32(amtkor) + Convert.ToInt32(amthr) + Convert.ToInt32(amtbdorwd) + Convert.ToInt32(amtcdorwd) + Convert.ToInt32(amtkorwd) + Convert.ToInt32(amthrwd) + Convert.ToInt32(amtbds) + Convert.ToInt32(amtcds) + Convert.ToInt32(amtbdswd) + Convert.ToInt32(amtcdswd) + Convert.ToInt32(amtbcp) + Convert.ToInt32(amtbkp) + Convert.ToInt32(amtckp) + Convert.ToInt32(amtbcpwd)
            + Convert.ToInt32(amtbkpwd) + Convert.ToInt32(amtckpwd) + Convert.ToInt32(amtcheeseout) + Convert.ToInt32(amtgsauceout) + Convert.ToInt32(amtcsauceout) + Convert.ToInt32(amthsauceout) + Convert.ToInt32(amtlemonadeout) + Convert.ToInt32(amtnesteaout) + Convert.ToInt32(amtwaterout)
            + Convert.ToInt32(amtsodaout) + Convert.ToInt32(amtturksfriesout) + Convert.ToInt32(amtextrariceout)).ToString();

                cash_dem.lbl_totalsales.Text = total_sales;

                string qry_sales = "UPDATE tbl_transactions SET total_sales = '" + total_sales + "' WHERE date = '" + date + "'";
                SQLiteCommand cmd_sales = new SQLiteCommand(qry_sales, myConnection);
                cmd_sales.ExecuteNonQuery();

                string qry3 = "SELECT * FROM tbl_insandlos WHERE date = '" + date + "'";
                SQLiteCommand myCommand3 = new SQLiteCommand(qry3, myConnection);
                SQLiteDataReader result2 = myCommand3.ExecuteReader();

                string pitapastlo = "";
                string pitapresentin = "";
                string pitapresentlo = "";
                string ricepastlo = "";
                string ricepresentin = "";
                string ricepresentlo = "";
                string kebabpastlo = "";
                string kebabpresentin = "";
                string kebabpresentlo = "";
                string mealboxpastlo = "";
                string mealboxpresentin = "";
                string mealboxpresentlo = "";
                string beefpastlo = "";
                string beefpresentin = "";
                string beefpresentlo = "";
                string chickenpastlo = "";
                string chickenpresentin = "";
                string chickenpresentlo = "";
                string hotdogpastlo = "";
                string hotdogpresentin = "";
                string hotdogpresentlo = "";
                string bsteakpastlo = "";
                string bsteakpresentin = "";
                string bsteakpresentlo = "";
                string csteakpastlo = "";
                string csteakpresentin = "";
                string csteakpresentlo = "";
                string cheesepastlo = "";
                string cheesepresentin = "";
                string friesbagspastlo = "";
                string friesbagspresentin = "";
                string friesbagspresentlo = "";
                string minicupspastlo = "";
                string minicupspresentin = "";
                string minicupspresentlo = "";
                string conespastlo = "";
                string conespresentin = "";
                string conespresentlo = "";
                string cupspastlo = "";
                string cupspresentin = "";
                string cupspresentlo = "";
                string waterpastlo = "";
                string waterpresentin = "";
                string waterpresentlo = "";
                string sodapastlo = "";
                string sodapresentin = "";
                string sodapresentlo = "";
                string platterboxpastlo = "";
                string platterboxpresentin = "";
                string platterboxpresentlo = "";
                string minipitapastlo = "";
                string minipitapresentin = "";
                string minipitapresentlo = "";

                if (result2.HasRows)
                {
                    while (result2.Read())
                    {
                        pitapastlo = result2["pitapastlo"].ToString();
                        pitapresentin = result2["pitapresentin"].ToString();
                        pitapresentlo = result2["pitapresentlo"].ToString();
                        ricepastlo = result2["ricepastlo"].ToString();
                        ricepresentin = result2["ricepresentin"].ToString();
                        ricepresentlo = result2["ricepresentlo"].ToString();
                        kebabpastlo = result2["kebabpastlo"].ToString();
                        kebabpresentin = result2["kebabpresentin"].ToString();
                        kebabpresentlo = result2["kebabpresentlo"].ToString();
                        mealboxpastlo = result2["mealboxpastlo"].ToString();
                        mealboxpresentin = result2["mealboxpresentin"].ToString();
                        mealboxpresentlo = result2["mealboxpresentlo"].ToString();
                        beefpastlo = result2["beefpastlo"].ToString();
                        beefpresentin = result2["beefpresentin"].ToString();
                        beefpresentlo = result2["beefpresentlo"].ToString();
                        chickenpastlo = result2["chickenpastlo"].ToString();
                        chickenpresentin = result2["chickenpresentin"].ToString();
                        chickenpresentlo = result2["chickenpresentlo"].ToString();
                        hotdogpastlo = result2["hotdogpastlo"].ToString();
                        hotdogpresentin = result2["hotdogpresentin"].ToString();
                        hotdogpresentlo = result2["hotdogpresentlo"].ToString();
                        bsteakpastlo = result2["bsteakpastlo"].ToString();
                        bsteakpresentin = result2["bsteakpresentin"].ToString();
                        bsteakpresentlo = result2["bsteakpresentlo"].ToString();
                        csteakpastlo = result2["csteakpastlo"].ToString();
                        csteakpresentin = result2["csteakpresentin"].ToString();
                        csteakpresentlo = result2["csteakpresentlo"].ToString();
                        cheesepastlo = result2["cheesepastlo"].ToString();
                        cheesepresentin = result2["cheesepresentin"].ToString();
                        friesbagspastlo = result2["friesbagspastlo"].ToString();
                        friesbagspresentin = result2["friesbagspresentin"].ToString();
                        friesbagspresentlo = result2["friesbagspresentlo"].ToString();
                        minicupspastlo = result2["minicupspastlo"].ToString();
                        minicupspresentin = result2["minicupspresentin"].ToString();
                        minicupspresentlo = result2["minicupspresentlo"].ToString();
                        conespastlo = result2["conespastlo"].ToString();
                        conespresentin = result2["conespresentin"].ToString();
                        conespresentlo = result2["conespresentlo"].ToString();
                        cupspastlo = result2["cupspastlo"].ToString();
                        cupspresentin = result2["cupspresentin"].ToString();
                        cupspresentlo = result2["cupspresentlo"].ToString();
                        waterpastlo = result2["waterpastlo"].ToString();
                        waterpresentin = result2["waterpresentin"].ToString();
                        waterpresentlo = result2["waterpresentlo"].ToString();
                        sodapastlo = result2["sodapastlo"].ToString();
                        sodapresentin = result2["sodapresentin"].ToString();
                        sodapresentlo = result2["sodapresentlo"].ToString();
                        platterboxpastlo = result2["platterboxpastlo"].ToString();
                        platterboxpresentin = result2["platterboxpresentin"].ToString();
                        platterboxpresentlo = result2["platterboxpresentlo"].ToString();
                        minipitapastlo = result2["minipitapastlo"].ToString();
                        minipitapresentin = result2["minipitapresentin"].ToString();
                        minipitapresentlo = result2["minipitapresentlo"].ToString();
                    }
                }

                if (pitapresentlo == "0")
                {
                    inv_pita.lbl_pitain1.Text = "";
                    inv_pita.lbl_pitain2.Text = "";
                    inv_pita.lbl_lo.Text = "";
                }
                else
                {
                    inv_pita.lbl_pitain1.Text = pitapastlo;
                    inv_pita.lbl_pitain2.Text = pitapresentin;
                    inv_pita.lbl_lo.Text = pitapresentlo;
                }
                if (ricepresentlo == "0")
                {
                    inv_pita.lbl_ricein1.Text = "";
                    inv_pita.lbl_ricein2.Text = "";
                    inv_pita.lbl_ricelo.Text = "";
                }
                else
                {
                    inv_pita.lbl_ricein1.Text = ricepastlo;
                    inv_pita.lbl_ricein2.Text = ricepresentin;
                    inv_pita.lbl_ricelo.Text = ricepresentlo;
                }
                if (kebabpresentlo == "0")
                {
                    inv_pita.lbl_kebabin1.Text = "";
                    inv_pita.lbl_kebabin2.Text = "";
                    inv_pita.lbl_kebablo.Text = "";
                }
                else
                {
                    inv_pita.lbl_kebabin1.Text = kebabpastlo;
                    inv_pita.lbl_kebabin2.Text = kebabpresentin;
                    inv_pita.lbl_kebablo.Text = kebabpresentlo;
                }
                if (mealboxpresentlo == "0")
                {
                    inv_pita.lbl_mealbin1.Text = "";
                    inv_pita.lbl_mealbin2.Text = "";
                    inv_pita.lbl_mealblo.Text = "";
                }
                else
                {
                    inv_pita.lbl_mealbin1.Text = mealboxpastlo;
                    inv_pita.lbl_mealbin2.Text = mealboxpresentin;
                    inv_pita.lbl_mealblo.Text = mealboxpresentlo;
                }
                if (beefpresentlo == "0")
                {
                    inv_pita.lbl_beefin1.Text = "";
                    inv_pita.lbl_beefin2.Text = "";
                    inv_pita.lbl_beeflo.Text = "";
                }
                else
                {
                    inv_pita.lbl_beefin1.Text = beefpastlo;
                    inv_pita.lbl_beefin2.Text = beefpresentin;
                    inv_pita.lbl_beeflo.Text = beefpresentlo;
                }
                if (chickenpresentlo == "0")
                {
                    inv_pita.lbl_chickenin1.Text = "";
                    inv_pita.lbl_chickenin2.Text = "";
                    inv_pita.lbl_chickenlo.Text = "";
                }
                else
                {
                    inv_pita.lbl_chickenin1.Text = chickenpastlo;
                    inv_pita.lbl_chickenin2.Text = chickenpresentin;
                    inv_pita.lbl_chickenlo.Text = chickenpresentlo;
                }
                if (hotdogpresentlo == "0")
                {
                    inv_pita.lbl_hotdogin1.Text = "";
                    inv_pita.lbl_hotdogin2.Text = "";
                    inv_pita.lbl_hotdoglo.Text = "";
                }
                else
                {
                    inv_pita.lbl_hotdogin1.Text = hotdogpastlo;
                    inv_pita.lbl_hotdogin2.Text = hotdogpresentin;
                    inv_pita.lbl_hotdoglo.Text = hotdogpresentlo;
                }
                if (bsteakpresentlo == "0")
                {
                    inv_pita.lbl_beefsteakin1.Text = "";
                    inv_pita.lbl_beefsteakin2.Text = "";
                    inv_pita.lbl_beefsteaklo.Text = "";
                }
                else
                {
                    inv_pita.lbl_beefsteakin1.Text = bsteakpastlo;
                    inv_pita.lbl_beefsteakin2.Text = bsteakpresentin;
                    inv_pita.lbl_beefsteaklo.Text = bsteakpresentlo;
                }
                if (csteakpresentlo == "0")
                {
                    inv_pita.lbl_chickensteakin1.Text = "";
                    inv_pita.lbl_chickensteakin2.Text = "";
                    inv_pita.lbl_chickensteaklo.Text = "";
                }
                else
                {
                    inv_pita.lbl_chickensteakin1.Text = csteakpastlo;
                    inv_pita.lbl_chickensteakin2.Text = csteakpresentin;
                    inv_pita.lbl_chickensteaklo.Text = csteakpresentlo;
                }
                if (cheesepastlo == "0")
                {
                    inv_pita.lbl_slicedcheesein1.Text = "";
                    inv_pita.lbl_slicedcheesein2.Text = "";
                }
                else
                {
                    inv_pita.lbl_slicedcheesein1.Text = cheesepastlo;
                    inv_pita.lbl_slicedcheesein2.Text = cheesepresentin;
                }
                if (friesbagspresentlo == "0")
                {
                    inv_pita.lbl_friesbagsin1.Text = "";
                    inv_pita.lbl_friesbagsin2.Text = "";
                    inv_pita.lbl_friesbagslo.Text = "";
                }
                else
                {
                    inv_pita.lbl_friesbagsin1.Text = friesbagspastlo;
                    inv_pita.lbl_friesbagsin2.Text = friesbagspresentin;
                    inv_pita.lbl_friesbagslo.Text = friesbagspresentlo;
                }
                if (minicupspresentlo == "0")
                {
                    inv_pita.lbl_minicupsin1.Text = "";
                    inv_pita.lbl_minicupsin2.Text = "";
                    inv_pita.lbl_minicupslo.Text = "";
                }
                else
                {
                    inv_pita.lbl_minicupsin1.Text = minicupspastlo;
                    inv_pita.lbl_minicupsin2.Text = minicupspresentin;
                    inv_pita.lbl_minicupslo.Text = minicupspresentlo;
                }
                if (conespresentlo == "0")
                {
                    inv_pita.lbl_conesin1.Text = "";
                    inv_pita.lbl_conesin2.Text = "";
                    inv_pita.lbl_coneslo.Text = "";
                }
                else
                {
                    inv_pita.lbl_conesin1.Text = conespastlo;
                    inv_pita.lbl_conesin2.Text = conespresentin;
                    inv_pita.lbl_coneslo.Text = conespresentlo;
                }
                if (cupspresentlo == "0")
                {
                    inv_pita.lbl_cupsin1.Text = "";
                    inv_pita.lbl_cupsin2.Text = "";
                    inv_pita.lbl_cupslo.Text = "";
                }
                else
                {
                    inv_pita.lbl_cupsin1.Text = cupspastlo;
                    inv_pita.lbl_cupsin2.Text = cupspresentin;
                    inv_pita.lbl_cupslo.Text = cupspresentlo;
                }
                if (waterpresentlo == "0")
                {
                    inv_pita.lbl_waterin1.Text = "";
                    inv_pita.lbl_waterin2.Text = "";
                    inv_pita.lbl_waterlo.Text = "";
                }
                else
                {
                    inv_pita.lbl_waterin1.Text = waterpastlo;
                    inv_pita.lbl_waterin2.Text = waterpresentin;
                    inv_pita.lbl_waterlo.Text = waterpresentlo;
                }
                if (sodapresentlo == "0")
                {
                    inv_pita.lbl_sodaincanin1.Text = "";
                    inv_pita.lbl_sodaincanin2.Text = "";
                    inv_pita.lbl_sodaincanlo.Text = "";
                }
                else
                {
                    inv_pita.lbl_sodaincanin1.Text = sodapastlo;
                    inv_pita.lbl_sodaincanin2.Text = sodapresentin;
                    inv_pita.lbl_sodaincanlo.Text = sodapresentlo;
                }
                if (platterboxpresentlo == "0")
                {
                    inv_pita.lbl_platterboxin1.Text = "";
                    inv_pita.lbl_platterboxin2.Text = "";
                    inv_pita.lbl_platterboxlo.Text = "";
                }
                else
                {
                    inv_pita.lbl_platterboxin1.Text = platterboxpastlo;
                    inv_pita.lbl_platterboxin2.Text = platterboxpresentin;
                    inv_pita.lbl_platterboxlo.Text = platterboxpresentlo;
                }
                if (minipitapresentlo == "0")
                {
                    inv_pita.lbl_minipitain1.Text = "";
                    inv_pita.lbl_minipitain2.Text = "";
                    inv_pita.lbl_minipitalo.Text = "";
                }
                else
                {
                    inv_pita.lbl_minipitain1.Text = minipitapastlo;
                    inv_pita.lbl_minipitain2.Text = minipitapresentin;
                    inv_pita.lbl_minipitalo.Text = minipitapresentlo;
                }
                if (conespresentlo == "0")
                {
                    inv_pita.lbl_conesin1.Text = "";
                    inv_pita.lbl_conesin2.Text = "";
                    inv_pita.lbl_coneslo.Text = "";
                }
                else
                {
                    inv_pita.lbl_conesin1.Text = conespastlo;
                    inv_pita.lbl_conesin2.Text = conespresentin;
                    inv_pita.lbl_coneslo.Text = conespresentlo;
                }
                if (platterboxpresentlo == "0")
                {
                    inv_pita.lbl_platterboxin1.Text = "";
                    inv_pita.lbl_platterboxin2.Text = "";
                    inv_pita.lbl_platterboxlo.Text = "";
                }
                else
                {
                    inv_pita.lbl_platterboxin1.Text = platterboxpastlo;
                    inv_pita.lbl_platterboxin2.Text = platterboxpresentin;
                    inv_pita.lbl_platterboxlo.Text = platterboxpresentlo;
                }

                string qry_cash = "SELECT * FROM tbl_cashdem WHERE date = '" + date + "'";
                string qry_cash2 = "SELECT COUNT(*) FROM tbl_cashdem WHERE date = '" + date + "'";
                SQLiteCommand myCommand_cash = new SQLiteCommand(qry_cash, myConnection);
                SQLiteCommand myCommand_cash2 = new SQLiteCommand(qry_cash2, myConnection);

                openConnection();
                SQLiteDataReader result_cash = myCommand_cash.ExecuteReader();
                int check3 = Convert.ToInt32(myCommand_cash2.ExecuteScalar());
                if (check3 != 0 && reported == "reported")
                {
                    string _x1 = "";
                    string _x2 = "";
                    string _x3 = "";
                    string _x4 = "";
                    string _x5 = "";
                    string _x6 = "";
                    string _x7 = "";
                    string _x8 = "";
                    string _x9 = "";
                    string _x10 = "";
                    string _x11 = "";
                    string _x12 = "";
                    string _x13 = "";
                    string _x14 = "";
                    string _x15 = "";
                    string _x16 = "";
                    string _x19 = "";
                    string _x20 = "";
                    string _x21 = "";
                    string _x22 = "";
                    string _x23 = "";
                    string _x24 = "";
                    string _x25 = "";
                    string _x26 = "";
                    string _x27 = "";
                    string _x28 = "";
                    string _x29 = "";
                    string _x30 = "";
                    string _x31 = "";
                    string _x32 = "";
                    string _x33 = "";
                    string _x34 = "";
                    string _x35 = "";
                    string _x36 = "";
                    string _x37 = "";
                    string _x38 = "";
                    string _x39 = "";
                    string _x40 = "";
                    string _x41 = "";
                    string _x42 = "";
                    string _x43 = "";
                    string _x44 = "";
                    string _x45 = "";
                    string _x46 = "";

                    if (result_cash.HasRows)
                    {
                        while (result_cash.Read())
                        {
                            _x1 = result_cash["x1"].ToString();
                            _x2 = result_cash["x2"].ToString();
                            _x3 = result_cash["x3"].ToString();
                            _x4 = result_cash["x4"].ToString();
                            _x5 = result_cash["x5"].ToString();
                            _x6 = result_cash["x6"].ToString();
                            _x7 = result_cash["x7"].ToString();
                            _x8 = result_cash["x8"].ToString();
                            _x9 = result_cash["x9"].ToString();
                            _x10 = result_cash["x10"].ToString();
                            _x11 = result_cash["x11"].ToString();
                            _x12 = result_cash["x12"].ToString();
                            _x13 = result_cash["x13"].ToString();
                            _x14 = result_cash["x14"].ToString();
                            _x15 = result_cash["x15"].ToString();
                            _x16 = result_cash["x16"].ToString();
                            _x19 = result_cash["x19"].ToString();
                            _x20 = result_cash["x20"].ToString();
                            _x21 = result_cash["x21"].ToString();
                            _x22 = result_cash["x22"].ToString();
                            _x23 = result_cash["x23"].ToString();
                            _x24 = result_cash["x24"].ToString();
                            _x25 = result_cash["x25"].ToString();
                            _x26 = result_cash["x26"].ToString();
                            _x27 = result_cash["x27"].ToString();
                            _x28 = result_cash["x28"].ToString();
                            _x29 = result_cash["x29"].ToString();
                            _x30 = result_cash["x30"].ToString();
                            _x31 = result_cash["x31"].ToString();
                            _x32 = result_cash["x32"].ToString();
                            _x33 = result_cash["x33"].ToString();
                            _x34 = result_cash["x34"].ToString();
                            _x35 = result_cash["x35"].ToString();
                            _x36 = result_cash["x36"].ToString();
                            _x37 = result_cash["x37"].ToString();
                            _x38 = result_cash["x38"].ToString();
                            _x39 = result_cash["x39"].ToString();
                            _x40 = result_cash["x40"].ToString();
                            _x41 = result_cash["x41"].ToString();
                            _x42 = result_cash["x42"].ToString();
                            _x43 = result_cash["x43"].ToString();
                            _x44 = result_cash["x44"].ToString();
                            _x45 = result_cash["x45"].ToString();
                            _x46 = result_cash["x46"].ToString();
                        }
                    }
                    cash_dem.qty_1000.Text = _x1;
                    cash_dem.qty_500.Text = _x2;
                    cash_dem.qty_200.Text = _x3;
                    cash_dem.qty_100.Text = _x4;
                    cash_dem.qty_50.Text = _x5;
                    cash_dem.qty_20.Text = _x6;
                    cash_dem.qty_10.Text = _x7;
                    cash_dem.qty_5.Text = _x8;
                    cash_dem.qty_1.Text = _x9;
                    cash_dem.qty_25.Text = _x10;
                    cash_dem.txt_deposit.Text = _x11;
                    cash_dem.txt_pita.Text = _x12;
                    cash_dem.txt_pitaduo.Text = _x13;
                    cash_dem.txt_trio.Text = _x14;
                    cash_dem.txt_rice.Text = _x15;
                    cash_dem.txt_riceduo.Text = _x16;
                    //cash_dem.txt_bsteaksolo.Text = _x17;
                    //cash_dem.txt_csteaksolo.Text = _x18;
                    //cash_dem.txt_bsteakduo.Text = _x19;
                    //cash_dem.txt_csteakduo.Text = _x20;
                    cash_dem.txt_steak.Text = _x19;
                    cash_dem.txt_steakduo.Text = _x20;
                    cash_dem.txt_platter.Text = _x21;
                    cash_dem.txt_platterduo.Text = _x22;
                    cash_dem.txt_cheese.Text = _x23;
                    cash_dem.txt_fries.Text = _x24;
                    cash_dem.txt_extrarice.Text = _x25;
                    cash_dem.txt_water.Text = _x26;
                    cash_dem.txt_softdrinks.Text = _x27;
                    cash_dem.txt_soda.Text = _x28;
                    cash_dem.item1.Text = _x29;
                    cash_dem.item2.Text = _x30;
                    cash_dem.item3.Text = _x31;
                    cash_dem.item4.Text = _x32;
                    cash_dem.item5.Text = _x33;
                    cash_dem.item6.Text = _x34;
                    cash_dem.item7.Text = _x35;
                    cash_dem.item8.Text = _x36;
                    cash_dem.item9.Text = _x37;
                    cash_dem.amt1.Text = _x38;
                    cash_dem.amt2.Text = _x39;
                    cash_dem.amt3.Text = _x40;
                    cash_dem.amt4.Text = _x41;
                    cash_dem.amt5.Text = _x42;
                    cash_dem.amt6.Text = _x43;
                    cash_dem.amt7.Text = _x44;
                    cash_dem.amt8.Text = _x45;
                    cash_dem.amt9.Text = _x46;

                    cash_dem.lbl_totalcash.Visible = true;
                    cash_dem.lbl_totalexpenses.Visible = true;
                    cash_dem.lbl_overshort.Visible = true;
                    if (cash_dem.lbl_total.Text != string.Empty && cash_dem.total_amt.Text != string.Empty && cash_dem.lbl_totalall.Text != string.Empty)
                    {
                        if (cash_dem.txt_deposit.Text == string.Empty)
                            cash_dem.lbl_totalcash.Text = (Convert.ToDouble(cash_dem.lbl_total.Text) + 0 + Convert.ToDouble(cash_dem.total_amt.Text) + Convert.ToDouble(cash_dem.lbl_totalall.Text)).ToString();
                        else
                            cash_dem.lbl_totalcash.Text = (Convert.ToDouble(cash_dem.lbl_total.Text) + Convert.ToDouble(cash_dem.txt_deposit.Text) + Convert.ToDouble(cash_dem.total_amt.Text) + Convert.ToDouble(cash_dem.lbl_totalall.Text)).ToString();
                    }

                    if (cash_dem.total_amt.Text != string.Empty && cash_dem.lbl_totalall.Text != string.Empty)
                    {
                        if (cash_dem.lbl_totalall.Text == string.Empty)
                            cash_dem.lbl_totalexpenses.Text = (Convert.ToDouble(cash_dem.total_amt.Text) + 0).ToString();
                        else
                            cash_dem.lbl_totalexpenses.Text = (Convert.ToDouble(cash_dem.total_amt.Text) + Convert.ToDouble(cash_dem.lbl_totalall.Text)).ToString();
                    }

                    if (cash_dem.lbl_totalcash.Text != string.Empty && inv_pita.lbl_totalamt.Text != string.Empty && inv_pita.lbl_totalamt.Text != "")
                    {
                        cash_dem.lbl_overshort.Text = (Math.Round(Convert.ToDouble(cash_dem.lbl_totalcash.Text) - Convert.ToDouble(inv_pita.lbl_totalamt.Text), 2)).ToString();
                    }
                }
                else
                {
                    cash_dem.lbl_amount1000.Text = "0";
                    cash_dem.lbl_amount500.Text = "0";
                    cash_dem.lbl_amount200.Text = "0";
                    cash_dem.lbl_amount100.Text = "0";
                    cash_dem.lbl_amount50.Text = "0";
                    cash_dem.lbl_amount20.Text = "0";
                    cash_dem.lbl_amount10.Text = "0";
                    cash_dem.lbl_amount5.Text = "0";
                    cash_dem.lbl_amount1.Text = "0";
                    cash_dem.lbl_amount025.Text = "0";
                    cash_dem.lbl_billssub.Text = "0";
                    cash_dem.lbl_coinssub.Text = "0";
                    cash_dem.lbl_coh.Text = "0";
                    cash_dem.lbl_total.Text = "0";
                    cash_dem.lbl_totalall.Text = "";
                    cash_dem.total_amt.Text = "0";
                    cash_dem.total_amt.Visible = false;

                    cash_dem.lbl_amount1000.Visible = false;
                    cash_dem.lbl_amount500.Visible = false;
                    cash_dem.lbl_amount200.Visible = false;
                    cash_dem.lbl_amount100.Visible = false;
                    cash_dem.lbl_amount50.Visible = false;
                    cash_dem.lbl_amount20.Visible = false;
                    cash_dem.lbl_amount10.Visible = false;
                    cash_dem.lbl_amount5.Visible = false;
                    cash_dem.lbl_amount1.Visible = false;
                    cash_dem.lbl_amount025.Visible = false;
                    cash_dem.lbl_billssub.Visible = false;
                    cash_dem.lbl_coinssub.Visible = false;
                    cash_dem.lbl_coh.Visible = false;
                    cash_dem.lbl_total.Text = "0";

                    cash_dem.lbl_pitascdpwd.Text = "0";
                    cash_dem.lbl_pitavat.Text = "0";
                    cash_dem.lbl_pitatotal.Text = "0";
                    cash_dem.lbl_pitaduoscdpwd.Text = "0";
                    cash_dem.lbl_pitaduovat.Text = "0";
                    cash_dem.lbl_pitaduototal.Text = "0";
                    cash_dem.lbl_pitatrioscdpwd.Text = "0";
                    cash_dem.lbl_pitatriovat.Text = "0";
                    cash_dem.lbl_pitatriototal.Text = "0";
                    cash_dem.lbl_ricescdpwd.Text = "0";
                    cash_dem.lbl_ricevat.Text = "0";
                    cash_dem.lbl_ricetotal.Text = "0";
                    cash_dem.lbl_riceduoscdpwd.Text = "0";
                    cash_dem.lbl_riceduovat.Text = "0";
                    cash_dem.lbl_riceduototal.Text = "0";
                    cash_dem.lbl_steakscdpwd.Text = "0";
                    cash_dem.lbl_steakvat.Text = "0";
                    cash_dem.lbl_steaktotal.Text = "0";
                    cash_dem.lbl_steakduoscdpwd.Text = "0";
                    cash_dem.lbl_steakduovat.Text = "0";
                    cash_dem.lbl_steakduototal.Text = "0";
                    cash_dem.lbl_platterscdpwd.Text = "0";
                    cash_dem.lbl_plattervat.Text = "0";
                    cash_dem.lbl_plattertotal.Text = "0";
                    cash_dem.lbl_plattersoloscdpwd.Text = "0";
                    cash_dem.lbl_plattersolovat.Text = "0";
                    cash_dem.lbl_plattersolototal.Text = "0";
                    cash_dem.lbl_cheesescdpwd.Text = "0";
                    cash_dem.lbl_cheesevat.Text = "0";
                    cash_dem.lbl_cheesetotal.Text = "0";
                    cash_dem.lbl_friesscdpwd.Text = "0";
                    cash_dem.lbl_friesvat.Text = "0";
                    cash_dem.lbl_friestotal.Text = "0";
                    cash_dem.lbl_extraricescdpwd.Text = "0";
                    cash_dem.lbl_extraricevat.Text = "0";
                    cash_dem.lbl_extraricetotal.Text = "0";
                    cash_dem.lbl_waterscdpwd.Text = "0";
                    cash_dem.lbl_watervat.Text = "0";
                    cash_dem.lbl_watertotal.Text = "0";
                    cash_dem.lbl_softdrinksscdpwd.Text = "0";
                    cash_dem.lbl_softdrinksvat.Text = "0";
                    cash_dem.lbl_softdrinkstotal.Text = "0";
                    cash_dem.lbl_sodascdpwd.Text = "0";
                    cash_dem.lbl_sodavat.Text = "0";
                    cash_dem.lbl_sodatotal.Text = "0";

                    cash_dem.lbl_pitascdpwd.Visible = false;
                    cash_dem.lbl_pitavat.Visible = false;
                    cash_dem.lbl_pitatotal.Visible = false;
                    cash_dem.lbl_pitaduoscdpwd.Visible = false;
                    cash_dem.lbl_pitaduovat.Visible = false;
                    cash_dem.lbl_pitaduototal.Visible = false;
                    cash_dem.lbl_pitatrioscdpwd.Visible = false;
                    cash_dem.lbl_pitatriovat.Visible = false;
                    cash_dem.lbl_pitatriototal.Visible = false;
                    cash_dem.lbl_ricescdpwd.Visible = false;
                    cash_dem.lbl_ricevat.Visible = false;
                    cash_dem.lbl_ricetotal.Visible = false;
                    cash_dem.lbl_riceduoscdpwd.Visible = false;
                    cash_dem.lbl_riceduovat.Visible = false;
                    cash_dem.lbl_riceduototal.Visible = false;
                    cash_dem.lbl_steakscdpwd.Visible = false;
                    cash_dem.lbl_steakvat.Visible = false;
                    cash_dem.lbl_steaktotal.Visible = false;
                    cash_dem.lbl_steakduoscdpwd.Visible = false;
                    cash_dem.lbl_steakduovat.Visible = false;
                    cash_dem.lbl_steakduototal.Visible = false;
                    cash_dem.lbl_platterscdpwd.Visible = false;
                    cash_dem.lbl_plattervat.Visible = false;
                    cash_dem.lbl_plattertotal.Visible = false;
                    cash_dem.lbl_plattersoloscdpwd.Visible = false;
                    cash_dem.lbl_plattersolovat.Visible = false;
                    cash_dem.lbl_plattersolototal.Visible = false;
                    cash_dem.lbl_cheesescdpwd.Visible = false;
                    cash_dem.lbl_cheesevat.Visible = false;
                    cash_dem.lbl_cheesetotal.Visible = false;
                    cash_dem.lbl_friesscdpwd.Visible = false;
                    cash_dem.lbl_friesvat.Visible = false;
                    cash_dem.lbl_friestotal.Visible = false;
                    cash_dem.lbl_extraricescdpwd.Visible = false;
                    cash_dem.lbl_extraricevat.Visible = false;
                    cash_dem.lbl_extraricetotal.Visible = false;
                    cash_dem.lbl_waterscdpwd.Visible = false;
                    cash_dem.lbl_watervat.Visible = false;
                    cash_dem.lbl_watertotal.Visible = false;
                    cash_dem.lbl_softdrinksscdpwd.Visible = false;
                    cash_dem.lbl_softdrinksvat.Visible = false;
                    cash_dem.lbl_softdrinkstotal.Visible = false;
                    cash_dem.lbl_sodascdpwd.Visible = false;
                    cash_dem.lbl_sodavat.Visible = false;
                    cash_dem.lbl_sodatotal.Visible = false;

                    cash_dem.lbl_totalcash.Text = "0";
                    cash_dem.lbl_totalexpenses.Text = "0";
                    cash_dem.lbl_overshort.Text = "0";

                    cash_dem.lbl_totalcash.Visible = false;
                    cash_dem.lbl_totalexpenses.Visible = false;
                    cash_dem.lbl_overshort.Visible = false;

                    cash_dem.qty_1000.Text = string.Empty;
                    cash_dem.qty_500.Text = string.Empty;
                    cash_dem.qty_200.Text = string.Empty;
                    cash_dem.qty_100.Text = string.Empty;
                    cash_dem.qty_50.Text = string.Empty;
                    cash_dem.qty_20.Text = string.Empty;
                    cash_dem.qty_10.Text = string.Empty;
                    cash_dem.qty_5.Text = string.Empty;
                    cash_dem.qty_1.Text = string.Empty;
                    cash_dem.qty_25.Text = string.Empty;
                    cash_dem.txt_deposit.Text = string.Empty;
                    cash_dem.txt_pita.Text = string.Empty;
                    cash_dem.txt_pitaduo.Text = string.Empty;
                    cash_dem.txt_trio.Text = string.Empty;
                    cash_dem.txt_rice.Text = string.Empty;
                    cash_dem.txt_riceduo.Text = string.Empty;
                    cash_dem.txt_steak.Text = string.Empty;
                    cash_dem.txt_steakduo.Text = string.Empty;
                    cash_dem.txt_platter.Text = string.Empty;
                    cash_dem.txt_platterduo.Text = string.Empty;
                    cash_dem.txt_cheese.Text = string.Empty;
                    cash_dem.txt_fries.Text = string.Empty;
                    cash_dem.txt_extrarice.Text = string.Empty;
                    cash_dem.txt_water.Text = string.Empty;
                    cash_dem.txt_softdrinks.Text = string.Empty;
                    cash_dem.txt_soda.Text = string.Empty;
                    cash_dem.item1.Text = string.Empty;
                    cash_dem.item2.Text = string.Empty;
                    cash_dem.item3.Text = string.Empty;
                    cash_dem.item4.Text = string.Empty;
                    cash_dem.item5.Text = string.Empty;
                    cash_dem.item6.Text = string.Empty;
                    cash_dem.item7.Text = string.Empty;
                    cash_dem.item8.Text = string.Empty;
                    cash_dem.item9.Text = string.Empty;
                    cash_dem.amt1.Text = string.Empty;
                    cash_dem.amt2.Text = string.Empty;
                    cash_dem.amt3.Text = string.Empty;
                    cash_dem.amt4.Text = string.Empty;
                    cash_dem.amt5.Text = string.Empty;
                    cash_dem.amt6.Text = string.Empty;
                    cash_dem.amt7.Text = string.Empty;
                    cash_dem.amt8.Text = string.Empty;
                    cash_dem.amt9.Text = string.Empty;
                }
                closeConnection();

                items_inv_layout.Controls.Clear();
                cash_dem_layout.Controls.Clear();
                items_inv_layout.Controls.Add(inv_pita);
                cash_dem_layout.Controls.Add(cash_dem);

                dailygraphs_layout.Controls.Clear();

                double[] xData = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
                double[] yData = new double[] { Convert.ToDouble(ckpwd), Convert.ToDouble(ckp), Convert.ToDouble(bcpwd), Convert.ToDouble(bcp),
                Convert.ToDouble(bkpwd), Convert.ToDouble(bkp), Convert.ToDouble(cdswd), Convert.ToDouble(cds), Convert.ToDouble(bdswd),
                Convert.ToDouble(bds), Convert.ToDouble(hrwd), Convert.ToDouble(hr), Convert.ToDouble(korwd), Convert.ToDouble(kor),
                Convert.ToDouble(cdorwd), Convert.ToDouble(cdor), Convert.ToDouble(bdorwd), Convert.ToDouble(bdor), Convert.ToDouble(hwwfnd),
                Convert.ToDouble(hwwd), Convert.ToDouble(hw), Convert.ToDouble(kwwfnd), Convert.ToDouble(kwwd), Convert.ToDouble(kw), 
                Convert.ToDouble(cpdwfnd), Convert.ToDouble(cpdwd), Convert.ToDouble(cpd), Convert.ToDouble(bpdwfnd), Convert.ToDouble(bpdwd),
                Convert.ToDouble(bpd) };

                Chart chart1 = new Chart();
                chart1.Width = 700;
                chart1.Height = 500;
                chart1.ChartAreas.Clear();
                ChartArea area = new ChartArea("First");
                chart1.Titles.Add("Today's Sales");
                chart1.ChartAreas.Add(area);
                chart1.ChartAreas["First"].AxisX.MajorGrid.LineWidth = 0;
                chart1.ChartAreas["First"].AxisY.MajorGrid.LineWidth = 0;

                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(0.5, 1.5, "Kebab and Chicken Platter (Duo)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(1.5, 2.5, "Kebab and Chicken Platter");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(2.5, 3.5, "Beef and Chicken Platter (Duo)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(3.5, 4.5, "Beef and Chicken Platter");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(4.5, 5.5, "Kebab and Beef Platter (Duo)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(5.5, 6.5, "Kebab and Beef Platter");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(6.5, 7.5, "Chicken Doner Steak (Duo)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(7.5, 8.5, "Chicken Doner Steak");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(8.5, 9.5, "Beef Doner Steak (Duo)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(9.5, 10.5, "Beef Doner Steak");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(10.5, 11.5, "Hotdog Rice (Duo)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(11.5, 12.5, "Hotdog Rice");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(12.5, 13.5, "Kebab on Rice (Duo)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(13.5, 14.5, "Kebab on Rice");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(14.5, 15.5, "Chicken Doner on Rice (Duo)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(15.5, 16.5, "Chicken Doner on Rice");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(16.5, 17.5, "Beef Doner on Rice (Duo)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(17.5, 18.5, "Beef Doner on Rice");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(18.5, 19.5, "Hotdog Wrap (Trio)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(19.5, 20.5, "Hotdog Wrap (Duo)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(20.5, 21.5, "Hotdog Wrap");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(21.5, 22.5, "Kebab Wrap (Trio)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(22.5, 23.5, "Kebab Wrap (Duo)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(23.5, 24.5, "Kebab Wrap");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(24.5, 25.5, "Chicken Pita Doner (Trio)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(25.5, 26.5, "Chicken Pita Doner (Duo)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(26.5, 27.5, "Chicken Pita Doner");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(27.5, 28.5, "Beef Pita Doner (Trio)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(28.5, 29.5, "Beef Pita Doner (Duo)");
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(29.5, 30.5, "Beef Pita Doner");

                area.AxisY.MajorTickMark.Interval = 1;
                chart1.Series.Clear();
                Series barSeries = new Series();
                barSeries.Points.Clear();
                barSeries.IsVisibleInLegend = false;
                barSeries.ChartType = SeriesChartType.Bar;
                barSeries.SetCustomProperty("PixelPointWidth", "10");
                barSeries.Points.DataBindXY(xData, yData);
                barSeries.Points[0].Label = ckpwd.ToString();
                barSeries.Points[1].Label = ckp.ToString();
                barSeries.Points[2].Label = bcpwd.ToString();
                barSeries.Points[3].Label = bcp.ToString();
                barSeries.Points[4].Label = bkpwd.ToString();
                barSeries.Points[5].Label = bkp.ToString();
                barSeries.Points[6].Label = cdswd.ToString();
                barSeries.Points[7].Label = cds.ToString();
                barSeries.Points[8].Label = bdswd.ToString();
                barSeries.Points[9].Label = bds.ToString();
                barSeries.Points[10].Label = hrwd.ToString();
                barSeries.Points[11].Label = hr.ToString();
                barSeries.Points[12].Label = korwd.ToString();
                barSeries.Points[13].Label = kor.ToString();
                barSeries.Points[14].Label = cdorwd.ToString();
                barSeries.Points[15].Label = cdor.ToString();
                barSeries.Points[16].Label = bdorwd.ToString();
                barSeries.Points[17].Label = bdor.ToString();
                barSeries.Points[18].Label = hwwfnd.ToString();
                barSeries.Points[19].Label = hwwd.ToString();
                barSeries.Points[20].Label = hw.ToString();
                barSeries.Points[21].Label = kwwfnd.ToString();
                barSeries.Points[22].Label = kwwd.ToString();
                barSeries.Points[23].Label = kw.ToString();
                barSeries.Points[24].Label = cpdwfnd.ToString();
                barSeries.Points[25].Label = cpdwd.ToString();
                barSeries.Points[26].Label = cpd.ToString();
                barSeries.Points[27].Label = bpdwfnd.ToString();
                barSeries.Points[28].Label = bpdwd.ToString();
                barSeries.Points[29].Label = bpd.ToString();
                barSeries.ChartArea = "First";
                chart1.Series.Add(barSeries);
                //barSeries.Color = Color.Orange;

                dailygraphs_layout.Controls.Add(chart1);

                myConnection = new SQLiteConnection("Data Source=database.sqlite3");
                string qry_time = "SELECT * FROM tbl_timetrans WHERE date = '" + date + "'";
                SQLiteCommand cmd_time = new SQLiteCommand(qry_time, myConnection);
                openConnection();
                SQLiteDataReader res_time = cmd_time.ExecuteReader();
                string[] times = new string[999];
                int i = 0;
                if (res_time.HasRows)
                {
                    while (res_time.Read())
                    {
                        times[i] = res_time["time"].ToString();
                        i++;
                    }
                }
                times = times.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                Chart chart2 = new Chart();
                chart2.Width = 700;
                chart2.Height = 500;
                dailygraphs_layout.Controls.Add(chart2);
                // chartArea
                chart2.ChartAreas.Clear();
                ChartArea area2 = new ChartArea("First");
                chart2.Titles.Add("Today's Sales Frequency");
                chart2.ChartAreas.Add(area2);
                chart2.ChartAreas["First"].Axes[0].MajorGrid.Enabled = true;//x axis
                //chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 13);
                chart2.ChartAreas["First"].AxisX.Interval = 1;
                chart2.ChartAreas["First"].Axes[1].MajorGrid.Enabled = true;//y axis

                chart2.ChartAreas["First"].AxisX.CustomLabels.Add(0.5, 1.5, "10am");
                chart2.ChartAreas["First"].AxisX.CustomLabels.Add(1.5, 2.5, "11am");
                chart2.ChartAreas["First"].AxisX.CustomLabels.Add(2.5, 3.5, "12am");
                chart2.ChartAreas["First"].AxisX.CustomLabels.Add(3.5, 4.5, "1pm");
                chart2.ChartAreas["First"].AxisX.CustomLabels.Add(4.5, 5.5, "2pm");
                chart2.ChartAreas["First"].AxisX.CustomLabels.Add(5.5, 6.5, "3pm");
                chart2.ChartAreas["First"].AxisX.CustomLabels.Add(6.5, 7.5, "4pm");
                chart2.ChartAreas["First"].AxisX.CustomLabels.Add(7.5, 8.5, "5pm");
                chart2.ChartAreas["First"].AxisX.CustomLabels.Add(8.5, 9.5, "6pm");
                chart2.ChartAreas["First"].AxisX.CustomLabels.Add(9.5, 10.5, "7pm");
                chart2.ChartAreas["First"].AxisX.CustomLabels.Add(10.5, 11.5, "8pm");
                chart2.ChartAreas["First"].AxisX.CustomLabels.Add(11.5, 12.5, "9pm");

                //Series
                Series series1 = new Series();
                chart2.Series.Add(series1);
                //Series style
                series1.ChartType = SeriesChartType.Line;  // type
                series1.BorderWidth = 2;
                series1.Color = Color.Green;

                int ten = 0;
                int ten15 = 0;
                int ten30 = 0;
                int ten45 = 0;
                int eleven = 0;
                int eleven15 = 0;
                int eleven30 = 0;
                int eleven45 = 0;
                int twelve = 0;
                int twelve15 = 0;
                int twelve30 = 0;
                int twelve45 = 0;
                int one = 0;
                int one15 = 0;
                int one30 = 0;
                int one45 = 0;
                int two = 0;
                int two15 = 0;
                int two30 = 0;
                int two45 = 0;
                int three = 0;
                int three15 = 0;
                int three30 = 0;
                int three45 = 0;
                int four = 0;
                int four15 = 0;
                int four30 = 0;
                int four45 = 0;
                int five = 0;
                int five15 = 0;
                int five30 = 0;
                int five45 = 0;
                int six = 0;
                int six15 = 0;
                int six30 = 0;
                int six45 = 0;
                int seven = 0;
                int seven15 = 0;
                int seven30 = 0;
                int seven45 = 0;
                int eight = 0;
                int eight15 = 0;
                int eight30 = 0;
                int eight45 = 0;

                for(i = 0; i < times.Length; i++)
                {
                    DateTime dateTime = DateTime.ParseExact(times[i], "h:mm tt", CultureInfo.InvariantCulture);
                    if (DateTime.ParseExact("10:00 AM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("10:15 AM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        ten++;
                    }
                    else if (DateTime.ParseExact("10:15 AM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("10:30 AM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        ten15++;
                    }
                    else if (DateTime.ParseExact("10:30 AM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("10:45 AM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        ten30++;
                    }
                    else if (DateTime.ParseExact("10:45 AM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("11:00 AM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        ten45++;
                    }
                    else if (DateTime.ParseExact("11:00 AM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("11:15 AM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        eleven++;
                    }
                    else if (DateTime.ParseExact("11:15 AM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("11:30 AM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        eleven15++;
                    }
                    else if (DateTime.ParseExact("11:30 AM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("11:45 AM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        eleven30++;
                    }
                    else if (DateTime.ParseExact("11:45 AM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("12:00 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        eleven45++;
                    }
                    else if (DateTime.ParseExact("12:00 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("12:15 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        twelve++;
                    }
                    else if (DateTime.ParseExact("12:15 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("12:30 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        twelve15++;
                    }
                    else if (DateTime.ParseExact("12:30 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("12:45 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        twelve30++;
                    }
                    else if (DateTime.ParseExact("12:45 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("1:00 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        twelve45++;
                    }
                    else if (DateTime.ParseExact("1:00 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("1:15 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        one++;
                    }
                    else if (DateTime.ParseExact("1:15 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("1:30 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        one15++;
                    }
                    else if (DateTime.ParseExact("1:30 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("1:45 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        one30++;
                    }
                    else if (DateTime.ParseExact("1:45 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("2:00 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        one45++;
                    }
                    else if (DateTime.ParseExact("2:00 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("2:15 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        two++;
                    }
                    else if (DateTime.ParseExact("2:15 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("2:30 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        two15++;
                    }
                    else if (DateTime.ParseExact("2:30 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("2:45 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        two30++;
                    }
                    else if (DateTime.ParseExact("2:45 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("3:00 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        two45++;
                    }
                    else if (DateTime.ParseExact("3:00 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("3:15 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        three++;
                    }
                    else if (DateTime.ParseExact("3:15 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("3:30 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        three15++;
                    }
                    else if (DateTime.ParseExact("3:30 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("3:45 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        three30++;
                    }
                    else if (DateTime.ParseExact("3:45 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("4:00 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        three45++;
                    }
                    else if (DateTime.ParseExact("4:00 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("4:15 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        four++;
                    }
                    else if (DateTime.ParseExact("4:15 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("4:30 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        four15++;
                    }
                    else if (DateTime.ParseExact("4:30 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("4:45 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        four30++;
                    }
                    else if (DateTime.ParseExact("4:45 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("5:00 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        four45++;
                    }
                    else if (DateTime.ParseExact("5:00 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("5:15 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        five++;
                    }
                    else if (DateTime.ParseExact("5:15 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("5:30 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        five15++;
                    }
                    else if (DateTime.ParseExact("5:30 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("5:45 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        five30++;
                    }
                    else if (DateTime.ParseExact("5:45 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("6:00 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        five45++;
                    }
                    else if (DateTime.ParseExact("6:00 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("6:15 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        six++;
                    }
                    else if (DateTime.ParseExact("6:15 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("6:30 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        six15++;
                    }
                    else if (DateTime.ParseExact("6:30 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("6:45 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        six30++;
                    }
                    else if (DateTime.ParseExact("6:45 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("7:00 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        six45++;
                    }
                    else if (DateTime.ParseExact("7:00 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("7:15 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        seven++;
                    }
                    else if (DateTime.ParseExact("7:15 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("7:30 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        seven15++;
                    }
                    else if (DateTime.ParseExact("7:30 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("7:45 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        seven30++;
                    }
                    else if (DateTime.ParseExact("7:45 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("8:00 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        seven45++;
                    }
                    else if (DateTime.ParseExact("8:00 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("8:15 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        eight++;
                    }
                    else if (DateTime.ParseExact("8:15 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("8:30 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        eight15++;
                    }
                    else if (DateTime.ParseExact("8:30 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("8:45 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        eight30++;
                    }
                    else if (DateTime.ParseExact("8:45 PM", "h:mm tt", CultureInfo.InvariantCulture) <= dateTime
                        && dateTime < DateTime.ParseExact("9:00 PM", "h:mm tt", CultureInfo.InvariantCulture))
                    {
                        eight45++;
                    }
                }

                List<int> ts = new List<int>();
                ts.Add(ten);
                ts.Add(ten15);
                ts.Add(ten30);
                ts.Add(ten45);
                ts.Add(eleven);
                ts.Add(eleven15);
                ts.Add(eleven30);
                ts.Add(eleven45);
                ts.Add(twelve);
                ts.Add(twelve15);
                ts.Add(twelve30);
                ts.Add(twelve45);
                ts.Add(one);
                ts.Add(one15);
                ts.Add(one30);
                ts.Add(one45);
                ts.Add(two);
                ts.Add(two15);
                ts.Add(two30);
                ts.Add(two45);
                ts.Add(three);
                ts.Add(three15);
                ts.Add(three30);
                ts.Add(three45);
                ts.Add(four);
                ts.Add(four15);
                ts.Add(four30);
                ts.Add(four45);
                ts.Add(five);
                ts.Add(five15);
                ts.Add(five30);
                ts.Add(five45);
                ts.Add(six);
                ts.Add(six15);
                ts.Add(six30);
                ts.Add(six45);
                ts.Add(seven);
                ts.Add(seven15);
                ts.Add(seven30);
                ts.Add(seven45);
                ts.Add(eight);
                ts.Add(eight15);
                ts.Add(eight30);
                ts.Add(eight45);

                int[] tpoints = ts.ToArray();

                double j = 1;
                for (i = 0; i < tpoints.Length ; i++)
                {
                    series1.Points.AddXY(j, tpoints[i]);
                    j += 0.25;
                    series1.Points[i].Label = tpoints[i].ToString();
                }

                //series1.Points.AddXY(1, 7);
                //series1.Points.AddXY(1.25, 3);
                //series1.Points.AddXY(1.5, 4);
                //series1.Points.AddXY(1.75, 9);
                //series1.Points.AddXY(2, 3);
                //series1.Points.AddXY(2.25, 6);
                //series1.Points.AddXY(2.5, 8);
                //series1.Points.AddXY(2.75, 3);
                //series1.Points.AddXY(3, 2);
                //series1.Points.AddXY(3.25, 6);
                //series1.Points.AddXY(3.5, 7);
                //series1.Points.AddXY(3.75, 4);
                //series1.Points.AddXY(4, 6);
                //series1.Points.AddXY(4.25, 3);
                //series1.Points.AddXY(4.5, 2);
                //series1.Points.AddXY(4.75, 12);
                //series1.Points.AddXY(5, 14);
                //series1.Points.AddXY(5.25, 9);
                //series1.Points.AddXY(5.5, 16);
                //series1.Points.AddXY(5.75, 18);
                //series1.Points.AddXY(6, 20);
                //series1.Points.AddXY(6.25, 17);
                //series1.Points.AddXY(6.5, 23);
                //series1.Points.AddXY(6.75, 16);
                //series1.Points.AddXY(7, 12);
                //series1.Points.AddXY(7.25, 9);
                //series1.Points.AddXY(7.5, 12);
                //series1.Points.AddXY(7.75, 8);
                //series1.Points.AddXY(8, 8);
                //series1.Points.AddXY(8.25, 6);
                //series1.Points.AddXY(8.5, 7);
                //series1.Points.AddXY(8.75, 9);
                //series1.Points.AddXY(9, 4);
                //series1.Points.AddXY(9.25, 2);
                //series1.Points.AddXY(9.5, 6);
                //series1.Points.AddXY(9.75, 1);
                //series1.Points.AddXY(10, 4);
                //series1.Points.AddXY(10.25, 5);
                //series1.Points.AddXY(10.5, 8);
                //series1.Points.AddXY(10.75, 7);
                //series1.Points.AddXY(11, 11);
                //series1.Points.AddXY(11.25, 14);
                //series1.Points.AddXY(11.5, 16);
                //series1.Points.AddXY(11.75, 14);
                //series1.Points.AddXY(12, 12);
                //series1.Points.AddXY(12.25, 15);
                //series1.Points.AddXY(12.5, 8);
                //series1.Points.AddXY(12.75, 4);
            }
            else
            {
                dailygraphs_layout.Controls.Clear();
                btn_update.Visible = false;
                lbl_none.Visible = true;
                btn_create.Visible = true;
            }
            closeConnection();
        }

        public void openConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
                myConnection.Open();
        }

        public void closeConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
                myConnection.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string qry_date = "SELECT COUNT(*) FROM tbl_cashdem WHERE date = '" + d + "'";
            SQLiteCommand cmd_date = new SQLiteCommand(qry_date, myConnection);
            openConnection();
            int check_date = Convert.ToInt32(cmd_date.ExecuteScalar());
            //string x1 = cash_dem.qty_1000.Text; string x2 = cash_dem.qty_500.Text; string x3 = cash_dem.qty_200.Text; string x4 = cash_dem.qty_100.Text;
            //string x5 = cash_dem.qty_50.Text; string x6 = cash_dem.qty_20.Text; string x7 = cash_dem.qty_10.Text; string x8 = cash_dem.qty_5.Text; string x9 = cash_dem.qty_1.Text;
            //string x10 = cash_dem.qty_25.Text; string x11 = cash_dem.txt_deposit.Text; string x12 = cash_dem.txt_pita.Text; string x13 = cash_dem.txt_pitaduo.Text;
            //string x14 = cash_dem.txt_trio.Text; string x15 = cash_dem.txt_rice.Text; string x16 = cash_dem.txt_riceduo.Text; string x17 = cash_dem.txt_bsteaksolo.Text;
            //string x18 = cash_dem.txt_csteaksolo.Text; string x19 = cash_dem.txt_bsteakduo.Text; string x20 = cash_dem.txt_csteakduo.Text; string x21 = cash_dem.txt_platter.Text;
            //string x22 = cash_dem.txt_platterduo.Text; string x23 = cash_dem.txt_cheese.Text; string x24 = cash_dem.txt_fries.Text; string x25 = cash_dem.txt_extrarice.Text;
            //string x26 = cash_dem.txt_water.Text; string x27 = cash_dem.txt_lemtea.Text; string x28 = cash_dem.txt_soda.Text; string x29 = cash_dem.item1.Text; string x30 = cash_dem.item2.Text;
            //string x31 = cash_dem.item3.Text; string x32 = cash_dem.item4.Text; string x33 = cash_dem.item5.Text; string x34 = cash_dem.item6.Text; string x35 = cash_dem.item7.Text;
            //string x36 = cash_dem.item8.Text; string x37 = cash_dem.item9.Text; string x38 = cash_dem.amt1.Text; string x39 = cash_dem.amt2.Text; string x40 = cash_dem.amt3.Text;
            //string x41 = cash_dem.amt4.Text; string x42 = cash_dem.amt5.Text; string x43 = cash_dem.amt6.Text; string x44 = cash_dem.amt7.Text; string x45 = cash_dem.amt8.Text; string x46 = cash_dem.amt9.Text;

            string x1 = cash_dem.qty_1000.Text; string x2 = cash_dem.qty_500.Text; string x3 = cash_dem.qty_200.Text; string x4 = cash_dem.qty_100.Text;
            string x5 = cash_dem.qty_50.Text; string x6 = cash_dem.qty_20.Text; string x7 = cash_dem.qty_10.Text; string x8 = cash_dem.qty_5.Text; string x9 = cash_dem.qty_1.Text;
            string x10 = cash_dem.qty_25.Text; string x11 = cash_dem.txt_deposit.Text; string x12 = cash_dem.txt_pita.Text; string x13 = cash_dem.txt_pitaduo.Text;
            string x14 = cash_dem.txt_trio.Text; string x15 = cash_dem.txt_rice.Text; string x16 = cash_dem.txt_riceduo.Text; string x19 = cash_dem.txt_steak.Text; string x20 = cash_dem.txt_steakduo.Text; string x21 = cash_dem.txt_platter.Text;
            string x22 = cash_dem.txt_platterduo.Text; string x23 = cash_dem.txt_cheese.Text; string x24 = cash_dem.txt_fries.Text; string x25 = cash_dem.txt_extrarice.Text;
            string x26 = cash_dem.txt_water.Text; string x27 = cash_dem.txt_softdrinks.Text; string x28 = cash_dem.txt_soda.Text; string x29 = cash_dem.item1.Text; string x30 = cash_dem.item2.Text;
            string x31 = cash_dem.item3.Text; string x32 = cash_dem.item4.Text; string x33 = cash_dem.item5.Text; string x34 = cash_dem.item6.Text; string x35 = cash_dem.item7.Text;
            string x36 = cash_dem.item8.Text; string x37 = cash_dem.item9.Text; string x38 = cash_dem.amt1.Text; string x39 = cash_dem.amt2.Text; string x40 = cash_dem.amt3.Text;
            string x41 = cash_dem.amt4.Text; string x42 = cash_dem.amt5.Text; string x43 = cash_dem.amt6.Text; string x44 = cash_dem.amt7.Text; string x45 = cash_dem.amt8.Text; string x46 = cash_dem.amt9.Text;

            if (check_date == 0)
            {
                //CREATE TBL_CASHDEM
                string qry_trans = "INSERT INTO tbl_cashdem ('date', 'x1', 'x2', 'x3', 'x4', 'x5', 'x6', 'x7', 'x8', 'x9', 'x10', 'x11', 'x12', 'x13', 'x14', 'x15', 'x16', 'x17', 'x18', 'x19', 'x20', 'x21', 'x22', 'x23', 'x24', 'x25', 'x26', 'x27', 'x28', 'x29', 'x30', 'x31', 'x32', 'x33', 'x34', 'x35', 'x36', 'x37', 'x38', 'x39', 'x40', 'x41', 'x42', 'x43', 'x44', 'x45', 'x46') " +
                                        "VALUES (@date, @x1, @x2, @x3, @x4, @x5, @x6, @x7, @x8, @x9, @x10, @x11, @x12, @x13, @x14, @x15, @x16, @x17, @x18, @x19, @x20, @x21, @x22, @x23, @x24, @x25, @x26, @x27, @x28, @x29, @x30, @x31, @x32, @x33, @x34, @x35, @x36, @x37, @x38, @x39, @x40, @x41, @x42, @x43, @x44, @x45, @x46)";
                SQLiteCommand cmd_trans = new SQLiteCommand(qry_trans, myConnection);
                openConnection();
                cmd_trans.Parameters.AddWithValue("@date", d);
                cmd_trans.Parameters.AddWithValue("@x1", x1);
                cmd_trans.Parameters.AddWithValue("@x2", x2);
                cmd_trans.Parameters.AddWithValue("@x3", x3);
                cmd_trans.Parameters.AddWithValue("@x4", x4);
                cmd_trans.Parameters.AddWithValue("@x5", x5);
                cmd_trans.Parameters.AddWithValue("@x6", x6);
                cmd_trans.Parameters.AddWithValue("@x7", x7);
                cmd_trans.Parameters.AddWithValue("@x8", x8);
                cmd_trans.Parameters.AddWithValue("@x9", x9);
                cmd_trans.Parameters.AddWithValue("@x10", x10);
                cmd_trans.Parameters.AddWithValue("@x11", x11);
                cmd_trans.Parameters.AddWithValue("@x12", x12);
                cmd_trans.Parameters.AddWithValue("@x13", x13);
                cmd_trans.Parameters.AddWithValue("@x14", x14);
                cmd_trans.Parameters.AddWithValue("@x15", x15);
                cmd_trans.Parameters.AddWithValue("@x16", x16);
                //cmd_trans.Parameters.AddWithValue("@x17", x17);
                //cmd_trans.Parameters.AddWithValue("@x18", x18);
                cmd_trans.Parameters.AddWithValue("@x19", x19);
                cmd_trans.Parameters.AddWithValue("@x20", x20);
                cmd_trans.Parameters.AddWithValue("@x21", x21);
                cmd_trans.Parameters.AddWithValue("@x22", x22);
                cmd_trans.Parameters.AddWithValue("@x23", x23);
                cmd_trans.Parameters.AddWithValue("@x24", x24);
                cmd_trans.Parameters.AddWithValue("@x25", x25);
                cmd_trans.Parameters.AddWithValue("@x26", x26);
                cmd_trans.Parameters.AddWithValue("@x27", x27);
                cmd_trans.Parameters.AddWithValue("@x28", x28);
                cmd_trans.Parameters.AddWithValue("@x29", x29);
                cmd_trans.Parameters.AddWithValue("@x30", x30);
                cmd_trans.Parameters.AddWithValue("@x31", x31);
                cmd_trans.Parameters.AddWithValue("@x32", x32);
                cmd_trans.Parameters.AddWithValue("@x33", x33);
                cmd_trans.Parameters.AddWithValue("@x34", x34);
                cmd_trans.Parameters.AddWithValue("@x35", x35);
                cmd_trans.Parameters.AddWithValue("@x36", x36);
                cmd_trans.Parameters.AddWithValue("@x37", x37);
                cmd_trans.Parameters.AddWithValue("@x38", x38);
                cmd_trans.Parameters.AddWithValue("@x39", x39);
                cmd_trans.Parameters.AddWithValue("@x40", x40);
                cmd_trans.Parameters.AddWithValue("@x41", x41);
                cmd_trans.Parameters.AddWithValue("@x42", x42);
                cmd_trans.Parameters.AddWithValue("@x43", x43);
                cmd_trans.Parameters.AddWithValue("@x44", x44);
                cmd_trans.Parameters.AddWithValue("@x45", x45);
                cmd_trans.Parameters.AddWithValue("@x46", x46);
                var res_trans = cmd_trans.ExecuteNonQuery();
            }
            else
            {
                string qry3 = "UPDATE tbl_cashdem SET x1 = '" + x1 + "', x2 = '" + x2 + "', x3 = '" + x3 + "', x4 = '" + x4 + "', x5 = '" + x5 + "', x6 = '" + x6 + "', x7 = '" + x7 + "', x8 = '" + x8 + "', x9 = '" + x9 + "', x10 = '" + x10 + "', x11 = '" + x11 + "', x12 = '" + x12 + "', x13 = '" + x13 + "', x14 = '" + x14 + "', x15 = '" + x15 + "', x16 = '" + x16 + /*"', x17 = '" + x17 + "', x18 = '" + x18 + */"', x19 = '" + x19 + "', x20 = '" + x20 + "', x21 = '" + x21 + "', x22 = '" + x22 + "', x23 = '" + x23 + "', x24 = '" + x24 + "', x25 = '" + x25 + "', x26 = '" + x26 + "', x27 = '" + x27 + "', x28 = '" + x28 + "', x29 = '" + x29 + "', x30 = '" + x30 + "', x31 = '" + x31 + "', x32 = '" + x32 + "', x33 = '" + x33 + "', x34 = '" + x34 + "', x35 = '" + x35 + "', x36 = '" + x36 + "', x37 = '" + x37 + "', x38 = '" + x38 + "', x39 = '" + x39 + "', x40 = '" + x40 + "', x41 = '" + x41 + "', x42 = '" + x42 + "', x43 = '" + x43 + "', x44 = '" + x44 + "', x45 = '" + x45 + "', x46 = '" + x46 + "' WHERE date = '" + d + "'";
                SQLiteCommand myCommand3 = new SQLiteCommand(qry3, myConnection);
                myCommand3.ExecuteNonQuery();
            }

            string riceout = inv_pita.inp_riceout.Text;
            string qry = "SELECT * FROM tbl_transactions WHERE date = '" + d + "'";
            SQLiteCommand cmd = new SQLiteCommand(qry, myConnection);
            SQLiteDataReader result = cmd.ExecuteReader();
            string rice = "";
            int r = 0;
            if (result.HasRows)
            {
                while (result.Read())
                {
                    rice = result["riceout"].ToString();
                }
            }

            if(riceout == string.Empty || riceout == "" || riceout == null)
            {
                riceout = "0";
            }
            else
            {
                r = Convert.ToInt32(riceout);
            }
            DateTime data = DateTime.ParseExact(d, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string yesterday = data.AddDays(-1).ToString("dd/MM/yyyy");
            if (rice == "0" || rice == "" || rice == null || rice == string.Empty)
            {
                string qry_upd = "UPDATE tbl_transactions SET riceout = '" + riceout + "' WHERE date = '" + d + "'";
                SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                cmd_upd.ExecuteNonQuery();

                string qry_upd2 = "UPDATE tbl_ingredients SET in_stock = in_stock - '" + r + "' WHERE in_name = 'Rice'";
                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                cmd_upd2.ExecuteNonQuery();

                string qry_update = "UPDATE tbl_insandlos " +
                                        "SET ricepresentlo = (" +
                                        "SELECT in_stock " +
                                        "FROM tbl_ingredients " +
                                        "WHERE in_name = 'Rice'" +
                                        ") WHERE date = '" + d + "'";
                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_update, myConnection);
                cmd_upd3.ExecuteNonQuery();

                string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET ricepastlo = (" +
                                        "SELECT ricepresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + d + "'";
                SQLiteCommand cmd_upd4 = new SQLiteCommand(qry_update2, myConnection);
                cmd_upd4.ExecuteNonQuery();
            }

            closeConnection();

            items_inv_layout.Controls.Clear();
            cash_dem_layout.Controls.Clear();
            items_inv_layout.Controls.Add(inv_pita);
            cash_dem_layout.Controls.Add(cash_dem);

            MessageBox.Show("Update successful!");
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            string date = datesel;
            DateTime data = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string yesterday = data.AddDays(-1).ToString("dd/MM/yyyy");
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            string qry = "SELECT * FROM tbl_ingredients";
            string qry2 = "SELECT COUNT(*) FROM tbl_ingredients";
            SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
            SQLiteCommand myCommand2 = new SQLiteCommand(qry2, myConnection);
            openConnection();
            SQLiteDataReader result = myCommand.ExecuteReader();
            int cnt = Convert.ToInt32(myCommand2.ExecuteScalar());
            string[] name = new string[cnt];
            int[] stock = new int[cnt];
            int i = 0;
            if (result.HasRows)
            {
                while (result.Read())
                {
                    name[i] = result["in_name"].ToString();
                    stock[i] = Convert.ToInt32(result["in_stock"]);
                    i++;
                }
            }
            //string toDisplay = string.Join(Environment.NewLine, name);
            //MessageBox.Show(toDisplay);
            foreach (string s in name)
            {
                if (s == "Pita")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                        "SET pitapresentlo = (" +
                                        "SELECT in_stock " +
                                        "FROM tbl_ingredients " +
                                        "WHERE in_name = '" + s + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET pitapastlo = (" +
                                        "SELECT pitapresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                else if (s == "Beef")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                        "SET beefpresentlo = (" +
                                        "SELECT in_stock " +
                                        "FROM tbl_ingredients " +
                                        "WHERE in_name = '" + s + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET beefpastlo = (" +
                                        "SELECT beefpresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                else if (s == "Chicken")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                        "SET chickenpresentlo = (" +
                                        "SELECT in_stock " +
                                        "FROM tbl_ingredients " +
                                        "WHERE in_name = '" + s + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET chickenpastlo = (" +
                                        "SELECT chickenpresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                else if (s == "Cheddar Cheese")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                        "SET cheesepresentlo = (" +
                                        "SELECT in_stock " +
                                        "FROM tbl_ingredients " +
                                        "WHERE in_name = '" + s + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET cheesepastlo = (" +
                                        "SELECT cheesepresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                /*else if (s == "Rice")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                        "SET ricepresentlo = (" +
                                        "SELECT in_stock " +
                                        "FROM tbl_ingredients " +
                                        "WHERE in_name = '" + s + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();
                }*/
                else if (s == "Coke")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                        "SET sodapresentlo = (" +
                                        "SELECT in_stock " +
                                        "FROM tbl_ingredients " +
                                        "WHERE in_name = '" + s + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET sodapastlo = (" +
                                        "SELECT sodapresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                else if (s == "Sprite")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                        "SET sodapresentlo = (" +
                                        "SELECT in_stock " +
                                        "FROM tbl_ingredients " +
                                        "WHERE in_name = '" + s + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET sodapastlo = (" +
                                        "SELECT sodapresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                else if (s == "Royal")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                        "SET sodapresentlo = (" +
                                        "SELECT in_stock " +
                                        "FROM tbl_ingredients " +
                                        "WHERE in_name = '" + s + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET sodapastlo = (" +
                                        "SELECT sodapresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                else if (s == "Kebab")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                        "SET kebabpresentlo = (" +
                                        "SELECT in_stock " +
                                        "FROM tbl_ingredients " +
                                        "WHERE in_name = '" + s + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET kebabpastlo = (" +
                                        "SELECT kebabpresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                else if (s == "Hotdog")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                        "SET hotdogpresentlo = (" +
                                        "SELECT in_stock " +
                                        "FROM tbl_ingredients " +
                                        "WHERE in_name = '" + s + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET hotdogpastlo = (" +
                                        "SELECT hotdogpresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                else if (s == "Beef Steak")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                        "SET bsteakpresentlo = (" +
                                        "SELECT in_stock " +
                                        "FROM tbl_ingredients " +
                                        "WHERE in_name = '" + s + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET bsteakpastlo = (" +
                                        "SELECT bsteakpresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                else if (s == "Chicken Steak")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                        "SET csteakpresentlo = (" +
                                        "SELECT in_stock " +
                                        "FROM tbl_ingredients " +
                                        "WHERE in_name = '" + s + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET csteakpastlo = (" +
                                        "SELECT csteakpresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                else if (s == "Mini Pita")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                        "SET minipitapresentlo = (" +
                                        "SELECT in_stock " +
                                        "FROM tbl_ingredients " +
                                        "WHERE in_name = '" + s + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET minipitapastlo = (" +
                                        "SELECT minipitapresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                else if (s == "Water")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                        "SET waterpresentlo = (" +
                                        "SELECT in_stock " +
                                        "FROM tbl_ingredients " +
                                        "WHERE in_name = '" + s + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET waterpastlo = (" +
                                        "SELECT waterpresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
            }

            string qry3 = "SELECT * FROM tbl_materials";
            string qry4 = "SELECT COUNT(*) FROM tbl_materials";
            SQLiteCommand myCommand3 = new SQLiteCommand(qry3, myConnection);
            SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
            openConnection();
            SQLiteDataReader result2 = myCommand3.ExecuteReader();
            int cnt2 = Convert.ToInt32(myCommand4.ExecuteScalar());
            string[] name2 = new string[cnt2];
            int[] stock2 = new int[cnt2];
            int i2 = 0;
            if (result2.HasRows)
            {
                while (result2.Read())
                {
                    name[i2] = result2["mat_name"].ToString();
                    stock[i2] = Convert.ToInt32(result2["mat_stock"]);
                    i2++;
                }
            }

            foreach (string s in name)
            {
                if (s == "Cones")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                    "SET conespresentlo = (" +
                                    "SELECT mat_stock " +
                                    "FROM tbl_materials " +
                                    "WHERE mat_name = '" + s + "'" +
                                    ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET conespastlo = (" +
                                        "SELECT conespresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                else if (s == "Meal Box")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                    "SET mealboxpresentlo = (" +
                                    "SELECT mat_stock " +
                                    "FROM tbl_materials " +
                                    "WHERE mat_name = '" + s + "'" +
                                    ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET mealboxpastlo = (" +
                                        "SELECT mealboxpresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                else if (s == "Platter Box")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                    "SET platterboxpresentlo = (" +
                                    "SELECT mat_stock " +
                                    "FROM tbl_materials " +
                                    "WHERE mat_name = '" + s + "'" +
                                    ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET platterboxpastlo = (" +
                                        "SELECT platterboxpresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                else if (s == "Fries Bags")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                    "SET friesbagspresentlo = (" +
                                    "SELECT mat_stock " +
                                    "FROM tbl_materials " +
                                    "WHERE mat_name = '" + s + "'" +
                                    ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET friesbagspastlo = (" +
                                        "SELECT friesbagspresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                else if (s == "Cups")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                    "SET cupspresentlo = (" +
                                    "SELECT mat_stock " +
                                    "FROM tbl_materials " +
                                    "WHERE mat_name = '" + s + "'" +
                                    ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET cupspastlo = (" +
                                        "SELECT cupspresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
                else if (s == "Mini Cups")
                {
                    string qry_update = "UPDATE tbl_insandlos " +
                                    "SET minicupspresentlo = (" +
                                    "SELECT mat_stock " +
                                    "FROM tbl_materials " +
                                    "WHERE mat_name = '" + s + "'" +
                                    ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd = new SQLiteCommand(qry_update, myConnection);
                    cmd_upd.ExecuteNonQuery();

                    string qry_update2 = "UPDATE tbl_insandlos " +
                                        "SET minicupspastlo = (" +
                                        "SELECT minicupspresentlo " +
                                        "FROM tbl_insandlos " +
                                        "WHERE date = '" + yesterday + "'" +
                                        ") WHERE date = '" + date + "'";
                    SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_update2, myConnection);
                    cmd_upd2.ExecuteNonQuery();
                }
            }
            string qry_rep = "UPDATE tbl_transactions SET reported = 'reported' WHERE date = '" + date + "'";
            SQLiteCommand cmd_rep = new SQLiteCommand(qry_rep, myConnection);
            cmd_rep.ExecuteNonQuery();

            closeConnection();

            dispRep();
        }

        Login frm;
        public string sen;
        private void btn_seldate_Click(object sender, EventArgs e)
        {
            sen = (sender as Button).Name;
            using (DatePick dp = new DatePick())
            {
                dp.Sen = sen;
                dp.Owner = frm;
                dp.StartPosition = FormStartPosition.CenterParent;
                if (dp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    datesel = dp.Date;
                    dispRep();
                }
            }
        }
        
        private void btn_seldate2_Click(object sender, EventArgs e)
        {
            sen = (sender as Button).Name;
            using (DatePick dp = new DatePick())
            {
                dp.Sen = sen;
                dp.Owner = frm;
                dp.StartPosition = FormStartPosition.CenterParent;
                if (dp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    weeksel = dp.WeekDays;
                    dispWeek();
                }
            }
        }

        void dispWeek()
        {
            string[] dates = weeksel.Split(',');
            int[] totalsales = new int[dates.Length];
            for (int i = 0; i<dates.Length; i++)
            {
                myConnection = new SQLiteConnection("Data Source=database.sqlite3");
                string qry = "SELECT * FROM tbl_transactions WHERE date = '"+ dates[i] +"'";
                string qry2 = "SELECT COUNT(*) FROM tbl_transactions WHERE date = '" + dates[i] + "'";
                SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
                SQLiteCommand myCommand2 = new SQLiteCommand(qry2, myConnection);
                openConnection();
                SQLiteDataReader result = myCommand.ExecuteReader();
                int cnt = Convert.ToInt32(myCommand2.ExecuteScalar());
                if(cnt == 0)
                {
                    totalsales[i] = 0;
                }
                else
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            totalsales[i] = Convert.ToInt32(result["total_sales"]);
                        }
                    }
                }
            }

            //var message = string.Join(",", totalsales);
            //MessageBox.Show(message);

            weeklygraphs_layout.Controls.Clear();
            
            Chart chart1 = new Chart();
            chart1.Width = 700;
            chart1.Height = 500;
            weeklygraphs_layout.Controls.Add(chart1);
            // chartArea
            chart1.ChartAreas.Clear();
            ChartArea area = new ChartArea("First");
            chart1.Titles.Add("Week's Total Sales");
            chart1.ChartAreas.Add(area);
            chart1.ChartAreas["First"].AxisX.Maximum = 6;
            chart1.ChartAreas["First"].Axes[0].MajorGrid.Enabled = false;//x axis
            //chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 13);
            chart1.ChartAreas["First"].AxisX.Interval = 1;
            chart1.ChartAreas["First"].Axes[1].MajorGrid.Enabled = true;//y axis

            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(0.5, 1.5, "Sunday");
            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(1.5, 2.5, "Monday");
            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(2.5, 3.5, "Tuesday");
            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(3.5, 4.5, "Wednesday");
            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(4.5, 5.5, "Thursday");
            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(5.5, 6.5, "Friday");

            //Series
            Series series1 = new Series();
            chart1.Series.Add(series1);
            //Series style
            series1.ChartType = SeriesChartType.Line;  // type
            series1.BorderWidth = 2;
            series1.Color = Color.Green;
            
            for (int i = 0; i<totalsales.Length; i++)
            {
                series1.Points.AddXY(i + 1, totalsales[i]);
                series1.Points[i].Label = "P" + totalsales[i].ToString();
            }
        }

        private void monthly_cbyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            monthly_cbmonth.Visible = true;
            monthly_cbmonth.Items.Clear();

            System.Object[] ItemObject = new System.Object[12];
            ItemObject[0] = "January";
            ItemObject[1] = "February";
            ItemObject[2] = "March";
            ItemObject[3] = "April";
            ItemObject[4] = "May";
            ItemObject[5] = "June";
            ItemObject[6] = "July";
            ItemObject[7] = "August";
            ItemObject[8] = "September";
            ItemObject[9] = "October";
            ItemObject[10] = "November";
            ItemObject[11] = "December";
            monthly_cbmonth.Items.AddRange(ItemObject);
        }

        private void monthly_cbmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string month = monthly_cbmonth.GetItemText(monthly_cbmonth.SelectedItem);
            string m = (DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month).ToString();
            if (Convert.ToInt32(m) < 10)
            {
                m = "0" + m;
            }
            string y = monthly_cbyear.GetItemText(monthly_cbyear.SelectedItem);
            string date = m + "/" + y;

            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            string qry = "SELECT * FROM tbl_transactions";
            SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
            string[] dates = new string[999];
            string[] days = new string[100];
            int i = 0;
            openConnection();
            SQLiteDataReader result = myCommand.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    if (Regex.Matches(result["date"].ToString(), date).Count == 1)
                    {
                        dates[i] = result["date"].ToString();
                        days[i] = dates[i].Substring(0, 2);
                        i++;
                    }
                }
            }
            dates = dates.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            days = days.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            int[] totalsales = new int[dates.Length];
            for (i = 0; i < dates.Length; i++)
            {
                myConnection = new SQLiteConnection("Data Source=database.sqlite3");
                string qry2 = "SELECT * FROM tbl_transactions WHERE date = '" + dates[i] + "'";
                SQLiteCommand myCommand2 = new SQLiteCommand(qry2, myConnection);
                openConnection();
                SQLiteDataReader result2 = myCommand2.ExecuteReader();
                if (result2.HasRows)
                {
                    while (result2.Read())
                    {
                        totalsales[i] = Convert.ToInt32(result2["total_sales"]);
                    }
                }
            }

            monthlygraphs_layout.Controls.Clear();

            Chart chart1 = new Chart();
            chart1.Width = 700;
            chart1.Height = 500;
            monthlygraphs_layout.Controls.Add(chart1);
            // chartArea
            chart1.ChartAreas.Clear();
            ChartArea area = new ChartArea("First");
            chart1.Titles.Add("Month's Total Sales");
            chart1.ChartAreas.Add(area);
            chart1.ChartAreas["First"].Axes[0].MajorGrid.Enabled = false;//x axis
            //chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 13);
            chart1.ChartAreas["First"].AxisX.Interval = 1;
            chart1.ChartAreas["First"].Axes[1].MajorGrid.Enabled = true;//y axis

            double j = 0.5;
            for(i = 0; i < days.Length; i++)
            {
                chart1.ChartAreas["First"].AxisX.CustomLabels.Add(j, j+1, days[i]);
                j++;
            }

            //Series
            Series series1 = new Series();
            chart1.Series.Add(series1);
            //Series style
            series1.ChartType = SeriesChartType.Line;  // type
            series1.BorderWidth = 2;
            series1.Color = Color.Green;

            for (i = 0; i < totalsales.Length; i++)
            {
                series1.Points.AddXY(i + 1, totalsales[i]);
                series1.Points[i].Label = "P" + totalsales[i].ToString();
            }
        }

        private void yearly_cbyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string year = yearly_cbyear.GetItemText(yearly_cbyear.SelectedItem);

            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            string qry = "SELECT * FROM tbl_transactions";
            SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
            string[] dates = new string[999];
            int i = 0;
            openConnection();
            SQLiteDataReader result = myCommand.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    if (Regex.Matches(result["date"].ToString(), year).Count == 1)
                    {
                        dates[i] = result["date"].ToString();
                        i++;
                    }
                }
            }
            dates = dates.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string[] dates2 = new string[999];
            for(i = 0; i<dates.Length; i++)
            {
                dates2[i] = dates[i].Substring(3, 7);
            }
            dates2 = dates2.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            string[] same = new string[12];
            string[] same2 = dates2.Distinct().ToArray();
            for(i = 0; i<same2.Length; i++)
            {
                same[i] = same2[i];
            }
            for(i = 0; i < 12; i++)
            {
                if (same[i] == null)
                    same[i] = "space";
            }

            List<string> list = dates.ToList<string>();
            list.Add("!@#$");
            string[] dates1 = list.ToArray();
            int[] totalsales = new int[12];
            string dates3 = "";
            i = 0;
            int j = 0;
            int total = 0;
            while (j < totalsales.Length)
            {
                if (same[j] != "space")
                {
                    if (Regex.Matches(dates1[i], same[j]).Count == 1)
                    {
                        dates3 = dates1[i];

                        myConnection = new SQLiteConnection("Data Source=database.sqlite3");
                        string qry2 = "SELECT * FROM tbl_transactions WHERE date = '" + dates3 + "'";
                        SQLiteCommand myCommand2 = new SQLiteCommand(qry2, myConnection);
                        openConnection();
                        SQLiteDataReader result2 = myCommand2.ExecuteReader();
                        if (result2.HasRows)
                        {
                            while (result2.Read())
                            {
                                total += Convert.ToInt32(result2["total_sales"]);
                            }
                        }
                        i++;
                    }
                    else
                    {
                        totalsales[j] = total;
                        j++;
                        total = 0;
                    }
                }
                else if (same[j] == "space")
                {
                    totalsales[j] = 0;
                    j++;
                }
            }

            //string toDisplay = string.Join("\n", totalsales);
            //MessageBox.Show(toDisplay);

            yearlygraphs_layout.Controls.Clear();

            Chart chart1 = new Chart();
            chart1.Width = 700;
            chart1.Height = 500;
            yearlygraphs_layout.Controls.Add(chart1);
            // chartArea
            chart1.ChartAreas.Clear();
            ChartArea area = new ChartArea("First");
            chart1.Titles.Add("Year's Total Sales");
            chart1.ChartAreas.Add(area);
            chart1.ChartAreas["First"].Axes[0].MajorGrid.Enabled = false;//x axis
            //chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 13);
            chart1.ChartAreas["First"].AxisX.Interval = 1;
            chart1.ChartAreas["First"].Axes[1].MajorGrid.Enabled = true;//y axis

            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(0.5, 1.5, "Jan");
            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(1.5, 2.5, "Feb");
            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(2.5, 3.5, "Mar");
            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(3.5, 4.5, "Apr");
            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(4.5, 5.5, "May");
            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(5.5, 6.5, "Jun");
            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(6.5, 7.5, "Jul");
            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(7.5, 8.5, "Aug");
            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(8.5, 9.5, "Sep");
            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(9.5, 10.5, "Oct");
            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(10.5, 11.5, "Nov");
            chart1.ChartAreas["First"].AxisX.CustomLabels.Add(11.5, 12.5, "Dec");

            //Series
            Series series1 = new Series();
            chart1.Series.Add(series1);
            //Series style
            series1.ChartType = SeriesChartType.Line;  // type
            series1.BorderWidth = 2;
            series1.Color = Color.Green;

            for (i = 0; i < totalsales.Length; i++)
            {
                series1.Points.AddXY(i + 1, totalsales[i]);
                series1.Points[i].Label = "P" + totalsales[i].ToString();
            }
        }
    }
}
