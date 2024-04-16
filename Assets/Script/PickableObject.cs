using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour, IPickable, IPlaceable
{
    public void OnPlace(Vector2 targetPosition)
    {
        GetComponent<Collider2D>().enabled = true;
        transform.parent = null;
        transform.position = targetPosition;
    }

    public void Pickable(Transform go)
    {
        transform.parent = go;
        transform.localPosition = Vector3.zero;
        GetComponent<Collider2D>().enabled = false;
    }
}
