using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Notes : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject[] notes;
    [SerializeField] LayerMask notesMask;

    private bool inTrigger = false;
    public static bool noteActive = false;
    private string currentNote = "";


    void Update()
    {

        if (Input.GetKeyDown("space") && inTrigger)
        {
            VisibleNotes(ExtractNoteNumber(currentNote) - 1);
            ActivatePanel();

        }
        if (Input.GetKeyDown(KeyCode.Escape) && noteActive)
        {
            HideNotes(ExtractNoteNumber(currentNote) - 1);
            Resume();


        }



    }
    int ExtractNoteNumber(string noteNumber)
    {
        return Int32.Parse(noteNumber.Substring(4));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Note"))
        {
            inTrigger = true;
            currentNote = other.tag;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag.Contains("Note"))
        {
            inTrigger = false;

        }
    }

    void ActivatePanel()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        noteActive = true;
    }

    void VisibleNotes(int x1)
    {
        //bool Note2, bool Note3, bool Note4, bool Note5, bool Note6
        notes[x1].SetActive(true);
        // notes[1].SetActive(Note2);
        // notes[2].SetActive(Note3);
        // notes[3].SetActive(Note4);
        // notes[4].SetActive(Note5);
        // notes[5].SetActive(Note6);
    }

    void HideNotes(int x1)
    {
        //bool Note2, bool Note3, bool Note4, bool Note5, bool Note6
        notes[x1].SetActive(false);
        // notes[1].SetActive(Note2);
        // notes[2].SetActive(Note3);
        // notes[3].SetActive(Note4);
        // notes[4].SetActive(Note5);
        // notes[5].SetActive(Note6);
    }



    void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        noteActive = false;
    }
}