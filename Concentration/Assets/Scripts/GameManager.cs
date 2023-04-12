using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float revealDuration = 1.5f; // 2枚のカードが一致しない場合の表示時間

    private Card firstRevealedCard; // 1枚目に表向きにされたカード
    private Card secondRevealedCard; // 2枚目に表向きにされたカード
    private int score; // プレイヤーのスコア

    // カードが表向きにされたときに呼び出される
    public void CardRevealed(Card card)
    {
        if (firstRevealedCard == null)
        {
            firstRevealedCard = card;
        }
        else
        {
            secondRevealedCard = card;
            StartCoroutine(CheckMatch());
        }
    }

    // 2枚のカードが一致するか確認し、スコアを更新する
    private IEnumerator CheckMatch()
    {
        if (firstRevealedCard.cardId == secondRevealedCard.cardId)
        {
            score++;
            Debug.Log("Score: " + score);
        }
        else
        {
            yield return new WaitForSeconds(revealDuration);
            firstRevealedCard.Hide();
            secondRevealedCard.Hide();
        }

        firstRevealedCard = null;
        secondRevealedCard = null;
    }
}
