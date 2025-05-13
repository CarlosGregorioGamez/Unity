using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackZone;
    public float attackDuration = 0.2f;

    private bool isAttacking = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            StartCoroutine(DoAttack());
        }
    }

    private System.Collections.IEnumerator DoAttack()
    {
        isAttacking = true;
        attackZone.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackZone.SetActive(false);
        isAttacking = false;
    }
}
