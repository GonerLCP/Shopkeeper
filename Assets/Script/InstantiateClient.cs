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
    public List<GameObject> InstantiatePrefab = new List<GameObject>();

    //Rachat de stock
    public TMP_Dropdown dropdownArmes;
    public Items script;

    //Argent magasin
    public TMP_Text displayArgent;
    public DestroyScript destroyScript;

    private void FixedUpdate()
    {
        if (destroyScript.PersoDetruit==true)
        {
            destroyScript.PersoDetruit = false;
            creerClient();
        }
    }
    public void creerClient() //A l'appuye d'un bouton ca cr�e un client, en faites pas spawn plusieurs en m�me temps svp
    {
        Instantiate(InstantiatePrefab.ElementAt(Random.Range(0,InstantiatePrefab.Count)), this.transform);

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
