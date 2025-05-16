using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private float verticalInput = 0f;
    private float horizontalInput = 0f;
    public float invulnerabilityTime = 2f;
    private bool isInvulnerable = false;
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
        if (other.CompareTag("Enemy") && !isInvulnerable)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && !enemy.IsDying())
            {
                StartCoroutine(TakeDamage());
            }
        }
    }

    private IEnumerator TakeDamage()
    {
        isInvulnerable = true;

        GameManager.Instance.LoseLife();

        // Opcional: efecto visual de parpadeo
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            float elapsed = 0f;
            while (elapsed < invulnerabilityTime)
            {
                sr.enabled = !sr.enabled;
                yield return new WaitForSeconds(0.1f);
                elapsed += 0.1f;
            }
            sr.enabled = true; // asegurarse de que quede visible
        }
        else
        {
            yield return new WaitForSeconds(invulnerabilityTime);
        }

        isInvulnerable = false;
    }



}
