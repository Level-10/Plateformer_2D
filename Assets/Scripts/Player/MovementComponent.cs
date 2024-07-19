using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class MovementComponent : ParentComponent
{
    [SerializeField] Rigidbody2D rb = null;

    [SerializeField] float moveSpeed = 10;
    [SerializeField] float jumpForce = 5;
    #region NoUse
    //[SerializeField] float deltaLerp = 5;
    [SerializeField] float moveSmoothTime = .05f;
    //[SerializeField] float maxSpeed = 5;
    [SerializeField] Vector3 currentVelocity = Vector3.zero;
    [SerializeField] Vector2 currentVelocity2 = Vector2.zero;
    #endregion NoUse

    [SerializeField] Animator animator = null;
    [SerializeField] SpriteRenderer spriteRenderer = null;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
    }

    private void FixedUpdate()
    {
        Move();
        Flip(rb.velocity.x);
    }

    public void Move()
    {
        float _moveDir = playerRef.InputComponent.InputMove.ReadValue<float>();
        float _horizontalMovement = _moveDir * moveSpeed * Time.deltaTime;

        //transform.position += transform.right * moveSpeed * Time.deltaTime * _moveDir;
        Vector3 _targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y); // Definir l'axe x et garder l'atuel y
        //rb.velocity = Vector3.SmoothDamp(rb.velocity, _targetVelocity, ref currentVelocity, moveSmoothTime);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, _targetVelocity, ref currentVelocity2, moveSmoothTime);

        // Use Abs to make something always positive
        float _characterVel = Mathf.Abs(rb.velocity.x);
        // Send velocity to animator
        animator.SetFloat("Speed", _characterVel);
    }

    public void Jump(InputAction.CallbackContext _context)
    {
        if (!playerRef.CollisionComponent.IsGrounded) return;
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up * 5, deltaLerp);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
