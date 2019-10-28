using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 1f;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if (Vector2.Distance(transform.position, target.position) > 3) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime); 
        }
    }
}
