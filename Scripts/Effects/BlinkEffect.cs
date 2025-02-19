using UnityEngine;
using System.Collections;

public class BlinkEffect : MonoBehaviour
{
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private IEnumerator Blink()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            _renderer.material.SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0, 0));
            yield return null;
        }
    }

    public void Blinken()
    {
        StartCoroutine(Blink());
    }
}