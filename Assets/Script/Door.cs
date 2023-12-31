using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject doorParent;
    public string doorOpenAnimName, doorCloseAnimName;
    Animator doorAnim;

    private void Start()
    {
        doorAnim = doorParent.GetComponent<Animator>();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            doorAnim.ResetTrigger("Close");
            doorAnim.SetTrigger("Open");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            doorAnim.ResetTrigger("Open");
            doorAnim.SetTrigger("Close");
    }
}
