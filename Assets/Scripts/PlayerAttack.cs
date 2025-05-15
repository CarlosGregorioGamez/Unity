using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackZone;
    public float attackCooldown = 1f;
    private float attackTimer = 0f;

    void Update()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f)
        {
            StartCoroutine(DoAttack());
            attackTimer = attackCooldown;
        }
    }

    IEnumerator DoAttack()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        // Posicionar la zona de ataque hacia el ratón
        attackZone.transform.localPosition = direction * 0.5f;

        attackZone.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        attackZone.SetActive(false);
    }
}
