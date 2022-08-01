using UnityEngine;

namespace _Scripts.View {
    public class Fading : MonoBehaviour{
        public Texture2D fading;
        private static float _fadeSpeed = 0.8f;
        private int _drawDepth = -1000;
        public float alpha = 1f;
        private static sbyte _fadeDir = -1;

        private void OnGUI() {
            alpha += _fadeDir * _fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
            GUI.depth = _drawDepth;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fading);
        }

        public static float Fade(sbyte dir) {
            _fadeDir = dir;
            return _fadeSpeed;
        }
    }
}