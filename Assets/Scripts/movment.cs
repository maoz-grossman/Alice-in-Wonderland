using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
    //movment filed

    public static movment Instanse { set; get;  }
    private bool tap, swipeUP, swipeDown, swipeLeft, swipeRight;
    private Vector2 startTouch, swipeDelta;
    private bool draging = false;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeUP { get { return swipeUP; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool Tap { get { return tap; } }

    private void Awake()
    {
        Instanse = this;
    }



    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        //draging = false;
    }

    // Update is called once per frame
    void Update()
    {
        tap = swipeUP = swipeDown = swipeLeft = swipeRight = false;


        //for pc check
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Hello");
            tap = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();

        }

        //for mobile 
        if (Input.touches.Length != 0) //at least 1 touch 
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Debug.Log("you touch");
              //  draging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
               // draging = false;
                Reset();
            }
        }

        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            
            if (Input.touches.Length != 0)
            {
                
                swipeDelta = Input.touches[0].position - startTouch;
            }
            //for pc check
            else if (Input.GetMouseButton(0))
            {
                Debug.Log("pc");
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }
                /**
                       if(draging)
                   {
                       if(Input.touches.Length != 0)
                       {
                           Debug.Log("hello");
                           swipeDelta = Input.touches[0].position - startTouch;

                       } else if (Input.GetMouseButton(0)){
                           swipeDelta = (Vector2)Input.mousePosition - startTouch;

                       }
                   }

               */

        if (swipeDelta.magnitude > 100) //100 pixels
        {

            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {

                Debug.Log("here");
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
          
            /**
             * else
            {
                //up or down
                if (x < 0)
                    swipeDown = true; //optional
                else
                    swipeUP = true; //for optinal jump 
            }
              */

            Reset();
    
        }
    }
}
