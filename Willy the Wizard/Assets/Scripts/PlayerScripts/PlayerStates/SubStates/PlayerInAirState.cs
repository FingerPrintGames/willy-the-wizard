using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    private int xInput;
    private bool jumpInput;
    private bool isGrounded;
    private bool coyoteTime;

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckIfOnTheGround();
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

        CheckCoyoteTime();
        xInput = player.InputManager.NormInputX;
        jumpInput = player.InputManager.JumpInput;

        //Attacking
        if (player.InputManager.AttackInputs[(int)CombatInputs.primary])
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }
        else if (player.InputManager.AttackInputs[(int)CombatInputs.secondary])
        {
            stateMachine.ChangeState(player.SecondaryAttackState);
        }

        //Landing
        else if (isGrounded && player.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        
        //Jumping
        else if (jumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
        
        //Moving in air
        else
        {
            player.CheckIfShouldFlip(xInput);
            player.SetVelocityX(xInput * playerData.moveSpeed);
            player.Anim.SetFloat("VelocityY", player.CurrentVelocity.y);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void CheckCoyoteTime()
    {
        if (coyoteTime && Time.time > startTime + playerData.coyoteTime)
        {
            coyoteTime = false;
            player.JumpState.DecreaseJumpAmount();
        }
    }

    public void StartCoyoteTime() => coyoteTime = true;
}
