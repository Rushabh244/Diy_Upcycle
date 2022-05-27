using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeCollide : MonoBehaviour
{
    public ParticleSystem BottleCut;
    public ParticleSystem BottleCut2;

    bool isCollide;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isCollide)
        {
            if (Knife.Instance.isDrag)
            {
                BottleCut.Play();
                BottleCut2.Play();
            }
            if (!Knife.Instance.isDrag)
            {
                BottleCut.Stop();
                BottleCut2.Stop();
            }
        }
        if(!isCollide)
        {
            BottleCut.Stop();
            BottleCut2.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bottle"))
        {
            isCollide = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bottle"))
        {
            isCollide = false;
        }
    }
}
