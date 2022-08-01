using System;
using UnityEngine;

namespace _Scripts.View {
    public class GunBlocker : MonoBehaviour {

        [SerializeField] private Transform bulletCreator;
        [SerializeField] private Vector3 backPosition;
        private Vector3 _forwardPosition;

        private void Start() {
            _forwardPosition = bulletCreator.localPosition;
        }

        private void OnTriggerEnter(Collider other) {
            if (other.tag.Equals("Wall")) bulletCreator.localPosition = backPosition;
        }
        private void OnTriggerExit(Collider other) {
            if (other.tag.Equals("Wall")) bulletCreator.localPosition = _forwardPosition;
        }
    }
}
