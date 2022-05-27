using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDrag : MonoBehaviour
{
    public static StarDrag Instance;

    Vector3 startPos, point;
    Ray camRay;
    public bool isDrag;
    public bool isDragCutStar;
    public bool isDone;
    public LayerMask LayerMask;
    public LayerMask LayerMask2;
    public LayerMask LayerMask3;

    public GameObject BluePlane;
    public GameObject GreenPlane;

    public Transform star;
    public GameObject box;

    public GameObject cutPiece;
    public GameObject candleScene;
    public GameObject nacklesMakingScene;

    public Material material;

    bool isBlend;

    public Color startcolor;
    public Color endcolor;

    public GameObject starObj;
    public GameObject starObj2;

    public GameObject candleParticle;

    //public bool isStarDone;

    public GameObject CutStar;
    public GameObject CutStarNew;

    public Transform starPos;

    //public GameObject starDone;
    public ParticleSystem particle;
    public ParticleSystem particle2;

    //public GameObject Text;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        startPos = transform.position;
        material.color = startcolor;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDone)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDrag = true;
                RaycastHit raycastHit;

                if (Physics.Raycast(camRay, out raycastHit, 100000, LayerMask))
                {
                    ScreenManager.Instance.TextImage.SetActive(false);
                    star = raycastHit.transform;
                    BluePlane.SetActive(false);
                    GreenPlane.transform.position = new Vector3(0.251f, 3.02f, 22.434f);
                    box.SetActive(true);
                    ScreenManager.Instance.StarBg.SetActive(true);
                    ScreenManager.Instance.StarBg1.SetActive(true);
                }

                if (Physics.Raycast(camRay, out raycastHit, 100000, LayerMask3))
                {
                    candleScene.SetActive(true);
                    cutPiece.SetActive(false);
                    ScreenManager.Instance.SliderObj.SetActive(true);
                    ScreenManager.Instance.LeafBg.SetActive(true);
                    ScreenManager.Instance.smallLeafBg.SetActive(true);
                    ScreenManager.Instance.smallLeafBg1.SetActive(true);
                    //ScreenManager.Instance.LeafDone.SetActive(true);
                    ScreenManager.Instance.slider.value = 0;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                isDrag = false;
                //if(transform.position )
            }

            if (isDrag)
            {
                camRay = Camera.main.ScreenPointToRay(Input.mousePosition); // shoot a ray at the obj from mouse screen point

                RaycastHit raycastHit;

                if (Physics.Raycast(camRay, out raycastHit, 100000, LayerMask2))
                {
                    point = raycastHit.point;

                    transform.position = new Vector3(point.x, point.y, 22.434f);
                    //transform.position = point;
                }
            }
        }

        if (isDone)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragCutStar = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isDragCutStar = false;
            }
            if (isDragCutStar)
            {
                camRay = Camera.main.ScreenPointToRay(Input.mousePosition); // shoot a ray at the obj from mouse screen point

                RaycastHit raycastHit;

                if (Physics.Raycast(camRay, out raycastHit, 100000, LayerMask2))
                {
                    point = raycastHit.point;

                    CutStarNew.transform.position = new Vector3(point.x, point.y, 22.434f);
                    //transform.position = point;
                }
            }
        }

        if (isBlend && isDrag)
        {
            candleParticle.SetActive(true);
            if (ScreenManager.Instance.slider.value < 180)
            {
                Color currentcolor = Color.Lerp(startcolor, endcolor, 15 * Time.deltaTime);
                material.color = currentcolor;
            }

            ScreenManager.Instance.slider.value += 1f;

            if (ScreenManager.Instance.slider.value >= 180)
            {
                ScreenManager.Instance.fill.color = Color.green;
                material.color = endcolor;
            }
        }
        else
        {
            candleParticle.SetActive(false);
        }
    }

    public void stardone()
    {
        ScreenManager.Instance.slider.value = 0;
        ScreenManager.Instance.fill.color = Color.yellow;

        particle2.Stop();

        if (starObj.activeInHierarchy)
        {
            CutStarNew.transform.SetParent(starPos);
            CutStarNew.transform.localPosition = new Vector3(0, 0, 0);
            CutStarNew.transform.rotation = new Quaternion(0, 0, 0, 0);
            CutStarNew.transform.localScale = new Vector3(1, 1, 1);
            CutStarNew.GetComponent<cutStar>().enabled = false;
            CutStarNew.GetComponent<Final>().enabled = true;

            if (ScreenManager.Instance.slider.value >= 90 && ScreenManager.Instance.slider.value <= 105)
            {
                ScreenManager.Instance.StarBg.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.Star.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.StarDoneMark.SetActive(true);
                starObj.SetActive(false);
                starObj2.SetActive(true);

                ScreenManager.Instance.starDone.SetActive(false);
            }

            if (ScreenManager.Instance.slider.value <= 90 || ScreenManager.Instance.slider.value >= 105)
            {
                //ScreenManager.Instance.Star.SetActive(false);
                //ScreenManager.Instance.LeafRed.SetActive(true);
                ScreenManager.Instance.StarBg.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                //ScreenManager.Instance.LeafRed.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.StarDoneMark.SetActive(true);
                starObj.SetActive(false);
                starObj2.SetActive(true);
                ScreenManager.Instance.starDone.SetActive(false);
            }
        }
        else if (starObj2.activeInHierarchy)
        {
            CutStarNew.transform.SetParent(starPos);
            CutStarNew.transform.localPosition = new Vector3(0, 0, 0);
            CutStarNew.transform.rotation = new Quaternion(0, 0, 0, 0);
            CutStarNew.transform.localScale = new Vector3(1, 1, 1);
            CutStarNew.GetComponent<cutStar>().enabled = false;
            CutStarNew.GetComponent<Final>().enabled = true;

            if (ScreenManager.Instance.slider.value >= 90 && ScreenManager.Instance.slider.value <= 105)
            {
                ScreenManager.Instance.StarBg1.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.Star1.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.StarDoneMark1.SetActive(true);
                //starObj2.SetActive(false);

                NacklaceManager.Instance.isStarDone = true;
                ScreenManager.Instance.starDone.SetActive(false);

                StartCoroutine(changeScene(2));
            }

            if (ScreenManager.Instance.slider.value <= 90 || ScreenManager.Instance.slider.value >= 105)
            {
                //ScreenManager.Instance.Star1.SetActive(false);
                //ScreenManager.Instance.smallLeafRed.SetActive(true);
                ScreenManager.Instance.StarBg1.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                //ScreenManager.Instance.smallLeafRed.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.StarDoneMark1.SetActive(true);
                //starObj2.SetActive(false);

                NacklaceManager.Instance.isStarDone = true;
                ScreenManager.Instance.starDone.SetActive(false);

                StartCoroutine(changeScene(2));
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("starcut"))
        {
            if(ScreenManager.Instance.slider.value < 180)
            {
                transform.position = startPos;
                ScreenManager.Instance.TextImage.SetActive(true);
            }

            if (ScreenManager.Instance.slider.value >= 180)
            {
                transform.position = other.transform.position;
                isDone = true;
                //material.color = startcolor;
                StartCoroutine(starJump(2));
            }
        }
        if (other.gameObject.CompareTag("candle"))
        {
            isBlend = true;
            ScreenManager.Instance.TextImage.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("candle"))
        {
            isBlend = false;
        }
    }

    IEnumerator starJump(float sec)
    {
        yield return new WaitForSeconds(sec);
        gameObject.GetComponent<Animator>().enabled = true;
        CutStar.SetActive(false);
        CutStarNew.SetActive(true);

        ScreenManager.Instance.fill.color = Color.yellow;
        ScreenManager.Instance.slider.value = 0;

        ScreenManager.Instance.starDone.SetActive(true);
        particle.Play();
    }

    IEnumerator changeScene(float sec)
    {
        yield return new WaitForSeconds(sec);

        if (NacklaceManager.Instance.isleafDone)
        {
            nacklesMakingScene.SetActive(true);
            cutPiece.SetActive(false);

            ScreenManager.Instance.StarBg.SetActive(false);
            ScreenManager.Instance.StarBg1.SetActive(false);
            ScreenManager.Instance.StarDoneMark.SetActive(false);
            ScreenManager.Instance.StarDoneMark1.SetActive(false);
        }
        if (!NacklaceManager.Instance.isleafDone)
        {
            candleScene.SetActive(true);
            cutPiece.SetActive(false);

            ScreenManager.Instance.StarBg.SetActive(false);
            ScreenManager.Instance.StarBg1.SetActive(false);
            ScreenManager.Instance.StarDoneMark.SetActive(false);
            ScreenManager.Instance.StarDoneMark1.SetActive(false);

            ScreenManager.Instance.LeafBg.SetActive(true);
            ScreenManager.Instance.smallLeafBg.SetActive(true);
            ScreenManager.Instance.smallLeafBg1.SetActive(true);
            //LeafDrag.Instance.LeafDone.SetActive(true);
        }
    }
}
