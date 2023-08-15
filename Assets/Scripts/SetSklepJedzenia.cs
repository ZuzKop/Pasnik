using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSklepJedzenia : MonoBehaviour
{
    public GameObject owoce;
    public GameObject owoceBlocked;

    public GameObject siano;
    public GameObject sianoBlocked;

    public GameObject pasnikJeden;
    public GameObject pasnikDwa;
    public GameObject skrzynia;
    public GameObject skrzyniaNowa;


    // Start is called before the first frame update
    public void OnEnable()
    {
        if(pasnikJeden.activeSelf || pasnikDwa.activeSelf)
        {
            siano.SetActive(true);
            sianoBlocked.SetActive(false);
        }
        else
        {
            siano.SetActive(false);
            sianoBlocked.SetActive(true);
        }

        if(skrzynia.activeSelf || skrzyniaNowa.activeSelf )
        {
            owoce.SetActive(true);
            owoceBlocked.SetActive(false);
        }
        else
        {
            owoce.SetActive(false);
            owoceBlocked.SetActive(true);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
