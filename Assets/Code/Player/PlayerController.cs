using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    enum PlayerState {Controllable, Dash};

    private PlayerControls controls;
    private Vector2 moveInput;
    private PlayerState state;


    private Vector2 lookInput;
    private Vector3 lookDirection;
    private float angleInput;
    private float inputDeadZone = 0.01f;
    public Transform pointer;
    private float turnTimeCount = 0.0f;
    private float dashTimeCount = 1.0f;
    private Vector3 dashDestination;
    private float lastAttackTime;


    //private bool flipped = false;

    [Header("Movement Settings")]
    [SerializeField] private MovementController movementController;
    [SerializeField] private PlayerStats stats;

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
    }
    private void Look()
    {
        if(pointer != null)
        {    
            if(lookInput.sqrMagnitude > inputDeadZone)
            {
                lookDirection = new Vector3(lookInput.x,lookInput.y,0);
                angleInput = Mathf.Atan2(lookInput.y,lookInput.x) * Mathf.Rad2Deg;
                turnTimeCount = 0.0f;
            }
            
            
            if (turnTimeCount < 0.95f){
                pointer.rotation = Quaternion.Slerp(pointer.rotation, Quaternion.Euler(0,0,angleInput), turnTimeCount);
                turnTimeCount += Time.fixedDeltaTime * stats.turnSpeed.value;
            }
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
        Debug.Log(Time.time - lastAttackTime);
        Debug.Log(60.0f/stats.atkSpeed.value);
        if(Time.time - lastAttackTime > (1.0f/stats.atkSpeed.value))
        {
            dashTimeCount = 0.0f;
            lastAttackTime = Time.time;
            state = PlayerState.Dash;
            dashDestination = transform.position + lookDirection.normalized * stats.dashDistance.value;
        }
    }
}
