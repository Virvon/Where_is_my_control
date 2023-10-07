using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFirstCutScene : MonoBehaviour
{
    private void Start()
    {
        CutsceneManager.Instance.StartCutscene("CutScene1");
    }
}
