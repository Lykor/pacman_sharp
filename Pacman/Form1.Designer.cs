
namespace Pacman
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.PacmanPic = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leadersItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interfacePanel = new System.Windows.Forms.Panel();
            this.eggPic = new System.Windows.Forms.PictureBox();
            this.hearthThree = new System.Windows.Forms.PictureBox();
            this.hearthTwo = new System.Windows.Forms.PictureBox();
            this.hearthOne = new System.Windows.Forms.PictureBox();
            this.pointLabel = new System.Windows.Forms.Label();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.gamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PacmanPic)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.interfacePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eggPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hearthThree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hearthTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hearthOne)).BeginInit();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gamePanel.Controls.Add(this.PacmanPic);
            this.gamePanel.Location = new System.Drawing.Point(0, 31);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(400, 400);
            this.gamePanel.TabIndex = 1;
            // 
            // PacmanPic
            // 
            this.PacmanPic.BackColor = System.Drawing.Color.Transparent;
            this.PacmanPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PacmanPic.Image = global::Pacman.Properties.Resources.right;
            this.PacmanPic.Location = new System.Drawing.Point(0, 0);
            this.PacmanPic.Name = "PacmanPic";
            this.PacmanPic.Size = new System.Drawing.Size(20, 20);
            this.PacmanPic.TabIndex = 0;
            this.PacmanPic.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowDrop = true;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileItem,
            this.gameItem,
            this.aboutItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(400, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileItem
            // 
            this.fileItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSaveItem,
            this.saveItem});
            this.fileItem.Name = "fileItem";
            this.fileItem.Size = new System.Drawing.Size(59, 24);
            this.fileItem.Text = "Файл";
            // 
            // loadSaveItem
            // 
            this.loadSaveItem.Name = "loadSaveItem";
            this.loadSaveItem.Size = new System.Drawing.Size(239, 26);
            this.loadSaveItem.Text = "Загрузка сохранения";
            this.loadSaveItem.Click += new System.EventHandler(this.loadSaveButton_click);
            // 
            // saveItem
            // 
            this.saveItem.Name = "saveItem";
            this.saveItem.Size = new System.Drawing.Size(239, 26);
            this.saveItem.Text = "Сохранение игры";
            this.saveItem.Click += new System.EventHandler(this.saveButton_click);
            // 
            // gameItem
            // 
            this.gameItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startItem,
            this.pauseItem,
            this.leadersItem});
            this.gameItem.Name = "gameItem";
            this.gameItem.Size = new System.Drawing.Size(57, 24);
            this.gameItem.Text = "Игра";
            // 
            // startItem
            // 
            this.startItem.Name = "startItem";
            this.startItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.startItem.Size = new System.Drawing.Size(196, 26);
            this.startItem.Text = "Старт";
            this.startItem.Click += new System.EventHandler(this.startButton_click);
            // 
            // pauseItem
            // 
            this.pauseItem.Name = "pauseItem";
            this.pauseItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.pauseItem.Size = new System.Drawing.Size(196, 26);
            this.pauseItem.Text = "Пауза";
            this.pauseItem.Click += new System.EventHandler(this.pauseButton_click);
            // 
            // leadersItem
            // 
            this.leadersItem.Name = "leadersItem";
            this.leadersItem.Size = new System.Drawing.Size(196, 26);
            this.leadersItem.Text = "Доска лидеров";
            this.leadersItem.Click += new System.EventHandler(this.leaderButton_click);
            // 
            // aboutItem
            // 
            this.aboutItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpItem});
            this.aboutItem.Name = "aboutItem";
            this.aboutItem.Size = new System.Drawing.Size(81, 24);
            this.aboutItem.Text = "Справка";
            // 
            // helpItem
            // 
            this.helpItem.CheckOnClick = true;
            this.helpItem.Name = "helpItem";
            this.helpItem.Size = new System.Drawing.Size(152, 26);
            this.helpItem.Text = "Помощь";
            this.helpItem.Click += new System.EventHandler(this.helpClickItem);
            // 
            // interfacePanel
            // 
            this.interfacePanel.Controls.Add(this.eggPic);
            this.interfacePanel.Controls.Add(this.hearthThree);
            this.interfacePanel.Controls.Add(this.hearthTwo);
            this.interfacePanel.Controls.Add(this.hearthOne);
            this.interfacePanel.Controls.Add(this.pointLabel);
            this.interfacePanel.Controls.Add(this.pointsLabel);
            this.interfacePanel.Location = new System.Drawing.Point(0, 437);
            this.interfacePanel.Name = "interfacePanel";
            this.interfacePanel.Size = new System.Drawing.Size(400, 50);
            this.interfacePanel.TabIndex = 3;
            // 
            // eggPic
            // 
            this.eggPic.BackColor = System.Drawing.Color.Transparent;
            this.eggPic.BackgroundImage = global::Pacman.Properties.Resources.egg;
            this.eggPic.Location = new System.Drawing.Point(211, 15);
            this.eggPic.Name = "eggPic";
            this.eggPic.Size = new System.Drawing.Size(20, 20);
            this.eggPic.TabIndex = 5;
            this.eggPic.TabStop = false;
            // 
            // hearthThree
            // 
            this.hearthThree.BackgroundImage = global::Pacman.Properties.Resources.hearthIcon;
            this.hearthThree.Location = new System.Drawing.Point(105, 15);
            this.hearthThree.Name = "hearthThree";
            this.hearthThree.Size = new System.Drawing.Size(20, 20);
            this.hearthThree.TabIndex = 4;
            this.hearthThree.TabStop = false;
            // 
            // hearthTwo
            // 
            this.hearthTwo.BackgroundImage = global::Pacman.Properties.Resources.hearthIcon;
            this.hearthTwo.Location = new System.Drawing.Point(66, 15);
            this.hearthTwo.Name = "hearthTwo";
            this.hearthTwo.Size = new System.Drawing.Size(20, 20);
            this.hearthTwo.TabIndex = 3;
            this.hearthTwo.TabStop = false;
            // 
            // hearthOne
            // 
            this.hearthOne.BackgroundImage = global::Pacman.Properties.Resources.hearthIcon;
            this.hearthOne.Location = new System.Drawing.Point(29, 14);
            this.hearthOne.Name = "hearthOne";
            this.hearthOne.Size = new System.Drawing.Size(20, 20);
            this.hearthOne.TabIndex = 2;
            this.hearthOne.TabStop = false;
            // 
            // pointLabel
            // 
            this.pointLabel.AutoSize = true;
            this.pointLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.pointLabel.Location = new System.Drawing.Point(290, 14);
            this.pointLabel.Name = "pointLabel";
            this.pointLabel.Size = new System.Drawing.Size(17, 20);
            this.pointLabel.TabIndex = 1;
            this.pointLabel.Text = "0";
            // 
            // pointsLabel
            // 
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.pointsLabel.Location = new System.Drawing.Point(237, 14);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(50, 20);
            this.pointsLabel.TabIndex = 0;
            this.pointsLabel.Text = "ОЧКИ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(400, 490);
            this.Controls.Add(this.interfacePanel);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pacman";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.gamePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PacmanPic)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.interfacePanel.ResumeLayout(false);
            this.interfacePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eggPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hearthThree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hearthTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hearthOne)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.PictureBox PacmanPic;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem fileItem;
        private System.Windows.Forms.ToolStripMenuItem loadSaveItem;
        private System.Windows.Forms.ToolStripMenuItem saveItem;
        private System.Windows.Forms.ToolStripMenuItem gameItem;
        private System.Windows.Forms.ToolStripMenuItem startItem;
        private System.Windows.Forms.ToolStripMenuItem pauseItem;
        private System.Windows.Forms.ToolStripMenuItem leadersItem;
        private System.Windows.Forms.ToolStripMenuItem aboutItem;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem helpItem;
        private System.Windows.Forms.Panel interfacePanel;
        private System.Windows.Forms.Label pointLabel;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.PictureBox hearthOne;
        private System.Windows.Forms.PictureBox hearthThree;
        private System.Windows.Forms.PictureBox hearthTwo;
        private System.Windows.Forms.PictureBox eggPic;
    }
}

