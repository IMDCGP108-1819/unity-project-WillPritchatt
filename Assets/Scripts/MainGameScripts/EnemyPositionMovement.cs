using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPositionMovement : MonoBehaviour
{

    //Non rotating enemy position locator follows the enemy directly
    public Transform Enemy;

    void Update()
    {
        transform.position = new Vector3(Enemy.position.x, Enemy.position.y, Enemy.position.z - 10);
    }
}
