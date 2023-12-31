using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class MenuInventaire : MonoBehaviour
{
    public GameObject canvas;
    public GameObject LimageLa;
    public GameObject lemptyla;

    public TMP_Text nomTxtBox;
    public TMP_Text prixTxtBox;
    public TMP_Text qteTxtBox;

    public TMP_Text argent;

    public Items item;

    public int moinsPrixDeRachat;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("CanvasMenu");
        LimageLa = canvas.transform.GetChild(0).gameObject;
        argent = LimageLa.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        RemplirLesTrucs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemplirLesTrucs()
    {
        argent.text = item.Boutique.ElementAt(0)._argent.ToString();
        for (int i = 0; i < 4; i++)
        {
            lemptyla = LimageLa.transform.GetChild(i).gameObject;

            lemptyla.transform.GetChild(0).GetComponent<TMP_Text>().text = item.Inventaire.ElementAt(i)._name;
            lemptyla.transform.GetChild(1).GetComponent<TMP_Text>().text = item.Inventaire.ElementAt(i)._price.ToString();
            lemptyla.transform.GetChild(2).GetComponent<TMP_Text>().text = "x"+item.Inventaire.ElementAt(i)._stock.ToString();
        }
    }

    public void RacheterGun()
    {
        if (item.Boutique.ElementAt(0)._argent >= (item.Inventaire.ElementAt(0)._price - moinsPrixDeRachat))
        {
            item.Boutique.ElementAt(0)._argent -= (item.Inventaire.ElementAt(0)._price - moinsPrixDeRachat);
            item.Inventaire.ElementAt(0)._stock += 1;
            RemplirLesTrucs();
        }
    }

    public void RacheterFusil()
    {
        if (item.Boutique.ElementAt(0)._argent >= (item.Inventaire.ElementAt(1)._price - moinsPrixDeRachat))
        {
            item.Boutique.ElementAt(0)._argent -= (item.Inventaire.ElementAt(1)._price - moinsPrixDeRachat);
            item.Inventaire.ElementAt(1)._stock += 1;
            RemplirLesTrucs();
        }
    }

    public void RacheterLancePierre()
    {
        if (item.Boutique.ElementAt(0)._argent >= (item.Inventaire.ElementAt(2)._price - moinsPrixDeRachat))
        {
            item.Boutique.ElementAt(0)._argent -= (item.Inventaire.ElementAt(2)._price - moinsPrixDeRachat);
            item.Inventaire.ElementAt(2)._stock += 1;
            RemplirLesTrucs();
        }
    }

    public void RacheterMitrailette()
    {
        if (item.Boutique.ElementAt(0)._argent >= (item.Inventaire.ElementAt(3)._price - moinsPrixDeRachat))
        {
            item.Boutique.ElementAt(0)._argent -= (item.Inventaire.ElementAt(3)._price - moinsPrixDeRachat);
            item.Inventaire.ElementAt(3)._stock += 1;
            RemplirLesTrucs();
        }
    }


}
