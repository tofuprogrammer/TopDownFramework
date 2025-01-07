using UnityEngine;
using UnityEngine.UIElements;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private Transform m_startWaypoint;
    [SerializeField] private Transform m_endWaypoint;
    [SerializeField] private float m_speed = 1;
    
    private Transform m_target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_target = m_startWaypoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MovingObstacleWaypoint"))
        {
            ChangeTarget();
        }
    }
    
    void ChangeTarget()
    {
        transform.Rotate(0f, 0f, 180f);
        
        if (m_target == m_startWaypoint)
        {
            m_target = m_endWaypoint;
        }
        else if (m_target == m_endWaypoint)
        {
            m_target = m_startWaypoint;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, m_target.position) < 0.01f)
        {
            transform.position = m_target.position; // Eliminates potential issues with floating point errors
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, m_target.position, m_speed * Time.deltaTime);
        }
    }
}
