using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3rdPerson : MonoBehaviour
{
    public GameObject thirdPersonController;
    private Vector3 distanceDePersonnage;

    // Start is called before the first frame update
    void Start()
    {
        distanceDePersonnage = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // pour ne pas que la rotation de la camera change avec le personnage
        Vector3 positionDuController = thirdPersonController.transform.position;

        this.transform.position = new Vector3(
            positionDuController.x + distanceDePersonnage.x,
            positionDuController.y + distanceDePersonnage.y,
            positionDuController.z + distanceDePersonnage.z);
    }
}
