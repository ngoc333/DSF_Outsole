using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OS_DSF.UC
{
    public partial class UC_ABSENT_V2 : UserControl
    {
        public UC_ABSENT_V2(string Title)
        {
            InitializeComponent();
            lblTitle.Text = Title;
        }

        public void BindingData(DataTable dt)
        {
            try
            {
                chartAbsent.DataSource = dt;
                chartAbsent.Series[0].ArgumentDataMember = "CAPTION";
                chartAbsent.Series[0].ValueDataMembers.AddRange(new string[] { "VALUE_DATA" });
                lblAbsent.Text = "Total Absent: " + "\n" + (Convert.ToDouble(dt.Rows[0][2].ToString()) + Convert.ToDouble(dt.Rows[1][2].ToString())).ToString() + " Person(s)"
                   + "\n" + ((Convert.ToDouble(dt.Rows[0][2].ToString()) + Convert.ToDouble(dt.Rows[1][2].ToString())) / Convert.ToDouble(dt.Rows[0][3].ToString()) * 100).ToString("#0.0") + "%"
                   ;
                if(dt!=null && dt.Rows.Count > 0)
                {
                    lblTitle.Text = "Attendance Status (" + dt.Rows[0]["YMD"].ToString() + ")";
                }
                //chartAbsent.PaletteRepository.Clear();
                //if (Convert.ToDouble(dt.Rows[0]["VALUE"].ToString()) < 5)
                //{
                //    chartAbsent.PaletteName = "Palette 2";
                //    chartAbsent.PaletteRepository.Add("Palette 2", new DevExpress.XtraCharts.Palette("Palette 2", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                //new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.DodgerBlue, System.Drawing.Color.DodgerBlue),
                //new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Green, System.Drawing.Color.Green)}));
                //}
                //else
                //{
                //    chartAbsent.PaletteName = "Palette 1";
                //    chartAbsent.PaletteRepository.Add("Palette 1", new DevExpress.XtraCharts.Palette("Palette 1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                //new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Red, System.Drawing.Color.Red),
                //new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Green, System.Drawing.Color.Green)}));
                //}

            
            }
            catch { }
        }
    }
}
