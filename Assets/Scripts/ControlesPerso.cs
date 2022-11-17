using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesPerso : MonoBehaviour
{
    public Animator animator;
    private bool solToucher = false;
    public int vitesseSaut = 375;
    public float vitesseDeplacement = 0.0000001f;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("is_jumping", false);
        animator.SetBool("is_falling", false);
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

        // marcher vers l'avant
        if (Input.GetKey(KeyCode.W))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.forward * vitesseDeplacement);
        }

        if (!solToucher)
        {
            // dans les airs
            if (this.gameObject.GetComponent<Rigidbody>().velocity.y > 0)
            {
                // monte verticalement
                animator.SetBool("is_falling", false);
                animator.SetBool("is_jumping", true);
            }
            else
            {
                //descend
                animator.SetBool("is_jumping", false);
                animator.SetBool("is_falling", true);
            }
        }
        else
        {
            // a terre
            animator.SetBool("is_jumping", false);
            animator.SetBool("is_falling", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "sol")
        {
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
            solToucher = false;
        }
    }
}
