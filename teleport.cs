using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    // Añadido cuaternion para posicion
    public Vector3 initial_pos;
    public Quaternion initial_rotation;
    public KeyCode keyToPress = KeyCode.T;

    void Start()
    {
        initial_rotation = transform.rotation;
        initial_pos = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            transform.position = initial_pos;
            transform.rotation = initial_rotation;
        }
    }
}
