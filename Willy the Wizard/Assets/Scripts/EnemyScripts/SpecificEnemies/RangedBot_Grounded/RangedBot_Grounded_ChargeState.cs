using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBot_Grounded_ChargeState : EnemyChargeState
{
    private RangedBot_Grounded rangedBot;

    public RangedBot_Grounded_ChargeState(Enemy enemy, EnemyFiniteStateMachine stateMachine, string animBoolName, 
    D_EnemyCharge stateData, RangedBot_Grounded rangedBot) : base(enemy, stateMachine, animBoolName, stateData)
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
        if (!isDetectingLedge || isDetectingWall)
        {
            stateMachine.ChangeState(rangedBot.LookForPlayerState);
        }

        else if (isChargeTimeOver)
        {
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(rangedBot.PlayerDetectedState);
            }
            else stateMachine.ChangeState(rangedBot.LookForPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
