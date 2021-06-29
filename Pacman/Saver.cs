using System;
using System.Collections.Generic;
using System.Text;

namespace Pacman
{
    // Класс для осуществления упрощенного вида записи сохранения и его чтения
    class Saver
    {
        // основные объекты игры которые необходимо записать либо считать
        public Pacman pac { get; set; } // пакмен
        public Game game { get; set; } // инфа игры
        public List<Bot> ghosts { get; set; } // инфа ботов
    }
}
