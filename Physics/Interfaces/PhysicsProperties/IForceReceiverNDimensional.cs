namespace PHATASS.Utils.Physics
{
// Interface representing an object capable of receiving N-dimensional kinetic forces
//	TDimensionalVector is meant to be a type capable of storing and representing an N-dimensional vector
	public interface IForceReceiverNDimensional <TDimensionalVector>
	{
		//Adds a 1D momentum to the body, with a force & direction depending on momentum value and sign.
		void AddMomentum (TDimensionalVector momentum);
	}
}