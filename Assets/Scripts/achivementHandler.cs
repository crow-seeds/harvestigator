using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class achivementHandler : MonoBehaviour
{
    List<int> NGAchievementNums = new List<int> { 72446, 72447, 72448, 72449, 72450, 72451, 72452, 72453 };
    NGHelper ng;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        ng = gameObject.GetComponent<NGHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void unlockAchievement(int i)
    {
        //SaveData("achievement" + i.ToString(), 1);
        PlayerPrefs.SetInt("achievement" + i.ToString(), 1);


        if (ng.hasNewgrounds)
        {
            ng.unlockMedal(NGAchievementNums[i]);
        }
    }

    public void runThroughAchievements()
    {
        if (ng.hasNewgrounds)
        {
            for(int i = 0; i < NGAchievementNums.Count; i++)
            {
                if(PlayerPrefs.GetInt("achievement" + i.ToString(), 0) == 1)
                {
                    ng.unlockMedal(NGAchievementNums[i]);
                }
            }
        }
    }

    public void submitScore(int i)
    {
        if (ng.hasNewgrounds)
        {
            ng.submitScore(12454, i);
        }
    }

    public void achInit()
    {
        runThroughAchievements();
        submitScore(PlayerPrefs.GetInt("coinsInEndless", 0));
    }
}
