using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    public Transform PlayerPosition;
    public Transform EnemyPosition;
    public GameObject PlayerObject;
    public EnemyStats EnemyStats;
    public PlayerStats PlayerStats;

    public Rigidbody2D Rb2d;
    public BoxCollider2D PlayerProjectileCollider;

	void Start () {
        Rb2d = GetComponent<Rigidbody2D>();
    }

	void Update () {

        // Checks to see if the player presses the hotkey for the projectile ability and if they have enough energy to fire it

        if (Input.GetButtonDown("Fire1") && PlayerStats.EnergyLevel == 100)
        {
            PlayerStats.EnergyLevel -= 100;
            // Instaniates the projectile and adds velocity in the direction of the enemy
            Rigidbody2D Clone;
            Clone = Instantiate(Rb2d, GameObject.Find("PlayerPosition").transform.position - new Vector3(0, 0, -10), transform.rotation);
            Clone.velocity = transform.TransformDirection(GameObject.Find("EnemyObject").transform.position * 14);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)

        // Handles collision with all objects on screen
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(PlayerObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        
        // If the projectiles hits the enemy then the enemy takes 30 damage
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyStats.EnemyHealth -= 30;
            Destroy(GameObject.Find("PlayerProjectile(Clone)"));
        }

        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(GameObject.Find("PlayerProjectile(Clone)"));
        }
    }
}
