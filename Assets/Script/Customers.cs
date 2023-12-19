using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour
{
    public bool peutMarcher;
    Rigidbody2D rb;
    Vector2 vecteur;


    public Client client;
    string[] ListeDenom = new[] { "Mishima", "Akechi", "Kawakami", "Shiho", "Takemi" };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        peutMarcher = true;


        JeSuisDesoleBenoit(Random.Range(0, 4), ListeDenom);
    }

    // Update is called once per frame
    void Update()
    {
        //Déplacement du client jusqu'a la caisse (Pas d'interpolation pour l'instant, juste de la ligne droite)
        if (peutMarcher == true)
        {
            rb.MovePosition(new Vector2(transform.position.x,transform.position.y+0.02f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //désactive l'avancement du clien quand il est à la caisse
    {
        peutMarcher = false;
    }

    private void JeSuisDesoleBenoit(int randomNumb, string[] noms) //Création d'un Client random, le switch case est du au fait que je ne sais aboslument pas gérer les enums, c'est pour ca que je l'ai honteusement caché par un int
    {
        switch (randomNumb)
        {
            case 0:
                client = new Client(noms[Random.Range(0, 5)], Random.Range(0, 100000), Client.TypeDarme.Pistolet, 0);
                break;
            case 1:
                client = new Client(noms[Random.Range(0, 5)], Random.Range(0, 100000), Client.TypeDarme.FusilAPompe, 1);
                break;
            case 2:
                client = new Client(noms[Random.Range(0, 5)], Random.Range(0, 100000), Client.TypeDarme.LancePierre, 2);
                break;
            case 3:
                client = new Client(noms[Random.Range(0, 5)], Random.Range(0, 100000), Client.TypeDarme.Mitraillette, 3);
                break;
        }
    }
}
