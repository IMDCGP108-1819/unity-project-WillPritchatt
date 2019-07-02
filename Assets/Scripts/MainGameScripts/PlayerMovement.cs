using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D Rb2d;
    private Vector3 MousePosition;

    public PlayerStats PlayerStats;
    public EnemyStats EnemyStats;
    public EnemyScript Enemy;
    public Transform Enemy_Position;
    public Transform Player_Position;
    public Vector2 PlayerVelocity1 = new Vector2(0, 0);
    public Vector2 PlayerVelocity2;
    public Vector2 EnemyVelocity;

    public float RotateSpeed;
    public float PercentHealth;
    public float MaxSpeed;
    public float DamageToPlayer;
    public float DamageToEnemy;

    void Start()
    {
        RotateSpeed = -100;
        Rb2d = GetComponent<Rigidbody2D>();
        MaxSpeed = 7f;
    }

    void Update()
    {
        // Keeps a steady rotation speed
        PercentHealth = PlayerStats.PercentageHealth;
        transform.Rotate(Vector3.forward * RotateSpeed * 10 * Time.deltaTime * PercentHealth);

    }
    void FixedUpdate()
    {
        //Movement is handled by having the player move towards the mouse position
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = MousePosition - Player_Position.position;
        Rb2d.AddForce(new Vector2(direction.x, direction.y));
        if (Rb2d.velocity.magnitude > MaxSpeed)
        {
            Rb2d.velocity = Rb2d.velocity.normalized * MaxSpeed;
        }
        PlayerVelocity2 = PlayerVelocity1; // This is used for determining velocity before a collision occurs
        PlayerVelocity1 = Rb2d.velocity;
        EnemyVelocity = Enemy.EnemyVelocity2;

        if (Input.GetKeyDown(KeyCode.Space) && PlayerStats.EnergyLevel >= 25)
        {
            // Gives the player a boost in velocity in the direction of the mouse at a cost of 25 energy
            PlayerStats.EnergyLevel -= 25;
            Rb2d.velocity = new Vector2(direction.x * MaxSpeed, direction.y * MaxSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    // Handles collision with the enemy and the damage that will be dealt
    {
        if (collision.collider.tag == "Enemy")
        {
            // If the player's velocity is lower than the enemy's velocity on collision then the player will take damage
            // The enemy will gain 7.5 energy
            if (PlayerVelocity2.magnitude < EnemyVelocity.magnitude)
            {
                Vector2 damageVelocity = PlayerVelocity2 - EnemyVelocity;
                DamageToPlayer = damageVelocity.magnitude;
                DamageToPlayer = Mathf.RoundToInt(DamageToPlayer);
                PlayerStats.PlayerHealth -= DamageToPlayer;
                EnemyStats.EnergyLevel += 7.5f;
            }
            // If the player's velocity is higher than the enemy's velocity on collision then the enemy will take damage
            // The player will gain 7.5 energy
            if (PlayerVelocity2.magnitude > EnemyVelocity.magnitude)
            {
                Vector2 damageVelocity = EnemyVelocity - PlayerVelocity2;
                DamageToEnemy = damageVelocity.magnitude;
                DamageToEnemy = Mathf.RoundToInt(DamageToEnemy);
                EnemyStats.EnemyHealth -= DamageToEnemy;
                PlayerStats.EnergyLevel += 7.5f;
            }
            // The is no statement for if they have equal velocity as it will always be 0 damage taken

        }
        // If the player hits a wall then they take 5 damage
        if (collision.collider.tag == "Wall")
        {
            PlayerStats.PlayerHealth -= 5;
        }
    }
}
