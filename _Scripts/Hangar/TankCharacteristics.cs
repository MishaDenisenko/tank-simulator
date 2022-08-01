using _Scripts.Model;
using Model;
using UnityEngine;

namespace _Scripts.Hangar {
    public class TankCharacteristics : MonoBehaviour {
        [SerializeField] private Tank tankModel;
        [SerializeField] private Bullet bulletType;

        public Tank TankModel => tankModel;

        public Bullet BulletType => bulletType;
    }
}
