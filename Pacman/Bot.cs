using System;
using System.Collections.Generic;
using System.Text;

namespace Pacman
{
    // Класс бота
    class Bot
    {
        public int[] data { get; set; }
        public Bot()
        {
            data = new int[4];
            data[0] = 15;
            data[1] = 15;
            data[2] = 2;
        }
        public Bot(int x, int y, int speed)
        {
            data = new int[4];
            data[0] = x;
            data[1] = y;
            data[2] = speed;
        }

        public void setX(int x)
        {
            data[0] = x;
        }
        public void setY(int y)
        {
            data[1] = y;
        }
        public void setSpeed(int speed)
        {
            data[2] = speed;
        }

        public int getSpeed()
        {
            return data[2];
        }
        public int getX()
        {
            return data[0];
        }

        public int getY()
        {
            return data[1];
        }
        public void setDir(int dir)
        {
            data[3] = dir;
        }
        public int getDir()
        {
            return data[3];
        }
        // обновление передвижения по типу *новая координата = *старая координата +/- *скорость в зависимости от направления
        public void updateLocation()
        {
            switch (data[3])
            {
                case -1:
                    data[0] = data[0] - data[2];
                    break;
                case 1:
                    data[0] = data[0] + data[2];
                    break;
                case -2:
                    data[1] = data[1] - data[2];
                    break;
                case 2:
                    data[1] = data[1] + data[2];
                    break;
            }
        }
    }
}
