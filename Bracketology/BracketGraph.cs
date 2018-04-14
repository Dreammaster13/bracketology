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
    public partial class BracketGraph : AnimatedControl
    {
        private MemoryGraph m_Graph;
        private List<Tuple<BasketballTeam, double>> m_Pairs;
        private SolidBrush m_Back, m_DataBrush, m_Box;
        private Pen m_DataPen, m_Line;
        private Font m_Font, m_SmallFont;

        public NcaaBracket Bracket;

        public Size RectangleSize;

        public int Minimum = 0;
        public int Maximum = 0;

        private int m_Y_Offset = 0;

        private int m_Y_Offset_Max
        {
            get
            {
                return 16 * (Bracket.Padding + Bracket.RectangleSize.Height) + Bracket.Padding - this.ClientSize.Height;
            }
        }

        public BracketGraph()
        {
            InitializeComponent();
            m_Graph = new MemoryGraph(ClientSize.Width, ClientSize.Height);
            m_Back = new SolidBrush(Color.FromArgb(45, 45, 48));
            m_DataBrush = new SolidBrush(Color.FromArgb(128, 128, 128));
            m_Line = new Pen(Color.FromArgb(255, 76, 113, 117));
            m_Box = new SolidBrush(Color.FromArgb(255, 76, 113, 117));
            m_DataPen = new Pen(Color.FromArgb(192, 192, 192));
            m_Font = new Font("Lucida Console", 10, FontStyle.Regular);
            m_SmallFont = new Font("Lucida Console", 8, FontStyle.Regular);
            m_Pairs = new List<Tuple<BasketballTeam, double>>();
            this.RefreshRate = 20;
            m_RefreshSpeed = 50;
            this.Bracket = new NcaaBracket();
        }

        public void Clear()
        {
            m_Count = 0;
        }

        private int m_Count = 0;
        public void Add(BasketballTeam t)
        {
            if(m_Count < 64)
            {
                int index = m_Count / 2;
                if (m_Count % 2 == 0)
                    Bracket.Matchups[index].Team1 = t;
                else
                    Bracket.Matchups[index].Team2 = t;
                m_Count++;
            }
        }

        private double ave = 0;
        private double std = 0;
        public void Feed()
        {
            OnRefreshed(EventArgs.Empty);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            m_Y_Offset -= (e.Delta / 120) * (Bracket.Padding + Bracket.RectangleSize.Height);
            if (m_Y_Offset > m_Y_Offset_Max) m_Y_Offset = m_Y_Offset_Max;
            else if (m_Y_Offset < 0) m_Y_Offset = 0;
            this.Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            m_Graph.Graphics.FillRectangle(m_Back, this.ClientRectangle);
            foreach(BracketMatchup bm in Bracket.Matchups)
            {

                if (bm.NextRound != null)
                {
                    m_Graph.Graphics.DrawLine(Pens.White, bm.X + Bracket.RectangleSize.Width / 2, bm.Y + Bracket.RectangleSize.Height / 2 - m_Y_Offset,
                        bm.NextRound.X + Bracket.RectangleSize.Width / 2, bm.Y + Bracket.RectangleSize.Height / 2 - m_Y_Offset);
                    m_Graph.Graphics.DrawLine(Pens.White, bm.NextRound.X + Bracket.RectangleSize.Width / 2, bm.Y + Bracket.RectangleSize.Height / 2 - m_Y_Offset,
                        bm.NextRound.X + Bracket.RectangleSize.Width / 2, bm.NextRound.Y + Bracket.RectangleSize.Height / 2 - m_Y_Offset);
                }

                if ((bm.Y > m_Y_Offset && bm.Y < m_Y_Offset + ClientSize.Height) || 
                    (bm.Y + Bracket.RectangleSize.Height > m_Y_Offset && bm.Y + Bracket.RectangleSize.Height < m_Y_Offset + ClientSize.Height))
                {
                    if ((bm.X >= 0 && bm.X < ClientSize.Width) ||
                    (bm.X + Bracket.RectangleSize.Width >= 0 && bm.X + Bracket.RectangleSize.Width < ClientSize.Width))
                    {
                        m_Graph.Graphics.FillRectangle(Brushes.White, bm.X, bm.Y - m_Y_Offset, Bracket.RectangleSize.Width, Bracket.RectangleSize.Height);
                        if(bm.Team1 != null)
                        {
                            if(bm.Team1 == bm.Winner)
                                m_Graph.Graphics.DrawString(bm.Team1.teamName, m_SmallFont, Brushes.Green, bm.X + 5, bm.Y + 5 - m_Y_Offset);
                            else if(bm.Team1 == bm.Loser)
                                m_Graph.Graphics.DrawString(bm.Team1.teamName, m_SmallFont, Brushes.Red, bm.X + 5, bm.Y + 5 - m_Y_Offset);
                            else m_Graph.Graphics.DrawString(bm.Team1.teamName, m_SmallFont, Brushes.White, bm.X + 5, bm.Y + 5 - m_Y_Offset);
                        }
                        if (bm.Team2 != null)
                        {
                            if (bm.Team2 == bm.Winner)
                                m_Graph.Graphics.DrawString(bm.Team2.teamName, m_SmallFont, Brushes.Green, bm.X + 5, bm.Y + Bracket.RectangleSize.Height - 15 - m_Y_Offset);
                            else if (bm.Team2 == bm.Loser)
                                m_Graph.Graphics.DrawString(bm.Team2.teamName, m_SmallFont, Brushes.Red, bm.X + 5, bm.Y + Bracket.RectangleSize.Height - 15 - m_Y_Offset);
                            else m_Graph.Graphics.DrawString(bm.Team2.teamName, m_SmallFont, Brushes.White, bm.X + 5, bm.Y + Bracket.RectangleSize.Height - 15 - m_Y_Offset);
                        }
                    }
                }
            }
            pe.Graphics.DrawImage(m_Graph.Image, 0, 0);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            m_Graph.Create(this.ClientSize.Width, this.ClientSize.Height);
            this.Bracket.RectangleSize.Width = (this.ClientSize.Width - 10 * Bracket.Padding) / 9;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            int x = e.X;
            int y = e.Y + m_Y_Offset;
            foreach(BracketMatchup b in Bracket.Matchups)
            {
                if(x >= b.X && x <= b.X+Bracket.RectangleSize.Width && y >= b.Y && y <= b.Y + Bracket.RectangleSize.Height)
                {
                    if (b.Team1 != null && b.Team2 != null)
                    {
                        FormMatchup fm = new FormMatchup();
                        fm.Matchup = b;
                        fm.ShowDialog();
                    }
                    break;
                }
            }
        }
    }
}
