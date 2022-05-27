using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class LevelHandler : MonoBehaviour
{
    [Header("REFERENCE")]
    [Tooltip("In Resources folder set level prefab path")]
    [SerializeField] private string LevelPath = "LevelPrefab";
    [SerializeField] private string LevelName = "Level_";
    [SerializeField] private int maxLevelNo = 0;

    private Transform LevelRoot;
    private bool isFirstTimeLoad = true;

    private static event Action LoadNewLevelE;
    private static event Action ReloadLevelE;

    public static event Action OnLevelStart;
    public static event Action OnLevelStatusUpdate;
    public static event Action OnLevelVictory;
    public static event Action OnLevelFail;

    [Space(14)]
    public UnityEvent OverrideLoadNewLevel;
    public UnityEvent OverrideOnReloadLevel;

    #region OnEnable/Disable

    private void OnEnable()
    {
        LoadNewLevelE += LoadNewLevel;
        ReloadLevelE += ReloadLevel;
    }
    private void OnDisable()
    {
        LoadNewLevelE -= LoadNewLevel;
        ReloadLevelE -= ReloadLevel;
    }
    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        GameObject _levelObject = new GameObject();
        _levelObject.name = "LevelRoot";
        LevelRoot = _levelObject.transform;
    }

    private void Start()
    {
        LevelStatusUpdateEvent();

#if UNITY_EDITOR
        //Init();
#endif

        LoadNewLevel();

    }
    #endregion

    #region Level Section
    private void LoadNewLevel()
    {
        if (OverrideLoadNewLevel.GetPersistentEventCount() > 0)
        {
            OverrideLoadNewLevel?.Invoke();
            return;
        }

        // IF OverrideLoadNewLevel is Empty
        if (maxLevelNo == 0) return;

        if (isFirstTimeLoad) isFirstTimeLoad = false;
        else
        {
            int _currentLevel = GameDatabase.CurrentLevel + 1;
            GameDatabase.SetLevelNo(_currentLevel);
        }

        LoadSystem();

        LevelStatusUpdateEvent();
    }

    private void ReloadLevel()
    {
        if (OverrideOnReloadLevel.GetPersistentEventCount() > 0)
        {
            OverrideOnReloadLevel?.Invoke();
            return;
        }

        // IF OverrideOnReloadLevel is Empty
        if (maxLevelNo == 0) return;

        LoadSystem();

        LevelStatusUpdateEvent();
    }
    #endregion

    #region Event Section

    public static void LoadNewLevelEvent() => LoadNewLevelE?.Invoke();
    public static void ReloadLevelEvent() => ReloadLevelE?.Invoke();
    public static void LevelStartEvent() => OnLevelStart?.Invoke();
    public static void LevelStatusUpdateEvent() => OnLevelStatusUpdate?.Invoke();
    public static void LevelVictoryEvent() => OnLevelVictory?.Invoke();
    public static void LevelFailEvent() => OnLevelFail?.Invoke();

    #endregion

    #region Private Function
    //private void Init()
    //{
    //    string _path = Path.Combine(Application.dataPath, "Resources", LevelPath);

    //    if (!Directory.Exists(_path))
    //    {
    //        Directory.CreateDirectory(_path);
    //        AssetDatabase.Refresh();
    //    }

    //    DirectoryInfo directoryInfo = new DirectoryInfo(_path);
    //    maxLevelNo = directoryInfo.GetFiles("*.prefab").Length;
    //}

    private void LoadSystem()
    {
        int childCount = LevelRoot.childCount; // IF any Gameobject in child

        for (int i = 0; i < childCount; i++) // IF LevelRoot in Child Available so Destroy it
        {
            Destroy(LevelRoot.GetChild(i).gameObject);
        }

        int _levelNo = GameDatabase.CurrentLevel % maxLevelNo;

        if (_levelNo == 0) _levelNo = maxLevelNo;

        // Load Level
        GameObject _levelObject = (GameObject)Resources.Load(Path.Combine(LevelPath, $"{LevelName}{_levelNo}"));
        Instantiate(_levelObject, LevelRoot);
    }


    #endregion

}
