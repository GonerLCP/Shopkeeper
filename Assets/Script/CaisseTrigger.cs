using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class CaisseTrigger : MonoBehaviour
{
    public bool clientALaCaisse;
    public GameObject clientEnCaisse;
    public Client classeDuClient;
    public Items item;
    public GameObject WeakImage;

    //Weak
    public AudioSource audioSource;
    public AudioClip clip;

    public bool pauvre;

    // Start is called before the first frame update
    void Start()
    {
        clientALaCaisse = false;
        pauvre = false;
    }
    private void Update()
    {
        if (clientEnCaisse.GetComponent<Talk>().weakCall == true)
        {
            StartCoroutine(WeakEffect());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) //Quand le client est à la caisse déclenche le srcipt d'achat
    {
        collision.GetComponent<Talk>().DeclencherDialogueIwai();
        clientALaCaisse = true;
        clientEnCaisse = collision.gameObject;
        classeDuClient = clientEnCaisse.GetComponent<Customers>().client;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        clientALaCaisse = false;
    }

    public void SkipButton()
    {
        clientEnCaisse.GetComponent<Talk>().SuiteDialogue();
    }

    public void Accepter()
    {
        clientEnCaisse.GetComponent<Talk>().Refus = false;
        item.AppelAchat();
        clientEnCaisse.GetComponent<Talk>().ReponseBox.SetActive(false);
        if (pauvre == true)
        {
            pauvre = false;
            clientEnCaisse.GetComponent<Talk>().Pauvre();
        }
        else
        {
            clientEnCaisse.GetComponent<Talk>().FinDialogue();
        }
        
    }

    public void Refuser()
    {
        clientEnCaisse.GetComponent<Talk>().Refus = true;
        clientEnCaisse.GetComponent<Talk>().ReponseBox.SetActive(false);
        clientEnCaisse.GetComponent<Talk>().FinDialogue();
    }

    IEnumerator WeakEffect()
    {
        clientEnCaisse.GetComponent<Talk>().weakCall = false;
        audioSource.PlayOneShot(clip, 1.00f);
        yield return new WaitForSeconds(0.3f);
        WeakImage.SetActive(true);
        yield return new WaitForSeconds(3.1f);
        WeakImage.SetActive(false);


    }
}
