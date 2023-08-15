using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveManager : MonoBehaviour
{
    public GameObject ZwierzetaGroup;
    public GameObject JedzeniaGroup;
    public GameObject PrzedmiotyGroup;

    public List<GameObject> zwierzeta_sprites;
    public List<GameObject> jedzenia_sprites;
    public List<GameObject> przedmioty_sprites;

    public static DateTime oldDate;

    Camera mainCamera;
    public SaveState saveState;
    public TimeManager timeManager;
    public Dotacje dotacje;


    private void Awake()
    {
        mainCamera = Camera.main;
        FillArrays();
    }


    public void Save()
    {
        Debug.Log("Saving.");

        SaveSpriteArray("zwierze", zwierzeta_sprites);
        SaveSpriteArray("przedmiot", przedmioty_sprites);
        SaveSpriteArray("jedzenie", jedzenia_sprites);

        PlayerPrefs.SetInt("pieniazki", saveState.GetPieniazki());

        PlayerPrefs.SetInt("HayAmount", saveState.GetHayAmount());
        PlayerPrefs.SetInt("HayMax", saveState.GetHayMax());
        PlayerPrefs.SetInt("FruitAmount", saveState.GetFruitAmount());
        PlayerPrefs.SetInt("FruitMax", saveState.GetFruitMax());
        PlayerPrefs.SetInt("Dotacje", dotacje.GetDotacje());

        //time:
        if(timeManager.TimeInSeconds() > 10)
        {
        PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());
        }
        else PlayerPrefs.SetString("sysString", timeManager.GetOldTime().ToBinary().ToString());

        PlayerPrefs.SetInt("First", 1);
    }

    public void SaveSpriteArray(string saveName, List<GameObject> sprites)
    {
        
        for (int i = 0; i < sprites.Count; i++)
        {
            if (sprites[i].activeSelf)
            {
                PlayerPrefs.SetInt(saveName + i, 1);
            }
            else
            {
                PlayerPrefs.SetInt(saveName + i, 0);
            }

        }

    }

    public void Load()
    {
        Debug.Log("Loading.");

        if (PlayerPrefs.HasKey("sysString"))
        {
            long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));
            oldDate = DateTime.FromBinary(temp);
            timeManager.SetOldTime(oldDate);
            Debug.Log("oldDate: " + timeManager.GetOldTime());

        }
        else Debug.Log("no older date found");

        LoadSpriteArray("zwierze", zwierzeta_sprites);
        LoadSpriteArray("przedmiot", przedmioty_sprites);
        LoadSpriteArray("jedzenie", jedzenia_sprites);

        saveState.SetPieniazki(PlayerPrefs.GetInt("pieniazki"));

        saveState.SetHayAmount(PlayerPrefs.GetInt("HayAmount"));
        saveState.SetHayMax(PlayerPrefs.GetInt("HayMax"));
        saveState.SetFruitAmount(PlayerPrefs.GetInt("FruitAmount"));
        saveState.SetFruitMax(PlayerPrefs.GetInt("FruitMax"));

        dotacje.SetDotacje(PlayerPrefs.GetInt("Dotacje"));

        saveState.UpdatePhotoCounter();
        mainCamera.GetComponent<UpdateMoney>().MoneyUpdate();
    }

    public void LoadSpriteArray(string saveName, List<GameObject> sprites)
    {

        for (int i = 0; i < sprites.Count; i++)
        {
            if (PlayerPrefs.GetInt(saveName + i) == 1)
            {
                sprites[i].SetActive(true);
            }
            else
            {
                sprites[i].SetActive(false);
            }

        }

    }

    private void FillArrays()
    {
        //find children
        foreach (Transform child in ZwierzetaGroup.transform)
        {
            zwierzeta_sprites.Add(child.gameObject);
        }

        foreach (Transform child in PrzedmiotyGroup.transform)
        {
            przedmioty_sprites.Add(child.gameObject);
        }

        foreach (Transform child in JedzeniaGroup.transform)
        {
            jedzenia_sprites.Add(child.gameObject);
        }
    }


}
