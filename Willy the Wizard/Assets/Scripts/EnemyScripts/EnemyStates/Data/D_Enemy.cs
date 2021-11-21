using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class D_Enemy : ScriptableObject
{
    public float wallCheckDistance = 0.4f;
    public float ledgeCheckDistance = 0.8f;

    public float minAgroDistance = 3f;
    public float maxAgroDistance = 4f;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

}
