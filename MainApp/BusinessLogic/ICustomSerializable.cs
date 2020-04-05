namespace BusinessLogic
{
    public interface ICustomSerializable
    {
        string Serialize<T>(T entity) where T : class, new();
        T Deserialize<T>(string entity) where T : class, new();
    }
}
