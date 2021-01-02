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

    public List<Vector3> pos2;
    public List<Vector3> pos1;

    public Transform[] carT;

    public Button playBtn;
    public Button pauseBtn;
    public Button startScene;

    public MoveCar mC;

    public Animator[] anim;
    public Button[] uiBtns;
    public GameObject[] secondaryUiBtns;

    public Dropdown myDropdown;


    // Start is called before the first frame update
    void Start()
    {
        LoadArrayNeutral();
    }

    // Update is called once per frame
    void Update()
    {
  

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
        LoadArrayNeg();
    }

    public void StopRewind()
    {
        isRewind = false;
    }

    public void FastF()
    {
        isFastF = true;
        LoadArrayPos();
    }
    public void PauseScene()
    {
        isPause = true;
        pauseBtn.gameObject.SetActive(false);
        playBtn.gameObject.SetActive(true);
        Time.timeScale = 0;

    }
    public void PlayScene()
    {
        isPlay = true;
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
    private void LoadArrayNeg()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetFloat("Direction", -1);
            anim[i].Play("all_anims", -1, float.NegativeInfinity);
        }
    }

    private void LoadArrayPos()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetFloat("Direction", 1);
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
        for(int i = 0; i < uiBtns.Length; i++)
        {
            uiBtns[i].gameObject.SetActive(true);
            secondaryUiBtns[i].gameObject.SetActive(true);
        }
        LoadArrayPos();
    }

    public void HandleDropDown()
    {
        //myDropdown.AddOptions(List<>)
    }
}
