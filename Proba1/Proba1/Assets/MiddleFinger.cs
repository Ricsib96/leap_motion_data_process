using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MiddleFinger : MonoBehaviour {

    List<ReadFile.Point> mpArray = new List<ReadFile.Point>();
    List<ReadFile.Point> mnArray = new List<ReadFile.Point>();
    List<ReadFile.Point> ppnArray = new List<ReadFile.Point>();
    List<ReadFile.Point> ipnArray = new List<ReadFile.Point>();
    List<ReadFile.Point> dpnArray = new List<ReadFile.Point>();
    int i = 0;
    float c = 0;
    float nextFrame = 1;
    GameObject mpCurrent, mnCurrent, ppnCurrent, ipnCurrent, dpnCurrent;
    Vector3 pos;
    LineRenderer line;

    // Use this for initialization
    void Start () {
        mpCurrent = GameObject.Find("mp_mf");
        mnCurrent = GameObject.Find("mn_mf");
        ppnCurrent = GameObject.Find("ppn_mf");
        ipnCurrent = GameObject.Find("ipn_mf");
        dpnCurrent = GameObject.Find("dpn_mf");
        line = GameObject.Find("MiddleFinger").GetComponent<LineRenderer>();
        
    }
	
	// Update is called once per frame
	void Update () {

        pos = new Vector3((float)mpArray.ElementAt(i).getCoordinate().X(), (float)mpArray.ElementAt(i).getCoordinate().Y(), (float)mpArray.ElementAt(i).getCoordinate().Z());
        mpCurrent.transform.position = pos;
        pos = new Vector3((float)mnArray.ElementAt(i).getCoordinate().X(), (float)mnArray.ElementAt(i).getCoordinate().Y(), (float)mnArray.ElementAt(i).getCoordinate().Z());
        mnCurrent.transform.position = pos;
        pos = new Vector3((float)ppnArray.ElementAt(i).getCoordinate().X(), (float)ppnArray.ElementAt(i).getCoordinate().Y(), (float)ppnArray.ElementAt(i).getCoordinate().Z());
        ppnCurrent.transform.position = pos;
        pos = new Vector3((float)ipnArray.ElementAt(i).getCoordinate().X(), (float)ipnArray.ElementAt(i).getCoordinate().Y(), (float)ipnArray.ElementAt(i).getCoordinate().Z());
        ipnCurrent.transform.position = pos;
        pos = new Vector3((float)dpnArray.ElementAt(i).getCoordinate().X(), (float)dpnArray.ElementAt(i).getCoordinate().Y(), (float)dpnArray.ElementAt(i).getCoordinate().Z());
        dpnCurrent.transform.position = pos;

        line.material.color = Color.green;
      //  line.SetPosition(0, mpCurrent.transform.position);
        line.SetPosition(0, mnCurrent.transform.position);
        line.SetPosition(1, ppnCurrent.transform.position);
        line.SetPosition(2, ipnCurrent.transform.position);
        line.SetPosition(3, dpnCurrent.transform.position);

        if (c % nextFrame == 0)
        {
            if (i < mpArray.Count - 1)
                i++;
        }
        c++;
    }
    public void Set(List<ReadFile.Point> mp, List<ReadFile.Point> mn, List<ReadFile.Point> ppn, List<ReadFile.Point> ipn, List<ReadFile.Point> dpn)
    {
        this.mpArray = mp;
        this.mnArray = mn;
        this.ppnArray = ppn;
        this.ipnArray = ipn;
        this.dpnArray = dpn;
    }
    public void setNextFrame(float nf)
    {
        nextFrame = nf;
    }
}
