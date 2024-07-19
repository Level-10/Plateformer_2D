using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer = null;

    [SerializeField] float moveSpeed = 2;
    [SerializeField] float minDistAllowed = 0.3f;
    [SerializeField] List<Transform> waypoints = new List<Transform>();

    [SerializeField] Transform target;
    [SerializeField] int destPoint = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        target = waypoints[0];
        spriteRenderer.flipX = true;
    }

    void Update()
    {
        Vector3 _dir = target.position - transform.position;
        transform.Translate(_dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        // Enemy has reached target point 
        if(Vector3.Distance(transform.position, target.position) < minDistAllowed)
        {
            destPoint = (destPoint + 1) % waypoints.Count; // Modulo for always stay in list
            target = waypoints[destPoint];
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}
