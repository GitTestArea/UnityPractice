using UnityEngine;
using System.Collections;

public class VroidLipSyncController : MonoBehaviour
{
    public string targetName;

    public Transform nodeA;
    public Transform nodeE;
    public Transform nodeI;
    public Transform nodeO;
    public Transform nodeU;

    public AnimationCurve weightCurve;

    SkinnedMeshRenderer target;

    void Start()
    {
        target = GameObject.Find(targetName).GetComponent<SkinnedMeshRenderer>();
    }

    float GetWeight(Transform tr)
    {
        return weightCurve.Evaluate(tr.localPosition.z);
    }

    void LateUpdate()
    {
        var total = 100.0f;

        var w = total * GetWeight(nodeA);
        // target.SetBlendShapeWeight(6, w);
        target.SetBlendShapeWeight(29, w);
        total -= w;

        w = total * GetWeight(nodeI);
        // target.SetBlendShapeWeight(7, w);
        target.SetBlendShapeWeight(30, w);
        total -= w;

        w = total * GetWeight(nodeU);
        // target.SetBlendShapeWeight(8, w);
        target.SetBlendShapeWeight(31, w);
        total -= w;

        w = total * GetWeight(nodeE);
        // target.SetBlendShapeWeight(9, w);
        target.SetBlendShapeWeight(32, w);
        total -= w;

        w = total * GetWeight(nodeO);
        // target.SetBlendShapeWeight(10, w);
        target.SetBlendShapeWeight(33, w);
    }
}
