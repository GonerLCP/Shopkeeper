using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour
{
    public bool peutMarcher;
    public bool peutReculer;
    public bool peutTourner;
    Rigidbody2D rb;
    Vector2 vecteur;
    float speed;


    public Client client;

    string[] ListeDenom = new[] { "Mishima", "Akechi", "Kawakami", "Shiho", "Takemi" };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        peutMarcher = true;
        peutReculer = false;
        peutTourner = false;
        speed = 500.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Déplacement du client jusqu'a la caisse (Pas d'interpolation pour l'instant, juste de la ligne droite)
        if (peutMarcher == true)
        {
            rb.MovePosition(new Vector2(transform.position.x,transform.position.y+0.02f));
        }

        if (peutTourner == true)
        {
            rb.MoveRotation(rb.rotation +speed * Time.deltaTime );
            if (rb.rotation >=179)
            {
                rb.rotation = 180f;
                peutReculer = true;
                peutTourner=false;
            }
        }

        if (peutReculer == true)
        {
            rb.MovePosition(new Vector2(transform.position.x, transform.position.y - 0.02f));
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //désactive l'avancement du clien quand il est à la caisse
    {
        if (collision.tag == "Comptoir")
        {
            peutMarcher = false;
        }
        if(collision.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
