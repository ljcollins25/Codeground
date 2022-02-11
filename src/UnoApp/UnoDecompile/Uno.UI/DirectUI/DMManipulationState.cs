namespace DirectUI;

internal enum DMManipulationState
{
	DMManipulationStarting = 1,
	DMManipulationStarted,
	DMManipulationDelta,
	DMManipulationLastDelta,
	DMManipulationCompleted,
	ConstantVelocityScrollStarted,
	ConstantVelocityScrollStopped
}
