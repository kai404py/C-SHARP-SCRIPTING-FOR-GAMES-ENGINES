using UnityEngine;

public class SimpleEnermy : MonoBehaviour
{
    [SerializeField] private float m_speed = 1;
    [SerializeField] private int m_health = 10;
    [SerializeField] private float m_attackRange = 0.5f;
    [SerializeField] private float m_attackCooldown = 1f;
    [SerializeField] private int m_attackDamage = 10;
    
    public HealthBar healthBar;
    public Transform m_Player;
    
    private float m_lastAttackTime = 0f;
    private TopDownCharacterController m_PlayerController;

    void Start()
    {
        m_PlayerController = FindObjectOfType<TopDownCharacterController>();
        m_Player = m_PlayerController.transform;   
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       	if (collision.CompareTag("PlayerBullet"))
        {
			Debug.Log("test");
            PlayerBullet bullet = collision.GetComponent<PlayerBullet>();
            float damage = bullet.GetDamage();
            TakeDamage((int)damage);
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        m_health -= damage;
        healthBar.SetHeath(m_health);
        
        if (m_health <= 0)
        {
            Die();
        }
    }

    public void SetHealth(int health)
    {
        m_health = health;
    }

    void Die()
    {
        FindObjectOfType<EnemyManager>().EnemyDied();
        Destroy(gameObject);
    }

    void Flip(HealthBar healthBar, Transform enemy, int direction) 
    {
        float enemyScale = 2.5f;
        float healthScale = 1f;
    
        if (direction == -1)
        {
            enemyScale = -2.5f;
            healthScale = -1f;
        }
    
        Vector3 scale = enemy.localScale;
        scale.x = enemyScale;
        enemy.localScale = scale;
    
        Vector3 healthBarScale = healthBar.transform.localScale;
        healthBarScale.x = healthScale;
        healthBar.transform.localScale = healthBarScale;
    }
    
    void AttackPlayer()
    {
        if (Time.time >= m_lastAttackTime + m_attackCooldown)
        {
            m_PlayerController.currentHealth -= m_attackDamage;
            m_PlayerController.healthBar.SetHeath(m_PlayerController.currentHealth);
            
            m_lastAttackTime = Time.time;
            
            Debug.Log("Enemy attacked player! Player health: " + m_PlayerController.currentHealth);
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, m_Player.position);
        
        if (distanceToPlayer <= m_attackRange)
        {
            AttackPlayer();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, m_Player.position, m_speed * Time.deltaTime);
        }
        
        if (transform.position.x < m_Player.position.x) 
        {
            Flip(healthBar, transform, 1);
        } 
        else if (transform.position.x > m_Player.position.x)
        {
            Flip(healthBar, transform, -1);
        }
		//Thank the lord for stack overflow (writen at 01:23am)
    }
}