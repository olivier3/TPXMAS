using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPauseUI : MonoBehaviour
{
    private GameObject menuPrincipalPause;
    private GameObject menuObjectifs;
    private GameObject menuCarte;
    public GameObject cameraCarte;

    // Start is called before the first frame update
    void Start()
    {
        menuPrincipalPause = this.transform.Find("MainPause").gameObject;
        menuObjectifs = this.transform.Find("Objectifs").gameObject;
        menuCarte = this.transform.Find("MiniCarte").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AfficherObjectifs()
    {
        menuPrincipalPause.SetActive(false);
        menuObjectifs.SetActive(true);
    }

    public void RevenirDeObjectifs()
    {
        menuPrincipalPause.SetActive(true);
        menuObjectifs.SetActive(false);
    }

    public void AfficherCarte()
    {
        cameraCarte.SetActive(true);
        menuPrincipalPause.SetActive(false);
        menuCarte.SetActive(true);
    }

    public void RevenirDeCarte()
    {
        cameraCarte.SetActive(false);
        menuPrincipalPause.SetActive(true);
        menuCarte.SetActive(false);
    }
}
