using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float batasAtas = 3.52f;
    public float batasBawah = -3.54f;
    public float kecepatan = 7;

    public string axis = "Vertical1";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float gerak = Input.GetAxis(axis) * kecepatan * Time.deltaTime;
        float nextPos = transform.position.y + gerak;
        if(nextPos > batasAtas)
        {
            gerak = 0;
        }
        else if (nextPos < batasBawah)
        {
            gerak = 0;
        }
        transform.Translate(gerak, 0, 0);
    }
}
