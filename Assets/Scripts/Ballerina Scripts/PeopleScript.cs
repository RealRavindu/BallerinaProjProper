using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PeopleScript : MonoBehaviour
{
    Rigidbody rb;
    public float waitDuration, moveDuration, minDist, maxDist;
    bool moving = false, pickedDir = false;
    Vector3 force;
    float t;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        t += Time.deltaTime;
        

        if (!moving)
        {
            if (t > waitDuration)
            {
                if (!pickedDir)
                {
                    force = PickRandomDirection();
                }
                moving = true;
                t = 0;
            }
        } else
        {
            if (t > moveDuration)
            {
                moving = false;
                t = 0;
            }
        }
    }
    private void FixedUpdate()
    {
        if (moving) 
        { 
            rb.AddForce(force, ForceMode.Impulse);
        }
    }

    private Vector3 PickRandomDirection()
    {
        return new Vector3(Random.Range(minDist, maxDist), 0, Random.Range(minDist, maxDist));
    }
}
