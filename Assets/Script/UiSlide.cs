using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSlide : MonoBehaviour
{
    bool slided;
    public GameObject SlideParent;
    Animator slideAnim;

    public MenuInventaire menuInventaire;
    // Start is called before the first frame update
    void Start()
    {
        slided = false;
        slideAnim = SlideParent.GetComponent<Animator>();
    }


    public void Slide()
    {
        menuInventaire.RemplirLesTrucs();
        if (slided)
        {
            slided = false;
            slideAnim.ResetTrigger("SlideIn");
            slideAnim.SetTrigger("SlideOut");
        }
        else
        {
            slided = true;
            slideAnim.ResetTrigger("SlideOut");
            slideAnim.SetTrigger("SlideIn");
        }
    }
}
