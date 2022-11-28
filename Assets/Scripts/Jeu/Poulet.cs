using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Poulet : MonoBehaviour
{
    Transform victime;                      //Représente de FPS Controller.		
    public int distancePoursuite = 10;      //Distance max. à partir de laquelle l'ennemi nous poursuit.
    NavMeshAgent navMeshAgent;              //Nous servira à définir le comportement de l'ennemi.
    float distanceVictime = Mathf.Infinity; //Distance entre le FPS Controller et l'ennmi.
    public Transform[] points;              //Les points de navigation.
    int destinationIndex = 0;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        victime = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.destination = points[destinationIndex].position;
        audio = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        EvaluerDestination();
        RechercheJoueur();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            audio.Play();
            Destroy(gameObject, 0.2f);
        }
    }

    public void EvaluerDestination()
    {
        //Distance entre la position de l'agent et la destination actuelle
        float dist = navMeshAgent.remainingDistance;

        if (dist <= 0.05f)
        {
            destinationIndex = (destinationIndex + 1) % points.Length;
            navMeshAgent.destination = points[destinationIndex].position;
        }
    }

    public void RechercheJoueur()
    {
        //Distance entre le monstre et le joueur
        float distanceVictime = Vector3.Distance(victime.position, transform.position);

        if (distanceVictime <= distancePoursuite)
        {
            //Le joueur est détecté
            navMeshAgent.destination = victime.position;
            //navMeshAgent.speed = runSpeed;
        }
        else
        {
            navMeshAgent.destination = points[destinationIndex].position;
            //navMeshAgent.speed = walkSpeed;
        }
    }

}
