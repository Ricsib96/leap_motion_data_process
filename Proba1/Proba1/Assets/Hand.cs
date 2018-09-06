using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour {

    List<List<ReadFile.Point>> hands;
    ReadFile a;
    public float nextFrame;
    public bool isPaused;
    public bool isStopped;

    LittleFinger lfScript;
    MiddleFinger mfScript;
    RingFinger rfScript;
    IndexFinger ifScript;
    Thumb tScript;
    Palm pScript;


    // Use this for initialization
    void Start () {

        PipeClient client = new PipeClient();
        client.StartClient();

        a = new ReadFile();
        a.readFile(client.File_name);
        //a.readFile(@"E:\TestForUnity.csv");

        isPaused = false;
        isStopped = false;

        lfScript = this.GetComponentInChildren<LittleFinger>();
        lfScript.Set(a.getPoints("mp_lf"), a.getPoints("mn_lf"), a.getPoints("ppn_lf"), a.getPoints("ipn_lf"), a.getPoints("dpn_lf"));

        mfScript = this.GetComponentInChildren<MiddleFinger>();
        mfScript.Set(a.getPoints("mp_mf"), a.getPoints("mn_mf"), a.getPoints("ppn_mf"), a.getPoints("ipn_mf"), a.getPoints("dpn_mf"));

        rfScript = this.GetComponentInChildren<RingFinger>();
        rfScript.Set(a.getPoints("mp_rf"), a.getPoints("mn_rf"), a.getPoints("ppn_rf"), a.getPoints("ipn_rf"), a.getPoints("dpn_rf"));

        ifScript = this.GetComponentInChildren<IndexFinger>();
        ifScript.Set(a.getPoints("mp_if"), a.getPoints("mn_if"), a.getPoints("ppn_if"), a.getPoints("ipn_if"), a.getPoints("dpn_if"));

        tScript = this.GetComponentInChildren<Thumb>();
        tScript.Set(a.getPoints("mn_t"), a.getPoints("ppn_t"), a.getPoints("ipn_t"), a.getPoints("dpn_t"));

        pScript = this.GetComponentInChildren<Palm>();
        pScript.Set(a.getPoints("mp_rf"), a.getPoints("mn_rf"), a.getPoints("mp_mf"), a.getPoints("mn_mf"));

        //lfScript.client = client;

        tScript.setNextFrame(nextFrame);
        lfScript.setNextFrame(nextFrame);
        mfScript.setNextFrame(nextFrame);
        rfScript.setNextFrame(nextFrame);
        ifScript.setNextFrame(nextFrame);
        pScript.setNextFrame(nextFrame);


    }

    // Update is called once per frame
    void Update () {
		
	}

    public float getCounter()
    {
        return nextFrame;
    }
    public void PauseOrContinue()
    {
        if (isPaused)
        {
            GameObject.Find("btn_pause").GetComponentInChildren<Text>().text = "Pause";
            isPaused = false;
            Continue();
        }
        else
        {
            GameObject.Find("btn_pause").GetComponentInChildren<Text>().text = "Continue";
            isPaused = true;
            Pause();
        }
        
    }
    public void StopOrStart()
    {
        var pause = Resources.FindObjectsOfTypeAll<Button>()[2];
        if (isStopped)
        {
            pause.interactable = true;
            GameObject.Find("btn_stop").GetComponentInChildren<Text>().text = "Stop";
            isStopped = false;
            Continue();
        }
        else
        {
            pause.interactable = false;
            GameObject.Find("btn_stop").GetComponentInChildren<Text>().text = "Start";
            isStopped = true;
            Stop();
        }
    }
    public void Pause()
    {

        lfScript.Pause();
        mfScript.Pause();
        rfScript.Pause();
        ifScript.Pause();
        tScript.Pause();
        pScript.Pause();
    }
    public void Continue()
    {

        lfScript.Continue();
        mfScript.Continue();
        rfScript.Continue();
        ifScript.Continue();
        tScript.Continue();
        pScript.Continue();
    }
    public void Stop()
    {
        lfScript.Stop();
        mfScript.Stop();
        rfScript.Stop();
        ifScript.Stop();
        tScript.Stop();
        pScript.Stop();
        

    }
    public void Quit()
    {
        Application.Quit();
    }


}
