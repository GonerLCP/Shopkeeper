using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;


public class Talk : MonoBehaviour
{
    public Customers customers;

    public TMP_Text dialogue;
    public TMP_Text nomTxtBox;
    public GameObject canvas;
    public GameObject IwaiTextBox;
    public GameObject ReponseBox;
    public GameObject SpriteBox;

    public string nom;
    public Sprite image;
    public Button bouton;

    public List<string> PhraseaDire = new List<string>();
    public List<string> PhrasesRefus= new List<string>();
    public List<string> PhrasesAccepte = new List<string>();

    public int phrase;

    public bool Reponse;
    public bool Refus;
    public bool policed;
    public bool weakCall;

    // Start is called before the first frame update
    void Start()
    {
        customers = GetComponent<Customers>();
        canvas = GameObject.Find("CanvasDialogues");

        IwaiTextBox = canvas.transform.GetChild(0).gameObject;
        SpriteBox = IwaiTextBox.transform.GetChild(0).gameObject;
        SpriteBox.GetComponent<Image>().sprite = image;
        dialogue = IwaiTextBox.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        nomTxtBox = IwaiTextBox.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        nomTxtBox.text = nom;
        bouton = IwaiTextBox.transform.GetChild(4).GetComponent<Button>();
        IwaiTextBox.SetActive(false);


        ReponseBox = canvas.transform.GetChild(1).gameObject;
        ReponseBox.SetActive(false);

        Reponse = false;
        Refus = false;
        weakCall = false;
        phrase = 0;
    }

    public void DeclencherDialogueIwai()
    {
        IwaiTextBox.SetActive(true);
        phrase++;
        StartCoroutine(TaperLeettrePar(PhraseaDire.ElementAt(0)));
    }

    public void SuiteDialogue()
    {
        if (Reponse == true)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            customers.peutTourner = true;
            IwaiTextBox.SetActive(false);
            if(policed == true)
            {
                policed = false;
                GameObject.Find("MainTruc").GetComponent<TalkIwai>().IwaiEngueule();
            }
        }
        if (phrase < PhraseaDire.Count)
        {
            phrase++;
            StopAllCoroutines();
            StartCoroutine(TaperLeettrePar(PhraseaDire.ElementAt(phrase-1)));
        }
        else if (Reponse == false)
        {
            phrase = 0;
            Reponse = true;
            ReponseBox.SetActive(true);
            //IwaiTextBox.SetActive(false);
        }
    }

    public void FinDialogue()
    {
        if (Refus == false)
        {
            StartCoroutine(TaperLeettrePar(PhrasesAccepte.ElementAt(0)));
            if (customers.client._flic == true)
            {
                policed = true;
            }
        }
        else
        {
            if (customers.client._flic == true)
            {
                weakCall = true;
            }
            StartCoroutine(TaperLeettrePar(PhrasesRefus.ElementAt(0)));
        }
    }

    public void Pauvre()
    {
        StartCoroutine(TaperLeettrePar("Quoi ? Vous l'avez plus ? Bon, je revienderais plus tard..."));
    }
    IEnumerator TaperLeettrePar(string textToType)
    {
        dialogue.text = string.Empty;

        for (int i = 0; i < textToType.Length; i++)
        {
            dialogue.text += textToType[i];
            yield return new WaitForSeconds(0.03f);
        }
    }
}
