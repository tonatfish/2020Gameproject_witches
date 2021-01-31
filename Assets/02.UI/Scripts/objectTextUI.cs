﻿using System;
using System.Collections.Generic;
using System.IO;
using Pathfinding.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class objectTextUI : MonoBehaviour
{
    private OnInteract Instance;
    public GameObject UI;
    private Text TextUI;
    private Image Image;
    private List<String> Text;
    private bool active;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        TextUI = UI.transform.Find("Text").GetComponent<Text>();
        Image = UI.transform.GetComponentInChildren<Image>();
        active = false;
        TextUI.gameObject.SetActive(false);
        Image.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (index >= Text.Count)
            {
                active = false;
                TextUI.gameObject.SetActive(false);
                Image.gameObject.SetActive(false);
                index = 0;
                if (Instance)
                {
                    Instance.active = true;
                    Instance = null;
                }
            }
            else
            {
                TextUI.text = Text[index];
                if (Input.GetKeyDown(KeyCode.H))
                {
                    index++;
                }
            }
            
        }
    }

    public void LoadText(String path,OnInteract instance)
    {
        Instance = instance;
        using (StreamReader r = new StreamReader(Application.dataPath+"/02.UI/StoryScripts/"+path))
        {
            string json = r.ReadToEnd();
            Text = (List<String>)TinyJsonDeserializer.Deserialize(json,typeof(List<String>));
            index = 0;
            active = true;
            TextUI.gameObject.SetActive(true);
            Image.gameObject.SetActive(true);
        }
    }
    public void LoadText(String path)
    {
        using (StreamReader r = new StreamReader(Application.dataPath+"/02.UI/StoryScripts/"+path))
        {
            string json = r.ReadToEnd();
            Text = (List<String>)TinyJsonDeserializer.Deserialize(json,typeof(List<String>));
            index = 0;
            active = true;
            TextUI.gameObject.SetActive(true);
            Image.gameObject.SetActive(true);
        }
    }
}