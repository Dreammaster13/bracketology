namespace FOOTBALL
{
    partial class FormMatchup
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
            this.groupBoxOffense = new System.Windows.Forms.GroupBox();
            this.groupBoxDefense = new System.Windows.Forms.GroupBox();
            this.barGraphOffPpg = new FOOTBALL.BarGraph();
            this.barGraphOffFg = new FOOTBALL.BarGraph();
            this.barGraphOff3p = new FOOTBALL.BarGraph();
            this.barGraphDef3p = new FOOTBALL.BarGraph();
            this.barGraphDefFg = new FOOTBALL.BarGraph();
            this.barGraphDefPpg = new FOOTBALL.BarGraph();
            this.groupBoxOffense.SuspendLayout();
            this.groupBoxDefense.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxOffense
            // 
            this.groupBoxOffense.Controls.Add(this.barGraphOff3p);
            this.groupBoxOffense.Controls.Add(this.barGraphOffFg);
            this.groupBoxOffense.Controls.Add(this.barGraphOffPpg);
            this.groupBoxOffense.Location = new System.Drawing.Point(12, 12);
            this.groupBoxOffense.Name = "groupBoxOffense";
            this.groupBoxOffense.Size = new System.Drawing.Size(268, 315);
            this.groupBoxOffense.TabIndex = 0;
            this.groupBoxOffense.TabStop = false;
            this.groupBoxOffense.Text = "Offense";
            // 
            // groupBoxDefense
            // 
            this.groupBoxDefense.Controls.Add(this.barGraphDef3p);
            this.groupBoxDefense.Controls.Add(this.barGraphDefPpg);
            this.groupBoxDefense.Controls.Add(this.barGraphDefFg);
            this.groupBoxDefense.Location = new System.Drawing.Point(297, 12);
            this.groupBoxDefense.Name = "groupBoxDefense";
            this.groupBoxDefense.Size = new System.Drawing.Size(271, 315);
            this.groupBoxDefense.TabIndex = 1;
            this.groupBoxDefense.TabStop = false;
            this.groupBoxDefense.Text = "Defense";
            // 
            // barGraphOffPpg
            // 
            this.barGraphOffPpg.Location = new System.Drawing.Point(7, 20);
            this.barGraphOffPpg.Name = "barGraphOffPpg";
            this.barGraphOffPpg.RefreshRate = 20;
            this.barGraphOffPpg.Size = new System.Drawing.Size(255, 91);
            this.barGraphOffPpg.TabIndex = 0;
            this.barGraphOffPpg.Text = "Offensive PPG Ratio";
            // 
            // barGraphOffFg
            // 
            this.barGraphOffFg.Location = new System.Drawing.Point(7, 117);
            this.barGraphOffFg.Name = "barGraphOffFg";
            this.barGraphOffFg.RefreshRate = 20;
            this.barGraphOffFg.Size = new System.Drawing.Size(255, 91);
            this.barGraphOffFg.TabIndex = 1;
            this.barGraphOffFg.Text = "Offensive FG Ratio";
            // 
            // barGraphOff3p
            // 
            this.barGraphOff3p.Location = new System.Drawing.Point(7, 214);
            this.barGraphOff3p.Name = "barGraphOff3p";
            this.barGraphOff3p.RefreshRate = 20;
            this.barGraphOff3p.Size = new System.Drawing.Size(255, 91);
            this.barGraphOff3p.TabIndex = 2;
            this.barGraphOff3p.Text = "Offensive 3P Ratio";
            // 
            // barGraphDef3p
            // 
            this.barGraphDef3p.Location = new System.Drawing.Point(6, 213);
            this.barGraphDef3p.Name = "barGraphDef3p";
            this.barGraphDef3p.RefreshRate = 20;
            this.barGraphDef3p.Size = new System.Drawing.Size(255, 91);
            this.barGraphDef3p.TabIndex = 5;
            this.barGraphDef3p.Text = "Defensive 3P Ratio";
            // 
            // barGraphDefFg
            // 
            this.barGraphDefFg.Location = new System.Drawing.Point(6, 116);
            this.barGraphDefFg.Name = "barGraphDefFg";
            this.barGraphDefFg.RefreshRate = 20;
            this.barGraphDefFg.Size = new System.Drawing.Size(255, 91);
            this.barGraphDefFg.TabIndex = 4;
            this.barGraphDefFg.Text = "Defensive FG Ratio";
            // 
            // barGraphDefPpg
            // 
            this.barGraphDefPpg.Location = new System.Drawing.Point(6, 19);
            this.barGraphDefPpg.Name = "barGraphDefPpg";
            this.barGraphDefPpg.RefreshRate = 20;
            this.barGraphDefPpg.Size = new System.Drawing.Size(255, 91);
            this.barGraphDefPpg.TabIndex = 3;
            this.barGraphDefPpg.Text = "Defensive PPG Ratio";
            // 
            // FormMatchup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 337);
            this.Controls.Add(this.groupBoxDefense);
            this.Controls.Add(this.groupBoxOffense);
            this.Name = "FormMatchup";
            this.Text = "FormMatchup";
            this.groupBoxOffense.ResumeLayout(false);
            this.groupBoxDefense.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxOffense;
        private BarGraph barGraphOffPpg;
        private System.Windows.Forms.GroupBox groupBoxDefense;
        private BarGraph barGraphOff3p;
        private BarGraph barGraphOffFg;
        private BarGraph barGraphDef3p;
        private BarGraph barGraphDefPpg;
        private BarGraph barGraphDefFg;
    }
}