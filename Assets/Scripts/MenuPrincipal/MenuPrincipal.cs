using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Jouer()
    {
        SceneManager.LoadScene("SampleScene");
        // il faut unload la scene pour pouvoir y retourner plus tard
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
