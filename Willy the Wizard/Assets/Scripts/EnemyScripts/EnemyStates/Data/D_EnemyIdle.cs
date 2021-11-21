using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyIdleData", menuName = "Data/Enemy Data/Idle State Data")]
public class D_EnemyIdle : ScriptableObject
{
    public float minIdleTime = 1f;
    public float maxIdleTime = 3f;
}
