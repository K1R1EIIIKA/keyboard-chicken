using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

public class Tongue : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TongueOnTriggerEnter2D");
        BaseCrumb crumb = other.GetComponent<BaseCrumb>();
        Chicken chicken = GetComponentInParent<Chicken>();
        if (crumb!=null && chicken != null)
        {
            chicken.GetScore(crumb.GetScore());
            crumb.GetHit();
        }
    }
}
