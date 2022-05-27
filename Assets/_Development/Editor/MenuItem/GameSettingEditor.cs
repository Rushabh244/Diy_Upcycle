using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


public class GameSettingEditor : EditorWindow
{
    [MenuItem("UltraGames/Set GameSettings/Android")]
    private static void InitializeSettings()
    {
        if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.Android)
        {
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
        }

        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.Android, ApiCompatibilityLevel.NET_4_6);

        PlayerSettings.defaultInterfaceOrientation = UIOrientation.Portrait;

        PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel23;
        PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevel30;

        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARMv7 | AndroidArchitecture.ARM64;

        PlayerSettings.SplashScreen.unityLogoStyle = PlayerSettings.SplashScreen.UnityLogoStyle.LightOnDark;
        PlayerSettings.SplashScreen.showUnityLogo = false;

        // Set Keystore
        string _path = Path.Combine(Application.dataPath, "!Development", "KeyStore");

        if (Directory.Exists(_path))
        {
            PlayerSettings.Android.useCustomKeystore = true;

            PlayerSettings.keystorePass = "ultragames";
            PlayerSettings.keyaliasPass = "ultragames";
        }

    }
    [InitializeOnLoadMethod]
    private static void Initialize()
    {
        BuildPlayerWindow.RegisterBuildPlayerHandler(DisplayDialog);
    }
    private static void DisplayDialog(BuildPlayerOptions buildOptions)
    {
        bool isAndroid = isAndroidPlatform();

        if (isAndroid == false)
        {
            if (EditorUtility.DisplayDialog("Warning!", "Current build target is not Android :(", "Switch Target", "Okay"))
            {
                InitializeSettings();
            }
            else
            {
                BuildPipeline.BuildPlayer(buildOptions);
            }
        }
        else
        {
            bool isCorrent = CheckAndroidSettings();

            if (isCorrent)
            {
                BuildPipeline.BuildPlayer(buildOptions);
            }
            else
            {
                if (EditorUtility.DisplayDialog("Warning!", "Some Android setting are not set :(", "Set and Build", "Ok"))
                {
                    InitializeSettings();
                }
                else
                {
                    BuildPipeline.BuildPlayer(buildOptions);
                }
            }
        }
    }

    private static bool isAndroidPlatform()
    {
        BuildTarget _currentBuildTarget = EditorUserBuildSettings.activeBuildTarget;

        if (_currentBuildTarget == BuildTarget.Android) return true;
        else return false;
    }

    private static bool CheckAndroidSettings()
    {
        AndroidArchitecture androidArchitecture = AndroidArchitecture.ARM64 | AndroidArchitecture.ARMv7;

        if (PlayerSettings.GetScriptingBackend(BuildTargetGroup.Android) != ScriptingImplementation.IL2CPP)
            return false;
        else if (PlayerSettings.defaultInterfaceOrientation != UIOrientation.Portrait)
            return false;
        else if (PlayerSettings.GetApiCompatibilityLevel(BuildTargetGroup.Android) != ApiCompatibilityLevel.NET_4_6)
            return false;
        else if (PlayerSettings.Android.minSdkVersion != AndroidSdkVersions.AndroidApiLevel23)
            return false;
        else if (PlayerSettings.Android.targetSdkVersion != AndroidSdkVersions.AndroidApiLevel30)
            return false;
        else if (PlayerSettings.Android.targetArchitectures != androidArchitecture)
            return false;
        else
            return true;
    }
}
