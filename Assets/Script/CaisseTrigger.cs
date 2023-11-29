using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaisseTrigger : MonoBehaviour
{
    public bool clientALaCaisse;
    // Start is called before the first frame update
    void Start()
    {
        clientALaCaisse = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        clientALaCaisse = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        clientALaCaisse = false;
    }
}
