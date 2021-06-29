using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        Game game; // объект с хранением информации игры и частично логикой
        Pacman pac; // объект игрока
        List<Bot> ghots; // коллекция ботов
        int[,] mapGame; // массив карты
        PictureBox[,] blockPic; // массив картинок блоков
        PictureBox[] ghotPic; // массив картинок ботов
        public Form1()
        {        
            InitializeComponent();
            game = new Game();  // создаем объект игры
            game.generateLever(); // генерируем уровень
            blockPic = new PictureBox[game.getWidthMap(), game.getHeightMap()]; // выделяем память массиву картинок
            timer1.Enabled = false; // указываем что таймер отключен
            pac = new Pacman(0, 0, 10); // создаем объект пакмена
            PacmanPic.Location = new Point(pac.getX(), pac.getY()); // передаем рсположение пакмена картинке
            PacmanPic.Image = Properties.Resources.right; // передаем объектку картинки картинку
            eggPic.Visible = false; // делаем невидимым картинку символизирующую пасхалку в интерфейсе
            fiilMap(); // заполнение панели игры блоками 
            ghots = new List<Bot>(); // инициализации коллекции
            visualHearth(); // вызов функции визуализации жизней
            ghotPic = new PictureBox[4]; // выделение памяти массиву картинок ботов
            createBots(); // создание ботов
            loadLeaders(); // загрузка списка лидеров с файла
        }
        // создание ботов
        private void createBots()
        {
           // в данной функции происходит создание ботов и загрузка их в панель
            Bot ghost = new Bot(200,100,5);
            ghost.setDir(2);
            ghots.Add(ghost);

            ghotPic[0] = new PictureBox();
            ghotPic[0].Size = new System.Drawing.Size(20, 20);
            ghotPic[0].Image = Properties.Resources.ghost1;
            ghotPic[0].Location = new Point(ghost.getX(), ghost.getY());
            gamePanel.Controls.Add(ghotPic[0]);

            Bot ghost2 = new Bot(260, 200, 10);
            ghost2.setDir(-1);
            ghots.Add(ghost2);

            ghotPic[1] = new PictureBox();
            ghotPic[1].Size = new System.Drawing.Size(20, 20);
            ghotPic[1].Image = Properties.Resources.ghost2;
            ghotPic[1].Location = new Point(ghost2.getX(), ghost2.getY());
            gamePanel.Controls.Add(ghotPic[1]);

            Bot ghost3 = new Bot(380, 300, 5);
            ghost3.setDir(1);
            ghots.Add(ghost3);
            

            ghotPic[2] = new PictureBox();
            ghotPic[2].Size = new System.Drawing.Size(20, 20);
            ghotPic[2].Image = Properties.Resources.ghost3;
            ghotPic[2].Location = new Point(ghost3.getX(), ghost3.getY());
            gamePanel.Controls.Add(ghotPic[2]);

            Bot ghost4 = new Bot(300, 380, 10);
            ghost4.setDir(-2);
            ghots.Add(ghost4);

            ghotPic[3] = new PictureBox();
            ghotPic[3].Size = new System.Drawing.Size(20, 20);
            ghotPic[3].Image = Properties.Resources.ghost4;
            ghotPic[3].Location = new Point(ghost4.getX(), ghost4.getY());
            gamePanel.Controls.Add(ghotPic[3]);

        }
        // загрузка панели картинками с картой в виде разноцветных квадратов
        private void fiilMap()
        {
            mapGame = game.getLevel(); // получение карты игры
            for(int i = 0; i < game.getWidthMap(); i++)
            {
                for(int j = 0; j < game.getHeightMap(); j++)
                {
                    if (i == 0) continue;
                    // в зависимости от карты
                    switch (mapGame[i, j])
                    {
                        case 1: // если блок - трава, то он будет зеленым
                            createBlock(Color.Green, (i*20), (j*20), i, j);
                            break;
                        case -1: // если блок - камень, то он будет белым
                            createBlock(Color.White, (i*20), (j*20), i, j);
                            break;
                        case 2: // если блок - пасхалка, то он будет желтым
                            createBlock(Color.Yellow, (i * 20), (j * 20), i, j);
                            break;
                    }
                }
            }
        }
        // функция создания блоков внутри панели
        private void createBlock(Color color, int x, int y, int i, int j)
        {
            blockPic[i,j] = new PictureBox(); // создаем блок и указываем данные с учетом параметров
            blockPic[i, j].Location = new System.Drawing.Point(x, y);
            blockPic[i, j].Size = new System.Drawing.Size(20, 20);
            blockPic[i, j].BackColor = color;
            gamePanel.Controls.Add(blockPic[i, j]); // добавляем в панель
        }
        // функция таймера. Вызывается, если активен таймер, опреденный интервал
        private void timer1_Tick(object sender, EventArgs e)
        {
            // если игра начата
            if (game.getStateGame())
            {
                // если пасхалка есть
                if (game.getXegg() < -20)
                {
                    eggPic.Visible = true; // визуализируем
                }
                visualHearth(); // вызываем функцию визуализации жизней
                moveBots(); // вызываем функцию просчитывания движения ботов
                checkBots(); // проверка ботов
                pac.updateLocation();  // обновление координат
                // чтобы пользователь не ушел в пустоту, делаем зеркальное отражение при уходе за пределы
                if (pac.getX() > 420 && pac.getDir() == 1)
                {
                    pac.setX(0); 
                    pac.setY(pac.getY());
                }
                else if(pac.getX() < -20 && pac.getDir() == -1)
                {
                    pac.setX(400);
                    pac.setY(pac.getY());
                }
                else if(pac.getY() < -20 && pac.getDir() == -2)
                {
                    pac.setX(pac.getX());
                    pac.setY(400);
                }
                else if(pac.getY() > 420 && pac.getDir() == 2)
                {
                    pac.setX(pac.getX());
                    pac.setY(0);
                }
                checkBlocks(); // проверка на пересечение с блоками
                // передаем новые позиции в картинку пакмена
                PacmanPic.Location = new Point(pac.getX(), pac.getY());
                // передаем значение очков игрока в лейбл очков
                pointLabel.Text = game.getPoints().ToString(); 
                // проверка на победу
                if (game.isWin())
                {
                    game.Stop(); // остановка игры
                    timer1.Enabled = false; // остановка таймера
                    MessageBox.Show("Вы победили"); // вывод сообщения
                    addToLeader(); // добавление в лидеры
                    restartGame(); // перезапуск игры
                }
                // проверка на поражение
                if (game.isLose())
                {
                    game.Stop(); // остановка игры
                    timer1.Enabled = false; // остановка таймера
                    MessageBox.Show("Вы проиграли"); // вывод сообщения
                    addToLeader(); // добавление в список игроков
                    restartGame(); // перезапуск игры
                }

            }
        }
        // загрузка лидеров с файла
        private void loadLeaders()
        {
            using (Stream s = File.Open("leaders.json", FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            {
                string json = sr.ReadLine(); // получаем строку
                List<Leader> leaders = JsonConvert.DeserializeObject<List<Leader>>(json); // преобразуем в объект коллекции объектов лидеров
                game.setLeaders(leaders); // передаем в объект игры список лидеров
                
            }
        }
        // добавление лидеров в список
        private void addToLeader()
        {
            int score = game.getPoints();   // получение очков с объекта игры
            var AddLead = new Form(); // создание формы
            AddLead.StartPosition = FormStartPosition.CenterScreen; // указываем центральное размещение формы
            AddLead.AutoSize = true; // размеры автоматические
            AddLead.BackColor = Color.White; // цвет заднего фона
            AddLead.ForeColor = Color.Black; // цвет на переднем плане
            AddLead.Name = "Сохранение в доску почета"; // название формы
            Label name = new Label(); // лейбл для размещения текста в форме
            name.Text = "Напишите ваше имя"; // тескт лейбла
            name.ForeColor = Color.Black; // цвета
            name.BackColor = Color.White;
            name.Location = new Point(75, 15); // расположение
            AddLead.Controls.Add(name); // добавление лейбла в форму
            TextBox field1 = new TextBox() // создание объекта ввода
            {
                Location = new Point(name.Location.X, name.Location.Y + 50) // расположение
            };
            field1.BackColor = Color.White; // цвета
            field1.ForeColor = Color.Black;
            Button b = new Button(); // создание кнопки
            b.ForeColor = Color.Black; // цвета
            b.BackColor = Color.White;
            b.Location = new Point(field1.Location.X, field1.Location.Y + 50); // расположение кнопки
            b.Text = "Сохранить"; // текст кнопки
            b.Click += (sender, args) => // событий отклика
            {
                if (field1.Text.Length > 0) // если поле больше 0, то записываем лидера
                {
                    game.addLeader(field1.Text, score); // записываем лидера в коллекцию, внутри объекта game
                    var jsonStr = JsonConvert.SerializeObject(game.getLeaders()); // преобразуем коллекцию в json строку
                    File.WriteAllText("leaders.json", string.Empty); // очищаем файл
                    using (Stream s = File.Open("leaders.json", FileMode.OpenOrCreate)) // открываем как созданный или создаем новый
                    using (StreamWriter sw = new StreamWriter(s))
                    {                        
                        sw.Write(jsonStr); // записываем json
                    }
                    loadLeaders();
                    AddLead.Close();
                }
                else // иначе вывходим текст что не заполнено
                {
                    name.Text = "Ты не заполнил";
                }
            };
            AddLead.Controls.Add(field1); // добавление в форму поля
            AddLead.Controls.Add(b); // добавление в форму кнопки
            AddLead.Show(); // показываем окно
            
        }
        // проверка ботов на пересечение с пакменом
        private void checkBots()
        {
            // перебираем все и относительно координат определяем что он находится на той же позиции что и пакмен
            for (int i = 0; i < 4; i++) { 
                if(ghots[i].getX() == pac.getX() && ghots[i].getY() == pac.getY()
                    || ghots[i].getX()+5 == pac.getX() && ghots[i].getX()-5 == pac.getX() &&
                       ghots[i].getY()+5 == pac.getY() && ghots[i].getY()-5 == pac.getY())
                {
                    game.setHearth(game.getHearth() - 1); // если это так то уменьшаем жизни
                    pac.setX(0); // указываем координаты возраждения
                    pac.setY(0);
                    pac.setSpeed(10); // указываем начальную скорость
                    game.Stop(); // ставим на паузу
                }
            }
        }

        // движение ботов
        private void moveBots()
        {
            // перебираем всех ботов
            for(int i = 0; i < 4; i++)
            {
                ghots[i].updateLocation(); // обновление координат переменных
                // чтобы бот не уходил за пределы экрана делаем переходы слева направо и сверху вниз
                if (ghots[i].getX() > 420 && ghots[i].getDir() == 1)
                {
                    ghots[i].setX(0);
                    ghots[i].setY(ghots[i].getY());
                }
                else if (ghots[i].getX() < -20 && ghots[i].getDir() == -1)
                {
                    ghots[i].setX(400);
                    ghots[i].setY(ghots[i].getY());
                }
                else if (ghots[i].getY() < -20 && ghots[i].getDir() == -2)
                {
                    ghots[i].setX(ghots[i].getX());
                    ghots[i].setY(400);
                }
                else if (ghots[i].getY() > 420 && ghots[i].getDir() == 2)
                {
                    ghots[i].setX(ghots[i].getX());
                    ghots[i].setY(0);
                }
                // указываем расположение картинки ботов из координат полученных
                ghotPic[i].Location = new Point(ghots[i].getX(), ghots[i].getY());
            }
        }
        // очистка карты от блоков с травой и камнями(очистка визуализированной части)
        private void clearVisualBlock()
        {
            for (int i = 0; i < game.getWidthMap(); i++)
            {
                for (int j = 0; j < game.getHeightMap(); j++)
                {
                    gamePanel.Controls.Remove(blockPic[i, j]); // удаляем каждый блок с панели
                }
            }
        }
        // перезапуск игры
        private void restartGame()
        {
            clearVisualBlock(); // очистка полей
            game.setHearth(3); // указываем жизни
            game.setPoints(0); // указываем очки
            game.generateLever(); // генерируем левел
            blockPic = new PictureBox[game.getWidthMap(), game.getHeightMap()]; // выделяем память под картинки
            timer1.Enabled = false; // указываем что таймер выключен
            pac = new Pacman(0, 0, 10); // создаем объект пакмена указывая координаты возраждения
            PacmanPic.Location = new Point(pac.getX(), pac.getY()); // передаем данные картинке пакмена
            PacmanPic.Image = Properties.Resources.right; // задаем картинку пакмену
            eggPic.Visible = false; // убираем картинку пасхального яйца
            fiilMap(); // Заполнение карты блоками с травой и камнями, точнее визуализация карты левела
            visualHearth(); // визуализация интерфейса с жизнями
        }

        // визуализация интерфейса с жизнями
        private void visualHearth()
        {
            // отображаем определнное количество картинок, в зависимости от количества жизней
            switch (game.getHearth())
            {
                case 1:
                    hearthOne.Visible = true;
                    hearthTwo.Visible = false;
                    hearthThree.Visible = false;
                    break;
                case 2:
                    hearthOne.Visible = true;
                    hearthTwo.Visible = true;
                    hearthThree.Visible = false;
                    break;
                case 3:
                    hearthOne.Visible = true;
                    hearthTwo.Visible = true;
                    hearthThree.Visible = true;
                    break;
            }
        }
        // проверка блоков пересечений пакмена
        private void checkBlocks()
        {
            for(int i = 0; i < game.getWidthMap(); i++)
            {
                for(int j = 0; j < game.getHeightMap(); j++)
                {
                    if (i == 0) continue;
                    if (pac.getX() == i * 20 && pac.getY() == j * 20)
                    {
                        // анализируем с генерированной картой уровня на какой клетке находится пакмен
                        switch (mapGame[i, j])
                        {
                            case 1: // если клетка является травой
                                gamePanel.Controls.Remove(blockPic[i, j]); // удаление картинки травы
                                game.setPoints(game.getPoints() + 1); // добавления очка
                                mapGame[i, j] = 0; // удаление с массива условного указателя травы
                                game.setLevel(mapGame); // обновленный массив передаем в объект с данными игры
                                break;
                            case -1: // если клетка является камне
                                game.setHearth(game.getHearth() - 1); // убираем 1 жизнь
                                pac.setX(0); // устанавливаем координаты возраждения
                                pac.setY(0);
                                game.Stop(); // ставим на паузу
                                break;
                            case 2: // если клетка является пасхальным яйцом
                                game.setPoints(game.getPoints() + 20); // прибавляем 20 очков
                                game.setXegg(-40); // передаем координаты яйца как можно дальше
                                game.setYegg(-40);
                                gamePanel.Controls.Remove(blockPic[i, j]); // убираем объект с панели(картинку модели яйца)
                                mapGame[i, j] = 0; // устанавливаем в массиве карты что там ничего нет
                                game.setLevel(mapGame); // передаем обновленный массив в объект с описанием игры
                                break;
                        }
                    }

                }
            }
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // кнопка помощи
        private void helpClickItem(object sender, EventArgs e)
        {
            MessageBox.Show("*Для передвижения используйте - W,A,S,D\nCTRL-D - начало игры\nCTRD-S - пауза\nX - смена скорости\nZ - остановка пакмена\n");
        }
        // кнопка сохранения
        private void saveButton_click(object sender, EventArgs e)
        {
            game.Stop(); // останавливаем игру
            SaveFileDialog sv = new SaveFileDialog(); // создаем объект диалога через проводник
            sv.Filter = "Json (*.json)|*.json"; // указываем фильтр по json-ам
            Saver saver = new Saver(); // создаем объект для сгрупирования всех необходимых данных игры
            saver.game = game; // передаем объект игры 
            saver.pac = pac; // передаем пакмена
            saver.ghosts = ghots; // передаем ботов
            var jsonObject = JsonConvert.SerializeObject(saver); // преобразуем в формат json строки
            if (sv.ShowDialog() == DialogResult.OK) // открываем диалог
            {
                // открываем файл
                using (Stream s = File.Open(sv.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {                    
                    sw.WriteLine(jsonObject); // записываем строку json                   
                }
            }



        }
        // кнопка загрузки сохранения
        private void loadSaveButton_click(object sender, EventArgs e)
        {
            game.Stop(); // остановка игры
            OpenFileDialog of = new OpenFileDialog(); // открываем диалог
            of.Filter = "Json (*.json)|*.json"; // формат данных для открытия
            Saver saver = new Saver(); // создаем объект для получения
            if (of.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(of.FileName, FileMode.Open))
                using (StreamReader sr = new StreamReader(s))
                {
                    JsonSerializer serializer = new JsonSerializer(); // создаем объект дессериализации
                    saver = (Saver)serializer.Deserialize(sr, typeof(Saver)); // получаем с файла объект Saver
                    sr.ReadLine(); 
                }
            }
            game = saver.game; // передаем данные из объекта Saver в остальные
            ghots = saver.ghosts;
            pac = saver.pac;
            saveSet(); // вызываем функцию для установке данных, чтобы обновились картинки внутри игры
        }
        // обновление картинок после загрузки сохранения
        private void saveSet()
        {
            clearVisualBlock(); // очищение блоков карты
            visualHearth(); // визуализация жизней
            for(int i = 0; i < 4; i++) // перебор всех призраков и установка координат 
            {
                ghotPic[i].Location = new Point(ghots[i].getX(), ghots[i].getY());
            }
            pointLabel.Text = game.getPoints().ToString();  // передаем количество очков
            PacmanPic.Location = new Point(pac.getX(), pac.getY()); // устанавливаем позицию пакмена картинки
            fiilMap(); // заполняем карту блоками картинок
        }

        
        // кнопка начала
        private void startButton_click(object sender, EventArgs e)
        {
            // если статус игры = игра не начата
            if (!game.getStateGame())
            {
                game.Start(); // запускаем игру
                timer1.Enabled = true; // запускаем таймер
            }
        }
        // кнопка паузы
        private void pauseButton_click(object sender, EventArgs e)
        {
            // если статус игры = игра начата
            if (game.getStateGame())
            {
                game.Stop(); // останавливаем игру
                timer1.Enabled = false; // останавливаем таймер
            }
        }
        // таблица лидеров
        private void leaderButton_click(object sender, EventArgs e)
        {
            string outstr = "Таблица лидеров:\n";
            // перебираем всех лидеров
            foreach(Leader leader in game.getLeaders())
            {
                outstr += leader.getName() + " - " + leader.getScore().ToString() + "\n"; // добавляем в строку вывода
            }
            MessageBox.Show(outstr); // выводим
        }
        // обработка нажатий клавиш в форме
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // если в игре
            if (game.getStateGame())
            {
                switch (e.KeyCode)
                {
                    case Keys.A: // если нажата А
                        PacmanPic.Image = Properties.Resources.left; // меняем картинку
                        pac.setDir(-1); // меняем движение влево по X
                        break;
                    case Keys.D: // если нажата D
                        PacmanPic.Image = Properties.Resources.right; // меняем картинку
                        pac.setDir(1);// меняем движение вправо по X
                        break;
                    case Keys.W:
                        PacmanPic.Image = Properties.Resources.up; // меняем картинку
                        pac.setDir(-2);// движение вверх
                        break;
                    case Keys.S:
                        PacmanPic.Image = Properties.Resources.down; // меняем картинку
                        pac.setDir(2); // движение вниз
                        break;
                    case Keys.X:
                        pac.setSpeed(pac.getSpeed() == 10 ? 20 : 10); // смена скорости от 10 до 20, в зависимости от значения изначального
                        break;
                    case Keys.Z:
                        pac.setSpeed(pac.getSpeed() == 0 ? 10 : 0); // остановка на месте
                        break;
                }
            }
        }
    }
}
