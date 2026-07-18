using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZombieKiller.Enums;
using ZombieKiller.GameObjects;
using ZombieKiller.Interfaces;

namespace ZombieKiller.GameObjects
{
    internal class Player : GameObject, ICollidable
    {
        public ProgressBar PlayerHealth { get; set; }
        public Label lbScore { get; set; }
        public Label lbLevel { get; set; }
        private int score = 0;
        public int Score => score;

        public Player(Image img, int formClientWidth, int formClientHeight)
        {
            Sprite = new PictureBox();
            Sprite.Image = img;
            Sprite.Height = 100;
            Sprite.Width = 100;
            Sprite.SizeMode = PictureBoxSizeMode.StretchImage;
            Sprite.BackColor = Color.Transparent;
            Sprite.Left = (formClientWidth - Sprite.Width) / 2;
            Sprite.Top = formClientHeight - Sprite.Height - 30;

            PlayerHealth = new ProgressBar();
            PlayerHealth.Value = 100;
            PlayerHealth.Width = 150;
            PlayerHealth.Left = 20;
            PlayerHealth.Top = 20;

            lbScore = new Label();
            lbScore.Text = "Score:  ";
            lbScore.ForeColor = Color.White;
            lbScore.BackColor = Color.Black;
            lbScore.AutoSize = true;
            lbScore.Left = 20;
            lbScore.Top = 50;

            lbLevel = new Label();
            lbLevel.Text = "Level: 1";
            lbLevel.ForeColor = Color.White;
            lbLevel.BackColor = Color.Black;
            lbLevel.AutoSize = true;
            lbLevel.Left = 20;
            lbLevel.Top = 75;
        }

        public override void update()
        {

        }

        public Bullet Fire(Image bulletImg)
        {
            Bullet bullet = new Bullet(bulletImg, Sprite.Left + (Sprite.Width / 2), Sprite.Top - 20, BulletDirection.Up, this);
            return bullet;
        }

        public void moveLeft(int speed)
        {
            Sprite.Left = Sprite.Left - speed - 10;
        }

        public void moveRight(int speed)
        {
            Sprite.Left = Sprite.Left + speed + 10;
        }

        public void moveUp(int speed)
        {
            Sprite.Top = Sprite.Top - speed - 10;
        }

        public void moveDown(int speed)
        {
            Sprite.Top = Sprite.Top + speed + 10;
        }

        public void onCollision(GameObject g)
        {
            if (g is Enemy)
            {
                PlayerHealth.Value = Math.Max(0, PlayerHealth.Value - 30);
            }
            else if (g is Medkit)
            {
                PlayerHealth.Value = Math.Min(100, PlayerHealth.Value + 20);
            }
        }

        public void AddScore(int points)
        {
            score += points;
            lbScore.Text = "Score: " + score;
        }

      
    }
}