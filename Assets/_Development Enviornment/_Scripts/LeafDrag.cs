using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeafDrag : MonoBehaviour
{
    public static LeafDrag Instance;

    Vector3 startPos, point;
    Ray camRay;
    bool isDrag;
    public LayerMask LayerMask;
    public LayerMask LayerMask2;

    public Transform star;
    public GameObject box;
    public bool isBlend;

    public SkinnedMeshRenderer skinnedMesh;
    float blendOne = 0f;
    float blendTwo = 0f;
    float blendSpeed = 0.3f;
    bool blendOneFinished = false;
    public float newBland;

    public GameObject BigLeaf;
    public GameObject smallLeaf;
    public GameObject smallLeaf1; 
    
    public GameObject Leafchild;

    public GameObject cutPiece;
    public GameObject candleScene;
    public GameObject nacklesMakingScene;

    public GameObject candleParticle;

    //public GameObject LeafDone;

    public Transform starPos;

    public ParticleSystem particle;

    float x, y;
    BoxCollider collider;

    //public bool isleafDone;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        startPos = transform.position;
        ScreenManager.Instance.LeafDone.SetActive(true);
        collider = GetComponent<BoxCollider>();
        x = 0.14f;
        y = 0.15f;
        ScreenManager.Instance.bottleText.SetActive(false);
        ScreenManager.Instance.planeText.SetActive(false);
        ScreenManager.Instance.shapeText.SetActive(false);
        ScreenManager.Instance.StarMoldText.SetActive(false);
        ScreenManager.Instance.starText.SetActive(false);
        ScreenManager.Instance.leafText.SetActive(true);
        ScreenManager.Instance.arrangeText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrag = true;
            RaycastHit raycastHit;

            if (Physics.Raycast(camRay, out raycastHit, 100000, LayerMask))
            {
                star = raycastHit.transform;
                box.SetActive(true);
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

                //transform.position = new Vector3(point.x, point.y, 22.434f);
                transform.position = new Vector3(point.x, point.y, 22.176f);
                //transform.position = point;
            }
        }

        if (isBlend && isDrag)
        {
            if (x >= 0.055)
            {
                x -= 0.0002f;
            }
            if (y >= 0.055)
            {
                y -= 0.0002f;
            }

            collider.size = new Vector3(x, y, 0.03998369f);
            candleParticle.SetActive(true);
            if (newBland >= 90 && newBland <= 105 && !blendOneFinished)
            {
                ScreenManager.Instance.fill.color = Color.green;
            }
            else if (blendOneFinished)
            {
                ScreenManager.Instance.fill.color = Color.red;
            }

            if (newBland <= 105 && !blendOneFinished)
            {
                skinnedMesh.SetBlendShapeWeight(0, blendOne);

                blendOne += blendSpeed;
                newBland += blendSpeed;
                ScreenManager.Instance.slider.value = newBland;
            }

            else if (newBland > 105)
            {
                blendOneFinished = true;
            }

            if (blendOneFinished && blendTwo < 100)
            {
                skinnedMesh.SetBlendShapeWeight(1, blendTwo);
                skinnedMesh.SetBlendShapeWeight(0, blendOne);
                blendTwo += blendSpeed;
                blendOne -= blendSpeed;
                newBland += blendSpeed;
                ScreenManager.Instance.slider.value = newBland;
            }
            else if (blendTwo > 90)
            {
                isBlend = false;
                this.gameObject.tag = "Untagged";
            }
        }
        else
        {
            candleParticle.SetActive(false);
        }
    }

    public void leafdone()
    {
        ScreenManager.Instance.leafText.SetActive(false);
        ScreenManager.Instance.slider.value = 0;
        ScreenManager.Instance.fill.color = Color.yellow;
        particle.Play();
        if (BigLeaf.activeInHierarchy)
        {
            Leafchild.transform.SetParent(starPos);
            Leafchild.transform.localPosition = new Vector3(0, 0, 0);
            Leafchild.transform.rotation = new Quaternion(0, 0, 0, 0);
            Leafchild.transform.localScale = new Vector3(1, 1, 1);
            Leafchild.GetComponent<LeafDrag>().enabled = false;
            Leafchild.GetComponent<Final>().enabled = true;

            ScreenManager.Instance.LeafDone.SetActive(false);
            if (newBland >= 90 && newBland <= 105)
            {
                ScreenManager.Instance.LeafBg.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.Leaf.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.leafDoneMark.SetActive(true);
                BigLeaf.SetActive(false);
                smallLeaf.SetActive(true);
            }

            if (newBland < 90 || newBland > 105)
            {
                ScreenManager.Instance.Leaf.SetActive(false);
                ScreenManager.Instance.LeafRed.SetActive(true);
                ScreenManager.Instance.LeafBg.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.LeafRed.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.leafDoneMark.SetActive(true);
                BigLeaf.SetActive(false);
                smallLeaf.SetActive(true);
            }
        }
        else if (smallLeaf.activeInHierarchy && !smallLeaf1.activeInHierarchy)
        {
            Leafchild.transform.SetParent(starPos);
            Leafchild.transform.localPosition = new Vector3(0, 0, 0);
            Leafchild.transform.rotation = new Quaternion(0, 0, 0, 0);
            Leafchild.transform.localScale = new Vector3(1, 1, 1);
            Leafchild.GetComponent<LeafDrag>().enabled = false;
            Leafchild.GetComponent<Final>().enabled = true;

            ScreenManager.Instance.LeafDone.SetActive(false);
            if (newBland >= 90 && newBland <= 105)
            {
                ScreenManager.Instance.smallLeafBg.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.smallLeaf.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.SmallleafDoneMark.SetActive(true);
                smallLeaf.SetActive(false);
                smallLeaf1.SetActive(true);
            }

            if (newBland < 90 || newBland > 105)
            {
                ScreenManager.Instance.smallLeaf.SetActive(false);
                ScreenManager.Instance.smallLeafRed.SetActive(true);
                ScreenManager.Instance.smallLeafBg.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.smallLeafRed.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.SmallleafDoneMark.SetActive(true);
                smallLeaf.SetActive(false);
                smallLeaf1.SetActive(true);
            }
        }
        else if (smallLeaf1.activeInHierarchy)
        {
            Leafchild.transform.SetParent(starPos);
            Leafchild.transform.localPosition = new Vector3(0, 0, 0);
            Leafchild.transform.rotation = new Quaternion(0, 0, 0, 0);
            Leafchild.transform.localScale = new Vector3(1, 1, 1);
            Leafchild.GetComponent<LeafDrag>().enabled = false;
            Leafchild.GetComponent<Final>().enabled = true;

            ScreenManager.Instance.LeafBg.SetActive(false);
            ScreenManager.Instance.smallLeafBg.SetActive(false);
            ScreenManager.Instance.smallLeafBg1.SetActive(false);
            ScreenManager.Instance.LeafDone.SetActive(false);
            ScreenManager.Instance.leafDoneMark.SetActive(false);
            ScreenManager.Instance.SmallleafDoneMark.SetActive(false);
            //ScreenManager.Instance.SmallleafDoneMark1.SetActive(false);

            if (newBland >= 90 && newBland <= 105)
            {
                ScreenManager.Instance.smallLeafBg1.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.smallLeaf1.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.SmallleafDoneMark1.SetActive(true);
                //smallLeaf1.SetActive(false);
                NacklaceManager.Instance.isleafDone = true;

                if (NacklaceManager.Instance.isStarDone)
                {
                    nacklesMakingScene.SetActive(true);
                    candleScene.SetActive(false);
                    ScreenManager.Instance.SmallleafDoneMark1.SetActive(false);
                    ScreenManager.Instance.bottleText.SetActive(false);
                    ScreenManager.Instance.planeText.SetActive(false);
                    ScreenManager.Instance.shapeText.SetActive(false);
                    ScreenManager.Instance.StarMoldText.SetActive(false);
                    ScreenManager.Instance.starText.SetActive(false);
                    ScreenManager.Instance.leafText.SetActive(false);
                    ScreenManager.Instance.arrangeText.SetActive(true);
                    ScreenManager.Instance.SliderObj.SetActive(false);
                }
                if (!NacklaceManager.Instance.isStarDone)
                {
                    candleScene.SetActive(false);
                    cutPiece.SetActive(true);
                    ScreenManager.Instance.StarBg.SetActive(true);
                    ScreenManager.Instance.StarBg1.SetActive(true);
                    ScreenManager.Instance.SmallleafDoneMark1.SetActive(false);
                }
            }

            if (newBland < 90 || newBland > 105)
            {
                ScreenManager.Instance.smallLeaf1.SetActive(false);
                ScreenManager.Instance.smallLeaf1Red.SetActive(true);
                ScreenManager.Instance.smallLeafBg1.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.smallLeaf1Red.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                ScreenManager.Instance.SmallleafDoneMark1.SetActive(true);
                //smallLeaf1.SetActive(false);
                NacklaceManager.Instance.isleafDone = true;

                if (NacklaceManager.Instance.isStarDone)
                {
                    nacklesMakingScene.SetActive(true);
                    candleScene.SetActive(false);
                    ScreenManager.Instance.SmallleafDoneMark1.SetActive(false);
                }
                if (!NacklaceManager.Instance.isStarDone)
                {
                    candleScene.SetActive(false);
                    cutPiece.SetActive(true);
                    ScreenManager.Instance.StarBg.SetActive(true);
                    ScreenManager.Instance.StarBg1.SetActive(true);
                    ScreenManager.Instance.SmallleafDoneMark1.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("candle"))
        {
            isBlend = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("candle"))
        {
            isBlend = false;
        }
    }

}
