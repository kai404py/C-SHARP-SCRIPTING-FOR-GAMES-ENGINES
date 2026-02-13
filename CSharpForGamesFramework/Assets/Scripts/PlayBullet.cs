using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float m_speed = 10f;
    [SerializeField] private float m_lifetime = 3f;
    private float m_damage;
    private Vector2 m_direction;

    void Start()
    {
        Destroy(gameObject, m_lifetime);
    }
    
    public void SetDamage(float damage)
    {
        m_damage = damage;
    }
    
    public float GetDamage()
    {
        return m_damage;
    }

    public void SetDirection(Vector2 direction)
    {
        m_direction = direction.normalized;
    }

    void Update()
    {
        transform.Translate(m_direction * m_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            
        }
    }
}