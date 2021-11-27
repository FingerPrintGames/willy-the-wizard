using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyFiniteStateMachine stateMachine;
    public D_Enemy enemyData;

    private Vector2 velocityWorkspace;
    public int FacingDirection { get; private set; }
    public Rigidbody2D EBody { get; private set; }
    public Animator EAnimator { get; private set; }
    public GameObject AliveGO { get; private set; }
    public AnimationToStateMachine AnimToSM { get; private set; }

    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform playerCheck;

    public virtual void Start()
    {
        FacingDirection = 1;
        
        AliveGO = transform.Find("Alive").gameObject;
        EBody = AliveGO.GetComponent<Rigidbody2D>();
        EAnimator = AliveGO.GetComponent<Animator>();
        AnimToSM = AliveGO.GetComponent<AnimationToStateMachine>();

        stateMachine = new EnemyFiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(FacingDirection * velocity, EBody.velocity.y);
        EBody.velocity = velocityWorkspace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, AliveGO.transform.right, 
        enemyData.wallCheckDistance, enemyData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, 
        enemyData.ledgeCheckDistance, enemyData.whatIsGround);
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, AliveGO.transform.right, 
        enemyData.minAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, AliveGO.transform.right, 
        enemyData.maxAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, AliveGO.transform.right, 
        enemyData.closeRangeActionDistance, enemyData.whatIsPlayer);
    }

    public virtual void Flip()
    {
        FacingDirection *= -1;
        AliveGO.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * FacingDirection * enemyData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * enemyData.ledgeCheckDistance));
        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * FacingDirection * enemyData.closeRangeActionDistance), 0.2f);
        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * FacingDirection * enemyData.minAgroDistance), 0.2f);
        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * FacingDirection * enemyData.maxAgroDistance), 0.2f);
    }
}
