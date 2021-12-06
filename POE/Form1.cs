using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POE
{
    public partial class Form1 : Form
    {
        GameEngine gameEngine = new GameEngine();

        public Form1()
        {
            InitializeComponent();

            label1.Text = gameEngine.MAP.ToString();


            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Question 2.1//
        public abstract class Tile
        {
            protected string symbol;
            public string SYMBOL
            {
                get { return symbol; }
                set { symbol = value; }
            }
            protected int x;
            protected int y;
            enum TileType { Hero, Enemy, Gold, Weapon };


            //Constructor//
            public Tile(int x, int y, string symbol)
            {
                this.x = x;
                this.y = y;
                this.symbol = symbol;
            }

            public int X
            {
                get { return x; }
                set { }
            }

            public int Y
            {
                get { return y; }
                set { }
            }
        }

        class Obstacle : Tile
        {
            public Obstacle(int x, int y) : base(x, y, "X")
            {

            }
        }

        class EmptyTile : Tile
        {
            public EmptyTile(int x, int y) : base(x, y, "=")
            {

            }
        }
        // Task 2 Question 2.1//
        public abstract class Item : Tile
        {
            public Item(int X, int Y, string symbol) : base(X, Y, symbol)// delegtes//
            {

            }
            public abstract string ToString();

        }

        //Task 2 Question 2.2//
        public class Gold : Item
        {
            public Gold(int X, int Y) : base(X, Y, "D")
            {
                gold = random.Next(1, 6);
            }
            private int gold;
            public int GOLD
            {
                get { return gold; }
                set { gold = value; }
            }
            private Random random = new Random();

            public override string ToString()
            {
                return "gold ";
            }
        }

        //POE Question 2.1
        public abstract class Weapon : Item
        {
            protected int damage;
            public int DAMAGE
            {
                get { return damage; }
                set { damage = value; }
            }

            protected int durability;
            public int DURABILITY
            {
                get { return durability; }
                set { durability = value; }
            }

            protected int cost;
            public int COST
            {
                get { return cost; }
                set { cost = value; }
            }

            protected string weapontype;
            public string WEAPONTYPE
            {
                get { return weapontype; }
                set { weapontype = value; }
            }

            protected string name;
            public string NAME
            {
                get { return name; }
                set { name = value; }
            }

            protected int range;
            public virtual int RANGE()
            {
                return range;
            }

            public Weapon(int X, int Y) : base(X, Y, "W")
            {

            }

        }

        //POE Question 2.2//
        public class MeleeWeapon : Weapon
        {

            public enum Types
            {
                Dagger,
                Longsword
            }
            public override int RANGE()
            {
                return 1;
            }

            public MeleeWeapon(int X, int Y, Types MW) : base(X, Y)
            {
                switch (MW)
                {
                    case Types.Dagger:
                        this.DURABILITY = 10;
                        this.DAMAGE = 3;
                        this.COST = 3;

                        this.SYMBOL = "D";
                        this.NAME = "Dagger";
                        break;

                    case Types.Longsword:
                        this.DURABILITY = 6;
                        this.DAMAGE = 4;
                        this.COST = 5;

                        this.SYMBOL = "S";
                        this.NAME = "LongSword";
                        break;

                }
            }
            public override string ToString()
            {
                throw new NotImplementedException();
            }
        }

        //POE Question 2.3//
        public class RangedWeapon : Weapon
        {
            public enum Types
            {
                Rifle,
                Longbow
            }

            public override int RANGE()
            {
                return base.RANGE();
            }

            public RangedWeapon(int X, int Y, Types RW) : base(X, Y)
            {
                switch (RW)
                {
                    case Types.Rifle:
                        this.DURABILITY = 3;
                        this.DAMAGE = 5;
                        this.COST = 7;
                        this.range = 3;
                        this.SYMBOL = "R";
                        this.NAME = "Rifle";
                        break;

                    case Types.Longbow:
                        this.DURABILITY = 4;
                        this.DAMAGE = 4;
                        this.COST = 6;
                        this.range = 2;
                        this.SYMBOL = "B";
                        this.NAME = "Longbow";
                        break;
                }
            }
            public override string ToString()
            {
                throw new NotImplementedException();
            }
        }






        //Question 2.2//
        public abstract class Character : Tile
        {
            protected List<Tile> vision = new List<Tile>();

            public List<Tile> VISION
            {
                get { return vision; }
                set { vision = value; }
            }


            protected TileType tile;
            public TileType TILE
            {
                get { return tile; }
                set { tile = value; }
            }

            protected int hp;

            public int HP
            {
                get { return hp; }
                set { hp = value; }
            }
            protected int maxhp;

            public int MAXHP
            {
                get { return maxhp; }
                set { maxhp = value; }
            }
            protected int damage;

            public int DAMAGE
            {
                get { return damage; }
                set { damage = value; }
            }

            private List<Tile> Vision
            {
                get { return Vision; }
                set { Vision = value; }
            }

            private Movement movement;

            public Movement MOVEMENT
            {
                get { return movement; }
                set { movement = value; }
            }

            protected int goldpurse;
            public int GOLDPURSE
            {
                get { return goldpurse; }
                set { goldpurse = value; }
            }

            protected Weapon GameWeapon;
            public Weapon GAMEWEAPON
            {
                get { return GameWeapon; }
                set { GameWeapon = value; }
            }

            public abstract Movement ReturnMove(Movement move);


            protected Character(int x, int y, int HP, int MAXHP, int DAMAGE, string symbol) : base(x, y, symbol)
            {
                HP = HP;
                MAXHP = MAXHP;
                DAMAGE = DAMAGE;
            }

            public void SetVision(Tile[,] Sight)
            {

                this.VISION.Add(Sight[x - 1, y]);
                this.VISION.Add(Sight[x + 1, y]);
                this.VISION.Add(Sight[x, y - 1]);
                this.VISION.Add(Sight[x, y + 1]);
            }

            string[] Tilearray = { "North", "South", "East", "West" };

            public enum TileType
            {
                Hero,
                Enemy,
                Gold,
                Weapon,
                Barrier,
                Empty,
            }

            public enum Movement
            {
                NoMovement,
                Up,
                Down,
                Left,
                Right,
            }

            protected Tile[] sight;

            //Question 2.3//


            public virtual void Attack(Character Target)
            {
                Target.HP -= DAMAGE;
            }

            public bool IsDead()
            {
                if (HP <= 0)
                {
                    return true;
                }
                return false;
            }

            public virtual bool CheckRange()
            {
                return true;
            }


            private int DistanceTo()
            {
                return 2;
            }

            public void Move(Movement move)
            {
                switch (move)
                {
                    case Movement.Up:
                        X--;
                        break;
                    case Movement.Down:
                        X++;
                        break;
                    case Movement.Left:
                        Y--;
                        break;
                    case Movement.Right:
                        Y++;
                        break;
                }

                
            }

            //POE Question 3.2//
            private void Equip(Weapon equiped)
            {
                this.GAMEWEAPON = equiped;
            }

            // POE Question 2.5//
            // POE Question 3.1 and 3.2
            public void PickUp(Item playeritem)
            {
                if (playeritem is Gold)
                {
                    Gold newgold = (Gold)playeritem;
                    this.goldpurse += newgold.GOLD;
                }
                else if(playeritem is Weapon)
                {
                    Weapon newweapon = (Weapon)playeritem;
                    Equip(newweapon);
                }
            }

            //POE Question 3.4
            public void Loot(Enemy opp)
            {
                GOLDPURSE += opp.GOLDPURSE;
                if ((this.GameWeapon == null) && !(this is Mage))
                {
                    if (opp.GameWeapon != null)
                    {
                        this.GameWeapon = opp.GameWeapon;
                    }
                }
            }

        }

        //Question 2.4//
        public abstract class Enemy : Character
        {




            protected Random random = new Random();

            protected Enemy(int X, int Y, int DAMAGE, int HP, int MAXHP, string symbol) : base(X, Y, HP, MAXHP, DAMAGE, symbol)
            {


            }
            public override string ToString()
            {
                return "Gold Amount: " + goldpurse.ToString();

            }

        }

        //Question 2.5//
        public class Goblin : Enemy
        {
            public Goblin(int X, int Y) : base(X, Y, 1, 10, 10, "G")
            {
                this.GOLDPURSE = 1;
                this.GameWeapon = new MeleeWeapon(x, y, MeleeWeapon.Types.Dagger);
            }

            public override Movement ReturnMove(Movement movement)
            {
                return movement;
            }
        }

        //Task 2 Question 2.3//

        [Serializable]
        class Mage : Enemy
        {
            public Mage(int X, int Y) : base(X, Y, 5, 10, 10, "M")
            {
                this.GOLDPURSE = 3;
                this.sight = new Tile[8];
            }
            public override Movement ReturnMove(Movement move)
            {
                return Movement.NoMovement;
            }



            public bool CheckRange(Character target)
            {
                int x, y;
                x = Math.Abs(target.X - this.X);
                y = Math.Abs(target.Y - this.Y);

                if ((x == 0 || x == 1) && (y == 0 || y == 1))
                {
                    if (x == 0 && y == 0)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }

         
        }

        //POE Question 2.4//
        public class Leader : Enemy
        {


            public Leader(int X, int Y) : base(X, Y, 2, 20, 20, "L")
            {
                this.GOLDPURSE = 2;
                this.GameWeapon = new MeleeWeapon(x, y, MeleeWeapon.Types.Longsword);

            }

            public override Movement ReturnMove(Movement move)
            {
                return Movement.NoMovement;
            }
        }
        //POE Question 2.5//

        public class Shop
        {
            protected Weapon[] Weaponselection;
            public Weapon[] WEAPONSELECTION
            {
                get { return Weaponselection; }
                set { Weaponselection = value; }
            }

            protected Character GameCharacter;
            public Character GAMECHARACTER
            {
                get { return GameCharacter; }
                set { GameCharacter = value; }
            }
            protected Random numbers;


            public Shop(Character Buyer)
            {
                Weaponselection = new Weapon[3];
                numbers = new Random();
            }

            public Weapon RandomWeapon()
            {
                int k = numbers.Next(4);
                if (k == 0)
                {
                    return new MeleeWeapon(0, 0, MeleeWeapon.Types.Dagger);
                }
                else if (k == 1)
                {
                    return new MeleeWeapon(0, 0, MeleeWeapon.Types.Longsword);
                }
                else if (k == 2)
                {
                    return new RangedWeapon(0, 0, RangedWeapon.Types.Longbow);
                }
                else
                {
                    return new RangedWeapon(0, 0, RangedWeapon.Types.Rifle);
                }
            }

            public bool CanBuy(int buy)
            {
                if (GAMECHARACTER.GOLDPURSE <= WEAPONSELECTION[buy].COST)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               
            }

            public void Buy(int decrease)
            {
                GAMECHARACTER.GOLDPURSE -= WEAPONSELECTION[decrease].COST;

                GAMECHARACTER.PickUp(WEAPONSELECTION[decrease]);

                WEAPONSELECTION[decrease] = RandomWeapon();
            }

            public string DisplayWeapon(int displayweapons)
            {
                string displayshop = "";
                displayshop += WEAPONSELECTION[displayweapons].NAME + " cost:"+ Convert.ToString(WEAPONSELECTION[displayweapons].COST);
                return displayshop;
            }

        }

        //Question 2.6//
        class Hero : Character
        {
            public Hero(int X, int Y, string SYMOBOL, int HP, int MAXHP, int DAMAGE) : base(X, Y, HP, MAXHP, DAMAGE, "H")
            {

            }
            public override Movement ReturnMove(Movement CharacterMove)
            {
                return CharacterMove;
            }

            public override string ToString()
            {
                string info = "Player Stats : \n";
                info += "HP: " + HP.ToString() + "/" + MAXHP.ToString() + "\n";
                info += "Damage: " + DAMAGE.ToString() + "\n";
                info += "[" + X.ToString() + "," + Y.ToString() + "]";
                return info;
            }

            
            //bool CheckForValidMove(Movement CharacterMove)
            //{

            // }
        }







        //Question 3.1//
        public class Map
        {
            private int enemyNum;
            private Hero PLAYER;

            private Tile[,] mapcontainer;
            public Tile[,] MAPCONTAINER
            {
                get { return mapcontainer; }
                set { mapcontainer = value; }
            }
            //private Hero playercharacter;
            //public Hero PLAYERCHARCTER
            // {
            //   get { return playercharacter; }
            //    set { playercharacter = value; }
            //}
            public void UpdateVision()
            {
                for (int setvision = 0; setvision < enemies.Count; setvision++)
                {
                    foreach (Enemy E in enemies)
                    {
                        E.VISION.Clear();
                        E.SetVision(MAPCONTAINER);
                    }

                    PLAYER.VISION.Clear();
                    PLAYER.SetVision(MAPCONTAINER);
                }
            }
            private List<Enemy> enemies;

            public List<Enemy> ENEMIES
            {
                get { return enemies; }
                set { enemies = value; }
            }

            private int mapwidth;
            public int MAPWIDTH
            {
                get { return mapwidth; }
                set { mapwidth = value; }
            }

            private int mapheight;
            public int MAPHEIGHT
            {
                get { return mapheight; }
                set { mapheight = value; }
            }

            private List<Item> items;

            public List<Item> ITEMS
            {
                get { return items; }
                set { items = value; }
            }

            protected Random random = new Random();

            public Map(int MINWIDTH, int MAXWIDTH, int MINHEIGHT, int MAXHEIGHT, int NUMBEROFENEMIES, int Goldmap, int Weaponsmap)
            {
                MAPWIDTH = random.Next(MINWIDTH, MAXWIDTH);
                MAPHEIGHT = random.Next(MINHEIGHT, MAXHEIGHT);

                MAPCONTAINER = new Tile[MAPWIDTH, MAPHEIGHT];

                ENEMIES = new List<Enemy>();
                ITEMS = new List<Item>();
                //POE Question 3.1//
                enemyNum = NUMBEROFENEMIES;
                GenerateInitialMap(Weaponsmap,Goldmap);

                UpdateVision();
            }

            public override string ToString()
            {
                string mapp = "";
                for (int y = 0; y < MAPWIDTH; y++)
                {
                    for (int x = 0; x < MAPHEIGHT; x++)
                    {
                        mapp += mapcontainer[y, x].SYMBOL;
                    }
                    mapp += "\n";
                }
                return mapp;
            }






            void GenerateInitialMap(int Weaponmap, int Goldmap)
            {
                for (int y = 0; y < MAPWIDTH; y++)
                {
                    for (int x = 0; x < MAPHEIGHT; x++)
                    {
                        if (y == 0 || y == mapwidth - 1 || x == 0 || x == mapheight - 1)
                        { Create(Character.TileType.Barrier, y, x); }
                        else
                        {
                            Create(Character.TileType.Empty, y, x);
                        }
                    }

                }
                Create(Character.TileType.Hero, random.Next(mapwidth - 1), random.Next(mapheight - 1));
                for (int e = 0; e < enemyNum; e++)
                {
                    int x = random.Next(mapwidth - 1);
                    int y = random.Next(mapheight - 1);
                    while (!(mapcontainer[x, y] is EmptyTile))
                    {
                        x = random.Next(mapwidth - 1);
                        y = random.Next(mapheight - 1);
                    }
                    Create(Character.TileType.Enemy, x, y);
                }

                for (int g = 0; g < Goldmap; g++)
                {
                    int x = random.Next(mapwidth - 1);
                    int y = random.Next(mapheight - 1);
                    while (!(mapcontainer[x, y] is EmptyTile))
                    {
                        x = random.Next(mapwidth - 1);
                        y = random.Next(mapheight - 1);
                    }
                    Create(Character.TileType.Gold, x, y);
                }
                for (int w = 0; w < Weaponmap; w++)
                {
                    int x = random.Next(mapwidth - 1);
                    int y = random.Next(mapheight - 1);
                    while (!(mapcontainer[x, y] is EmptyTile))
                    {
                        x = random.Next(mapwidth - 1);
                        y = random.Next(mapheight - 1);
                    }
                    Create(Character.TileType.Weapon, x, y);
                }
            }

            public void Create(Character.TileType TypeOfTyle, int X = 0, int Y = 0)
            {
                switch (TypeOfTyle)
                {
                    case Character.TileType.Barrier:
                        MAPCONTAINER[X, Y] = new Obstacle(X, Y);
                        break;
                    case Character.TileType.Empty:
                        MAPCONTAINER[X, Y] = new EmptyTile(X, Y);
                        break;
                    case Character.TileType.Hero:
                        PLAYER = new Hero(X, Y, "H", 10, 10, 5);
                        MAPCONTAINER[X, Y] = PLAYER;
                        break;
                    case Character.TileType.Enemy:
                        MAPCONTAINER[X, Y] = new Goblin(X, Y);
                        int k = random.Next(2);
                        if (k == 1)
                        {
                            Goblin NewEnemy = new Goblin(X, Y);
                            MAPCONTAINER[X, Y] = NewEnemy;
                            ENEMIES.Add(NewEnemy);
                        }
                        else if (k == 2)
                        {
                            Mage NewEnemy = new Mage(X, Y);
                            MAPCONTAINER[X, Y] = NewEnemy;
                            ENEMIES.Add(NewEnemy);
                        }
                        else
                        {
                            Leader NewEnemy = new Leader(X, Y);
                            MAPCONTAINER[X, Y] = NewEnemy;
                            ENEMIES.Add(NewEnemy);
                        }
                        enemies.Add((Enemy)mapcontainer[X, Y]);
                        break;
                        case Character.TileType.Gold:
                        Gold one = new Gold(X, Y);
                        MAPCONTAINER[X, Y] = one;
                        ITEMS.Add(one);
                        break;
                    case Character.TileType.Weapon:

                        //POE Question 3.1//
                        int u = random.Next(4);
                        if (u == 1)
                        {
                            MeleeWeapon NewWeapon = new MeleeWeapon(X, Y, MeleeWeapon.Types.Dagger);
                            MAPCONTAINER[X, Y] = NewWeapon;
                            ITEMS.Add(NewWeapon);
                            
                        }
                        else if (u == 2)
                        {
                            MeleeWeapon NewWeapon = new MeleeWeapon(X, Y, MeleeWeapon.Types.Longsword);
                            MAPCONTAINER[X, Y] = NewWeapon;
                            ITEMS.Add(NewWeapon);
                           
                        }
                        else if (u == 3)
                        {
                            RangedWeapon NewWeapon = new RangedWeapon(X, Y, RangedWeapon.Types.Rifle);
                            MAPCONTAINER[X, Y] = NewWeapon;
                            ITEMS.Add(NewWeapon);
                            
                        }
                        else
                        {
                            RangedWeapon NewWeapon = new RangedWeapon(X, Y, RangedWeapon.Types.Longbow);
                            MAPCONTAINER[X, Y] = NewWeapon;
                            ITEMS.Add(NewWeapon);
                            
                        }
                        
                        break;
                }
            }
            public void TryMove(Character.Movement controls)
            {
                int x = PLAYER.X;
                int y = PLAYER.Y;

                PLAYER.Move(PLAYER.ReturnMove(controls));
                mapcontainer[x, y] = new EmptyTile(x, y);
                mapcontainer[PLAYER.X, PLAYER.Y] = PLAYER;
            }
        }
        //Question 3.3//
        class GameEngine
        {
            public Label maplabel = new Label();
            private Map map;

            public Map MAP
            {
                get { return map; }
                set { map = value; }
            }

            public Item getItemAtPosition(int X, int Y)
            {
                for (int item = 0; item < map.ITEMS.Count; item++)
                {
                    if (map.ITEMS[item].X == X && map.ITEMS[item].Y == Y)
                    {
                        Item tempItem;

                        tempItem = map.ITEMS[item];
                        map.ITEMS[item] = null;

                        return tempItem;
                    }
                }
                return null;
            }

            public GameEngine()
            {
                map = new Map(10, 20, 10, 20, 5, 4, 5);
            }

            public void MovePlayer(Character.Movement controls)
            {
                MAP.TryMove(controls);
            }

            //public class SaveGame
            //{
            //    public string savefile = "data.savegame";
            //    private SaveGame savegame;
            //    public BinaryFormatter form;

            //    public void SaveG()
            //    {
            //        if (savegame == null)
            //            savegame = new SaveGame();

            //        var file = new FileStream(savefile, FileMode.OpenCreate, FileAccess.Readwrite);
            //        form.Serialize(file.savegame);
            //        file.close();

            //    }

            //    public void Load()
            //    {
            //        var file = new filestream(savefile, file.OpenCreate, FileAccess.write);
            //        if (file == null)
            //        {
            //            savegame = (SaveGame)form.Deserialze(file);
            //            file.close();
            //        }
            //        else
            //        {
            //            Save();
            //        }
            //    }
            //}

            public void ShowMap()
            {
                //for (int y = 0; )
            }
        }

        public void updateform()
        {

        }

        private void upbtn_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Up);
            label1.Text = gameEngine.MAP.ToString();
        }

        private void upbtn_Click_1(object sender, EventArgs e)
        {
            
            gameEngine.MovePlayer(Character.Movement.Up);
            label1.Text = gameEngine.MAP.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
} 

