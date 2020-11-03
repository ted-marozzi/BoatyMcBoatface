using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditMenuManagement : MonoBehaviour
{
    // Credits menu management
    public GameObject creditsPage1;
    public GameObject creditsPage2;
    public GameObject creditsPage3;
    public GameObject creditsPage4;
    public GameObject creditsPage5;

    // Page Management
    public void ShowPage1()
    {
        closeAllPages();
        creditsPage1.SetActive(true);
    }
    public void ShowPage2()
    {
        closeAllPages();
        creditsPage2.SetActive(true);
    }
    public void ShowPage3()
    {
        closeAllPages();
        creditsPage3.SetActive(true);
    }
    public void ShowPage4()
    {
        closeAllPages();
        creditsPage4.SetActive(true);
    }
    public void ShowPage5()
    {
        closeAllPages();
        creditsPage5.SetActive(true);
    }

    void closeAllPages()
    {
        creditsPage1.SetActive(false);
        creditsPage2.SetActive(false);
        creditsPage3.SetActive(false);
        creditsPage4.SetActive(false);
        creditsPage5.SetActive(false);
    }
}
