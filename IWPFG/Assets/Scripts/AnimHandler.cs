using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;


//The class which handles time managemnet, such as fastforward, rewing, pause/play
public class AnimHandler : MonoBehaviour
{


    public bool isRewind = false;
    public bool isFastF = false;
    public bool isPause = false;
    public bool isPlay = false;
    public bool isRecording = false;
    private bool wasPaused = false;

    public List<Vector3> pos2;
    public List<Vector3> pos1;

    public Transform[] carT;

    public Button playBtn;
    public Button pauseBtn;
    public GameObject startScene;
    public GameObject slider;

    public MoveCar mC;

    public Animator[] anim;
    public Button[] uiBtns;
    public GameObject[] secondaryUiBtns; // 0 = ff, 1 = rw

    public Dropdown myDropdown;

    private float playbackSpeed;

    public GameObject origCam;
    public GameObject curCam;
    public GameObject carCam;
    public GameObject vanCam;

    public Sprite[] uiSprites; //0 = ffInact, 1 = ffAct, 2 = rwInact, 3 = rwAct

    private GameObject stashPosition;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {

        myDropdown.value = 0;
        
        //stashPosition = origCam.transform.position;
       // rotation = origCam.transform.rotation;
        Time.timeScale = 0;
         //LoadArrayPos(1f);

    }

    // Update is called once per frame
    void Update()
    {

       // dropDowncheck();
        HandleDropDown();
        if (myDropdown.value == 1)
        {

            curCam.transform.position = carCam.transform.position;
            curCam.transform.rotation = carCam.transform.rotation;

        }
        else if (myDropdown.value == 2)
        {
            curCam.transform.position = vanCam.transform.position;
            curCam.transform.rotation = vanCam.transform.rotation;

        }
    }
    private void LateUpdate()
    {

    }

   

    public void Record()
    {
        isRecording = true;
        pos2.Insert(0, carT[0].position);
        pos1.Insert(0, carT[1].position);

    }

    public void Rewind()
    {
        secondaryUiBtns[1].gameObject.GetComponent<Image>().sprite = uiSprites[3];
        LoadArrayNeg(3.5f);
        if (isPause)
        {
            Time.timeScale = .9f;
            wasPaused = true;
        }
      
    }
    public void StopRewind()
    {
        secondaryUiBtns[1].gameObject.GetComponent<Image>().sprite = uiSprites[2];
        LoadArrayPos(1f);
        if (wasPaused && !isPlay)
        {
            PauseScene();
        }
        else
        {
            PlayScene();
        }
    }
    public void StopFf()
    {
        secondaryUiBtns[0].gameObject.GetComponent<Image>().sprite = uiSprites[0];
        LoadArrayPos(1f);
        if (wasPaused && !isPlay)
        {
            PauseScene();
        }
        else
        {
            PlayScene();
        }
    }
    public void FastF()
    {
        secondaryUiBtns[0].gameObject.GetComponent<Image>().sprite = uiSprites[1];
        LoadArrayPos(3.5f);
        if (isPause)
        {
            Time.timeScale = .9f;
            wasPaused = true;
        }
     
    }
    public void PauseScene()
    {
        isPause = true;
        isPlay = false;
        pauseBtn.gameObject.SetActive(false);
        playBtn.gameObject.SetActive(true);
        Time.timeScale = 0;

    }
    public void PlayScene()
    {
        isPlay = true;
        isPause = false;
        pauseBtn.gameObject.SetActive(true);
        playBtn.gameObject.SetActive(false);
        Time.timeScale = .9f;
    }

    public void PointerDown()
    {
        Rewind();
        Debug.Log("pointer down");
    }
    public void PointerUp()
    {
        PauseScene();
        Debug.Log("pointer up");
    }
    private void LoadArrayNeg(float s)
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetFloat("Direction", -1 * s);
            anim[i].Play("all_anims", -1, float.NegativeInfinity);
        }
    }

    private void LoadArrayPos(float s)
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetFloat("Direction", 1 * s);
            anim[i].Play("all_anims", 1, float.PositiveInfinity);
        }
    }

    private void LoadArrayNeutral()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetFloat("Direction", 0);
            //anim[i].Play("all_anims", 0, 0);
        }
    }

    public void HandleUi()
    {
        myDropdown.gameObject.SetActive(true);
        startScene.gameObject.SetActive(false);
        uiBtns[1].gameObject.SetActive(true);
        slider.gameObject.SetActive(true);
        for (int i = 0; i < uiBtns.Length; i++)
        {
            secondaryUiBtns[i].gameObject.SetActive(true);
            myDropdown.gameObject.SetActive(true);
        }
        Time.timeScale = .9f;
        LoadArrayPos(1f);  
    }
    public void HideUi()
    {
        myDropdown.gameObject.SetActive(false);
        startScene.gameObject.SetActive(false);
        slider.gameObject.SetActive(false);
        for (int i = 0; i < uiBtns.Length; i++)
        {
            secondaryUiBtns[i].gameObject.SetActive(false);
            uiBtns[1].gameObject.SetActive(false);
        }
    }


    public void HandleDropDown()
    {
        //myDropdown.AddOptions(List<>)
        myDropdown.onValueChanged.AddListener(delegate
        {
            selectvalue(myDropdown);
            //dropDowncheck();
        });
    }
    private void selectvalue(Dropdown dropdown)
    {

    }
    public void dropDowncheck()
    {

        if (myDropdown.value == 0)
        {
            curCam.transform.position = origCam.transform.position;
           // curCam.transform.position = new Vector3(-96f, 420f, -47f);
            curCam.transform.rotation = origCam.transform.rotation;
     
        }
        if(myDropdown.value == 1)
        {
            
            curCam.transform.position = carCam.transform.position;
            curCam.transform.rotation = carCam.transform.rotation;
        
        }
        else if(myDropdown.value == 2)
        {
            curCam.transform.position = vanCam.transform.position;
            curCam.transform.rotation = vanCam.transform.rotation;
        
        }
    }
}
