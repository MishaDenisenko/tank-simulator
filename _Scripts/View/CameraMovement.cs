using UnityEngine;

namespace _Scripts.View {
    public class CameraMovement : MonoBehaviour {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float speed;
        [Header("PlayerBox")]
        [SerializeField] private float rightEdge;
        [SerializeField] private float leftEdge;
        [SerializeField] private float topEdge;
        [SerializeField] private float bottomEdge;
        [Header("CameraBox")]
        [SerializeField] private float distance;
        [SerializeField] private float camraPositionY;
        [SerializeField] private float camRightEdge;
        [SerializeField] private float camLeftEdge;
        [SerializeField] private float camTopEdge;
        [SerializeField] private float camBottomEdge;
        private Vector3 _cameraPosition;
        private Vector3 _playerPosition;
    
        // Start is called before the first frame update
        void Start() {
            // _cameraPosition = transform.position;
            // print(_cameraPosition);
        }

        // Update is called once per frame
        void Update() {
            if (playerTransform) {
                _cameraPosition = transform.position;
                _playerPosition = playerTransform.position;
                if (_playerPosition.z <= leftEdge && _playerPosition.z >= rightEdge && _playerPosition.x >= bottomEdge && _playerPosition.x <= topEdge) {
                    Vector3 targetPosition = new Vector3(_playerPosition.x - distance, camraPositionY, _playerPosition.z);
                    transform.position = Vector3.Slerp(_cameraPosition, targetPosition, speed * Time.deltaTime);
                }
                else if (_playerPosition.z < rightEdge && _cameraPosition.x + distance > camTopEdge) {
                    Vector3 targetPosition = new Vector3(camTopEdge, camraPositionY, camRightEdge);
                    transform.position = Vector3.Slerp(_cameraPosition, targetPosition, speed * Time.deltaTime);
                }
                else if (_playerPosition.z < rightEdge && _cameraPosition.x + distance < camTopEdge) {
                    Vector3 targetPosition = new Vector3(_playerPosition.x - distance, camraPositionY, camRightEdge);
                    transform.position = Vector3.Slerp(_cameraPosition, targetPosition, speed * Time.deltaTime);
                }
                else if (_playerPosition.z > leftEdge && _cameraPosition.x + distance > camTopEdge) {
                    Vector3 targetPosition = new Vector3(camTopEdge, camraPositionY, camLeftEdge);
                    transform.position = Vector3.Slerp(_cameraPosition, targetPosition, speed * Time.deltaTime);
                }
                else if (_playerPosition.z > leftEdge && _cameraPosition.x + distance < camTopEdge) {
                    Vector3 targetPosition = new Vector3(_playerPosition.x - distance, camraPositionY, camLeftEdge);
                    transform.position = Vector3.Slerp(_cameraPosition, targetPosition, speed * Time.deltaTime);
                }
                else if (_playerPosition.z < rightEdge && _cameraPosition.x + distance < camBottomEdge) {
                    Vector3 targetPosition = new Vector3(camBottomEdge, camraPositionY, camRightEdge);
                    transform.position = Vector3.Slerp(_cameraPosition, targetPosition, speed * Time.deltaTime);
                }
                else if (_playerPosition.z < rightEdge && _cameraPosition.x + distance < camBottomEdge) {
                    Vector3 targetPosition = new Vector3(_playerPosition.x - distance, camraPositionY, camRightEdge);
                    transform.position = Vector3.Slerp(_cameraPosition, targetPosition, speed * Time.deltaTime);
                }
                else if (_playerPosition.z > leftEdge && _cameraPosition.x + distance > camBottomEdge) {
                    Vector3 targetPosition = new Vector3(camBottomEdge, camraPositionY, camLeftEdge);
                    transform.position = Vector3.Slerp(_cameraPosition, targetPosition, speed * Time.deltaTime);
                }
                else if (_playerPosition.z > leftEdge && _cameraPosition.x + distance < camBottomEdge) {
                    Vector3 targetPosition = new Vector3(_playerPosition.x - distance, camraPositionY, camLeftEdge);
                    transform.position = Vector3.Slerp(_cameraPosition, targetPosition, speed * Time.deltaTime);
                }
                else if (_playerPosition.x > topEdge) {
                    Vector3 targetPosition = new Vector3(camTopEdge, camraPositionY, _playerPosition.z);
                    transform.position = Vector3.Slerp(_cameraPosition, targetPosition, speed * Time.deltaTime);
                } 
                else if (_playerPosition.x < bottomEdge) {
                    Vector3 targetPosition = new Vector3(camBottomEdge, camraPositionY, _playerPosition.z);
                    transform.position = Vector3.Slerp(_cameraPosition, targetPosition, speed * Time.deltaTime);
                } 
            }
            
        }

    }
}
