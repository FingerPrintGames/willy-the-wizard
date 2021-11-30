using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
    public Rigidbody2D Body { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDir { get; private set; }
    
    private Vector2 workspace;

    protected override void Awake()
    {
        base.Awake();
        Body = GetComponentInParent<Rigidbody2D>();
        FacingDir = 1;
    }

    public void LogicUpdate()
    {
        CurrentVelocity = Body.velocity;
    }

    #region Set Functions
    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        Body.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        Body.velocity = workspace;
        CurrentVelocity = workspace;
    }
    #endregion

    #region Check Functions
    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDir)
            Flip();
    }
    #endregion
    
    #region Do Functions
    private void Flip()
    {
        FacingDir *= -1;
        Body.transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    #endregion
}
