using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// A class to control the top-down character.
/// Implements the player controls for moving and shooting.
/// Updates the player animator so the character animates based on input.
/// </summary>
public class TopDownCharacterController : MonoBehaviour
{
    #region Framework Variables

    [Header("Projectile parameters")]
    // Reference to the projectile object.
    [SerializeField]
    GameObject m_projectilePrefab;

    // The point at which the projectile spawns.
    [SerializeField] private Transform m_firePoint;

    // The speed of the projectile.
    [SerializeField] private float m_projectileSpeed;

    // How often the projectile can be fired.
    [SerializeField] private float m_fireRate;

    private float m_fireTimeout;

    // The last known direction of the player.
    private Vector2 m_lastDirection;

    [Header("Movement parameters")]
    // The inputs that we need to retrieve from the input system.
    private InputAction m_moveAction;

    private InputAction m_attackAction;

    // The components that we need to edit to make the player move smoothly.
    private Animator m_animator;
    private Rigidbody2D m_rigidbody;

    // The direction that the player is moving in.
    private Vector2 m_playerDirection;

    // The speed at which the player moves.
    [SerializeField] private float m_playerSpeed = 200f;

    //The maximum speed the player can move
    [SerializeField] private float m_playerMaxSpeed = 1000f;

    // The speed at which the player rotates.
    [SerializeField] private float m_playerRotationSpeed = 10f;

    // The damping applied to the player when they stop moving;
    [SerializeField] private float m_playerDampingFactor = 1.0f; 
    
    #endregion

    public static int playerScore = 0;
    
    /// <summary>
    /// When the script first initialises this gets called.
    /// Use this for grabbing components and setting up input bindings.
    /// </summary>

    private void Awake()
    {
        // Bind movement inputs to variables.
        m_moveAction = InputSystem.actions.FindAction("Move");
        m_attackAction = InputSystem.actions.FindAction("Attack");

        // Get components from Character game object so that we can use them later.
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// When a fixed update loop is called, it runs at a constant rate, regardless of PC performance.
    /// This ensures that physics are calculated properly.
    /// </summary>
    private void FixedUpdate()
    {
        // Clamp the speed to the maximum speed for if the speed has been changed in code.
        float speed = m_playerSpeed > m_playerMaxSpeed ? m_playerMaxSpeed : m_playerSpeed;

        // Applies a force to make the player move in the direction they are facing if W or the up arrow is pressed.
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            m_rigidbody.linearDamping = 0f;
            m_rigidbody.AddForce(transform.up * (Time.deltaTime * speed * Input.GetAxis("Vertical")));
        }
        else
        {
            m_rigidbody.linearDamping = m_playerDampingFactor;
        }
    }

    /// <summary>
    /// When the update loop is called, it runs every frame.
    /// Therefore, this will run more or less frequently depending on performance.
    /// Used to catch changes in variables or input.
    /// </summary>
    void Update()
    {
        // Store any movement inputs into m_playerDirection - this will be used in FixedUpdate to move the player.
        m_playerDirection = m_moveAction.ReadValue<Vector2>();

        if (m_playerDirection.magnitude > 0)
        {
            // Stores last known direction for later.
            m_lastDirection = m_playerDirection;
        }

        // Check if an attack has been triggered.
        if (m_attackAction.IsPressed() && Time.time > m_fireTimeout)
        {
            m_fireTimeout = Time.time + m_fireRate;
            Fire();
        }

        // Rotates the player if the correct keys are pressed.
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, m_playerRotationSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -m_playerRotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void Fire()
    {
        Vector2 fireDirection = transform.up;

        if (fireDirection == Vector2.zero)
        {
            fireDirection = Vector2.up;
        }

        Rigidbody2D projectileRigidbody = Instantiate(m_projectilePrefab, m_firePoint.position, transform.rotation).GetComponent<Rigidbody2D>();
        // Spawns projectile.
        if (projectileRigidbody)
        {
            // Gets the player's current velocity.
            Vector2 playerVelocity = m_rigidbody.linearVelocity;
            // Adds the player's velocity to the projectile's initial velocity.
            projectileRigidbody.linearVelocity = (fireDirection * m_projectileSpeed) + playerVelocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }
}
