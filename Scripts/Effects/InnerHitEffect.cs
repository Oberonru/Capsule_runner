using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InnerHitEffect : MonoBehaviour
{
   [SerializeField] private Image borderImg;
   
   private IEnumerator ShowEffect()
   {
      borderImg.enabled = true;

      for (float t = 1; t > 0; t -= Time.deltaTime)
      {
         borderImg.color = new Color(1, 0, 0, t);
         yield return null;
      }

      borderImg.enabled = false;
   }

   public void ShowInnerHitEffect()
   {
      StartCoroutine(ShowEffect());
   }
}
