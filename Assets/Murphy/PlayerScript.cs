using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Sprite IdleLeft;

    public Sprite IdleRight;

    private Vector3 currentDirection;

    private Vector3 previousDirection;

    private void Update()
    {
        var direction = Vector3.zero;
        var numKeyDown = 0;

        if (Input.GetKey(KeyCode.A))
        {
            numKeyDown++;
            direction = Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            numKeyDown++;
            direction = Vector3.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            numKeyDown++;
            direction = Vector3.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            numKeyDown++;
            direction = Vector3.down;
        }

        UpdateAnimationDirection(direction);

        if (direction != Vector3.zero && numKeyDown == 1)
        {
            transform.position += direction * Time.deltaTime * 5;
        }
    }

    private void UpdateAnimationDirection(Vector3 direction)
    {
        if (currentDirection == direction)
        {
            return;
        }

        previousDirection = currentDirection;
        currentDirection = direction;

        var animator = GetComponent<Animator>();

        var moveLeft = false;
        var moveRight = false;
        if (direction == Vector3.left || direction == Vector3.up)
        {
            moveLeft = true;
        }
        else if (direction == Vector3.right || direction == Vector3.down)
        {
            moveRight = true;
        }

        animator.SetBool("MoveRight", moveRight);
        animator.SetBool("MoveLeft", moveLeft);

        if (direction == Vector3.zero)
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            Sprite idleSprite;

            if (previousDirection == Vector3.left || previousDirection == Vector3.up)
            {
                idleSprite = IdleLeft;
            }
            else
            {
                idleSprite = IdleRight;
            }

            spriteRenderer.sprite = idleSprite;
        }
    }
}
