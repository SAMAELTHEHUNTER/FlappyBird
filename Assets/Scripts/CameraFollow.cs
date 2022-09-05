using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject m_Player;
    [SerializeField] private Camera m_MainCamera;
    [SerializeField] private float m_Offset;

    void Update()
    {
        Vector3 cameraPos = m_MainCamera.transform.position;
        Vector3 playerPos = m_Player.transform.position;
        m_MainCamera.transform.position = new Vector3(playerPos.x+m_Offset, cameraPos.y,cameraPos.z);
    }
}
