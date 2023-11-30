using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public Text text;
    public float radius;
    public Transform circle;
    private bool isInRange;
    private SpriteRenderer player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 position = circle == null ? Vector3.zero : circle.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    public void DetectCol()
    {
        foreach (Collider2D col in Physics2D.OverlapCircleAll(circle.position, radius))
        {
            
            //Debug.Log(col.name);
        }
    }
}
