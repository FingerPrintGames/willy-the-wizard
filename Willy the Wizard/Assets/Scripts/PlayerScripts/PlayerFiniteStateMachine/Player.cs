using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public PlayerInputManager InputManager { get; private set; }
    public Rigidbody2D Body { get; private set; }
    [SerializeField] private PlayerData playerData;
    #endregion

    #region Other Variables
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDir { get; private set; }
    private Vector2 workspace;
    #endregion

    #region Unity Callback Functions
    public void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        RunState = new PlayerRunState(this, StateMachine, playerData, "running");
    }

    public void Start()
    {
        Anim = GetComponent<Animator>();
        InputManager = GetComponent<PlayerInputManager>();
        Body = GetComponent<Rigidbody2D>();
        FacingDir = 1;

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = Body.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Set Functions
    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        Body.velocity = workspace;
        CurrentVelocity = workspace;
    }
    #endregion

    #region Check Functions
    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDir)
            Flip();
    }
    #endregion

    #region Other Functions
    private void Flip()
    {
        FacingDir *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    #endregion
}
