using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FOOTBALL
{
    public partial class FormMatchup : Form
    {
        private BracketMatchup m_Matchup;
        public BracketMatchup Matchup
        {
            get { return m_Matchup; }
            set
            {
                m_Matchup = value;
                AddTeamsToControls();
            }
        }

        public FormMatchup()
        {
            InitializeComponent();
            barGraphOffPpg.SortEntries = false;
            barGraphOffPpg.SpaceBetween = 10;
            barGraphOffPpg.TheseWickedLines = 25;
            barGraphOffPpg.TopPadding = 10;
            barGraphOffFg.SortEntries = false;
            barGraphOffFg.SpaceBetween = 10;
            barGraphOffFg.TheseWickedLines = 25;
            barGraphOffFg.TopPadding = 10;
            barGraphOff3p.SortEntries = false;
            barGraphOff3p.SpaceBetween = 10;
            barGraphOff3p.TheseWickedLines = 25;
            barGraphOff3p.TopPadding = 10;
            barGraphDefPpg.SortEntries = false;
            barGraphDefPpg.SpaceBetween = 10;
            barGraphDefPpg.TheseWickedLines = 25;
            barGraphDefPpg.TopPadding = 10;
            barGraphDefFg.SortEntries = false;
            barGraphDefFg.SpaceBetween = 10;
            barGraphDefFg.TheseWickedLines = 25;
            barGraphDefFg.TopPadding = 10;
            barGraphDef3p.SortEntries = false;
            barGraphDef3p.SpaceBetween = 10;
            barGraphDef3p.TheseWickedLines = 25;
            barGraphDef3p.TopPadding = 10;
        }

        public void AddTeamsToControls()
        {
            double d1, d2;
            barGraphOffPpg.Clear();
            d1 = m_Matchup.Team1Wins;
            d2 = m_Matchup.Team2Wins;
            barGraphOffPpg.Add(m_Matchup.Team1.teamName, d1);
            barGraphOffPpg.Add(m_Matchup.Team2.teamName, d2);
            barGraphOffPpg.SelectedIndex = d1 > d2 ? 0 : 1;
            barGraphOffPpg.Feed();
        }
    }
}
