using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : EnemyState
{
    protected D_LookForPlayer stateData;

    protected bool turnImmediately;
    protected bool isPlayerInMinAgroRange;
    protected bool areAllTurnsDone;
    protected bool areAllTurnsTimeDone;
    
    protected float lastTurnTime;
    protected int amountOfTurnsDone;
    
    public LookForPlayerState(Enemy enemy, EnemyFiniteStateMachine stateMachine, string animBoolName,
    D_LookForPlayer stateData) : base(enemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();
        areAllTurnsDone = false;
        areAllTurnsTimeDone = false;
        lastTurnTime = startTime;
        amountOfTurnsDone = 0;

        core.Movement.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (turnImmediately)
        {
            core.Movement.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
            turnImmediately = false;
        }
        //If turn time is up but the enemy still has turns for searching
        else if (Time.time >= lastTurnTime + stateData.timeBetweenTurns && !areAllTurnsDone)
        {
            core.Movement.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
        }
        //If the enemy is out of turns
        if (amountOfTurnsDone >= stateData.amountOfTurns)
        {
            areAllTurnsDone = true;
        }
        //If turn time is up and the enemy is out of turns for searching then go to a new state
        if (Time.time >= lastTurnTime + stateData.timeBetweenTurns && areAllTurnsDone)
        {
            areAllTurnsTimeDone = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetTurnImmediately(bool flip)
    {
        turnImmediately = flip;
    }
}
