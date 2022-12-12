using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayed2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SingletonBGM.instance.printMessage(2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
