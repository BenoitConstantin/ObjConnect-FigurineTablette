using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

 public class FX_Scripts : MonoBehaviour {
    
    public bool destroyAfter;
    public bool instantiateFX;
    public GameObject FXtoInstantiate;

    Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    public void InstanceOther() {

        //Instance le prochain objet, marche bizarrement
        if (instantiateFX && FXtoInstantiate != null) {

            Debug.Log("Coucou");

            Instantiate(FXtoInstantiate);
            GameObject obj = Instantiate(FXtoInstantiate);
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
        }

    }

    public void AnimationEnd() {

      //  Debug.Log("Sayonara");
        
        if (destroyAfter) {
            Destroy(gameObject);
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(FX_Scripts))]
public class FXEditor : Editor {

    public override void OnInspectorGUI() {
        FX_Scripts fx = (FX_Scripts)target;
        fx.destroyAfter = EditorGUILayout.Toggle("Destroy FX", fx.destroyAfter);
        fx.instantiateFX = EditorGUILayout.Toggle("Instantiate an FX", fx.instantiateFX);
        if (fx.instantiateFX) {
            fx.FXtoInstantiate =(GameObject)EditorGUILayout.ObjectField(fx.FXtoInstantiate, typeof(GameObject), false);
        }
        EditorUtility.SetDirty(fx);
    }
}
#endif
