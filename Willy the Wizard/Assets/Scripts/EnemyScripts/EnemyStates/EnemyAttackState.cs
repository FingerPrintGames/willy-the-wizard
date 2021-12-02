using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    protected Transform attackPosition;

    protected bool isAnimationFinished;
    protected bool isPlayerInMinAgroRange;

    public EnemyAttackState(Enemy enemy, EnemyFiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(enemy, stateMachine, animBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();
        enemy.AnimToSM.attackState = this;
        isAnimationFinished = false;
        core.Movement.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void TriggerAttack()
    {

    }

    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }
}
