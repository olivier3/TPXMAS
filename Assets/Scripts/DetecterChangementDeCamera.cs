using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecterChangementDeCamera : MonoBehaviour
{
    private GameObject objectCamera;

    // Start is called before the first frame update
    void Start()
    {
        objectCamera = this.transform.Find("CameraSecondaire").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        objectCamera.SetActive(true);
    }

    private void OnTriggerExit(Collider collider)
    {
        objectCamera.SetActive(false);
    }
}
