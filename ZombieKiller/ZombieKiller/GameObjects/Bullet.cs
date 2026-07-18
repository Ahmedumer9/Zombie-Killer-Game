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
    internal class Bullet : GameObject, ICollidable
    {
        BulletDirection direction;
        Player player;

        public Bullet(Image img, int x, int y, BulletDirection direction, Player player)
        {
            Sprite = new PictureBox();
            Sprite.Image = img;
            Sprite.Height = img.Height;
            Sprite.Width = img.Width;
            Sprite.BackColor = Color.Transparent;
            Sprite.Left = x;
            Sprite.Top = y;
            this.direction = direction;
            this.player = player;
        }

        public override void update()
        {
            if (direction == BulletDirection.Up)
            {
                Sprite.Top = Sprite.Top - 10;
                if (Sprite.Top < -Sprite.Height)
                    Destroy();
            }
            else
            {
                Sprite.Top = Sprite.Top + 10;
                if (Sprite.Top > Sprite.Parent?.ClientSize.Height)
                    Destroy();
            }
        }

        public void onCollision(GameObject g)
        {
            if (g is Enemy)
            {
                player.AddScore(20);
            }
            Destroy();
        }
    }
}