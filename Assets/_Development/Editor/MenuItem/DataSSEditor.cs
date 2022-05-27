using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.Build.Reporting;

public class DataSSEditor : EditorWindow
{
    public static string DevelopmentSymbol = "ULTRAGAMES_DEBUG";
    public static string FinalSymbol = "ULTRAGAMES_RELEASE";

    #region Data Section

    [MenuItem("UltraGames/Delete PlayerPrefs")]
    public static void DeleteAllPreferences()
    {
        PlayerPrefs.DeleteAll();
    }

    [MenuItem("UltraGames/Persistant DataPath/Open")]
    public static void OpenPersistantDataPath()
    {
        Application.OpenURL(Application.persistentDataPath);
    }

    [MenuItem("UltraGames/Persistant DataPath/Delete All Data")]
    public static void DeleteAllFilesFromPersistantDataPath()
    {
        DeleteAllData();
    }

    #endregion

    #region ScreenShot Section

    [MenuItem("UltraGames/Capture Screenshot/Regular Size %#&C")]
    public static void CaptureScreenshorRegular()
    {
        CaptureScreenshot(1);
    }

    [MenuItem("UltraGames/Capture Screenshot/2X Size %#&V")]
    public static void CaptureScreenshor2X()
    {
        CaptureScreenshot(2);
    }

    [MenuItem("UltraGames/Capture Screenshot/3X Size %#&B")]
    public static void CaptureScreenshor3X()
    {
        CaptureScreenshot(3);
    }

    public static void CaptureScreenshot(int superSize = 1)
    {
        string _path = Path.Combine(Application.dataPath, "ScreenShots"); 

        if(!Directory.Exists(_path))
        {
            Directory.CreateDirectory(_path);
            AssetDatabase.Refresh();
        }

        ScreenCapture.CaptureScreenshot(_path + "/Img-" + GetCurrentTime() + ".png", superSize);
        AssetDatabase.Refresh();
        Application.OpenURL(Application.dataPath + "/-@ScreenShots");
    }

    #endregion

    #region Private Static Functions

    private static void DeleteAllData()
    {
        System.IO.Directory.Delete(Application.persistentDataPath, true);
    }
    private static string GetCurrentTime()
    {
        string currentTime = System.DateTime.Now.ToString();
        currentTime = currentTime.Replace("/", "-");
        currentTime = currentTime.Replace(" ", "-");
        currentTime = currentTime.Replace(":", "-");
        return currentTime;
    }
    private static BuildPlayerOptions GetCurrentBuildOptions(BuildPlayerOptions defaultOptions = new BuildPlayerOptions())
    {
        return BuildPlayerWindow.DefaultBuildMethods.GetBuildPlayerOptions(defaultOptions);
    }
    private static void BuildPlayerHandler(BuildPlayerOptions options)
    {
        if (EditorUserBuildSettings.development)
        {
            if (EditorUtility.DisplayDialog("Attention!", "This is Development Build.\n\nIf you want to build to Upload on Google or IOS, plaese Select Prepare For Final Build from Menu Bar.\n\nUltragames>Build>Prepare For Final Build",
             "Continue", "Cancel"))
            {
                BuildPlayerOptions buildPlayerOptions = GetCurrentBuildOptions(new BuildPlayerOptions());
                BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
                if (report.summary.result == BuildResult.Succeeded)
                {
                    EditorUtility.RevealInFinder(buildPlayerOptions.locationPathName);
                }
            }
            else
            {
                Debug.LogError("Build Cancelled");
                Debug.LogError("Please select Prepare For Final Build from Ultragames>Build>Prepare For Final Build");
            }
        }
        else
        {
            if (EditorUtility.DisplayDialog("Attention!", "This is Final Build.\n\nIf you want to build For Testing, plaese Select Prepare For Development Build from Menu Bar.\n\nUltragames>Build>Prepare For Development Build",
                         "Continue", "Cancel"))
            {
                BuildPlayerOptions buildPlayerOptions = GetCurrentBuildOptions(new BuildPlayerOptions());
                BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
                if (report.summary.result == BuildResult.Succeeded)
                {
                    EditorUtility.RevealInFinder(buildPlayerOptions.locationPathName);
                }
            }
            else
            {
                Debug.LogError("Build Cancelled");
                Debug.LogError("Please select Prepare For Development Build from Ultragames>Build>Prepare For Development Build");
            }
        }
    }

    #endregion

}