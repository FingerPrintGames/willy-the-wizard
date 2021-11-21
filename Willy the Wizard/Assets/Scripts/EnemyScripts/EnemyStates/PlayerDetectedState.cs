using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : EnemyState
{
    public D_PlayerDetected stateData;
    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;

    public PlayerDetectedState(Enemy enemy, EnemyFiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(enemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.SetVelocity(0f);
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();
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

        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();
    }
}
