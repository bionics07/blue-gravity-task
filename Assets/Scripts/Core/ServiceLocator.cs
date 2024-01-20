using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    [SerializeField] private CharacterView _characterView;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private CharacterMovementConfig _characterMovementConfig;
    [SerializeField] private MapLimitConfig _limitConfig;
    [SerializeField] private UIManager _uiManager;

    public CharacterView CharacterView => _characterView;
    public InputManager InputManager => _inputManager;
    public UIManager UIManager => _uiManager;
    public CharacterAnimationManager CharacterAnimationManager { get; private set; }
    public CharacterMovementManager CharacterMovementManager { get; private set; }
    public CharacterInputService CharacterInputService { get; private set; }
    public MapLimitManager MapLimitManager { get; private set; }
    public CharacterCollisionManager CharacterCollisionManager { get; private set; }
    public InventoryManager InventoryManager { get; private set; }
    public ObserverService ObserverService { get; private set; }
    public CharacterInteractionService CharacterInteractionService { get; private set; }

    public static ServiceLocator Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        Init();
    }

    private void Init()
    {
        ObserverService = new ObserverService();
        CharacterAnimationManager = new CharacterAnimationManager(_characterView);
        CharacterMovementManager = new CharacterMovementManager(_characterView, _characterMovementConfig);
        CharacterInputService = new CharacterInputService(_characterView);
        MapLimitManager = new MapLimitManager(_limitConfig, _characterView);
        CharacterCollisionManager = new CharacterCollisionManager();
        InventoryManager = new InventoryManager();
        CharacterInteractionService = new CharacterInteractionService();
    }
}
