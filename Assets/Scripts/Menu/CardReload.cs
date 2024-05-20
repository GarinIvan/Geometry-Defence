using UnityEngine;
using UnityEngine.UI;

public class CardReload : MonoBehaviour
{
    public Image reloadImage;
    public float startTime;
    public float currentTime;
    private Card _cardSO;
    public void SetTimeToReload(float timeToReload)
    {
        startTime = timeToReload;
        currentTime = startTime;
        reloadImage.fillAmount = 1;
    }
    private void Start()
    {
        currentTime = 0;
        reloadImage.fillAmount = 0;
    }
    private void Update()
    {
        currentTime -= Time.deltaTime;
        reloadImage.fillAmount = currentTime / startTime;
        if (reloadImage.fillAmount <= 0)
        {
            return;
        }
    }
    public void Reload()
    {
        currentTime = startTime;
        reloadImage.fillAmount = 1;
    }
}
