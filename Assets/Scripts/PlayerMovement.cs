using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    public float MinGroundNormalY = .65f;
    [SerializeField] private float _gravityModifier = 0.1f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _powerJump = 4f;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private Vector2 _movement;
    protected Vector2 groundNormal;
    public LayerMask LayerMask;
    [SerializeField] private Vector2 _targerVelocity;
    [SerializeField] private float _velocity;
    private bool _transformRight;
    protected ContactFilter2D contactFilter;
    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;
    private RaycastHit2D[] _hitbuffer = new RaycastHit2D[5];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(5);
    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(LayerMask);
        contactFilter.useLayerMask = true;
    }

    // Update is called once per frame
    private void Update()
    {

        _targerVelocity.x = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            _movement.y = _powerJump * Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        _movement += _gravityModifier * Physics2D.gravity * Time.deltaTime;
        _movement.x = _targerVelocity.x;

        Vector2 deltaPosition = _movement * Time.deltaTime;
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x;
        _transformRight = deltaPosition.x > 0;
        Movement(move, false, _transformRight);

    }

    private void Movement(Vector2 move, bool yMovement, bool transformRight)
    {
        float distance = move.magnitude;
        if (distance > minMoveDistance)
        {
            int count = _rigidbody2D.Cast(move, contactFilter, _hitbuffer, distance * shellRadius);
            hitBufferList.Clear();

            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(_hitbuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentnormal = hitBufferList[i].normal;
                if (currentnormal.y > MinGroundNormalY)
                {
                    _isGrounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentnormal;
                        currentnormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(_movement, currentnormal);
                if (projection < 0)
                {
                    _movement = _movement - projection * currentnormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }

        }
        _spriteRenderer.flipX = transformRight;
        _rigidbody2D.position = _rigidbody2D.position * move.normalized * distance;
    }
}
