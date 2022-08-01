using System;
using System.Collections.Generic;
using _Scripts.View;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace _Scripts.Controller {
    public class GameController : MonoBehaviour {
        [SerializeField] private List<GameObject> enemies;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject info;
        [SerializeField] private float infoPosition;
        [SerializeField] private float starsPosition;
        [SerializeField] private float speedInfo;
        [SerializeField] private float lambda;
        [SerializeField] private GameObject stars;
        [SerializeField] private Sprite filledStar;
        [SerializeField] private Sprite emptyStar;
        private GameObject[] _starsImages;
        private GameObject _textInfo;
        private enum GameMode {
            Victori,
            Lose,
            Action,
            Completed
        }

        private GameMode _gameMode;
        void Start() {
            _gameMode = GameMode.Action;
            _starsImages = new GameObject[stars.transform.childCount];
            for (int i = 0; i < stars.transform.childCount; i++) {
                _starsImages[i] = stars.transform.GetChild(i).gameObject;
            }
            _textInfo = info.transform.GetChild(0).gameObject;
        }

        private void Update() {
            if (_gameMode == GameMode.Lose) {
                MoveInfo("You Lose");
            }
            else if (_gameMode == GameMode.Victori) {
                MoveInfo("You Win");
                
            };
        }

        private void MoveInfo(string text) {
            _textInfo.GetComponent<TMP_Text>().text = text;
            
            Vector3 currentInfoPosition = _textInfo.transform.localPosition;
            Vector3 currentStarsPosition = stars.transform.localPosition;
            if (currentInfoPosition.x > infoPosition) {
                Vector3 targetPosition = new Vector3(infoPosition, currentInfoPosition.y, currentInfoPosition.z);
                _textInfo.transform.localPosition = Vector3.Lerp(currentInfoPosition, targetPosition, speedInfo * Time.deltaTime);
                // info.transform.Translate(Vector3.left * speedInfo * Time.deltaTime, Space.Self);
            }
            if (currentStarsPosition.y < starsPosition) {
                Vector3 targetPosition = new Vector3(currentStarsPosition.x, starsPosition, currentStarsPosition.z);
                stars.transform.localPosition = Vector3.Lerp(currentStarsPosition, targetPosition, speedInfo * Time.deltaTime);
                // stars.transform.Translate(Vector3.up * speedInfo * Time.deltaTime, Space.Self);
            }
            else if (currentInfoPosition.x <= infoPosition + lambda && currentStarsPosition.y >= starsPosition - lambda) {
                _gameMode = GameMode.Completed;
            }
        }

        private void CheckGameMode() {
            if (enemies.Count == 0) _gameMode = GameMode.Victori;
        }

        private void SetStars(int count) {
            print(count);

            for (int i = 0; i < count; i++) {
                _starsImages[i].GetComponent<Image>().sprite = filledStar;
            }

            if (count < _starsImages.Length) {
                for (int i = count; i < _starsImages.Length; i++) {
                    _starsImages[i].GetComponent<Image>().sprite = emptyStar;
                }
            }
            
        }

        public void DestroyTank(GameObject tank) {
            if (tank.layer == 3) {
                _gameMode = GameMode.Lose;
                SetStars(0);
            }
            else if (tank.layer == 6) {
                enemies.Remove(tank);
                CheckGameMode();
                SetStars(player.GetComponent<HpMapping>().TankController.HitPoints/100);
            }
        }
    }
}
