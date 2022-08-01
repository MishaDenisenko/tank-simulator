using System;
using _Scripts.Controller;
using Model;
using UnityEngine;

namespace _Scripts.View {
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(DestroyObject))]
    public class BulletFlight : MonoBehaviour {
        public Bullet bullet;
        private Rigidbody _rb;
        private float _maxForce;
        private float _speed;
        private int _damage;
        private BulletController _controller;

        private void Start() {
            _rb = GetComponent<Rigidbody>();
            _speed = bullet.Speed;
            _maxForce = bullet.MaxForce;
            _controller = ScriptableObject.CreateInstance<BulletController>();
            _controller.RicochetCount = bullet.RicochetCount;
            _damage = bullet.Damage;
            
            Physics.IgnoreLayerCollision(8, 3);
            Physics.IgnoreLayerCollision(9, 6); 
            Physics.IgnoreLayerCollision(9, 8); 
            Physics.IgnoreLayerCollision(9, 9); 
            Physics.IgnoreLayerCollision(8, 8); 
        }

        private void FixedUpdate() {
            if (_rb.velocity.magnitude < _maxForce) _rb.velocity = _speed * transform.forward;
        
            Debug.DrawRay(transform.position, transform.forward, Color.red, 1);
        }

        private void OnCollisionEnter(Collision collision) {
            // if (collision.collider.tag.Equals("Gun")) Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
            if (collision.collider.tag.Equals("Enemy") || collision.collider.tag.Equals("Player")) {
                collision.gameObject.GetComponent<HpMapping>().Heat(_damage);
                GetComponent<DestroyObject>().BlowUp();
            }
            else if (collision.collider.tag.Equals("Wall")) {
                if (!_controller.RicochetDecrement()) GetComponent<DestroyObject>().BlowUp();
                var dir = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
                transform.rotation = Quaternion.LookRotation(dir);
            }
        }

        private void OnTriggerEnter(Collider other) {
            if (other.tag.Equals("Enemy") || other.tag.Equals("Player")) {
                other.gameObject.GetComponent<HpMapping>().Heat(_damage);
                GetComponent<DestroyObject>().BlowUp();
            }
        }
    }
}
