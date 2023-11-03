using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiders : MonoBehaviour
{
    GameObject zombie;
    GameObject[] chairs;
    //Rigidbody rb;
    public float distanceThreshold = 2.0f;
    public Vector3 direction = new Vector3(0,0,0);
    private bool isColliding = false;
    void Start()
    {
        zombie = GameObject.FindGameObjectWithTag("zombie");
        chairs = GameObject.FindGameObjectsWithTag("silla");
    }

    // Update is called once per frame
    void Update()
    {

        if(isColliding)
        {
            MoveSpiders();
        }
        
    }

    void MoveSpiders()
    {
        GameObject[] spiders = GameObject.FindGameObjectsWithTag("araña");
        float speed = 5.0f;
        foreach (GameObject spider in spiders)
        {
            //rb = GetComponent("spider") as Rigidbody;
            direction = (zombie.transform.position - spider.transform.position).normalized;
            spider.transform.LookAt(zombie.transform);
            spider.transform.Translate(direction* speed * Time.deltaTime);
            //rb.velocity = direction * speed;
        }
    }

// Añadido triggers
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("silla"))
        {
            isColliding = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("silla"))
        {
            isColliding = false;
        }
    }
}
