using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float moveSpeed = 7f;

    [Header("Jump State")]
    public float jumpForce = 10f;
    public int amountOfJumps = 1;

    [Header("In Air State")]
    public float coyoteTime = 0.2f;

    [Header("Check Variables")]
    public float groundCheckRadius = 0.05f;
    public LayerMask whatIsGround;
}
