using System;
using System.Collections.Generic;
using System.Text;

namespace Pacman
{
    // Класс игры
    class Game
    {
        public int points { get; set; }     // очки
        public bool start { get; set; }     // состояние игры
        public int width { get; set; }      // размеры игрового поля
        public int height { get; set; }
        public int[,] blocks { get; set; }      // массив блоков, двумерная матрица
        public List<Leader> leaders { get; set; }   // коллекция лидеров
        public int countGrass { get; set; }     // количество травы в игре
        public int hearth { get; set; }         // количество жизней
        public int xegg { get; set; }           // расположение пасхалки
        public int yegg { get; set; }
        public Game()
        {
            start = false;
            width = 20;
            height = 20;
            blocks = new int[width, height];
            leaders = new List<Leader>();
            points = 0;
            countGrass = 0;
            hearth = 3;
            xegg = -40;
            yegg = -40;
        }

        public void setWidhHeightMap(int width, int height)
        {
            setWidthMap(width);
            setHeightMap(height);
        }

        public void setWidthMap(int width)
        {
            this.width = width;
        }

        public void setHeightMap(int height)
        {
            this.height = height;
        }

        public int getWidthMap()
        {
            return width;
        }

        public int getHeightMap()
        {
            return height;
        }

        public void generateLever()
        {
            Random r = new Random();
            int egg = 1;
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    if (i == 0) continue;
                    // случайный способ заполнения карты, используя тернарный оператор и рандом
                    blocks[i, j] = r.Next() % 16 == 3 ? 1: r.Next()%20==1?-1:0;
                    // обязательно будет одно яйцо в определенном месте
                    if (egg > 0 && i==15 && j==15)
                    {
                        blocks[15, 15] = 2;
                        xegg = i;
                        yegg = j;
                        egg--;
                    }
                    // считаем сколько травы всего
                    if (blocks[i, j] == 1)
                    {
                        countGrass++;
                    }
                }
            }
        }
        public int[,] getLevel()
        {
            return blocks;
        }

        public void setLevel(int[,] blocks)
        {
            this.blocks = blocks;
        }

        public void setPoints(int points)
        {
            this.points = points;
        }

        public int getPoints()
        {
            return points;
        }

        public void Start()
        {
            start = true;
        }

        public void Stop()
        {
            start = false;
        }

        public bool getStateGame()
        {
            return start;
        }      
        
        public bool isWin()
        {
            return points == (countGrass+20) ? true:false;
        }

        public bool isLose()
        {
            return hearth == 0 ? true : false;
        }

        public void setHearth(int hearth)
        {
            this.hearth = hearth;
        }

        public int getHearth()
        {
            return hearth;
        }

        public void setXegg(int xegg)
        {
            this.xegg = xegg;
        }

        public void setYegg(int yegg)
        {
            this.yegg = yegg;
        }

        public int getXegg()
        {
            return xegg;
        }
        public int getYegg()
        {
            return yegg;
        }

        public void addLeader(string name, int score)
        {
            leaders.Add(new Leader(name, score));
        }

        public List<Leader> getLeaders()
        {
            return leaders;
        }

        public void setLeaders(List<Leader> leaders)
        {
            this.leaders = leaders;
        }
       
    }
}
