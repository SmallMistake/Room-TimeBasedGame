using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestScript : MonoBehaviour
{
    RestController restController;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (restController == null)
            {
                restController = FindObjectOfType<RestController>();
            }
            restController.ShowRestPanel();
        }
    }
}
