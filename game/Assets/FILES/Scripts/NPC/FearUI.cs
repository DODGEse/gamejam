using UnityEngine;
using UnityEngine.UI;

public class FearUI : MonoBehaviour
{
    public FearSystem fearSystem;
    public Image fillImage;
    public Gradient colorGradient;

    private void Update()
    {
        if (fearSystem == null || fillImage == null) return;

        float fearPercent = fearSystem.fearLevel / fearSystem.fearPanic;
        
        fillImage.fillAmount = fearPercent;
        fillImage.color = colorGradient.Evaluate(fearPercent);
    }
}