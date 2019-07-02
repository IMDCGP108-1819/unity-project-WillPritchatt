using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    public Transform PlayerPosition;
    public Transform EnemyPosition;
    public GameObject EnemyObject;
    public PlayerStats PlayerStats;
    public EnemyStats EnemyStats;

    public Rigidbody2D Rb2d;
    public BoxCollider2D EnemyProjectileCollider;


    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // If the enemy has 100 energy they will fire a projectile at the player
        if (EnemyStats.EnergyLevel == 100)
        {
            EnemyStats.EnergyLevel -= 100;
            Rigidbody2D Clone;
            Clone = Instantiate(Rb2d, GameObject.Find("EnemyPosition").transform.position - new Vector3(0, 0, -10), transform.rotation);
            Clone.velocity = transform.TransformDirection(GameObject.Find("Player").transform.position * 14);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    // Handles collision with all objects on screen
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(EnemyObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        // If the projectile hits the player then the player takes 30 damage
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats.PlayerHealth -= 30;
            Destroy(GameObject.Find("EnemyProjectile(Clone)"));
        }

        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "PlayerProjectile")
        {
            Destroy(GameObject.Find("EnemyProjectile(Clone)"));
        }
    }
}
