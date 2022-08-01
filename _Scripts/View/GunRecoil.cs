using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRecoil : MonoBehaviour {
    [SerializeField] private Vector3 backPosition;
    [SerializeField] private float recoilSpeed;
    [SerializeField] private Coord recoilCoord;
    
    private enum Coord {
        X,
        Y,
        Z
    }

    private Vector3 _startPosition;
    private bool _recoiled;

    private void Start() {
        _startPosition = transform.localPosition;
    }

    public bool DoRecoil { get; set; }

    private void Update() {
        if (DoRecoil) Recoil();
    }

    public void Recoil() {
        switch (recoilCoord) {
            case Coord.X: 
                if (!_recoiled) {
                    if (transform.localPosition.x < backPosition.x) transform.Translate(Vector3.right * Time.deltaTime * recoilSpeed);
                    else if (transform.localPosition.x >= backPosition.z) _recoiled = true; 
                }
                else {
                    if (transform.localPosition.x > _startPosition.x) transform.Translate(Vector3.left * Time.deltaTime * recoilSpeed);
                    else if (transform.position.x <= _startPosition.x) {
                        transform.localPosition = _startPosition;
                        _recoiled = false;
                        DoRecoil = false;
                    } 
                }
                break;
            case Coord.Y: 
                if (transform.localPosition.y > backPosition.y) transform.Translate(Vector3.down*Time.deltaTime*recoilSpeed);
                else if (transform.localPosition.y < _startPosition.y) transform.Translate(Vector3.up*Time.deltaTime*recoilSpeed);
                else if (transform.localPosition.y > _startPosition.y) {
                    transform.position = _startPosition;
                    DoRecoil = false;
                }
                break;
            case Coord.Z:
                if (!_recoiled) {
                    if (transform.localPosition.z > backPosition.z) transform.Translate(Vector3.back * Time.deltaTime * recoilSpeed);
                    else if (transform.localPosition.z <= backPosition.z) _recoiled = true; 
                }
                else {
                    if (transform.localPosition.z < _startPosition.z) transform.Translate(Vector3.forward * Time.deltaTime * recoilSpeed);
                    else if (transform.position.z >= _startPosition.z) {
                        transform.localPosition = _startPosition;
                        _recoiled = false;
                        DoRecoil = false;
                    } 
                }
                break;
        }
        
    }
}
