using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ScoutMovement : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public Vector3 targetPosition;
    public Transform cameraTransform;
    private Vector3 screenPosition;
    private Vector3 mousePosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navAgent.SetDestination(targetPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mousePosition = Mouse.current.position.ReadValue();
            screenPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Debug.Log("MousePos["+mousePosition.ToString()+"] ScreenPos["+screenPosition.ToString()+"]");
            RaycastHit[] hits = Physics.RaycastAll(cameraTransform.position, (screenPosition - cameraTransform.position).normalized,Mathf.Infinity, 3);
            
            if (hits.Length != 0)
            {
                targetPosition = hits[0].point;
            } else
            {
                targetPosition = transform.position;
                Debug.Log("Click didn't register a ground layer object");
            }
                
            navAgent.SetDestination(targetPosition);

        }

        Debug.DrawLine(cameraTransform.position, (screenPosition - cameraTransform.position).normalized);
    }
}
