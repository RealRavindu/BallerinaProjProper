using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    bool moving;
    public float ForceMagnitude;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            moving = true;
        } else
        {
            moving = false;
        }
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            rb.AddForce(Vector3.right * ForceMagnitude, ForceMode.Impulse);
        }
    }
}
