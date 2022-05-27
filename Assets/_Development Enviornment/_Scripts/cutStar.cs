using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutStar : MonoBehaviour
{
    public bool isBlend;

    public GameObject candleParticle;

    public SkinnedMeshRenderer skinnedMesh;
    public float blendOne = 0f;
    float blendTwo = 0f;
    float blendSpeed = 0.3f;
    bool blendOneFinished = false;
    float newBland;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isBlend && StarDrag.Instance.isDragCutStar)
        {
            candleParticle.SetActive(true);
            if (newBland >= 90 && newBland <= 110 && !blendOneFinished)
            {
                ScreenManager.Instance.fill.color = Color.green;
            }
            else if (blendOneFinished)
            {
                ScreenManager.Instance.fill.color = Color.red;
            }

            if (newBland <= 110 && !blendOneFinished)
            {
                skinnedMesh.SetBlendShapeWeight(0, blendOne);
                skinnedMesh.SetBlendShapeWeight(1, blendOne);
                skinnedMesh.SetBlendShapeWeight(2, blendOne);
                skinnedMesh.SetBlendShapeWeight(3, blendOne);
                skinnedMesh.SetBlendShapeWeight(4, blendOne);

                blendOne += blendSpeed;
                newBland += blendSpeed;
                ScreenManager.Instance.slider.value = newBland;
            }

            else if (newBland > 110)
            {
                blendOneFinished = true;
            }
        }
        else
        {
            candleParticle.SetActive(false);
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

            candleParticle.SetActive(false);
        }
    }
}
