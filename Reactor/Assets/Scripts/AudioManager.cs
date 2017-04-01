using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private void Awake()
    {
        ToolBox.RegisterAsTool(this);
    }

    private void OnDestroy()
    {
        ToolBox.UnregisterTool(this);
    }

}
