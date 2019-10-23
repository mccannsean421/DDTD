using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name == "Player")
        {
            Debug.Log("YOU DEAD");
        }
    }
}
