﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OracleClient;
using Microsoft.VisualBasic.PowerPacks;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
//using ChartDirector;
using System.Threading;
//using IPEX_Monitor.ClassLib;


namespace OS_DSF
{

    

    public partial class FORM_SMT_OS_LEADTIME : Form
    {
        public FORM_SMT_OS_LEADTIME()
        {
            InitializeComponent();
            addUC();
        }


        #region Init

        public int _time = 0, _timeReload = 40;
        OS_DSF.UC.UC_DWMY ucMenu = new UC.UC_DWMY(1);
        #endregion Init

        #region Function

        private void addUC()
        {
            try
            {
                
                
                pnMenu.Controls.Add(ucMenu);
                ucMenu.OnDWMYClick += mnBtnClick;
            }
            catch 
            {}
            

        }

        private void mnBtnClick(string ButtonCap, string ButtonCD)
        {
            try
            {
                Form fc = null;
                switch (ButtonCap)
                {
                    case "btnClose":
                        timer1.Stop();
                        this.Close();
                        break;
                    case "btnMonth":
                        fc = Application.OpenForms["FORM_SMT_OS_LEADTIME_MONTH"];
                        if (fc != null)
                        {

                            fc.Show();
                            this.Hide();
                        }
                        else
                        {
                            FORM_SMT_OS_LEADTIME_MONTH f = new FORM_SMT_OS_LEADTIME_MONTH();
                            f.Show();
                            this.Hide();
                        }
                        break;
                    case "btnWeek":
                        fc = Application.OpenForms["FORM_SMT_OS_LEADTIME_WEEK"];
                        if (fc != null)
                        {

                            fc.Show();
                            this.Hide();
                        }
                        else
                        {
                            FORM_SMT_OS_LEADTIME_WEEK f = new FORM_SMT_OS_LEADTIME_WEEK();
                            f.Show();
                            this.Hide();
                        }
                        break;
                    case "btnYear":
                        fc = Application.OpenForms["FORM_SMT_OS_LEADTIME_YEAR"];
                        if (fc != null)
                        {

                            fc.Show();
                            this.Hide();
                        }
                        else
                        {
                            FORM_SMT_OS_LEADTIME_YEAR f = new FORM_SMT_OS_LEADTIME_YEAR();
                            f.Show();
                            this.Hide();
                        }
                        break;
                }
            }
            catch 
            {}
            

        }
        
        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }

        public void loaddata()
        {
            try
            {
                DataTable dt = SEL_OS_LEAD_TIME("OSP");
                Control cntrl;
               // cntrl = this.Controls.Find(dt.Rows, true).FirstOrDefault();
                //cntrl.Text = "inspection\n20'";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cntrl = this.Controls.Find(dt.Rows[i]["ctr_name"].ToString(), true ).FirstOrDefault();
                    if (cntrl != null)
                        cntrl.Text = dt.Rows[i]["val1"].ToString();
                }
            }
            catch
            { }
            finally
            {
            }
        }

        private void lineArrow_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                LineShape line = (LineShape)sender;
                Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.NoAnchor;
                e.Graphics.DrawLine(pen, line.EndPoint, line.StartPoint);
            }
            catch 
            {}
            
        }
    

        #endregion Fuction

        #region DB

        public DataTable SEL_OS_LEAD_TIME(string arg_wh)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            System.Data.DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_B_LEADTIME.SEL_LEAD_TIME_BY_DAY";

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;


                MyOraDB.Parameter_Name[0] = "ARG_OP_CD";
                MyOraDB.Parameter_Name[1] = "ARG_TYPE";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = arg_wh;
                MyOraDB.Parameter_Values[1] = "Q";
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
       
        #endregion DB

        #region Event

        public void Frm_Load(object sender, EventArgs e)
        {
            GoFullscreen();
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd")) + "\n\r" + string.Format(DateTime.Now.ToString("HH:mm:ss"));
                _time++;
                if (_time >= _timeReload)
                {
                    loaddata();                    
                    _time = 0;
                }
            }
            catch
            {}
        }


        private void Frm_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    ucMenu.YMD_Change(12);
                    _time = _timeReload -1;
                     timer1.Start();       
                }
                else
                {    
                    timer1.Stop();
                }              
            }
            catch 
            {}
        }

        
        
        #endregion Event







    }
}
