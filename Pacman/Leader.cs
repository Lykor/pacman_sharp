using System;
using System.Collections.Generic;
using System.Text;

namespace Pacman
{
    class Leader
    {
        public string name { get; set; } // имя лидера
        public int score { get; set; } // его рекорд
                   // конструктор класса
        public Leader(string name, int score)
        {
            setName(name);
            setScore(score);
        }
        // сеттеры и гетеры
        public void setName(String name)
        {
            this.name = name;
        }
        public void setScore(int score)
        {
            this.score = score;
        }
        public int getScore()
        {
            return score;
        }
        public string getName()
        {
            return name;
        }
    }
}
