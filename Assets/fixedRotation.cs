using UnityEngine;

public class fixedRotation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Transform reloadIndicator;

    void Start()
    {
        reloadIndicator = transform.Find("reloadIndicator");
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.7f, 0f);
    }
}
