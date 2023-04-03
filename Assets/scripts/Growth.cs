using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth : MonoBehaviour
{
    [Header("Plant Parts")]
    public GameObject seedling;
    public GameObject twig;
    public GameObject leaf;
    public GameObject top1;
    public GameObject top2;
    public GameObject top3;

    public Vector3 seedlingSize;
    public Vector3 twigSize;
    public Vector3 leafSize;
    public Vector3 top1Size;
    public Vector3 top2Size;
    public Vector3 top3Size;

    [Header("Growth Parameters")]
    public float timeToGrow = 1;
    public float timeSpeed = 0.1f;
    public Vector3 smallestSize;

    [Header("Possible Plants")]
    public GameObject[] plantsArray;





    // Start is called before the first frame update
    void Start()
    {
        seedlingSize = seedling.transform.localScale;
        twigSize = twig.transform.localScale;
        leafSize = leaf.transform.localScale;
        top1Size = top1.transform.localScale;
        top2Size = top2.transform.localScale;
        top3Size = top3.transform.localScale;

        StartCoroutine(GrowToFullSize());
    }

    IEnumerator GrowToFullSize()
    {
        timeToGrow = Random.Range(1.5f, 4f);

        twig.SetActive(true);
        float timePassing =0;
        twig.transform.localScale = smallestSize;
        do
        {
            twig.transform.localScale = Vector3.Lerp(smallestSize, twigSize, timePassing / timeToGrow);

            timePassing += Time.deltaTime * timeSpeed;

            yield return null;


        }
        while (timePassing < timeToGrow);

        leaf.SetActive(true);
        timePassing = 0;
        leaf.transform.localScale = smallestSize;
        do
        {
            leaf.transform.localScale = Vector3.Lerp(smallestSize, leafSize, timePassing / timeToGrow);

            timePassing += Time.deltaTime * timeSpeed;

            yield return null;


        }
        while (timePassing < timeToGrow);

        top1.SetActive(true);
        timePassing = 0;
        top1.transform.localScale = smallestSize;
        do
        {
            top1.transform.localScale = Vector3.Lerp(smallestSize, top1Size, timePassing / timeToGrow);

            timePassing += Time.deltaTime * timeSpeed;

            yield return null;


        }
        while (timePassing < timeToGrow);

        top2.SetActive(true);
        timePassing = 0;
        top2.transform.localScale = smallestSize;
        do
        {
            top2.transform.localScale = Vector3.Lerp(smallestSize, top2Size, timePassing / timeToGrow);

            timePassing += Time.deltaTime * timeSpeed;

            yield return null;


        }
        while (timePassing < timeToGrow);

        top3.SetActive(true);
        timePassing = 0;
        top3.transform.localScale = smallestSize;
        do
        {
            top3.transform.localScale = Vector3.Lerp(smallestSize, top3Size, timePassing / timeToGrow);

            timePassing += Time.deltaTime * timeSpeed;

            yield return null;


        }
        while (timePassing < timeToGrow);

        RandomizePlant();

    }

    public void RandomizePlant()
    {
        int rand = Random.Range(1, plantsArray.Length);
        GameObject NewPlant = Instantiate(plantsArray[rand], transform.position + new Vector3(0,+0.5f,0), Quaternion.identity);
        gameObject.SetActive(false);

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
