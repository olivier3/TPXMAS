using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class ScenariosPersoBlesse : MonoBehaviour
{
    private Vector3 dernierEmplacementSauvegarde;
    public float hauteurDeMortParTomber = -100;

    // Start is called before the first frame update
    void Start()
    {
        dernierEmplacementSauvegarde = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < hauteurDeMortParTomber)
        {
            // meurt
            GameObject.FindGameObjectWithTag("HealthBarInteractions").GetComponent<HealthBarHUDTester>().Hurt(100000000000000000);
            Invoke("Respawn", 1);
        }
    }

    public void SauvegarderLaPosition(Vector3 position)
    {
        dernierEmplacementSauvegarde = position;
    }

    public void Respawn()
    {
        // pour teleporter le personnage au dernier checkpoint
        this.transform.position = new Vector3(dernierEmplacementSauvegarde.x,
            dernierEmplacementSauvegarde.y + 5, // il faut que ca soit assez haut pour ne pas glitcher
            dernierEmplacementSauvegarde.z);

        // pour redonner de la vie au personnage
        GameObject.FindGameObjectWithTag("HealthBarInteractions").GetComponent<HealthBarHUDTester>().Heal(100000000000000000);
    }
}
