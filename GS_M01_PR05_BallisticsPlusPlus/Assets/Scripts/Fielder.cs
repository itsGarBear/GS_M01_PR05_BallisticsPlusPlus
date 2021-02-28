using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fielder : Kinematic
{
    Arrive myMoveType;
    LookWhereGoing myRotateType;

    PathFollower batter;
    public Arriver chaserPrefab;
    // Start is called before the first frame update
    void Start()
    {
        batter = FindObjectOfType<PathFollower>();

        myMoveType = new Arrive();
        myMoveType.character = this;
        myMoveType.target = myTarget;

        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        myRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (batter.didHit)
        {
            steeringUpdate = new SteeringOutput();
            steeringUpdate.linear = myMoveType.getSteering().linear;
            steeringUpdate.angular = myRotateType.getSteering().angular;
        }
        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Instantiate(chaserPrefab, this.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        
    }
}
