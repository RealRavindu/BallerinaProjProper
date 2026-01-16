using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    bool moving;
    public float ForceMagnitude, maxVelocity;
    GameObject camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = GameObject.FindWithTag("MainCamera");

        rb.maxLinearVelocity = maxVelocity; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.A))
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
            int direction = 1;
            direction = (Input.GetKey(KeyCode.A)) ? -1 : 1;
            rb.AddForce(Vector3.right * ForceMagnitude * direction, ForceMode.Impulse);
        }
    }
}
