using UnityEngine;

namespace _Scripts.Model {
    [CreateAssetMenu(fileName= "EnemyTank", menuName = "Managers/EnemyTank")]
    public class EnemyTank : Tank{
        public EnemyTank() {
            hitPoints = 500;
            coolDown = 5;
            speed = 100000;
            rotateVelocity = 100;
            turretTraverceSpeed = 8;
        }
    }
}