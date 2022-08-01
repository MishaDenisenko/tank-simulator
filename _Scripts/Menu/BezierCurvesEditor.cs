#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace _Scripts.Menu {
    [CustomEditor(typeof(BezierCurves))]

    public class BezierCurvesEditor : Editor {

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            BezierCurves e = (BezierCurves)target;

            GUILayout.Space(15);
            if(GUILayout.Button("Add New"))
            {
                e.AddPoint();
            }
            GUILayout.Space(5);
            if(GUILayout.Button("Destroy Last"))
            {
                e.DestroyLast();
            }
            GUILayout.Space(5);
            if(GUILayout.Button("Clear All"))
            {
                e.ClearAll();
            }
        }
    }
}
#endif
