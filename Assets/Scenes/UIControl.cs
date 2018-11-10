using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour {

    private bool m_show = true;
    private GameObject[] m_planes;

    public GameObject m_MeshButton;
    public GameObject m_CameraButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void togglePlaneMesh () {

        m_show = !m_show;

        Debug.Log("toggled plane " + m_planes.Length);

        foreach (GameObject plane in m_planes) {
            if (plane != null) {

                plane.GetComponent<MeshRenderer>().enabled = m_show;

            }
        }
    }

    public void updatePlaneMeshVisibility(MeshRenderer newRenderer) {

        m_planes = GameObject.FindGameObjectsWithTag("PlaneGeneratedByARCore");

        newRenderer.enabled = m_show;

        Debug.Log("plane update visibility");
    }

    public void CaptureScreenshot() {
        m_MeshButton.SetActive(false);
        m_CameraButton.SetActive(false);
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string myFileName = "ARPoop" + timeStamp + ".png";

        StartCoroutine("CaptureScreenshotCoroutine", myFileName);
    }

    private IEnumerator CaptureScreenshotCoroutine(string filename) {
        yield return new WaitForEndOfFrame();
        ScreenShoter.CaptureScreenShot(filename);
        m_MeshButton.SetActive(true);
        m_CameraButton.SetActive(true);
    }

    //private IEnumerator CaptureScreenshotCoroutine() {

    //    Debug.Log("Screenshot called");

    //    string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
    //    string myFileName = "ARPOOP" + timeStamp + ".png";
    //    string pathToSave = myFileName;

    //    ScreenCapture.CaptureScreenshot(pathToSave);
    //    yield return new WaitForEndOfFrame();
    //    m_MeshButton.SetActive(true);
    //    m_CameraButton.SetActive(true);

    //}

}
