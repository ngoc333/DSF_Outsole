using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace OS_DSF
{
    public partial class DIGITAL_SHOP_FLOOR_OS : Form
    {
        public DIGITAL_SHOP_FLOOR_OS()
        {
            InitializeComponent();   
            this.Text = "RunOS";
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool turnon);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindow(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_SHOWWINDOW = 0x0040;

        #region UserControl
        UC.UC_MENU_OS_V2 UC_MENU = new UC.UC_MENU_OS_V2("MENU");
        UC.UC_OSD_V2 UC_OSD = new UC.UC_OSD_V2("Quality");
        UC.UC_PRODUCTION_V2 UC_PRODUCTION = new UC.UC_PRODUCTION_V2("Production");
        UC.UC_POD_V2 UC_POD = new UC.UC_POD_V2("POD");
        UC.UC_INV_V2 UC_INV = new UC.UC_INV_V2("Inventory");
        UC.UC_ABSENT_V2 UC_ABSENT = new UC.UC_ABSENT_V2("Attendance Status");

        #endregion
        #region Variable
         
        Process dashboard1 = new Process();
        Process dashboard2 = new Process();
        Process dashboard3 = new Process();
        Process dashboard4 = new Process(); 
        public const int SW_MAXIMIZE = 3;
        int cCount = 0;
        #endregion
        #region Db
        Addons.Database Db = new Addons.Database();
        #endregion

        #region Read File XML
        public static Dictionary<string, string>[] Init_File_XML(string str_FileName, string arg_TagName)
        {
            try
            {
                using (FileStream fs = new FileStream(str_FileName, FileMode.Open, FileAccess.Read))
                {
                    System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                    xmldoc.Load(fs);

                    //Get Configuration OF Production Form
                    Dictionary<string, string>[] rtn_VarName = new Dictionary<string, string>[xmldoc.GetElementsByTagName(arg_TagName).Count];
                    int i = 0;
                    foreach (System.Xml.XmlNode xmlnode in xmldoc.GetElementsByTagName(arg_TagName))
                    {
                        rtn_VarName[i] = new Dictionary<string, string>();
                        foreach (System.Xml.XmlElement xmllist in xmlnode.ChildNodes)
                        {
                            rtn_VarName[i].Add(xmllist.Name, xmllist.InnerText);
                        }
                        i++;
                    }
                    return rtn_VarName;
                }
            }
            catch 
            {
               
                return null;
            }

        } 
        private DataTable ReadXML(string file)
        {
            DataTable table = new DataTable("Item");
            try
            {
                DataSet lstNode = new DataSet();
                lstNode.ReadXml(file);
                table = lstNode.Tables["Item"];
                return table;
            }
            catch (Exception ex)
            {
                return table;
            }
        }
        #endregion Read File XML


        #region Open WorkShop Program
        private void start4Process()
        {
            ProcessStartInfo theProcess = new ProcessStartInfo(Application.StartupPath + @"\OS_DASHBOARD1\OS_DSF.exe");
            theProcess.WindowStyle = ProcessWindowStyle.Minimized;
            dashboard1.StartInfo = theProcess;
            dashboard1.Start();

            theProcess = new ProcessStartInfo(Application.StartupPath + @"\OS_DASHBOARD2\OS_DSF.exe");
            theProcess.WindowStyle = ProcessWindowStyle.Minimized;
            dashboard2.StartInfo = theProcess;
            dashboard2.Start();

            theProcess = new ProcessStartInfo(Application.StartupPath + @"\OS_DASHBOARD3\OS_DSF.exe");
            theProcess.WindowStyle = ProcessWindowStyle.Minimized;
            dashboard3.StartInfo = theProcess;
            dashboard3.Start();

            theProcess = new ProcessStartInfo(Application.StartupPath + @"\OS_DASHBOARD4\OS_DSF.exe");
            theProcess.WindowStyle = ProcessWindowStyle.Minimized;
            dashboard4.StartInfo = theProcess;
            dashboard4.Start();
        }


        private void MoveToScreen2()
        {
            this.WindowState = FormWindowState.Normal;
            this.Bounds = Screen.AllScreens[1].Bounds;
            this.WindowState = FormWindowState.Maximized;
        }

        #endregion 

        private void DIGITAL_SHOP_FLOOR_OS_Load(object sender, EventArgs e)
        {
            try
            {


                DataTable dtXML = ReadXML(Application.StartupPath + "\\Config.XML");
                lblDateTime.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
                if (tblMain.Controls.Count > 0)
                    tblMain.Controls.Clear();
                //splashScreenManager1.ShowWaitForm();
                //splashScreenManager1.SetWaitFormCaption("Đợi chút...");
                //Load All Datatable
                DataTable dtOSD = Db.SEL_OSD_DATA("Q");
                DataTable dtPROD = Db.SEL_OS_PRODUCTION_DATA("Q");
                DataTable dtINV = Db.SEL_OS_INV_DATA("Q");
                DataTable dtAbsent = Db.SEL_OS_ABSENT_DATA("Q");
                DataTable dtPOD = Db.SEL_OS_POD_DATA("Q");
                tblMain.Controls.Add(UC_MENU, 0, 0);
                UC_MENU.OnMenuClick += MenuOnClick;
                UC_MENU.MoveLeave += MoveLeaveClick;
                tblMain.Controls.Add(UC_OSD, 1, 0);

                tblMain.Controls.Add(UC_PRODUCTION, 2, 0);

                tblMain.Controls.Add(UC_POD, 0, 1);

                tblMain.Controls.Add(UC_INV, 1, 1);

                tblMain.Controls.Add(UC_ABSENT, 2, 1);
                UC_OSD.BindingData(dtOSD);
                UC_PRODUCTION.BindingData(dtPROD);
                UC_POD.BindingData(dtPOD);
                UC_INV.BindingData(dtINV);
                UC_ABSENT.BindingData(dtAbsent);
                pic_under.Visible = false;
                if (dtXML.Rows[0]["Office_YN"].ToString() == "Y")
                {
                    cmdBack.Visible = true;
                    btn_WS1.Visible = btn_WS2.Visible = btn_WS3.Visible = btn_WS4.Visible = false;
                    if (Screen.AllScreens.Length > 1)
                        MoveToScreen2();
                    this.WindowState = FormWindowState.Minimized;
                }
                if (dtXML.Rows[0]["Office_YN"].ToString() == "2Y")
                {
                    cmdBack.Visible = true;
                    start4Process();
                    btn_WS1.Visible = btn_WS2.Visible = btn_WS3.Visible = btn_WS4.Visible = true;
                }
                else
                {
                    start4Process();
                    btn_WS1.Visible = btn_WS2.Visible = btn_WS3.Visible = btn_WS4.Visible = true;
                }
               
                Dictionary<string, string>[] dtn  =   Init_File_XML(AppDomain.CurrentDomain.BaseDirectory + "App.xml", "form");
                cmdBack.Visible = Boolean.Parse(dtn[0]["cmdBack"]);
                //splashScreenManager1.CloseWaitForm();
            }
            catch
            {
                //splashScreenManager1.CloseWaitForm();
            }
        }


        void MenuOnClick(string MenuName, string BtnCD)
        {
            try
            {
                 //  MessageBox.Show(MenuName + "_" + BtnCD);
                System.Windows.Forms.Form F = null;
                Form fc1 = null;
                this.Cursor = Cursors.WaitCursor;
                switch (Convert.ToInt32(BtnCD))
                {
                    case 1:
                        //Empty
                        break;
                    case 2:
                        /*Internal OS&D
                        Author: DO.IT*/
                        fc1 = Application.OpenForms["FORM_OS_DEFFECTIVE_STATUS"];
                        if (fc1 != null)
                            fc1.Close();
                        FORM_OS_DEFFECTIVE_STATUS DEF = new FORM_OS_DEFFECTIVE_STATUS();
                        F = DEF;
                        //pic_under.Visible = true;
                        break;
                    case 3:
                        /*OS&D
                       Author: DO.IT*/
                        fc1 = Application.OpenForms["FRM_SMT_OS_OSD_MONTH"];
                        if (fc1 != null)
                            fc1.Close();
                        FRM_SMT_OS_OSD_MONTH IN_OSD = new FRM_SMT_OS_OSD_MONTH();
                        F = IN_OSD;

                        break;

                    case 4:
                        /*Mold OverHoul 
                        Author: Ngọc.IT*/
                        fc1 = Application.OpenForms["FORM_OS_MOLD_OVERHAUL"];
                        if (fc1 != null)
                            fc1.Close();
                        FORM_OS_MOLD_OVERHAUL OS_OVERHAUL = new FORM_OS_MOLD_OVERHAUL();
                        F = OS_OVERHAUL;

                        break;
                    case 5:
                        /*Mold Layout 
                       Author: Ngọc.IT*/
                        fc1 = Application.OpenForms["FORM_OS_MACHINE_LAYOUT"];
                        if (fc1 != null)
                            fc1.Close();
                        FORM_OS_MACHINE_LAYOUT OS_LAYOUT = new FORM_OS_MACHINE_LAYOUT();
                        F = OS_LAYOUT;

                        break;
                    case 6:
                        /*Mold Layout 
                     Author: Ngọc.IT*/
                        fc1 = Application.OpenForms["FRM_SMT_OS_MOLD_ACTUAL_PLAN"];
                        if (fc1 != null)
                            fc1.Close();
                        FRM_SMT_OS_MOLD_ACTUAL_PLAN MOLD_PLAN_ACTUAL = new FRM_SMT_OS_MOLD_ACTUAL_PLAN();
                        F = MOLD_PLAN_ACTUAL;
                        break;
                    case 7:
                        /*Production Status
                          Author: DO.IT*/
                        fc1 = Application.OpenForms["FRM_SMT_OS_PROD_DAILY"];
                        if (fc1 != null)
                            fc1.Close();
                        FRM_SMT_OS_PROD_DAILY PROD_STATS = new FRM_SMT_OS_PROD_DAILY();
                        F = PROD_STATS;
                        break;
                    case 8:/*OEE MONTH
                          Author: LUAN.IT*/
                        fc1 = Application.OpenForms["FRM_SMT_OS_OEE"];
                        if (fc1 != null)
                            fc1.Close();
                        Machinery.FRM_SMT_OS_OEE OS_OEE = new Machinery.FRM_SMT_OS_OEE();
                        F = OS_OEE;
                        break;

                    case 9:
                        pic_under.Visible = true;
                        break;
                    case 10:
                        fc1 = Application.OpenForms["FRM_SMT_OS_INVENTORY"];
                        if (fc1 != null)
                            fc1.Close();
                        FRM_SMT_OS_INVENTORY OS_INV = new FRM_SMT_OS_INVENTORY();
                        F = OS_INV;
                        break;
                    case 11:
                        fc1 = Application.OpenForms["FRM_SMT_OS_FSS_INVENTORY"];
                        if (fc1 != null)
                            fc1.Close();
                        FRM_SMT_OS_FSS_INVENTORY OS_FSS_INV = new FRM_SMT_OS_FSS_INVENTORY();
                        F = OS_FSS_INV;
                        break;
                        break;
                    case 12:
                        /*Absent
                          Author: NGOC.IT*/
                        fc1 = Application.OpenForms["FRM_SMT_OS_HR_ABSENT"];
                        if (fc1 != null)
                            fc1.Close();
                        FRM_SMT_OS_HR_ABSENT HR_ABSENT = new FRM_SMT_OS_HR_ABSENT();
                        F = HR_ABSENT;
                        break;
                    case 13:
                        pic_under.Visible = true;
                        break;
                    case 14:
                        pic_under.Visible = true;
                        break;
                    case 15:
                        /*LeadTime
                          Author: NGOC.IT*/
                        fc1 = Application.OpenForms["FORM_SMT_OS_LEADTIME"];
                        if (fc1 != null)
                            fc1.Close();
                        FORM_SMT_OS_LEADTIME LEADTIME_OS = new FORM_SMT_OS_LEADTIME();
                        F = LEADTIME_OS;
                        break;
                    case 50:
                        /*BTS
                         * 
                          Author: PHUOC.IT*/
                        fc1 = Application.OpenForms["FORM_SMT_BTS"];
                        if (fc1 != null)
                            fc1.Close();
                        FRM_SMT_BTS FRM_SMT_BTS = new FRM_SMT_BTS();
                        F = FRM_SMT_BTS;
                        break;
                    case 51:
                        /*BTS
                         * 
                          Author: PHUOC.IT*/
                        fc1 = Application.OpenForms["FORM_SMT_BTS"];
                        if (fc1 != null)
                            fc1.Close();
                        FRM_SMT_OS_TOPO_DAILY FRM_SMT_TOPO = new FRM_SMT_OS_TOPO_DAILY();
                        F = FRM_SMT_TOPO;
                        break;
                    case 16:
                        pic_under.Visible = true;
                        break;
                    default:
                        break;
                }
                if (F != null)
                {

                    F.Show();
                    F.BringToFront();

                    if (Db.INSERT_FRM_LOG("OS_SMT", this.Name + " (Inside Office)", BtnCD, F.Name, "Open Form", GetIP() + "/" + System.Environment.MachineName)) { }
                    this.Cursor = Cursors.Default;
                }
                else
                    this.Cursor = Cursors.Default;


            }
            catch { this.Cursor = Cursors.Default; }
        }

        void MoveLeaveClick(string MenuName, string BtnCD)
        {
            if (pic_under.Visible == true)
            {
                pic_under.Visible = false;
            }
        }


        private string GetIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            return addr[addr.Length - 1].ToString();

        }

        private void lblDateTime_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTitle2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDateTime.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
                cCount++;
                if (cCount >= 30)
                {
                    //splashScreenManager1.ShowWaitForm();
                    //splashScreenManager1.SetWaitFormCaption("Đợi chút...");
                    DataTable dtOSD = Db.SEL_OSD_DATA("Q");
                    DataTable dtPROD = Db.SEL_OS_PRODUCTION_DATA("Q");
                    DataTable dtINV = Db.SEL_OS_INV_DATA("Q");
                    DataTable dtAbsent = Db.SEL_OS_ABSENT_DATA("Q");
                    DataTable dtPOD = Db.SEL_OS_POD_DATA("Q");

                    //  splashScreenManager1.SetWaitFormDescription("Loading Data...");
                    UC_OSD.BindingData(dtOSD);
                    UC_PRODUCTION.BindingData(dtPROD);
                    UC_POD.BindingData(dtPOD);
                    UC_INV.BindingData(dtINV);
                    UC_ABSENT.BindingData(dtAbsent);
                    // splashScreenManager1.CloseWaitForm();
                    cCount = 0;
                }
            }
            catch
            { //splashScreenManager1.CloseWaitForm(); 
            }
        }

        private void btnMoldWH_Click(object sender, EventArgs e)
        {
            try
            {



                string patch = Application.StartupPath + "\\Mold\\MoldOS.exe";
                //string patch = Application.StartupPath + "\\Mold\\WarehouseMaterialSystem.exe";

                if (!ProgramIsRunning(patch))
                {
                     Process.Start(patch);
                }
                else
                {
                    System.Diagnostics.Process result = System.Diagnostics.Process.GetProcessesByName("MoldOS").FirstOrDefault();
                    //SetWindowPos(result.MainWindowHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
                    SwitchToThisWindow(result.MainWindowHandle, false);
                }
            }
            catch 
            {}
            
        }

        //Kiem tra Program co dang chay hay chua?
        private bool ProgramIsRunning(string FullPath)
        {
            try
            {
                string FilePath = Path.GetDirectoryName(FullPath);
                string FileName = Path.GetFileNameWithoutExtension(FullPath).ToLower();
                bool isRunning = false;

                Process[] pList = Process.GetProcessesByName(FileName);
                foreach (Process p in pList)
                    if (p.MainModule.FileName.StartsWith(FilePath, StringComparison.InvariantCultureIgnoreCase))
                    {
                        isRunning = true;
                        break;
                    }

                return isRunning;
            }
            catch
            {

                return false;
            }

        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            try
            {
                //this.Hide();
                //System.Diagnostics.Process result = System.Diagnostics.Process.GetProcessesByName("B1_DASHBOARD").FirstOrDefault();
                ////SetWindowPos(result.MainWindowHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
                //SwitchToThisWindow(FindWindow(IntPtr.Zero, "OutSole Digital Shop Floor"), false);

                //ShowWindow(FindWindow(IntPtr.Zero, "OutSole Digital Shop Floor"), SW_MAXIMIZE);

                if (this.Name != "DIGITAL_SHOP_FLOOR_OS")
                    this.Hide();
                else
                {

                    System.Diagnostics.Process result = System.Diagnostics.Process.GetProcessesByName("B1_DASHBOARD").FirstOrDefault();
                    //SetWindowPos(result.MainWindowHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
                    SwitchToThisWindow(result.MainWindowHandle, true);
                }
                
            }
            catch 
            {}
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form fc1 = null;
            fc1 = Application.OpenForms["FORM_OS_KPI_PERFOMANCE"];
            if (fc1 != null)
                fc1.Close();
            FORM_OS_KPI_PERFOMANCE KPI = new FORM_OS_KPI_PERFOMANCE();
            KPI.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchToThisWindow(dashboard1.MainWindowHandle, false);
                ShowWindow(dashboard1.MainWindowHandle, 3);
            }
            catch
            {
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchToThisWindow(dashboard2.MainWindowHandle, false);
                ShowWindow(dashboard2.MainWindowHandle, 3);
            }
            catch
            {
            }  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchToThisWindow(dashboard3.MainWindowHandle, false);
                ShowWindow(dashboard3.MainWindowHandle, 3);
            }
            catch
            {
            }  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchToThisWindow(dashboard4.MainWindowHandle, false);
                ShowWindow(dashboard4.MainWindowHandle, 3);
            }
            catch
            {
            }  
        }

        private void DIGITAL_SHOP_FLOOR_OS_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                dashboard1.Kill();
                dashboard2.Kill();
                dashboard3.Kill();
                dashboard4.Kill();
            }
            catch
            {


            }
        }
    }
}
