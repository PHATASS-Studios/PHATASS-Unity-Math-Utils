using System.Collections.Generic;

using Animator = UnityEngine.Animator;

using SerializableAnimatorVariableIdentifier = PHATASS.Utils.Types.SerializableAnimatorVariableIdentifier;


namespace PHATASS.Utils.Extensions
{
// Extensions class offering methods assisting with the management of lists of Animator objects
	public static class AnimatorListExtensions
	{
	// Animator variable setting methods - sets animator vars values on every animator on a list
		public static void SetBool (this IList<Animator> animators, SerializableAnimatorVariableIdentifier varName, bool value)
		{
			foreach (Animator animator in animators)
			{ animator.SetBool(id: varName, value: value); }
		}

		public static void SetFloat (this IList<Animator> animators, SerializableAnimatorVariableIdentifier varName, float value)
		{
			foreach (Animator animator in animators)
			{ animator.SetFloat(id: varName, value: value); }
		}

		public static void SetInteger (this IList<Animator> animators, SerializableAnimatorVariableIdentifier varName, int value)
		{
			foreach (Animator animator in animators)
			{ animator.SetInteger(id: varName, value: value); }
		}

		public static void SetTrigger (this IList<Animator> animators, SerializableAnimatorVariableIdentifier varName)
		{
			foreach (Animator animator in animators)
			{ animator.SetTrigger(id: varName); }
		}

		public static void ResetTrigger (this IList<Animator> animators, SerializableAnimatorVariableIdentifier varName)
		{
			foreach (Animator animator in animators)
			{ animator.ResetTrigger(id: varName); }
		}
	//ENDOF Animator variable setting methods
	}
}
