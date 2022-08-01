using System.Collections.Generic;
using _Scripts.Model;
using Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Hangar {
    public class TankPerformance : MonoBehaviour {
        [SerializeField] private TankViewController tankViewController;
        [SerializeField] private List<GameObject> performances;
        private Image[] _stripes;
        private TMP_Text[] _values;

        private Tank _tankModel;
        private Bullet _bulletType;
        // private GameObject _hp;
        // private GameObject _reload;
        // private GameObject _speed;
        // private GameObject _damage;
        // private GameObject _turretSpeed;
        // private GameObject _ricochetCount;
        void Awake() {
            _stripes = new Image[performances.Count];
            _values = new TMP_Text[performances.Count];

            for (int i = 0; i < performances.Count; i++) {
                _stripes[i] = performances[i].transform.GetChild(0).GetComponent<Image>();
                _values[i] = performances[i].transform.GetChild(1).GetComponent<TMP_Text>();
            }
        }

        public void ShowPerformances() {
            _tankModel = tankViewController.Tank.GetComponent<TankCharacteristics>().TankModel;
            _bulletType = tankViewController.Tank.GetComponent<TankCharacteristics>().BulletType;

            _values[0].text = _tankModel.HitPoints.ToString();
            _values[1].text = _tankModel.CoolDown.ToString();
            _values[2].text = (_tankModel.Speed / 2000).ToString();
            _values[3].text = (_tankModel.TurretTraverceSpeed * 2).ToString();
            _stripes[0].fillAmount = _tankModel.HitPoints / 1500f;
            _stripes[1].fillAmount = 0.5f / _tankModel.CoolDown;
            _stripes[2].fillAmount = _tankModel.Speed / 500000;
            _stripes[3].fillAmount = _tankModel.TurretTraverceSpeed / 20;

            _values[4].text = _bulletType.Damage.ToString();
            _values[5].text = _bulletType.RicochetCount.ToString();
            _stripes[4].fillAmount = _bulletType.Damage / 700f;
            _stripes[5].fillAmount = _bulletType.RicochetCount / 10f;
            

        }
    }
}
