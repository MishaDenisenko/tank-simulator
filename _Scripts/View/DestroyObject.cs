using UnityEngine;

namespace _Scripts.View {
    public class DestroyObject : MonoBehaviour {
        [SerializeField] private GameObject exploseonEffect;

        public void BlowUp() {
            Instantiate(exploseonEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
