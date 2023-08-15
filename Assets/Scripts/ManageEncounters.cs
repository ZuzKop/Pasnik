using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManageEncounters: MonoBehaviour
{
    DateTime currentDate;

    public GameObject pasnik_pusty;
    public GameObject pasnik_pelny;
    public GameObject pasnik_lepszy_pusty;
    public GameObject pasnik_lepszy_pelny;

    public GameObject jablka;
    public GameObject gruszki;

    public GameObject jelonek;
    public GameObject lania;
    public GameObject koziol;
    public GameObject sarna;
    public GameObject dzik;
    public GameObject los;
    public GameObject losza;

    public SaveState saveState;
    public SaveManager saveManager;
    public TimeManager timeManager;

    public GameObject[] jedzenia_sprites;

    public HayBar hayBar;
    public FruitBar fruitBar;

    public Tutorial tutorial;

    int majorTimeDiff = 10;

    void Awake()
    {

    }


    public void RandomiseAnimals()
    {
        int RandPas = 0;
        //HayEaters
        int visits = saveState.HowManyVisitsTotal(); //liczba wizyt przed dodaniem nowych w pierwszym losowaniu

        jelonek.SetActive(false);
        lania.SetActive(false); 
        sarna.SetActive(false); 
        koziol.SetActive(false); 

        bool jestSiano;
        if (pasnik_lepszy_pelny.activeSelf || pasnik_pelny.activeSelf)
        {
            jestSiano = true;
        }
        else jestSiano = false;

        if( jestSiano )
        {
            RandPas = UnityEngine.Random.Range(1, 8);


            switch (RandPas)
            {
                case 1://jelen
                    jelonek.SetActive(true); 
                    PlayerPrefs.SetInt("ile-jelonek", PlayerPrefs.GetInt("ile-jelonek") + 1);
                    break;

                case 2://lania
                    lania.SetActive(true);
                    PlayerPrefs.SetInt("ile-lania", PlayerPrefs.GetInt("ile-lania") + 1);
                    break;

                case 3://jelen i lania
                    jelonek.SetActive(true);
                    PlayerPrefs.SetInt("ile-jelonek", PlayerPrefs.GetInt("ile-jelonek") + 1);
                    lania.SetActive(true);
                    PlayerPrefs.SetInt("ile-lania", PlayerPrefs.GetInt("ile-lania") + 1);
                    break;

                case 4://koziolek
                    koziol.SetActive(true);
                    PlayerPrefs.SetInt("ile-koziol", PlayerPrefs.GetInt("ile-koziol") + 1);
                    break;

                case 5://sarna
                    sarna.SetActive(true);
                    PlayerPrefs.SetInt("ile-sarna", PlayerPrefs.GetInt("ile-sarna") + 1);
                    break;

                case 6://koziolek i sarna
                    koziol.SetActive(true);
                    PlayerPrefs.SetInt("ile-koziol", PlayerPrefs.GetInt("ile-koziol") + 1);
                    sarna.SetActive(true);
                    PlayerPrefs.SetInt("ile-sarna", PlayerPrefs.GetInt("ile-sarna") + 1);
                    break;

                default://nikt
                    if(visits == 0)
                    {
                        sarna.SetActive(true);
                        PlayerPrefs.SetInt("ile-sarna", PlayerPrefs.GetInt("ile-sarna") + 1);
                        tutorial.FirstAnimal();

                    }
                    break;
            }
        }


        //FruitEaters
        bool sterta = false;
        if(saveState.GetFruitAmount() > 0 ) sterta = true; else sterta = false;

        dzik.SetActive(false);
        losza.SetActive(false);
        los.SetActive(false);

        if(sterta)
        {
            RandPas = UnityEngine.Random.Range(1, 8);
            switch (RandPas)
            {
                case 1://dzik
                    dzik.SetActive(true);
                    PlayerPrefs.SetInt("ile-dzik", PlayerPrefs.GetInt("ile-dzik") + 1);
                    break;
                case 2://locha

                    break;

                case 3://dzik i locha
                    break;

                case 4://losza
                    losza.SetActive(true);
                    PlayerPrefs.SetInt("ile-losza", PlayerPrefs.GetInt("ile-losza") + 1);
                    break;

                case 5://los
                    los.SetActive(true);
                    PlayerPrefs.SetInt("ile-los", PlayerPrefs.GetInt("ile-los") + 1);
                    break;

                case 6://los i losza
                    losza.SetActive(true);
                    PlayerPrefs.SetInt("ile-losza", PlayerPrefs.GetInt("ile-losza") + 1);
                    los.SetActive(true);
                    PlayerPrefs.SetInt("ile-los", PlayerPrefs.GetInt("ile-los") + 1);
                    break;


                default:
                    break;
            }
        }
    }

    public void EatFood()
    {
        jedzenia_sprites = GameObject.FindGameObjectsWithTag("Jedzenie");

    
        /*istnieje 5% szansy, ze jedzenie zostanie w pasniku po dlugim okresie nieobecnosci(10h)
        if (timeManager.TimeInHours() > majorTimeDiff)
        {

            int Chance = UnityEngine.Random.Range(1, 21);
            switch (Chance)
            {
                case 1:
                    break;

                default:
                    if (saveState.GetHayAmount() > 0) saveState.EatHay();
                    if(saveState.GetFruitAmount() > 0) saveState.EatFruit();
                    break;
            }

            if(saveState.GetFruitAmount() == 0)
            {
                foreach (GameObject go in jedzenia_sprites)
                {
                    go.SetActive(false);
                }
            }

        }
        */
        
        if(CheckHayeaters())
        {
            saveState.EatHay();
            if (saveState.GetHayAmount() < 0)
            {
                Debug.Log("ilosc siana mniej niz 0");
            }
        }

        if (saveState.GetHayAmount() <= 0)
        {
            pasnik_pelny.SetActive(false);
            pasnik_lepszy_pelny.SetActive(false);
        }

        if(CheckFruiteaters())
        {
            saveState.EatFruit();
            if (saveState.GetFruitAmount() < 0)
            {
                Debug.Log("ilosc owocow mniej niz 0");
            }
        }
        if (saveState.GetFruitAmount() <= 0)
        {
        jablka.SetActive(false);
        gruszki.SetActive(false);
        }

        hayBar.SetHay(saveState.GetHayAmount());
        fruitBar.SetFruit(saveState.GetFruitAmount());
    }
        

    private bool CheckHayeaters() //1=they were there  0=theywerent
    {
        if(sarna.activeSelf || jelonek.activeSelf || lania.activeSelf || koziol.activeSelf)
        {
            return true;
        }
        else return false;
    }

    private bool CheckFruiteaters()
    {
        if( dzik.activeSelf || losza.activeSelf  || los.activeSelf )
        {
            return true;
        }
        else return false;
    }
   
}
