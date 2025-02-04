namespace PasswordValidation.Interfaces
{
    public interface ILoginRepository
    {
        Task<bool> VerificarUsuarioDuplicado(string usuario);
        Task<bool> SalvarCadastro(string usuario, string senha);
        Task<bool> ValidarLogin(string usuario, string senha);
    }
}
