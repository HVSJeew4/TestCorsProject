public interface ICorsPolicyService
{
    Task<List<string>> GetAllowedOriginsAsync();
}