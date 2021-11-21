using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    protected D_EnemyMove stateData;
    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMinAgroRange;
    
    public EnemyMoveState(Enemy enemy, EnemyFiniteStateMachine stateMachine, string animBoolName, D_EnemyMove stateData) : base(enemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocity(stateData.movementSpeed);
        isDetectingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
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
        isDetectingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
    }
}
