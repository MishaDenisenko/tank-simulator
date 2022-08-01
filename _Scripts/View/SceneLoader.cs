using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.View {
    public class SceneLoader {
        public static IEnumerator LoadScene(string sceneName) {
            float fadeTime = Fading.Fade(1);
            yield return new WaitForSeconds(fadeTime);
            SceneManager.LoadScene(sceneName);
        }
    }
}