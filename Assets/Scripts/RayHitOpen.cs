using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RayHitOpen : MonoBehaviour
{
    [SerializeField] Camera cameraP;
    [SerializeField] Transform Aims;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] GameObject Door1;
    [SerializeField] Animation anim;
    [SerializeField] GameObject PortalStat;
    [SerializeField] GameObject MoveToNextScene;
    [SerializeField] GameObject UiToOpen;
    [SerializeField] GameObject Portal;
    [SerializeField] Button Buttonmap1;
    bool map1 = false;
    //Ray ray;

    void Start()
    {
        ///map 1
        Button btn = Buttonmap1.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Time.timeScale = 1;

        UiToOpen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Portal.SetActive(true);
        map1 = true;

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Move" && map1 == true)
        {
            Debug.Log("Move To A New Scene");
            SceneManager.LoadScene("Test");
        }
    }
    void FixedUpdate()
    {
        Ray ray = cameraP.ScreenPointToRay(new Vector2(Screen.width/2,Screen.height/2));
        // Bit shift the index of the layer (6) to get a bit mask
        //layer 6 is Door 1
        int layerMaskdoor1 = 1 << 6;
        //layer 7 is the main Computer to select the Level From
        int layerSelectScene = 1 << 7;
        //layerMask = ~layerMask;
        //register hit
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, 200, layerMaskdoor1))
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, Aims.transform.position);
            lineRenderer.SetPosition(1, raycastHit.transform.position);
            if (Input.GetKeyDown(KeyCode.Mouse0)&& !anim.isPlaying)
            {
                anim.Play("pCube1011.003|Open");
            }
            //Debug.DrawRay(ray, raycastHit.distance, Color.yellow);
            print(raycastHit.transform.name);
            //Debug.Log("hit happened door 1");
        }
        else if (Physics.Raycast(ray, out raycastHit, 200, layerSelectScene))
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, Aims.transform.position);
            lineRenderer.SetPosition(1, raycastHit.transform.position);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Time.timeScale = 0;
                
                UiToOpen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            } 
        }
        else 
        {
            lineRenderer.enabled = false;
            Debug.Log("no hit");
        }
        
    }
}
