using UnityEngine;

public class LightUpdate : MonoBehaviour
{
    public void Awake()
    {
        DynamicGI.UpdateEnvironment();
    }
}
