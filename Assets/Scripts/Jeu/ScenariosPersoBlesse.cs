using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class ScenariosPersoBlesse : MonoBehaviour
{
    private Vector3 dernierEmplacementSauvegarde;
    public float hauteurDeMortParTomber = -100;
    public AudioSource audioSourceMusiquePrincipal;
    public AudioSource audioSourceMort;
    float _hitTime = 1;
    float _hitTimer = 0;
    bool _canHit = true;
    int vie = 3;

    // Start is called before the first frame update
    void Start()
    {
        dernierEmplacementSauvegarde = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the hit timer
        _hitTimer += Time.deltaTime;

        if (_hitTimer > _hitTime)
            _canHit = true;

        if (this.transform.position.y < hauteurDeMortParTomber)
        {
            // meurt
            GameObject.FindGameObjectWithTag("HealthBarInteractions").GetComponent<HealthBarHUDTester>().Hurt(100000000000000000);

            Mourir();
        }
    }

    public void SauvegarderLaPosition(Vector3 position)
    {
        dernierEmplacementSauvegarde = position;
    }

    public void Blesser()
    {
        // If can't be hit yet, return
        if (!_canHit)
            return;

        GameObject.FindGameObjectWithTag("HealthBarInteractions").GetComponent<HealthBarHUDTester>().Hurt(1);

        vie--;

        if (vie <= 0) { 
            Mourir();
        }

        // Reset the hit timer when taking damage
        _hitTimer = 0;
    }

    public void Mourir()
    {
        // pour jouer le son de mort
        audioSourceMort.Play();

        Invoke("Respawn", 1);
    }

    private void Respawn()
    {
        // pour faire recommencer la musique principale
        audioSourceMusiquePrincipal.Play();

        // pour teleporter le personnage au dernier checkpoint
        this.transform.position = new Vector3(dernierEmplacementSauvegarde.x,
            dernierEmplacementSauvegarde.y + 5, // il faut que ca soit assez haut pour ne pas glitcher
            dernierEmplacementSauvegarde.z);

        // pour redonner de la vie au personnage
        GameObject.FindGameObjectWithTag("HealthBarInteractions").GetComponent<HealthBarHUDTester>().Heal(100000000000000000);
    }
}
