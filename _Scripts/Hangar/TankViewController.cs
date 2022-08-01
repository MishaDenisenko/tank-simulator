using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _Scripts.Hangar {
    public class TankViewController : MonoBehaviour {
        [SerializeField] private GameObject tankLabel;
        [SerializeField] private GameObject tankPeformance;
        [Header("PlayerTanks")] 
        [SerializeField] private List<GameObject> playerTanks;
        [Header("EnemyTanks")] 
        [SerializeField] private List<GameObject> enemyTanks;
        
        
        private int _number;
        private TMP_Text _text; 
        private int _playerCount; 
        private int _enemyCount; 

        public GameObject Tank { get; set; }

        private void Awake() {
            Tank = playerTanks[0];
        }

        private void Start() {
            _text = tankLabel.GetComponent<TMP_Text>();
            _playerCount = playerTanks.Count;
            _enemyCount = enemyTanks.Count;
            ShowTank();
        }


        public void ChengeNumber(bool inc = true) {
            switch (ViewCase.ViewEnum) {
                case ViewEnum.SelfTanks:
                    _number = inc ? ++_number : --_number;

                    if (_number == _playerCount || _number < 0) _number = 0;
                    break;
                case ViewEnum.EnemyTanks:
                    _number = inc ? ++_number : --_number;

                    if (_number == _enemyCount || _number < 0) _number = 0;
                    break;
            }
        }


        private void SetTank(bool changeCase = false) {
            if (changeCase) _number = 0;
            if (ViewCase.ViewEnum == ViewEnum.SelfTanks) Tank = playerTanks[_number];
            else if (ViewCase.ViewEnum == ViewEnum.EnemyTanks) Tank = enemyTanks[_number];
        }

        public void ShowTank(bool changeCase = false) {
            SetTank(changeCase);
            tankPeformance.GetComponent<TankPerformance>().ShowPerformances();
            foreach (GameObject tank in playerTanks) {
                tank.SetActive(false);
            }
            foreach (GameObject tank in enemyTanks) {
                tank.SetActive(false);
            }
            Tank.SetActive(true);
            _text.text = Tank.name;
        }
    }
}