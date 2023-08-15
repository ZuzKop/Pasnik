using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUlepszenia : MonoBehaviour
{
    public GameObject pasnikUkladZero;
    public GameObject pasnikUkladJeden;
    public GameObject pasnikUkladDwa;
    public GameObject skrzyniaUkladZero;
    public GameObject skrzyniaUkladJeden;
    public GameObject skrzyniaUkladDwa;

    public GameObject pUkladZeroBlocked;
    public GameObject pUkladZeroUnlocked;
    public GameObject pUkladJedenBlocked;
    public GameObject pUkladJedenUnlocked;
    public GameObject pUkladDwaBlocked;
    public GameObject pUkladDwaUnlocked;

    public GameObject sUkladZeroBlocked;
    public GameObject sUkladZeroUnlocked;
    public GameObject sUkladJedenBlocked;
    public GameObject sUkladJedenUnlocked;
    public GameObject sUkladDwaBlocked;
    public GameObject sUkladDwaUnlocked;


    public Tutorial tutorial;

    public GameObject pasnik_nowy;
    public GameObject pasnik;
    public GameObject pasnik_pelny;
    public GameObject skrzynia;
    public GameObject skrzynia_nowa;

    public GameObject popUp;

    public Camera cam;
    public SaveState saveState;
    public HayBar hayBar;
    public FruitBar fruitBar;


    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
    }

    public void SetAccurateMenu()
    {
        Debug.Log("posiadane pieniadze: " + saveState.GetPieniazki() + " posiadane zdjecia: " + saveState.HowManyPhotosTotal());

        pasnikUkladZero.SetActive(false);
        pasnikUkladJeden.SetActive(false);
        pasnikUkladDwa.SetActive(false);

        //najpierw ustawianie pasnika
        if(pasnik_nowy.activeSelf)
        {
            Debug.Log("Set uklad 2");
            pasnikUkladDwa.SetActive(true);
            if (CheckPrice("cena_p") && CheckPhotos("zdjecia_p"))
            {
                pUkladDwaUnlocked.SetActive(true);
                pUkladDwaBlocked.SetActive(false);
            }
            else
            {
                pUkladDwaUnlocked.SetActive(false);
                pUkladDwaBlocked.SetActive(true);
            }
        }
        else if(pasnik.activeSelf)
        {
            Debug.Log("Set uklad 1");
            pasnikUkladJeden.SetActive(true);
            if (CheckPrice("cena_p") && CheckPhotos("zdjecia_p"))
            {
                pUkladJedenUnlocked.SetActive(true);
                pUkladJedenBlocked.SetActive(false);
            }
            else
            {
                pUkladJedenUnlocked.SetActive(false);
                pUkladJedenBlocked.SetActive(true);
            }
        }
        else //zaden pasnik nie jest aktywny
        {
            Debug.Log("Set uklad 0");
            pasnikUkladZero.SetActive(true);
            Debug.Log(CheckPrice("cena_p"));
            if (CheckPrice("cena_p"))
            {
                pUkladZeroUnlocked.SetActive(true);
                pUkladZeroBlocked.SetActive(false);
            }
            else
            {
                pUkladZeroUnlocked.SetActive(false);
                pUkladZeroBlocked.SetActive(true);
            }

        }

        skrzyniaUkladJeden.SetActive(false);
        skrzyniaUkladZero.SetActive(false);
        skrzyniaUkladDwa.SetActive(false);

        //teraz skrzynie
        if(skrzynia.activeSelf)
        {
            skrzyniaUkladJeden.SetActive(true);
            if (CheckPrice("cena_s") && CheckPhotos("zdjecia_s"))
            {
                sUkladJedenUnlocked.SetActive(true);
                sUkladJedenBlocked.SetActive(false);
            }
            else
            {
                sUkladJedenUnlocked.SetActive(false);
                sUkladJedenBlocked.SetActive(true);
            }
        }
        else if(skrzynia_nowa.activeSelf)
        {
            skrzyniaUkladDwa.SetActive(true);
            if (CheckPrice("cena_s") && CheckPhotos("zdjecia_s"))
            {
                sUkladDwaUnlocked.SetActive(true);
                sUkladDwaBlocked.SetActive(false);
            }
            else
            {
                sUkladDwaUnlocked.SetActive(false);
                sUkladDwaBlocked.SetActive(true);
            }
        }
        else
        {
            skrzyniaUkladZero.SetActive(true);
            if (CheckPrice("cena_s") && CheckPhotos("zdjecia_s"))
            {
                sUkladZeroUnlocked.SetActive(true);
                sUkladZeroBlocked.SetActive(false);
            }
            else
            {
                sUkladZeroUnlocked.SetActive(false);
                sUkladZeroBlocked.SetActive(true);
            }
        }
    }

    bool CheckPrice(string tag)
    {
        GameObject cenaGO = GameObject.FindWithTag(tag);
        int cena = int.Parse(cenaGO.GetComponent<UnityEngine.UI.Text>().text);
        Debug.Log("cena: " + cena);

        bool cenaOk;

        if (cena <= saveState.GetPieniazki())
        {
            cenaOk = true;
        }
        else cenaOk = false;

        return cenaOk;

    }

    bool CheckPhotos(string tag)
    {
        GameObject zdjeciaGO = GameObject.FindWithTag(tag);
        bool zdjeciaOk;

        if (zdjeciaGO)
        {
            int zdjeciaLicznik = int.Parse(zdjeciaGO.GetComponent<UnityEngine.UI.Text>().text);

            if (zdjeciaLicznik > saveState.HowManyPhotosTotal())
            {
                zdjeciaOk = false;
            }
            else zdjeciaOk = true;
        }
        else zdjeciaOk = true;

       return zdjeciaOk;
    }

    public void BuyObjectPasnik()
    {
        bool block = false;
        GameObject cenaGO = GameObject.FindWithTag("cena_p");
        int cena = int.Parse(cenaGO.GetComponent<UnityEngine.UI.Text>().text);

        if (CheckPrice("cena_p") && CheckPhotos("zdjecia_p"))
        {
            if(pasnik.activeSelf)
            {
                pasnik.SetActive(false);
                pasnik_pelny.SetActive(false);

                pasnik_nowy.SetActive(true);
            }
            else if(pasnik_nowy.activeSelf)
            {
                //cos tu sie stanie jak bedzie jeszcze lepszy pasnik, kiedys
                block = true;

            }
            else
            {
                pasnik.SetActive(true);
                tutorial.PasnikBought();

            }

            if(!block)
            {
                int currentPieniazki = saveState.GetPieniazki();
                saveState.SetPieniazki(currentPieniazki - cena);
                cam.GetComponent<UpdateMoney>().MoneyUpdate();

                saveState.SetHayAmount(0);
                saveState.SetHayMax(1);
                hayBar.SetHay(0);
                hayBar.SetHayMax(1);
            }

            SetAccurateMenu();
        }
        else
        {
            popUp.SetActive(true);
        }
    }
    

    public void BuyObjectCrate()
    {
        bool block = false;
        GameObject cenaGO = GameObject.FindWithTag("cena_s");
        int cena = int.Parse(cenaGO.GetComponent<UnityEngine.UI.Text>().text);

        if (CheckPrice("cena_s") && CheckPhotos("zdjecia_s"))
        {
            if (skrzynia.activeSelf)
            {
                skrzynia_nowa.SetActive(true);
                skrzynia.SetActive(false);
            }
            else if (skrzynia_nowa.activeSelf)
            {
                //jeszcze lepsza skrzynia
                block = true;
            }
            else
            {
                skrzynia.SetActive(true);
            }

            if(!block)
                {
                int currentPieniazki = saveState.GetPieniazki();
                saveState.SetPieniazki(currentPieniazki - cena);
                cam.GetComponent<UpdateMoney>().MoneyUpdate();
            }

            SetAccurateMenu();
        }
        else
        {
            popUp.SetActive(true);
        }
    }
}
