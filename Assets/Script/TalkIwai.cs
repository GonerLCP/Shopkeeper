using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TalkIwai : MonoBehaviour
{
    public TMP_Text dialogue;
    public TMP_Text nomTxtBox;
    public GameObject IwaiTextBox;
    public GameObject SpriteBox;

    public InstantiateClient instantiateClient;

    public string nom;
    public Sprite image;

    public List<string> PhraseaDire = new List<string>();

    public int phrase;
    public int tillGameOver;

    bool doOnce;
    bool GameOver;

    // Start is called before the first frame update
    void Start()
    {
        phrase = 0;
        SpriteBox.GetComponent<Image>().sprite = image;
        nomTxtBox.text = nom;
        IwaiTextBox.SetActive(false);
        tillGameOver = 3;
        doOnce = true;
        GameOver = false;

        DeclencherDialogueIwai();
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
    public void DeclencherDialogueIwai()
    {
        IwaiTextBox.SetActive(true);
        phrase++;
        StartCoroutine(TaperLeettrePar(PhraseaDire.ElementAt(0)));
    }


    public void SuiteDialogue()
    {
        if (GameOver == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
        }
        if (phrase < PhraseaDire.Count)
        {
            phrase++;
            StopAllCoroutines();
            StartCoroutine(TaperLeettrePar(PhraseaDire.ElementAt(phrase - 1)));
        }
        else
        {
            if (doOnce == true)
            {
                doOnce = false;
                instantiateClient.creerClient();
            }
            IwaiTextBox.SetActive(false);
        }
    }


    public void IwaiEngueule()
    {
        tillGameOver--;
        if (tillGameOver >= 1)
        {
            IwaiTextBox.SetActive(true);
            StartCoroutine(TaperLeettrePar("Tu te fous ma gueule ? Il te reste " + tillGameOver.ToString() + " erreurs !"));
        }
        else
        {
            GameOver = true;
            IwaiTextBox.SetActive(true);
            StartCoroutine(TaperLeettrePar("Allez c'est bon dégage de la !"));
        }

    }
}
