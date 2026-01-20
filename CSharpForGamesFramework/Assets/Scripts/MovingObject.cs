using UnityEngine;
public class MovingObject : MonoBehaviour
{
    [SerializeField] private Transform m_startWaypoint;
    [SerializeField] private Transform m_endWaypoint;
    [SerializeField] private float m_speed = 1;
    
    private Transform m_target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        m_target = m_startWaypoint;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetDestination = m_startWaypoint.position - transform.position;
        bool goToEnd = true;
        
        if (transform.position == m_startWaypoint.position)
        {
            goToEnd = false;
        }
        else
        {
            goToEnd = true;
        }

        if (goToEnd)
        {
            targetDestination = m_endWaypoint.position - transform.position;
        }
        else
        {
            targetDestination = m_startWaypoint.position - transform.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetDestination, m_speed * Time.deltaTime);
    }
}
