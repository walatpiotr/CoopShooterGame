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
    }

    void FixedUpdate()
    {
        // TODO - cross sqr(2) -> 1
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);

        //Vector2 lookingDirection = mousePosition - rb.position;
        //float angle = Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg - 90f;

        //rb.rotation = angle;
        RotateToMouse();
    }

    void RotateToMouse()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = cam.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)cam.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle+90f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
