using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;

public class Items : MonoBehaviour
{
    public SpriteRenderer Joker;
    public List<Magasin> Boutique = new List<Magasin>();
    public List<Arme> Inventaire = new List<Arme>();
    public List<Client> Cli = new List<Client>();
    public CaisseTrigger CaisseTrigger;
    bool doOnce;
    // Start is called before the first frame update
    void Start()
    {
        Inventaire.Add(new Arme("Joker's Gun", Joker, 1800, 40, 96, 10, "L'arme du plus charismatique des Phantom Thieves", Arme._typeDarme.Pistolet,3));
        Cli.Add(new Client("Makima", 10000, Client._typeDarme.Pistolet));
        Boutique.Add(new Magasin(10000, 20));
        doOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (doOnce == true && CaisseTrigger.clientALaCaisse == true)
        {
            StartCoroutine(Achat(Cli.ElementAt(0), Inventaire.ElementAt(0), Boutique.ElementAt(0)));
            doOnce = false;
        }
    }

    IEnumerator Achat(Client client, Arme arme, Magasin magasin)
    {
        print("Un client veux acheter un objet");
        yield return new WaitForSeconds(10);
        client.Acheter(client,arme,magasin);
        print("Il à acheté un truc");
    }

}


[System.Serializable]
public class Magasin
{
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

    public enum _typeDarme
    {
        Pistolet,
        FusilAPompe,
        Mitraillette,
        LancePierre,
        Fusil,
        Revolver,
        LanceGrenade
    }

    public Arme(string name, SpriteRenderer sprite, int price, int atkStat, int preStat, int bullets, string description, _typeDarme typeDarme, int stock)
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
    private string _nom;
    private int _argent;
    public enum _typeDarme
    {
        Pistolet,
        FusilAPompe,
        Mitraillette,
        LancePierre,
        Fusil,
        Revolver,
        LanceGrenade
    }

    public Client(string nom, int argent, _typeDarme typeDarme)
    {
        this._nom = nom;
        this._argent = argent;
    }

    public void Acheter(Client client, Arme arme, Magasin magasin)
    {
        if (client._argent >= arme._price)
        {
            client._argent -= arme._price;
            magasin._argent += arme._price;
            magasin._stock -= 1;
            arme._stock -= 1;
        }
    }
}


