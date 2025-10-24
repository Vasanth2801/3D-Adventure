using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public float speed = 7f;
    public float smoothSpeed = 0.025f;
    float turnVecocity;
    public Transform cam;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    //public int maxHealth = 100;
    //public int currentHealth;
    //public Image healthBar;

    private void Start()
    {
       // currentHealth = maxHealth;
    }

    private void Update()
    {
        Attack();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2f * gravity * 3f);
        }


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (direction.magnitude >= 0.1f)
        {
            Run();
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVecocity, smoothSpeed);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime); 
        }
        else
        {
            Idle();
        }

       // healthBar.fillAmount = Mathf.Clamp((float)currentHealth / maxHealth, 0, 1);
       // if (currentHealth <= 0)
        {
         //   Destroy(gameObject);
           // Debug.Log("Player Died");
        }
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            Collider[] hitInfo = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);
            foreach(Collider enemy in hitInfo)
            {
                EnemyAI.instance.TakeDamage(20);
                Debug.Log("We hit " + enemy.name);
            }
        }
    }

    void Run()
    {
         animator.SetFloat("Speed", 1);
    }

    void Idle()
    {
         animator.SetFloat("Speed", 0);
    }
}