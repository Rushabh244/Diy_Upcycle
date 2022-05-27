using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Animator anim;

    public Transform[] Path;
    public Transform CurrentPathTrans;
    public int CurrentPathPoint;
    public float Distance;

    public float WaitTime = 0f;

    //public Color PathColor;

    public int speed;
    public int Rotationspeed;

    public int CurrentPathPointTime;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetInteger("Girl", 0); 
        CurrentPathPoint = 0;
        CurrentPathTrans = Path[CurrentPathPoint];

        if (CurrentPathPoint == 0) WaitTime = UnityEngine.Random.Range(0f, 0.1f);
    }
    private void SetTime()
    {
        CurrentPathPointTime = UnityEngine.Random.Range(0, Path.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentPathTrans == null) return;

        if (WaitTime > 0)
        {
            WaitTime -= Time.deltaTime;

            anim.SetInteger("Girl", 1);

            return;
        }

        Vector3 pointPosition = new Vector3(CurrentPathTrans.position.x, this.transform.position.y, CurrentPathTrans.position.z);
        Distance = Vector3.Distance(this.transform.position, pointPosition);

        if (Distance < 0.1f)
        {
            CurrentPathPoint++;

            if (CurrentPathPoint >= Path.Length)
            {
                CurrentPathPoint = 0;
            }
            if (CurrentPathPointTime == CurrentPathPoint)
            {
                speed = 0;
                Rotationspeed = 0;

                if (!GameManager.Instance.isComplete)
                {
                    anim.SetInteger("Girl", 2);
                    GameManager.Instance.isTalk = true;
                }
            }

            CurrentPathTrans = Path[CurrentPathPoint];
        }

        if(GameManager.Instance.isComplete)
        {
            if(GameManager.Instance.isTrue && GameManager.Instance.isSprayTrue && GameManager.Instance.isBottleTrue)
            {
                anim.SetInteger("Girl", 3);
                StartCoroutine(win(2));
            } 
            if(GameManager.Instance.isFlase || !GameManager.Instance.isSprayTrue || !GameManager.Instance.isBottleTrue)
            {
                anim.SetInteger("Girl", 4);
                StartCoroutine(Loss(2));
            }
        }

        this.transform.position = Vector3.MoveTowards(this.transform.position, pointPosition, speed * Time.deltaTime);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            Quaternion.LookRotation(CurrentPathTrans.position - transform.position)
            , Rotationspeed * Time.deltaTime);
    }

    IEnumerator win(float sec)
    {
        yield return new WaitForSeconds(sec);
        ScreenManager.Instance.GameplayScreenObject.SetActive(false);
        ScreenManager.Instance.VictoryScreenObject.SetActive(true);
    }
    
    IEnumerator Loss(float sec)
    {
        yield return new WaitForSeconds(sec);
        ScreenManager.Instance.GameplayScreenObject.SetActive(false);
        ScreenManager.Instance.FailScreenObject.SetActive(true);
        ScreenManager.Instance.isStart = false;
    }

    //public void BottleUI()
    //{
    //    ScreenManager.Instance.first.SetActive(true);

    //    int count = Random.Range(0, ScreenManager.Instance.firstBottle.Length - 1);

    //    ScreenManager.Instance.firstBottle[count].SetActive(true);
    //}

    public void BottleCutUI()
    {
        ScreenManager.Instance.first.SetActive(false);
        ScreenManager.Instance.Second.SetActive(true);

        int count = Random.Range(0, ScreenManager.Instance.secondBottle.Length - 1);
        GameManager.Instance.num = count;
        ScreenManager.Instance.secondBottle[count].SetActive(true);
    }

}
