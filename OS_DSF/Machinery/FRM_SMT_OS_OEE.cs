using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OS_DSF.Machinery
{
    public partial class FRM_SMT_OS_OEE : Form
    {
        public FRM_SMT_OS_OEE()
        {
            InitializeComponent();
        }


        #region Func
        private DataTable SELECT_DATA_OS(string ARG_QTYPE,string ARG_DATE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_B1_PHUOC.OS_OEE_SELECT";

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_DATE";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_DATE;
                MyOraDB.Parameter_Values[2] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }
        private DataTable SELECT_DATA(string ARG_QTYPE,string ARG_DATE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_B1_PHUOC.OS_OEE_SELECT";

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_DATE";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_DATE;
                MyOraDB.Parameter_Values[2] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }
        private void BindingOEEData(string ARG_QTYPE)
        {
            try
            {
                DataTable DT = new DataTable();
                DT = SELECT_DATA_OS("GMONTH",uc_month.GetValue());
               // grdBase.DataSource = DT;

                DataTable dt1 = SELECT_DATA_OS("MONTH", uc_month.GetValue());
                ChartOEE.DataSource = dt1; // SELECT_DATA(ARG_QTYPE);
                grdBase.DataSource = DT;
                ChartOEE.Series[0].ArgumentDataMember = "OSP_LINE";
                ChartOEE.Series[0].ValueDataMembers.AddRange(new string[] { "OEE" });
                ((XYDiagram)ChartOEE.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                // ChartOEE.Series[0].ValueScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
                FormatGrid();
            }
            catch (Exception ex)
            { }
        }
        private void FormatGrid()
        {
            for (int i = 0; i < gvwBase.Columns.Count; i++)
            {
                if (i == gvwBase.Columns.Count - 1)
                {
                    gvwBase.Columns[i].AppearanceHeader.BackColor = Color.DarkOrange;
                    gvwBase.Columns[i].AppearanceHeader.ForeColor = Color.Black;
                }
                else
                {
                    gvwBase.Columns[i].AppearanceHeader.BackColor = Color.Gray;
                    gvwBase.Columns[i].AppearanceHeader.ForeColor = Color.White;
                }
            }
            gvwBase.Columns[0].Width = 120;
        }
        private DataTable pivotTable(DataTable dt)
        {
            DataTable dtr = new DataTable();
            string [] strRow = new string [dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if(dt.Rows[i][0].ToString() == "AVG")
                dtr.Columns.Add(dt.Rows[i][1].ToString());
            }
            //for (int i = 0; i < dt.Columns.Count; i++)
            //{
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                strRow[j] = dt.Rows[j][2].ToString();

            }
            dtr.Rows.Add(strRow);
            
            return dtr;
        }

        #endregion

        #region event
        private void ChartOEE_Click(object sender, EventArgs e)
        {

        }
        UC.UC_DWMY uc = new UC.UC_DWMY(7);
        private void FRM_SMT_OS_OEE_Load(object sender, EventArgs e)
        {
            BindingOEEData("PH_C");
            pnYMD.Controls.Add(uc);
            uc.OnDWMYClick += DWMYClick;
        }
        void DWMYClick(string ButtonCap, string ButtonCD)
        {
            //MessageBox.Show(ButtonCap + "    " + ButtonCD);
            switch (ButtonCD)
            {
                case "C":
                    this.Close();
                    break;
                case "M":
                    this.Close();
                    Form fc = Application.OpenForms["FRM_SMT_OS_OEE"];
                    if (fc != null)
                        fc.Show();
                    else
                    {
                        FRM_SMT_OS_OEE f = new FRM_SMT_OS_OEE();
                        f.Show();
                    }
                    break;
                case "Y":
                    this.Close();
                    Form fc1 = Application.OpenForms["FRM_SMT_OS_OEE_YEAR"];
                    if (fc1 != null)
                        fc1.Show();
                    else
                    {
                        FRM_SMT_OS_OEE_YEAR f1 = new FRM_SMT_OS_OEE_YEAR();
                        f1.Show();
                    }
                    break;
            }
        }
        private void gvwBase_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {

                if (e.RowHandle < 0)
                    return;
                if (gvwBase.GetRowCellValue(e.RowHandle, "LINE").ToString() == "AVG")
                {
                    e.Appearance.ForeColor = Color.Black;
                    e.Appearance.BackColor = Color.DarkOrange;
                    //e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, 16, FontStyle.Bold);

                }

                if (e.Column.AbsoluteIndex > 10)
                {
                    if (e.CellValue.ToString().Contains("GREEN"))
                    {
                        e.Appearance.BackColor = Color.LimeGreen;
                    }
                    if (e.CellValue.ToString().Contains("RED"))
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    if (e.CellValue.ToString().Contains("YELLOW"))
                    {
                        e.Appearance.BackColor = Color.Yellow;
                    }
                    if (e.CellValue.ToString().Contains("GRAY"))
                    {
                        e.Appearance.BackColor = Color.SlateGray;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void gvwBase_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;
            if (e.Column.AppearanceHeader.BackColor != Color.Empty)
            {                
                e.Info.AllowColoring = true;                
            }
            if (e.Column.AppearanceHeader.ForeColor != Color.Empty)
            {                
                e.Info.AllowColoring = true;                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BindingOEEData("MONTH");
        }    

        #endregion

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void uc_month_ValueChangeEvent(object sender, EventArgs e)
        {
            //MessageBox.Show( uc_month.GetValue());
            BindingOEEData("MONTH");
        }
    }
}
