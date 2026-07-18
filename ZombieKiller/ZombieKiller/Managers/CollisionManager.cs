using System.Collections.Generic;
using ZombieKiller.GameObjects;
using ZombieKiller.Interfaces;

namespace ZombieKiller.Managers
{
    internal class CollisionManager
    {
        public void CheckCollision(GameObject a, GameObject b)
        {
            if (a.Bounds.IntersectsWith(b.Bounds))
            {
                if (a is ICollidable ca) ca.onCollision(b);
                if (b is ICollidable cb) cb.onCollision(a);
            }
        }

        public void CheckCollision(List<GameObject> objects)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                for (int j = i + 1; j < objects.Count; j++)
                {
                    var a = objects[i];
                    var b = objects[j];

                    if ((a is Bullet && b is Player) || (a is Player && b is Bullet))
                        continue;

                    if ((a is Medkit && b is Bullet) || (a is Bullet && b is Medkit))
                        continue;

                    if ((a is Medkit && b is Enemy) || (a is Enemy && b is Medkit))
                        continue;

                    if (a.IsAlive && b.IsAlive)
                        CheckCollision(a, b);
                }
            }
        }
    }
}