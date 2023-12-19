using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Talk : MonoBehaviour
{
    public TMP_Text dialogue;
    public string textToType;
    public GameObject IwaiTextBox;

    // Start is called before the first frame update
    void Start()
    {
        IwaiTextBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeclencherDialogueIwai()
    {
        IwaiTextBox.SetActive(true);
        StartCoroutine(TaperLeettrePar());

    }

    IEnumerator TaperLeettrePar()
    {
        dialogue.text = string.Empty;

        for (int i = 0; i < textToType.Length; i++)
        {
            dialogue.text += textToType[i];
            yield return new WaitForSeconds(0.03f);
        }
    }
}
