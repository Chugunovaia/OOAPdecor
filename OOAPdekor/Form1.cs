using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAPdekor
{
	

	public partial class Form1 : Form
	{
		Game game = new Game();
		int[,] myfield;
		int x_ind, y_ind;
		string name;
		Button[,] map_btn;
		bool turn = false;

		public void Redraw_field()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (myfield[i, j] < 0)
					{
						map_btn[i, j].BackColor = Color.Red;
						map_btn[i, j].Enabled = false;
					}
					else if (myfield[i, j] == 0)
					{
						map_btn[i, j].BackColor = Color.White;
						if (turn)
						{ map_btn[i, j].Enabled = true; }
						else { map_btn[i, j].Enabled = false; }
					}
					else if (myfield[i, j] == 1)
					{
						map_btn[i, j].BackColor = Color.Blue;
						map_btn[i, j].Enabled = false;
					}
					else if (myfield[i, j] > 1)
					{
						map_btn[i, j].BackColor = Color.Green;
						map_btn[i, j].Enabled = false;
					}
				}
			}
		}
		public Form1()
		{
			InitializeComponent();
		}

		private void castle_Click(object sender, EventArgs e)
		{
			//castle.Enabled = false;
			if (!turn)
			{
				game.CreateCastle(x_ind, y_ind);
				turn = true;
				Redraw_field();

			}
		}
		public void Butt0n_Click(object sender, EventArgs e)
		{
			name = (((System.Windows.Forms.Button)sender).Name);
			x_ind = (int)Char.GetNumericValue(name[0]);
			y_ind = (int)Char.GetNumericValue(name[2]);
			turn = false;
			knight.Visible = true;
			knight.Enabled = true;
			castle.Visible = true;
			castle.Enabled = true;
		}

		private void knight_Click(object sender, EventArgs e)
		{
			if (!turn)
			{
				game.CreateKnight(x_ind, y_ind);
				turn = true;
				Redraw_field();

			}
		}

		private void start_Click(object sender, EventArgs e)
		{
			int x = 0, y = 0;
			map_btn = new Button[8, 8];
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					map_btn[i, j] = new Button();
					map_btn[i, j].Name = i.ToString() + " " + j.ToString();
					map_btn[i, j].Size = new System.Drawing.Size(50, 50);
					map_btn[i, j].Enabled = true;
					map_btn[i, j].Left = x;
					map_btn[i, j].Top = y;
					map_panel.Controls.Add(map_btn[i, j]);
					map_btn[i, j].Click += new System.EventHandler(this.Butt0n_Click);
					x += 50;
				}
				x = 0;
				y += 50;
			}
			start.Enabled = false;
			start.Visible = false;
			castle.Visible = true;
			turn = true;
			myfield = game.NewMap();

		}
	}
}
