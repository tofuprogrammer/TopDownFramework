using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// A class to control the top down character.
/// Implements the player controls for moving and shooting.
/// Updates the player animator so the character animates based on input.
/// </summary>
public class TopDownCharacterController : MonoBehaviour
{
    #region Framework Variables
    
    [Header("Movement parameters")]
    // Reference for the projectile object
    [SerializeField] GameObject m_projectilePrefab;
    // The point at which the projectile spawns
    [SerializeField] private Transform m_firePoint;
    // The speed of the projectile
    [SerializeField] float m_projectileSpeed;
    //The inputs that we need to retrieve from the input system.
    private InputAction m_moveAction;
    private InputAction m_attackAction;

    //The components that we need to edit to make the player move smoothly.
    private Animator m_animator;
    private Rigidbody2D m_rigidbody;
    
    //The direction that the player is moving in.
    private Vector2 m_playerDirection;
    
    //The speed at which the player moves
    [SerializeField] private float m_playerSpeed = 200f;
    //The maximum speed the player can move
    [SerializeField] private float m_playerMaxSpeed = 1000f;
    
    // The speed at which the player rotates
    [SerializeField] private float m_playerRotationSpeed = 40f;
    #endregion

    /// <summary>
    /// When the script first initialises this gets called.
    /// Use this for grabbing components and setting up input bindings.
    /// </summary>
    
    private void Awake()
    {
        //bind movement inputs to variables
        m_moveAction = InputSystem.actions.FindAction("Move");
        m_attackAction = InputSystem.actions.FindAction("Attack");
        
        //get components from Character game object so that we can use them later.
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// When a fixed update loop is called, it runs at a constant rate, regardless of pc performance.
    /// This ensures that physics are calculated properly.
    /// </summary>
    private void FixedUpdate()
    {
        //clamp the speed to the maximum speed for if the speed has been changed in code.
        float speed = m_playerSpeed > m_playerMaxSpeed ? m_playerMaxSpeed : m_playerSpeed;
        
        // Applies a force to make the player move in the direction they are facing if W or the up arrow is pressed.
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * (Time.deltaTime * speed * Input.GetAxis("Vertical")));
        }
    }
    
    /// <summary>
    /// When the update loop is called, it runs every frame.
    /// Therefore, this will run more or less frequently depending on performance.
    /// Used to catch changes in variables or input.
    /// </summary>
    void Update()
    {
        // store any movement inputs into m_playerDirection - this will be used in FixedUpdate to move the player.
        m_playerDirection = m_moveAction.ReadValue<Vector2>();

        // check if an attack has been triggered.
        if (m_attackAction.IsPressed())
        {
            // just log that an attack has been registered for now
            // we will look at how to do this in future sessions.
            Fire();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate (0, 0, m_playerRotationSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate (0, 0, -m_playerRotationSpeed * Time.fixedDeltaTime);
        }
    }

    void Fire()
    {
        GameObject projectileToSpawn = Instantiate(m_projectilePrefab, m_firePoint.position, Quaternion.identity);

        if (projectileToSpawn.GetComponent<Rigidbody2D>())
        {
            projectileToSpawn.GetComponent<Rigidbody2D>().linearVelocity = m_playerDirection * m_projectileSpeed;
        }
    }
}
