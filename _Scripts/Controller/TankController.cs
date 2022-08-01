
using System.Timers;
using _Scripts.Model;
using UnityEngine;

namespace _Scripts.Controller {
    public class TankController : Tank {
        public void GetDamage(int damage) {
            hitPoints -= damage;
            if (hitPoints < 0) {
                hitPoints = 0;
                isAlive = false;
            }
        }

        
    }
}