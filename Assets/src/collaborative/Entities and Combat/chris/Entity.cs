using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D body = null;
    public EntityMovement movement = null;
    public EntityCombat combat = null;
    public EntityAnimator mainAnimator = null;

    private void Awake()
    {
        if (body == null)
        {
            body = gameObject.GetComponent<Rigidbody2D>();
            if (body == null)
            {
                body = gameObject.AddComponent<Rigidbody2D>();
            }
        }

        if (movement == null)
        {
            movement = gameObject.AddComponent<EntityMovement>();
            movement.entity = this;
        }

        if (combat == null)
        {
            combat = gameObject.AddComponent<EntityCombat>();
        }

        if (mainAnimator == null)
        {
            mainAnimator = gameObject.AddComponent<EntityAnimator>();
        }
    }
}