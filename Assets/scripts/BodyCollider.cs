using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider : MonoBehaviour
{
    public Vector2 slot1;
    public Vector2 slot2;
    public Vector2 slot3;
    public Vector2 slot4;
    public Vector2 slot5;

    public Mochila mochila;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Flower"))
        {
            if (other.GetComponent<Flower>().hasBeenTouched == false)
            {
                other.GetComponent<Flower>().hasBeenTouched = true;
                other.GetComponent<Flower>().PrepareToBeCollectedAgain();

                    GetFlower(other.gameObject);

            }

        }

    }

    public void GetFlower(GameObject target)
    {
        int whatItem;
        whatItem = target.GetComponent<Flower>().FlowerType;
        mochila.AddFlowerItem(whatItem, target.transform);

    }


}
