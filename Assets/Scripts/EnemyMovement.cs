using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int _directionX;
    [SerializeField] private int _speed = 7;
    [SerializeField] ContactFilter2D _contactFilter;
    private Rigidbody2D _rigidbody2D;
    private float _distanceCast = 0.5f;
    private readonly RaycastHit2D[] _results = new RaycastHit2D[1];

    private void OnEnable()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        var collisionCount = _rigidbody2D.Cast(new Vector2(_directionX, 0),_contactFilter, _results,_distanceCast);
        if(collisionCount == 0)
        {
            transform.position += new Vector3(_directionX * _speed, 0, 0) * Time.deltaTime;
        }
        else
        {
            _directionX *= -1;
        }
    }
}
