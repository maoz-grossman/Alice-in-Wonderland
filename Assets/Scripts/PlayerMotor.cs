using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private const float LANE_DISTANCE = 4.0f;
    private Animator anim;
    private Rigidbody rb;
    private float jumpForce = 4.0f;
    private float gravity =12.04f;
    private float verticalVelocity;
    private float speed = 10.0f;
    private bool left;
    private bool right;
    private bool grounded;
    private bool dead=false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        Movement();
        if (dead)
        {
            StartCoroutine(deadCoroutine());
        }
    }

    private void Movement()
    {
        float x=0;
        Vector3 targetPosition = transform.position.z * Vector3.forward;

        if (Input.GetKeyDown(KeyCode.A)&&!left)
        {
            x = -3;
        }
        if (Input.GetKeyDown(KeyCode.D) && !right)
        {
            x = 3;
        }

        Vector3 moveVector = Vector3.zero;
       
        moveVector.x = x;
        moveVector.y = 0f;
        moveVector.z = speed;

        //cc.Move(moveVector * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector3(0, 8, 0), ForceMode.Impulse);
            anim.SetBool("Jump", true);
            grounded = false;
        }
        if(grounded)
        transform.Translate(new Vector3(moveVector.x, 0, moveVector.z * Time.deltaTime));
        else
        transform.Translate(new Vector3(moveVector.x, 0, 10*Time.deltaTime));

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Left")
            left = true;
        if (other.tag == "Right")
            right = true;
        if (other.tag == "Dead")
        {
            dead = true;
            anim.SetBool("Dead", true);
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Left")
            left = false;
        if (other.tag == "Right")
            right = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
        anim.SetBool("Jump", false);
    }
    IEnumerator deadCoroutine()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
