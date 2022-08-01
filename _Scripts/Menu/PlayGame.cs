using System.Collections;
using _Scripts.View;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Menu {
    public class PlayGame : MonoBehaviour {
        private Fading _fading;
        private void Start() {
            _fading = Camera.main.GetComponent<Fading>();
        }

        public void Play() {
            StartCoroutine(SceneLoader.LoadScene("Level1"));
        }

        
    }
}
