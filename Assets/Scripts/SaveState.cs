using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveState : MonoBehaviour
{
    public int pieniazki;

    public int hayAmount;
    public int fruitAmount;

    public int fruitMax;
    public int hayMax;

    public Text counter;

     /*
     *List of Playreprefs: 
     * ile-name : ilosc wystapien zwierzat
     * name : pomocnicza zmienna pamietajaca czy zwierze bylo ostatnio fotografowane
     * pieniazki : ilosc pieniazkow jakie ma gracz
     * namePhoto : ile razy to zwierze bylo fotografowane
     */

    /*
    funkcje w tej klasie:

    public int GetPieniazki();
    public void SetPieniazki(int amount);
    public void AddPieniazki(int amount);

    public int GetHayAmount();
    public void SetHayAmount(int amount);
    public void EatHay();
    public int GetHayMax();
    public void SetHayMax(int amount);

    public int GetFruitAmount();
    public void SetFruitAmount(int amount);
    public void EatFruit();
    public int GetFruitMax();
    public void SetFruitMax(int amount);

    public int HowManyPhotosTotal();
    */

    void Awake()
    {

    }


    public int GetPieniazki()
    {
        return pieniazki;
    }

    public void SetPieniazki(int amount)
    {
        pieniazki = amount;
    }

    public void AddPieniazki(int amount)
    {
        pieniazki += amount;
    }


    public int GetHayAmount()
    {
        return hayAmount;
    }
    public void SetHayAmount(int amount)
    {
        hayAmount = amount;
    }
    public void EatHay()
    {
        if(GetHayAmount() > 0)
        {
            hayAmount--;
        }
    }
    public int GetHayMax()
    {
        return hayMax;
    }
    public void SetHayMax(int amount)
    {
        hayMax = amount;
    }


    public int GetFruitAmount()
    {
        return fruitAmount;
    }
    public void SetFruitAmount(int amount)
    {
       fruitAmount = amount;
    }
    public void EatFruit()
    {
        if(GetFruitAmount() > 0)
        {
             fruitAmount--;
        }
    }
    public int GetFruitMax()
    {
        return fruitMax;
    }
    public void SetFruitMax(int amount)
    {
        fruitMax = amount;
    }

    public int HowManyPhotosTotal()
    {
        int photosTotal = 0;

        GameObject ZwierzetaGroup;
        ZwierzetaGroup = GameObject.FindWithTag("ZwierzetaGroup");

        foreach (Transform child in ZwierzetaGroup.transform)
        {
            photosTotal += PlayerPrefs.GetInt(child.name + "Photo");
        }

        return photosTotal;
    }

    public int HowManyVisitsTotal()
    {
        int visitsTotal = 0;

        GameObject ZwierzetaGroup;
        ZwierzetaGroup = GameObject.FindWithTag("ZwierzetaGroup");

        foreach (Transform child in ZwierzetaGroup.transform)
        {
            visitsTotal += PlayerPrefs.GetInt("ile-" + child.name);
        }

        return visitsTotal;

    }

    public void UpdatePhotoCounter()
    {
        string photosTotalString = HowManyPhotosTotal().ToString();
        counter.text = photosTotalString;
        Debug.Log("photos total: " + photosTotalString);
    }
}
