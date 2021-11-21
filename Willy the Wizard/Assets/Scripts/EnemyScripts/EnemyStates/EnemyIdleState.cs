using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected D_EnemyIdle stateData;
    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;
    protected bool isPlayerInMinAgroRange;
    protected float idleTime;

    public EnemyIdleState(Enemy enemy, EnemyFiniteStateMachine stateMachine, string animBoolName, D_EnemyIdle stateData) : base(enemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocity(0f);
        isIdleTimeOver = false;
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
        SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();
        if (flipAfterIdle)
        {
            enemy.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
    }

    public void SetFlipAfterIdle(bool flip)
    {
        flipAfterIdle = flip;
    }

    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
