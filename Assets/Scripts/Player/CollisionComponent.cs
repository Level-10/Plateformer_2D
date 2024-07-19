using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionComponent : ParentComponent
{
    [SerializeField] bool isGrounded = false;
    [SerializeField] float rcGround = 1;

    [SerializeField] RaycastHit2D hit;

    #region Tuto
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = .2f;
    [SerializeField] LayerMask collisionLayer;
    #endregion Tuto

    public bool IsGrounded => isGrounded;
    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);
    }

    private void FixedUpdate()
    {
        //IsOnGround();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*//Ground _ground = collision.GetComponent<Ground>();
        //if (_ground) fallingSpeed = 0;*/

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*//Ground _ground = collision.GetComponent<Ground>();
        //if (_ground) fallingSpeed = initFallingSpeed;*/
    }

    void IsOnGround()
    {
        //isGrounded = Physics2D.OverlapArea(playerRef.GroundCheckLeft.position, playerRef.GroundCheckRight.position);

        hit = Physics2D.Raycast(transform.position, -transform.up, rcGround);

        if (hit) Debug.Log($"Distance {hit.distance}");
        if (hit) Debug.Log($"Distance {hit.rigidbody}");
        
        
    }

    private void OnDrawGizmos()
    {
        /*Debug.DrawLine(transform.position , -Vector2.up, Color.blue);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, -transform.up);*/
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
