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
	public class Battlefield ///////!!!!!!!!!!!!!!!!!!!
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
		public bool IsFull()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (field[i, j] == 0)
						return false;
				}
			} return true;
		}

	}

	abstract class GameObj /////!!!!!!!!!!
	{
		public int AttackRange=1;
		public int Damage=1;
	//	public int x_ind, y_ind, health;
		//public abstract bool IsDead();
		public abstract void Attack();
		public abstract bool IsDead();
		public abstract int Get_x();
		public abstract int Get_y();
		public abstract int get_hp();

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
		public override int Get_x()
		{
			return x_ind;
		}
		public override int Get_y()
		{
			return y_ind;
		}
		public override int get_hp()
		{
			return health;
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
		public override void Attack()
		{
			this.Damage = 1;
			this.AttackRange = 1;
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
		public override void Attack()
		{
			this.Damage = 1;
			this.AttackRange = 1;
		}
		public override int Get_x()
		{
			return x_ind;
		}
		public override int Get_y()
		{
			return y_ind;
		}
		public override int get_hp()
		{
			return health;
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
		public override void Attack()
		{
			this.Damage = 1;
			this.AttackRange = 1;
		}
		public override int Get_x()
		{
			return x_ind;
		}
		public override int Get_y()
		{
			return y_ind;
		}
		public override int get_hp()
		{
			return health;
		}

	}
	abstract class Equipment_decorator:GameObj
	{
		public GameObj obj;
		public Equipment_decorator(GameObj obj)
		{
			this.obj = obj;
		}
		//public override void Attack()
		//{

		//}
	}
	class Sword_decorator:Equipment_decorator
	{
		public int x_ind, y_ind, health;
		public Sword_decorator(GameObj obj) : base(obj)
		{
			x_ind = obj.Get_x();
			y_ind = obj.Get_y();
			health=obj.get_hp();
			this.Damage = obj.Damage;
			this.AttackRange = obj.AttackRange;
		}
		public override void Attack()
		{
			this.obj.Attack();
			this.SwordAttack();
		}

		private void SwordAttack()
		{
			this.Damage = 2;
			
		}
		public override bool IsDead()
		{
			if (health > 0) return false;
			else return true;
		}
		public override int Get_x()
		{
			return x_ind;
		}
		public override int Get_y()
		{
			return y_ind;
		}
		public override int get_hp()
		{
			return health;
		}
	}
	class Bow_decorator : Equipment_decorator
	{
		public int x_ind, y_ind, health;
		public Bow_decorator(GameObj obj) : base(obj) {
			x_ind = obj.Get_x();
			y_ind = obj.Get_y();
			health = obj.get_hp();
			this.Damage = obj.Damage;
			this.AttackRange = obj.AttackRange;
		}
		public override void Attack()
		{
			this.obj.Attack();
			this.BowAttack();
		}
		public void BowAttack()
		{
			
			this.AttackRange = 2;
		}
		public override bool IsDead()
		{
			if (health > 0) return false;
			else return true;
		}
		public override int Get_x()
		{
			return x_ind;
		}
		public override int Get_y()
		{
			return y_ind;
		}
		public override int get_hp()
		{
			return health;
		}
	}

	class Game
	{
		//- enemy, 0 clear, 1 castle, 2+ knights
		Random rnd = new Random();
		double rand;
		public Castle_singletone castle;
		public Battlefield field; int[,] myfield;
		//public Knight[] knight=new Knight[64];
		SortedDictionary<int, GameObj> knight = new SortedDictionary<int, GameObj>();
		private int k = 2;
		SortedDictionary<int, GameObj> enemy = new SortedDictionary<int, GameObj>();
		private int e = -1;
		//GameObj obj;
		public Battlefield NewMap() /////!!!!!!!!!!!!!!!!1
		{
			field = new Battlefield();
			myfield = field.get_field();
			return field;

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
			rand = rnd.Next(0, 11);
			rand=rand/10;
			if (myfield[x, y] == 0)
			{
				Knight cur = new Knight(x, y, hp);
				if (rand <= 0.3)
				{	
					Sword_decorator sword_knight = new Sword_decorator(cur);
					knight.Add(k, sword_knight);
					
				}else if(rand <=0.6)
				{
					Bow_decorator bow_knight = new Bow_decorator(cur);
					knight.Add(k, bow_knight);
					
				}else
				{
					knight.Add(k, cur);
				}
				myfield[x, y] = k;
				k++;
			}
		}
		public void CreateEnemy(int x, int y)
		{
			int hp = 3;
			rand = rnd.Next(0, 11);
			rand = rand / 10;
			if (myfield[x, y] == 0)
			{
				Enemy cur = new Enemy(x, y, hp);
				if (rand <= 0.3)
				{
					Sword_decorator sword_enemy = new Sword_decorator(cur);
					enemy.Add(e, sword_enemy);

				}
				else if (rand <= 0.6)
				{
					Bow_decorator bow_enemy = new Bow_decorator(cur);
					enemy.Add(e, bow_enemy);

				}
				else
				{
					enemy.Add(e, cur);
				}
				myfield[x, y] = e;
				e--;
			}
		}

		public string EnAttack()
		{
			string caption;
			caption=EnemyAttack(enemy);
			return caption;
		}
		public string KnAttack()
		{
			string caption;
			caption = KnightAttack(knight);
			return caption;
		}
		public string KnightAttack(SortedDictionary<int, GameObj> knight)
		{
			GameObj cur = null;
			if (knight.TryGetValue((k - 1), out cur))
			{
				cur.Attack();
				int val = cur.Damage;
				string str = "D " + val;

				val = cur.AttackRange;

				str = str + " C " + val;
				return (str);
			}

			return ("err");
		}
		public string EnemyAttack(SortedDictionary<int, GameObj> enemy)
		{
			
			int way_x = castle.Get_x();
			int way_y = castle.Get_y();
			//foreach (KeyValuePair<int, GameObj> pair in enemy)
			//GameObj cur = pair.Value;
			{
				GameObj cur = null;
				if (enemy.TryGetValue((e+1), out cur))
				{
					cur.Attack();
					int val = cur.Damage;
					string str = "D " + val;
					
					val = cur.AttackRange;
					
					str = str+" C " + val;
					return (str);
				}

				return ("err");


				//int cur_x = cur.Get_x();
				//int cur_y = cur.Get_y();
				//way_x=way_x-cur_x;
				//way_y=way_y-cur_y;
				//if (way_x<0)
				//{ }
			}
		}
	}
}
