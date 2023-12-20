using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;


public class Talk : MonoBehaviour
{
    public TMP_Text dialogue;
    public TMP_Text nomTxtBox;
    //public string textToType;
    public GameObject IwaiTextBox;
    public GameObject SpriteBox;
    public List<string> PhraseaDire = new List<string>();
    public int phrase;
    public string nom;
    public Sprite image;

    // Start is called before the first frame update
    void Start()
    {
        IwaiTextBox.SetActive(false);
        nomTxtBox.text = nom;
        SpriteBox.GetComponent<Image>().sprite = image;
        phrase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeclencherDialogueIwai()
    {
        IwaiTextBox.SetActive(true);
        phrase++;
        StartCoroutine(TaperLeettrePar(PhraseaDire.ElementAt(0)));
    }

    public void SuiteDialogue()
    {
        if (phrase < PhraseaDire.Count)
        {
            phrase++;
            StartCoroutine(TaperLeettrePar(PhraseaDire.ElementAt(phrase-1)));
        }
        else
        {
            phrase = 0;
            IwaiTextBox.SetActive(false);
        }
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
