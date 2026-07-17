using UnityEngine;

public class Cooldown_Example : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float redColorDuration = 1.0f;

    public float currentTimeInGame;
    public float lastTimeDamaged;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ChangeColorIfNeeded();
    }

    private void ChangeColorIfNeeded()
    {
        currentTimeInGame = Time.time;

        if (currentTimeInGame > lastTimeDamaged + redColorDuration)
        {
            if (spriteRenderer.color != Color.white)
            {
                TurnWhite();
            }
        }
    }

    public void TakeDamage()
    {
        // Debug.Log(gameObject.name + " took damage!");
        spriteRenderer.color = Color.red;
        lastTimeDamaged = Time.time;
    }

    private void TurnWhite()
    {
        spriteRenderer.color = Color.white;
    }
}
