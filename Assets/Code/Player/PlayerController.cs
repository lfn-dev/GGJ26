using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IDamageable
{

    enum PlayerState {Controllable, Dash};

    private PlayerControls controls;
    private Vector2 moveInput;
    private PlayerState state;
    private Camera mainCamera;


    private Vector2 lookInput;
    private Vector3 lookDirection;
    private float angleInput;
    public Transform pointer;
    private float turnTimeCount = 0.0f;
    private float dashTimeCount = 1.0f;
    private Vector3 dashDestination;
    private float lastAttackTime;


    //private bool flipped = false;

    [Header("Movement Settings")]
    [SerializeField] private MovementController movementController;
    [SerializeField] private PlayerStats stats;
    [SerializeField] private PlayerAnimationController playerAnimationController;

    private void Awake()
    {
        // Initialize the PlayerControls instance
        controls = new PlayerControls();
        
        // Subscribe to the movement and jump actions
        controls.Player.Move.performed += ctx => moveInput = 
          ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = 
          Vector2.zero;
        
        controls.Player.Look.performed += ctx => lookInput = 
          ctx.ReadValue<Vector2>();
        controls.Player.Look.canceled += ctx => lookInput = 
          Vector2.zero;

        controls.Player.Attack.performed += ctx => Attack();
    }

    private void Start()
    {
        mainCamera = Camera.main;

        angleInput = 0.0f;
        lastAttackTime = Time.time;
        dashDestination = transform.position;
        state = PlayerState.Controllable;
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

    private void Update()
    {
        if(state == PlayerState.Controllable) Move();
    }

    private void FixedUpdate()
    {
        Look();
        Dash();
    }

    private void Move()
    {
        movementController.Move(moveInput * stats.movSpeed.value);
        if(moveInput.x != 0f)
        {
            playerAnimationController.Flip(moveInput.x < 0f);            
        }
    }
    private void Look()
    {
        if (pointer == null) return;

        // 1. Pega a posição do mouse na tela (pixels)
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

        // 2. Converte para posição no mundo (World Space)
        // O 'z' é a distância da câmera até o plano do jogo (geralmente 10 ou -cam.z)
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, -mainCamera.transform.position.z));
        
        // Garante que estamos trabalhando em 2D (Z=0)
        mouseWorldPos.z = 0;

        // 3. Calcula o vetor direção: Destino (Mouse) - Origem (Player)
        Vector3 directionToMouse = (mouseWorldPos - transform.position).normalized;

        // Se o mouse estiver exatamente em cima do player, evita rotação maluca
        if (directionToMouse.sqrMagnitude > 0.001f)
        {
            lookDirection = directionToMouse;
            angleInput = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
            pointer.rotation = Quaternion.Euler(0, 0, angleInput);
        }
    }

    private void Dash()
    {
        if(dashTimeCount < 0.95f)
        {
            transform.position = Vector3.Lerp(transform.position, dashDestination, dashTimeCount);
            
            dashTimeCount += Time.deltaTime * stats.dashSpeed.value;
        }
        else
        {
            state = PlayerState.Controllable;
        }
    }

    private void Attack()
    {
        if(Time.time - lastAttackTime > (1.0f/stats.atkSpeed.value))
        {
            dashTimeCount = 0.0f;
            lastAttackTime = Time.time;
            state = PlayerState.Dash;
            dashDestination = transform.position + lookDirection.normalized * stats.dashDistance.value;
        }
    }

    public void DealDamage(int damageAmount)
    {
        if (state == PlayerState.Dash)
        {
            return;
        }

        stats.health.value -= damageAmount;
    }
}
