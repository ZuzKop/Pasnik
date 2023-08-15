using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backMenu : MonoBehaviour
{
    public GameObject previousMenu;
    public GameObject page;
    public GameObject profil;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Backing up");
            previousMenu.SetActive(true);

            AssignObjects();
            if (profil) profil.SetActive(false);
            if (page) page.SetActive(false);

            this.gameObject.SetActive(false);
        }
    }

    void AssignObjects()
    {
        profil = GameObject.FindGameObjectWithTag("menuProfil");
        page = GameObject.FindGameObjectWithTag("menuPage");
    }
}
