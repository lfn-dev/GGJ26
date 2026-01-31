using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerControls controls;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    [Header("Movement Settings")]
    [SerializeField] private MovementController movementController;
    [SerializeField] private CharacterStats stats;

    private void Awake()
    {
        // Initialize the PlayerControls instance
        controls = new PlayerControls();
        
        // Subscribe to the movement and jump actions
        controls.Player.Move.performed += ctx => moveInput = 
          ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = 
          Vector2.zero;
    }

    private void OnEnable()
    {
        // Enable the input controls
        controls.Enable();
    }

    private void OnDisable()
    {
        // Disable the input controls when the player object is disabled
        controls.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        movementController.Move(moveInput * stats.movSpeed.value);
    }
}
