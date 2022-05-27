using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public bool isKnife;
    public int count;

    public bool blend1;
    public bool blend2;
    public bool blend3;
    public bool blend4;
    public bool blend5;
    public bool blend6;
    public bool blend7;
    public bool blend8;
    public bool blend9;
    public bool blend10;
    public bool blend11;
    public bool blend12;

    float blendOne = 0f;
    float blendSpeed = 0.2f;

    public SkinnedMeshRenderer skinnedMesh;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isKnife)
        {
            if (blend1 && blendOne < 100)
            {
                skinnedMesh.SetBlendShapeWeight(0, blendOne);
                blendOne += blendSpeed;
            }
            if (blend2 && blendOne < 100)
            {
                skinnedMesh.SetBlendShapeWeight(1, blendOne);
                blendOne += blendSpeed;
            }
            if (blend3 && blendOne < 100)
            {
                skinnedMesh.SetBlendShapeWeight(2, blendOne);
                blendOne += blendSpeed;
            }
            if (blend4 && blendOne < 100)
            {
                skinnedMesh.SetBlendShapeWeight(3, blendOne);
                blendOne += blendSpeed;
            }
            if (blend5 && blendOne < 100)
            {
                skinnedMesh.SetBlendShapeWeight(4, blendOne);
                blendOne += blendSpeed;
            }
            if (blend6 && blendOne < 100)
            {
                skinnedMesh.SetBlendShapeWeight(5, blendOne);
                blendOne += blendSpeed;
            }
            if (blend7 && blendOne < 100)
            {
                skinnedMesh.SetBlendShapeWeight(6, blendOne);
                blendOne += blendSpeed;
            }
            if (blend8 && blendOne < 100)
            {
                skinnedMesh.SetBlendShapeWeight(7, blendOne);
                blendOne += blendSpeed;
            }
            if (blend9 && blendOne < 100)
            {
                skinnedMesh.SetBlendShapeWeight(8, blendOne);
                blendOne += blendSpeed;
            }
            if (blend10 && blendOne < 100)
            {
                skinnedMesh.SetBlendShapeWeight(9, blendOne);
                blendOne += blendSpeed;
            }
            if (blend11 && blendOne < 100)
            {
                skinnedMesh.SetBlendShapeWeight(10, blendOne);
                blendOne += blendSpeed;
            }
            if (blend12 && blendOne < 100)
            {
                skinnedMesh.SetBlendShapeWeight(11, blendOne);
                blendOne += blendSpeed;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("knife"))
        {
            if (count < 1)
            {
                count += 1;
                isKnife = true;
            }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("knife"))
    //    {
    //        if (blend1 && blendOne < 100)
    //        {
    //            skinnedMesh.SetBlendShapeWeight(0, blendOne);
    //            blendOne += blendSpeed;
    //        }
    //        if (blend2 && blendOne < 100)
    //        {
    //            skinnedMesh.SetBlendShapeWeight(1, blendOne);
    //            blendOne += blendSpeed;
    //        }
    //        if (blend3 && blendOne < 100)
    //        {
    //            skinnedMesh.SetBlendShapeWeight(2, blendOne);
    //            blendOne += blendSpeed;
    //        }
    //        if (blend4 && blendOne < 100)
    //        {
    //            skinnedMesh.SetBlendShapeWeight(3, blendOne);
    //            blendOne += blendSpeed;
    //        }
    //        if (blend5 && blendOne < 100)
    //        {
    //            skinnedMesh.SetBlendShapeWeight(4, blendOne);
    //            blendOne += blendSpeed;
    //        }
    //        if (blend6 && blendOne < 100)
    //        {
    //            skinnedMesh.SetBlendShapeWeight(5, blendOne);
    //            blendOne += blendSpeed;
    //        }
    //        if (blend7 && blendOne < 100)
    //        {
    //            skinnedMesh.SetBlendShapeWeight(6, blendOne);
    //            blendOne += blendSpeed;
    //        }
    //        if (blend8 && blendOne < 100)
    //        {
    //            skinnedMesh.SetBlendShapeWeight(7, blendOne);
    //            blendOne += blendSpeed;
    //        }
    //        if (blend9 && blendOne < 100)
    //        {
    //            skinnedMesh.SetBlendShapeWeight(8, blendOne);
    //            blendOne += blendSpeed;
    //        }
    //        if (blend10 && blendOne < 100)
    //        {
    //            skinnedMesh.SetBlendShapeWeight(9, blendOne);
    //            blendOne += blendSpeed;
    //        }
    //        if (blend11 && blendOne < 100)
    //        {
    //            skinnedMesh.SetBlendShapeWeight(10, blendOne);
    //            blendOne += blendSpeed;
    //        }
    //        if (blend12 && blendOne < 100)
    //        {
    //            skinnedMesh.SetBlendShapeWeight(11, blendOne);
    //            blendOne += blendSpeed;
    //        }
    //    }
    //}
}
