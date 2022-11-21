using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenariosPersoBlesse : MonoBehaviour
{
    public float hauteurDeMortParTomber = -100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < hauteurDeMortParTomber)
        {
            // meurt
            GameObject.FindGameObjectWithTag("HealthBarInteractions").GetComponent<HealthBarHUDTester>().Hurt(100000000000000000);
            Invoke("Recommencer", 1);
        }
    }

    public void Recommencer()
    {
        Scene sceneActuelle = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sceneActuelle.name);
    }
}
