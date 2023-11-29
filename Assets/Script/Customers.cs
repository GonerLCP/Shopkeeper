using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour
{
    public bool peutMarcher;
    Rigidbody2D rb;
    Vector2 vecteur;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        peutMarcher = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (peutMarcher == true)
        {
            rb.MovePosition(new Vector2(transform.position.x,transform.position.y+0.02f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        peutMarcher = false;
    }

}



