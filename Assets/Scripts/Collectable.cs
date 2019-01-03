﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    //private static PlayerComponent playerComponent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Hit thingy " + other.name);
        if (other.gameObject.tag == "Player")
        {
            PlayerComponent.Instance.IncreaseCount();
            Destroy(gameObject);
        }
    }
}
