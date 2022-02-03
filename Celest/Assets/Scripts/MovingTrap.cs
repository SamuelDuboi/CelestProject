using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    public bool Loop = true;
    [SerializeField]
    public float speed = 1f;

    [Header("R�f�rences")]
    [SerializeField]
    public Transform self;
    [SerializeField]
    public GameObject[] Path;


    int ActualTarget = 1;
    private bool Return = false;

    // Start is called before the first frame update
    void Start()
    {
        //Je v�rifie que j'ai au moins un point dans mon chemin � suivre
        if (Path.Length > 0)
            //Vu que j'en au moins un j'initialise la position de ma plateforme
            //� l'endroit o� se trouve mon premier point
            self.SetPositionAndRotation(Path[0].transform.position, Path[0].transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        if (Path.Length < 2) return; //Verifie que j'ai plus de 1 points
        //Sinon tu ne peux pas bouger

        //Ma direction c'est le vecteur (posTarget - posInit)
        Vector3 dir = Path[ActualTarget].transform.position - transform.position;
        //Je bouge mon bloc dans cette direction, la vitesse = spped *temps �coul�
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Si l'ennemi est quasiment arriv� � sa destination
        if (Vector3.Distance(transform.position, Path[ActualTarget].transform.position) < 0.3f)
        {
            //si je veux faire des boucles
            if(Loop)
            {
                //je prends le reste de la division enti�re de numCible+1 par le nombre de cibles
                ActualTarget = (ActualTarget + 1) % Path.Length;
            }
            else
            //le cas ou je souhaite un all� retour
            {

                if (ActualTarget == Path.Length -1)//regarde si je suis � la derni�re cible
                    //et que j'ai vesoin d'aller en arri�re
                    Return = true;
                else if (ActualTarget == 0) Return = false;//v�rifie si je suis pas de retour au d�but

                if(Return)
                {
                    ActualTarget--;
                }
                else
                {
                    ActualTarget++;
                }

            }
        }

    }
    



}
