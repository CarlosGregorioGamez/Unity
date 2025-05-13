using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    private Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Busca al jugador por su etiqueta
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    void FixedUpdate()
    {
        if (target == null) return;

        // Calcula dirección hacia el jugador
        Vector2 direction = (target.position - transform.position).normalized;

        // Mueve al enemigo hacia el jugador
        rb.linearVelocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            GameManager.Instance.AddScore(100);
            Destroy(gameObject); 
        }
    }

}
