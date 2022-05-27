using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    [Header("SCRIPT REFERENCE")]
    public HomeScreen HomeScreen;
    public GameplayScreen GameplayScreen;
    public VictoryScreen VictoryScreen;
    public FailScreen FailScreen;
    public LoadingScreen LoadingScreen;
    public GameObject BG;
    public GameObject BGSpray;
    public GameObject Done;
    public GameObject DoneBottle;
    public bool isStart;
    public GameManager manager;

    public Camera UiCamera;

    public GameObject first;
    public GameObject Second;

    public GameObject[] firstBottle;
    public GameObject[] secondBottle;

    public bool level1;
    public bool level2;

    public GameObject[] bottleBG;

    public static ScreenManager Instance;

    public GameObject SliderObj;

    public GameObject LeafBg;
    public GameObject Leaf;
    public GameObject LeafRed;
    public GameObject smallLeafBg;
    public GameObject smallLeaf;
    public GameObject smallLeafRed;
    public GameObject smallLeafBg1;
    public GameObject smallLeaf1;
    public GameObject smallLeaf1Red;

    public GameObject leafDoneMark;
    public GameObject SmallleafDoneMark;
    public GameObject SmallleafDoneMark1;

    public GameObject StarBg;
    public GameObject Star;
    public GameObject StarBg1;
    public GameObject Star1;

    public GameObject StarDoneMark;
    public GameObject StarDoneMark1;

    public GameObject starDone;
    public GameObject LeafDone;

    public GameObject TextImage;

    public void stardone()
    {
        StarDrag.Instance.stardone();
    }

    public void leafdone()
    {
        LeafDrag.Instance.leafdone();
    }

    public void bottle1()
    {
        GameManager.Instance.activeBottle1();
        GameManager.Instance.isBottleSelect = true;
    }
    public void bottle2()
    {
        GameManager.Instance.activeBottle2();
        GameManager.Instance.isBottleSelect = true;
    }
    public void bottle3()
    {
        GameManager.Instance.activeBottle3();
        GameManager.Instance.isBottleSelect = true;
    }
    public void bottle4()
    {
        GameManager.Instance.activeBottle4();
        GameManager.Instance.isBottleSelect = true;
    }
    public void bottle5()
    {
        GameManager.Instance.activeBottle5();
        GameManager.Instance.isBottleSelect = true;
    }

    public void Spraybottle1()
    {
        GameManager.Instance.SprayBottle1();
    }
    public void Spraybottle2()
    {
        GameManager.Instance.SprayBottle2();
    }
    public void Spraybottle3()
    {
        GameManager.Instance.SprayBottle3();
    }
    public void Spraybottle4()
    {
        GameManager.Instance.SprayBottle4();
    }
    public void Spraybottle5()
    {
        GameManager.Instance.SprayBottle5();
    }

    public void done()
    {
        GameManager.Instance.Done();
    }
    public void donebottle()
    {
        GameManager.Instance.DoneBottle();
    }

    //public GameObject LeafDone;
    //public GameObject LeafDone1;
    //public GameObject LeafDone2;
    //public GameObject starDone;
    //public GameObject starDone2;

    public Slider slider;
    public Image fill;

    public GameObject HomeScreenObject { get { return HomeScreen.gameObject; } }
    public GameObject GameplayScreenObject { get { return GameplayScreen.gameObject; } }
    public GameObject VictoryScreenObject { get { return VictoryScreen.gameObject; } }
    public GameObject FailScreenObject { get { return FailScreen.gameObject; } }
    public GameObject LoadingScreenObject { get { return LoadingScreen.gameObject; } }

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        Instance = this;

        SetScreen();
    }

    #endregion

    #region Public Functions


    #endregion

    #region Private Functions

    private void SetScreen()
    {
        HomeScreenObject.SetActive(true);
        GameplayScreenObject.SetActive(false);
        VictoryScreenObject.SetActive(false);
        FailScreenObject.SetActive(false);
    }

    #endregion

}
