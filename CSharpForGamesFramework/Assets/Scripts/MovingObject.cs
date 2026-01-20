using UnityEngine;
public class MovingObject : MonoBehaviour
{
    [SerializeField] private Transform m_startWaypoint;
    [SerializeField] private Transform m_endWaypoint;
    [SerializeField] private float m_speed = 1;
    bool goToEnd = true;

    private Vector2 targetDestination;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        targetDestination = m_startWaypoint.position;
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
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, targetDestination, m_speed * Time.deltaTime);
    }
}
