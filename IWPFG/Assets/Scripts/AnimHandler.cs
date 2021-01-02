using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


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

    public MoveCar mC;


    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
   
      
    }
    private void LateUpdate()
    {
        if (isRewind)
        {
            pointerDown();
        }
        else 
        {
            pointerUp();
           // mC.MoveObject();

        }
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
        if (pos2.Count > 0 && pos1.Count > 0){
            carT[0].position = pos2[0];
            carT[1].position = pos1[1];
            pos2.RemoveAt(0);
            pos1.RemoveAt(0);
        }
        else
        {
            StopRewind(); 
        }
        
    }
    public void StopRecord()
    {
        isRecording = false;
    }

    public void StopRewind()
    {
        isRewind = false;
    }

    public void FastF()
    {
        isFastF = true;
    }
    public void PauseScene()
    {
        isPause = true;
        Time.timeScale = 0;
        pauseBtn.gameObject.SetActive(false);
        playBtn.gameObject.SetActive(true);
        StopRecord();   
    }
    public void PlayScene()
    {
        isPlay = true;
        Time.timeScale = 1;
        pauseBtn.gameObject.SetActive(true);
        playBtn.gameObject.SetActive(false);
    }

    public void pointerDown()
    {
        Rewind();
        StopRecord();
        Debug.Log("pointer down");
    }
    public void pointerUp()
    {
        Record();
        StopRewind();
        Debug.Log("pointer up");
    }

}
