using Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField output;

    public Player player;

    public void GetData()
    {
        output.text = null;
        string uri = "https://localhost:7153/superadventure";
        Quest quest = new Quest();
        StartCoroutine(quest.LoadQuestsFromDatabase(uri, output));

        print(quest.GetQuest());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
