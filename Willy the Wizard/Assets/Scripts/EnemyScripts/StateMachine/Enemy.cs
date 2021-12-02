using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyFiniteStateMachine stateMachine;
    public D_Enemy enemyData;

    private Vector2 velocityWorkspace;
    public Animator EAnimator { get; private set; }
    public AnimationToStateMachine AnimToSM { get; private set; }
    public Core Core { get; private set; }

    [SerializeField] private Transform playerCheck;

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();
        
        EAnimator = GetComponent<Animator>();
        AnimToSM = GetComponent<AnimationToStateMachine>();

        stateMachine = new EnemyFiniteStateMachine();
    }

    public virtual void Update()
    {
        Core.LogicUpdate();
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    #region Check Functions
    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, 
        enemyData.minAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, 
        enemyData.maxAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, 
        enemyData.closeRangeActionDistance, enemyData.whatIsPlayer);
    }
    #endregion
    
    public virtual void OnDrawGizmos()
    {
        if (Core != null)
        {
            Gizmos.DrawLine(Core.CollisionSenses.WallCheck.position, Core.CollisionSenses.WallCheck.position + (Vector3)(Vector2.right * Core.Movement.FacingDir * enemyData.wallCheckDistance));
            Gizmos.DrawLine(Core.CollisionSenses.LedgeCheck.position, Core.CollisionSenses.LedgeCheck.position + (Vector3)(Vector2.down * enemyData.ledgeCheckDistance));
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * Core.Movement.FacingDir * enemyData.closeRangeActionDistance), 0.2f);
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * Core.Movement.FacingDir * enemyData.minAgroDistance), 0.2f);
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * Core.Movement.FacingDir * enemyData.maxAgroDistance), 0.2f);
        }
    }
}
