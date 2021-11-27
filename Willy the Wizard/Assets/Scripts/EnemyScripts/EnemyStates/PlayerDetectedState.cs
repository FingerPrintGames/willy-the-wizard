using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : EnemyState
{
    public D_PlayerDetected stateData;
    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool performLongRangeAction;
    protected bool performCloseRangeAction;

    public PlayerDetectedState(Enemy enemy, EnemyFiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(enemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }


    public override void Enter()
    {
        base.Enter();
        performLongRangeAction = false;
        enemy.SetVelocity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + stateData.longRangeActionTime)
        {
            performLongRangeAction = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate(); 
    }
    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();
        performCloseRangeAction = enemy.CheckPlayerInCloseRangeAction();
    }
}
