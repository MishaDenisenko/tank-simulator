using UnityEngine;

namespace Model {
    public abstract class Bullet : ScriptableObject{
        [SerializeField] protected float speed;
        [SerializeField] protected float maxForce;
        [SerializeField] protected int ricochetCount;
        [SerializeField] protected int damage;

        public float Speed => speed;

        public float MaxForce => maxForce;

        public int RicochetCount {
            get => ricochetCount;
            set => ricochetCount = value;
        }

        public int Damage => damage;
    }
}
