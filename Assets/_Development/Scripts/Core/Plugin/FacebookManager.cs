using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Facebook.Unity;

public class FacebookManager : MonoBehaviour
{

    //-------------------------//

    // IF USING FACEBOOK -> UNCOMMENT LINES

    //-------------------------//


    #region MonoBehaviour Callbacks

    private void Awake()
    {
        //FB.Init(FBInitCallback);
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus)
        {
            // if (FB.IsInitialized)
            {
                // FB.ActivateApp();
            }
        }
    }

    #endregion

    #region Private Functions

    private void FBInitCallback()
    {
        //     if (FB.IsInitialized)
        //     {
        //         FB.ActivateApp();
        //     }
    }

    #endregion
}
