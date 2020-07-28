using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class swipe : MonoBehaviour
{
    public movment swipeConrtol;
    public Transform player;
    private Vector3 position;

    // Update is called once per frame
    void Update()
    {
        if (swipeConrtol.SwipeLeft)
        {
            position += Vector3.left;
        }
        if (swipeConrtol.SwipeRight)
        {
            position += Vector3.right;
        }
    }
}
