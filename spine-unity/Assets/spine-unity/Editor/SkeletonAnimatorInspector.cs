

/*****************************************************************************
 * SkeletonAnimatorInspector created by Mitch Thompson
 * Full irrevocable rights and permissions granted to Esoteric Software
*****************************************************************************/
using System;
using UnityEditor;
using UnityEngine;
using Spine;

[CustomEditor(typeof(SkeletonAnimator))]
public class SkeletonAnimatorInspector : SkeletonRendererInspector {
    protected SerializedProperty layerMixModes, targetDeltaTime, timeScale;
	protected bool isPrefab;
	protected override void OnEnable () {
		base.OnEnable();
		layerMixModes = serializedObject.FindProperty("layerMixModes");
        targetDeltaTime = serializedObject.FindProperty("targetDeltaTime");
        timeScale = serializedObject.FindProperty("timeScale");

		if (PrefabUtility.GetPrefabType(this.target) == PrefabType.Prefab)
			isPrefab = true;
	}

	protected override void gui () {
		base.gui();

		EditorGUILayout.PropertyField(layerMixModes, true);

		SkeletonAnimator component = (SkeletonAnimator)target;
		if (!component.valid)
			return;

        EditorGUILayout.PropertyField(targetDeltaTime);
        EditorGUILayout.PropertyField(timeScale);

		EditorGUILayout.Space();

		if (!isPrefab) {
			if (component.GetComponent<SkeletonUtility>() == null) {
				if (GUILayout.Button(new GUIContent("Add Skeleton Utility", SpineEditorUtilities.Icons.skeletonUtility), GUILayout.Height(30))) {
					component.gameObject.AddComponent<SkeletonUtility>();
				}
			}
		}
	}
}