using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private float verticalInput = 0f;
    private float horizontalInput = 0f;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.Instance.LoseLife();
        }
    }


}
