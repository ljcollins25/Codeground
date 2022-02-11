namespace System.Reflection.Metadata;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
public sealed class MetadataUpdateHandlerAttribute : Attribute
{
	public Type HandlerType { get; }

	public MetadataUpdateHandlerAttribute(Type handlerType)
	{
		HandlerType = handlerType;
	}
}
