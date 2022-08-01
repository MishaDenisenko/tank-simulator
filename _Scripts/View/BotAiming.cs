using System;
using System.Collections.Generic;
using _Scripts.Model;
using Model;
using UnityEngine;

namespace _Scripts.View {
    public class BotAiming : MonoBehaviour {
        [SerializeField] private int rayDistance;
        [SerializeField] private GameObject shooting;
        [SerializeField] private Bullet bullet;
        [SerializeField] private GameObject turretRottor;
        // [SerializeField] private GameObject point;
        // [SerializeField] private GameObject player;
        [SerializeField] private float height;
        [SerializeField] private float lambda;
        [SerializeField] private Tank tankType;
        private float _maxDistance;
        private Dictionary<List<Vector3>, bool> _turnsPoints ;
        private bool _isSpotted;
        private int _countOfRicochets;
        private int _currentCountOfRicochets;
        private float lookspeed = 8;
        private Vector3 target;
        private float timer = 1;
        private float currentTime = 0;
        private Shooting s;

        void Start() {
            _countOfRicochets = bullet.RicochetCount;
            _currentCountOfRicochets = 0;
            _turnsPoints = new Dictionary<List<Vector3>, bool>(); 
            target = new Vector3();
            s = shooting.GetComponent<Shooting>();
            lookspeed = tankType.TurretTraverceSpeed;
        }



        private int count = 0;
        private bool ok = true;
        void Update() {
            if (ok) {
                target = Vector3.zero;
                // _isSpotted = false;
                for (int i = 0; i < 360; i++) {
                    List<Vector3> points = new List<Vector3>();
                    bool isHited;
                    transform.rotation = Quaternion.AngleAxis(i, Vector3.up);
                    Vector3 direction = transform.forward;
                    Vector3 position = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
                    isHited = CalculteLaserTrajectory(position, direction, ref points);
                    _turnsPoints.Add(points, isHited);
                    // Debug.DrawRay(transform.position, direction, Color.magenta, rayDistance);
                    // points.Clear();
                    _currentCountOfRicochets = 0;
                }

                int minCountsOfTurns = _countOfRicochets + 1;
                foreach (var turnsPoint in _turnsPoints) {
                    
                    if (turnsPoint.Value && turnsPoint.Key.Count < minCountsOfTurns) {
                        target = turnsPoint.Key[0];
                        _isSpotted = true;
                        minCountsOfTurns = turnsPoint.Key.Count;
                    }
                }
                ok = false;
                _turnsPoints.Clear();
            }
            Quaternion targetRotation = Quaternion.LookRotation(target - turretRottor.transform.position);
            turretRottor.transform.rotation = Quaternion.Slerp(turretRottor.transform.rotation, targetRotation, lookspeed * Time.deltaTime);
            if (_isSpotted && turretRottor.transform.rotation.y <= targetRotation.y + lambda && turretRottor.transform.rotation.y >= targetRotation.y - lambda) {
                s.Shoot();
                _isSpotted = false;
            }
        }

        private void FixedUpdate() {
            if (currentTime >= timer && !ok) {
                currentTime = 0;
                ok = true;
            }
            else if (!ok){
                currentTime += 0.02f;
            }
            
        }

        private bool CalculteLaserTrajectory(Vector3 startPosition, Vector3 direction, ref List<Vector3> points) {
            if (_currentCountOfRicochets == _countOfRicochets) return false;
            
            RaycastHit hit;
            Ray ray = new Ray(startPosition, direction);
            _maxDistance = rayDistance;
            bool intersection = Physics.Raycast(ray, out hit, _maxDistance);

            if (intersection) {
                // Debug.DrawLine(startPosition, hit.point, Color.green, 10000);

                if (hit.collider.tag.Equals("Player")) {
                    points.Add(hit.point);
                    return true;
                }

                if (hit.collider.tag.Equals("Wall")) {
                    // Instantiate(point, hit.point, Quaternion.identity).SetActive(true);
                    points.Add(hit.point);
                    _currentCountOfRicochets++;
                    return CalculteLaserTrajectory(hit.point, Vector3.Reflect(direction, hit.normal), ref points);
                }
            }
            
            
            return false;

        }
    }
}