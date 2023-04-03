using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFundoMenu : MonoBehaviour
{
    public Vector3 end = new Vector3(0, 0, 0);
    public Vector3 start = new Vector3(2000, 540, 0);
    Vector3 startpos;
    public float speed = 1;

    RectTransform rectTrans;

    // Start is called before the first frame update
    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        startpos = rectTrans.position;
        Debug.Log(startpos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rectTrans.position.x > end.x)
        {
            rectTrans.Translate(Vector3.left * Time.deltaTime * speed);

        }
        else
        {
            rectTrans.position = start;
        }
    }
}
