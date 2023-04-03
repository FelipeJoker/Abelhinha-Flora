using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public int FlowerType = 1;

    public bool hasBeenTouched = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrepareToBeCollectedAgain()
    {
        StartCoroutine(WaitToTryCollectingAgain());
    }

    IEnumerator WaitToTryCollectingAgain()
    {
        float tempinho = 0;

        do
        {
            tempinho += Time.deltaTime;
            yield return null;
        }
        while (tempinho < 1f);

        hasBeenTouched = false;

    }


}
