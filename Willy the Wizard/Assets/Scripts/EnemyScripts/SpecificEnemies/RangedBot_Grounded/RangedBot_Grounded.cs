using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBot_Grounded : Enemy
{
    public RangedBot_Grounded_IdleState IdleState { get; private set; }
    public RangedBot_Grounded_MoveState MoveState { get; private set; }
    public RangedBot_Grounded_PlayerDetectedState PlayerDetectedState { get; private set; }
    public RangedBot_Grounded_ChargeState ChargeState { get; private set; }
    public RangedBot_Grounded_LookForPlayerState LookForPlayerState { get; private set; }
    public RangedBot_Grounded_MeleeAttackState MeleeAttackState { get; private set; }
    
    [SerializeField] private D_EnemyIdle idleStateData;
    [SerializeField] private D_EnemyMove moveStateData;
    [SerializeField] private D_PlayerDetected playerDetectedStateData;
    [SerializeField] private D_EnemyCharge enemyChargeStateData;
    [SerializeField] private D_LookForPlayer lookForPlayerStateData;
    [SerializeField] private D_EnemyMeleeAttack meleeAttackData;

    [SerializeField] private Transform meleeAttackPosition;

    public override void Start()
    {
        base.Start();
        MoveState = new RangedBot_Grounded_MoveState(this, stateMachine, "move", moveStateData, this);
        IdleState = new RangedBot_Grounded_IdleState(this, stateMachine, "idle", idleStateData, this);
        PlayerDetectedState = new RangedBot_Grounded_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        ChargeState = new RangedBot_Grounded_ChargeState(this, stateMachine, "charge", enemyChargeStateData, this);
        LookForPlayerState = new RangedBot_Grounded_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        MeleeAttackState = new RangedBot_Grounded_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackData, this);

        stateMachine.Initialize(MoveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackData.attackRadius);
    }
}
