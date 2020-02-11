using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turks_POS_System
{
    public partial class Cash_Dem : UserControl
    {
        private double ototal;

        public Cash_Dem()
        {
            InitializeComponent();
            lbl_amount1000.Text = "0";
            lbl_amount500.Text = "0";
            lbl_amount200.Text = "0";
            lbl_amount100.Text = "0";
            lbl_amount50.Text = "0";
            lbl_amount20.Text = "0";
            lbl_amount10.Text = "0";
            lbl_amount5.Text = "0";
            lbl_amount1.Text = "0";
            lbl_amount025.Text = "0";
            lbl_billssub.Text = "0";
            lbl_coinssub.Text = "0";
            lbl_coh.Text = "0";
            lbl_total.Text = "";
            lbl_totalall.Text = "0";
            total_amt.Text = "0";
            total_amt.Visible = false;

            lbl_amount1000.Visible = false;
            lbl_amount500.Visible = false;
            lbl_amount200.Visible = false;
            lbl_amount100.Visible = false;
            lbl_amount50.Visible = false;
            lbl_amount20.Visible = false;
            lbl_amount10.Visible = false;
            lbl_amount5.Visible = false;
            lbl_amount1.Visible = false;
            lbl_amount025.Visible = false;
            lbl_billssub.Visible = false;
            lbl_coinssub.Visible = false;
            lbl_coh.Visible = false;
            lbl_total.Text = "";

            lbl_pitascdpwd.Text = "0";
            lbl_pitavat.Text = "0";
            lbl_pitatotal.Text = "0";
            lbl_pitaduoscdpwd.Text = "0";
            lbl_pitaduovat.Text = "0";
            lbl_pitaduototal.Text = "0";
            lbl_pitatrioscdpwd.Text = "0";
            lbl_pitatriovat.Text = "0";
            lbl_pitatriototal.Text = "0";
            lbl_ricescdpwd.Text = "0";
            lbl_ricevat.Text = "0";
            lbl_ricetotal.Text = "0";
            lbl_riceduoscdpwd.Text = "0";
            lbl_riceduovat.Text = "0";
            lbl_riceduototal.Text = "0";
            lbl_steakscdpwd.Text = "0";
            lbl_steakvat.Text = "0";
            lbl_steaktotal.Text = "0";
            lbl_steakduoscdpwd.Text = "0";
            lbl_steakduovat.Text = "0";
            lbl_steakduototal.Text = "0";
            lbl_platterscdpwd.Text = "0";
            lbl_plattervat.Text = "0";
            lbl_plattertotal.Text = "0";
            lbl_plattersoloscdpwd.Text = "0";
            lbl_plattersolovat.Text = "0";
            lbl_plattersolototal.Text = "0";
            lbl_cheesescdpwd.Text = "0";
            lbl_cheesevat.Text = "0";
            lbl_cheesetotal.Text = "0";
            lbl_friesscdpwd.Text = "0";
            lbl_friesvat.Text = "0";
            lbl_friestotal.Text = "0";
            lbl_extraricescdpwd.Text = "0";
            lbl_extraricevat.Text = "0";
            lbl_extraricetotal.Text = "0";
            lbl_waterscdpwd.Text = "0";
            lbl_watervat.Text = "0";
            lbl_watertotal.Text = "0";
            lbl_sodascdpwd.Text = "0";
            lbl_sodavat.Text = "0";
            lbl_sodatotal.Text = "0";
            lbl_softdrinksscdpwd.Text = "0";
            lbl_softdrinksvat.Text = "0";
            lbl_softdrinkstotal.Text = "0";

            lbl_pitascdpwd.Visible = false;
            lbl_pitavat.Visible = false;
            lbl_pitatotal.Visible = false;
            lbl_pitaduoscdpwd.Visible = false;
            lbl_pitaduovat.Visible = false;
            lbl_pitaduototal.Visible = false;
            lbl_pitatrioscdpwd.Visible = false;
            lbl_pitatriovat.Visible = false;
            lbl_pitatriototal.Visible = false;
            lbl_ricescdpwd.Visible = false;
            lbl_ricevat.Visible = false;
            lbl_ricetotal.Visible = false;
            lbl_riceduoscdpwd.Visible = false;
            lbl_riceduovat.Visible = false;
            lbl_riceduototal.Visible = false;
            lbl_steakscdpwd.Text = "0";
            lbl_steakvat.Text = "0";
            lbl_steaktotal.Text = "0";
            lbl_steakduoscdpwd.Text = "0";
            lbl_steakduovat.Text = "0";
            lbl_steakduototal.Text = "0";
            lbl_platterscdpwd.Visible = false;
            lbl_plattervat.Visible = false;
            lbl_plattertotal.Visible = false;
            lbl_plattersoloscdpwd.Visible = false;
            lbl_plattersolovat.Visible = false;
            lbl_plattersolototal.Visible = false;
            lbl_cheesescdpwd.Visible = false;
            lbl_cheesevat.Visible = false;
            lbl_cheesetotal.Visible = false;
            lbl_friesscdpwd.Visible = false;
            lbl_friesvat.Visible = false;
            lbl_friestotal.Visible = false;
            lbl_extraricescdpwd.Visible = false;
            lbl_extraricevat.Visible = false;
            lbl_extraricetotal.Visible = false;
            lbl_waterscdpwd.Visible = false;
            lbl_watervat.Visible = false;
            lbl_watertotal.Visible = false;
            lbl_sodascdpwd.Visible = false;
            lbl_sodavat.Visible = false;
            lbl_sodatotal.Visible = false;
            lbl_softdrinksscdpwd.Text = "0";
            lbl_softdrinksvat.Text = "0";
            lbl_softdrinkstotal.Text = "0";

            lbl_totalcash.Text = "0";
            lbl_totalexpenses.Text = "0";
            lbl_overshort.Text = "0";
            
            lbl_totalcash.Visible = false;
            lbl_totalexpenses.Visible = false;
            lbl_overshort.Visible = false;


        }

        private void qty_1000_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(qty_1000.Text))
            {
                lbl_amount1000.Text = "0";
                lbl_amount1000.Visible = false;
                
                lbl_billssub.Text = (Convert.ToInt32(lbl_amount1000.Text) + Convert.ToInt32(lbl_amount500.Text) + Convert.ToInt32(lbl_amount200.Text) +
                                    Convert.ToInt32(lbl_amount100.Text) + Convert.ToInt32(lbl_amount50.Text) + Convert.ToInt32(lbl_amount20.Text)).ToString();
                if (lbl_billssub.Text == "0")
                    lbl_billssub.Visible = false;
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
                if (lbl_coh.Text == "0")
                {
                    lbl_coh.Visible = false;
                    lbl_total.Text = "";
                }
            }
            else
            {
                lbl_amount1000.Visible = true;
                lbl_billssub.Visible = true;
                lbl_coh.Visible = true;
                lbl_amount1000.Text = (Convert.ToInt32(qty_1000.Text) * 1000).ToString();
                lbl_billssub.Text = (Convert.ToInt32(lbl_amount1000.Text) + Convert.ToInt32(lbl_amount500.Text) + Convert.ToInt32(lbl_amount200.Text) +
                                    Convert.ToInt32(lbl_amount100.Text) + Convert.ToInt32(lbl_amount50.Text) + Convert.ToInt32(lbl_amount20.Text)).ToString();
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
            }
        }

        private void qty_500_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(qty_500.Text))
            {
                lbl_amount500.Text = "0";
                lbl_amount500.Visible = false;

                lbl_billssub.Text = (Convert.ToInt32(lbl_amount1000.Text) + Convert.ToInt32(lbl_amount500.Text) + Convert.ToInt32(lbl_amount200.Text) +
                                    Convert.ToInt32(lbl_amount100.Text) + Convert.ToInt32(lbl_amount50.Text) + Convert.ToInt32(lbl_amount20.Text)).ToString();
                if (lbl_billssub.Text == "0")
                    lbl_billssub.Visible = false;
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
                if (lbl_coh.Text == "0")
                {
                    lbl_coh.Visible = false;
                    lbl_total.Text = "";
                }
            }
            else
            {
                lbl_amount500.Visible = true;
                lbl_billssub.Visible = true;
                lbl_coh.Visible = true;
                lbl_amount500.Text = (Convert.ToInt32(qty_500.Text) * 500).ToString();
                lbl_billssub.Text = (Convert.ToInt32(lbl_amount1000.Text) + Convert.ToInt32(lbl_amount500.Text) + Convert.ToInt32(lbl_amount200.Text) +
                                    Convert.ToInt32(lbl_amount100.Text) + Convert.ToInt32(lbl_amount50.Text) + Convert.ToInt32(lbl_amount20.Text)).ToString();
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
            }
        }

        private void qty_200_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(qty_200.Text))
            {
                lbl_amount200.Text = "0";
                lbl_amount200.Visible = false;

                lbl_billssub.Text = (Convert.ToInt32(lbl_amount1000.Text) + Convert.ToInt32(lbl_amount500.Text) + Convert.ToInt32(lbl_amount200.Text) +
                                    Convert.ToInt32(lbl_amount100.Text) + Convert.ToInt32(lbl_amount50.Text) + Convert.ToInt32(lbl_amount20.Text)).ToString();
                if (lbl_billssub.Text == "0")
                    lbl_billssub.Visible = false;
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
                if (lbl_coh.Text == "0")
                {
                    lbl_coh.Visible = false;
                    lbl_total.Text = "";
                }
            }
            else
            {
                lbl_amount200.Visible = true;
                lbl_billssub.Visible = true;
                lbl_coh.Visible = true;
                lbl_amount200.Text = (Convert.ToInt32(qty_200.Text) * 200).ToString();
                lbl_billssub.Text = (Convert.ToInt32(lbl_amount1000.Text) + Convert.ToInt32(lbl_amount500.Text) + Convert.ToInt32(lbl_amount200.Text) +
                                    Convert.ToInt32(lbl_amount100.Text) + Convert.ToInt32(lbl_amount50.Text) + Convert.ToInt32(lbl_amount20.Text)).ToString();
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
            }
        }

        private void qty_100_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(qty_100.Text))
            {
                lbl_amount100.Text = "0";
                lbl_amount100.Visible = false;

                lbl_billssub.Text = (Convert.ToInt32(lbl_amount1000.Text) + Convert.ToInt32(lbl_amount500.Text) + Convert.ToInt32(lbl_amount200.Text) +
                                    Convert.ToInt32(lbl_amount100.Text) + Convert.ToInt32(lbl_amount50.Text) + Convert.ToInt32(lbl_amount20.Text)).ToString();
                if (lbl_billssub.Text == "0")
                    lbl_billssub.Visible = false;
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
                if (lbl_coh.Text == "0")
                {
                    lbl_coh.Visible = false;
                    lbl_total.Text = "";
                }
            }
            else
            {
                lbl_amount100.Visible = true;
                lbl_billssub.Visible = true;
                lbl_coh.Visible = true;
                lbl_amount100.Text = (Convert.ToInt32(qty_100.Text) * 100).ToString();
                lbl_billssub.Text = (Convert.ToInt32(lbl_amount1000.Text) + Convert.ToInt32(lbl_amount500.Text) + Convert.ToInt32(lbl_amount200.Text) +
                                    Convert.ToInt32(lbl_amount100.Text) + Convert.ToInt32(lbl_amount50.Text) + Convert.ToInt32(lbl_amount20.Text)).ToString();
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
            }
        }

        private void qty_50_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(qty_50.Text))
            {
                lbl_amount50.Text = "0";
                lbl_amount50.Visible = false;

                lbl_billssub.Text = (Convert.ToInt32(lbl_amount1000.Text) + Convert.ToInt32(lbl_amount500.Text) + Convert.ToInt32(lbl_amount200.Text) +
                                    Convert.ToInt32(lbl_amount100.Text) + Convert.ToInt32(lbl_amount50.Text) + Convert.ToInt32(lbl_amount20.Text)).ToString();
                if (lbl_billssub.Text == "0")
                    lbl_billssub.Visible = false;
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
                if (lbl_coh.Text == "0")
                {
                    lbl_coh.Visible = false;
                    lbl_total.Text = "";
                }
            }
                
            else
            {
                lbl_amount50.Visible = true;
                lbl_billssub.Visible = true;
                lbl_coh.Visible = true;
                lbl_amount50.Text = (Convert.ToInt32(qty_50.Text) * 50).ToString();
                lbl_billssub.Text = (Convert.ToInt32(lbl_amount1000.Text) + Convert.ToInt32(lbl_amount500.Text) + Convert.ToInt32(lbl_amount200.Text) +
                                    Convert.ToInt32(lbl_amount100.Text) + Convert.ToInt32(lbl_amount50.Text) + Convert.ToInt32(lbl_amount20.Text)).ToString();
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
            }
        }

        private void qty_20_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(qty_20.Text))
            {
                lbl_amount20.Text = "0";
                lbl_amount20.Visible = false;

                lbl_billssub.Text = (Convert.ToInt32(lbl_amount1000.Text) + Convert.ToInt32(lbl_amount500.Text) + Convert.ToInt32(lbl_amount200.Text) +
                                    Convert.ToInt32(lbl_amount100.Text) + Convert.ToInt32(lbl_amount50.Text) + Convert.ToInt32(lbl_amount20.Text)).ToString();
                if (lbl_billssub.Text == "0")
                    lbl_billssub.Visible = false;
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
                if (lbl_coh.Text == "0")
                {
                    lbl_coh.Visible = false;
                    lbl_total.Text = "";
                }
            }
            else
            {
                lbl_amount20.Visible = true;
                lbl_billssub.Visible = true;
                lbl_coh.Visible = true;
                lbl_amount20.Text = (Convert.ToInt32(qty_20.Text) * 20).ToString();
                lbl_billssub.Text = (Convert.ToInt32(lbl_amount1000.Text) + Convert.ToInt32(lbl_amount500.Text) + Convert.ToInt32(lbl_amount200.Text) +
                                    Convert.ToInt32(lbl_amount100.Text) + Convert.ToInt32(lbl_amount50.Text) + Convert.ToInt32(lbl_amount20.Text)).ToString();
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
            }
        }

        private void qty_10_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(qty_10.Text))
            {
                lbl_amount10.Text = "0";
                lbl_amount10.Visible = false;

                lbl_coinssub.Text = (Convert.ToInt32(lbl_amount10.Text) + Convert.ToInt32(lbl_amount5.Text) +
                                    Convert.ToInt32(lbl_amount1.Text) + Convert.ToDouble(lbl_amount025.Text)).ToString();
                if (lbl_coinssub.Text == "0")
                    lbl_coinssub.Visible = false;
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
                if (lbl_coh.Text == "0")
                {
                    lbl_coh.Visible = false;
                    lbl_total.Text = "";
                }
            }
            else
            {
                lbl_amount10.Visible = true;
                lbl_coinssub.Visible = true;
                lbl_coh.Visible = true;
                lbl_amount10.Text = (Convert.ToInt32(qty_10.Text) * 10).ToString();
                lbl_coinssub.Text = (Convert.ToInt32(lbl_amount10.Text) + Convert.ToInt32(lbl_amount5.Text) +
                                    Convert.ToInt32(lbl_amount1.Text) + Convert.ToDouble(lbl_amount025.Text)).ToString();
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
            }
        }

        private void qty_5_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(qty_5.Text))
            {
                lbl_amount5.Text = "0";
                lbl_amount5.Visible = false;

                lbl_coinssub.Text = (Convert.ToInt32(lbl_amount10.Text) + Convert.ToInt32(lbl_amount5.Text) +
                                    Convert.ToInt32(lbl_amount1.Text) + Convert.ToDouble(lbl_amount025.Text)).ToString();
                if (lbl_coinssub.Text == "0")
                    lbl_coinssub.Visible = false;
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
                if (lbl_coh.Text == "0")
                {
                    lbl_coh.Visible = false;
                    lbl_total.Text = "";
                }
            }
            else
            {
                lbl_amount5.Visible = true;
                lbl_coinssub.Visible = true;
                lbl_coh.Visible = true;
                lbl_amount5.Text = (Convert.ToInt32(qty_5.Text) * 5).ToString();
                lbl_coinssub.Text = (Convert.ToInt32(lbl_amount10.Text) + Convert.ToInt32(lbl_amount5.Text) +
                                    Convert.ToInt32(lbl_amount1.Text) + Convert.ToDouble(lbl_amount025.Text)).ToString();
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
            }
        }

        private void qty_1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(qty_1.Text))
            {
                lbl_amount1.Text = "0";
                lbl_amount1.Visible = false;

                lbl_coinssub.Text = (Convert.ToInt32(lbl_amount10.Text) + Convert.ToInt32(lbl_amount5.Text) +
                                    Convert.ToInt32(lbl_amount1.Text) + Convert.ToDouble(lbl_amount025.Text)).ToString();
                if (lbl_coinssub.Text == "0")
                    lbl_coinssub.Visible = false;
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
                if (lbl_coh.Text == "0")
                {
                    lbl_coh.Visible = false;
                    lbl_total.Text = "";
                }
            }
            else
            {
                lbl_amount1.Visible = true;
                lbl_coinssub.Visible = true;
                lbl_coh.Visible = true;
                lbl_amount1.Text = (Convert.ToInt32(qty_1.Text) * 1).ToString();
                lbl_coinssub.Text = (Convert.ToInt32(lbl_amount10.Text) + Convert.ToInt32(lbl_amount5.Text) +
                                    Convert.ToInt32(lbl_amount1.Text) + Convert.ToDouble(lbl_amount025.Text)).ToString();
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
            }
        }

        private void qty_25_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(qty_25.Text))
            {
                lbl_amount025.Text = "0";
                lbl_amount025.Visible = false;

                lbl_coinssub.Text = (Convert.ToInt32(lbl_amount10.Text) + Convert.ToInt32(lbl_amount5.Text) +
                                    Convert.ToInt32(lbl_amount1.Text) + Convert.ToDouble(lbl_amount025.Text)).ToString();
                if (lbl_coinssub.Text == "0")
                    lbl_coinssub.Visible = false;
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
                if (lbl_coh.Text == "0")
                {
                    lbl_coh.Visible = false;
                    lbl_total.Text = "";
                }
            }
            else
            {
                lbl_amount025.Visible = true;
                lbl_coinssub.Visible = true;
                lbl_coh.Visible = true;
                lbl_amount025.Text = (Convert.ToInt32(qty_25.Text) * 0.25).ToString();
                lbl_coinssub.Text = (Convert.ToInt32(lbl_amount10.Text) + Convert.ToInt32(lbl_amount5.Text) +
                                    Convert.ToInt32(lbl_amount1.Text) + Convert.ToDouble(lbl_amount025.Text)).ToString();
                lbl_coh.Text = (Convert.ToDouble(lbl_billssub.Text) + Convert.ToDouble(lbl_coinssub.Text)).ToString();
                lbl_total.Text = lbl_coh.Text;
            }
        }

        private void txt_pita_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_pita.Text))
            {
                lbl_pitascdpwd.Text = "0";
                lbl_pitavat.Text = "0";
                lbl_pitatotal.Text = "0";
                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) + 
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();

                if (lbl_totalall.Text == "0")
                    lbl_totalall.Visible = false;

                lbl_pitascdpwd.Visible = false;
                lbl_pitavat.Visible = false;
                lbl_pitatotal.Visible = false;
            }
            else
            {
                lbl_pitascdpwd.Visible = true;
                lbl_pitavat.Visible = true;
                lbl_pitatotal.Visible = true;
                lbl_totalall.Visible = true;

                lbl_pitascdpwd.Text = (Convert.ToDouble(txt_pita.Text) * 10.71).ToString();
                lbl_pitavat.Text = (Convert.ToDouble(txt_pita.Text) * 6.43).ToString();
                lbl_pitatotal.Text = (Convert.ToDouble(lbl_pitascdpwd.Text) + Convert.ToDouble(lbl_pitavat.Text)).ToString();

                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();
            }
        }
        
        private void txt_pitaduo_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_pitaduo.Text))
            {
                lbl_pitaduoscdpwd.Text = "0";
                lbl_pitaduovat.Text = "0";
                lbl_pitaduototal.Text = "0";
                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) + 
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();

                if (lbl_totalall.Text == "0")
                    lbl_totalall.Visible = false;

                lbl_pitaduoscdpwd.Visible = false;
                lbl_pitaduovat.Visible = false;
                lbl_pitaduototal.Visible = false;
            }
            else
            {
                lbl_pitaduoscdpwd.Visible = true;
                lbl_pitaduovat.Visible = true;
                lbl_pitaduototal.Visible = true;
                lbl_totalall.Visible = true;

                lbl_pitaduoscdpwd.Text = (Convert.ToDouble(txt_pitaduo.Text) * 14.29).ToString();
                lbl_pitaduovat.Text = (Convert.ToDouble(txt_pitaduo.Text) * 8.57).ToString();
                lbl_pitaduototal.Text = (Convert.ToDouble(lbl_pitaduoscdpwd.Text) + Convert.ToDouble(lbl_pitaduovat.Text)).ToString();

                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();
            }
        }

        private void txt_trio_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_trio.Text))
            {
                lbl_pitatrioscdpwd.Text = "0";
                lbl_pitatriovat.Text = "0";
                lbl_pitatriototal.Text = "0";
                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();

                if (lbl_totalall.Text == "0")
                    lbl_totalall.Visible = false;

                lbl_pitatrioscdpwd.Visible = false;
                lbl_pitatriovat.Visible = false;
                lbl_pitatriototal.Visible = false;
            }
            else
            {
                lbl_pitatrioscdpwd.Visible = true;
                lbl_pitatriovat.Visible = true;
                lbl_pitatriototal.Visible = true;
                lbl_totalall.Visible = true;

                lbl_pitatrioscdpwd.Text = (Convert.ToDouble(txt_trio.Text) * 19.64).ToString();
                lbl_pitatriovat.Text = (Convert.ToDouble(txt_trio.Text) * 11.79).ToString();
                lbl_pitatriototal.Text = (Convert.ToDouble(lbl_pitatrioscdpwd.Text) + Convert.ToDouble(lbl_pitatriovat.Text)).ToString();

                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();
            }
        }
        
        private void txt_rice_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_rice.Text))
            {
                lbl_ricescdpwd.Text = "0";
                lbl_ricevat.Text = "0";
                lbl_ricetotal.Text = "0";
                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();

                if (lbl_totalall.Text == "0")
                    lbl_totalall.Visible = false;

                lbl_ricescdpwd.Visible = false;
                lbl_ricevat.Visible = false;
                lbl_ricetotal.Visible = false;
            }
            else
            {
                lbl_ricescdpwd.Visible = true;
                lbl_ricevat.Visible = true;
                lbl_ricetotal.Visible = true;
                lbl_totalall.Visible = true;

                lbl_ricescdpwd.Text = (Convert.ToDouble(txt_rice.Text) * 17.68).ToString();
                lbl_ricevat.Text = (Convert.ToDouble(txt_rice.Text) * 10.61).ToString();
                lbl_ricetotal.Text = (Convert.ToDouble(lbl_ricescdpwd.Text) + Convert.ToDouble(lbl_ricevat.Text)).ToString();

                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();
            }
        }
        
        private void txt_riceduo_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_riceduo.Text))
            {
                lbl_riceduoscdpwd.Text = "0";
                lbl_riceduovat.Text = "0";
                lbl_riceduototal.Text = "0";
                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();

                if (lbl_totalall.Text == "0")
                    lbl_totalall.Visible = false;

                lbl_riceduoscdpwd.Visible = false;
                lbl_riceduovat.Visible = false;
                lbl_riceduototal.Visible = false;
            }
            else
            {
                lbl_riceduoscdpwd.Visible = true;
                lbl_riceduovat.Visible = true;
                lbl_riceduototal.Visible = true;
                lbl_totalall.Visible = true;

                lbl_riceduoscdpwd.Text = (Convert.ToDouble(txt_riceduo.Text) * 21.25).ToString();
                lbl_riceduovat.Text = (Convert.ToDouble(txt_riceduo.Text) * 12.75).ToString();
                lbl_riceduototal.Text = (Convert.ToDouble(lbl_riceduoscdpwd.Text) + Convert.ToDouble(lbl_riceduovat.Text)).ToString();

                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();
            }
        }

        private void txt_steak_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_steak.Text))
            {
                lbl_steakscdpwd.Text = "0";
                lbl_steakvat.Text = "0";
                lbl_steaktotal.Text = "0";
                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();

                if (lbl_totalall.Text == "0")
                    lbl_totalall.Visible = false;

                lbl_steakscdpwd.Visible = false;
                lbl_steakvat.Visible = false;
                lbl_steaktotal.Visible = false;
            }
            else
            {
                lbl_steakscdpwd.Visible = true;
                lbl_steakvat.Visible = true;
                lbl_steaktotal.Visible = true;
                lbl_totalall.Visible = true;

                lbl_steakscdpwd.Text = (Convert.ToDouble(txt_steak.Text) * 33.04).ToString();
                lbl_steakvat.Text = (Convert.ToDouble(txt_steak.Text) * 19.82).ToString();
                lbl_steaktotal.Text = (Convert.ToDouble(lbl_steakscdpwd.Text) + Convert.ToDouble(lbl_steakvat.Text)).ToString();

                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();
            }
        }

        private void txt_steakduo_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_steakduo.Text))
            {
                lbl_steakduoscdpwd.Text = "0";
                lbl_steakduovat.Text = "0";
                lbl_steakduototal.Text = "0";
                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();

                if (lbl_totalall.Text == "0")
                    lbl_totalall.Visible = false;

                lbl_steakduoscdpwd.Visible = false;
                lbl_steakduovat.Visible = false;
                lbl_steakduototal.Visible = false;
            }
            else
            {
                lbl_steakduoscdpwd.Visible = true;
                lbl_steakduovat.Visible = true;
                lbl_steakduototal.Visible = true;
                lbl_totalall.Visible = true;

                lbl_steakduoscdpwd.Text = (Convert.ToDouble(txt_steakduo.Text) * 36.61).ToString();
                lbl_steakduovat.Text = (Convert.ToDouble(txt_steakduo.Text) * 21.96).ToString();
                lbl_steakduototal.Text = (Convert.ToDouble(lbl_steakduoscdpwd.Text) + Convert.ToDouble(lbl_steakduovat.Text)).ToString();

                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();
            }
        }
        
        private void txt_platter_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_platter.Text))
            {
                lbl_platterscdpwd.Text = "0";
                lbl_plattervat.Text = "0";
                lbl_plattertotal.Text = "0";
                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();

                if (lbl_totalall.Text == "0")
                    lbl_totalall.Visible = false;

                lbl_platterscdpwd.Visible = false;
                lbl_plattervat.Visible = false;
                lbl_plattertotal.Visible = false;
            }
            else
            {
                lbl_platterscdpwd.Visible = true;
                lbl_plattervat.Visible = true;
                lbl_plattertotal.Visible = true;
                lbl_totalall.Visible = true;

                lbl_platterscdpwd.Text = (Convert.ToDouble(txt_platter.Text) * 26.79).ToString();
                lbl_plattervat.Text = (Convert.ToDouble(txt_platter.Text) * 16.07).ToString();
                lbl_plattertotal.Text = (Convert.ToDouble(lbl_platterscdpwd.Text) + Convert.ToDouble(lbl_plattervat.Text)).ToString();

                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();
            }
        }
        
        private void txt_platterduo_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_platterduo.Text))
            {
                lbl_plattersoloscdpwd.Text = "0";
                lbl_plattersolovat.Text = "0";
                lbl_plattersolototal.Text = "0";
                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();

                if (lbl_totalall.Text == "0")
                    lbl_totalall.Visible = false;

                lbl_plattersoloscdpwd.Visible = false;
                lbl_plattersolovat.Visible = false;
                lbl_plattersolototal.Visible = false;
            }
            else
            {
                lbl_plattersoloscdpwd.Visible = true;
                lbl_plattersolovat.Visible = true;
                lbl_plattersolototal.Visible = true;
                lbl_totalall.Visible = true;

                lbl_plattersoloscdpwd.Text = (Convert.ToDouble(txt_platterduo.Text) * 30.36).ToString();
                lbl_plattersolovat.Text = (Convert.ToDouble(txt_platterduo.Text) * 18.21).ToString();
                lbl_plattersolototal.Text = (Convert.ToDouble(lbl_plattersoloscdpwd.Text) + Convert.ToDouble(lbl_plattersolovat.Text)).ToString();

                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();
            }
        }
        
        private void txt_cheese_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_cheese.Text))
            {
                lbl_cheesescdpwd.Text = "0";
                lbl_cheesevat.Text = "0";
                lbl_cheesetotal.Text = "0";
                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();

                if (lbl_totalall.Text == "0")
                    lbl_totalall.Visible = false;

                lbl_cheesescdpwd.Visible = false;
                lbl_cheesevat.Visible = false;
                lbl_cheesetotal.Visible = false;
            }
            else
            {
                lbl_cheesescdpwd.Visible = true;
                lbl_cheesevat.Visible = true;
                lbl_cheesetotal.Visible = true;
                lbl_totalall.Visible = true;

                lbl_cheesescdpwd.Text = (Convert.ToDouble(txt_cheese.Text) * 2.68).ToString();
                lbl_cheesevat.Text = (Convert.ToDouble(txt_cheese.Text) * 1.61).ToString();
                lbl_cheesetotal.Text = (Convert.ToDouble(lbl_cheesescdpwd.Text) + Convert.ToDouble(lbl_cheesevat.Text)).ToString();

                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();
            }
        }
        
        private void txt_fries_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_fries.Text))
            {
                lbl_friesscdpwd.Text = "0";
                lbl_friesvat.Text = "0";
                lbl_friestotal.Text = "0";
                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();

                if (lbl_totalall.Text == "0")
                    lbl_totalall.Visible = false;

                lbl_friesscdpwd.Visible = false;
                lbl_friesvat.Visible = false;
                lbl_friestotal.Visible = false;
            }
            else
            {
                lbl_friesscdpwd.Visible = true;
                lbl_friesvat.Visible = true;
                lbl_friestotal.Visible = true;
                lbl_totalall.Visible = true;

                lbl_friesscdpwd.Text = (Convert.ToDouble(txt_fries.Text) * 7.14).ToString();
                lbl_friesvat.Text = (Convert.ToDouble(txt_fries.Text) * 4.29).ToString();
                lbl_friestotal.Text = (Convert.ToDouble(lbl_friesscdpwd.Text) + Convert.ToDouble(lbl_friesvat.Text)).ToString();

                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();
            }
        }
        
        private void txt_extrarice_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_extrarice.Text))
            {
                lbl_extraricescdpwd.Text = "0";
                lbl_extraricevat.Text = "0";
                lbl_extraricetotal.Text = "0";
                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();

                if (lbl_totalall.Text == "0")
                    lbl_totalall.Visible = false;

                lbl_extraricescdpwd.Visible = false;
                lbl_extraricevat.Visible = false;
                lbl_extraricetotal.Visible = false;
            }
            else
            {
                lbl_extraricescdpwd.Visible = true;
                lbl_extraricevat.Visible = true;
                lbl_extraricetotal.Visible = true;
                lbl_totalall.Visible = true;

                lbl_extraricescdpwd.Text = (Convert.ToDouble(txt_extrarice.Text) * 17.68).ToString();
                lbl_extraricevat.Text = (Convert.ToDouble(txt_extrarice.Text) * 10.61).ToString();
                lbl_extraricetotal.Text = (Convert.ToDouble(lbl_extraricescdpwd.Text) + Convert.ToDouble(lbl_extraricevat.Text)).ToString();

                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();
            }
        }
        
        private void txt_water_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_water.Text))
            {
                lbl_waterscdpwd.Text = "0";
                lbl_watervat.Text = "0";
                lbl_watertotal.Text = "0";
                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();

                if (lbl_totalall.Text == "0")
                    lbl_totalall.Visible = false;

                lbl_waterscdpwd.Visible = false;
                lbl_watervat.Visible = false;
                lbl_watertotal.Visible = false;
            }
            else
            {
                lbl_waterscdpwd.Visible = true;
                lbl_watervat.Visible = true;
                lbl_watertotal.Visible = true;
                lbl_totalall.Visible = true;

                lbl_waterscdpwd.Text = (Convert.ToDouble(txt_water.Text) * 3.57).ToString();
                lbl_watervat.Text = (Convert.ToDouble(txt_water.Text) * 2.14).ToString();
                lbl_watertotal.Text = (Convert.ToDouble(lbl_waterscdpwd.Text) + Convert.ToDouble(lbl_watervat.Text)).ToString();

                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();
            }
        }
        
        
        private void txt_soda_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_soda.Text))
            {
                lbl_sodascdpwd.Text = "0";
                lbl_sodavat.Text = "0";
                lbl_sodatotal.Text = "0";
                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();

                if (lbl_totalall.Text == "0")
                    lbl_totalall.Visible = false;

                lbl_sodascdpwd.Visible = false;
                lbl_sodavat.Visible = false;
                lbl_sodatotal.Visible = false;
            }
            else
            {
                lbl_sodascdpwd.Visible = true;
                lbl_sodavat.Visible = true;
                lbl_sodatotal.Visible = true;
                lbl_totalall.Visible = true;

                lbl_sodascdpwd.Text = (Convert.ToDouble(txt_soda.Text) * 7.5).ToString();
                lbl_sodavat.Text = (Convert.ToDouble(txt_soda.Text) * 4.5).ToString();
                lbl_sodatotal.Text = (Convert.ToDouble(lbl_sodascdpwd.Text) + Convert.ToDouble(lbl_sodavat.Text)).ToString();

                lbl_totalall.Text = (Convert.ToDouble(lbl_pitatotal.Text) + Convert.ToDouble(lbl_pitaduototal.Text) + Convert.ToDouble(lbl_pitatriototal.Text) + Convert.ToDouble(lbl_ricetotal.Text) + Convert.ToDouble(lbl_riceduoscdpwd.Text) +
                            Convert.ToDouble(lbl_steaktotal.Text) + Convert.ToDouble(lbl_steakduototal.Text) +
                            Convert.ToDouble(lbl_plattertotal.Text) + Convert.ToDouble(lbl_plattersolototal.Text) + Convert.ToDouble(lbl_cheesetotal.Text) + Convert.ToDouble(lbl_friestotal.Text) + Convert.ToDouble(lbl_extraricetotal.Text) +
                            Convert.ToDouble(lbl_watertotal.Text) + Convert.ToDouble(lbl_softdrinkstotal.Text) + Convert.ToDouble(lbl_sodatotal.Text)).ToString();
            }
        }

        private void txt_softdrinks_TextChanged(object sender, EventArgs e)
        {

        }

        private void amt1_TextChanged(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(amt1.Text))
            {
                ototal = 0;
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal += Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal += Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal += Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal += Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal += Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal += Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal += Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal += Convert.ToDouble(amt9.Text);

                if (ototal == 0)
                    total_amt.Visible = false;
            }
            else
            {
                total_amt.Visible = true;
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal = 0 + Convert.ToDouble(amt1.Text);
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal += Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal += Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal += Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal += Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal += Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal += Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal += Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal += Convert.ToDouble(amt9.Text);

                total_amt.Text = ototal.ToString();
            }
        }

        private void amt2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(amt2.Text))
            {
                ototal = 0;
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal += Convert.ToDouble(amt1.Text);
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal += Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal += Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal += Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal += Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal += Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal += Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal += Convert.ToDouble(amt9.Text);

                if (ototal == 0)
                    total_amt.Visible = false;
            }
            else
            {
                total_amt.Visible = true;
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal = 0 + Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal += Convert.ToDouble(amt1.Text);
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal += Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal += Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal += Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal += Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal += Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal += Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal += Convert.ToDouble(amt9.Text);

                total_amt.Text = ototal.ToString();
            }
        }

        private void amt3_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(amt3.Text))
            {
                ototal = 0;
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal += Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal += Convert.ToDouble(amt1.Text);
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal += Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal += Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal += Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal += Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal += Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal += Convert.ToDouble(amt9.Text);

                if (ototal == 0)
                    total_amt.Visible = false;
            }
            else
            {
                total_amt.Visible = true;
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal = 0 + Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal += Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal += Convert.ToDouble(amt1.Text);
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal += Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal += Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal += Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal += Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal += Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal += Convert.ToDouble(amt9.Text);

                total_amt.Text = ototal.ToString();
            }
        }

        private void amt4_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(amt4.Text))
            {
                ototal = 0;
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal += Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal += Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal += Convert.ToDouble(amt1.Text);
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal += Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal += Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal += Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal += Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal += Convert.ToDouble(amt9.Text);

                if (ototal == 0)
                    total_amt.Visible = false;
            }
            else
            {
                total_amt.Visible = true;
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal = 0 + Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal += Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal += Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal += Convert.ToDouble(amt1.Text);
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal += Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal += Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal += Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal += Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal += Convert.ToDouble(amt9.Text);

                total_amt.Text = ototal.ToString();
            }
        }

        private void amt5_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(amt5.Text))
            {
                ototal = 0;
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal += Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal += Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal += Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal += Convert.ToDouble(amt1.Text);
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal += Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal += Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal += Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal += Convert.ToDouble(amt9.Text);

                if (ototal == 0)
                    total_amt.Visible = false;
            }
            else
            {
                total_amt.Visible = true;
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal = 0 + Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal += Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal += Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal += Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal += Convert.ToDouble(amt1.Text);
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal += Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal += Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal += Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal += Convert.ToDouble(amt9.Text);

                total_amt.Text = ototal.ToString();
            }
        }

        private void amt6_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(amt6.Text))
            {
                ototal = 0;
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal += Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal += Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal += Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal += Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal += Convert.ToDouble(amt1.Text);
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal += Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal += Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal += Convert.ToDouble(amt9.Text);

                if (ototal == 0)
                    total_amt.Visible = false;
            }
            else
            {
                total_amt.Visible = true;
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal = 0 + Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal += Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal += Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal += Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal += Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal += Convert.ToDouble(amt1.Text);
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal += Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal += Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal += Convert.ToDouble(amt9.Text);

                total_amt.Text = ototal.ToString();
            }
        }

        private void amt7_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(amt7.Text))
            {
                ototal = 0;
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal += Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal += Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal += Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal += Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal += Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal += Convert.ToDouble(amt1.Text);
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal += Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal += Convert.ToDouble(amt9.Text);

                if (ototal == 0)
                    total_amt.Visible = false;
            }
            else
            {
                total_amt.Visible = true;
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal = 0 + Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal += Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal += Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal += Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal += Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal += Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal += Convert.ToDouble(amt1.Text);
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal += Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal += Convert.ToDouble(amt9.Text);

                total_amt.Text = ototal.ToString();
            }
        }

        private void amt8_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(amt8.Text))
            {
                ototal = 0;
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal += Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal += Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal += Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal += Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal += Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal += Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal += Convert.ToDouble(amt1.Text);
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal += Convert.ToDouble(amt9.Text);

                if (ototal == 0)
                    total_amt.Visible = false;
            }
            else
            {
                total_amt.Visible = true;
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal = 0 + Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal += Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal += Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal += Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal += Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal += Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal += Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal += Convert.ToDouble(amt1.Text);
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal += Convert.ToDouble(amt9.Text);

                total_amt.Text = ototal.ToString();
            }
        }

        private void amt9_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(amt9.Text))
            {
                ototal = 0;
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal += Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal += Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal += Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal += Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal += Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal += Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal += Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal += Convert.ToDouble(amt1.Text);

                if (ototal == 0)
                    total_amt.Visible = false;
            }
            else
            {
                total_amt.Visible = true;
                if (!String.IsNullOrEmpty(amt9.Text))
                    ototal = 0 + Convert.ToDouble(amt9.Text);
                if (!String.IsNullOrEmpty(amt2.Text))
                    ototal += Convert.ToDouble(amt2.Text);
                if (!String.IsNullOrEmpty(amt3.Text))
                    ototal += Convert.ToDouble(amt3.Text);
                if (!String.IsNullOrEmpty(amt4.Text))
                    ototal += Convert.ToDouble(amt4.Text);
                if (!String.IsNullOrEmpty(amt5.Text))
                    ototal += Convert.ToDouble(amt5.Text);
                if (!String.IsNullOrEmpty(amt6.Text))
                    ototal += Convert.ToDouble(amt6.Text);
                if (!String.IsNullOrEmpty(amt7.Text))
                    ototal += Convert.ToDouble(amt7.Text);
                if (!String.IsNullOrEmpty(amt8.Text))
                    ototal += Convert.ToDouble(amt8.Text);
                if (!String.IsNullOrEmpty(amt1.Text))
                    ototal += Convert.ToDouble(amt1.Text);

                total_amt.Text = ototal.ToString();
            }
        }
    }
}
