using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rigidbody;
    public int damage = 40;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        AgentController agent = obj.GetComponent<AgentController>();

        if (agent)
        {
            agent.TakeDamage(40);
        }
        Debug.Log("Bang");
        Destroy(gameObject);
    }
}
