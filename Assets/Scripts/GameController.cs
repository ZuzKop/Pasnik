using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menu;

    public GameObject tutorial;

    public bool menuOn;
    public SaveManager saveManager;
    public TimeManager timeManager;
    public SaveState saveState;
    public ManageEncounters encounterManager;
    public Dotacje dotacje;

    int minorTimeDiff = 10;

    public int First;

    public HayBar hayBar;
    public FruitBar fruitBar;

    Camera mainCam;


    void Awake()
    {
        mainCam = Camera.main;
        menuOn = false;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus)
        {
            //Pobieranie nowej daty w celu sprawdzenia
            timeManager.SetNewTime(System.DateTime.Now);

            //Sprawdzanie czy jest to piersze uruchomienie gry (brak zapisu)
            First = PlayerPrefs.GetInt("First");
            if (First == 0)
            {
                Debug.Log("First time in app.");

                tutorial.SetActive(true); //Uruchomienie sekwencji tutorialu

                timeManager.SetOldTime(timeManager.GetNewTime());//Ustawienie starego czasu jako nowy czas, żeby stary czas nie miał wartości null

                //ustawianie wskaźników stanu jedzenia w paśniku i skrzyni na "0/1"
                hayBar.SetHayMax(1);
                hayBar.SetHay(0);

                fruitBar.SetFruitMax(1);
                fruitBar.SetFruit(0);

                //Ustawienie ilości posiadanych Pieniazkow na 0 oraz aktualizacja wszystkich wskaźników Pieniazkow
                saveState.SetPieniazki(0);
                mainCam.GetComponent<UpdateMoney>().MoneyUpdate();


            }
            else //nie jest to pierwsze uruchomienie gry, wczytanie zapisu
            {
                Debug.Log("Not the first time in app.");
                saveManager.Load(); //wczytanie gry
                dotacje.CalculateDotacje(); //uruchomienie funkcji przyznawającej Dotacje

            }

            //Zapis zostal zaladowany
            if (timeManager.TimeInMinutes() > minorTimeDiff)
            {
                Debug.Log("It's been more than 10 minutes sience last time.");
                encounterManager.EatFood(); //Eat Food musi byc zawsze przed Randomise(sprawdzanie czy zwierze bylo ostatnio przy pasniku)
                encounterManager.RandomiseAnimals();
            }
            else
            {
                Debug.Log("It's been less than 10 minutes sience last time.");
            }            
            
            /*Zamknięcie menus po zminimalizowaniu
            foreach (Transform child in menu.transform) { child.gameObject.SetActive(false); }
            */

        }
        if (pauseStatus)
        {
            saveManager.Save(); //zapis po wyjsciu z gry
        }
    }


    public void SetMenuFalse()
    {
        menuOn = false;
    }
    public void SetMenuTrue()
    {
        menuOn = true;
    }
    public bool GetMenuOn()
    {
        return menuOn;
    }
}
