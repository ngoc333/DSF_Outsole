using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
//using JPlatform.Client.Controls;


namespace OS_DSF
{
    public partial class FRM_SMT_OS_TOPO_WEEKLY : Form
    {
        public FRM_SMT_OS_TOPO_WEEKLY()
        {
            InitializeComponent();
        }

        int cnt = 0, i_max = 0, i_min = 0;
        string str_op = "";
        string strCol = "";

        #region db
        Addons.Database db = new Addons.Database();
        #endregion
        #region UC
        UC.UC_DWMY uc = new UC.UC_DWMY(1);

        #endregion

        private void FRM_ROLL_SLABTEST_MON_Load(object sender, EventArgs e)
        {            
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 1000;
            
            pnYMD.Controls.Add(uc);
            uc.OnDWMYClick += DWMYClick;
            uc.YMD_Change(9);
        }

        void DWMYClick(string ButtonCap, string ButtonCD)
        {
            //MessageBox.Show(ButtonCap + "    " + ButtonCD);
            switch (ButtonCD)
            {
                case "C":
                    this.Close();
                    break;
                case "D":
                    this.Close();
                    Form fc = Application.OpenForms["FRM_SMT_OS_TOPO_DAILY"];
                    if (fc != null)
                        fc.Show();
                    else
                    {
                        FRM_SMT_OS_TOPO_DAILY f = new FRM_SMT_OS_TOPO_DAILY();
                        f.Show();
                    }
                    break;
                case "W":
                    this.Close();
                    Form fc1 = Application.OpenForms["FRM_SMT_OS_TOPO_WEEKLY"];
                    if (fc1 != null)
                        fc1.Show();
                    else
                    {
                        FRM_SMT_OS_TOPO_WEEKLY f1 = new FRM_SMT_OS_TOPO_WEEKLY();
                        f1.Show();
                    }
                    break;
                case "M":
                    this.Close();
                    Form fc2 = Application.OpenForms["FRM_SMT_OS_PROD_MONTH"];
                    if (fc2 != null)
                        fc2.Show();
                    else
                    {
                        FRM_SMT_OS_PROD_MONTH f2 = new FRM_SMT_OS_PROD_MONTH();
                        f2.Show();
                    }
                    break;
                case "Y":
                    this.Close();
                    Form fc3 = Application.OpenForms["FRM_SMT_OS_PROD_YEAR"];
                    if (fc3 != null)
                        fc3.Show();
                    else
                    {
                        FRM_SMT_OS_PROD_YEAR f3 = new FRM_SMT_OS_PROD_YEAR();
                        f3.Show();
                    }
                    break;
            }
        }

        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
        
        private void formatgrid()
        {
            for (int i = 0; i < gvwView.Columns.Count; i++)
            {
                gvwView.Columns[i].OptionsColumn.ReadOnly = true;
                gvwView.Columns[i].OptionsColumn.AllowEdit = false;
                gvwView.Columns[i].OptionsFilter.AllowFilter = false;
                gvwView.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                gvwView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 16, FontStyle.Regular);
                gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwView.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                if (i == 0)
                {
                    gvwView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    gvwView.Columns[i].Caption = "" + i;
                    gvwView.Columns[i].ColumnEdit = this.repositoryItemMemoEdit1;
                    gvwView.Columns[i].Visible = true;
                    gvwView.Columns[i].VisibleIndex = i;
                }
                else
                {
                    gvwView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                }
                if (i > 1)
                {
                    gvwView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gvwView.Columns[i].DisplayFormat.FormatString = "#,#";
                }
            }
        }

        private void BindingData(string arg_op)
        {
            try
            {
                grdView.Refresh();
                DataTable dtsource = null, dtsource1 = null;
                dtsource = db.SEL_OS_TOPO_WEEKLY("Q", arg_op);
                dtsource1 = db.SEL_OS_TOPO_WEEKLY("H", arg_op);

                BindingHead(dtsource1);
                grdView.DataSource = dtsource;
                formatgrid();
            }
            catch { }
        }

        private void BindingHead(DataTable dt)
        {
            try
            {
                for (int i_row = 0; i_row < dt.Rows.Count; i_row++)
                {
                    for (int i_col = 2; i_col < gvwView.Columns.Count; i_col++)
                    {
                        if (gvwView.Columns[i_col].OwnerBand.ParentBand.Name.Contains(dt.Rows[i_row]["BAND_NM"].ToString()))
                        {
                            gvwView.Columns[i_col].OwnerBand.ParentBand.Caption = dt.Rows[i_row]["CAPTION"].ToString();
                            break;
                        }
                    }
                }
            }
            catch { }
        }

        private void bindingchart(DataTable dt, ChartControl _chart )
        {
            _chart.DataSource = dt;
            _chart.Series[0].ArgumentDataMember = "DIV";
            _chart.Series[0].ValueDataMembers.AddRange(new string[] { "TO_QTY" });
            _chart.Series[1].ArgumentDataMember = "DIV";
            _chart.Series[1].ValueDataMembers.AddRange(new string[] { "PO_QTY" });            
        }

        private void bindingchart2(DataTable dt, ChartControl _chart)
        {
            _chart.DataSource = dt;
            _chart.Series[0].ArgumentDataMember = "SHIFT";
            _chart.Series[0].ValueDataMembers.AddRange(new string[] { "PO_QTY" });
        }

        private void gvwView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (gvwView.GetRowCellValue(e.RowHandle, "DIV").ToString().ToUpper().Contains("TOTAL"))
            {
                e.Appearance.BackColor = Color.FromArgb(255, 224, 192);
                e.Appearance.ForeColor = Color.Black;
            }
            
            if (e.Column.FieldName.Contains("BAL"))
            {
                if (e.CellValue.ToString() != "")
                {
                    if (Convert.ToDouble(e.CellValue.ToString())<0)
                    {
                        e.Appearance.BackColor = Color.FromArgb(0, 255, 0);
                        e.Appearance.ForeColor = Color.Black;
                    }
                    else if (Convert.ToDouble(e.CellValue.ToString()) > 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
            else
            {
                
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd")) + "\n\r" + string.Format(DateTime.Now.ToString("HH:mm:ss"));
            if (cnt < 40)
            {
                cnt++;                
            }
            else
            {
                cnt = 0;
                BindingData("OSP");
            }
        }

        private void FRM_ROLL_SLABTEST_MON_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    uc.YMD_Change(9);
                    timer1.Start();
                    cnt = 40;
                }
                else
                    timer1.Stop();
            }
            catch
            {

            }
        }

        private void gvwView_DoubleClick(object sender, EventArgs e)
        {
            BandedGridView view = (BandedGridView)sender;
            if (view != null)
            {
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                BandedGridHitInfo info = view.CalcHitInfo(pt);
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridView sndr = sender as DevExpress.XtraGrid.Views.BandedGrid.BandedGridView;
                DevExpress.Utils.DXMouseEventArgs dxMouseEventArgs = e as DevExpress.Utils.DXMouseEventArgs;
                DevExpress.XtraGrid.Views.BandedGrid.ViewInfo.BandedGridHitInfo hitInfo = sndr.CalcHitInfo(dxMouseEventArgs.Location);
                if (hitInfo.RowHandle < 0)
                {
                    if (hitInfo.Band.Caption.Equals("Chart"))
                    {
                        this.Close();
                        Form fc = Application.OpenForms["FRM_SMT_OS_TOPO_WEEKLY_CHART"];
                        if (fc != null)
                            fc.Show();
                        else
                        {
                            FRM_SMT_OS_TOPO_WEEKLY_CHART f = new FRM_SMT_OS_TOPO_WEEKLY_CHART();
                            f.Show();
                        }
                    }
                }
                
            }
        }
    }
}
