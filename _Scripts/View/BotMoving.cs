using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

namespace _Scripts.View {
    public class BotMoving : MonoBehaviour {
        [SerializeField] private List<GameObject> points;
        [SerializeField] private float waitTime;
        private NavMeshAgent _agent;

        private IEnumerator _coroutine;
        // Start is called before the first frame update
        void Start() {
            _agent = GetComponent<NavMeshAgent>();
            _coroutine = MoveToPoint(waitTime);
            StartCoroutine(_coroutine);
            foreach (GameObject point in points) {
                if (point) point.SetActive(false);
            }
        }
        

        private IEnumerator MoveToPoint(float time) {
            while (true) {
                _agent.SetDestination(points[new Random().Next(points.Count)].transform.position);
                yield return new WaitForSeconds(time);
            }
        }
    }
}
