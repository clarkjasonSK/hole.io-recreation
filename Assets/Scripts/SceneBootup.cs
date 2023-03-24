using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBootup : MonoBehaviour, IBootstrapper
{
    [SerializeField] private GameValues _game_values;
    [SerializeField] private VisualValues _visual_values;
    public void Awake()
    {
        LoadSingletonsAndDependencies();
    }
    public void LoadSingletonsAndDependencies()
    {
        //GameManager.Instance.GameValues = ScriptableObjectsHelper.GetScriptableObject<GameValues>(FileNames.GAME_VALUES);

        //GameManager.Instance.VisualValues = ScriptableObjectsHelper.GetScriptableObject<VisualValues>(FileNames.VISUAL_VALUES);

        GameManager.Instance.GameValues = _game_values;
        GameManager.Instance.VisualValues = _visual_values;

        PlayerHandler.Instance.Initialize();
        HoleHandler.Instance.Initialize();
        PropHandler.Instance.Initialize();
        VFXHandler.Instance.Initialize();
        CameraHandler.Instance.Initialize();

        if (PlayerHandler.Instance.IsDoneInitializing
            && HoleHandler.Instance.IsDoneInitializing
            && PropHandler.Instance.IsDoneInitializing
            && VFXHandler.Instance.IsDoneInitializing
            && CameraHandler.Instance.IsDoneInitializing)
        {
            Debug.Log(SceneNames.GAME_SCENE + " initialized!");
            
            //EventBroadcaster.Instance.PostEvent(EventKeys.START_GAME, null);
        }
    }
}
