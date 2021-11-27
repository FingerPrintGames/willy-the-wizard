using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeState : EnemyState
{
    protected D_EnemyCharge stateData;
    protected bool isPlayerInMinAgroRange;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;
    protected bool isChargeTimeOver;
    protected bool performCloseRangeAction;

    public EnemyChargeState(Enemy enemy, EnemyFiniteStateMachine stateMachine, string animBoolName, 
    D_EnemyCharge stateData) : base(enemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocity(stateData.chargeSpeed);
        isChargeTimeOver = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + stateData.chargeTime)
        {
            isChargeTimeOver = true;
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
        isDetectingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();
        performCloseRangeAction = enemy.CheckPlayerInCloseRangeAction();
    }
}
