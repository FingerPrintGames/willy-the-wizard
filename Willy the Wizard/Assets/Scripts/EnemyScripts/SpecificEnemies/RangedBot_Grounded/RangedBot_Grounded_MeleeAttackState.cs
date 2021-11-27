using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBot_Grounded_MeleeAttackState : EnemyMeleeAttackState
{
    private RangedBot_Grounded rangedBot;
    public RangedBot_Grounded_MeleeAttackState(Enemy enemy, EnemyFiniteStateMachine stateMachine, 
    string animBoolName, Transform attackPosition, D_EnemyMeleeAttack stateData, 
    RangedBot_Grounded rangedBot) : base(enemy, stateMachine, animBoolName, attackPosition, stateData)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
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

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
