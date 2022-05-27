using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NacklaceManager : MonoBehaviour
{
    public static NacklaceManager Instance;

    public bool isleafDone;
    public bool isStarDone;


    public GameObject star1; 
    public GameObject star2; 
    public GameObject Leaf; 
    public GameObject Leaf2; 
    public GameObject Leaf3;

    public bool starDone;
    public bool star2Done;
    public bool LeafDone;
    public bool Leaf2Done;
    public bool Leaf3Done;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(star1.GetComponent<Final>().isDone && star2.GetComponent<Final>().isDone && Leaf.GetComponent<Final>().isDone && Leaf2.GetComponent<Final>().isDone 
            && Leaf3.GetComponent<Final>().isDone)
        {
            if(star1.GetComponent<cutStar>().blendOne >= 90 && star1.GetComponent<cutStar>().blendOne <= 110)
            {
                starDone = true;
            }
            if(star2.GetComponent<cutStar>().blendOne >= 90 && star2.GetComponent<cutStar>().blendOne <= 110)
            {
                star2Done = true;
            }
            if(Leaf.GetComponent<LeafDrag>().newBland >= 90 && Leaf.GetComponent<LeafDrag>().newBland <= 105)
            {
                LeafDone = true;
            }
            if(Leaf2.GetComponent<LeafDrag>().newBland >= 90 && Leaf2.GetComponent<LeafDrag>().newBland <= 105)
            {
                Leaf2Done = true;
            }
            if(Leaf3.GetComponent<LeafDrag>().newBland >= 90 && Leaf3.GetComponent<LeafDrag>().newBland <= 105)
            {
                Leaf3Done = true;
            }

            if (starDone && star2Done && LeafDone && Leaf2Done && Leaf3Done)
            {
                StartCoroutine(win(2));
            }
            if (!starDone || !star2Done || !LeafDone || !Leaf2Done || !Leaf3Done)
            {
                StartCoroutine(Loss(2));
            }
        }
    }

    IEnumerator win(float sec)
    {
        yield return new WaitForSeconds(sec);

        ScreenManager.Instance.GameplayScreenObject.SetActive(false);
        ScreenManager.Instance.VictoryScreenObject.SetActive(true);
        ScreenManager.Instance.level1 = true;
        ScreenManager.Instance.level2 = false;
    }

    IEnumerator Loss(float sec)
    {
        yield return new WaitForSeconds(sec);
        ScreenManager.Instance.GameplayScreenObject.SetActive(false);
        ScreenManager.Instance.FailScreenObject.SetActive(true);
        ScreenManager.Instance.level1 = false;
        ScreenManager.Instance.level2 = true;
    }
}
