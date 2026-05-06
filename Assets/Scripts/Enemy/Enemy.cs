using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float health = 20f;
    public int experienceReward = 10;
    public GameObject dropItemPrefab;
    
    private Transform player;
    private float currentHealth;
    private Rigidbody2D rb;
    private Animator animator;
    public WaveManager waveManager;
    private bool isDead = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = health;
    }

    void FixedUpdate()
    {
        if (!isDead && player != null)
        {
            // 플레이어 방향으로 이동
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            // 애니메이션 업데이트
            if (animator != null)
            {
                animator.SetFloat("moveX", direction.x);
                animator.SetFloat("moveY", direction.y);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("몬스터 처치! 경험치 +" + experienceReward);
        
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        // 플레이어에게 경험치 제공
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.GainExperience(experienceReward);
        }

        // 아이템 드롭
        if (dropItemPrefab != null && Random.value > 0.5f)
        {
            Instantiate(dropItemPrefab, transform.position, Quaternion.identity);
        }

        // 웨이브 매니저에 알림
        if (waveManager != null)
        {
            waveManager.MonsterDefeated();
        }

        // 약간의 딜레이 후 삭제
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            // 플레이어의 공격력으로 피해 입기
            PlayerAttack playerAttack = collision.GetComponent<PlayerAttack>();
            if (playerAttack != null)
            {
                TakeDamage(playerAttack.attackDamage);
            }
        }
    }
}
