using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SklepJedzenieExit : MonoBehaviour
{
    public GameController gameController;
    public GameObject previousMenu;

    public GameObject opisy;
    public GameObject page;
    public GameObject profil;

    public GameObject backButton;

    private LeanTweenManager ltm;

    // Start is called before the first frame update
    void Awake()
    {
    }

    public void OnEnable()
    {
        if(gameController.GetMenuOn())
        {
            backButton.SetActive(true);
        }
        else
        {
            backButton.SetActive(false);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AssignObjects();
            if (profil) profil.SetActive(false);
            if (opisy) { foreach (Transform child in opisy.transform) { child.gameObject.SetActive(false); } }

            if(gameController.GetMenuOn())
            {
                previousMenu.SetActive(true);
                if(page)
                {
                    page.SetActive(true);
                }
            }
            else
            {
                ltm.SlideUp();
            }

        }
    }

    void AssignObjects()
    {
        profil = GameObject.FindWithTag("menuProfil");
        ltm = GameObject.FindGameObjectWithTag("LeanTween").GetComponent<LeanTweenManager>();
    }
}
