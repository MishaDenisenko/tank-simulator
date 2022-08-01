using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Menu {
    public class CameraMovement : MonoBehaviour {
        [SerializeField] private List<ParticleSystem> particleSystems;
        [SerializeField] private BezierCurves bezier;
        [SerializeField] private GameObject player;
        [SerializeField] private float speed;
        private bool _stop;
        private int _timer;
        private int _index;
        private Vector3[] _points;

        void Start() {
            for (int i = 0; i < particleSystems.Count; i++) {
                particleSystems[i].Play();
            }

            _points = bezier.bezierPath;
            transform.position = _points[0];
        }

        private void FixedUpdate() {
            if (!_stop) {
                if (_timer < 15) _timer++;

                if (_timer == 4) particleSystems[0].Pause();
                else if (_timer == 6) {
                    particleSystems[2].Pause();
                    particleSystems[3].Pause();
                }
                else if (_timer == 15) {
                    particleSystems[1].Pause();
                    _stop = true;
                }
            }
        }

        // Update is called once per frame
        void Update() {
            if (_index == _points.Length-1) _index = 0;
            Vector3 point = _points[_index];
            transform.position = Vector3.MoveTowards(transform.position, point, speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
            if (transform.position.Equals(point)) _index++;
        }
    }
}