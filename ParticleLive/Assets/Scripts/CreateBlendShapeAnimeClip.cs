using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Text;
public class CreateBlendShapeAnimeClip : MonoBehaviour
{

    public string targetName = "Face";

    public int MTH_A = 29;
    public int MTH_I = 30;
    public int MTH_U = 31;
    public int MTH_E = 32;
    public int MTH_O = 33;

    private int recordFlg = 0;
    SkinnedMeshRenderer target;

    AnimationClip animclip;
    AnimationCurve curveA;
    AnimationCurve curveI;
    AnimationCurve curveU;
    AnimationCurve curveE;
    AnimationCurve curveO;

    SkinnedMeshRenderer[] smeshs;

    // Use this for initialization
    void Start()
    {
#if UNITY_EDITOR
        target = GameObject.Find(targetName).GetComponent<SkinnedMeshRenderer>();

        animclip = new AnimationClip();

        curveA = new AnimationCurve();
        curveI = new AnimationCurve();
        curveU = new AnimationCurve();
        curveE = new AnimationCurve();
        curveO = new AnimationCurve();

        SetBlendShape();
#endif
    }


    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {

            recordFlg = 1;
        }

        CreateAnimationClip();
#endif
    }

    void CreateAnimationClip()
    {
#if UNITY_EDITOR

        foreach (var mesh in smeshs)
        {

            if (recordFlg == 1)
            {
                EditorCurveBinding curveBinding = new EditorCurveBinding();
                curveBinding.type = typeof(SkinnedMeshRenderer);
                curveBinding.path = "Face";

                float keyPoint = Time.time;

                curveBinding.propertyName = "blendShape." + mesh.sharedMesh.GetBlendShapeName(MTH_A);
                curveA.AddKey(keyPoint, mesh.GetBlendShapeWeight(MTH_A));
                AnimationUtility.SetEditorCurve(animclip, curveBinding, curveA);

                curveBinding.propertyName = "blendShape." + mesh.sharedMesh.GetBlendShapeName(MTH_I);
                curveI.AddKey(keyPoint, mesh.GetBlendShapeWeight(MTH_I));
                AnimationUtility.SetEditorCurve(animclip, curveBinding, curveI);

                curveBinding.propertyName = "blendShape." + mesh.sharedMesh.GetBlendShapeName(MTH_U);
                curveU.AddKey(keyPoint, mesh.GetBlendShapeWeight(MTH_U));
                AnimationUtility.SetEditorCurve(animclip, curveBinding, curveU);

                curveBinding.propertyName = "blendShape." + mesh.sharedMesh.GetBlendShapeName(MTH_E);
                curveE.AddKey(keyPoint, mesh.GetBlendShapeWeight(MTH_E));
                AnimationUtility.SetEditorCurve(animclip, curveBinding, curveE);

                curveBinding.propertyName = "blendShape." + mesh.sharedMesh.GetBlendShapeName(MTH_O);
                curveO.AddKey(keyPoint, mesh.GetBlendShapeWeight(MTH_O));
                AnimationUtility.SetEditorCurve(animclip, curveBinding, curveO);

                AssetDatabase.CreateAsset(animclip, AssetDatabase.GenerateUniqueAssetPath("Assets/" + target.gameObject.name + " Clip.anim"));
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                recordFlg = 2;
            }

            if (mesh.GetBlendShapeWeight(MTH_A) > 0 || mesh.GetBlendShapeWeight(MTH_I) > 0 ||
                mesh.GetBlendShapeWeight(MTH_U) > 0 || mesh.GetBlendShapeWeight(MTH_E) > 0 || mesh.GetBlendShapeWeight(MTH_O) > 0)
            {
                EditorCurveBinding curveBinding = new EditorCurveBinding();
                curveBinding.type = typeof(SkinnedMeshRenderer);
                curveBinding.path = "Face";

                float keyPoint = Time.time;

                curveBinding.propertyName = "blendShape." + mesh.sharedMesh.GetBlendShapeName(MTH_A);
                curveA.AddKey(keyPoint, mesh.GetBlendShapeWeight(MTH_A));

                curveBinding.propertyName = "blendShape." + mesh.sharedMesh.GetBlendShapeName(MTH_I);
                curveI.AddKey(keyPoint, mesh.GetBlendShapeWeight(MTH_I));

                curveBinding.propertyName = "blendShape." + mesh.sharedMesh.GetBlendShapeName(MTH_U);
                curveU.AddKey(keyPoint, mesh.GetBlendShapeWeight(MTH_U));

                curveBinding.propertyName = "blendShape." + mesh.sharedMesh.GetBlendShapeName(MTH_E);
                curveE.AddKey(keyPoint, mesh.GetBlendShapeWeight(MTH_E));

                curveBinding.propertyName = "blendShape." + mesh.sharedMesh.GetBlendShapeName(MTH_O);
                curveO.AddKey(keyPoint, mesh.GetBlendShapeWeight(MTH_O));

            }

        }

#endif
    }

    void SetBlendShape()
    {
        smeshs = this.GetSkinnedMeshRenderers();
    }

    SkinnedMeshRenderer[] GetSkinnedMeshRenderers()
    {
        var renderers = target.GetComponentsInChildren<SkinnedMeshRenderer>();
        List<SkinnedMeshRenderer> smeshList = new List<SkinnedMeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            var rend = renderers[i];
            var cnt = rend.sharedMesh.blendShapeCount;

            if (cnt > 0)
            {
                smeshList.Add(rend);
            }
        }

        return smeshList.ToArray();
    }
}

