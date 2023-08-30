using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePage : MonoBehaviour
{
    public GameObject nextPage;
    public GameObject thisPage;

    public void openPage()
    {
        if (nextPage != null)
        {
            bool isActive = nextPage.activeSelf;
            nextPage.SetActive(!isActive);
            thisPage.SetActive(false);
        }
    }
}
