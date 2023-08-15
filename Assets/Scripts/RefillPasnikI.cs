using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RefillPasnikI : MonoBehaviour
{
    public GameObject pasnik_pelny;
    public GameObject pasnik_pusty;
    public GameObject HayBar;
    public HayBar hayBar;
    public GameObject sklepMenu;
    public GameController gameController;

    public GameObject popUp;

    public GameObject aparat;
    public SaveState saveState;

    private LeanTweenManager ltm;

    Camera mainCamera;

    void Awake()
    {
        aparat = GameObject.FindGameObjectWithTag("aparatButton");
        mainCamera = Camera.main;
        ltm = GameObject.FindGameObjectWithTag("LeanTween").GetComponent<LeanTweenManager>();
    }

    void OnMouseUp()
    {
        if (!IsPointerOverUIObject())
        {        
            if (!aparat.GetComponent<PhotoMode>().photoModeOn)
            {
                hayBar.SetHay(saveState.GetHayAmount());
                HayBar.SetActive(true);

            }
        }
    }

    public void RefillOnce()
    {
        int cena = 5;
        popUp.SetActive(false);
        //set progress bar as 1/1
        if ( saveState.pieniazki >= cena && !pasnik_pelny.activeSelf && pasnik_pusty.activeSelf)
        {
            pasnik_pelny.SetActive(true);
            saveState.pieniazki -= cena;
            
            saveState.SetHayAmount(1);
            hayBar.SetHayMax(1);
            hayBar.SetHay(1);

            ltm.SlideUp();
            gameController.SetMenuFalse();
            mainCamera.GetComponent<UpdateMoney>().MoneyUpdate();
        }
        else if (pasnik_pusty.activeSelf)
        {
            //komunikat
            popUp.SetActive(true);
        }
    }

    public void RefilThrice()
    {
        popUp.SetActive(false);
        int cena = 12;
        //zamiast pasnik pelny active self, sprawdzamy czy ilosc ladunkow siana jest mniejsza niz 3
        if (saveState.pieniazki >= cena && !pasnik_pelny.activeSelf && pasnik_pusty.activeSelf)
        {
            pasnik_pelny.SetActive(true);
            saveState.pieniazki -= cena;

            saveState.SetHayAmount(3);
            hayBar.SetHayMax(3);
            hayBar.SetHay(3);

            ltm.SlideUp();
            gameController.SetMenuFalse();
            mainCamera.GetComponent<UpdateMoney>().MoneyUpdate();

        }
        else if(pasnik_pusty.activeSelf)
        {
            popUp.SetActive(true);

        }

    }


    public void RefilWithSpecial()
    {
        //set special

    }

    private bool IsPointerOverUIObject()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return true;

        for (int touchIndex = 0; touchIndex < Input.touchCount; touchIndex++)
        {
            Touch touch = Input.GetTouch(touchIndex);
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                return true;
        }

        return false;
    }
}
