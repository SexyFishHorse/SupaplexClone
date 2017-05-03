using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        var direction = Vector3.zero;
        var numKeyDown = 0;

        if (Input.GetKeyDown(KeyCode.A))
        {
            numKeyDown++;
            direction = Vector3.left;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            numKeyDown++;
            direction = Vector3.right;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            numKeyDown++;
            direction = Vector3.up;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            numKeyDown++;
            direction = Vector3.down;
        }

        if (direction != Vector3.zero && numKeyDown == 1)
        {
            transform.position += direction;
        }
    }
}
