using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType { Gold, Potion, Equipment }
    public ItemType itemType = ItemType.Gold;
    public int value = 10;
    
    private bool isPickedUp = false;
    private Rigidbody2D rb;
    private float floatForce = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // 아이템이 위로 떠오르도록
        rb.velocity = new Vector2(Random.Range(-2f, 2f), floatForce);
    }

    void Update()
    {
        // 중력 감소시켜서 부드럽게 내려오기
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.98f, rb.velocity.y - 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isPickedUp)
        {
            PickUp(collision.gameObject);
        }
    }

    void PickUp(GameObject player)
    {
        isPickedUp = true;
        
        switch (itemType)
        {
            case ItemType.Gold:
                GameManager.instance.AddScore(value);
                Debug.Log("골드 " + value + "을 획득했습니다!");
                break;
                
            case ItemType.Potion:
                PlayerStats stats = player.GetComponent<PlayerStats>();
                if (stats != null)
                {
                    stats.currentHealth = Mathf.Min(stats.currentHealth + value, stats.maxHealth);
                    Debug.Log("포션을 사용했습니다! HP +" + value);
                }
                break;
                
            case ItemType.Equipment:
                Debug.Log("장비를 획득했습니다!");
                break;
        }
        
        Destroy(gameObject);
    }
}
