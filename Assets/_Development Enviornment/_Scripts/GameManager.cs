using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Bottle1;
    public GameObject Bottle2;
    public GameObject Bottle3;
    public GameObject Bottle4;
    public GameObject Bottle5;

    public GameObject Cut_BottleUp1;
    public GameObject Cut_BottleUp2;
    public GameObject Cut_BottleUp3;
    public GameObject Cut_BottleUp4;
    public GameObject Cut_BottleUp5;

    public GameObject Cut_BottleDown1;
    public GameObject Cut_BottleDown2;
    public GameObject Cut_BottleDown3;
    public GameObject Cut_BottleDown4;
    public GameObject Cut_BottleDown5;

    public GameObject Cut_Bottle1;
    public GameObject Cut_Bottle2;
    public GameObject Cut_Bottle3;
    public GameObject Cut_Bottle4;
    public GameObject Cut_Bottle5;

    public GameObject ZoomOutCam;
    public GameObject ZoomInCam;

    public GameObject Cut_Bottle1Cut;
    public GameObject Cut_Bottle2Cut;
    public GameObject Cut_Bottle3Cut;
    public GameObject Cut_Bottle4Cut;
    public GameObject Cut_Bottle5Cut;

    public GameObject Cut_Bottle1UpperCut;
    public GameObject Cut_Bottle2UpperCut;
    public GameObject Cut_Bottle3UpperCut;
    public GameObject Cut_Bottle4UpperCut;
    public GameObject Cut_Bottle5UpperCut;

    public GameObject Cut_Bottle1UnderCut;
    public GameObject Cut_Bottle2UnderCut;
    public GameObject Cut_Bottle3UnderCut;
    public GameObject Cut_Bottle4UnderCut;
    public GameObject Cut_Bottle5UnderCut;

    public GameObject Cut_Bottle1CutArea;
    public GameObject Cut_Bottle2CutArea;
    public GameObject Cut_Bottle3CutArea;
    public GameObject Cut_Bottle4CutArea;
    public GameObject Cut_Bottle5CutArea;

    public GameObject Cut_Bottle1UpperCutArea;
    public GameObject Cut_Bottle2UpperCutArea;
    public GameObject Cut_Bottle3UpperCutArea;
    public GameObject Cut_Bottle4UpperCutArea;
    public GameObject Cut_Bottle5UpperCutArea;

    public GameObject Cut_Bottle1UnderCutArea;
    public GameObject Cut_Bottle2UnderCutArea;
    public GameObject Cut_Bottle3UnderCutArea;
    public GameObject Cut_Bottle4UnderCutArea;
    public GameObject Cut_Bottle5UnderCutArea;

    public GameObject Bottle1Cut;
    public GameObject Bottle2Cut;
    public GameObject Bottle3Cut;
    public GameObject Bottle4Cut;
    public GameObject Bottle5Cut;

    public GameObject Bottle1UpperCut;
    public GameObject Bottle2UpperCut;
    public GameObject Bottle3UpperCut;
    public GameObject Bottle4UpperCut;
    public GameObject Bottle5UpperCut;

    public GameObject Bottle1UnderCut;
    public GameObject Bottle2UnderCut;
    public GameObject Bottle3UnderCut;
    public GameObject Bottle4UnderCut;
    public GameObject Bottle5UnderCut;

    public GameObject SprayBottleChoose1;
    public GameObject SprayBottleChoose2;
    public GameObject SprayBottleChoose3;
    public GameObject SprayBottleChoose4;
    public GameObject SprayBottleChoose5;

    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;
    public GameObject canvas5;


    public GameObject[] NPC;
    public Transform startPoint;

    public bool isTalk;
    public bool isSpray;
    public bool isComplete;
    public bool isTrue;
    public bool isFlase;
    public bool isBottleTrue;
    public bool isSprayTrue;

    public GameObject knifeTool;

    public Material blue;
    public Material Yellow;
    public Material Pink;
    public Material Green;
    public Material Purple;

    public int num;

    public bool isSpawn;

    public bool isBottleSelect;

    public bool isSprayDone;

    // Start is called before the first frame update
    void Start()
    {
        ScreenManager.Instance.SliderObj.SetActive(false);
        Instance = this;
        isSpawn = false;
        ScreenManager.Instance.Done.SetActive(false);
        ScreenManager.Instance.DoneBottle.SetActive(false);
        ScreenManager.Instance.first.SetActive(false);
        ScreenManager.Instance.Second.SetActive(false);
        ScreenManager.Instance.BG.SetActive(false);
        ScreenManager.Instance.BGSpray.SetActive(false); 
        ScreenManager.Instance.bottleBG[0].SetActive(false);
        ScreenManager.Instance.bottleBG[1].SetActive(false);
        ScreenManager.Instance.bottleBG[2].SetActive(false);
        ScreenManager.Instance.bottleBG[3].SetActive(false);
        ScreenManager.Instance.bottleBG[4].SetActive(false);
        ScreenManager.Instance.firstBottle[0].SetActive(false);
        ScreenManager.Instance.firstBottle[1].SetActive(false);
        ScreenManager.Instance.firstBottle[2].SetActive(false);
        ScreenManager.Instance.firstBottle[3].SetActive(false);
        ScreenManager.Instance.firstBottle[4].SetActive(false);
        ScreenManager.Instance.secondBottle[0].SetActive(false);
        ScreenManager.Instance.secondBottle[1].SetActive(false);
        ScreenManager.Instance.secondBottle[2].SetActive(false);
        ScreenManager.Instance.secondBottle[3].SetActive(false);
        ScreenManager.Instance.secondBottle[4].SetActive(false);
        //SpawnNPC();
    }

    // Update is called once per frame
    void Update()
    {
        if(ScreenManager.Instance.isStart && !isSpawn)
        {
            SpawnNPC();
        }

        if (isTalk)
        {
            ScreenManager.Instance.BG.SetActive(true);
        }
    }

    public void SpawnNPC()
    {
        int num = Random.Range(0, 3);
        //GameObject npc = Instantiate(NPC[num], startPoint);
        NPC[num].SetActive(true);
        isSpawn = true;
    }

    public void activeBottle1()
    {
        if (!isBottleSelect)
        {
            Bottle1.SetActive(true);
            Cut_Bottle1.SetActive(true);
            isTalk = false;
            StartCoroutine(ChangeCam(3));

            ScreenManager.Instance.bottleBG[0].SetActive(true);

            if (ScreenManager.Instance.firstBottle[0].activeInHierarchy)
            {
                isBottleTrue = true;
            }
        }
    }
    public void activeBottle2()
    {
        if (!isBottleSelect)
        {
            Bottle2.SetActive(true);
            Cut_Bottle2.SetActive(true);
            isTalk = false;
            StartCoroutine(ChangeCam(3));

            ScreenManager.Instance.bottleBG[1].SetActive(true);

            if (ScreenManager.Instance.firstBottle[1].activeInHierarchy)
            {
                isBottleTrue = true;
            }
        }
    }
    public void activeBottle3()
    {
        if (!isBottleSelect)
        {
            Bottle3.SetActive(true);
            Cut_Bottle3.SetActive(true);
            isTalk = false;
            StartCoroutine(ChangeCam(3));

            ScreenManager.Instance.bottleBG[2].SetActive(true);

            if (ScreenManager.Instance.firstBottle[2].activeInHierarchy)
            {
                isBottleTrue = true;
            }
        }
    }
    public void activeBottle4()
    {
        if (!isBottleSelect)
        {
            Bottle4.SetActive(true);
            Cut_Bottle4.SetActive(true);
            isTalk = false;
            StartCoroutine(ChangeCam(3));

            ScreenManager.Instance.bottleBG[3].SetActive(true);

            if (ScreenManager.Instance.firstBottle[3].activeInHierarchy)
            {
                isBottleTrue = true;
            }
        }
    }
    public void activeBottle5()
    {
        if (!isBottleSelect)
        {
            Bottle5.SetActive(true);
            Cut_Bottle5.SetActive(true);
            isTalk = false;
            StartCoroutine(ChangeCam(3));

            ScreenManager.Instance.bottleBG[4].SetActive(true);

            if (ScreenManager.Instance.firstBottle[4].activeInHierarchy)
            {
                isBottleTrue = true;
            }
        }
    }

    public void SprayBottle1()
    {
        SprayBottleChoose1.SetActive(true);

        Cut_Bottle1Cut.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle2Cut.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle3Cut.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle4Cut.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle5Cut.GetComponent<MeshRenderer>().material = Yellow;

        Cut_Bottle1UpperCut.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle2UpperCut.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle3UpperCut.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle4UpperCut.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle5UpperCut.GetComponent<MeshRenderer>().material = Yellow;

        Cut_Bottle1UnderCut.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle2UnderCut.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle3UnderCut.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle4UnderCut.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle5UnderCut.GetComponent<MeshRenderer>().material = Yellow;

        Cut_Bottle1CutArea.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle2CutArea.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle3CutArea.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle4CutArea.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle5CutArea.GetComponent<MeshRenderer>().material = Yellow;

        Cut_Bottle1UpperCutArea.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle2UpperCutArea.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle3UpperCutArea.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle4UpperCutArea.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle5UpperCutArea.GetComponent<MeshRenderer>().material = Yellow;

        Cut_Bottle1UnderCutArea.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle2UnderCutArea.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle3UnderCutArea.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle4UnderCutArea.GetComponent<MeshRenderer>().material = Yellow;
        Cut_Bottle5UnderCutArea.GetComponent<MeshRenderer>().material = Yellow;

        Bottle1Cut.GetComponent<MeshRenderer>().material = Yellow;
        Bottle2Cut.GetComponent<MeshRenderer>().material = Yellow;
        Bottle3Cut.GetComponent<MeshRenderer>().material = Yellow;
        Bottle4Cut.GetComponent<MeshRenderer>().material = Yellow;
        Bottle5Cut.GetComponent<MeshRenderer>().material = Yellow;

        Bottle1UpperCut.GetComponent<MeshRenderer>().material = Yellow;
        Bottle2UpperCut.GetComponent<MeshRenderer>().material = Yellow;
        Bottle3UpperCut.GetComponent<MeshRenderer>().material = Yellow;
        Bottle4UpperCut.GetComponent<MeshRenderer>().material = Yellow;
        Bottle5UpperCut.GetComponent<MeshRenderer>().material = Yellow;

        Bottle1UnderCut.GetComponent<MeshRenderer>().material = Yellow;
        Bottle2UnderCut.GetComponent<MeshRenderer>().material = Yellow;
        Bottle3UnderCut.GetComponent<MeshRenderer>().material = Yellow;
        Bottle4UnderCut.GetComponent<MeshRenderer>().material = Yellow;
        Bottle5UnderCut.GetComponent<MeshRenderer>().material = Yellow;

        ScreenManager.Instance.BGSpray.SetActive(false);
        ScreenManager.Instance.BG.SetActive(false);
        ScreenManager.Instance.first.SetActive(false);
        ScreenManager.Instance.Second.SetActive(false);
        ScreenManager.Instance.Done.SetActive(true);

        if (num == 0)
        {
            isSprayTrue = true;
        }
    }
    public void SprayBottle2()
    {
        SprayBottleChoose2.SetActive(true);

        Cut_Bottle1Cut.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle2Cut.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle3Cut.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle4Cut.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle5Cut.GetComponent<MeshRenderer>().material = Purple;

        Cut_Bottle1UnderCut.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle2UnderCut.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle3UnderCut.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle4UnderCut.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle5UnderCut.GetComponent<MeshRenderer>().material = Purple;

        Cut_Bottle1UpperCut.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle2UpperCut.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle3UpperCut.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle4UpperCut.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle5UpperCut.GetComponent<MeshRenderer>().material = Purple;

        Cut_Bottle1CutArea.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle2CutArea.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle3CutArea.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle4CutArea.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle5CutArea.GetComponent<MeshRenderer>().material = Purple;

        Cut_Bottle1UnderCutArea.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle2UnderCutArea.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle3UnderCutArea.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle4UnderCutArea.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle5UnderCutArea.GetComponent<MeshRenderer>().material = Purple;

        Cut_Bottle1UpperCutArea.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle2UpperCutArea.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle3UpperCutArea.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle4UpperCutArea.GetComponent<MeshRenderer>().material = Purple;
        Cut_Bottle5UpperCutArea.GetComponent<MeshRenderer>().material = Purple;

        Bottle1Cut.GetComponent<MeshRenderer>().material = Purple;
        Bottle2Cut.GetComponent<MeshRenderer>().material = Purple;
        Bottle3Cut.GetComponent<MeshRenderer>().material = Purple;
        Bottle4Cut.GetComponent<MeshRenderer>().material = Purple;
        Bottle5Cut.GetComponent<MeshRenderer>().material = Purple;

        Bottle1UnderCut.GetComponent<MeshRenderer>().material = Purple;
        Bottle2UnderCut.GetComponent<MeshRenderer>().material = Purple;
        Bottle3UnderCut.GetComponent<MeshRenderer>().material = Purple;
        Bottle4UnderCut.GetComponent<MeshRenderer>().material = Purple;
        Bottle5UnderCut.GetComponent<MeshRenderer>().material = Purple;

        Bottle1UpperCut.GetComponent<MeshRenderer>().material = Purple;
        Bottle2UpperCut.GetComponent<MeshRenderer>().material = Purple;
        Bottle3UpperCut.GetComponent<MeshRenderer>().material = Purple;
        Bottle4UpperCut.GetComponent<MeshRenderer>().material = Purple;
        Bottle5UpperCut.GetComponent<MeshRenderer>().material = Purple;

        ScreenManager.Instance.BGSpray.SetActive(false);
        ScreenManager.Instance.Done.SetActive(true);
        ScreenManager.Instance.BG.SetActive(false);
        ScreenManager.Instance.first.SetActive(false);
        ScreenManager.Instance.Second.SetActive(false);

        if (num == 1)
        {
            isSprayTrue = true;
        }
    }
    public void SprayBottle3()
    {
        SprayBottleChoose3.SetActive(true);

        Cut_Bottle1Cut.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle2Cut.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle3Cut.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle4Cut.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle5Cut.GetComponent<MeshRenderer>().material = Green;

        Cut_Bottle1UnderCut.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle2UnderCut.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle3UnderCut.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle4UnderCut.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle5UnderCut.GetComponent<MeshRenderer>().material = Green;

        Cut_Bottle1UpperCut.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle2UpperCut.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle3UpperCut.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle4UpperCut.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle5UpperCut.GetComponent<MeshRenderer>().material = Green;

        Cut_Bottle1CutArea.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle2CutArea.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle3CutArea.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle4CutArea.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle5CutArea.GetComponent<MeshRenderer>().material = Green;

        Cut_Bottle1UnderCutArea.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle2UnderCutArea.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle3UnderCutArea.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle4UnderCutArea.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle5UnderCutArea.GetComponent<MeshRenderer>().material = Green;

        Cut_Bottle1UpperCutArea.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle2UpperCutArea.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle3UpperCutArea.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle4UpperCutArea.GetComponent<MeshRenderer>().material = Green;
        Cut_Bottle5UpperCutArea.GetComponent<MeshRenderer>().material = Green;

        Bottle1Cut.GetComponent<MeshRenderer>().material = Green;
        Bottle2Cut.GetComponent<MeshRenderer>().material = Green;
        Bottle3Cut.GetComponent<MeshRenderer>().material = Green;
        Bottle4Cut.GetComponent<MeshRenderer>().material = Green;
        Bottle5Cut.GetComponent<MeshRenderer>().material = Green;

        Bottle1UnderCut.GetComponent<MeshRenderer>().material = Green;
        Bottle2UnderCut.GetComponent<MeshRenderer>().material = Green;
        Bottle3UnderCut.GetComponent<MeshRenderer>().material = Green;
        Bottle4UnderCut.GetComponent<MeshRenderer>().material = Green;
        Bottle5UnderCut.GetComponent<MeshRenderer>().material = Green;

        Bottle1UpperCut.GetComponent<MeshRenderer>().material = Green;
        Bottle2UpperCut.GetComponent<MeshRenderer>().material = Green;
        Bottle3UpperCut.GetComponent<MeshRenderer>().material = Green;
        Bottle4UpperCut.GetComponent<MeshRenderer>().material = Green;
        Bottle5UpperCut.GetComponent<MeshRenderer>().material = Green;

        ScreenManager.Instance.BGSpray.SetActive(false);
        ScreenManager.Instance.Done.SetActive(true);
        ScreenManager.Instance.BG.SetActive(false);
        ScreenManager.Instance.first.SetActive(false);
        ScreenManager.Instance.Second.SetActive(false);

        if (num == 2)
        {
            isSprayTrue = true;
        }
    }
    public void SprayBottle4()
    {
        SprayBottleChoose4.SetActive(true);

        Cut_Bottle1Cut.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle2Cut.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle3Cut.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle4Cut.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle5Cut.GetComponent<MeshRenderer>().material = blue;

        Cut_Bottle1UnderCut.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle2UnderCut.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle3UnderCut.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle4UnderCut.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle5UnderCut.GetComponent<MeshRenderer>().material = blue;

        Cut_Bottle1UpperCut.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle2UpperCut.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle3UpperCut.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle4UpperCut.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle5UpperCut.GetComponent<MeshRenderer>().material = blue;

        Cut_Bottle1CutArea.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle2CutArea.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle3CutArea.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle4CutArea.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle5CutArea.GetComponent<MeshRenderer>().material = blue;

        Cut_Bottle1UnderCutArea.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle2UnderCutArea.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle3UnderCutArea.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle4UnderCutArea.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle5UnderCutArea.GetComponent<MeshRenderer>().material = blue;

        Cut_Bottle1UpperCutArea.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle2UpperCutArea.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle3UpperCutArea.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle4UpperCutArea.GetComponent<MeshRenderer>().material = blue;
        Cut_Bottle5UpperCutArea.GetComponent<MeshRenderer>().material = blue;

        Bottle1Cut.GetComponent<MeshRenderer>().material = blue;
        Bottle2Cut.GetComponent<MeshRenderer>().material = blue;
        Bottle3Cut.GetComponent<MeshRenderer>().material = blue;
        Bottle4Cut.GetComponent<MeshRenderer>().material = blue;
        Bottle5Cut.GetComponent<MeshRenderer>().material = blue;

        Bottle1UnderCut.GetComponent<MeshRenderer>().material = blue;
        Bottle2UnderCut.GetComponent<MeshRenderer>().material = blue;
        Bottle3UnderCut.GetComponent<MeshRenderer>().material = blue;
        Bottle4UnderCut.GetComponent<MeshRenderer>().material = blue;
        Bottle5UnderCut.GetComponent<MeshRenderer>().material = blue;

        Bottle1UpperCut.GetComponent<MeshRenderer>().material = blue;
        Bottle2UpperCut.GetComponent<MeshRenderer>().material = blue;
        Bottle3UpperCut.GetComponent<MeshRenderer>().material = blue;
        Bottle4UpperCut.GetComponent<MeshRenderer>().material = blue;
        Bottle5UpperCut.GetComponent<MeshRenderer>().material = blue;

        ScreenManager.Instance.BGSpray.SetActive(false);
        ScreenManager.Instance.Done.SetActive(true);
        ScreenManager.Instance.BG.SetActive(false);
        ScreenManager.Instance.first.SetActive(false);
        ScreenManager.Instance.Second.SetActive(false);

        if (num == 3)
        {
            isSprayTrue = true;
        }
    }
    public void SprayBottle5()
    {
        SprayBottleChoose5.SetActive(true);

        Cut_Bottle1Cut.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle2Cut.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle3Cut.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle4Cut.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle5Cut.GetComponent<MeshRenderer>().material = Pink;

        Cut_Bottle1UnderCut.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle2UnderCut.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle3UnderCut.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle4UnderCut.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle5UnderCut.GetComponent<MeshRenderer>().material = Pink;

        Cut_Bottle1UpperCut.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle2UpperCut.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle3UpperCut.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle4UpperCut.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle5UpperCut.GetComponent<MeshRenderer>().material = Pink;

        Cut_Bottle1CutArea.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle2CutArea.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle3CutArea.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle4CutArea.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle5CutArea.GetComponent<MeshRenderer>().material = Pink;

        Cut_Bottle1UnderCutArea.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle2UnderCutArea.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle3UnderCutArea.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle4UnderCutArea.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle5UnderCutArea.GetComponent<MeshRenderer>().material = Pink;

        Cut_Bottle1UpperCutArea.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle2UpperCutArea.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle3UpperCutArea.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle4UpperCutArea.GetComponent<MeshRenderer>().material = Pink;
        Cut_Bottle5UpperCutArea.GetComponent<MeshRenderer>().material = Pink;

        Bottle1Cut.GetComponent<MeshRenderer>().material = Pink;
        Bottle2Cut.GetComponent<MeshRenderer>().material = Pink;
        Bottle3Cut.GetComponent<MeshRenderer>().material = Pink;
        Bottle4Cut.GetComponent<MeshRenderer>().material = Pink;
        Bottle5Cut.GetComponent<MeshRenderer>().material = Pink;

        Bottle1UnderCut.GetComponent<MeshRenderer>().material = Pink;
        Bottle2UnderCut.GetComponent<MeshRenderer>().material = Pink;
        Bottle3UnderCut.GetComponent<MeshRenderer>().material = Pink;
        Bottle4UnderCut.GetComponent<MeshRenderer>().material = Pink;
        Bottle5UnderCut.GetComponent<MeshRenderer>().material = Pink;

        Bottle1UpperCut.GetComponent<MeshRenderer>().material = Pink;
        Bottle2UpperCut.GetComponent<MeshRenderer>().material = Pink;
        Bottle3UpperCut.GetComponent<MeshRenderer>().material = Pink;
        Bottle4UpperCut.GetComponent<MeshRenderer>().material = Pink;
        Bottle5UpperCut.GetComponent<MeshRenderer>().material = Pink;

        ScreenManager.Instance.BGSpray.SetActive(false);
        ScreenManager.Instance.Done.SetActive(true);
        ScreenManager.Instance.BG.SetActive(false);
        ScreenManager.Instance.first.SetActive(false);
        ScreenManager.Instance.Second.SetActive(false);

        if (num == 4)
        {
            isSprayTrue = true;
        }
    }

    public void Done()
    {
        if (isSprayDone)
        {
            isSpray = true;

            Spray.Instance.Bottle.GetComponent<MeshRenderer>().material = Spray.Instance.material;
            Spray.Instance.BottleUp.GetComponent<SkinnedMeshRenderer>().material = Spray.Instance.material;

            canvas1.SetActive(true);
            canvas2.SetActive(true);
            canvas3.SetActive(true);
            canvas4.SetActive(true);
            canvas5.SetActive(true);

            SprayBottleChoose1.SetActive(false);
            SprayBottleChoose2.SetActive(false);
            SprayBottleChoose3.SetActive(false);
            SprayBottleChoose4.SetActive(false);
            SprayBottleChoose5.SetActive(false);
            isSpray = true;
            knifeTool.SetActive(true);
            ScreenManager.Instance.Done.SetActive(false);
        }
    }

    public void DoneBottle()
    {
        ZoomOutCam.SetActive(true);
        ZoomInCam.SetActive(false);
        isComplete = true;
        ScreenManager.Instance.DoneBottle.SetActive(false);
    }

    IEnumerator ChangeCam(float sec)
    {
        yield return new WaitForSeconds(sec);
        ScreenManager.Instance.BG.SetActive(false);
        ZoomOutCam.SetActive(false);
        ZoomInCam.SetActive(true);
        ScreenManager.Instance.BGSpray.SetActive(true);
        Bottle1.SetActive(false);
        Bottle2.SetActive(false);
        Bottle3.SetActive(false);
        Bottle4.SetActive(false);
        Bottle5.SetActive(false);
        ScreenManager.Instance.bottleBG[0].SetActive(false);
        ScreenManager.Instance.bottleBG[1].SetActive(false);
        ScreenManager.Instance.bottleBG[2].SetActive(false);
        ScreenManager.Instance.bottleBG[3].SetActive(false);
        ScreenManager.Instance.bottleBG[4].SetActive(false);
        ScreenManager.Instance.firstBottle[0].SetActive(false);
        ScreenManager.Instance.firstBottle[1].SetActive(false);
        ScreenManager.Instance.firstBottle[2].SetActive(false);
        ScreenManager.Instance.firstBottle[3].SetActive(false);
        ScreenManager.Instance.firstBottle[4].SetActive(false);
        ScreenManager.Instance.secondBottle[0].SetActive(false);
        ScreenManager.Instance.secondBottle[1].SetActive(false);
        ScreenManager.Instance.secondBottle[2].SetActive(false);
        ScreenManager.Instance.secondBottle[3].SetActive(false);
        ScreenManager.Instance.secondBottle[4].SetActive(false);

        ScreenManager.Instance.first.SetActive(false);
        ScreenManager.Instance.Second.SetActive(false);
    }
}
