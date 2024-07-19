using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeakSpot))]

public class Enemy_Snake: MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer = null;

    [SerializeField] float moveSpeed = 2;
    [SerializeField] float minDistAllowed = 0.3f;
    [SerializeField] int collisionDamage = 20;
    [SerializeField] List<Transform> waypoints = new List<Transform>();

    [SerializeField] Transform target;
    [SerializeField] int destPoint = 0;

    void Start()
    {
        Init();
    }

    void Update()
    {
        CheckWaypointReached();
    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.transform.CompareTag("Player"))
        {
            Player _player = _collision.transform.GetComponent<Player>();
            _player.HealthComponent.AddHealth(-collisionDamage);
        }
    }

    void Init()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        target = waypoints[0];
        spriteRenderer.flipX = true;
    }

    void CheckWaypointReached()
    {
        Vector3 _dir = target.position - transform.position;
        transform.Translate(_dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        // Enemy has reached target point 
        if (Vector3.Distance(transform.position, target.position) < minDistAllowed)
        {
            destPoint = (destPoint + 1) % waypoints.Count; // Modulo for always stay in list
            target = waypoints[destPoint];
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }


}
