using System.Collections.Generic;
using UnityEngine;

public class AnimatorStatesNamesAttribute : StringPopupAttribute
{
    protected string m_animatorName;
    protected char m_stateLayerDelimiter;

    public AnimatorStatesNamesAttribute(string animatorName, char stateLayerDelimiter=(char)0x00)
    {
        m_animatorName = animatorName;
        m_stateLayerDelimiter = stateLayerDelimiter;
    }

    protected override void GetOptionsInternal(UnityEngine.Object targetObject)
    {
        #if UNITY_EDITOR

        object obj = targetObject.GetType().GetField(m_animatorName, BindingFlags)
        .GetValue(targetObject);

        UnityEditor.Animations.AnimatorController animatorController;
        if(obj is Animator)
        {
            animatorController = (obj as Animator).runtimeAnimatorController as UnityEditor.Animations.AnimatorController;
        }
        else
        {
            animatorController = obj as UnityEditor.Animations.AnimatorController;
        }

        List<string> statesLayers = new List<string>();
        UnityEditor.Animations.AnimatorControllerLayer[] animatorControllerLayer = animatorController.layers;
        int layer;

        void AddStatesInStateMachine(UnityEditor.Animations.AnimatorStateMachine animatorStateMachine)
        {
            foreach(UnityEditor.Animations.ChildAnimatorState childAnimatorState in animatorStateMachine.states)
            {
                if(char.IsControl(m_stateLayerDelimiter))
                {
                    statesLayers.Add($"{childAnimatorState.state.name}");
                }
                else
                {
                    statesLayers.Add($"{childAnimatorState.state.name}{m_stateLayerDelimiter}{layer}");
                }
            }

            foreach(UnityEditor.Animations.ChildAnimatorStateMachine childAnimatorStateMachine in animatorStateMachine.stateMachines)
            {
                AddStatesInStateMachine(childAnimatorStateMachine.stateMachine);
            }
        }

        for(layer=0; layer<animatorControllerLayer.Length; layer++)
        {
            AddStatesInStateMachine(animatorControllerLayer[layer].stateMachine);
        }
        
        m_options = statesLayers.ToArray();

        #endif
    }
}
