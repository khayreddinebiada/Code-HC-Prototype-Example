using UnityEngine;

namespace Main.store
{
    public class MarketViewPanel : MonoBehaviour, IPanel
    {
        [SerializeField] public int _indexDefaultPanel;
        [SerializeField] public GameObject _myPanel;
        [SerializeField] public StoreViewPanel[] _storesPanels;

        public StoreViewPanel currentPanelView { get; private set; }
        public bool isInited { get; private set; } = false;

        public bool isVisible { get; private set; }

        protected void Start()
        {
            if (isInited == true)
                return;

            for (int i = 0; i < _storesPanels.Length; i++)
                _storesPanels[i].Initialize(this, i);

            isInited = true;
        }

        public void Show()
        {
            isVisible = true;
            _myPanel.SetActive(true);
            ShowStore(_indexDefaultPanel);
        }

        public void Hide()
        {
            isVisible = false;
            _myPanel.SetActive(false);
            currentPanelView?.Hide();
            currentPanelView = null;
        }

        public void ShowStore(int idPanel)
        {
            currentPanelView?.Hide();
            currentPanelView = _storesPanels[idPanel];
            currentPanelView.Show();
        }

        public void OnClickRandomBuy()
        {
            currentPanelView?.RandomBuyProduct();
        }
    }
}
