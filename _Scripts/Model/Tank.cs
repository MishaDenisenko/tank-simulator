using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Model {
    public abstract class Tank : ScriptableObject {
        [SerializeField] protected int hitPoints;
        [SerializeField] protected float coolDown;
        [SerializeField] protected float speed;
        [SerializeField] protected float rotateVelocity;
        [SerializeField] protected float turretTraverceSpeed;

        public float TurretTraverceSpeed => turretTraverceSpeed;

        protected bool isAlive;

        public int HitPoints {
            get => hitPoints;
            set => hitPoints = value;
        }

        public float CoolDown => coolDown;

        public bool IsAlive() {
            return hitPoints > 0;
        }

        public float Speed => speed;

        public float RotateVelocity => rotateVelocity;
    }
}