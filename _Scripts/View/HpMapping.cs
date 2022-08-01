using System;
using _Scripts.Controller;
using UnityEngine;

namespace _Scripts.View {
    public class HpMapping : MonoBehaviour
    {
        [SerializeField] private GameObject tankModel;
        [SerializeField] private Color greenColor;
        [SerializeField] private Color yellowColor;
        [SerializeField] private Color redColor;
        
        [SerializeField] private int textSize = 14;
        [SerializeField] private Font textFont;
        private Color _textColor;
        [SerializeField] private float textY = 1.15f;
        [SerializeField] private float textX = 1.15f;
        [SerializeField] private float textZ = 1.15f;
        private Camera _camera;
        private int _heatPoints;
        private string _hp;
        private GameController _gameController;
        
        private TankController _tankController;

        public TankController TankController => _tankController;

        private void Awake() {
            _tankController = ScriptableObject.CreateInstance<TankController>();
        }

        void Start()
        {
            _camera = Camera.main;
            _tankController.HitPoints = tankModel.GetComponent<TankMove>().Tank.HitPoints;
            _heatPoints = _tankController.HitPoints;
            _gameController = GameObject.FindWithTag("Game Controller").GetComponent<GameController>();
        }

        void Update() {
            int currentHeatPoints = _tankController.HitPoints;
            _hp = "" + currentHeatPoints;
            if (currentHeatPoints == _heatPoints) _textColor = greenColor;
            else if (currentHeatPoints <= _heatPoints && currentHeatPoints > 10) _textColor = yellowColor;
            else if (currentHeatPoints <= 10 && currentHeatPoints > 0) _textColor = redColor;
            else if (!_tankController.IsAlive()) {
                tankModel.GetComponent<DestroyObject>().BlowUp();
                _gameController.DestroyTank(gameObject);
            }
        }
        
        private void OnGUI() {
            GUIStyle style = new GUIStyle();
            style.fontSize = textSize;
            style.richText = true;
            if(textFont) style.font = textFont;
            style.normal.textColor = _textColor;
            style.alignment = TextAnchor.MiddleCenter;

            Vector3 turretRottorPosition = transform.position;
            Vector3 worldPosition = new Vector3(turretRottorPosition.x + textX, turretRottorPosition.y + textY, turretRottorPosition.z + textZ);
            Vector3 screenPosition = _camera.WorldToScreenPoint(worldPosition);
            screenPosition.y = Screen.height - screenPosition.y;
            GUI.Label(new Rect (screenPosition.x, screenPosition.y, 0, 0), _hp, style);
        }

        public void Heat(int damage) {
            _tankController.GetDamage(damage);
        }
    }
}
