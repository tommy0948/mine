using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage = 10f;
    public float attackCooldown = 0.5f;
    public float attackRange = 1f;
    
    private float lastAttackTime = 0f;
    private PlayerStats playerStats;
    private Animator animator;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryAttack();
        }
    }

    void TryAttack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    void Attack()
    {
        Debug.Log("플레이어 공격!");
        
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        // 공격 범위 내의 모든 적 피해
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);
        
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Enemy enemyComponent = enemy.GetComponent<Enemy>();
                if (enemyComponent != null)
                {
                    attackDamage = playerStats.attackDamage;
                    enemyComponent.TakeDamage(attackDamage);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
