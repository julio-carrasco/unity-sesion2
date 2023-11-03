using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    GameObject zombie;
    GameObject board;
    private bool isNear = false;
    public float distanceThreshold = 8.0f;
    void Start()
    {
        zombie = GameObject.FindGameObjectWithTag("zombie");
        board = GameObject.FindGameObjectWithTag("pizarra");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(zombie.transform.position, board.transform.position);
        if (distance < distanceThreshold)
        {
            isNear = true;
        }
        else
        {
            isNear = false;
        }
        if(isNear) {
            MoveChairs();
            TeleportPots();
        }
    }

    void TeleportPots() 
    {
        GameObject[] pots = GameObject.FindGameObjectsWithTag("maceta");
        foreach (GameObject pot in pots)
        {
            // Añadido random para que se muevan las macetas de forma aleatoria
            Random.InitState((int)Time.time);
            Vector3 random_dir = new Vector3(Random.Range(-1,1), Random.Range(-1,1), 0.0f).normalized;
            pot.transform.Translate(random_dir * Time.deltaTime);
        }
    }

    void MoveChairs()
    {
        GameObject[] chairs = GameObject.FindGameObjectsWithTag("silla");
        foreach (GameObject chair in chairs)
        {
            Vector3 direction = (zombie.transform.position - chair.transform.position).normalized;
            chair.transform.LookAt(zombie.transform.position);
            chair.transform.Translate(direction * Time.deltaTime);
        }
    }
}
