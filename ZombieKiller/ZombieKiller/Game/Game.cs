using System;
using EZInput;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZombieKiller.GameObjects;
using ZombieKiller.Managers;
using ZombieKiller.Properties;

namespace ZombieKiller.Game 
{
    internal class Game 
    {
        private const int PlayerSpeed = 5; 
        private int level = 1;

        Player player;
        List<GameObject> gameObjects;
        List<GameObject> pendingAdd;
        InputManager inputManager;
        CollisionManager collisionManager;
        Form GameForm;
        Timer gameLoop;
        Random random;

        public Game(Form gameForm)
        {
            this.GameForm = gameForm;
            gameObjects = new List<GameObject>();
            pendingAdd = new List<GameObject>();
            inputManager = new InputManager();
            collisionManager = new CollisionManager();
            random = new Random();

            gameLoop = new Timer();
            gameLoop.Interval = 16;
            gameLoop.Tick += (s, e) => update();
        }

        public void Start()
        {
            createPlayer();
            createEnemies(5);
            createMedkit();
            gameLoop.Start();
        }

        public void Stop()
        {
            gameLoop.Stop();
        }

        private void createPlayer()
        {
            player = new Player(Resources.player1, GameForm.ClientSize.Width, GameForm.ClientSize.Height);
            gameObjects.Add(player);
            GameForm.Controls.Add(player.Sprite);
            GameForm.Controls.Add(player.PlayerHealth);
            GameForm.Controls.Add(player.lbScore);
            GameForm.Controls.Add(player.lbLevel);


            player.PlayerHealth.BringToFront();
            player.lbScore.BringToFront();
            player.lbLevel.BringToFront();
        }

        private void createEnemies(int count)
        {
            List<Enemy> existing = new List<Enemy>();
            for (int i = 0; i < count; i++)
            {
                Image img = Resources.zombie1;

                Enemy enemy = new Enemy(img, GameForm.ClientSize.Width, GameForm.ClientSize.Height, random, existing, level);
                existing.Add(enemy);
                gameObjects.Add(enemy);
                GameForm.Controls.Add(enemy.Sprite);
            }
        }

        private void createMedkit()
        {
            Medkit medkit = new Medkit(Resources.health, GameForm.ClientSize.Width, random);
            gameObjects.Add(medkit);
            GameForm.Controls.Add(medkit.Sprite);
        }

        public void update()
        {
            HandleInput();
            DetectCollisions();
            RemoveDeadObjects();


            foreach (GameObject go in pendingAdd)
            {
                gameObjects.Add(go);
                GameForm.Controls.Add(go.Sprite);
            }
            pendingAdd.Clear();


            GameForm.SuspendLayout();
            foreach (GameObject go in gameObjects)
            {
                go.update();
            }
            GameForm.ResumeLayout(false);

            if (player.PlayerHealth.Value <= 0)
            {
                ShowEndForm(Resources.gameover);
                return;
            }

            if (player.Score >= 1000)
            {
                ShowEndForm(Resources.win);
                return;
            }



            if (player.Score >= 500 && level == 1)
            {
                level = 2;
                player.lbLevel.Text = "Level: 2";
            }

            int maxEnemies = level == 2 ? 10 : 5;
            int enemyCount = gameObjects.Count(g => g is Enemy && g.IsAlive);
            int enemiesToSpawn = maxEnemies - enemyCount;
            if (enemiesToSpawn > 0)

            {
                createEnemies(enemiesToSpawn);
            }

            int medkitCount = gameObjects.Count(g => g is Medkit && g.IsAlive);
            if (medkitCount == 0)
            {
                createMedkit();
            }
        }

        private void ShowEndForm(Image img)
        {
            gameLoop.Stop();
            EndForm endForm = new EndForm(img);
            DialogResult result = endForm.ShowDialog(GameForm);
            if (result == DialogResult.Yes)
            {
                level = 1;
                RestartGame();
            }
            if (result == DialogResult.No)
            {
                Application.Exit();
            }
        }

        private void RestartGame()
        {
            foreach (GameObject go in gameObjects)
            {
                GameForm.Controls.Remove(go.Sprite);
            }
            gameObjects.Clear();
            pendingAdd.Clear();

            Start();
        }

        private void HandleInput()
        {
            if (player.IsAlive)
            {
                if (inputManager.MoveLeft())
                    player.moveLeft(PlayerSpeed);

                if (inputManager.MoveRight())
                    player.moveRight(PlayerSpeed);

                if (inputManager.MoveUp())
                    player.moveUp(PlayerSpeed);

                if (inputManager.MoveDown())
                    player.moveDown(PlayerSpeed);

                if (inputManager.Fire())
                {
                    Bullet bullet = player.Fire(ZombieKiller.Properties.Resources.bullet);
                    pendingAdd.Add(bullet);
                }
            }
        }

        private void DetectCollisions()
        {
            collisionManager.CheckCollision(gameObjects);
        }

        private void RemoveDeadObjects()
        {
            var dead = gameObjects.Where(g => !g.IsAlive).ToList();
            foreach (var go in dead)
            {
                GameForm.Controls.Remove(go.Sprite);
                gameObjects.Remove(go);
            }
        }
    }
}