using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MakePhoto : MonoBehaviour
{
    private SpriteRenderer kadr;
    private SpriteRenderer polaroid;
    private Vector2 newPosition;

    private GameObject polaroidGO;
    private SpriteRenderer whiteCanvas;

    private Coroutine coroutine;

    DateTime currentDate;

    private SaveManager saveManager;
    private bool flag;
    public SaveState saveState;
    public GameObject aparat;
    public TimeManager timeManager;
    public Tutorial tutorial;

    Camera mainCamera;

    void Awake()
    {
        polaroidGO = GameObject.FindGameObjectWithTag("polaroid");
        whiteCanvas = GameObject.FindGameObjectWithTag("white-canvas").GetComponent<SpriteRenderer>();

        polaroid = polaroidGO.GetComponent<SpriteRenderer>();
        kadr = GameObject.FindGameObjectWithTag("kadr").GetComponent<SpriteRenderer>();

        newPosition = transform.position;

        aparat = GameObject.FindGameObjectWithTag("aparatButton");

        mainCamera = Camera.main;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus)
        {
            currentDate = System.DateTime.Now;
            flag = false;

        }
    }


    void OnMouseDown()
    {
        //sprawdza, czy minelo wiecej niz 15 minut od zobaczenia tego zwierzecia, ale tylko raz
        //funkcja ta nie moze byc w start(), zeby jej wykoanie mialo miejsce po load()
        if (!flag)
        {
            if(timeManager.TimeInMinutes() > 10) PlayerPrefs.SetInt(name, 0);
            flag = true;
        }

        if (aparat.GetComponent<PhotoMode>().photoModeOn && PlayerPrefs.GetInt(name) == 0)
        {
            if (polaroid.enabled) //zdjecie zostało zrobione
            {
                polaroid.enabled = false;
                PlayerPrefs.SetInt(name, 1);

                //zrobione zdjecie, akcje:
                PlayerPrefs.SetInt(name + "Photo", PlayerPrefs.GetInt(name + "Photo") + 1);
                saveState.AddPieniazki(PhotoMoney(PhotoBonus()));
                saveState.UpdatePhotoCounter();

                if(saveState.HowManyPhotosTotal() == 1)
                {
                    tutorial.FirstPhoto();
                }

                mainCamera.GetComponent<UpdateMoney>().MoneyUpdate();
            }
            else if (!kadr.enabled && !polaroid.enabled)
            {
                GameObject.FindGameObjectWithTag("kadr").transform.position = newPosition;
                kadr.enabled = true;
            }
            else if (kadr.enabled && !polaroid.enabled)
            {
                kadr.enabled = false;
                coroutine = StartCoroutine(Flash());
                polaroidGO.transform.position = newPosition;
                polaroid.enabled = true;
            }

        }
        else if (PlayerPrefs.GetInt(name) == 1)
        {
            Debug.Log("Zakaz fotografowanie zwierzat");
        }

    }

    private IEnumerator Flash()
    {
        whiteCanvas.enabled = true;
        yield return new WaitForSeconds(0.1f);

        for (float i = 0.6f; i >= 0; i -= Time.deltaTime)
        {
            whiteCanvas.color = new Color(1, 1, 1, i);
            yield return null;
        }

        whiteCanvas.enabled = false;
        yield return coroutine;
    }


    int PhotoMoney(int Bonus)
    {
        int baseMoney = 1;
        List<string> list = new List<string> { "jelonek", "lania", "sarna", "koziol", "dzik", "locha", "los", "losza" };

        if (list.Contains(name))
        {
            baseMoney = 5;
        }
        else
        {
            Debug.Log("zwierze nie istnieje");
        }

        //else if ptaki == 2
        //else if nocne zwierzeta == 10
        //else if mlode = 20

        int money = baseMoney * PhotoBonus();

        return money;
    }

    int PhotoBonus()
    {
        int bonus;

        switch (PlayerPrefs.GetInt(name + "Photo"))
            {
            case 5:
                bonus = 5;
                break;
            case 10:
                bonus = 10;
                break;
            case 20:
                bonus = 15;
                break;
            case 50:
                bonus = 20;
                break;
            default:
                bonus = 1;
                break;
            }

        return bonus;
    }

}

