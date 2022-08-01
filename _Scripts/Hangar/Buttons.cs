using System;
using _Scripts.View;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Hangar {
    public class Buttons : MonoBehaviour {
        [SerializeField] private TankViewController tankViewController;
        [SerializeField] private GameObject caseButton;

        
        public void NextButton() {
            tankViewController.ChengeNumber();
            tankViewController.ShowTank();
        }
        
        public void PreviousButton() {
            tankViewController.ChengeNumber(false);
            tankViewController.ShowTank();
        }

        public void ChangeCase() {
            ViewCase.ViewEnum = (int) ViewCase.ViewEnum == 1 ? ViewEnum.EnemyTanks : ViewEnum.SelfTanks;
            if ((int) ViewCase.ViewEnum == 1) caseButton.GetComponentInChildren<Text>().text = "SELF";
            else if ((int) ViewCase.ViewEnum == -1) caseButton.GetComponentInChildren<Text>().text = "ENEMY";
            tankViewController.ShowTank(true);
        }

        public void EnterMenu() {
            StartCoroutine(SceneLoader.LoadScene("Menu"));
        }
    }
}
