using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    [SerializeField] private float m_Velocity=1;
    [SerializeField] private Transform[] m_Hazards;
    [SerializeField] private float[] m_HazardsYPos;
    [SerializeField] private Transform m_CameraTransfrom;
    [SerializeField] private float m_DistanceFormCamera;
    [SerializeField] private float m_lastHazardX;
    [SerializeField] private float m_HazardsDistance;
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(m_Velocity,0);
    }
    private void Update()
    {
        for (int i = 0; i < m_Hazards.Length; i++)
        {
            if (m_CameraTransfrom.position.x - m_Hazards[i].position.x > m_DistanceFormCamera) 
            {
                var xPos = m_lastHazardX + m_HazardsDistance;
                m_Hazards[i].transform.localPosition = new Vector3(xPos, RandomYPos());
                m_lastHazardX = xPos;
            }
        }
    }
    private float RandomYPos() 
    {
        return m_HazardsYPos[Random.Range(0, m_HazardsYPos.Length)];
    }
}
