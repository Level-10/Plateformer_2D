using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] int coinsCount = 0;

    public static Inventory instance;
    [SerializeField] TMP_Text coinsCountText = null;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There's already an instance of Inventory");
            return;
        }
        instance = this;
    }

    public void AddCoins(int _count)
    {
        coinsCount += _count;
        coinsCountText.text = coinsCount.ToString();
    }
}
