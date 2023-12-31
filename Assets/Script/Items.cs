using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.PackageManager;
using UnityEngine;

public class Items : MonoBehaviour
{
    public SpriteRenderer Joker; //Feature pas encore implémenté de sprite d'objet
    public List<Magasin> Boutique = new List<Magasin>();
    public List<Arme> Inventaire = new List<Arme>();
    public List<Client> Cli = new List<Client>();
    public CaisseTrigger caisseTrigger;
    public Customers customers;

    // Start is called before the first frame update
    void Start()
    {
        //Initialisation du stock
        Inventaire.Add(new Arme("Joker's Gun", Joker, 1800, 40, 96, 10, "L'arme du plus charismatique des Phantom Thieves", Arme.TypeDarme.Pistolet, 3));
        Inventaire.Add(new Arme("Skull's Shotgun", Joker, 2200, 60, 85, 6, "Ca fait bam, des fois boom et c'est déjà pas mal", Arme.TypeDarme.FusilAPompe, 3));
        Inventaire.Add(new Arme("Mona's Slingshot", Joker, 1600, 34, 90, 17, "Littéralement une reviste de david contre goliath (à peu de choses près)", Arme.TypeDarme.LancePierre, 3));
        Inventaire.Add(new Arme("Panther's rifle", Joker, 2000, 13, 50, 35, "Elle fait tomber le coeur de ses ennemmis et chamboule celui des phantom thieves", Arme.TypeDarme.Mitraillette, 3));


        //Initialisation de la boutique
        Boutique.Add(new Magasin(10000, 20));


    }

    public void AppelAchat()
    {
        //StartCoroutine(Achat(caisseTrigger.classeDuClient, Inventaire.ElementAt(caisseTrigger.classeDuClient._tricheparcequejesaispasutiliserlesEnum), Boutique.ElementAt(0),caisseTrigger));
        print("Un client veux acheter un objet");
        caisseTrigger.classeDuClient.Acheter(caisseTrigger.classeDuClient, Inventaire.ElementAt(caisseTrigger.classeDuClient._tricheparcequejesaispasutiliserlesEnum), Boutique.ElementAt(0), caisseTrigger);
        print("Il à acheté un truc");
    }

    IEnumerator Achat(Client client, Arme arme, Magasin magasin, CaisseTrigger caisseTrigger) //Utilisation de Coroutine pour avoir un petit délai lors de l'achat
    {
        print("Un client veux acheter un objet");
        yield return new WaitForSeconds(0.1f);
        client.Acheter(client,arme,magasin,caisseTrigger);
        print("Il à acheté un truc");
        //CaisseTrigger.clientEnCaisse.GetComponent<Customers>().peutTourner = true;
        //doOnce = true;
    }

}


[System.Serializable]
public class Magasin
{
    //Désolé j'ai pas réussi à faire qqch des constructeurs, j'ai tout mis en public comme un sagouin, j'essaierai de faire un truc plus académique à l'avenir, mais j'ai quand même fait l'effort de mettre un constructeur pour la forme
    public int _argent;
    public int _stock;

    public Magasin(int argent, int stock)
    {
        _argent = argent;
        _stock = stock;
    }
}


[System.Serializable]
public class Arme
{
    public string _name;
    public SpriteRenderer _sprite;
    public int _price;
    public int _atkStat;
    public int _preStat;
    public int _bullets;
    public string _description;
    public int _stock;

    public enum TypeDarme
    {
        Pistolet,
        FusilAPompe,
        Mitraillette,
        LancePierre,
        Fusil,
        Revolver,
        LanceGrenade
    }
    public TypeDarme typeDarme;

    public Arme(string name, SpriteRenderer sprite, int price, int atkStat, int preStat, int bullets, string description, TypeDarme typeDarme, int stock)
    {
        this._name = name;
        this._sprite = sprite;
        this._price = price;
        _atkStat = atkStat;
        _preStat = preStat;
        _bullets = bullets;
        this._description = description;
        _stock = stock;
    }
}


[System.Serializable]
public class Client
{
    public string _nom;
    public int _argent;
    public int _tricheparcequejesaispasutiliserlesEnum;
    public bool _flic;
    public enum TypeDarme
    {
        Pistolet,
        FusilAPompe,
        Mitraillette,
        LancePierre,
        Fusil,
        Revolver,
        LanceGrenade
    }
    public TypeDarme typeDarme;

    public Client(string nom, int argent, TypeDarme typeDarme, int tricheparcequejesaispasutiliserlesEnum, bool flic)
    {
        this._nom = nom;
        this._argent = argent;
        this._tricheparcequejesaispasutiliserlesEnum = tricheparcequejesaispasutiliserlesEnum;
        this._flic = flic;
    }

    public void Acheter(Client client, Arme arme, Magasin magasin, CaisseTrigger caisseTrigger)
    {
        if (client._argent >= arme._price && arme._stock > 0) //Si assez d'argent et assez de stock, alors on fait les transactions qui vont bien
        {
            client._argent -= arme._price;
            magasin._argent += arme._price;
            magasin._stock -= 1;
            arme._stock -= 1;
        }
        else if(client._argent <= arme._price)
        {
            Debug.Log("Désolé vous n'avez pas assez d'argent");
        }
        else
        {
            caisseTrigger.pauvre = true;
            Debug.Log("Désolé nous n'avons plus cet article revenez plus tard");
        }
    }

}


