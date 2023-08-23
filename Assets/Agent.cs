using System.Collections;
using System.Collections.Generic;
using RVO;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public UnityEngine.Vector2 destPos;
    public float maxSpeed;
    int idRvo;

    // Start is called before the first frame update
    void Start()
    {
        idRvo = Simulator.Instance.addAgent(new RVO.Vector2(transform.position.x, transform.position.y), 3, 2, 1, 1, 1, maxSpeed, new RVO.Vector2(0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        var dir = destPos - new UnityEngine.Vector2(transform.position.x, transform.position.z);
        dir = dir.normalized * maxSpeed;

        Simulator.Instance.setAgentPrefVelocity(idRvo, new RVO.Vector2(dir.x, dir.y));
        var pos = Simulator.Instance.getAgentPosition(idRvo);
        transform.position = new Vector3(pos.x(), 0, pos.y());
    }
}
