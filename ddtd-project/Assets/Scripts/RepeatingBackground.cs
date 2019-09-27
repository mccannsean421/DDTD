using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{

    private BoxCollider2D sceneCollider;
    private float backgroundWidth;
    // Start is called before the first frame update
    void Start()
    {
        sceneCollider = GetComponent<BoxCollider2D> ();
        backgroundWidth = sceneCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
     if(transform.position.x < -backgroundWidth) {
         RepositionBackground();
     } 
    }

    private void RepositionBackground() {
        Vector2 backgroundOffset = new Vector2(backgroundWidth * 2.0f, 0);
        transform.position = (Vector2) transform.position + backgroundOffset;
    }
}
