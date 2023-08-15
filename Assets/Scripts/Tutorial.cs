using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public SaveState saveState;
    public Camera mainCam;

    public bool kupionoSiano;

    public GameController gameController;
    public GameObject tutorialPanelPasnik;

    public GameObject tutorialPanelSiano;
    public GameObject wykrzyknikI;
    public GameObject wykrzyknikII;
    public GameObject wykrzyknikIII;


    public GameObject tutorialFirstAnimal;
    public GameObject tutorialFirstPhoto;

    public GameObject sklepMenu;

    public GameObject tutOne;

    private LeanTweenManager ltm;

    public void TutorialUp(GameObject tut)
    {
        LeanTween.moveY(tut.GetComponent<RectTransform>(), 320, .6f);
    }

    public void TutorialDown(GameObject tut)
    {
        LeanTween.moveY(tut.GetComponent<RectTransform>(), -320, .5f);
        StartCoroutine(WaitAndDisable(tut));
    }

    void Awake()
    {
        if (PlayerPrefs.GetInt("kupionoSiano") != 1) kupionoSiano = false;
        else kupionoSiano = true;
        ltm = GameObject.FindGameObjectWithTag("LeanTween").GetComponent<LeanTweenManager>();
        LeanTween.moveY(tutOne.GetComponent<RectTransform>(), 320, .8f);
    }

    public void ClaimTutorialMoney()
    {
        mainCam = Camera.main;
        saveState.AddPieniazki(15);
        mainCam.GetComponent<UpdateMoney>().MoneyUpdate();
    }

    public void PasnikBought()
    {
        ltm.SlideUp();
        gameController.SetMenuFalse();
        tutorialPanelPasnik.SetActive(true);
        LeanTween.moveY(tutorialPanelPasnik.GetComponent<RectTransform>(), 320, .6f);
    }

    public void SianoBought()
    {
        if (!kupionoSiano)
        {
            tutorialPanelSiano.SetActive(true);
            LeanTween.moveY(tutorialPanelSiano.GetComponent<RectTransform>(), 370, .6f);
            wykrzyknikI.SetActive(false);
            wykrzyknikII.SetActive(false);
            wykrzyknikIII.SetActive(false);
            kupionoSiano = true;
            PlayerPrefs.SetInt("kupionoSiano", 1);
        }

    }

    public void FirstAnimal()
    {
        tutorialFirstAnimal.SetActive(true);
        LeanTween.moveY(tutorialFirstAnimal.GetComponent<RectTransform>(), 320, .6f);
    }

    public void FirstPhoto()
    {
        tutorialFirstPhoto.SetActive(true);
        LeanTween.moveY(tutorialFirstPhoto.GetComponent<RectTransform>(), 320, .6f);
    }

    public IEnumerator WaitAndDisable(GameObject tut)
    {
        yield return new WaitForSeconds(.4f);
        tut.SetActive(false);
    }

}
