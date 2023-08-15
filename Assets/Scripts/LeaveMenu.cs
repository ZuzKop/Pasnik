using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveMenu : MonoBehaviour
{
    public GameObject profil;
    public LeanTweenManager ltm;

    public GameController gameController;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Leaving Menu.");

            AssignObjects();

            if(profil) profil.SetActive(false);
            ltm.SlideUp();
            gameController.SetMenuFalse();
        }
    }

    void AssignObjects()
    {
        profil = GameObject.FindGameObjectWithTag("menuProfil");
        ltm = GameObject.FindGameObjectWithTag("LeanTween").GetComponent<LeanTweenManager>();
    }
}
