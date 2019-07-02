using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointer : MonoBehaviour {

    SpriteRenderer Enemy_Renderer;
    SpriteRenderer Point_Renderer;

    public GameObject Enemy;
    public Transform Enemy_Position;
    public GameObject Player;
    public Transform Player_Position;

	void Start () {
        Point_Renderer = this.GetComponent<SpriteRenderer>();
        Enemy_Renderer = Enemy.GetComponent<SpriteRenderer>();
        this.Point_Renderer.enabled = false;
    }
	
	void Update () {
        // If the enemy is visible in the camera then the pointer is invisible
        if (Enemy_Renderer.isVisible)
        {
            this.Point_Renderer.enabled = false;
        }
        // If the enemy is not visible in the camera then the pointer is visible
        else
        {
            this.Point_Renderer.enabled = true;
        }

        // This rotates the pointer so it points in the direction of the enemy
        Vector3 difference = Enemy_Position.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }
}
