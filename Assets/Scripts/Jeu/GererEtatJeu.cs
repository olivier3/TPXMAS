using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GererEtatJeu : MonoBehaviour
{
    private GameObject menuPause;
    private AudioSource musiqueMenuPause;
    private bool isPaused = false; // pour pouvoir changer entre en pause et non en pause

    // Start is called before the first frame update
    void Start()
    {
        menuPause = this.gameObject.transform.Find("PanelPause").gameObject;
        musiqueMenuPause = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                menuPause.SetActive(true);
                // mettre en pause la majorite des choses
                Time.timeScale = 0f;
            }
            else
            {
                menuPause.SetActive(false);
                // remet actif la majorite des choses
                Time.timeScale = 1f;
            }

            // changer effets sonores selon si en pause ou non
            AlternerEntreSonsDeJeuEtDeMenuPause();
        }
    }

    /**
     * Cette fonction met en pause tout les effets sonores lorsqu'on met le jeu en pause
     * et part une musique de pause et reactive tout les effets sonores et met fin à la musique
     * de pause lorsqu'on sort du menu pause.
     */
    private void AlternerEntreSonsDeJeuEtDeMenuPause()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        if (isPaused)
        {
            foreach (AudioSource audioSource in allAudioSources)
            {
                audioSource.Pause();
            }

            musiqueMenuPause.Play();
        }
        else
        {
            foreach (AudioSource audioSource in allAudioSources)
            {
                audioSource.UnPause();
            }

            musiqueMenuPause.Stop();
        }
    }

    public void RevenirAuMenu()
    {
        SceneManager.LoadScene("SceneMenuPrincipal");
        // il faut unload la scene pour pouvoir y retourner plus tard
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
