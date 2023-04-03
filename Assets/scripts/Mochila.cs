using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mochila : MonoBehaviour
{

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    public GameObject prefab7;
    public GameObject prefab8;
    public GameObject prefab9;
    public GameObject prefab10;

    public GameObject PrefabToUse;

    public GameObject slot1Obj;
    public GameObject slot2Obj;
    public GameObject slot3Obj;
    public GameObject slot4Obj;
    public GameObject slot5Obj;

    public int currentAvaliableSlot =1;

    public Camera cam;
    public GameObject canvasObj;

    public Vector3 testVector3;

    public float speed;

    public Color usualColor;
    public Image image;

    public bool isFlickering = false;

    // Start is called before the first frame update
    void Start()
    {
        usualColor = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFlowerItem(int itemNumber, Transform whereGot)
    {
        
        if(itemNumber ==1) // arranje what prefab to use
        {
            PrefabToUse = prefab1;
        }
        if (itemNumber == 2)
        {
            PrefabToUse = prefab2;
        }
        if (itemNumber == 3)
        {
            PrefabToUse = prefab3;
        }
        if (itemNumber == 4)
        {
            PrefabToUse = prefab4;
        }
        if (itemNumber == 5)
        {
            PrefabToUse = prefab5;
        }
        if (itemNumber == 6)
        {
            PrefabToUse = prefab6;
        }
        if (itemNumber == 7)
        {
            PrefabToUse = prefab7;
        }
        if (itemNumber == 8)
        {
            PrefabToUse = prefab8;
        }
        if (itemNumber == 9)
        {
            PrefabToUse = prefab9;
        }
        if (itemNumber == 10)
        {
            PrefabToUse = prefab10;
        }


        //what slot to use?
        if (currentAvaliableSlot == 6)
        {
            // make rejection sound
            // make bag red
            Debug.Log("bater, bateu");
            if(!isFlickering)
            {
                StartCoroutine(BagFlickerRed());
            }
        }
        if (currentAvaliableSlot == 5)
        {
            GameObject item5 = Instantiate(PrefabToUse, whereGot.position, Quaternion.identity, slot5Obj.transform);
            StartCoroutine(MoveToInventory(item5.transform, slot5Obj.transform.InverseTransformPoint(item5.transform.position), Vector3.zero));

            currentAvaliableSlot = 6;  //******************* 6 is NOT MORE SLOTS!
            Destroy(whereGot.gameObject);


        }
        if (currentAvaliableSlot == 4)
        {
            GameObject item4 = Instantiate(PrefabToUse, whereGot.position, Quaternion.identity, slot4Obj.transform);
            StartCoroutine(MoveToInventory(item4.transform, slot4Obj.transform.InverseTransformPoint(item4.transform.position), Vector3.zero));

            currentAvaliableSlot = 5;
            Destroy(whereGot.gameObject);



        }
        if (currentAvaliableSlot == 3)
        {
            GameObject item3 = Instantiate(PrefabToUse, whereGot.position, Quaternion.identity, slot3Obj.transform);
            StartCoroutine(MoveToInventory(item3.transform, slot3Obj.transform.InverseTransformPoint(item3.transform.position), Vector3.zero));

            currentAvaliableSlot = 4;
            Destroy(whereGot.gameObject);



        }
        if (currentAvaliableSlot == 2)
        {
            GameObject item2 = Instantiate(PrefabToUse, whereGot.position, Quaternion.identity, slot2Obj.transform);
            StartCoroutine(MoveToInventory(item2.transform, slot2Obj.transform.InverseTransformPoint(item2.transform.position), Vector3.zero));

            currentAvaliableSlot = 3;
            Destroy(whereGot.gameObject);



        }
        if (currentAvaliableSlot == 1)
        {
            GameObject item1 = Instantiate(PrefabToUse, whereGot.position, Quaternion.identity, slot1Obj.transform);
            StartCoroutine(MoveToInventory(item1.transform, slot1Obj.transform.InverseTransformPoint(item1.transform.position), Vector3.zero));

            currentAvaliableSlot = 2;
            Destroy(whereGot.gameObject);


        }

    }

    IEnumerator MoveToInventory(Transform objTransform, Vector3 startPos, Vector3 endPos)
    {
        float time = 0;
        Debug.Log("obj position = " + objTransform.position);
        while(time <1)
        {
            time += speed * Time.deltaTime;
            objTransform.localPosition = Vector3.Lerp(startPos, endPos, time);
            yield return new WaitForEndOfFrame();
        }
        

        yield return null;
    }

    IEnumerator BagFlickerRed()
    {
        Debug.Log("started flicker");
        float time = 0;
        isFlickering = true;

        do
        {
            time += Time.deltaTime;
            yield return null;
        }
        while (time < 0.2f);

        image.color = Color.red;

        time = 0;

        do
        {
            time += Time.deltaTime;
            yield return null;
        }
        while (time < 0.2f);

        image.color = usualColor;

        time = 0;

        do
        {
            time += Time.deltaTime;
            yield return null;
        }
        while (time < 0.2f);

        image.color = Color.red;

        time = 0;

        do
        {
            time += Time.deltaTime;
            yield return null;
        }
        while (time < 0.2f);

        image.color = usualColor;
        time = 0;

        do
        {
            time += Time.deltaTime;
            yield return null;
        }
        while (time < 0.2f);

        image.color = Color.red;

        time = 0;

        do
        {
            time += Time.deltaTime;
            yield return null;
        }
        while (time < 0.2f);

        image.color = usualColor;

        isFlickering = false;

        yield return null;


    }

}
