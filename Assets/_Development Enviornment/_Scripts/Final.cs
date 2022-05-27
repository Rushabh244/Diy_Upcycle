using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    Vector3 point;
    Ray camRay;
    bool isDrag;
    public LayerMask LayerMask;
    public LayerMask LayerMask2;

    public Transform star;
    public GameObject box;

    public bool isDone;
    public bool isStar;
    public bool isStar2;
    public bool isBigLeaf;
    public bool isLeaf2;
    public bool isLeaf3;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnMouseDown()
    {
        isDrag = true;
        Debug.Log("Mouse Dowm");
        RaycastHit raycastHit;

        if (Physics.Raycast(camRay, out raycastHit, 100000, LayerMask))
        {
            star = raycastHit.transform;
            box.SetActive(true);
        }
    }

    private void OnMouseUp()
    {
        isDrag = false;
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetMouseButtonUp(0))
        //{
        //    isDrag = false;
        //    //if(transform.position )
        //}

        if (isDrag && !isDone)
        {
            camRay = Camera.main.ScreenPointToRay(Input.mousePosition); // shoot a ray at the obj from mouse screen point
            Debug.Log("camRay " + camRay);
            RaycastHit raycastHit;

            if (Physics.Raycast(camRay, out raycastHit, 100000, LayerMask2))
            {
                point = raycastHit.point;
                Debug.Log("Point " + point);

                //transform.position = new Vector3(point.x, point.y, 22.434f);
                transform.position = new Vector3(point.x, 3.039f, point.z);
                //transform.position = point;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("star"))
        {
            if (isStar)
            {
                transform.position = other.transform.position;
                isDone = true;
            }
        }
        if(other.gameObject.CompareTag("star2"))
        {
            if (isStar2)
            {
                transform.position = other.transform.position;
                isDone = true;
            }
        }
        if(other.gameObject.CompareTag("bigleaf"))
        {
            if (isBigLeaf)
            {
                transform.position = other.transform.position;
                isDone = true;
            }
        }
        if(other.gameObject.CompareTag("smallleaf1"))
        {
            if (isLeaf2)
            {
                transform.position = other.transform.position;
                isDone = true;
            }
        }
        if(other.gameObject.CompareTag("smallleaf2"))
        {
            if (isLeaf3)
            {
                transform.position = other.transform.position;
                isDone = true;
            }
        }
    }
}
