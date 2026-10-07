using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody rb;

    public float jump = 5f;
    public float rotation = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotateRight();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            rotateStatic();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            rotateLeft();
        }
    }

    void rotateRight()
    {
        rb.AddForce(new Vector3(1, 1, 0) * jump, ForceMode.Impulse);

        Vector3 torque = new Vector3(0f, 0f, -1f) * rotation;
        rb.AddTorque(torque, ForceMode.Impulse);
    }

    void rotateLeft()
    {
        rb.AddForce(new Vector3(-1, 1, 0) * jump, ForceMode.Impulse);

        Vector3 torque = new Vector3(0f, 0f, 1f) * rotation;
        rb.AddTorque(torque, ForceMode.Impulse);
    }

    void rotateStatic()
    {
        rb.AddForce(new Vector3(0, 1, 0) * jump, ForceMode.Impulse);

        Vector3 torque = new Vector3(0f, 1f, 0f) * rotation;
        rb.AddTorque(torque, ForceMode.Impulse);
    }
}
