using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _jaguar;
    [SerializeField] private GameObject _createdObject;
    [SerializeField] private GameObject _platform;

    private void Awake()
    {
        _createdObject = Instantiate(_jaguar, transform.position, Quaternion.identity);
        _createdObject.transform.parent = gameObject.transform;

        if (_createdObject.transform.position.y > -1.5f)
        {
            Vector3 platformposition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-1, gameObject.transform.position.z);
            GameObject _createdPlatform = Instantiate(_platform, platformposition, Quaternion.identity);
        }
    }
}
