namespace FOOTBALL
{
	partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxTeams = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTeamStats = new System.Windows.Forms.TabPage();
            this.lineGraphTeamStats = new FOOTBALL.LineGraph();
            this.barGraph1 = new FOOTBALL.BarGraph();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tabPagePlayerStats = new System.Windows.Forms.TabPage();
            this.lineGraphFieldGoal = new FOOTBALL.LineGraph();
            this.lineGraphSteal = new FOOTBALL.LineGraph();
            this.lineGraphBlock = new FOOTBALL.LineGraph();
            this.lineGraphOffensiveRebound = new FOOTBALL.LineGraph();
            this.lineGraphTurnover = new FOOTBALL.LineGraph();
            this.lineGraphFreeThrow = new FOOTBALL.LineGraph();
            this.lineGraphRebound = new FOOTBALL.LineGraph();
            this.lineGraphMinutes = new FOOTBALL.LineGraph();
            this.lineGraphDefensiveRebound = new FOOTBALL.LineGraph();
            this.lineGraphAssist = new FOOTBALL.LineGraph();
            this.lineGraphPoint = new FOOTBALL.LineGraph();
            this.lineGraphThreePoint = new FOOTBALL.LineGraph();
            this.tabPageBracket = new System.Windows.Forms.TabPage();
            this.bracketGraph1 = new FOOTBALL.BracketGraph();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.scatterPlot1 = new FOOTBALL.ScatterPlot();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.tabPpgRatio = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.scatterPlot2 = new FOOTBALL.ScatterPlot();
            this.tabControl1.SuspendLayout();
            this.tabPageTeamStats.SuspendLayout();
            this.tabPagePlayerStats.SuspendLayout();
            this.tabPageBracket.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPpgRatio.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(5, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Team";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 5;
            // 
            // listBoxTeams
            // 
            this.listBoxTeams.FormattingEnabled = true;
            this.listBoxTeams.Location = new System.Drawing.Point(5, 58);
            this.listBoxTeams.Name = "listBoxTeams";
            this.listBoxTeams.Size = new System.Drawing.Size(120, 238);
            this.listBoxTeams.TabIndex = 6;
            this.listBoxTeams.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTeamStats);
            this.tabControl1.Controls.Add(this.tabPagePlayerStats);
            this.tabControl1.Controls.Add(this.tabPageBracket);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPpgRatio);
            this.tabControl1.Location = new System.Drawing.Point(12, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1153, 586);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPageTeamStats
            // 
            this.tabPageTeamStats.Controls.Add(this.lineGraphTeamStats);
            this.tabPageTeamStats.Controls.Add(this.barGraph1);
            this.tabPageTeamStats.Controls.Add(this.listBox1);
            this.tabPageTeamStats.Controls.Add(this.label2);
            this.tabPageTeamStats.Controls.Add(this.comboBox2);
            this.tabPageTeamStats.Location = new System.Drawing.Point(4, 22);
            this.tabPageTeamStats.Name = "tabPageTeamStats";
            this.tabPageTeamStats.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTeamStats.Size = new System.Drawing.Size(1145, 560);
            this.tabPageTeamStats.TabIndex = 1;
            this.tabPageTeamStats.Text = "Team Stats";
            this.tabPageTeamStats.UseVisualStyleBackColor = true;
            // 
            // lineGraphTeamStats
            // 
            this.lineGraphTeamStats.Location = new System.Drawing.Point(230, 287);
            this.lineGraphTeamStats.Name = "lineGraphTeamStats";
            this.lineGraphTeamStats.RefreshRate = 20;
            this.lineGraphTeamStats.Size = new System.Drawing.Size(911, 267);
            this.lineGraphTeamStats.TabIndex = 11;
            this.lineGraphTeamStats.Text = "Team Stats";
            this.lineGraphTeamStats.Click += new System.EventHandler(this.lineGraphTeamStats_Click);
            // 
            // barGraph1
            // 
            this.barGraph1.Location = new System.Drawing.Point(230, 6);
            this.barGraph1.Name = "barGraph1";
            this.barGraph1.RefreshRate = 20;
            this.barGraph1.Size = new System.Drawing.Size(911, 275);
            this.barGraph1.TabIndex = 10;
            // 
            // listBox1
            // 
            this.listBox1.Enabled = false;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Points Per Game",
            "Field Goal Percentage",
            "Free Throw Percentage",
            "Three Point Percentage",
            "Average Offensive PPG Ratio",
            "Points Allowed Per Game",
            "Opponent Field Goal Percentage",
            "Opponent Free Throw Percentage",
            "Opponent Three Point Percentage",
            "Opponent Field Goal Percentage Ratio",
            "Opponent Free Throw Percentage Ratio",
            "Opponent Three Point Percentage Ratio"});
            this.listBox1.Location = new System.Drawing.Point(5, 53);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(219, 238);
            this.listBox1.TabIndex = 9;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Team";
            // 
            // comboBox2
            // 
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(5, 23);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(219, 21);
            this.comboBox2.TabIndex = 7;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // tabPagePlayerStats
            // 
            this.tabPagePlayerStats.Controls.Add(this.lineGraphFieldGoal);
            this.tabPagePlayerStats.Controls.Add(this.listBoxTeams);
            this.tabPagePlayerStats.Controls.Add(this.label1);
            this.tabPagePlayerStats.Controls.Add(this.comboBox1);
            this.tabPagePlayerStats.Controls.Add(this.lineGraphSteal);
            this.tabPagePlayerStats.Controls.Add(this.lineGraphBlock);
            this.tabPagePlayerStats.Controls.Add(this.lineGraphOffensiveRebound);
            this.tabPagePlayerStats.Controls.Add(this.lineGraphTurnover);
            this.tabPagePlayerStats.Controls.Add(this.lineGraphFreeThrow);
            this.tabPagePlayerStats.Controls.Add(this.lineGraphRebound);
            this.tabPagePlayerStats.Controls.Add(this.lineGraphMinutes);
            this.tabPagePlayerStats.Controls.Add(this.lineGraphDefensiveRebound);
            this.tabPagePlayerStats.Controls.Add(this.lineGraphAssist);
            this.tabPagePlayerStats.Controls.Add(this.lineGraphPoint);
            this.tabPagePlayerStats.Controls.Add(this.lineGraphThreePoint);
            this.tabPagePlayerStats.Location = new System.Drawing.Point(4, 22);
            this.tabPagePlayerStats.Name = "tabPagePlayerStats";
            this.tabPagePlayerStats.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePlayerStats.Size = new System.Drawing.Size(1145, 560);
            this.tabPagePlayerStats.TabIndex = 0;
            this.tabPagePlayerStats.Text = "Player Stats";
            this.tabPagePlayerStats.UseVisualStyleBackColor = true;
            // 
            // lineGraphFieldGoal
            // 
            this.lineGraphFieldGoal.Location = new System.Drawing.Point(810, 8);
            this.lineGraphFieldGoal.Name = "lineGraphFieldGoal";
            this.lineGraphFieldGoal.RefreshRate = 50;
            this.lineGraphFieldGoal.Size = new System.Drawing.Size(329, 135);
            this.lineGraphFieldGoal.TabIndex = 10;
            this.lineGraphFieldGoal.Text = "Field Goal Percentage";
            // 
            // lineGraphSteal
            // 
            this.lineGraphSteal.Location = new System.Drawing.Point(132, 426);
            this.lineGraphSteal.Name = "lineGraphSteal";
            this.lineGraphSteal.RefreshRate = 50;
            this.lineGraphSteal.Size = new System.Drawing.Size(323, 126);
            this.lineGraphSteal.TabIndex = 17;
            this.lineGraphSteal.Text = "Steals";
            // 
            // lineGraphBlock
            // 
            this.lineGraphBlock.Location = new System.Drawing.Point(461, 426);
            this.lineGraphBlock.Name = "lineGraphBlock";
            this.lineGraphBlock.RefreshRate = 50;
            this.lineGraphBlock.Size = new System.Drawing.Size(343, 126);
            this.lineGraphBlock.TabIndex = 18;
            this.lineGraphBlock.Text = "Blocks";
            // 
            // lineGraphOffensiveRebound
            // 
            this.lineGraphOffensiveRebound.Location = new System.Drawing.Point(132, 289);
            this.lineGraphOffensiveRebound.Name = "lineGraphOffensiveRebound";
            this.lineGraphOffensiveRebound.RefreshRate = 50;
            this.lineGraphOffensiveRebound.Size = new System.Drawing.Size(323, 131);
            this.lineGraphOffensiveRebound.TabIndex = 14;
            this.lineGraphOffensiveRebound.Text = "Offensive Rebounds";
            // 
            // lineGraphTurnover
            // 
            this.lineGraphTurnover.Location = new System.Drawing.Point(810, 426);
            this.lineGraphTurnover.Name = "lineGraphTurnover";
            this.lineGraphTurnover.RefreshRate = 50;
            this.lineGraphTurnover.Size = new System.Drawing.Size(329, 126);
            this.lineGraphTurnover.TabIndex = 19;
            this.lineGraphTurnover.Text = "Turnovers";
            // 
            // lineGraphFreeThrow
            // 
            this.lineGraphFreeThrow.Location = new System.Drawing.Point(132, 149);
            this.lineGraphFreeThrow.Name = "lineGraphFreeThrow";
            this.lineGraphFreeThrow.RefreshRate = 50;
            this.lineGraphFreeThrow.Size = new System.Drawing.Size(323, 134);
            this.lineGraphFreeThrow.TabIndex = 11;
            this.lineGraphFreeThrow.Text = "Free Throw Percentage";
            // 
            // lineGraphRebound
            // 
            this.lineGraphRebound.Location = new System.Drawing.Point(810, 149);
            this.lineGraphRebound.Name = "lineGraphRebound";
            this.lineGraphRebound.RefreshRate = 50;
            this.lineGraphRebound.Size = new System.Drawing.Size(329, 134);
            this.lineGraphRebound.TabIndex = 13;
            this.lineGraphRebound.Text = "Rebounds";
            // 
            // lineGraphMinutes
            // 
            this.lineGraphMinutes.Location = new System.Drawing.Point(132, 8);
            this.lineGraphMinutes.Name = "lineGraphMinutes";
            this.lineGraphMinutes.RefreshRate = 50;
            this.lineGraphMinutes.Size = new System.Drawing.Size(323, 135);
            this.lineGraphMinutes.TabIndex = 8;
            this.lineGraphMinutes.Text = "Minutes";
            // 
            // lineGraphDefensiveRebound
            // 
            this.lineGraphDefensiveRebound.Location = new System.Drawing.Point(461, 289);
            this.lineGraphDefensiveRebound.Name = "lineGraphDefensiveRebound";
            this.lineGraphDefensiveRebound.RefreshRate = 50;
            this.lineGraphDefensiveRebound.Size = new System.Drawing.Size(343, 131);
            this.lineGraphDefensiveRebound.TabIndex = 15;
            this.lineGraphDefensiveRebound.Text = "Defensive Rebounds";
            // 
            // lineGraphAssist
            // 
            this.lineGraphAssist.Location = new System.Drawing.Point(810, 289);
            this.lineGraphAssist.Name = "lineGraphAssist";
            this.lineGraphAssist.RefreshRate = 50;
            this.lineGraphAssist.Size = new System.Drawing.Size(329, 131);
            this.lineGraphAssist.TabIndex = 16;
            this.lineGraphAssist.Text = "Assists";
            // 
            // lineGraphPoint
            // 
            this.lineGraphPoint.Location = new System.Drawing.Point(461, 8);
            this.lineGraphPoint.Name = "lineGraphPoint";
            this.lineGraphPoint.RefreshRate = 50;
            this.lineGraphPoint.Size = new System.Drawing.Size(343, 135);
            this.lineGraphPoint.TabIndex = 9;
            this.lineGraphPoint.Text = "Points";
            // 
            // lineGraphThreePoint
            // 
            this.lineGraphThreePoint.Location = new System.Drawing.Point(461, 149);
            this.lineGraphThreePoint.Name = "lineGraphThreePoint";
            this.lineGraphThreePoint.RefreshRate = 50;
            this.lineGraphThreePoint.Size = new System.Drawing.Size(343, 134);
            this.lineGraphThreePoint.TabIndex = 12;
            this.lineGraphThreePoint.Text = "Three Point Percentage";
            // 
            // tabPageBracket
            // 
            this.tabPageBracket.Controls.Add(this.bracketGraph1);
            this.tabPageBracket.Location = new System.Drawing.Point(4, 22);
            this.tabPageBracket.Name = "tabPageBracket";
            this.tabPageBracket.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBracket.Size = new System.Drawing.Size(1145, 560);
            this.tabPageBracket.TabIndex = 2;
            this.tabPageBracket.Text = "Bracket";
            this.tabPageBracket.UseVisualStyleBackColor = true;
            // 
            // bracketGraph1
            // 
            this.bracketGraph1.Location = new System.Drawing.Point(6, 6);
            this.bracketGraph1.Name = "bracketGraph1";
            this.bracketGraph1.RefreshRate = 1000;
            this.bracketGraph1.Size = new System.Drawing.Size(1133, 547);
            this.bracketGraph1.TabIndex = 0;
            this.bracketGraph1.Text = "bracketGraph1";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.comboBox4);
            this.tabPage1.Controls.Add(this.scatterPlot1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.listBox3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.listBox2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.comboBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1145, 560);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "tabPagePrediction";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Team 2";
            // 
            // comboBox4
            // 
            this.comboBox4.Enabled = false;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(5, 67);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(219, 21);
            this.comboBox4.TabIndex = 17;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // scatterPlot1
            // 
            this.scatterPlot1.Location = new System.Drawing.Point(250, 23);
            this.scatterPlot1.Name = "scatterPlot1";
            this.scatterPlot1.RefreshRate = 20;
            this.scatterPlot1.Size = new System.Drawing.Size(872, 509);
            this.scatterPlot1.TabIndex = 16;
            this.scatterPlot1.Text = "scatterPlot1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 343);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Y Axis";
            // 
            // listBox3
            // 
            this.listBox3.Enabled = false;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Items.AddRange(new object[] {
            "Points Per Game",
            "Field Goal Percentage",
            "Free Throw Percentage",
            "Three Point Percentage",
            "Average Offensive PPG Ratio",
            "Points Allowed Per Game",
            "Opponent Field Goal Percentage",
            "Opponent Free Throw Percentage",
            "Opponent Three Point Percentage",
            "Opponent Field Goal Percentage Ratio",
            "Opponent Free Throw Percentage Ratio",
            "Opponent Three Point Percentage Ratio"});
            this.listBox3.Location = new System.Drawing.Point(6, 359);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(219, 173);
            this.listBox3.TabIndex = 14;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "X Axis";
            // 
            // listBox2
            // 
            this.listBox2.Enabled = false;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
            "Points Per Game",
            "Field Goal Percentage",
            "Free Throw Percentage",
            "Three Point Percentage",
            "Average Offensive PPG Ratio",
            "Points Allowed Per Game",
            "Opponent Field Goal Percentage",
            "Opponent Free Throw Percentage",
            "Opponent Three Point Percentage",
            "Opponent Field Goal Percentage Ratio",
            "Opponent Free Throw Percentage Ratio",
            "Opponent Three Point Percentage Ratio"});
            this.listBox2.Location = new System.Drawing.Point(6, 143);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(219, 173);
            this.listBox2.TabIndex = 12;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Team 1";
            // 
            // comboBox3
            // 
            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(5, 23);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(219, 21);
            this.comboBox3.TabIndex = 10;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // tabPpgRatio
            // 
            this.tabPpgRatio.Controls.Add(this.scatterPlot2);
            this.tabPpgRatio.Controls.Add(this.label8);
            this.tabPpgRatio.Controls.Add(this.comboBox5);
            this.tabPpgRatio.Location = new System.Drawing.Point(4, 22);
            this.tabPpgRatio.Name = "tabPpgRatio";
            this.tabPpgRatio.Padding = new System.Windows.Forms.Padding(3);
            this.tabPpgRatio.Size = new System.Drawing.Size(1145, 560);
            this.tabPpgRatio.TabIndex = 4;
            this.tabPpgRatio.Text = "Offensive vs. Defensive PPG Ratio";
            this.tabPpgRatio.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Select Team";
            // 
            // comboBox5
            // 
            this.comboBox5.Enabled = false;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(5, 23);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(219, 21);
            this.comboBox5.TabIndex = 12;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // scatterPlot2
            // 
            this.scatterPlot2.Location = new System.Drawing.Point(9, 51);
            this.scatterPlot2.Name = "scatterPlot2";
            this.scatterPlot2.RefreshRate = 20;
            this.scatterPlot2.Size = new System.Drawing.Size(1130, 503);
            this.scatterPlot2.TabIndex = 17;
            this.scatterPlot2.Text = "scatterPlot2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 598);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "StatCenter";
            this.Load += new System.EventHandler(this.StatusLabel_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTeamStats.ResumeLayout(false);
            this.tabPageTeamStats.PerformLayout();
            this.tabPagePlayerStats.ResumeLayout(false);
            this.tabPagePlayerStats.PerformLayout();
            this.tabPageBracket.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPpgRatio.ResumeLayout(false);
            this.tabPpgRatio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox listBoxTeams;
        private LineGraph lineGraphMinutes;
        private LineGraph lineGraphPoint;
        private LineGraph lineGraphFieldGoal;
        private LineGraph lineGraphRebound;
        private LineGraph lineGraphThreePoint;
        private LineGraph lineGraphFreeThrow;
        private LineGraph lineGraphAssist;
        private LineGraph lineGraphDefensiveRebound;
        private LineGraph lineGraphOffensiveRebound;
        private LineGraph lineGraphTurnover;
        private LineGraph lineGraphBlock;
        private LineGraph lineGraphSteal;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTeamStats;
        private System.Windows.Forms.TabPage tabPagePlayerStats;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private BarGraph barGraph1;
        private LineGraph lineGraphTeamStats;
        private System.Windows.Forms.TabPage tabPageBracket;
        private BracketGraph bracketGraph1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox3;
        private ScatterPlot scatterPlot1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.TabPage tabPpgRatio;
        private ScatterPlot scatterPlot2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox5;
    }
}

