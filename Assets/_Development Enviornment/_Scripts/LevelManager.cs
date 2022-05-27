using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject shop;
    public GameObject Nackles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isComplete)
        {
            StartCoroutine(changeLevel(2));
        }
    }

    IEnumerator changeLevel(float sec)
    {
        yield return new WaitForSeconds(sec);

        shop.SetActive(false);
        Nackles.SetActive(true);
    }
}
