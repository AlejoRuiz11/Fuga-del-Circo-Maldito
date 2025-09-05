using UnityEngine;
using UnityEngine.EventSystems;

public class InputStandaloneFix : MonoBehaviour
{
    void Start()
    {
        var inputModule = GetComponent<StandaloneInputModule>();
        if (inputModule != null)
        {
            inputModule.forceModuleActive = true;
        }
    }
}