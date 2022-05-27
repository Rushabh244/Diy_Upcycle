using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public static Knife Instance;

    public GameObject MainCanvas;
    public GameObject MainPoints;
    public GameObject cutBottle;
    public GameObject cutBottle_Upper;
    public GameObject cutBottle_Lower;
    public GameObject CutCanvas;
    public GameObject cutbottle_Cut;
    public GameObject cutbottle_Cut_Upper;
    public GameObject cutbottle_Cut_Lower;

    public GameObject cutBottle_Main;
    public GameObject cutBottle_Upper_Main;
    public GameObject cutBottle_Lower_Main;

    Ray camRay;
    public Vector3 startPos, point;

    public Transform KnifeTra;

    public LayerMask LayerMask;

    public bool isDrag;

    public Points point1;
    public Points point2;
    public Points point3;
    public Points point4;
    public Points point5;
    public Points point6;
    public Points point7;
    public Points point8;
    public Points point9;
    public Points point10;
    public Points point11;
    public Points point12;

    public Points new1;
    public Points new2;
    public Points new3;
    public Points new4;
    public Points new5;
    public Points new6;
    public Points new7;
    public Points new8;
    public Points new9;
    public Points new10;

    public GameObject closeObject;

    public Vector3 quaternion;

    Vector3 IntialPos;
    Vector3 CurrentPos;
    public float errorRange;
    public bool isHorizontalSwipe;
    //public ParticleSystem BottleCut;
    //public ParticleSystem BottleCut2;

    public Camera camera;
    Vector3 camPos;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        startPos = KnifeTra.position;
        camPos = camera.transform.position;

        startPos.y = 3.3945f;
        //pos = transform.position;
    }

    IEnumerator camChange(float sec)
    {
        yield return new WaitForSeconds(sec);

        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, 35, 2 * Time.deltaTime);
    }

    private void Update()
    {
        if(camera.fieldOfView > 35 && GameManager.Instance.isSpray)
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, 35, 1 * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            isDrag = true;
            IntialPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
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

                KnifeTra.position = new Vector3(point.x, startPos.y, point.z + 0.08f);
            }
        }

        if (point1.isKnife && point2.isKnife && point3.isKnife && point4.isKnife && point5.isKnife && point6.isKnife && point7.isKnife && point8.isKnife && point9.isKnife
            && point10.isKnife && point11.isKnife && point12.isKnife)
        {
            //KnifeTra.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            //camera.fieldOfView = 40;
            cutBottle.SetActive(true);
            cutBottle_Main.SetActive(true);
            CutCanvas.SetActive(true);
            MainCanvas.SetActive(false);
            MainPoints.SetActive(false);
            closeObject.SetActive(false);
            startPos.y = 3.319f;
            GameManager.Instance.isTrue = true;
        }

        if (new1.isKnife && new2.isKnife && new3.isKnife && new4.isKnife && new5.isKnife && new6.isKnife && new7.isKnife && new8.isKnife && new9.isKnife && new10.isKnife)
        {
            CutCanvas.SetActive(false);
            cutbottle_Cut.SetActive(false);
            cutbottle_Cut_Upper.SetActive(false);
            cutbottle_Cut_Lower.SetActive(false);

            ScreenManager.Instance.DoneBottle.SetActive(true);
        }
    }

    #region Old

    //private void OnMouseDown()
    //{
    //    startPos = KnifeTra.position; // save position in case draged to invalid place
    //    //movePlane = new Plane(-Camera.main.transform.forward, transform.position);
    //}

    //private void OnMouseDrag()
    //{
    //    camRay = Camera.main.ScreenPointToRay(Input.mousePosition); // shoot a ray at the obj from mouse screen point
    //    RaycastHit raycastHit;

    //    Debug.Log("Ray1 " + point);

    //    if (Physics.Raycast(camRay, out raycastHit, 100000, LayerMask))
    //    {
    //        //point = camRay.GetPoint(hitDist);
    //        point = raycastHit.point;

    //        Debug.Log("Ray " + point);
    //        float x = Mathf.Clamp(point.x, -0.11f, 0.18f);
    //        //float z = Mathf.Clamp(-point.z, 0, -0.12f);
    //        KnifeTra.position = new Vector3(x, startPos.y, point.z);

    //        //Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
    //        //Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //        //float x = Mathf.Clamp(-objPosition.x, -0.1f, 0.18f);
    //        //transform.position = new Vector3(x, pos.y, pos.z);
    //    }
    //}

    #endregion
}
