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
        core.Movement.SetVelocityX(stateData.movementSpeed * core.Movement.FacingDir);
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
    public override void DoChecks()
    {
        base.DoChecks();
        isDetectingLedge = core.CollisionSenses.CheckLedge;
        isDetectingWall = core.CollisionSenses.CheckWall;
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
    }
}
