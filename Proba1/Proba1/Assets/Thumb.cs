﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Thumb : MonoBehaviour {

    List<ReadFile.Point> mnArray = new List<ReadFile.Point>();
    List<ReadFile.Point> ppnArray = new List<ReadFile.Point>();
    List<ReadFile.Point> ipnArray = new List<ReadFile.Point>();
    List<ReadFile.Point> dpnArray = new List<ReadFile.Point>();
    float c = 0;
    float nextFrame = 1;
    int i = 0;
    GameObject mnCurrent, ppnCurrent, ipnCurrent, dpnCurrent;
    Vector3 pos;
    LineRenderer line;
    bool isPaused;


    // Use this for initialization
    void Start()
    {

        mnCurrent = GameObject.Find("mn_t");
        ppnCurrent = GameObject.Find("ppn_t");
        ipnCurrent = GameObject.Find("ipn_t");
        dpnCurrent = GameObject.Find("dpn_t");
        line = GameObject.Find("Thumb").GetComponent<LineRenderer>();
        isPaused = false;

    }

    // Update is called once per frame
    void Update()
    {

        if(!isPaused)
        {
            pos = new Vector3((float)mnArray.ElementAt(i).getCoordinate().X(), (float)mnArray.ElementAt(i).getCoordinate().Y(), (float)mnArray.ElementAt(i).getCoordinate().Z());
            mnCurrent.transform.position = pos;
            pos = new Vector3((float)ppnArray.ElementAt(i).getCoordinate().X(), (float)ppnArray.ElementAt(i).getCoordinate().Y(), (float)ppnArray.ElementAt(i).getCoordinate().Z());
            ppnCurrent.transform.position = pos;
            pos = new Vector3((float)ipnArray.ElementAt(i).getCoordinate().X(), (float)ipnArray.ElementAt(i).getCoordinate().Y(), (float)ipnArray.ElementAt(i).getCoordinate().Z());
            ipnCurrent.transform.position = pos;
            pos = new Vector3((float)dpnArray.ElementAt(i).getCoordinate().X(), (float)dpnArray.ElementAt(i).getCoordinate().Y(), (float)dpnArray.ElementAt(i).getCoordinate().Z());
            dpnCurrent.transform.position = pos;

            line.material.color = Color.yellow;
            line.SetPosition(0, mnCurrent.transform.position);
            line.SetPosition(1, ppnCurrent.transform.position);
            line.SetPosition(2, ipnCurrent.transform.position);
            line.SetPosition(3, dpnCurrent.transform.position);

            if (c % nextFrame == 0)
            {

                if (i < mnArray.Count - 1)
                    i++;
            }
            c++;
        }
        
        


    }

    public void Set(List<ReadFile.Point> mn, List<ReadFile.Point> ppn, List<ReadFile.Point> ipn, List<ReadFile.Point> dpn)
    {

        this.mnArray = mn;
        this.ppnArray = ppn;
        this.ipnArray = ipn;
        this.dpnArray = dpn;
    }

    public void setNextFrame(float nf)
    {
        nextFrame = nf;
    }
    public void Pause()
    {
        isPaused = true;
    }
    public void Continue()
    {
        isPaused = false;
    }
    public void Stop()
    {
        Pause();
        i = 0;
        c = 0;
    }
}
