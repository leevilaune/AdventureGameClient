using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace Data
{
    [System.Serializable]
    public class Quest
    {
        public int Id;
        public string QuestName;
        public string QuestDesc;
        public string QuestReward;
        public int QuestExp;
        public bool completionStatus;

        public Quest thisQuest;
        public Quest() { }

        public Quest(int id, string questName, string questDesc, string questReward, int questExp, bool completionStatus)
        {
            Id = id;
            QuestName = questName;
            QuestDesc = questDesc;
            QuestReward = questReward;
            QuestExp = questExp;
            this.completionStatus = completionStatus;
        }
        public IEnumerator LoadQuestsFromDatabase(string uri, TMP_InputField output)
        {
            using(UnityWebRequest request = UnityWebRequest.Get(uri))
            {
                yield return request.SendWebRequest();
                if(request.error != null)
                {
                    output.text = "network error" + request.error;
                }
                else
                {
                    output.text = request.downloadHandler.text;
                }
                string newOutput = output.text.Remove(0, 1); 
                string newOutput2 = newOutput.Remove(newOutput.Length - 1, 1);

                Quest quest = JsonUtility.FromJson<Quest>(newOutput2);
                Console.WriteLine(quest.QuestName);
            }
        }
        public Quest GetQuest()
        {
            return thisQuest;
        }
        override
        public string ToString()
        {
            return "id: " + Id + "\nquestName: " + QuestName + "\nquestDesc: " + QuestDesc + "\nquestReward: " + QuestReward + "\nquestExp: " + QuestExp + "\ncompletionStatus: " + completionStatus;
        }
    }
}
