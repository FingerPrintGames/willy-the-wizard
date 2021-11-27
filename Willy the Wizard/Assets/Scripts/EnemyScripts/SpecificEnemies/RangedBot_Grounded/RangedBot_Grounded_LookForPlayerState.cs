using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBot_Grounded_LookForPlayerState : LookForPlayerState
{
    private RangedBot_Grounded rangedBot;

    public RangedBot_Grounded_LookForPlayerState(Enemy enemy, EnemyFiniteStateMachine stateMachine, string animBoolName, 
    D_LookForPlayer stateData, RangedBot_Grounded rangedBot) : base(enemy, stateMachine, animBoolName, stateData)
    {
        this.rangedBot = rangedBot;
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(rangedBot.PlayerDetectedState);
        }
        else if (areAllTurnsTimeDone)
        {
            stateMachine.ChangeState(rangedBot.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
