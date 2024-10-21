using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAPdekor
{
	internal static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
	public class Battlefield
	{
		public static int[,] field = new int[8, 8];
		public Battlefield()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					field[i, j] = 0;
				}
			}
		}
		public int[,] get_field()
		{
			return field;
		}

	}

	abstract class GameObj
	{

		public abstract bool IsDead();
	}
	class Castle_singletone : GameObj
	{
		private static Castle_singletone instance;
		private int x_ind, y_ind, health;

		private Castle_singletone(int x, int y, int hp)
		{
			x_ind = x;
			y_ind = y;
			health = hp;
		}
		public int Get_x()
		{
			return x_ind;
		}
		public int Get_y()
		{
			return y_ind;
		}
		public static Castle_singletone getInstance(int x, int y, int hp)
		{
			if (instance == null)

				instance = new Castle_singletone(x, y, hp);
			return instance;

		}
		public override bool IsDead()
		{
			if (health > 0) return false;
			else return true;
		}
	}
	class Knight : GameObj
	{
		private int x_ind, y_ind, health;
		public Knight(int x, int y, int hp)
		{
			x_ind = x;
			y_ind = y;
			health = hp;
		}
		public override bool IsDead()
		{
			if (health > 0) return false;
			else return true;
		}
	}
	class Enemy : GameObj
	{
		private int x_ind, y_ind, health;
		public Enemy(int x, int y, int hp)
		{
			x_ind = x;
			y_ind = y;
			health = hp;
		}
		public override bool IsDead()
		{
			if (health > 0) return false;
			else return true;
		}
	}
	class Game
	{
		//- enemy, 0 clear, 1 castle, 2+ knights
		public Castle_singletone castle;
		public Battlefield field; int[,] myfield;
		//public Knight[] knight=new Knight[64];
		SortedDictionary<int, Knight> knight = new SortedDictionary<int, Knight>();
		private int k = 2;
		SortedDictionary<int, Enemy> enemy = new SortedDictionary<int, Enemy>();
		private int e = -1;
		//GameObj obj;
		public int[,] NewMap()
		{
			field = new Battlefield();
			myfield = field.get_field();
			return myfield;

		}
		public void CreateCastle(int x, int y)
		{
			int hp = 1;
			if (myfield[x, y] == 0)
			{
				castle = Castle_singletone.getInstance(x, y, hp);
				if ((castle.Get_x() == x) && (castle.Get_y() == y))
					myfield[x, y] = hp;
			}
		}

		public void CreateKnight(int x, int y)
		{
			int hp = 2;
			if (myfield[x, y] == 0)
			{
				knight.Add(k, new Knight(x, y, hp));
				myfield[x, y] = k;
				k++;
			}
		}
		public void CreateEnemy(int x, int y)
		{
			int hp = 2;
			if (myfield[x, y] == 0)
			{
				enemy.Add(k, new Enemy(x, y, hp));
				myfield[x, y] = e;
				e--;
			}
		}
	}
}
