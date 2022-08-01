using UnityEngine;

namespace _Scripts.Menu {
    public class BezierCurvesComponent : MonoBehaviour {

        public Transform adjustPoint, endPoint, adjustMirror;
        public Color color = Color.white;
        public float scale = 1;

        void OnDrawGizmos()
        {
            Gizmos.color = color;
            Gizmos.DrawCube(transform.position, Vector3.one * scale);
        }
    }
}
