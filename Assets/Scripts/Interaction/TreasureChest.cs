using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public GameObject itemPrefab;
    public Sprite openChestSprite;
    private SpriteRenderer spriteRenderer;
    private bool isPlayerInRange = false;
    private bool isOpen = false;
    private Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isPlayerInRange && !isOpen && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        isOpen = true;
        Debug.Log("상자를 열었습니다!");
        
        // 애니메이션 재생
        if (animator != null)
        {
            animator.SetTrigger("Open");
        }
        
        // 스프라이트 변경
        if (spriteRenderer != null && openChestSprite != null)
        {
            spriteRenderer.sprite = openChestSprite;
        }
        
        // 상자 위치 근처에 아이템 스폰 (여러 개 가능)
        for (int i = 0; i < Random.Range(1, 4); i++)
        {
            Vector3 spawnOffset = new Vector3(Random.Range(-1f, 1f), -1f, 0);
            Instantiate(itemPrefab, transform.position + spawnOffset, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
            isPlayerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
            isPlayerInRange = false;
    }
}
