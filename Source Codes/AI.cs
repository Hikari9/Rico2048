using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class AI : Form
    {
        public enum MOVE { up, right, down, left };
        public int[,] g;
        public int r
        {
            get { return grid.RowCount; }
        }
        public int c
        {
            get { return grid.ColumnCount; }
        }
        public void FromGrid()
        {
            for (int i = 0; i < r; ++i)
            {
                for (int j = 0; j < c; ++j)
                {
                    Control cc = grid.GetControlFromPosition(j, i);
                    g[i, j] = int.Parse(cc.Text);
                }
            }
        }
        public Color[] color = 
        {
            Color.Black, // 0
            Color.White, //2
            Color.WhiteSmoke, //4
            Color.LightBlue, //8
            Color.PaleGreen, //16
            Color.Pink, //32
            Color.Gold, // 64
            Color.LightYellow, // 128
            Color.LimeGreen, // 256
            Color.Orange, // 512
            Color.Goldenrod, // 1024
            Color.White // 2048

        };
        public Color getColor(int num)
        {
            int power = 0;
            num >>= 1;
            while (num != 0)
            {
                num >>= 1;
                power++;
            }
            return color[power];
        }
        public void ToGrid()
        {
            grid.Visible = false;
            for (int i = 0; i < r; ++i)
            {
                for (int j = 0; j < c; ++j)
                {
                    Control cc = grid.GetControlFromPosition(j, i);
                    cc.Text = "" + g[i, j];
                    cc.BackColor = getColor(g[i, j]);
                }
            }
            grid.Visible = true;
            if (isWin())
            {
                MessageBox.Show("YOU WIN!");
                foreach (Control cc in Controls)
                {
                    cc.Enabled = false;
                }
            }
            else if (isLose())
            {
                MessageBox.Show("YOU LOSE. Continue?");
                for (int i = 0; i < r; ++i)
                {
                    for (int j = 0; j < c; ++j)
                    {
                        g[i, j] = 0;
                    }
                }
                CastTile();
                ToGrid();

            }
        }
        public Random rand = new Random();
        public void CastTile()
        {
            while (true)
            {
                int x = rand.Next(r);
                int y = rand.Next(c);
                if (g[x, y] == 0)
                {
                    int two = rand.Next(10);
                    if (two == 4) g[x, y] = 4;
                    else g[x, y] = 2;
                    break;
                }
            }
        }
        public void print()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < r; ++i)
            {
                sb.Append("[");
                for (int j = 0; j < c; ++j)
                {
                    if (j != 0) sb.Append(", ");
                    sb.Append(g[i, j]);
                }
                sb.Append(" ]\n");
            }
            MessageBox.Show(sb.ToString());
        }
        public bool Slide(MOVE m, int[,] gr = null)
        {
            if (gr == null) gr = g;
            bool hasMoved = false;
            switch (m)
            {
                case MOVE.up:
                    for (int i = 0; i < r; ++i)
                    {
                        for (int j = 0; j < c; ++j)
                        {
                            if (gr[i, j] == 0)
                            {
                                for (int k = i + 1; k < r; ++k)
                                {
                                    if (gr[k, j] != 0)
                                    {
                                        gr[i, j] = gr[k, j];
                                        gr[k, j] = 0;
                                        hasMoved = true;
                                        break;
                                    }
                                }
                            }
                            if (gr[i, j] != 0)
                            {
                                for (int k = i + 1; k < r; ++k)
                                {
                                    if (gr[k, j] == gr[i, j])
                                    {
                                        gr[i, j] <<= 1;
                                        gr[k, j] = 0;
                                        hasMoved = true;
                                        break;
                                    }
                                    if (gr[k, j] != 0) break;
                                }
                            }
                        }
                    }
                    break;
                case MOVE.right:
                    for (int j = c - 1; j >= 0; --j)
                    {
                        for (int i = 0; i < r; ++i)
                        {
                            if (gr[i, j] == 0)
                            {
                                for (int k = j - 1; k >= 0; --k)
                                {
                                    if (gr[i, k] != 0)
                                    {
                                        gr[i, j] = gr[i, k];
                                        gr[i, k] = 0;
                                        hasMoved = true;
                                        break;
                                    }
                                }
                            }
                            if (gr[i, j] != 0)
                            {
                                for (int k = j - 1; k >= 0; --k)
                                {
                                    if (gr[i, k] == gr[i, j])
                                    {
                                        gr[i, j] <<= 1;
                                        gr[i, k] = 0;
                                        hasMoved = true;
                                        break;
                                    }
                                    if (gr[i, k] == 0) break;
                                }
                            }
                        }
                    }
                    break;
                case MOVE.down:
                    for (int i = r - 1; i >= 0; --i)
                    {
                        for (int j = 0; j < c; ++j)
                        {
                            if (gr[i, j] == 0)
                            {
                                for (int k = i - 1; k >= 0; --k)
                                {
                                    if (gr[k, j] != 0)
                                    {
                                        gr[i, j] = gr[k, j];
                                        gr[k, j] = 0;
                                        hasMoved = true;
                                        break;
                                    }
                                }
                            }
                            if (gr[i, j] != 0)
                            {
                                for (int k = i - 1; k >= 0; --k)
                                {
                                    if (gr[k, j] == gr[i, j])
                                    {
                                        gr[i, j] <<= 1;
                                        gr[k, j] = 0;
                                        hasMoved = true;
                                        break;
                                    }
                                    if (gr[k, j] != 0) break;
                                }
                            }
                        }
                    }
                    break;
                case MOVE.left:
                    for (int j = 0; j < c; ++j)
                    {
                        for (int i = 0; i < r; ++i)
                        {
                            if (gr[i, j] == 0)
                            {

                                for (int k = j + 1; k < c; ++k)
                                {
                                    if (gr[i, k] != 0)
                                    {
                                        gr[i, j] = gr[i, k];
                                        gr[i, k] = 0;
                                        hasMoved = true;
                                        break;
                                    }
                                }
                            }
                            if (gr[i, j] != 0)
                            {
                                for (int k = j + 1; k < c; ++k)
                                {
                                    if (gr[i, k] == gr[i, j])
                                    {
                                        gr[i, j] <<= 1;
                                        gr[i, k] = 0;
                                        hasMoved = true;
                                        break;
                                    }
                                    if (gr[i, k] != 0) break;
                                }
                            }
                        }
                    }
                    break;
                
            }
            return hasMoved;
        }

        public Dictionary<Keys, Button> Keyboard;
        Button[] buttons;
        public AI()
        {
            InitializeComponent();
            dp = new int[r, c];
            buttons = new Button[] { b0, b1, b2, b3 };
            Keyboard = new Dictionary<Keys, Button>()
            {
                { Keys.Up, b0 },
                { Keys.Right, b1 },
                { Keys.Down, b2 },
                { Keys.Left, b3 }
            };
            g = new int[grid.RowCount, grid.ColumnCount];
            for (int i = 0; i < grid.RowCount; ++i)
            {
                for (int j = 0; j < grid.ColumnCount; ++j)
                {
                    var label = new Label(){ Text = "0", AutoSize = false, Width = int.MaxValue, Height = int.MaxValue, TextAlign = ContentAlignment.MiddleCenter };
                    grid.Controls.Add(label, j, i);
                }
            }
            FromGrid();
            CastTile();
            ToGrid();

        }



        private void buttonClick(object sender, EventArgs e)
        {
            if (Slide((MOVE)(((Button)sender).Name[1] - '0')))
            {
                
                CastTile();
                ToGrid();
                lbest.Text = "-";
            }
        }


        private void AI_KeyUp(object sender, KeyEventArgs e)
        {
            if(Keyboard.ContainsKey(e.KeyCode))
                Keyboard[e.KeyCode].PerformClick();
        }

        int[,] CloneGrid(int[,] gr)
        {
            int[,] tg = new int[r, c];
            for (int i = 0; i < r; ++i)
            {
                for (int j = 0; j < c; ++j)
                {
                    tg[i, j] = gr[i, j];
                }
            }
            return tg;
        }
        public bool isWin(int[,] gr = null)
        {
            if (gr == null) gr = g;
            for (int i = 0; i < r; ++i)
            {
                for (int j = 0; j < c; ++j)
                {
                    if (gr[i, j] == 2048) return true;
                }
            }
            return false;
        }
        public bool isLose(int[,] gr = null)
        {
            if (gr == null) gr = CloneGrid(g);
            for (int i = 0; i < 4; ++i)
            {
                if (Slide((MOVE)i, gr)) return false;
            }
            return true;
        }
       
        int[] dx = { -1, 0, 1, 0 }, dy = { 0, -1, 0, 1 };
        public int[,] dp;
        int DP(int i, int j, int[,] gr, int[,] dp)
        {
            if (dp[i, j] != -1) return dp[i, j];
            
            int inc = gr[i, j] * (i == 0 || i == 3 ? ( j == 0 || j == 3 ? 8 : 2 ) : ( j == 0 || j == 3 ? 2 : 1 ) );
            dp[i, j] = inc;
            for (int k = 0; k < 4; ++k)
            {
                int nx = i + dx[k];
                int ny = j + dy[k];
                if (nx >= 0 && ny >= 0 && nx < r && ny < c)
                {
                    //if (gr[i, j] < gr[nx, ny]) cnt++;
                    //else continue;
                    /*for (int l = 0; l < 2; ++l)
                    {
                        if ((gr[i, j] << l) == gr[nx, ny])
                        {
                            dp[i, j] = Math.Max(dp[i, j], Math.Max(inc << (2 - l), (DP(nx, ny, gr, dp)>>1)+7));
                        }
                    }*/
                    
                    if ((gr[i, j] << 1) == gr[nx, ny])
                    {
                        dp[i, j] = Math.Max(dp[i, j], Math.Max(inc, DP(nx, ny, gr, dp)));
                    }
                    else if (gr[i, j] == gr[nx, ny])
                    {
                        dp[i, j] = Math.Max(dp[i, j], Math.Max(inc << 2, DP(nx, ny, gr, dp)));
                    }
                    //else if ((gr[i, j] << 4) >= gr[nx, ny])
                    //{
                    //    dp[i, j] = Math.Max(dp[i, j], Math.Max(inc+2, DP(nx, ny, gr, dp)));
                    //}
                }
            }
            //if (cnt == 0) dp[i, j] = 3*(dp[i, j] << 3);
            return dp[i, j];
        }
        
        int Score(int[,] gr)
        {
            
            for (int i = 0; i < r; ++i)
            {
                for (int j = 0; j < c; ++j)
                {
                    dp[i, j] = -1;
                }
            }
            int sum = 0;
            for (int i = 0; i < r; ++i)
            {
                for (int j = 0; j < c; ++j)
                {
                    sum += DP(i, j, gr, dp);
                }
            }
            return sum;
        }

        int[] GetBest(int dep, int[,] gg = null)
        {
            if (gg == null) gg = g;
            int[] best = new int[]{ -1, int.MinValue };
            for (int i = 0; i < 4; ++i)
            {
                int[,] gr = CloneGrid(gg);
                if (!Slide((MOVE)i, gr)) continue;
                if (dep == 0)
                {
                    int newBest = Score(gr);
                    if (newBest > best[1])
                    {
                        best = new int[] { i, newBest };
                    }
                    return best;
                }
                else for (int j = 0; j < r; ++j)
                {
                    double ave = 0.0;
                    int cnt = 0;
                    for (int k = 0; k < c; ++k)
                    {
                        if (gr[j, k] == 0)
                        {
                            for (int l = 2; l <= 4; l <<= 1)
                            {
                                gr[j, k] = l;
                                int[] newBest = GetBest(dep-1, gr);
                                ave += newBest[1];
                                cnt++;
                                /*
                                if (best[1] < newBest[1])
                                {
                                    best = new int[]{ i, newBest[1] };
                                }
                                */
                            }
                        }
                    }
                    if (cnt > 0)
                    {
                        ave /= cnt;
                        int newBest = (int)Math.Ceiling(ave);
                        if (best[1] < newBest)
                        {
                            best = new int[] { i, newBest };
                        }
                    }
                }
            }
            return best;
        }

        int BestMove()
        {
            return GetBest(2)[0];
        }

        private void GetBest_Click(object sender, EventArgs e)
        {
            int best = BestMove();
            if (best == -1) lbest.Text = "none";
            else lbest.Text = ((MOVE)best).ToString();
        }
       
        private void moveAI_Click(object sender, EventArgs e)
        {
            int best = BestMove();
            if (best != -1)
            {
                buttons[best].PerformClick();
            }
        }

        
    }
}
