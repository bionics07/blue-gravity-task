using System;
using UnityEngine;
using UnityEngine.Timeline;

[Serializable]
public class CharacterAnimations
{
    [SerializeField] private string _animationKey;
    [SerializeField] private TimelineAsset _timelineAsset;

    [SerializeField] private AnimationClip[] _bodyAnimations;
    [SerializeField] private AnimationClip[] _clothesAnimations;
    [SerializeField] private AnimationClip[] _hairAnimations;
    [SerializeField] private AnimationClip[] _hatAnimations;

    public string AnimationKey => _animationKey;
    public AnimationClip[] BodyAnimations => _bodyAnimations;
    public AnimationClip[] ClothesAnimations => _clothesAnimations;
    public AnimationClip[] HairAnimations => _hairAnimations;
    public AnimationClip[] HatAnimations => _hatAnimations;
    public TimelineAsset TimelineAsset => _timelineAsset;
}
