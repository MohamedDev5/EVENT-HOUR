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
    //Move To next Scene
    [SerializeField] GameObject MoveToNextScene;

    //Ui
    [SerializeField] GameObject UiToOpen, UiLoadingMap1, UiLoadingMap2, UiLoadingMap3;
    [SerializeField] Slider proMap1, proMap2, proMap3;
    [SerializeField] GameObject UiPause;
    [SerializeField] Button resuemBtn, mainMenuBtn, exitBtn;
    //The Time Portal
    [SerializeField] GameObject Portal;
    //Maps
    [SerializeField] Button ButMap1;
    [SerializeField] Button ButMap2;
    [SerializeField] Button ButMap3;

    bool map1 = false;
    bool map2 = false;
    bool map3 = false;


    bool isAnimDone = false;
    //Ray ray;

    void Start()
    {
        ///map 1
        Button btn1 = ButMap1.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClickMap1);
        //map 2
        Button btn2 = ButMap2.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClickMap2);
        //map3
        Button btn3 = ButMap3.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClickMap3);
    }

    void TaskOnClickMap3()
    {
        Time.timeScale = 1;

        UiToOpen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (Portal.activeInHierarchy == false)
        {
            Portal.SetActive(true);
        }
        map1 = false;
        map2 = false;
        map3 = true;
    }

    void TaskOnClickMap2()
    {
        Time.timeScale = 1;

        UiToOpen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (Portal.activeInHierarchy == false)
        {
            Portal.SetActive(true);
        }
        map1 = false;
        map2 = true;
        map3 = false;
    }

    void TaskOnClickMap1()
    {
        Time.timeScale = 1;

        UiToOpen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (Portal.activeInHierarchy == false)
        {
            Portal.SetActive(true);
        }
        map1 = true;
        map2 = false;
        map3 = false;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Move" && map1 == true)
        {
            //Debug.Log("Move To A New Scene");
            if (UiLoadingMap1.activeInHierarchy == false)
            {
                UiLoadingMap1.SetActive(true);
            }
            StartCoroutine(LoadMap1());
            
        }
        else if(collision.gameObject.tag == "Move" && map2 == true)
        {
            if (UiLoadingMap2.activeInHierarchy == false)
            {
                UiLoadingMap2.SetActive(true);
            }
            
            StartCoroutine(LoadMap2()); 
        }
        else if (collision.gameObject.tag == "Move" && map3 == true)
        {
            if (UiLoadingMap3.activeInHierarchy == false)
            {
                UiLoadingMap3.SetActive(true);
            }
            StartCoroutine(LoadMap3());
        }
    }

    IEnumerator LoadMap1()
    {
        AsyncOperation op1 = SceneManager.LoadSceneAsync("MAP1");
        while (!op1.isDone)
        {
            float prograss1 = Mathf.Clamp01(op1.progress / .9f);
            proMap1.value = prograss1;

            Debug.Log(op1.progress);
            yield return null;
        }
    }
    IEnumerator LoadMap2()
    {
        AsyncOperation op2 = SceneManager.LoadSceneAsync("MAP2");
        while (!op2.isDone)
        {
            float prograss2 = Mathf.Clamp01(op2.progress / .9f);
            proMap2.value = prograss2;

            Debug.Log(op2.progress);
            yield return null;
        }
    }
    IEnumerator LoadMap3()
    {
        AsyncOperation op3 = SceneManager.LoadSceneAsync("MAP3");
        while (!op3.isDone)
        {
            float prograss3 = Mathf.Clamp01(op3.progress / .9f);
            proMap3.value = prograss3;

            Debug.Log(op3.progress);
            yield return null;
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

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 2, layerMaskdoor1))
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, Aims.transform.position);
            lineRenderer.SetPosition(1, raycastHit.transform.position);
            if (Input.GetKeyDown(KeyCode.Mouse0) && isAnimDone == false)
            {
                anim.Play("Default_Open");
                isAnimDone = true;
            }
            //Debug.DrawRay(ray, raycastHit.distance, Color.yellow);
            //print(raycastHit.transform.name);
            //Debug.Log("hit happened door 1");
        }
        else if (Physics.Raycast(ray, out raycastHit, 2, layerSelectScene))
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
            //Debug.Log("no hit");
        }
        //pause Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UiPause.SetActive(true);
            Time.timeScale = 0;
        }

    }
    public void ResumGame()
    {
        UiPause.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void LoadMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
