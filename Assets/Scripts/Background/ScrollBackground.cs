using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField] private float speed;

    private float spriteHeight;
    private float originy;

    void Start()
    {
        originy = transform.position.y;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Bounds spriteBounds = sr.sprite.bounds;
        spriteHeight = spriteBounds.size.y * transform.localScale.y;
    }

    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);

        if (transform.position.y < (originy - spriteHeight))
        {
            transform.Translate(0, spriteHeight, 0);
        }
    }
}
