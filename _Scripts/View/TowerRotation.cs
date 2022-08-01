using System;
using _Scripts.Model;
using UnityEngine;

namespace _Scripts.View {
    public class TowerRotation : MonoBehaviour {
        private Camera _camera;

        [SerializeField] private float lookspeed;
        [SerializeField] private Tank tankType;

        private void Start() {
            _camera = Camera.main;
            lookspeed = tankType.TurretTraverceSpeed;
        }

        private void Update() {
            LookOnCursor();
        }

        void LookOnCursor() {		
            Plane playerPlane = new Plane(Vector3.up, transform.position);
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            float hitdist;
            if (playerPlane.Raycast(ray, out hitdist)) {
                Vector3 targetPoint = ray.GetPoint(hitdist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookspeed * Time.deltaTime);
            }
        }

        // private void OnCollisionEnter(Collision collision) {
        //     if (collision.collider.tag.Equals("Wall")) _inWall = true;
        // }
        // private void OnCollisionExit(Collision collision) {
        //     if (collision.collider.tag.Equals("Wall")) _inWall = false;
        // }
        //
        // private void OnTriggerEnter(Collider other) {
        //     if (other.tag.Equals("Wall")) _inWall = true;
        // }
        // private void OnTriggerExit(Collider other) {
        //     if (other.tag.Equals("Wall")) _inWall = false;
        // }
    }
}