using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MultipleCondition : ConditionTask
{

    public ConditionList conditionTasks;


    public override void OnValidate(ITaskSystem ownerSystem)
    {

        base.OnValidate(ownerSystem);
        SetOwnerSystem(ownerSystem);

        if (conditionTasks == null)
        {
            conditionTasks = (ConditionList)Task.Create(typeof(ConditionList), ownerSystem);
            conditionTasks.checkMode = ConditionList.ConditionsCheckMode.AllTrueRequired;
        }

        conditionTasks.OnValidate(ownerSystem);

        conditionTasks.SetOwnerSystem(this.ownerSystem);


        foreach (ConditionTask c in conditionTasks.conditions)
        {
            c.SetOwnerSystem(this.ownerSystem);
        }

    }


    public override Task Duplicate(ITaskSystem newOwnerSystem)
    {
        var newConditionnedAction = (MultipleCondition)base.Duplicate(newOwnerSystem);
        newConditionnedAction.conditionTasks = (ConditionList)conditionTasks.Duplicate(newOwnerSystem);

        return newConditionnedAction;
    }


    protected override void OnEnable()
    {
        base.OnEnable();
        conditionTasks.Enable(this.agent, this.blackboard);
    }

    protected override bool OnCheck()
    {
        return conditionTasks.CheckCondition(this.agent,this.blackboard);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        conditionTasks.Disable();
    }




#if UNITY_EDITOR
    protected override void OnTaskInspectorGUI()
    {
      
        foreach (ConditionTask c in conditionTasks.conditions)
        {
            c.SetOwnerSystem(this.ownerSystem);
        }

        GUILayout.Label("Conditions");
        conditionTasks.ShowListGUI();
        conditionTasks.ShowNestedConditionsGUI();
    }




    public void DoSavePreset()
    {
#if !UNITY_WEBPLAYER
        var path = EditorUtility.SaveFilePanelInProject("Save Preset", "", "ConditionnedAction", "");
        if (!string.IsNullOrEmpty(path))
        {
            System.IO.File.WriteAllText(path, JSONSerializer.Serialize(typeof(MultipleCondition), this, true)); //true for pretyJson
            AssetDatabase.Refresh();
        }
#else
            Debug.LogWarning("Preset saving is not possible with WebPlayer as active platform");
#endif
    }

    public void DoLoadPreset()
    {
#if !UNITY_WEBPLAYER
        var path = EditorUtility.OpenFilePanel("Load Preset", "Assets", "ConditionnedAction");
        if (!string.IsNullOrEmpty(path))
        {
            var json = System.IO.File.ReadAllText(path);
            var list = JSONSerializer.Deserialize<MultipleCondition>(json);

            this.conditionTasks = list.conditionTasks;

            this.conditionTasks.SetOwnerSystem(this.ownerSystem);


            foreach (var c in this.conditionTasks.conditions)
            {
                c.SetOwnerSystem(this.ownerSystem);
            }
        }
#else
            Debug.LogWarning("Preset loading is not possible with WebPlayer as active platform");
#endif
    }

#endif


}
