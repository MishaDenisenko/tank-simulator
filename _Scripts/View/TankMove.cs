using _Scripts.Model;
using UnityEngine;

namespace _Scripts.View {
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(DestroyObject))]
    public class TankMove : MonoBehaviour {
        private float _speed = 15f;
        private float _rotateVelocity = 100;

        private Rigidbody _rb;
        [SerializeField] private float maxForce = 10;

        [SerializeField] private Tank tank;

        private void Start() {
            _rb = GetComponent<Rigidbody>();
            _speed = tank.Speed;
            _rotateVelocity = tank.RotateVelocity;
        }

        void FixedUpdate() {
            if (gameObject.tag.Equals("Player")) {
#if UNITY_EDITOR
                if (Input.GetAxis("Vertical") != 0) Move();
                if (Input.GetAxis("Horizontal") != 0) Rotate();
                
// #elif 
#endif
                
                
            }
                
        }

        private void Move() {
            if (_rb.velocity.magnitude < maxForce)_rb.AddRelativeForce(Vector3.forward*Input.GetAxis("Vertical")*_speed, ForceMode.Impulse);
        }

        private void Rotate() {
            if (Input.GetAxis("Vertical") < 0) transform.Rotate(0f, -Input.GetAxis("Horizontal")*_rotateVelocity * Time.deltaTime, 0f, Space.Self);
            else transform.Rotate(0f, Input.GetAxis("Horizontal")*_rotateVelocity * Time.deltaTime, 0f, Space.Self);
        }

        public Tank Tank => tank;
    }
}
