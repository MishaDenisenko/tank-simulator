using UnityEngine;

namespace _Scripts.View {
    [CreateAssetMenu(fileName= "TestWallNormal", menuName = "Managers/TestWallNormal")]
    public class TestWallNormal : ScriptableObject {

        public Vector3 normal { set; get; }
        public Vector3 point { set; get; }
        void Update()
        {
            if (normal != Vector3.zero) Debug.DrawRay(point, normal, Color.blue, 100);
        }
    }
}
