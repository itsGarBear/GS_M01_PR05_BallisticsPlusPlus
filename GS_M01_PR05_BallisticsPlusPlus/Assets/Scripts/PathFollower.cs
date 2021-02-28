using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : Kinematic
{
    FollowPath myMoveType;
    LookWhereGoing myRotateType;
    Arrive myArriveType;

    public Kinematic[] myWayPts;

    public bool didHit = false;

    public Zone z;

    //public bool needArrive = false;

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new FollowPath();
        myMoveType.character = this;
        myMoveType.wayPts = myWayPts;

        myArriveType = new Arrive();
        myArriveType.character = this;
        myArriveType.target = myWayPts[myMoveType.wayPts.Length-1].gameObject;

        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        myRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        //if(myMoveType.currWayPtNdx == 3)
        //{
        //    needArrive = true;
        //}

        if(didHit)
        {
            steeringUpdate = new SteeringOutput();
            //steeringUpdate.linear = needArrive ? myMoveType.getSteering().linear : myArriveType.getSteering().linear;
            steeringUpdate.linear = myMoveType.getSteering().linear;
            steeringUpdate.angular = myRotateType.getSteering().angular;
        }
        
        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Chaser")
        {
            z.PlayerOut();
        }
    }

}
