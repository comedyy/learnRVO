using System.Collections;
using System.Collections.Generic;
using RVO;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public UnityEngine.Vector2 destPos;
    public float maxSpeed;
    public float radius;
    int idRvo;
    public Color color = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        idRvo = Simulator.Instance.addAgent(new RVO.Vector2(transform.position.x, transform.position.y), 3, 5, 1, 1, radius, maxSpeed, new RVO.Vector2(0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        // Simulator.Instance.setAgentMaxSpeed(idRvo, maxSpeed);

        var dir = destPos - new UnityEngine.Vector2(transform.position.x, transform.position.y);
        dir = dir.normalized * maxSpeed;

        Simulator.Instance.setAgentPrefVelocity(idRvo, new RVO.Vector2(dir.x, dir.y));
        var pos = Simulator.Instance.getAgentPosition(idRvo);
        transform.position = new Vector3(pos.x(), pos.y(), 0);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        var velocity = Simulator.Instance.getAgentVelocity(idRvo);
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(velocity.x(), velocity.y()));

        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, radius);
        var velocityPref = Simulator.Instance.getAgentPrefVelocity(idRvo);
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(velocityPref.x(), velocityPref.y()));

        var lines = Simulator.Instance.getAgentOrcaLines(idRvo);
        foreach(var x in lines)
        {
            Gizmos.DrawLine(ToVec2(x.point) - ToVec2(x.direction) * 1, ToVec2(x.point) + ToVec2(x.direction) * 1);
        }
    }

    static UnityEngine.Vector2 ToVec2(RVO.Vector2 vec)
    {
        return new UnityEngine.Vector2(vec.x(), vec.y());
    }
}
