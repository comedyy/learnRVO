using System.Collections;
using System.Collections.Generic;
using RVO;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Simulator.Instance.setTimeStep(Time.deltaTime);
        Simulator.Instance.doStep();
    }
}
