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
    internal class Medkit : GameObject, ICollidable
    {
        public Medkit(Image img, int formClientWidth, Random random)
        {
            Sprite = new PictureBox();
            Sprite.Image = img;
            Sprite.Width = 40;
            Sprite.Height = 40;
            Sprite.SizeMode = PictureBoxSizeMode.StretchImage;
            Sprite.BackColor = Color.Transparent;
            Sprite.Left = random.Next(0, formClientWidth - Sprite.Width);
            Sprite.Top = random.Next(-300, -50);
        }

        public override void update()
        {
            Sprite.Top += 4;
        }

        public void onCollision(GameObject g)
        {
            Destroy();
        }
    }
}