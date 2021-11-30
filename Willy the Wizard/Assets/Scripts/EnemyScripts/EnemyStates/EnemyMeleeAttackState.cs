using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttackState : EnemyAttackState
{
    protected D_EnemyMeleeAttack stateData;
    protected AttackDetails attackDetails;

    public EnemyMeleeAttackState(Enemy enemy, EnemyFiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_EnemyMeleeAttack stateData) : base(enemy, stateMachine, animBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        attackDetails.attackDamage = stateData.meleeDamage;
        attackDetails.position = enemy.AliveGO.transform.position;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, 
        stateData.attackRadius, stateData.whatIsPlayer);

        /*foreach (Collider2D detectedObject in detectedObjects)
        {
            detectedObject.transform.SendMessage("Damage", attackDetails);
        }
        */
    }
}
