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

    public MoveCar mC;

    public Animator[] anim;
    public Button[] uiBtns;
    public GameObject[] secondaryUiBtns; // 0 = ff, 1 = rw

    public Dropdown myDropdown;

    private float playbackSpeed;

    public GameObject curCam;
    public GameObject carCam;
    public GameObject vanCam;

    public Sprite[] uiSprites; //0 = ffInact, 1 = ffAct, 2 = rwInact, 3 = rwAct

    private Vector3 stashPosition;
    private Quaternion rotation;


    // Start is called before the first frame update
    void Start()
    {

        myDropdown.value = 0;
        
        stashPosition = curCam.transform.position;
        rotation = curCam.transform.rotation;
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {

        dropDowncheck();
        HandleDropDown();
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
        isRewind = true;
        LoadArrayNeg(2.9f);
        if (isPause)
        {
            PlayScene();
            wasPaused = true;
        }
    }
    public void StopRewind()
    {
        isRewind = false;
        LoadArrayPos(1f);
        secondaryUiBtns[1].gameObject.GetComponent<Image>().sprite = uiSprites[2];
        if (wasPaused)
        {
            PauseScene();
        }
    }
    public void StopFf()
    {
        isRewind = false;
        LoadArrayPos(1f);
        secondaryUiBtns[0].gameObject.GetComponent<Image>().sprite = uiSprites[0];
        if (wasPaused)
        {
            PauseScene();
        }
    }
    public void FastF()
    {
        isFastF = true;
        LoadArrayPos(2.9f);
        if (isPause)
        {
            PlayScene();
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
        Time.timeScale = 1;
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
        startScene.gameObject.SetActive(false);
        uiBtns[1].gameObject.SetActive(true);
        for (int i = 0; i < uiBtns.Length; i++)
        {
            secondaryUiBtns[i].gameObject.SetActive(true);
            myDropdown.gameObject.SetActive(true);
        }
        PlayScene();
        LoadArrayPos(1f);
        
    }


    public void HandleDropDown()
    {
        //myDropdown.AddOptions(List<>)
        myDropdown.onValueChanged.AddListener(delegate
        {
            selectvalue(myDropdown);
        });
    }
    private void selectvalue(Dropdown dropdown)
    {

    }
    public void dropDowncheck()
    {

        if (myDropdown.value == 0)
        {
            curCam.transform.position = stashPosition;
            curCam.transform.rotation = rotation;
        }
        else if(myDropdown.value == 1)
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
