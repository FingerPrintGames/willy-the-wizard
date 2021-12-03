using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBot_Grounded_KnockedBackState : EnemyKnockedBackState
{
    private RangedBot_Grounded rangedBot;
    
    public RangedBot_Grounded_KnockedBackState(Enemy enemy, EnemyFiniteStateMachine stateMachine, string animBoolName, RangedBot_Grounded rangedBot) : base(enemy, stateMachine, animBoolName)
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
        if (!isBeingKnockedBack)
        {
            stateMachine.ChangeState(rangedBot.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
