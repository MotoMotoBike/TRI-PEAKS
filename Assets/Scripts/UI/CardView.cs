using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _frontSide; // UI Image для лицевой стороны

    public void SetCard(Card card)
    {
        // Загружаем спрайт для лицевой стороны
        var sprite = Resources.Load<Sprite>($"{card.Suit}/{card.Value}");
        _frontSide.sprite = sprite;
    }

    public void FlipToFront(Vector3 destination)
    {
        // Создаем последовательность для комбинирования анимаций
        Sequence sequence = DOTween.Sequence();

        // Добавляем анимацию перемещения
        sequence.Append(transform.DOMove(destination, 1).SetEase(Ease.InOutQuad)).OnComplete(() =>
        {
        });
        sequence.Join(
            transform.DORotate(new Vector3(0, 180, 0), 1f));

        // Запускаем последовательность
        sequence.Play();
    }
}