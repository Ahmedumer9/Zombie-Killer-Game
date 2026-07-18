using ZombieKiller.GameObjects;

namespace ZombieKiller.Interfaces
{
    internal interface ICollidable
    {
        void onCollision(GameObject g);
    }
}