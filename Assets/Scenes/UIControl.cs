using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour {

    private bool m_show = true;
    private GameObject[] m_planes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void togglePlaneMesh () {

        m_show = !m_show;

        m_planes = GameObject.FindGameObjectsWithTag("PlaneGeneratedByARCore");

        Debug.Log("toggled " + m_planes.Length);

        foreach (GameObject plane in m_planes) {

            Debug.Log("toggled plane");

            plane.GetComponent<MeshRenderer>().enabled = m_show;
 
        }
    }
}
