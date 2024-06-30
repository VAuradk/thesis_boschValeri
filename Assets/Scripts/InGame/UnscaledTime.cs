using UnityEngine;
public class UnscaledTime : MonoBehaviour
{
    public Material material;

    private void Update()
    {
        material.SetFloat("_UnscaledTime", Time.unscaledTime);
    }
}
