using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_crawl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0.0f, 0.0f, speed);

        // Apply the movement to the object's position.
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
