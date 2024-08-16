namespace ThomasGregChallenge.Base.Configuracoes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class SwaggerIgnoreAttribute : Attribute
    { }
}
