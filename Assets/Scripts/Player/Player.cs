using UnityEngine;

[RequireComponent(typeof(InputComponent), typeof(MovementComponent), typeof(CollisionComponent))]
[RequireComponent(typeof(HealthComponent))]
public class Player : MonoBehaviour
{
    [SerializeField] MovementComponent movementComponent = null;
    [SerializeField] InputComponent inputComponent = null;
    [SerializeField] CollisionComponent collisionComponent = null;
    [SerializeField] HealthComponent healthComponent = null;

    [SerializeField] Transform groundCheckLeft = null;
    [SerializeField] Transform groundCheckRight = null;

    public MovementComponent MovementComponent => movementComponent;
    public InputComponent InputComponent => inputComponent;
    public CollisionComponent CollisionComponent => collisionComponent;
    public HealthComponent HealthComponent => healthComponent;
    public Transform GroundCheckLeft => groundCheckLeft;
    public Transform GroundCheckRight => groundCheckRight;

    private void Awake()
    {
        movementComponent = GetComponent<MovementComponent>();
        inputComponent = GetComponent<InputComponent>();
        collisionComponent = GetComponent<CollisionComponent>();
        healthComponent = GetComponent<HealthComponent>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
