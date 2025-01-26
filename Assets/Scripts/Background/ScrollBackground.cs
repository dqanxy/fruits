using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField] private float speed;

    private float spriteHeight;
    private float originy;

    public SpriteRenderer startSection;
    public SpriteRenderer loopSection;
    public SpriteRenderer endSection;

    void Start()
    {
        originy = loopSection.gameObject.transform.position.y;

        SpriteRenderer sr = loopSection;
        Bounds spriteBounds = sr.sprite.bounds;
        //spriteHeight = spriteBounds.size.y;

        spriteHeight = spriteBounds.size.y * loopSection.gameObject.transform.localScale.y;
    }

    void Update()
    {
        if (endSection.gameObject.transform.position.y > 0)
        {
            startSection.gameObject.transform.Translate(0, -speed * Time.deltaTime, 0);
            loopSection.gameObject.transform.Translate(0, -speed * Time.deltaTime, 0);
            endSection.gameObject.transform.Translate(0, -speed * Time.deltaTime, 0);

            if (loopSection.gameObject.transform.position.y < (originy - spriteHeight))
            {
                loopSection.gameObject.transform.Translate(0, spriteHeight, 0);
            }
        }
        else
        {
            endSection.transform.position -= new Vector3(0, endSection.transform.position.y, 0);
        }
    }
}