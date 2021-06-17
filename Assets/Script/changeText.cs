using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;

public class changeText : MonoBehaviour
{
    public ScrollRect Panel;

    public GameObject Intro;
    public GameObject DT;
    public GameObject DT2;
    public GameObject DT3;
    public GameObject DT4;

    private int activContainer = 1;    
    

    public void lesson1()
    {
        activContainer = 1;
        Debug.Log(" lesson1: " + activContainer);

        Panel.content = Intro.GetComponent<RectTransform>();

        Intro.SetActive(true);
        DT.SetActive(false);
        DT2.SetActive(false);
        DT3.SetActive(false);
        DT4.SetActive(false);

    }
    public void lesson2()
    {
        activContainer = 2;
        Debug.Log(" lesson2: " + activContainer);

        Panel.content = DT.GetComponent<RectTransform>();

        Intro.SetActive(false);
        DT.SetActive(true);
        DT2.SetActive(false);
        DT3.SetActive(false);
        DT4.SetActive(false);
    }
    public void lesson3()
    {
        activContainer = 3;
        Debug.Log(" lesson3: " + activContainer);

        Panel.content = DT2.GetComponent<RectTransform>();

        Intro.SetActive(false);
        DT.SetActive(false);
        DT2.SetActive(true);
        DT3.SetActive(false);
        DT4.SetActive(false);
    }
    public void lesson4()
    {
        activContainer = 4;
        Debug.Log(" lesson4: " + activContainer);

        Panel.content = DT3.GetComponent<RectTransform>();

        Intro.SetActive(false);
        DT.SetActive(false);
        DT2.SetActive(false);
        DT3.SetActive(true);
        DT4.SetActive(false);
    }
    public void lesson5()
    {
        activContainer = 5;
        Debug.Log(" lesson5: " + activContainer);

        Panel.content = DT4.GetComponent<RectTransform>();

        Intro.SetActive(false);
        DT.SetActive(false);
        DT2.SetActive(false);
        DT3.SetActive(false);
        DT4.SetActive(true);
    }




}