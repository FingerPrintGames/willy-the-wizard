using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttackState : EnemyAttackState
{
    protected D_EnemyMeleeAttack stateData;

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

        foreach (Collider2D detectedObject in detectedObjects)
        {
            IDamageable damageable = detectedObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.Damage(stateData.meleeDamage);
            }
        }

        foreach (Collider2D detectedObject in detectedObjects)
        {
            IKnockback knockback = detectedObject.GetComponent<IKnockback>();

            if (knockback != null)
            {
                knockback.Knockback(stateData.knockbackAngle, stateData.knockbackStrength, core.Movement.FacingDir);
            }
        }

    }
}
