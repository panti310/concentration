using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int cardId; // このカードのID
    public Sprite cardFront; // カードの表面の画像
    public Sprite cardBack; // カードの裏面の画像
    public bool isRevealed = false; // カードが表向きかどうか

    private Image image; // カードのImageコンポーネント
    private GameManager gameManager; // ゲームマネージャーへの参照

    private void Start()
    {
        image = GetComponent<Image>(); // Imageコンポーネントを取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // ゲームマネージャーを検索し、参照を取得
    }

    // カードがクリックされたときの処理
    public void OnCardClicked()
    {
        if (!isRevealed)
        {
            isRevealed = true;
            image.sprite = cardFront;
            gameManager.CardRevealed(this);
        }
    }

    // カードを裏返す処理
    public void Hide()
    {
        image.sprite = cardBack;
        isRevealed = false;
    }
}
