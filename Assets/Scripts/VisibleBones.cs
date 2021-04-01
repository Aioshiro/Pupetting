using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleBones : MonoBehaviour
{
    private class Bone
    {
        private GameObject bone;
        private Transform from;
        private Transform to;
        public Bone(GameObject _bone, Transform _from, Transform _to)
        {
            bone = _bone;
            from = _from;
            to = _to;

            bone.transform.SetParent(from);
            bone.GetComponent<MeshRenderer>().material = Resources.Load<Material>("GoodBoySkin");

            UpdateBone();
        }

        public void UpdateBone()
        {
            bone.transform.localPosition = 0.5f * (to.position - from.position);
            // must rotate
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, Vector3.Normalize(to.position - from.position));
            bone.transform.localRotation = rot;
            bone.transform.localScale = new Vector3(bone.transform.localScale.x, 0.5f * Vector3.Magnitude(to.position - from.position), bone.transform.localScale.z);
        }
    }

    List<Bone> bones = new List<Bone>();

    public GameObject bonePrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject goodBoy = GameObject.FindGameObjectWithTag("GoodBoy");
        RecursiveSkeleton(goodBoy.transform.GetChild(0).gameObject);

        GameObject.Find("GoodBoy").transform.SetParent(GameObject.Find("Head").transform);
        GameObject.Find("GoodBoy").transform.localPosition = Vector3.zero;
    }

    void RecursiveSkeleton(GameObject go)
    {
        for (int i = 0; i < go.transform.childCount; i++)
        {
            if (go.transform.GetChild(i).gameObject.tag.Equals("GoodBoyKnuckle"))
            {
                bones.Add(new Bone(GameObject.Instantiate(bonePrefab), go.transform, go.transform.GetChild(i)));
                RecursiveSkeleton(go.transform.GetChild(i).gameObject);
            }
        }
    }

    public void UpdateBones()
    {
        foreach(Bone bone in bones)
        {
            bone.UpdateBone();
        }
    }
}
