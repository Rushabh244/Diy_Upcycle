using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour
{
    public static Spray Instance;

    Vector3 startPos, point;
    Ray camRay;
    bool isDrag;
    public LayerMask LayerMask;

    public ParticleSystem SprayColor;
    public Material material;
    public GameObject Bottle;
    public GameObject BottleUp;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        startPos = transform.position;

        //if(GameManager.Instance.Cut_Bottle1.activeInHierarchy)
        //{
        //    Bottle = GameManager.Instance.Cut_BottleDown1;
        //    BottleUp = GameManager.Instance.Cut_BottleUp1;
        //}

        //if(GameManager.Instance.Cut_Bottle2.activeInHierarchy)
        //{
        //    Bottle = GameManager.Instance.Cut_BottleDown2;
        //    BottleUp = GameManager.Instance.Cut_BottleUp2;
        //}

        //if(GameManager.Instance.Cut_Bottle3.activeInHierarchy)
        //{
        //    Bottle = GameManager.Instance.Cut_BottleDown3;
        //    BottleUp = GameManager.Instance.Cut_BottleUp3;
        //}

        //if(GameManager.Instance.Cut_Bottle4.activeInHierarchy)
        //{
        //    Bottle = GameManager.Instance.Cut_BottleDown4;
        //    BottleUp = GameManager.Instance.Cut_BottleUp4;
        //}

        if(GameManager.Instance.Cut_Bottle5.activeInHierarchy)
        {
            Bottle = GameManager.Instance.Cut_BottleDown5;
            BottleUp = GameManager.Instance.Cut_BottleUp5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrag = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
            SprayColor.Stop();
            GameManager.Instance.isSprayDone = true;
            //Bottle.GetComponent<MeshRenderer>().material = material;
        }

        if(GameManager.Instance.isSpray)
        {
            //Bottle.GetComponent<MeshRenderer>().material = material;
        }

        if (isDrag)
        {
            SprayColor.Play();
            camRay = Camera.main.ScreenPointToRay(Input.mousePosition); // shoot a ray at the obj from mouse screen point

            RaycastHit raycastHit;

            if (Physics.Raycast(camRay, out raycastHit, 100000, LayerMask))
            {
                point = raycastHit.point;

                transform.position = new Vector3(point.x, startPos.y, point.z);
            }
        }
    }
}
