using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public GameObject cardPrefab; // カードプレファブ
    public Sprite[] cardSprites; // カード表面の画像の配列
    public int gridSizeX; // グリッドのX方向のサイズ
    public int gridSizeY; // グリッドのY方向のサイズ
    public float cardSpacing; // カード間のスペース

    private void Start()
    {
        SpawnCards(); // カードを生成・配置する
    }

    // カードを生成・配置する関数
    private void SpawnCards()
    {
        List<int> cardIds = GenerateCardIds(); // カードIDリストを生成
        int cardIndex = 0;

        for (int y = 0; y < gridSizeY; y++)
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                // カードをインスタンス化し、グリッド上に配置する
                GameObject card = Instantiate(cardPrefab, transform);
                RectTransform cardRect = card.GetComponent<RectTransform>();
                cardRect.anchoredPosition = new Vector2(x * cardSpacing, y * cardSpacing);
                Card cardScript = card.GetComponent<Card>();
                cardScript.cardId = cardIds[cardIndex]; // カードIDを設定
                cardScript.cardFront = cardSprites[cardIds[cardIndex]]; // 表面画像を設定
                cardIndex++;
            }
        }
    }

    // カードIDリストを生成する関数
    private List<int> GenerateCardIds()
    {
        List<int> cardIds = new List<int>();
        int pairCount = (gridSizeX * gridSizeY) / 2;

        // 各ペアのカードIDをリストに追加
        for (int i = 0; i < pairCount; i++)
        {
            cardIds.Add(i);
            cardIds.Add(i);
        }

        return ShuffleCardIds(cardIds); // カードIDリストをシャッフルして返す
    }

    // カードIDリストをシャッフルする関数
    private List<int> ShuffleCardIds(List<int> cardIds)
    {
        for (int i = 0; i < cardIds.Count; i++)
        {
            int temp = cardIds[i];
            int randomIndex = Random.Range(i, cardIds.Count);
            cardIds[i] = cardIds[randomIndex];
            cardIds[randomIndex] = temp;
        }

        return cardIds;
    }
}
