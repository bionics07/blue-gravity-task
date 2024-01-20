using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CharacterAnimationManager
{
    public CharacterView CharacterView { get; private set; }

    public CharacterAnimationManager(CharacterView characterView)
    {
        CharacterView = characterView;
    }

    public void SetAnimation(CharacterAnimationParams characterAnimationParams, bool forceReset = false)
    {
        if(!forceReset && CharacterView.CurrentAnimationParams.AnimationKey == characterAnimationParams.AnimationKey)
        {
            return;
        }

        PlayAnimation(characterAnimationParams);
    }

    public void SetAnimation(string animationKey)
    {
        if (CharacterView.CurrentAnimationParams.AnimationKey == animationKey)
        {
            return;
        }

        CharacterAnimationParams characterAnimationParams = CharacterView.CurrentAnimationParams;
        characterAnimationParams.AnimationKey = animationKey;

        PlayAnimation(characterAnimationParams);
    }

    private void PlayAnimation(CharacterAnimationParams characterAnimationParams)
    {
        CharacterAnimations characterAnimations = GetCharacterAnimations(characterAnimationParams.AnimationKey);
        TimelineAsset timelineAsset = characterAnimations.TimelineAsset;
        AnimationClip bodyAnimation = GetBodyAnimation(characterAnimations, characterAnimationParams.BodySkinIndex);
        AnimationClip clothesAnimation = GetClothesAnimation(characterAnimations, characterAnimationParams.ClothesSkinIndex);
        AnimationClip hairAnimation = GetHairAnimation(characterAnimations, characterAnimationParams.HairSkinIndex);
        AnimationClip hatAnimation = GetHatAnimation(characterAnimations, characterAnimationParams.HatSkinIndex);

        PlayableDirector playableDirector = CharacterView.PlayableDirector;
        SetCharacterSkin(timelineAsset, bodyAnimation, clothesAnimation, hairAnimation, hatAnimation);

        playableDirector.playableAsset = timelineAsset;
        playableDirector.RebuildGraph();
        playableDirector.time = 0.0;
        playableDirector.Play();
        CharacterView.SetCurrentAnimationParams(characterAnimationParams);
    }

    private void SetCharacterSkin(TimelineAsset timelineAsset, AnimationClip bodyAnimation, AnimationClip clothesAnimation, AnimationClip hairAnimation, AnimationClip hatAnimation)
    {
        foreach (TrackAsset track in timelineAsset.GetOutputTracks())
        {
            if (track is AnimationTrack animationTrack)
            {
                
                foreach (TimelineClip timelineClip in animationTrack.GetClips())
                {
                    AnimationPlayableAsset animationAsset = timelineClip.asset as AnimationPlayableAsset;

                    if (animationTrack.name.Contains("Body"))
                    {
                        CharacterView.PlayableDirector.SetGenericBinding(animationTrack, CharacterView.BodyAnimator);
                        animationAsset.clip = bodyAnimation;
                    }
                    else if (animationTrack.name.Contains("Clothes"))
                    {
                        CharacterView.PlayableDirector.SetGenericBinding(animationTrack, CharacterView.ClothesAnimator);
                        animationAsset.clip = clothesAnimation;
                    }
                    else if (animationTrack.name.Contains("Hair"))
                    {
                        CharacterView.PlayableDirector.SetGenericBinding(animationTrack, CharacterView.HairAnimator);
                        animationAsset.clip = hairAnimation;
                    }
                    else if (animationTrack.name.Contains("Hat"))
                    {
                        CharacterView.PlayableDirector.SetGenericBinding(animationTrack, CharacterView.HatAnimator);
                        animationAsset.clip = hatAnimation;
                    }
                }
            }
        }
    }

    private CharacterAnimations GetCharacterAnimations(string animationKey)
    {
        foreach (CharacterAnimations animation in CharacterView.CharacterAnimationConfig.CharacterAnimations)
        {
            if (animation.AnimationKey == animationKey)
            {
                return animation;
            }
        }

        return null;
    }

    private AnimationClip GetBodyAnimation(CharacterAnimations characterAnimations, int skinIndex)
    {
        if(skinIndex >= characterAnimations.BodyAnimations.Length)
        {
            return characterAnimations.BodyAnimations[characterAnimations.BodyAnimations.Length - 1];
        }
        else
        {
            return characterAnimations.BodyAnimations[skinIndex];
        }
    }

    private AnimationClip GetClothesAnimation(CharacterAnimations characterAnimations, int skinIndex)
    {
        if (skinIndex >= characterAnimations.ClothesAnimations.Length)
        {
            return characterAnimations.ClothesAnimations[characterAnimations.ClothesAnimations.Length - 1];
        }
        else
        {
            return characterAnimations.ClothesAnimations[skinIndex];
        }
    }

    private AnimationClip GetHairAnimation(CharacterAnimations characterAnimations, int skinIndex)
    {
        if (skinIndex >= characterAnimations.HairAnimations.Length)
        {
            return characterAnimations.HairAnimations[characterAnimations.HairAnimations.Length - 1];
        }
        else
        {
            return characterAnimations.HairAnimations[skinIndex];
        }
    }

    private AnimationClip GetHatAnimation(CharacterAnimations characterAnimations, int skinIndex)
    {
        if (skinIndex >= characterAnimations.HatAnimations.Length)
        {
            return characterAnimations.HatAnimations[characterAnimations.HatAnimations.Length - 1];
        }
        else
        {
            return characterAnimations.HatAnimations[skinIndex];
        }
    }
}
