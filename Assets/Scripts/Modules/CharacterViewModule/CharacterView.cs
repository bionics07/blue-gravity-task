using UnityEngine;
using UnityEngine.Playables;

public class CharacterView : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private CharacterAnimationConfig _characterAnimationConfig;
    [SerializeField] private Animator _bodyAnimator;
    [SerializeField] private Animator _clothesAnimator;
    [SerializeField] private Animator _hairAnimator;
    [SerializeField] private Animator _hatAnimator;
    [SerializeField] private CharacterAnimationParams _defaultParams;

    public Animator BodyAnimator => _bodyAnimator;
    public Animator ClothesAnimator => _clothesAnimator;
    public Animator HairAnimator => _hairAnimator;
    public Animator HatAnimator => _hatAnimator;
    public CharacterAnimationConfig CharacterAnimationConfig => _characterAnimationConfig;
    public PlayableDirector PlayableDirector => _playableDirector;
    public CharacterAnimationParams DefaultParams => _defaultParams;

    public CharacterAnimationParams CurrentAnimationParams { get; private set; }

    private void Start()
    {
        SetAnimation(DefaultParams);
    }

    public void SetAnimation(CharacterAnimationParams characterAnimationParams)
    {
        ServiceLocator.Instance.CharacterAnimationManager.SetAnimation(characterAnimationParams, true);
    }

    public void SetCurrentAnimationParams(CharacterAnimationParams characterAnimationParams)
    {
        CurrentAnimationParams = characterAnimationParams;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ServiceLocator.Instance.CharacterCollisionManager.OnTriggerEnter(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ServiceLocator.Instance.CharacterCollisionManager.OnTriggerExit(collision);
    }
}
