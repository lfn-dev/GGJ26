using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IDamageable
{

    public enum PlayerState {Controllable, Dashing, Shooting};
    public enum PlayerMood {Happy, Sad};

    [SerializeField]
    private PlayerMood currentPlayerMood;

    private PlayerControls controls;
    private Vector2 moveInput;
    private Camera mainCamera;


    private Vector2 lookInput;
    private Vector3 lookDirection;
    private float angleInput;
    
    public Transform pointer;
    private float dashTimeCount = 1.0f;
    private Vector3 dashDestination;
    private float lastAttackTime;


    //private bool flipped = false;

    [Header("Movement Settings")]
    [SerializeField] private MovementController movementController;
    [SerializeField] private PlayerStats stats;
    [SerializeField] private PlayerAnimationController playerAnimationController;
    [SerializeField] private PlayerDash playerDash = null;
    [SerializeField] private PlayerShooter playerShooter;
    [SerializeField] private EventRaiser OnGameOver;
    [SerializeField] private AudioChannelTransmissor damageAudioChannel;

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
        stats.health.value = stats.initialHealth;
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
        if(getState() == PlayerState.Controllable) Move();
    }

    private void FixedUpdate()
    {
        Look();
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
            angleInput = (Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg) - 90f;
            pointer.rotation = Quaternion.Euler(0, 0, angleInput);
        }
    }

    private void Attack()
    {
        switch (currentPlayerMood)
        {
            case PlayerMood.Sad:
                playerDash.Dash(lookDirection);
                break;
            case PlayerMood.Happy:
                playerShooter.Shoot(pointer.position, pointer.rotation);
                break;
            default:
                Debug.LogWarning($"PlayerMood '{currentPlayerMood}' não tem ataques associados.");
                break;
        }
    }

    public PlayerState getState()
    {
        return playerDash != null && playerDash.isDashing ? PlayerState.Dashing : PlayerState.Controllable;  
    }

    public void DealDamage(int damageAmount)
    {
        if (getState() == PlayerState.Dashing)
        {
            return;
        }

        stats.health.value -= damageAmount;
        damageAudioChannel.PlaySound("player_damage");

        if(stats.health.value <= 0)
        {
            OnGameOver.RaiseEvent();
        }
    }

    public void SwapMood()
    {
        if (currentPlayerMood == PlayerMood.Sad)
            currentPlayerMood = PlayerMood.Happy;
        else
            currentPlayerMood = PlayerMood.Sad;
    }
}
