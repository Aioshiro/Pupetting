using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodBoodPoses : MonoBehaviour
{
    public enum Pose
    {
        Stand = 0,
        Sit = 1,
        Rise = 2,
        GiveRightPaw = 3,
        Count = 4
    }
    public Pose pose = Pose.Stand;
    private Pose currentPose = Pose.Stand;
    private PosePositions[] poses;

    private float t;
    public float transitionDelta = 0.05f;

    private struct PosePositions
    {
        public Vector3 BellyFront;
        public Vector3 BellyRear;
        public Vector3 FrontRightLeg;
        public Vector3 FrontRightAnkle;
        public Vector3 FrontRightPaw;
        public Vector3 FrontLeftLeg;
        public Vector3 FrontLeftAnkle;
        public Vector3 FrontLeftPaw;
        public Vector3 RearRightLeg;
        public Vector3 RearRightAnkle;
        public Vector3 RearRightPaw;
        public Vector3 RearLeftLeg;
        public Vector3 RearLeftAnkle;
        public Vector3 RearLeftPaw;
        public Vector3 TailBase;
        public Vector3 TailMiddle;
        public Vector3 TailTip;
        public Vector3 Chin;
        public Vector3 Head;

        public static PosePositions Lerp(PosePositions from, PosePositions to, float t)
        {
            PosePositions pos = new PosePositions();
            pos.BellyFront = Vector3.Lerp(from.BellyFront, to.BellyFront, t);
            pos.BellyRear = Vector3.Lerp(from.BellyRear, to.BellyRear, t);
            pos.FrontRightLeg = Vector3.Lerp(from.FrontRightLeg, to.FrontRightLeg, t);
            pos.FrontRightAnkle = Vector3.Lerp(from.FrontRightAnkle, to.FrontRightAnkle, t);
            pos.FrontRightPaw = Vector3.Lerp(from.FrontRightPaw, to.FrontRightPaw, t);
            pos.FrontLeftLeg = Vector3.Lerp(from.FrontLeftLeg, to.FrontLeftLeg, t);
            pos.FrontLeftAnkle = Vector3.Lerp(from.FrontLeftAnkle, to.FrontLeftAnkle, t);
            pos.FrontLeftPaw = Vector3.Lerp(from.FrontLeftPaw, to.FrontLeftPaw, t);
            pos.RearRightLeg = Vector3.Lerp(from.RearRightLeg, to.RearRightLeg, t);
            pos.RearRightAnkle = Vector3.Lerp(from.RearRightAnkle, to.RearRightAnkle, t);
            pos.RearRightPaw = Vector3.Lerp(from.RearRightPaw, to.RearRightPaw, t);
            pos.RearLeftLeg = Vector3.Lerp(from.RearLeftLeg, to.RearLeftLeg, t);
            pos.RearLeftAnkle = Vector3.Lerp(from.RearLeftAnkle, to.RearLeftAnkle, t);
            pos.RearLeftPaw = Vector3.Lerp(from.RearLeftPaw, to.RearLeftPaw, t);
            pos.TailBase = Vector3.Lerp(from.TailBase, to.TailBase, t);
            pos.TailMiddle = Vector3.Lerp(from.TailMiddle, to.TailMiddle, t);
            pos.TailTip = Vector3.Lerp(from.TailTip, to.TailTip, t);
            pos.Chin = Vector3.Lerp(from.Chin, to.Chin, t);
            pos.Head = Vector3.Lerp(from.Head, to.Head, t);
            return pos;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        poses = new PosePositions[(int)Pose.Count];
        poses[(int)Pose.Stand] = CreatePosePosition(Pose.Stand);
        poses[(int)Pose.Sit] = CreatePosePosition(Pose.Sit);
        poses[(int)Pose.Rise] = CreatePosePosition(Pose.Rise);
        poses[(int)Pose.GiveRightPaw] = CreatePosePosition(Pose.GiveRightPaw);

        SetPosition(poses[(int)Pose.Stand]);
    }

    // Update is called once per frame
    void Update()
    {
        // don't change poses too quick or it will be weird
        if (currentPose != pose)
        {
            if (t < 1f)
            {
                SetPosition(PosePositions.Lerp(poses[(int)currentPose], poses[(int)pose], t));
                t += transitionDelta;
            } else
            {
                currentPose = pose;
                t = 0;
            }
        }
    }

    PosePositions CreatePosePosition(Pose pose)
    {
        PosePositions pos = new PosePositions();

        switch (pose)
        {
            case Pose.Stand:
                pos.BellyFront = new Vector3(0,1f,0);
                pos.BellyRear = new Vector3(1.5f,0,0);
                pos.FrontRightLeg = new Vector3(0, 0, 0.3f);
                pos.FrontRightAnkle = new Vector3(0, -0.5f, 0);
                pos.FrontRightPaw = pos.FrontRightAnkle;
                pos.FrontLeftLeg = -pos.FrontRightLeg;
                pos.FrontLeftAnkle = pos.FrontRightAnkle;
                pos.FrontLeftPaw = pos.FrontRightAnkle;
                pos.RearRightLeg = pos.FrontRightLeg;
                pos.RearRightAnkle = pos.FrontRightAnkle;
                pos.RearRightPaw = pos.FrontRightAnkle;
                pos.RearLeftLeg = -pos.FrontRightLeg;
                pos.RearLeftAnkle = pos.FrontRightAnkle;
                pos.RearLeftPaw = pos.FrontRightAnkle;
                pos.TailBase = new Vector3(0.3f, 0, 0);
                pos.TailMiddle = new Vector3(0.3f, -0.5f, 0);
                pos.TailTip = pos.TailMiddle;
                pos.Chin = new Vector3(-0.2f,0.3f,0);
                pos.Head = new Vector3(-0.5f,0,0);
                break;
            case Pose.Sit:
                pos.BellyFront = new Vector3(1f, 1f, 0);
                pos.BellyRear = new Vector3(1.1f, -0.8f, 0);
                pos.FrontRightLeg = new Vector3(0, 0, 0.3f);
                pos.FrontRightAnkle = new Vector3(0, -0.5f, 0);
                pos.FrontRightPaw = pos.FrontRightAnkle;
                pos.FrontLeftLeg = -pos.FrontRightLeg;
                pos.FrontLeftAnkle = pos.FrontRightAnkle;
                pos.FrontLeftPaw = pos.FrontRightPaw;
                pos.RearRightLeg = pos.FrontRightLeg;
                pos.RearRightAnkle = new Vector3(-0.4f, -0.2f, 0);
                pos.RearRightPaw = new Vector3(-0.5f, 0, 0);
                pos.RearLeftLeg = -pos.FrontRightLeg;
                pos.RearLeftAnkle = pos.RearRightAnkle;
                pos.RearLeftPaw = pos.RearRightPaw;
                pos.TailBase = new Vector3(0.1f, -0.1f, 0.1f);
                pos.TailMiddle = new Vector3(0, -0.1f, 0.2f);
                pos.TailTip = pos.TailMiddle;
                pos.Chin = new Vector3(-0.2f, 0.3f, 0);
                pos.Head = new Vector3(-0.5f, 0, 0);
                break;
            case Pose.Rise:
                pos.BellyFront = new Vector3(1.4f, 1.9f, 0);
                pos.BellyRear = new Vector3(0, -1.5f, 0);
                pos.FrontRightLeg = new Vector3(0, 0, 0.3f);
                pos.FrontRightAnkle = new Vector3(0, -0.5f, 0);
                pos.FrontRightPaw = new Vector3(-0.3f, 0.3f, 0);
                pos.FrontLeftLeg = -pos.FrontRightLeg;
                pos.FrontLeftAnkle = pos.FrontRightAnkle;
                pos.FrontLeftPaw = pos.FrontRightPaw;
                pos.RearRightLeg = pos.FrontRightLeg;
                pos.RearRightAnkle = new Vector3(0.1f, -0.4f, 0);
                pos.RearRightPaw = new Vector3(-0.5f, 0, 0);
                pos.RearLeftLeg = -pos.FrontRightLeg;
                pos.RearLeftAnkle = pos.RearRightAnkle;
                pos.RearLeftPaw = pos.RearRightPaw;
                pos.TailBase = new Vector3(0.2f, -0.1f, 0.1f);
                pos.TailMiddle = new Vector3(0.1f, -0.1f, 0.2f);
                pos.TailTip = new Vector3(0.1f, -0.2f, 0.1f);
                pos.Chin = new Vector3(-0.2f, 0.3f, 0);
                pos.Head = new Vector3(-0.5f, 0, 0);
                break;
        }
        return pos;
    }

    private void SetPosition(PosePositions pos)
    {
        GameObject.Find("BellyFront").transform.localPosition = pos.BellyFront;
        GameObject.Find("BellyRear").transform.localPosition = pos.BellyRear;
        GameObject.Find("FrontRightLeg").transform.localPosition = pos.FrontRightLeg;
        GameObject.Find("FrontRightAnkle").transform.localPosition = pos.FrontRightAnkle;
        GameObject.Find("FrontRightPaw").transform.localPosition = pos.FrontRightPaw;
        GameObject.Find("FrontLeftLeg").transform.localPosition = pos.FrontLeftLeg;
        GameObject.Find("FrontLeftAnkle").transform.localPosition = pos.FrontLeftAnkle;
        GameObject.Find("FrontLeftPaw").transform.localPosition = pos.FrontLeftPaw;
        GameObject.Find("RearRightLeg").transform.localPosition = pos.RearRightLeg;
        GameObject.Find("RearRightAnkle").transform.localPosition = pos.RearRightAnkle;
        GameObject.Find("RearRightPaw").transform.localPosition = pos.RearRightPaw;
        GameObject.Find("RearLeftLeg").transform.localPosition = pos.RearLeftLeg;
        GameObject.Find("RearLeftAnkle").transform.localPosition = pos.RearLeftAnkle;
        GameObject.Find("RearLeftPaw").transform.localPosition = pos.RearLeftPaw;
        GameObject.Find("TailBase").transform.localPosition = pos.TailBase;
        GameObject.Find("TailMiddle").transform.localPosition = pos.TailMiddle;
        GameObject.Find("TailTip").transform.localPosition = pos.TailTip;
        GameObject.Find("Chin").transform.localPosition = pos.Chin;
        GameObject.Find("Head").transform.localPosition = pos.Head;


        GameObject.FindGameObjectWithTag("GoodBoy").GetComponent<VisibleBones>().UpdateBones();

        return;
    }
}
