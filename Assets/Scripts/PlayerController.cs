using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    bool moving;
    public float ForceMagnitude;
    GameObject camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = GameObject.FindWithTag("MainCamera");
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

        //camera control
        Vector3 currentCamPos = camera.transform.position;
        currentCamPos.x = transform.position.x;
        camera.transform.position = currentCamPos;
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            rb.AddForce(Vector3.right * ForceMagnitude, ForceMode.Impulse);
        }
    }
}
