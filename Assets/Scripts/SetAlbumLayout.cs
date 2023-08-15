using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAlbumLayout : MonoBehaviour
{
    public GameObject sarnaZdjecie;
    public GameObject koziolZdjecie;
    public GameObject laniaZdjecie;
    public GameObject jelenZdjecie;
    public GameObject dzikZdjecie;
    public GameObject losZdjecie;
    public GameObject loszaZdjecie;



    // Start is called before the first frame update
    public void OnEnable()
    {
        if(PlayerPrefs.GetInt("ile-sarna") > 0)
        { sarnaZdjecie.SetActive(true); }
        else
        { sarnaZdjecie.SetActive(false); }

        if (PlayerPrefs.GetInt("ile-koziol") > 0)
        { koziolZdjecie.SetActive(true); }
        else
        { koziolZdjecie.SetActive(false); }

        if (PlayerPrefs.GetInt("ile-lania") > 0)
        { laniaZdjecie.SetActive(true); }
        else
        { laniaZdjecie.SetActive(false); }

        if (PlayerPrefs.GetInt("ile-jelonek") > 0)
        { jelenZdjecie.SetActive(true); }
        else
        { jelenZdjecie.SetActive(false); }

        if (PlayerPrefs.GetInt("ile-dzik") > 0)
        { dzikZdjecie.SetActive(true); }
        else
        { dzikZdjecie.SetActive(false); }

        if (PlayerPrefs.GetInt("ile-los") > 0)
        { losZdjecie.SetActive(true); }
        else
        { losZdjecie.SetActive(false); }

        if (PlayerPrefs.GetInt("ile-losza") > 0)
        { loszaZdjecie.SetActive(true); }
        else
        { loszaZdjecie.SetActive(false); }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
