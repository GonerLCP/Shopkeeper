using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaisseTrigger : MonoBehaviour
{
    public bool clientALaCaisse;
    public GameObject clientEnCaisse;
    public Client classeDuClient;

    // Start is called before the first frame update
    void Start()
    {
        clientALaCaisse = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) //Quand le client est à la caisse déclenche le srcipt d'achat
    {
        clientALaCaisse = true;
        clientEnCaisse = collision.gameObject;
        classeDuClient = clientEnCaisse.GetComponent<Customers>().client;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        clientALaCaisse = false;
    }
}
