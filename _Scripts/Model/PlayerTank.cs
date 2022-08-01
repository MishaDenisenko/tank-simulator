using UnityEngine;

namespace _Scripts.Model {
    [CreateAssetMenu(fileName= "PlayerTank", menuName = "Managers/PlayerTank")]
    
    public class PlayerTank : Tank{
        
        public PlayerTank() {
            hitPoints = 300;
            coolDown = 1;
            speed = 100000;
            rotateVelocity = 100;
            turretTraverceSpeed = 10;
        }
    }
}