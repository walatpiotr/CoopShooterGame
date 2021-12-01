using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;
    Vector2 mousePosition;

    public Camera cam;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Debug.Log(mousePosition);

        mousePosition = Input.mousePosition - transform.position - new Vector3(320f, 180f, 0f);
    }

    void FixedUpdate()
    {
        // TODO - cross sqr(2) -> 1
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);

        Vector2 lookingDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }
}
