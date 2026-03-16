using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(FearSystem))]
public class NPC : MonoBehaviour
{
    public float speedCalm = 2f;
    public float speedScared = 6f;
    public Vector2 minBounds = new Vector2(-10f, -10f);
    public Vector2 maxBounds = new Vector2(10f, 10f);

    private Vector2 targetPosition;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private FearSystem fearSystem;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        fearSystem = GetComponent<FearSystem>();

        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        fearSystem.onPanic.AddListener(Panic);
        PickNewTarget();
    }

    void Update()
    {
        if (fearSystem.isConsumed) return;

        if (Vector2.Distance(transform.position, targetPosition) < 0.5f)
        {
            PickNewTarget();
        }

        if (targetPosition.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (targetPosition.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }

    void FixedUpdate()
    {
        if (fearSystem.isConsumed) return;

        float fearPercent = fearSystem.fearLevel / fearSystem.fearPanic;
        float currentSpeed = Mathf.Lerp(speedCalm, speedScared, fearPercent);

        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        rb.linearVelocity = direction * currentSpeed;
    }

    private void PickNewTarget()
    {
        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);
        targetPosition = new Vector2(randomX, randomY);
    }

    public void HandleScare(float baseAmount, Vector2 scareSourcePosition)
    {
        float distance = Vector2.Distance(transform.position, scareSourcePosition);
        float effectiveFear = baseAmount / Mathf.Max(1f, distance / 5f);
        
        fearSystem.AddFear(effectiveFear);

        if (effectiveFear > 4f)
        {
            Vector2 fleeDirection = ((Vector2)transform.position - scareSourcePosition).normalized;
            Vector2 fleeTarget = (Vector2)transform.position + (fleeDirection * 10f);
            
            fleeTarget.x = Mathf.Clamp(fleeTarget.x, minBounds.x, maxBounds.x);
            fleeTarget.y = Mathf.Clamp(fleeTarget.y, minBounds.y, maxBounds.y);

            targetPosition = fleeTarget;
        }
    }

    public void Consume()
    {
        if (fearSystem.TryConsume())
        {
            rb.linearVelocity = Vector2.zero;
            Destroy(gameObject, 0.5f);
        }
    }

    private void Panic()
    {
        rb.linearVelocity = Vector2.zero;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector2 center = (minBounds + maxBounds) / 2f;
        Vector2 size = maxBounds - minBounds;
        Gizmos.DrawWireCube(center, size);
    }
}