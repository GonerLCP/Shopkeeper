using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.UIElements;
using TMPro;

public class InstantiateClient : MonoBehaviour
{
    //Client
    public GameObject InstantiatePrefab;

    //Rachat de stock
    public TMP_Dropdown dropdownArmes;
    public Items script;

    //Argent magasin
    public TMP_Text displayArgent;

    private void FixedUpdate()
    {
        displayArgent.text = script.Boutique.ElementAt(0)._argent.ToString();
    }
    public void creerClient() //A l'appuye d'un bouton ca crée un client, en faites pas spawn plusieurs en même temps svp
    {
        Instantiate(InstantiatePrefab, this.transform);

    }

    public void RacheterDesArmes() //Rachat des armes si on a assez d'argent en fonction du dropdown menu (Les armes coutent 800 yens de moins que leur prix de base)
    {
        if (script.Boutique.ElementAt(0)._argent >= (script.Inventaire.ElementAt(dropdownArmes.value)._price-800))
        {
            script.Boutique.ElementAt(0)._argent -= (script.Inventaire.ElementAt(dropdownArmes.value)._price - 800);
            script.Inventaire.ElementAt(dropdownArmes.value)._stock += 1;
        }
    }
}
