using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public SpriteRenderer healthBarRenderer;
    public TextMesh textMesh;
    public void UpdateValue(float value, float percent)
    {
        Vector3 temp = healthBarRenderer.transform.localScale;
        temp.x = percent;
        healthBarRenderer.transform.localScale = temp;
        textMesh.text = Mathf.Round(value).ToString();
    }

    public void DoDestroy()
    {
        Destroy(healthBarRenderer.gameObject);
        Destroy(textMesh.gameObject);
        Destroy(gameObject);
    }
}
