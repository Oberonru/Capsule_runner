using System.Collections;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{
    // [SerializeField] private Renderer[] renderers;
    //
    // private IEnumerator BlinkEnumerator()
    // {
    //     for (float t = 0; t < 1; t += Time.deltaTime)
    //     {
    //         for (int i = 0; i < renderers.Length; i++)
    //         {
    //             for (int j = 0; j < renderers[i]?.materials.Length; j++)
    //             {
    //                 renderers[i]?.materials[j]
    //                     .SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0, 0));
    //             }
    //         }
    //         yield return null;
    //     }
    // }

    [SerializeField] private Renderer renderer;

    private IEnumerator BlinkEnumerator()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            renderer.material.SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0, 0));
            yield return null;
        }
    }

    public void Blinken()
    {
        StartCoroutine(BlinkEnumerator());
    }
}