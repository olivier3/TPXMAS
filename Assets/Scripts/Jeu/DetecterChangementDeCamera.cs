using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

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
        if (collider.tag == "Player")
        {
            // affiche cette camera secondaire
            objectCamera.SetActive(true);
            // modifie les controles pour avec cette camera secondaire
            // StartCoroutine = pour ajouter delai entre changements de controles et pour pouvoir passer des parametres
            StartCoroutine(ModifierLaCameraSurLaquelleBaserLesControles(collider, objectCamera.GetComponent<Camera>()));
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            // affiche la camera principale
            objectCamera.SetActive(false);
            // modifie les controles pour avec la camera principale (Camera.main = recupere la camera principale selon le tag)
            // StartCoroutine = pour ajouter delai entre changements de controles et pour pouvoir passer des parametres
            StartCoroutine(ModifierLaCameraSurLaquelleBaserLesControles(collider, Camera.main));
        }
    }

    private IEnumerator ModifierLaCameraSurLaquelleBaserLesControles(Collider collider, Camera camera)
    {
        // fait attendre le systeme une demi seconde avant de changer les controles
        yield return new WaitForSecondsRealtime(0.5f);

        collider.gameObject.GetComponent<ThirdPersonUserControlModified>().m_Cam = camera.transform;
    }
}
