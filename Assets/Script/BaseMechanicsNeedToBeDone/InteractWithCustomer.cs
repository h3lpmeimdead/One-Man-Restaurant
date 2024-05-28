using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithCustomer : MonoBehaviour
{
    public float interactionRange = 3f;
    public LayerMask customerLayer;
    Player player;
    void Start()
    {
        player = GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        player.ShootingRaycast();
    }

    public void InteractWithCustomers()
    {

        if (Physics.Raycast(transform.position, Vector3.right, interactionRange, customerLayer))
        {
            //CustomerOrder customer = hit.collider.GetComponent<CustomerOrder>();
            //if (customer != null)
            //{
            //    customer.Interact();
            //}
        }
    }
}
