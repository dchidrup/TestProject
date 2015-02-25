using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TestProject
{
    public partial class Default : System.Web.UI.Page
    {
        enum RankOFChar { A = 1, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z };

        public static DataTable dtSource = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    int total = 0;
                    int index = 1;

                    System.IO.StreamReader myFile = new System.IO.StreamReader(Server.MapPath("names.txt"));
                    string myString = myFile.ReadToEnd();
                    myFile.Close();

                    string[] stringArray = myString.Replace("\"", "").Split(',');
                    Array.Sort(stringArray);

                    
                    dtSource = new DataTable();
                    dtSource.Rows.Clear();

                    dtSource.Columns.Add("Name", typeof(string));
                    dtSource.Columns.Add("Position", typeof(int));
                    dtSource.Columns.Add("Worth", typeof(int));
                    dtSource.Columns.Add("Score", typeof(int));

                    foreach (string name in stringArray)
                    {

                        int worth = getWorth(name);
                        int score = worth * index;

                        DataRow dr = dtSource.NewRow();
                        dr["Name"] = name;
                        dr["Position"] = index;
                        dr["Worth"] = worth;
                        dr["Score"] = score;

                        dtSource.Rows.Add(dr);
                        index += 1;
                        total += score;
                    }
                    dtSource.AcceptChanges();

                    grdview.DataSource = dtSource;
                    grdview.DataBind();

                    lblTotal.Text = total.ToString();
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Some Error occur while computing";
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        public int getWorth(string name)
        {
            int worth = 0;
            char[] charArray = name.ToCharArray();
            try
            {
                foreach (Char c in charArray)
                {
                    if (c == 'A')
                        worth += (int)RankOFChar.A;
                    else if (c == 'B')
                        worth += (int)RankOFChar.B;
                    else if (c == 'C')
                        worth += (int)RankOFChar.C;
                    else if (c == 'D')
                        worth += (int)RankOFChar.D;
                    else if (c == 'E')
                        worth += (int)RankOFChar.E;
                    else if (c == 'F')
                        worth += (int)RankOFChar.F;
                    else if (c == 'G')
                        worth += (int)RankOFChar.G;
                    else if (c == 'H')
                        worth += (int)RankOFChar.H;
                    else if (c == 'I')
                        worth += (int)RankOFChar.I;
                    else if (c == 'J')
                        worth += (int)RankOFChar.J;
                    else if (c == 'K')
                        worth += (int)RankOFChar.K;
                    else if (c == 'L')
                        worth += (int)RankOFChar.L;
                    else if (c == 'M')
                        worth += (int)RankOFChar.M;
                    else if (c == 'N')
                        worth += (int)RankOFChar.N;
                    else if (c == 'O')
                        worth += (int)RankOFChar.O;
                    else if (c == 'P')
                        worth += (int)RankOFChar.P;
                    else if (c == 'Q')
                        worth += (int)RankOFChar.Q;
                    else if (c == 'R')
                        worth += (int)RankOFChar.R;
                    else if (c == 'S')
                        worth += (int)RankOFChar.S;
                    else if (c == 'T')
                        worth += (int)RankOFChar.T;
                    else if (c == 'U')
                        worth += (int)RankOFChar.U;
                    else if (c == 'V')
                        worth += (int)RankOFChar.V;
                    else if (c == 'W')
                        worth += (int)RankOFChar.W;
                    else if (c == 'X')
                        worth += (int)RankOFChar.X;
                    else if (c == 'Y')
                        worth += (int)RankOFChar.Y;
                    else if (c == 'Z')
                        worth += (int)RankOFChar.Z;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Some Error occur while computing";
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
            return worth;

        }

        protected void grdview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdview.PageIndex = e.NewPageIndex;
                grdview.DataSource = dtSource;
                grdview.DataBind();
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Some Error occur while computing";
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}