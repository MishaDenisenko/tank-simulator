using Model;
using UnityEngine;

namespace _Scripts.Model {
    [CreateAssetMenu(fileName= "SimpleBullet", menuName = "Managers/SimpleBullet")]
    public sealed class SimpleBullet : Bullet{
        public SimpleBullet() {
            speed = 1f;
            maxForce = 10;
            ricochetCount = 3;
            damage = 100;
        }
    }
}