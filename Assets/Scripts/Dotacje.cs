using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dotacje : MonoBehaviour
{
    public int dotacja;
    public TimeManager timeManager;
    public Camera mainCam;
    public SaveState saveState;

    public GameObject PanelDotacja;
    public GameObject BrakDotacji;
    public Text kwota;
    public GameObject alert;


    void Awake()
    {
        mainCam = Camera.main;
    }

    public int GetDotacje()
    {
        return dotacja;
    }

    public void SetDotacje( int dot)
    {
        dotacja = dot;
    }

    public void CalculateDotacje()
    {
        PanelDotacja.SetActive(true);
        BrakDotacji.SetActive(false);
        alert.SetActive(true);

        int random;

        if ( timeManager.TimeInMinutes() > 60)
        {
            int multiplier = 1;
            if (timeManager.TimeInHours() < 10)
            {
                multiplier = timeManager.TimeInHours();
            }
            else { multiplier = 10;  }

            random = UnityEngine.Random.Range(2, 7);

            dotacja += random * multiplier;
        }
        else if (timeManager.TimeInMinutes() > 10)
        {
            random = UnityEngine.Random.Range(1, 6);
            dotacja += random;
        }
        else if(dotacja == 0)
        {
            PanelDotacja.SetActive(false);
            BrakDotacji.SetActive(true);
            alert.SetActive(false);
        }
    
        kwota.text = dotacja.ToString(); 
    }

    public void ClaimDotacje()
    {
        if(PanelDotacja.activeSelf)
        {
            int pieniadze = saveState.GetPieniazki();
            pieniadze += dotacja;
            dotacja = 0;
            saveState.SetPieniazki(pieniadze);
            mainCam.GetComponent<UpdateMoney>().MoneyUpdate();
            PanelDotacja.SetActive(false);
            BrakDotacji.SetActive(true);
            alert.SetActive(false);
        }
    }

}
