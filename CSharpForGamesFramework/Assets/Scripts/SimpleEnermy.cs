using UnityEngine;

public class SimpleEnermy : MonoBehaviour
{
    [SerializeField] private float m_speed = 1;
    public Transform m_Player;

    void Start()
    {
        m_Player = FindObjectOfType<TopDownCharacterController>().transform;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, m_Player.position, m_speed * Time.deltaTime);
    }
}
