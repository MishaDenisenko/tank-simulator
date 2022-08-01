
using System;
using System.Globalization;
using _Scripts.Controller;
using _Scripts.Model;
using TMPro;
using UnityEngine;

namespace _Scripts.View {
    public class Shooting : MonoBehaviour {
        [SerializeField] private GameObject bullet;
        [SerializeField] private int layerValue;
        [SerializeField] private GameObject shootEffect;
        [SerializeField] private GameObject tankModel;
        [SerializeField] private Color greenColor;
        [SerializeField] private Color redColor;
        [SerializeField] private Color emission;
        
        [SerializeField] private int textSize = 14;
        [SerializeField] private Font textFont;
        private Color _textColor;
        [SerializeField] private float textY = 1.15f;
        [SerializeField] private float textX = 1.15f;
        [SerializeField] private float textZ = 1.15f;
        [SerializeField] private GunRecoil gunRecoil;
        // public bool showShadow = true;
        // public Color shadowColor = new Color(0, 0, 0, 0.5f);
        // public Vector2 shadowOffset = new Vector2(1,1);
        private Camera _camera;
        private bool _canShoot;
        private float _cooldown;
        private float _currentCooldown;
        private string _lable;
        
        private TankController _tankController;
        

        private void Start() {
            _tankController = ScriptableObject.CreateInstance<TankController>();
            _cooldown = tankModel.GetComponent<TankMove>().Tank.CoolDown;
            _currentCooldown = 0;
            _camera = Camera.main;
            _canShoot = true;
            _lable = "" + _currentCooldown;
        }


        private void Update() {
            if (Input.GetButtonDown("Fire1") && tag.Equals("Player")) {
                Shoot();
            }
        }

        private void FixedUpdate() {
            if (_currentCooldown < _cooldown) {
                _currentCooldown += 0.02f;
                _textColor = redColor;
                _lable = _currentCooldown > 0 ? ("" + Math.Round(_currentCooldown, 2)).Replace(",", ".") : "0";
                _canShoot = false;
            }
            else {
                _textColor = greenColor;
                _canShoot = true;
                _lable = "" + _cooldown;
            }
            
            if (_lable.Length == 3) _lable += "0";
            else if (_lable.Length == 1) _lable += ".00";
            
        }

        public void Shoot() {
            
            if (_canShoot) {
                Transform tr = transform;
                GameObject newBullet = Instantiate(bullet, tr.position, tr.rotation);   
                newBullet.layer = layerValue;
                for (int i = 0; i < 2; i++) {
                    Material material = newBullet.transform.GetChild(i).GetComponent<Renderer>().material;
                    material.SetColor(Shader.PropertyToID("_EmissionColor"), emission);
                }

                if (gunRecoil) gunRecoil.DoRecoil = true;
                newBullet.GetComponentInChildren<Light>().color = emission;
                Instantiate(shootEffect, newBullet.transform.position, Quaternion.identity);
                _currentCooldown = 0;
            }
            
        }

        private void OnGUI() {
            GUIStyle style = new GUIStyle();
            style.fontSize = textSize;
            style.richText = true;
            if(textFont) style.font = textFont;
            style.normal.textColor = _textColor;
            style.alignment = TextAnchor.MiddleCenter;

            Vector3 turretRottorPosition = transform.parent.parent.position;
            Vector3 worldPosition = new Vector3(turretRottorPosition.x + textX, turretRottorPosition.y + textY, turretRottorPosition.z + textZ);
            Vector3 screenPosition = _camera.WorldToScreenPoint(worldPosition);
            screenPosition.y = Screen.height - screenPosition.y;
            GUI.Label(new Rect (screenPosition.x, screenPosition.y, 0, 0), _lable, style);
        }
    }
}
