using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovementerController : MonoBehaviour
{
    public LayerMask groundLayerMask;
    private NavMeshAgent navAgent;
    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        bool lmbClicked = Mouse.current.leftButton.wasPressedThisFrame;
        if (lmbClicked)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            //Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

            //using method to cast a raycast to see where the mouse is clicking on the ground
            Ray mouseClickRay = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit mouseClickHit;

            
            if (Physics.Raycast(mouseClickRay, out mouseClickHit, 25f, groundLayerMask))
            {
                //moves player to wherever the point that was clicked by the mouse
                navAgent.SetDestination(mouseClickHit.point);
            }
            
        }
    }
}
