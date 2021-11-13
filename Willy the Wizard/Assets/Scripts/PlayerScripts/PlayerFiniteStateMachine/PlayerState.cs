using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    protected float startTime;

    private string animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    //Called when entering a new state
    public virtual void Enter()
    {
        DoChecks();
        startTime = Time.time;
    }

    //Called when exiting a state
    public virtual void Exit()
    {

    }

    //Gets called every frame
    public virtual void LogicUpdate()
    {

    }

    //Gets called every fixed update
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    //Check to see if we need to change states
    public virtual void DoChecks()
    {

    }
    
}
