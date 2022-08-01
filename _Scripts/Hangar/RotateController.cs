using System;
using _Scripts.Controller;
using UnityEngine;

namespace _Scripts.Hangar {
    public class RotateController : MonoBehaviour {
        [SerializeField] private TankViewController tankViewController;
        [SerializeField] private float speed;
        private Vector3 _targetPos;
        private GameObject _tank;

        private void Start() {
            // _tank = tankViewController.Tank;
        }

        private void Update() {
#if UNITY_ANDROID
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved) {
                    _targetPos = Camera.main.ScreenToWorldPoint(touch.position);
                }
            }
#endif

#if UNITY_EDITOR
            if (Input.GetMouseButton(0)) {
                _targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
#endif
            float step = speed * Time.deltaTime;

            Quaternion currentRotation = tankViewController.Tank.transform.rotation;
            
            tankViewController.Tank.transform.rotation = currentRotation * Quaternion.AngleAxis(step, Vector3.up);
        }
    }
}