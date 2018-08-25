using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Palm : MonoBehaviour {
    GameObject p_center;
    List<ReadFile.Point> rf_mpArray = new List<ReadFile.Point>();
    List<ReadFile.Point> rf_mnArray = new List<ReadFile.Point>();
    List<ReadFile.Point> mf_mpArray = new List<ReadFile.Point>();
    List<ReadFile.Point> mf_mnArray = new List<ReadFile.Point>();
    int i = 0;
    float c = 0;
    float nextFrame = 1;
    Vector3 pos1,center1,center2,pos2;


    // Use this for initialization
    void Start () {
        p_center = GameObject.Find("p_center");
	}
	
	// Update is called once per frame
	void Update () {

        pos1 = new Vector3((float)rf_mpArray.ElementAt(i).getCoordinate().X(), (float)rf_mpArray.ElementAt(i).getCoordinate().Y(), (float)rf_mpArray.ElementAt(i).getCoordinate().Z());
        pos2 = new Vector3((float)rf_mnArray.ElementAt(i).getCoordinate().X(), (float)rf_mnArray.ElementAt(i).getCoordinate().Y(), (float)rf_mnArray.ElementAt(i).getCoordinate().Z());
        center1 = Vector3.Lerp(pos1, pos2, 0.5f);

        pos1 = new Vector3((float)mf_mpArray.ElementAt(i).getCoordinate().X(), (float)mf_mpArray.ElementAt(i).getCoordinate().Y(), (float)mf_mpArray.ElementAt(i).getCoordinate().Z());
        pos2 = new Vector3((float)mf_mnArray.ElementAt(i).getCoordinate().X(), (float)mf_mnArray.ElementAt(i).getCoordinate().Y(), (float)mf_mnArray.ElementAt(i).getCoordinate().Z());
        center2 = Vector3.Lerp(pos1, pos2, 0.5f);

        p_center.transform.position = Vector3.Lerp(center1, center2, 0.5f);

        if (c % nextFrame == 0)
        {
            if (i < rf_mpArray.Count - 1)
                i++;
        }
        c++;
    }
    public void Set(List<ReadFile.Point> rf_mp, List<ReadFile.Point> rf_mn, List<ReadFile.Point> mf_mp, List<ReadFile.Point> mf_mn)
    {
        this.rf_mpArray = rf_mp;
        this.rf_mnArray = rf_mn;
        this.mf_mpArray = mf_mp;
        this.mf_mnArray = mf_mn;
    }
    public void setNextFrame(float nf)
    {
        nextFrame = nf;
    }
}
