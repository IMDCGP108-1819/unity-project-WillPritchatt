using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public Transform Player_Position, Enemy_Position;
    public Rigidbody2D Rb2d;
    public EnemyStats EnemyStats;
    public Vector2 EnemyVelocity1 = new Vector2(0, 0);
    public Vector2 EnemyVelocity2;

    public int RotateSpeed;
    public float PercentHealth;
    public float MaxSpeed;


    void Start()
    {
        RotateSpeed = -100;
        Rb2d = GetComponent<Rigidbody2D>();
        MaxSpeed = 7f;
    }

    void Update()
    {
        // Keeps a steady rotation speed
        PercentHealth = EnemyStats.PercentageHealth;
        transform.Rotate(Vector3.forward * RotateSpeed * 10 * Time.deltaTime * PercentHealth);

    }

    private void FixedUpdate()
    {
        // Finds the position of the player and sets that as their direction target
        var direction = Player_Position.position - Enemy_Position.position;
        Rb2d.AddForce(new Vector2(direction.x / 2, direction.y / 2));
        if (Rb2d.velocity.magnitude > MaxSpeed)
        {
            Rb2d.velocity = Rb2d.velocity.normalized * MaxSpeed;
        }
        EnemyVelocity2 = EnemyVelocity1; // This is used for determining velocity before a collision occurs
        EnemyVelocity1 = Rb2d.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    // Collision with the player is handled within the PlayerMovement script
    {
        // If the enemy hits a wall then they take 5 damage
        if (collision.collider.tag == "Wall")
        {
            EnemyStats.EnemyHealth -= 5;
        }
    }
}
