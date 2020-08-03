namespace OS_DSF.Machinery
{
    partial class FRM_SMT_OS_OEE_YEAR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.XYDiagram xyDiagram3 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.ConstantLine constantLine3 = new DevExpress.XtraCharts.ConstantLine();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel3 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView3 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uc_year = new OS_DSF.UC.UC_YEAR_SELECTION();
            this.ChartOEE = new DevExpress.XtraCharts.ChartControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grdBase = new DevExpress.XtraGrid.GridControl();
            this.gvwBase = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnYMD = new System.Windows.Forms.Panel();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartOEE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwBase)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Turquoise;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1920, 100);
            this.lblTitle.TabIndex = 687;
            this.lblTitle.Text = "Outsole Machine OEE By Year";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uc_year);
            this.panel1.Controls.Add(this.ChartOEE);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 509);
            this.panel1.TabIndex = 688;
            // 
            // uc_year
            // 
            this.uc_year.AutoSize = true;
            this.uc_year.Location = new System.Drawing.Point(10, 4);
            this.uc_year.Name = "uc_year";
            this.uc_year.Size = new System.Drawing.Size(229, 47);
            this.uc_year.TabIndex = 10;
            this.uc_year.ValueChangeEvent += new System.EventHandler(this.uc_year_ValueChangeEvent);
            this.uc_year.Load += new System.EventHandler(this.uc_year_Load);
            // 
            // ChartOEE
            // 
            this.ChartOEE.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.ChartOEE.DataBindings = null;
            xyDiagram3.AxisX.Label.Angle = -35;
            xyDiagram3.AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
            xyDiagram3.AxisX.Title.Text = "Machine";
            xyDiagram3.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram3.AxisX.VisibleInPanesSerializable = "-1";
            constantLine3.AxisValueSerializable = "80";
            constantLine3.Color = System.Drawing.Color.DeepPink;
            constantLine3.LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            constantLine3.LineStyle.Thickness = 2;
            constantLine3.Name = "OEE Target";
            constantLine3.Title.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            constantLine3.Title.ShowBelowLine = true;
            constantLine3.Title.Text = "Target: 80%";
            constantLine3.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(48)))), ((int)(((byte)(160)))));
            xyDiagram3.AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] {
            constantLine3});
            xyDiagram3.AxisY.Title.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram3.AxisY.Title.Text = "Percent (%)";
            xyDiagram3.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram3.AxisY.VisibleInPanesSerializable = "-1";
            this.ChartOEE.Diagram = xyDiagram3;
            this.ChartOEE.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ChartOEE.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.ChartOEE.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.ChartOEE.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.ChartOEE.Legend.Name = "Default Legend";
            this.ChartOEE.Location = new System.Drawing.Point(0, 57);
            this.ChartOEE.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.ChartOEE.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ChartOEE.Name = "ChartOEE";
            sideBySideBarSeriesLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))));
            sideBySideBarSeriesLabel3.Border.Color = System.Drawing.Color.Red;
            sideBySideBarSeriesLabel3.Border.Thickness = 2;
            sideBySideBarSeriesLabel3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sideBySideBarSeriesLabel3.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            sideBySideBarSeriesLabel3.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;
            sideBySideBarSeriesLabel3.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(96)))));
            series3.Label = sideBySideBarSeriesLabel3;
            series3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series3.Name = "OEE";
            sideBySideBarSeriesView3.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            sideBySideBarSeriesView3.Color = System.Drawing.Color.RoyalBlue;
            sideBySideBarSeriesView3.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Hatch;
            series3.View = sideBySideBarSeriesView3;
            this.ChartOEE.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series3};
            this.ChartOEE.Size = new System.Drawing.Size(1920, 452);
            this.ChartOEE.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdBase);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 609);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1920, 496);
            this.panel2.TabIndex = 689;
            // 
            // grdBase
            // 
            this.grdBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBase.Location = new System.Drawing.Point(0, 0);
            this.grdBase.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.grdBase.MainView = this.gvwBase;
            this.grdBase.Name = "grdBase";
            this.grdBase.Size = new System.Drawing.Size(1920, 496);
            this.grdBase.TabIndex = 1;
            this.grdBase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwBase});
            // 
            // gvwBase
            // 
            this.gvwBase.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Black;
            this.gvwBase.Appearance.HeaderPanel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvwBase.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvwBase.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvwBase.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvwBase.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvwBase.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvwBase.Appearance.HorzLine.BackColor = System.Drawing.Color.Black;
            this.gvwBase.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvwBase.Appearance.Row.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvwBase.Appearance.Row.Options.UseFont = true;
            this.gvwBase.Appearance.Row.Options.UseTextOptions = true;
            this.gvwBase.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvwBase.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvwBase.Appearance.VertLine.BackColor = System.Drawing.Color.Black;
            this.gvwBase.Appearance.VertLine.Options.UseBackColor = true;
            this.gvwBase.ColumnPanelRowHeight = 40;
            this.gvwBase.DetailHeight = 360;
            this.gvwBase.GridControl = this.grdBase;
            this.gvwBase.Name = "gvwBase";
            this.gvwBase.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.False;
            this.gvwBase.OptionsBehavior.Editable = false;
            this.gvwBase.OptionsCustomization.AllowColumnMoving = false;
            this.gvwBase.OptionsCustomization.AllowColumnResizing = false;
            this.gvwBase.OptionsCustomization.AllowFilter = false;
            this.gvwBase.OptionsCustomization.AllowGroup = false;
            this.gvwBase.OptionsCustomization.AllowSort = false;
            this.gvwBase.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gvwBase.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gvwBase.OptionsFilter.AllowFilterEditor = false;
            this.gvwBase.OptionsFind.AllowFindPanel = false;
            this.gvwBase.OptionsHint.ShowColumnHeaderHints = false;
            this.gvwBase.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvwBase.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvwBase.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gvwBase.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvwBase.OptionsView.ShowGroupPanel = false;
            this.gvwBase.OptionsView.ShowIndicator = false;
            this.gvwBase.RowHeight = 30;
            this.gvwBase.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(this.gvwBase_CustomDrawColumnHeader_1);
            this.gvwBase.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvwBase_RowCellStyle);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnYMD
            // 
            this.pnYMD.BackColor = System.Drawing.Color.Turquoise;
            this.pnYMD.Location = new System.Drawing.Point(1169, 4);
            this.pnYMD.Name = "pnYMD";
            this.pnYMD.Size = new System.Drawing.Size(450, 96);
            this.pnYMD.TabIndex = 692;
            // 
            // lblDateTime
            // 
            this.lblDateTime.BackColor = System.Drawing.Color.Turquoise;
            this.lblDateTime.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(1679, 0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(225, 100);
            this.lblDateTime.TabIndex = 693;
            this.lblDateTime.Text = "20-10-2018\r\n00:00:00";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FRM_SMT_OS_OEE_YEAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.pnYMD);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_SMT_OS_OEE_YEAR";
            this.Text = "FRM_SMT_OS_OEE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_SMT_OS_OEE_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartOEE)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraCharts.ChartControl ChartOEE;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl grdBase;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwBase;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnYMD;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer timer2;
        private UC.UC_YEAR_SELECTION uc_year;

    }
}