using UnityEngine;
using TMPro;

public class AvoidDangerCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;
    public int switchCount = 0;
    
    public static AvoidDangerCounter instance;

    void Awake()
    {
        instance = this;
    }
    
    public void UpdateCounterText()
    {
        switchCount++;
    }

    void Update()
    {
        counterText.text = switchCount.ToString();
    }
}
