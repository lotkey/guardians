using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    public static void DropHealth(float amount, Vector2 position)
    {
        GameObject drop = new GameObject();
        HealthDrop healthDrop = drop.AddComponent<HealthDrop>();
        Rigidbody2D body = drop.AddComponent<Rigidbody2D>();
        SpriteRenderer spriteRenderer = drop.AddComponent<SpriteRenderer>();
        BoxCollider2D collider = drop.AddComponent<BoxCollider2D>();
        drop.layer = LayerMask.NameToLayer("Pickups");
        drop.transform.position = position;
        
        healthDrop.healthAmount = amount;

        body.gravityScale = 0;

        spriteRenderer.sortingLayerName = "Pickups";

        collider.isTrigger = true;
        collider.size = new Vector2(.55f, .43f);
        collider.offset = new Vector2(0, -.03f);

        spriteRenderer.sprite = Resources.Load<Sprite>("sprites/chris/healthDrop");
    }

    public float healthAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() == Player.GetPlayer())
        {
            Player.GetPlayer().combat.Heal(healthAmount);
            Destroy(gameObject);
        }
    }
}