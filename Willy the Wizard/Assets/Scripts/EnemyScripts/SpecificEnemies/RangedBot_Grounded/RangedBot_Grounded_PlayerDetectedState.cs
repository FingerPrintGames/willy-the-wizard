using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBot_Grounded_PlayerDetectedState : PlayerDetectedState
{
    private RangedBot_Grounded rangedBot;
    
    public RangedBot_Grounded_PlayerDetectedState(Enemy enemy, EnemyFiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, RangedBot_Grounded rangedBot) : base(enemy, stateMachine, animBoolName, stateData)
    {
        this.rangedBot = rangedBot;
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

        if (performLongRangeAction)
        {
            stateMachine.ChangeState(rangedBot.ChargeState);
        }
        else if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(rangedBot.LookForPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
