using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    private Transform target;
    private bool isDying = false;

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

    public bool IsDying()
    {
        return isDying;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDying) return;

        if (other.CompareTag("PlayerAttack"))
        {
            isDying = true;
            GameManager.Instance.AddScore(10);
            Destroy(gameObject);
        }
    }


}
