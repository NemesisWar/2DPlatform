using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] private int _directionX;
    [SerializeField] private int _speed = 7;
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] ContactFilter2D _contactFilter;
    private readonly RaycastHit2D[] _results = new RaycastHit2D[1];
    // Start is called before the first frame update


    // Update is called once per frame

    private void FixedUpdate()
    {
        var collisionCount = _rigidbody2D.Cast(new Vector2(_directionX, 0),_contactFilter, _results, 0.5f);
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
