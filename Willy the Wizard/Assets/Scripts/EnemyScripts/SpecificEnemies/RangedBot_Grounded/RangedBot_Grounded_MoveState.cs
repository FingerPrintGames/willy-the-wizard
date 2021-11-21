public class RangedBot_Grounded_MoveState : EnemyMoveState
{
    private RangedBot_Grounded rangedBot;

    public RangedBot_Grounded_MoveState(Enemy enemy, EnemyFiniteStateMachine stateMachine, string animBoolName, D_EnemyMove stateData, RangedBot_Grounded rangedBot) : base(enemy, stateMachine, animBoolName, stateData)
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

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(rangedBot.PlayerDetectedState);
        }

        else if (isDetectingWall || !isDetectingLedge)
        {
            rangedBot.IdleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(rangedBot.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
