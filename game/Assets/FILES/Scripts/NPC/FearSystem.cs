using UnityEngine;
using UnityEngine.Events;

public class FearSystem : MonoBehaviour
{
    public float fearLevel = 0f;
    public float fearTasty = 70f;
    public float fearPanic = 100f;
    public float decayRate = 5f;
    public bool isConsumed = false;

    public UnityEvent onPanic;

    void Update()
    {
        if (isConsumed) return;

        if (fearLevel > 0)
        {
            fearLevel -= decayRate * Time.deltaTime;
            fearLevel = Mathf.Clamp(fearLevel, 0f, fearPanic);
        }

        if (fearLevel >= fearPanic)
        {
            onPanic?.Invoke();
        }
    }

    public void AddFear(float amount)
    {
        if (isConsumed) return;
        fearLevel += amount;
    }

    public bool TryConsume()
    {
        if (fearLevel >= fearTasty && !isConsumed)
        {
            isConsumed = true;
            return true;
        }
        return false;
    }
}