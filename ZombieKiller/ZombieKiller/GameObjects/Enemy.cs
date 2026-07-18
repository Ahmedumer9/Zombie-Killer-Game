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
using ZombieKiller.GameObjects;
using ZombieKiller.Interfaces;

namespace ZombieKiller.GameObjects
{
    internal class Enemy : GameObject, ICollidable
    {
        private int formClientWidth;
        private int formClientHeight;
        private Random random;
        private int speed;

        public Enemy(Image img, int formClientWidth, int formClientHeight, Random random, List<Enemy> existingEnemies, int level)
        {
            this.formClientWidth = formClientWidth;
            this.formClientHeight = formClientHeight;
            this.random = random;
            this.speed = level == 2 ? 12 : 8;

            Sprite = new PictureBox();
            Sprite.Image = img;
            Sprite.Height = 100;
            Sprite.Width = 100;
            Sprite.SizeMode = PictureBoxSizeMode.StretchImage;
            Sprite.BackColor = Color.Transparent;

            PlaceAtTop(existingEnemies);
        }

        private void PlaceAtTop(List<Enemy> existingEnemies)
        {
            bool validPosition = false;

            while (!validPosition)
            {
                Sprite.Left = random.Next(0, formClientWidth - Sprite.Width);
                Sprite.Top = random.Next(-300, -50);

                validPosition = true;

                foreach (Enemy e in existingEnemies)
                {
                    Rectangle newEnemy = new Rectangle(Sprite.Left, Sprite.Top, Sprite.Width, Sprite.Height);
                    Rectangle existingEnemy = new Rectangle(e.Sprite.Left, e.Sprite.Top, e.Sprite.Width, e.Sprite.Height);

                    if (newEnemy.IntersectsWith(existingEnemy))
                    {
                        validPosition = false;
                        break;
                    }
                }
            }
        }

        public override void update()
        {
            Sprite.Top += speed;

            if (Sprite.Top > formClientHeight)
            {
                Sprite.Left = random.Next(0, formClientWidth - Sprite.Width);
                Sprite.Top = random.Next(-300, -50);
            }
        }

        public void onCollision(GameObject g)
        {
            Destroy();
        }
    }
}