using UnityEngine;
public class MovingObject : MonoBehaviour
{
    [SerializeField] private Transform m_startWaypoint;
    [SerializeField] private Transform m_endWaypoint;
    [SerializeField] private float m_speed = 1;
    bool goToEnd = true;

    private Vector2 targetDestination;
    private TopDownCharacterController m_PlayerController;
    private int m_attackDamage = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        targetDestination = m_startWaypoint.position;
        m_PlayerController = FindObjectOfType<TopDownCharacterController>();
    }

    void ChangeTarget()
    {
        if (goToEnd == false)
        {
            goToEnd = true;
            targetDestination = m_startWaypoint.position;
        }
        else
        {
            goToEnd = false;
            targetDestination = m_endWaypoint.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeTarget();
        if (collision.CompareTag("Player"))
        {
            m_PlayerController.currentHealth -= m_attackDamage;
            m_PlayerController.healthBar.SetHeath(m_PlayerController.currentHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, targetDestination, m_speed * Time.deltaTime);
    }
}
