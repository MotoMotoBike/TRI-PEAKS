using UnityEngine;

public class TriPeaksGameManager : MonoBehaviour
{
    private Deck _deck;
    private Table _table;
    private Card _selectedCard;

    [SerializeField] private GameObject cardPrefab; // Префаб карты
    [SerializeField] private Transform cardPrefabAnimationSpawnPoint;
    [SerializeField] private Transform cardPrefabAnimationEndPoint;
    private float _cardsOffset;

    private void Start()
    {
        _deck = new Deck();
        _table = new Table(_deck);
    }

    public void DrawNewCard()
    {
        var card = _deck.DrawCard();
        var currentCardObject = Instantiate(cardPrefab, cardPrefabAnimationSpawnPoint.position, Quaternion.identity);
        var cardView = currentCardObject.GetComponent<CardView>();
        cardView.SetCard(card);
        var endPosition = cardPrefabAnimationEndPoint.position;
        endPosition.z -= _cardsOffset;
        cardView.FlipToFront(endPosition);
        _cardsOffset += 0.01f;
        if (_deck.Count == 0)
        {
            Destroy(cardPrefabAnimationSpawnPoint.parent.gameObject);
        }
    }
}