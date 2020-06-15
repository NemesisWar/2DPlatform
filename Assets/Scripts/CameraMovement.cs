using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _lookCameraPosition;
    [SerializeField] private Transform _camera;
    // Start is called before the first frame update
    void Start()
    {

        _lookCameraPosition = _camera.position - new Vector3(_player.position.x, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        _camera.position=_lookCameraPosition + new Vector3(_player.position.x, 0, 0);
    }
}
