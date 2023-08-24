using UnityEngine;

using Physics = PHATASS.Utils.Physics;
using static PHATASS.Utils.Extensions.TimeExtensions;

namespace PHATASS.Utils.Physics
{
// Base for any updatable physics1D component, like springs or contraints.
	[System.Serializable]
	public abstract class BasePhysicsUpdatable :
		IPhysicsUpdatable
	{
	//serialized fields
		[SerializeField]
		[Tooltip("If enabled == true, Update() calls will be ignored, effectively disabling the component. Get/set through IToggleable.state.")]
		private bool _enabled = true;
		protected bool enabled
		{
			get { return this._enabled; }
			private set { this._enabled = value; }
		}
	//ENDOF serialized fields

	//IPhysics1DComponent
		void PHATASS.Utils.Physics.IPhysicsUpdatable.Update (float? timeStep)
		{ this.TryUpdate(timeStep); }

		//IToggleable.state represents the enabled/disabled state of the component. If component is disabled (state == false), updates are ignored.
		bool PHATASS.Utils.Types.Toggleables.IToggleable.state
		{
			get { return this.enabled; }
			set { this.enabled = value; }
		}
	//ENDOF IPhysics1DComponent

	//inheritable members
		protected abstract void Update (float? timeStep);
	//ENDOF inheritable members

	//private members
		//TryUpdate filters null timeSteps and ensures component is enabled before propagating the call to inheriting implementors
		private void TryUpdate (float? timeStep)
		{
			if (!this.enabled) { return; }
			this.Update(timeStep.EValidateDeltaTime());
		}
	//ENDOF private members
	}
}