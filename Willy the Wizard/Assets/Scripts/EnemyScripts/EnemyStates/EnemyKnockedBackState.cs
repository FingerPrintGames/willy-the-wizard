using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockedBackState : EnemyState
{
    protected bool isBeingKnockedBack;
    
    public EnemyKnockedBackState(Enemy enemy, EnemyFiniteStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        isBeingKnockedBack = core.Combat.isKnockbackActive;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        isBeingKnockedBack = core.Combat.isKnockbackActive;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
