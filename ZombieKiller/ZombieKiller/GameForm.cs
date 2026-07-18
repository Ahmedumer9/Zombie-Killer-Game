using System;
using System.Drawing;
using System.Windows.Forms;

namespace ZombieKiller
{
    public partial class GameForm : Form
    {
        Game.Game game;

        public GameForm()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint, true);

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Zombie Killer";
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    this.BackgroundImage = ZombieKiller.Properties.Resources.background;
            //    this.BackgroundImageLayout = ImageLayout.Stretch;
            //}
            //catch { }

            StartForm startForm = new StartForm();
            DialogResult result = startForm.ShowDialog();
            if (result == DialogResult.Yes)
            {
                game = new Game.Game(this);
                game.Start();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}