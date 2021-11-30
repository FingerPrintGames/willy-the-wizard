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

    [Header("Melee Attack State")]
    public float meleeAttackCooldown = 0.5f;
    public float meleeAttackDamage = 20f;
    public float meleeAttackRadius = 0.5f;

    [Header("In Air State")]
    public float coyoteTime = 0.2f;

    [Header("Check Variables")]
    public LayerMask whatIsDamageable;
}
