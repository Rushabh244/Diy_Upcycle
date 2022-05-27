using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using GameAnalyticsSDK;


public class GameAnalyticsManager : MonoBehaviour
{

    //-------------------------//

    // IF USING GAMEANALYTICS -> UNCOMMENT EVENT SECTION LINES

    //-------------------------//


    #region MonoBehaviour Callbacks

    private void Awake()
    {
        //GameAnalytics.Initialize();
    }

    private void Start()
    {
        StartGASession();
    }

    #endregion

    #region Event Section

    public static void StartGASession()
    {
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, Application.version, "Session_Start");
        //GameAnalytics.StartSession();
    }

    public static void EndGASession()
    {
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, Application.version, "Session_End");
        //GameAnalytics.EndSession();
    }

    public void LevelStartEvent(int levelNo)
    {
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, ("Level_" + levelNo));
    }

    public void LevelVictoryEvent(int levelNo)
    {
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, ("Level_" + levelNo));
    }

    public void LevelFailEvent(int levelNo)
    {
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, ("Level_" + levelNo));
    }

    #endregion
}
