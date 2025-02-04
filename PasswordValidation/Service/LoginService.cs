using PasswordValidation.Interfaces;

namespace PasswordValidation.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<bool> SalvarCadastro(string usuario, string senha)
        {
            return await _loginRepository.SalvarCadastro(usuario, senha);
        }
        public async Task<bool> ValidarLogin(string usuario, string senha)
        {
            return await _loginRepository.ValidarLogin(usuario, senha);
        }

        public async Task<bool> VerificarUsuarioDuplicado(string usuario)
        {
           return await _loginRepository.VerificarUsuarioDuplicado(usuario);
        }
    }
}
