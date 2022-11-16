using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesPerso : MonoBehaviour
{
    public Animator animator;
    private bool solToucher = false;
    public int vitesseSaut = 375;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("is_jumping", false);
    }

    // Update is called once per frame
    void Update()
    {
        // sauter
        if (Input.GetKeyDown(KeyCode.Space) && solToucher)
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * vitesseSaut);
            animator.SetTrigger("Jump");
            //animator.SetBool("is_jumping", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "sol")
        {
            animator.SetBool("is_jumping", false);
            solToucher = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "sol")
        {
            solToucher = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "sol")
        {
            animator.SetBool("is_jumping", true);
            solToucher = false;
        }
    }
}
