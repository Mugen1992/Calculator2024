namespace MaxFunkCalculator2024
{
    partial class MaxCalculator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaxCalculator));
            EllipseControlMax1 = new EllipseCont.EllipseControlMax();
            PnlTitle = new Panel();
            BtnChangeTheme = new Button();
            BntMaxFGithub = new Button();
            BtnMinimize = new Button();
            CalculatorIcon = new Button();
            BtnCloseWindow = new Button();
            PnlHistory = new Panel();
            RtBoxDisplayHistory = new RichTextBox();
            BtnClearHistory = new Button();
            PnlMenuAndHistory = new Panel();
            BtnGithub = new Button();
            BtnHist = new Button();
            TxtDisplay2 = new TextBox();
            TxtDisplay1 = new TextBox();
            BtnMemStore = new ButtonMax.ButtonMax();
            BtnMemSubstract = new ButtonMax.ButtonMax();
            BtnMemAdd = new ButtonMax.ButtonMax();
            BtnMemClear = new ButtonMax.ButtonMax();
            BtnBackspace = new ButtonMax.ButtonMax();
            Btn7 = new ButtonMax.ButtonMax();
            BtnEquals = new ButtonMax.ButtonMax();
            BtnClear = new ButtonMax.ButtonMax();
            BtnClearEntry = new ButtonMax.ButtonMax();
            BtnPercentage = new ButtonMax.ButtonMax();
            BtnDivision = new ButtonMax.ButtonMax();
            BtnSquareRoot = new ButtonMax.ButtonMax();
            BtnSquareX = new ButtonMax.ButtonMax();
            BtnReciprocal = new ButtonMax.ButtonMax();
            BtnMultiplication = new ButtonMax.ButtonMax();
            BtnSubstraction = new ButtonMax.ButtonMax();
            BtnAddition = new ButtonMax.ButtonMax();
            Btn8 = new ButtonMax.ButtonMax();
            Btn9 = new ButtonMax.ButtonMax();
            Btn4 = new ButtonMax.ButtonMax();
            Btn5 = new ButtonMax.ButtonMax();
            Btn6 = new ButtonMax.ButtonMax();
            Btn1 = new ButtonMax.ButtonMax();
            Btn2 = new ButtonMax.ButtonMax();
            Btn3 = new ButtonMax.ButtonMax();
            BtnChangeSign = new ButtonMax.ButtonMax();
            Btn0 = new ButtonMax.ButtonMax();
            BtnDecimal = new ButtonMax.ButtonMax();
            BtmMemResult = new ButtonMax.ButtonMax();
            TxtDisplayMem = new TextBox();
            PnlTitle.SuspendLayout();
            PnlHistory.SuspendLayout();
            PnlMenuAndHistory.SuspendLayout();
            SuspendLayout();
            // 
            // EllipseControlMax1
            // 
            EllipseControlMax1.CornerRadius = 18;
            EllipseControlMax1.TargetControl = this;
            // 
            // PnlTitle
            // 
            PnlTitle.Controls.Add(BtnChangeTheme);
            PnlTitle.Controls.Add(BntMaxFGithub);
            PnlTitle.Controls.Add(BtnMinimize);
            PnlTitle.Controls.Add(CalculatorIcon);
            PnlTitle.Controls.Add(BtnCloseWindow);
            resources.ApplyResources(PnlTitle, "PnlTitle");
            PnlTitle.Name = "PnlTitle";
            PnlTitle.Paint += PnlTitle_Paint;
            PnlTitle.MouseDown += PnlTitle_MouseDown;
            // 
            // BtnChangeTheme
            // 
            resources.ApplyResources(BtnChangeTheme, "BtnChangeTheme");
            BtnChangeTheme.FlatAppearance.BorderSize = 0;
            BtnChangeTheme.ForeColor = Color.FromArgb(26, 31, 51);
            BtnChangeTheme.Image = Properties.Resources.chtheme_btn_icon_20;
            BtnChangeTheme.Name = "BtnChangeTheme";
            BtnChangeTheme.UseVisualStyleBackColor = true;
            BtnChangeTheme.Click += BtnChangeTheme_Click;
            // 
            // BntMaxFGithub
            // 
            BntMaxFGithub.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BntMaxFGithub, "BntMaxFGithub");
            BntMaxFGithub.ForeColor = Color.Silver;
            BntMaxFGithub.Name = "BntMaxFGithub";
            BntMaxFGithub.UseVisualStyleBackColor = true;
            // 
            // BtnMinimize
            // 
            resources.ApplyResources(BtnMinimize, "BtnMinimize");
            BtnMinimize.FlatAppearance.BorderSize = 0;
            BtnMinimize.ForeColor = Color.FromArgb(26, 31, 51);
            BtnMinimize.Image = Properties.Resources.minimize_btn_icon_15;
            BtnMinimize.Name = "BtnMinimize";
            BtnMinimize.UseVisualStyleBackColor = true;
            BtnMinimize.Click += BtnMinimize_Click;
            // 
            // CalculatorIcon
            // 
            resources.ApplyResources(CalculatorIcon, "CalculatorIcon");
            CalculatorIcon.FlatAppearance.BorderSize = 0;
            CalculatorIcon.ForeColor = Color.FromArgb(26, 31, 51);
            CalculatorIcon.Image = Properties.Resources.Calc_icon_30;
            CalculatorIcon.Name = "CalculatorIcon";
            CalculatorIcon.UseVisualStyleBackColor = true;
            CalculatorIcon.Click += CalculatorIcon_Click;
            // 
            // BtnCloseWindow
            // 
            resources.ApplyResources(BtnCloseWindow, "BtnCloseWindow");
            BtnCloseWindow.FlatAppearance.BorderSize = 0;
            BtnCloseWindow.FlatAppearance.MouseOverBackColor = Color.Red;
            BtnCloseWindow.ForeColor = Color.FromArgb(26, 31, 51);
            BtnCloseWindow.Image = Properties.Resources.close_btn_icon_15;
            BtnCloseWindow.Name = "BtnCloseWindow";
            BtnCloseWindow.UseVisualStyleBackColor = true;
            BtnCloseWindow.Click += BtnCloseWindow_Click;
            // 
            // PnlHistory
            // 
            PnlHistory.Controls.Add(RtBoxDisplayHistory);
            PnlHistory.Controls.Add(BtnClearHistory);
            resources.ApplyResources(PnlHistory, "PnlHistory");
            PnlHistory.Name = "PnlHistory";
            // 
            // RtBoxDisplayHistory
            // 
            RtBoxDisplayHistory.BackColor = Color.FromArgb(26, 31, 51);
            RtBoxDisplayHistory.BorderStyle = BorderStyle.None;
            resources.ApplyResources(RtBoxDisplayHistory, "RtBoxDisplayHistory");
            RtBoxDisplayHistory.ForeColor = Color.Silver;
            RtBoxDisplayHistory.Name = "RtBoxDisplayHistory";
            RtBoxDisplayHistory.ReadOnly = true;
            RtBoxDisplayHistory.TabStop = false;
            // 
            // BtnClearHistory
            // 
            resources.ApplyResources(BtnClearHistory, "BtnClearHistory");
            BtnClearHistory.FlatAppearance.BorderSize = 0;
            BtnClearHistory.Image = Properties.Resources.trash_btn_icon_30;
            BtnClearHistory.Name = "BtnClearHistory";
            BtnClearHistory.UseVisualStyleBackColor = true;
            BtnClearHistory.Click += BtnClearHistory_Click;
            // 
            // PnlMenuAndHistory
            // 
            PnlMenuAndHistory.Controls.Add(BtnGithub);
            PnlMenuAndHistory.Controls.Add(BtnHist);
            resources.ApplyResources(PnlMenuAndHistory, "PnlMenuAndHistory");
            PnlMenuAndHistory.Name = "PnlMenuAndHistory";
            // 
            // BtnGithub
            // 
            resources.ApplyResources(BtnGithub, "BtnGithub");
            BtnGithub.FlatAppearance.BorderSize = 0;
            BtnGithub.ForeColor = Color.Silver;
            BtnGithub.Name = "BtnGithub";
            BtnGithub.UseVisualStyleBackColor = true;
            BtnGithub.Click += BntMaxFGithub_Click;
            // 
            // BtnHist
            // 
            resources.ApplyResources(BtnHist, "BtnHist");
            BtnHist.FlatAppearance.BorderSize = 0;
            BtnHist.Image = Properties.Resources.timemachine_btn_icon_25;
            BtnHist.Name = "BtnHist";
            BtnHist.UseVisualStyleBackColor = true;
            BtnHist.Click += BtnHist_Click;
            // 
            // TxtDisplay2
            // 
            TxtDisplay2.BackColor = Color.FromArgb(26, 31, 51);
            TxtDisplay2.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TxtDisplay2, "TxtDisplay2");
            TxtDisplay2.ForeColor = Color.Silver;
            TxtDisplay2.Name = "TxtDisplay2";
            TxtDisplay2.ReadOnly = true;
            TxtDisplay2.TabStop = false;
            TxtDisplay2.TextChanged += TxtDisplay2_TextChanged;
            // 
            // TxtDisplay1
            // 
            TxtDisplay1.BackColor = Color.FromArgb(26, 31, 51);
            TxtDisplay1.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TxtDisplay1, "TxtDisplay1");
            TxtDisplay1.ForeColor = Color.White;
            TxtDisplay1.Name = "TxtDisplay1";
            TxtDisplay1.ReadOnly = true;
            TxtDisplay1.TabStop = false;
            TxtDisplay1.TextChanged += TxtDisplay1_TextChanged;
            // 
            // BtnMemStore
            // 
            BtnMemStore.BackColor = Color.FromArgb(26, 31, 51);
            BtnMemStore.BackgroundColor = Color.FromArgb(26, 31, 51);
            BtnMemStore.BorderColor = Color.FromArgb(26, 31, 51);
            BtnMemStore.BorderRadius = 20;
            BtnMemStore.BorderSize = 0;
            BtnMemStore.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnMemStore, "BtnMemStore");
            BtnMemStore.ForeColor = Color.White;
            BtnMemStore.Name = "BtnMemStore";
            BtnMemStore.TextColor = Color.White;
            BtnMemStore.UseVisualStyleBackColor = false;
            BtnMemStore.Click += BtnMemStore_Click;
            // 
            // BtnMemSubstract
            // 
            BtnMemSubstract.BackColor = Color.FromArgb(26, 31, 51);
            BtnMemSubstract.BackgroundColor = Color.FromArgb(26, 31, 51);
            BtnMemSubstract.BorderColor = Color.FromArgb(26, 31, 51);
            BtnMemSubstract.BorderRadius = 20;
            BtnMemSubstract.BorderSize = 0;
            BtnMemSubstract.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnMemSubstract, "BtnMemSubstract");
            BtnMemSubstract.ForeColor = Color.White;
            BtnMemSubstract.Name = "BtnMemSubstract";
            BtnMemSubstract.TextColor = Color.White;
            BtnMemSubstract.UseVisualStyleBackColor = false;
            BtnMemSubstract.Click += BtnMemSubstract_Click;
            // 
            // BtnMemAdd
            // 
            BtnMemAdd.BackColor = Color.FromArgb(26, 31, 51);
            BtnMemAdd.BackgroundColor = Color.FromArgb(26, 31, 51);
            BtnMemAdd.BorderColor = Color.FromArgb(26, 31, 51);
            BtnMemAdd.BorderRadius = 20;
            BtnMemAdd.BorderSize = 0;
            BtnMemAdd.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnMemAdd, "BtnMemAdd");
            BtnMemAdd.ForeColor = Color.White;
            BtnMemAdd.Name = "BtnMemAdd";
            BtnMemAdd.TextColor = Color.White;
            BtnMemAdd.UseVisualStyleBackColor = false;
            BtnMemAdd.Click += BtnMemAdd_Click;
            // 
            // BtnMemClear
            // 
            BtnMemClear.BackColor = Color.FromArgb(26, 31, 51);
            BtnMemClear.BackgroundColor = Color.FromArgb(26, 31, 51);
            BtnMemClear.BorderColor = Color.FromArgb(26, 31, 51);
            BtnMemClear.BorderRadius = 20;
            BtnMemClear.BorderSize = 0;
            resources.ApplyResources(BtnMemClear, "BtnMemClear");
            BtnMemClear.FlatAppearance.BorderSize = 0;
            BtnMemClear.ForeColor = Color.White;
            BtnMemClear.Name = "BtnMemClear";
            BtnMemClear.TextColor = Color.White;
            BtnMemClear.UseVisualStyleBackColor = false;
            BtnMemClear.Click += BtnMemClear_Click;
            // 
            // BtnBackspace
            // 
            BtnBackspace.BackColor = Color.FromArgb(38, 43, 60);
            BtnBackspace.BackgroundColor = Color.FromArgb(38, 43, 60);
            BtnBackspace.BorderColor = Color.FromArgb(26, 31, 51);
            BtnBackspace.BorderRadius = 20;
            BtnBackspace.BorderSize = 0;
            BtnBackspace.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnBackspace, "BtnBackspace");
            BtnBackspace.ForeColor = Color.FromArgb(26, 31, 51);
            BtnBackspace.Name = "BtnBackspace";
            BtnBackspace.TextColor = Color.FromArgb(26, 31, 51);
            BtnBackspace.UseVisualStyleBackColor = false;
            BtnBackspace.Click += BtnBackspace_Click;
            // 
            // Btn7
            // 
            Btn7.BackColor = Color.FromArgb(53, 58, 78);
            Btn7.BackgroundColor = Color.FromArgb(53, 58, 78);
            Btn7.BorderColor = Color.FromArgb(26, 31, 51);
            Btn7.BorderRadius = 20;
            Btn7.BorderSize = 0;
            Btn7.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(Btn7, "Btn7");
            Btn7.ForeColor = Color.White;
            Btn7.Name = "Btn7";
            Btn7.TextColor = Color.White;
            Btn7.UseVisualStyleBackColor = false;
            Btn7.Click += BtnNum_Click;
            // 
            // BtnEquals
            // 
            BtnEquals.BackColor = Color.FromArgb(76, 194, 255);
            BtnEquals.BackgroundColor = Color.FromArgb(76, 194, 255);
            BtnEquals.BorderColor = Color.FromArgb(26, 31, 51);
            BtnEquals.BorderRadius = 20;
            BtnEquals.BorderSize = 0;
            BtnEquals.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnEquals, "BtnEquals");
            BtnEquals.ForeColor = Color.Black;
            BtnEquals.Name = "BtnEquals";
            BtnEquals.TextColor = Color.Black;
            BtnEquals.UseVisualStyleBackColor = false;
            BtnEquals.Click += BtnEquals_Click;
            // 
            // BtnClear
            // 
            BtnClear.BackColor = Color.FromArgb(38, 43, 60);
            BtnClear.BackgroundColor = Color.FromArgb(38, 43, 60);
            BtnClear.BorderColor = Color.FromArgb(26, 31, 51);
            BtnClear.BorderRadius = 20;
            BtnClear.BorderSize = 0;
            BtnClear.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnClear, "BtnClear");
            BtnClear.ForeColor = Color.White;
            BtnClear.Name = "BtnClear";
            BtnClear.TextColor = Color.White;
            BtnClear.UseVisualStyleBackColor = false;
            BtnClear.Click += BtnClear_Click;
            // 
            // BtnClearEntry
            // 
            BtnClearEntry.BackColor = Color.FromArgb(38, 43, 60);
            BtnClearEntry.BackgroundColor = Color.FromArgb(38, 43, 60);
            BtnClearEntry.BorderColor = Color.FromArgb(26, 31, 51);
            BtnClearEntry.BorderRadius = 20;
            BtnClearEntry.BorderSize = 0;
            BtnClearEntry.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnClearEntry, "BtnClearEntry");
            BtnClearEntry.ForeColor = Color.White;
            BtnClearEntry.Name = "BtnClearEntry";
            BtnClearEntry.TextColor = Color.White;
            BtnClearEntry.UseVisualStyleBackColor = false;
            BtnClearEntry.Click += BtnClearEntry_Click;
            // 
            // BtnPercentage
            // 
            BtnPercentage.BackColor = Color.FromArgb(38, 43, 60);
            BtnPercentage.BackgroundColor = Color.FromArgb(38, 43, 60);
            BtnPercentage.BorderColor = Color.FromArgb(26, 31, 51);
            BtnPercentage.BorderRadius = 20;
            BtnPercentage.BorderSize = 0;
            BtnPercentage.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnPercentage, "BtnPercentage");
            BtnPercentage.ForeColor = Color.White;
            BtnPercentage.Name = "BtnPercentage";
            BtnPercentage.TextColor = Color.White;
            BtnPercentage.UseVisualStyleBackColor = false;
            BtnPercentage.Click += BtnOperations_Click;
            // 
            // BtnDivision
            // 
            BtnDivision.BackColor = Color.FromArgb(38, 43, 60);
            BtnDivision.BackgroundColor = Color.FromArgb(38, 43, 60);
            BtnDivision.BorderColor = Color.FromArgb(26, 31, 51);
            BtnDivision.BorderRadius = 20;
            BtnDivision.BorderSize = 0;
            BtnDivision.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnDivision, "BtnDivision");
            BtnDivision.ForeColor = Color.White;
            BtnDivision.Name = "BtnDivision";
            BtnDivision.TextColor = Color.White;
            BtnDivision.UseVisualStyleBackColor = false;
            BtnDivision.Click += BtnMathOperation_Click;
            // 
            // BtnSquareRoot
            // 
            BtnSquareRoot.BackColor = Color.FromArgb(38, 43, 60);
            BtnSquareRoot.BackgroundColor = Color.FromArgb(38, 43, 60);
            BtnSquareRoot.BorderColor = Color.FromArgb(26, 31, 51);
            BtnSquareRoot.BorderRadius = 20;
            BtnSquareRoot.BorderSize = 0;
            BtnSquareRoot.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnSquareRoot, "BtnSquareRoot");
            BtnSquareRoot.ForeColor = Color.White;
            BtnSquareRoot.Name = "BtnSquareRoot";
            BtnSquareRoot.TextColor = Color.White;
            BtnSquareRoot.UseVisualStyleBackColor = false;
            BtnSquareRoot.Click += BtnOperations_Click;
            // 
            // BtnSquareX
            // 
            BtnSquareX.BackColor = Color.FromArgb(38, 43, 60);
            BtnSquareX.BackgroundColor = Color.FromArgb(38, 43, 60);
            BtnSquareX.BorderColor = Color.FromArgb(26, 31, 51);
            BtnSquareX.BorderRadius = 20;
            BtnSquareX.BorderSize = 0;
            BtnSquareX.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnSquareX, "BtnSquareX");
            BtnSquareX.ForeColor = Color.White;
            BtnSquareX.Name = "BtnSquareX";
            BtnSquareX.TextColor = Color.White;
            BtnSquareX.UseVisualStyleBackColor = false;
            BtnSquareX.Click += BtnOperations_Click;
            // 
            // BtnReciprocal
            // 
            BtnReciprocal.BackColor = Color.FromArgb(38, 43, 60);
            BtnReciprocal.BackgroundColor = Color.FromArgb(38, 43, 60);
            BtnReciprocal.BorderColor = Color.FromArgb(26, 31, 51);
            BtnReciprocal.BorderRadius = 20;
            BtnReciprocal.BorderSize = 0;
            BtnReciprocal.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnReciprocal, "BtnReciprocal");
            BtnReciprocal.ForeColor = Color.White;
            BtnReciprocal.Name = "BtnReciprocal";
            BtnReciprocal.TextColor = Color.White;
            BtnReciprocal.UseVisualStyleBackColor = false;
            BtnReciprocal.Click += BtnOperations_Click;
            // 
            // BtnMultiplication
            // 
            BtnMultiplication.BackColor = Color.FromArgb(38, 43, 60);
            BtnMultiplication.BackgroundColor = Color.FromArgb(38, 43, 60);
            BtnMultiplication.BorderColor = Color.FromArgb(26, 31, 51);
            BtnMultiplication.BorderRadius = 20;
            BtnMultiplication.BorderSize = 0;
            BtnMultiplication.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnMultiplication, "BtnMultiplication");
            BtnMultiplication.ForeColor = Color.White;
            BtnMultiplication.Name = "BtnMultiplication";
            BtnMultiplication.TextColor = Color.White;
            BtnMultiplication.UseVisualStyleBackColor = false;
            BtnMultiplication.Click += BtnMathOperation_Click;
            // 
            // BtnSubstraction
            // 
            BtnSubstraction.BackColor = Color.FromArgb(38, 43, 60);
            BtnSubstraction.BackgroundColor = Color.FromArgb(38, 43, 60);
            BtnSubstraction.BorderColor = Color.FromArgb(26, 31, 51);
            BtnSubstraction.BorderRadius = 20;
            BtnSubstraction.BorderSize = 0;
            BtnSubstraction.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnSubstraction, "BtnSubstraction");
            BtnSubstraction.ForeColor = Color.White;
            BtnSubstraction.Name = "BtnSubstraction";
            BtnSubstraction.TextColor = Color.White;
            BtnSubstraction.UseVisualStyleBackColor = false;
            BtnSubstraction.Click += BtnMathOperation_Click;
            // 
            // BtnAddition
            // 
            BtnAddition.BackColor = Color.FromArgb(38, 43, 60);
            BtnAddition.BackgroundColor = Color.FromArgb(38, 43, 60);
            BtnAddition.BorderColor = Color.FromArgb(26, 31, 51);
            BtnAddition.BorderRadius = 20;
            BtnAddition.BorderSize = 0;
            BtnAddition.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnAddition, "BtnAddition");
            BtnAddition.ForeColor = Color.White;
            BtnAddition.Name = "BtnAddition";
            BtnAddition.TextColor = Color.White;
            BtnAddition.UseVisualStyleBackColor = false;
            BtnAddition.Click += BtnMathOperation_Click;
            // 
            // Btn8
            // 
            Btn8.BackColor = Color.FromArgb(53, 58, 78);
            Btn8.BackgroundColor = Color.FromArgb(53, 58, 78);
            Btn8.BorderColor = Color.FromArgb(26, 31, 51);
            Btn8.BorderRadius = 20;
            Btn8.BorderSize = 0;
            Btn8.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(Btn8, "Btn8");
            Btn8.ForeColor = Color.White;
            Btn8.Name = "Btn8";
            Btn8.TextColor = Color.White;
            Btn8.UseVisualStyleBackColor = false;
            Btn8.Click += BtnNum_Click;
            // 
            // Btn9
            // 
            Btn9.BackColor = Color.FromArgb(53, 58, 78);
            Btn9.BackgroundColor = Color.FromArgb(53, 58, 78);
            Btn9.BorderColor = Color.FromArgb(26, 31, 51);
            Btn9.BorderRadius = 20;
            Btn9.BorderSize = 0;
            Btn9.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(Btn9, "Btn9");
            Btn9.ForeColor = Color.White;
            Btn9.Name = "Btn9";
            Btn9.TabStop = false;
            Btn9.TextColor = Color.White;
            Btn9.UseVisualStyleBackColor = false;
            Btn9.Click += BtnNum_Click;
            // 
            // Btn4
            // 
            Btn4.BackColor = Color.FromArgb(53, 58, 78);
            Btn4.BackgroundColor = Color.FromArgb(53, 58, 78);
            Btn4.BorderColor = Color.FromArgb(26, 31, 51);
            Btn4.BorderRadius = 20;
            Btn4.BorderSize = 0;
            Btn4.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(Btn4, "Btn4");
            Btn4.ForeColor = Color.White;
            Btn4.Name = "Btn4";
            Btn4.TextColor = Color.White;
            Btn4.UseVisualStyleBackColor = false;
            Btn4.Click += BtnNum_Click;
            // 
            // Btn5
            // 
            Btn5.BackColor = Color.FromArgb(53, 58, 78);
            Btn5.BackgroundColor = Color.FromArgb(53, 58, 78);
            Btn5.BorderColor = Color.FromArgb(26, 31, 51);
            Btn5.BorderRadius = 20;
            Btn5.BorderSize = 0;
            Btn5.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(Btn5, "Btn5");
            Btn5.ForeColor = Color.White;
            Btn5.Name = "Btn5";
            Btn5.TextColor = Color.White;
            Btn5.UseVisualStyleBackColor = false;
            Btn5.Click += BtnNum_Click;
            // 
            // Btn6
            // 
            Btn6.BackColor = Color.FromArgb(53, 58, 78);
            Btn6.BackgroundColor = Color.FromArgb(53, 58, 78);
            Btn6.BorderColor = Color.FromArgb(26, 31, 51);
            Btn6.BorderRadius = 20;
            Btn6.BorderSize = 0;
            Btn6.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(Btn6, "Btn6");
            Btn6.ForeColor = Color.White;
            Btn6.Name = "Btn6";
            Btn6.TextColor = Color.White;
            Btn6.UseVisualStyleBackColor = false;
            Btn6.Click += BtnNum_Click;
            // 
            // Btn1
            // 
            Btn1.BackColor = Color.FromArgb(53, 58, 78);
            Btn1.BackgroundColor = Color.FromArgb(53, 58, 78);
            Btn1.BorderColor = Color.FromArgb(26, 31, 51);
            Btn1.BorderRadius = 20;
            Btn1.BorderSize = 0;
            Btn1.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(Btn1, "Btn1");
            Btn1.ForeColor = Color.White;
            Btn1.Name = "Btn1";
            Btn1.TextColor = Color.White;
            Btn1.UseVisualStyleBackColor = false;
            Btn1.Click += BtnNum_Click;
            // 
            // Btn2
            // 
            Btn2.BackColor = Color.FromArgb(53, 58, 78);
            Btn2.BackgroundColor = Color.FromArgb(53, 58, 78);
            Btn2.BorderColor = Color.FromArgb(26, 31, 51);
            Btn2.BorderRadius = 20;
            Btn2.BorderSize = 0;
            Btn2.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(Btn2, "Btn2");
            Btn2.ForeColor = Color.White;
            Btn2.Name = "Btn2";
            Btn2.TextColor = Color.White;
            Btn2.UseVisualStyleBackColor = false;
            Btn2.Click += BtnNum_Click;
            // 
            // Btn3
            // 
            Btn3.BackColor = Color.FromArgb(53, 58, 78);
            Btn3.BackgroundColor = Color.FromArgb(53, 58, 78);
            Btn3.BorderColor = Color.FromArgb(26, 31, 51);
            Btn3.BorderRadius = 20;
            Btn3.BorderSize = 0;
            Btn3.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(Btn3, "Btn3");
            Btn3.ForeColor = Color.White;
            Btn3.Name = "Btn3";
            Btn3.TextColor = Color.White;
            Btn3.UseVisualStyleBackColor = false;
            Btn3.Click += BtnNum_Click;
            // 
            // BtnChangeSign
            // 
            BtnChangeSign.BackColor = Color.FromArgb(53, 58, 78);
            BtnChangeSign.BackgroundColor = Color.FromArgb(53, 58, 78);
            BtnChangeSign.BorderColor = Color.FromArgb(26, 31, 51);
            BtnChangeSign.BorderRadius = 20;
            BtnChangeSign.BorderSize = 0;
            BtnChangeSign.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnChangeSign, "BtnChangeSign");
            BtnChangeSign.ForeColor = Color.White;
            BtnChangeSign.Name = "BtnChangeSign";
            BtnChangeSign.TextColor = Color.White;
            BtnChangeSign.UseVisualStyleBackColor = false;
            BtnChangeSign.Click += BtnOperations_Click;
            // 
            // Btn0
            // 
            Btn0.BackColor = Color.FromArgb(53, 58, 78);
            Btn0.BackgroundColor = Color.FromArgb(53, 58, 78);
            Btn0.BorderColor = Color.FromArgb(26, 31, 51);
            Btn0.BorderRadius = 20;
            Btn0.BorderSize = 0;
            Btn0.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(Btn0, "Btn0");
            Btn0.ForeColor = Color.White;
            Btn0.Name = "Btn0";
            Btn0.TextColor = Color.White;
            Btn0.UseVisualStyleBackColor = false;
            Btn0.Click += BtnNum_Click;
            // 
            // BtnDecimal
            // 
            BtnDecimal.BackColor = Color.FromArgb(53, 58, 78);
            BtnDecimal.BackgroundColor = Color.FromArgb(53, 58, 78);
            BtnDecimal.BorderColor = Color.FromArgb(26, 31, 51);
            BtnDecimal.BorderRadius = 20;
            BtnDecimal.BorderSize = 0;
            BtnDecimal.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(BtnDecimal, "BtnDecimal");
            BtnDecimal.ForeColor = Color.White;
            BtnDecimal.Name = "BtnDecimal";
            BtnDecimal.TextColor = Color.White;
            BtnDecimal.UseVisualStyleBackColor = false;
            BtnDecimal.Click += BtnNum_Click;
            // 
            // BtmMemResult
            // 
            BtmMemResult.BackColor = Color.FromArgb(26, 31, 51);
            BtmMemResult.BackgroundColor = Color.FromArgb(26, 31, 51);
            BtmMemResult.BorderColor = Color.FromArgb(26, 31, 51);
            BtmMemResult.BorderRadius = 20;
            BtmMemResult.BorderSize = 0;
            resources.ApplyResources(BtmMemResult, "BtmMemResult");
            BtmMemResult.FlatAppearance.BorderSize = 0;
            BtmMemResult.ForeColor = Color.White;
            BtmMemResult.Name = "BtmMemResult";
            BtmMemResult.TextColor = Color.White;
            BtmMemResult.UseVisualStyleBackColor = false;
            BtmMemResult.Click += BtmMemResult_Click;
            // 
            // TxtDisplayMem
            // 
            TxtDisplayMem.BackColor = Color.FromArgb(26, 31, 51);
            TxtDisplayMem.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TxtDisplayMem, "TxtDisplayMem");
            TxtDisplayMem.ForeColor = Color.Silver;
            TxtDisplayMem.Name = "TxtDisplayMem";
            TxtDisplayMem.ReadOnly = true;
            TxtDisplayMem.TabStop = false;
            TxtDisplayMem.TextChanged += TxtDisplayMem_TextChanged;
            // 
            // MaxCalculator
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(26, 31, 51);
            resources.ApplyResources(this, "$this");
            Controls.Add(TxtDisplayMem);
            Controls.Add(BtmMemResult);
            Controls.Add(PnlHistory);
            Controls.Add(BtnReciprocal);
            Controls.Add(BtnPercentage);
            Controls.Add(BtnSquareX);
            Controls.Add(BtnClearEntry);
            Controls.Add(BtnSquareRoot);
            Controls.Add(BtnClear);
            Controls.Add(BtnEquals);
            Controls.Add(BtnDecimal);
            Controls.Add(Btn0);
            Controls.Add(Btn3);
            Controls.Add(Btn2);
            Controls.Add(Btn6);
            Controls.Add(BtnChangeSign);
            Controls.Add(Btn5);
            Controls.Add(Btn1);
            Controls.Add(Btn9);
            Controls.Add(Btn4);
            Controls.Add(Btn8);
            Controls.Add(Btn7);
            Controls.Add(BtnAddition);
            Controls.Add(BtnSubstraction);
            Controls.Add(BtnMultiplication);
            Controls.Add(BtnDivision);
            Controls.Add(BtnBackspace);
            Controls.Add(BtnMemClear);
            Controls.Add(BtnMemAdd);
            Controls.Add(BtnMemSubstract);
            Controls.Add(BtnMemStore);
            Controls.Add(TxtDisplay1);
            Controls.Add(TxtDisplay2);
            Controls.Add(PnlMenuAndHistory);
            Controls.Add(PnlTitle);
            ForeColor = Color.FromArgb(26, 31, 51);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MaxCalculator";
            PnlTitle.ResumeLayout(false);
            PnlHistory.ResumeLayout(false);
            PnlMenuAndHistory.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private EllipseCont.EllipseControlMax EllipseControlMax1;
        private Panel PnlTitle;
        private Panel PnlHistory;
        private Button BtnCloseWindow;
        private Button BtnMinimize;
        private Button CalculatorIcon;
        private Panel PnlMenuAndHistory;
        private Button BtnHist;
        private TextBox TxtDisplay2;
        private TextBox TxtDisplay1;
        private Button BtnClearHistory;
        private RichTextBox RtBoxDisplayHistory;
        private ButtonMax.ButtonMax BtnMemClear;
        private ButtonMax.ButtonMax BtnMemAdd;
        private ButtonMax.ButtonMax BtnMemSubstract;
        private ButtonMax.ButtonMax BtnMemStore;
        private ButtonMax.ButtonMax BtnBackspace;
        private ButtonMax.ButtonMax Btn7;
        private ButtonMax.ButtonMax BtnEquals;
        private ButtonMax.ButtonMax BtnClearEntry;
        private ButtonMax.ButtonMax BtnClear;
        private ButtonMax.ButtonMax BtnPercentage;
        private ButtonMax.ButtonMax BtnReciprocal;
        private ButtonMax.ButtonMax BtnSquareX;
        private ButtonMax.ButtonMax BtnSquareRoot;
        private ButtonMax.ButtonMax BtnDivision;
        private ButtonMax.ButtonMax BtnAddition;
        private ButtonMax.ButtonMax BtnSubstraction;
        private ButtonMax.ButtonMax BtnMultiplication;
        private ButtonMax.ButtonMax Btn0;
        private ButtonMax.ButtonMax Btn3;
        private ButtonMax.ButtonMax Btn2;
        private ButtonMax.ButtonMax Btn6;
        private ButtonMax.ButtonMax BtnChangeSign;
        private ButtonMax.ButtonMax Btn5;
        private ButtonMax.ButtonMax Btn1;
        private ButtonMax.ButtonMax Btn9;
        private ButtonMax.ButtonMax Btn4;
        private ButtonMax.ButtonMax Btn8;
        private ButtonMax.ButtonMax BtnDecimal;
        private ButtonMax.ButtonMax BtmMemResult;
        private Button BntMaxFGithub;
        private Button BtnChangeTheme;
        private Button BtnGithub;
        private TextBox TxtDisplayMem;
    }

}
