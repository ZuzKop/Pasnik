using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RefillCrateI : MonoBehaviour
{
    public GameObject gruszki;
    public GameObject jablka;

    public FruitBar fruitBar;
    public GameObject FruitBarMenu;
    public GameObject sklepMenu;

    public SaveState saveState;
    Camera mainCamera;
    public GameController gameController;
    public GameObject popUp;

    public GameObject aparat;

    private LeanTweenManager ltm;

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
                fruitBar.SetFruit(saveState.GetFruitAmount());
                FruitBarMenu.SetActive(true);
            }

        }
    }

    public void RefillJablka()
    {
        popUp.SetActive(false);
        int cena = 10;
        if (saveState.pieniazki >= cena && saveState.fruitAmount == 0)
        {
            saveState.AddPieniazki(-cena);
            ltm.SlideUp();
            gameController.SetMenuFalse();

            saveState.SetFruitAmount(1);
            fruitBar.SetFruitMax(1);
            fruitBar.SetFruit(saveState.GetFruitAmount());

            jablka.SetActive(true);
            gruszki.SetActive(false);
            mainCamera.GetComponent<UpdateMoney>().MoneyUpdate();
        }
        else
        {
            popUp.SetActive(true);
        }
    }

    public void RefilGruszki()
    {
        popUp.SetActive(false);
        int cena = 25;
        if (saveState.pieniazki >= cena && saveState.fruitAmount < 3)
        {
            saveState.AddPieniazki(-cena);
            ltm.SlideUp();
            gameController.SetMenuFalse();
            gruszki.SetActive(true);
            jablka.SetActive(false);

            saveState.SetFruitAmount(3);
            fruitBar.SetFruitMax(3);
            fruitBar.SetFruit(saveState.GetFruitAmount());

            mainCamera.GetComponent<UpdateMoney>().MoneyUpdate();

        }
        else
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

