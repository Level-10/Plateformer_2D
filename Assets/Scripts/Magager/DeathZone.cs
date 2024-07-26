using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] Transform playerSpawn;
    [SerializeField] Animator fadeSystem;

    private void Awake()
    {
        playerSpawn = FindObjectOfType<PlayerSpawn>().transform;
        fadeSystem = 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            collision.transform.position = playerSpawn.position;
            //collision.transform.position = GameObject.FindGameObjectsWithTag("PlayerSpawn").transform.position;
        
        }
    }


}
