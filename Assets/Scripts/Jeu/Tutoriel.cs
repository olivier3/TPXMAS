using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutoriel : MonoBehaviour
{
    private GameObject tutoHistoire;
    private GameObject tutoMouvements;
    private GameObject tutoSauts;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        tutoHistoire = this.transform.Find("Histoire").gameObject;
        tutoMouvements = this.transform.Find("Mouvements").gameObject;
        tutoSauts = this.transform.Find("Sauts").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void VersTutoMouvements()
    {
        tutoHistoire.SetActive(false);
        tutoMouvements.SetActive(true);
    }

    public void VersTutoSauts()
    {
        tutoMouvements.SetActive(false);
        tutoSauts.SetActive(true);
    }

    public void CommencerJeu()
    {
        tutoSauts.SetActive(false);
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }
}
