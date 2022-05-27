using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newBottleCut : MonoBehaviour
{
    Ray camRay;
    public Vector3 startPos, point;

    public Transform KnifeTra;

    public LayerMask LayerMask;

    bool isDrag;

    Vector3 IntialPos;
    Vector3 CurrentPos;
    public float errorRange;
    public bool isHorizontalSwipe;
    public ParticleSystem BottleCut;

    public Vector3 quaternion;

    public Points point1;
    public Points point2;
    public Points point3;
    public Points point4;

    public GameObject cutPieces;
    public GameObject BottleScene;

    // Start is called before the first frame update
    void Start()
    {
        startPos = KnifeTra.position;
        ScreenManager.Instance.bottleText.SetActive(true);
        ScreenManager.Instance.planeText.SetActive(false);
        ScreenManager.Instance.shapeText.SetActive(false);
        ScreenManager.Instance.StarMoldText.SetActive(false);
        ScreenManager.Instance.starText.SetActive(false);
        ScreenManager.Instance.leafText.SetActive(false);
        ScreenManager.Instance.arrangeText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ScreenManager.Instance.isStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDrag = true;
                BottleCut.Play();
                IntialPos = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDrag = false;
                BottleCut.Stop();
            }

            if (isDrag)
            {
                //BottleCut.Play();
                CurrentPos = Input.mousePosition;

                camRay = Camera.main.ScreenPointToRay(Input.mousePosition); // shoot a ray at the obj from mouse screen point

                RaycastHit raycastHit;

                if (Physics.Raycast(camRay, out raycastHit, 100000, LayerMask))
                {
                    point = raycastHit.point;

                    KnifeTra.position = new Vector3(point.x, point.y + 0.15f, startPos.z);

                    //if (Vector2.Distance(CurrentPos, IntialPos) > errorRange)
                    //{
                    //    float x = CurrentPos.x - IntialPos.x;
                    //    float y = CurrentPos.y - IntialPos.y;

                    //    isHorizontalSwipe = Mathf.Abs(x) > Mathf.Abs(y);

                    //    if (Mathf.Abs(x) > 0 || Mathf.Abs(y) > 0)
                    //    {
                    //        if (isHorizontalSwipe)
                    //        {
                    //            KnifeTra.localEulerAngles = new Vector3(0, 0, 0);
                    //        }
                    //        else if (!isHorizontalSwipe)
                    //        {
                    //            KnifeTra.localEulerAngles = quaternion;
                    //        }
                    //    }
                    //    IntialPos = Input.mousePosition;
                    //}
                }
            }
            if (point1.isKnife && point2.isKnife && point3.isKnife && point4.isKnife)
            {
                cutPieces.SetActive(true);
                BottleScene.SetActive(false);
                ScreenManager.Instance.SliderObj.SetActive(true);
                ScreenManager.Instance.slider.value = 0;
            }
        }
    }
}
