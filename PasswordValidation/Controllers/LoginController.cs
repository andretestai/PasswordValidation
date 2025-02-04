using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PasswordValidation.Interfaces;

namespace PasswordValidation.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService cadastroService)
        {
            _loginService = cadastroService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost("SalvarCadastro")]
        public async Task<IActionResult> SalvarCadastro(string usuario, string senha)
        {
            var resultado =  await _loginService.SalvarCadastro(usuario, senha);

            if (resultado == true)
            {
                return Ok();
            }

            return BadRequest("Erro ao cadastrar usuario");
        }

        [HttpPost("VerificarUsuarioDuplicado")]
        public async Task<IActionResult> VerificarUsuarioDuplicado(string usuario)
        {
            var existeUsuario = await _loginService.VerificarUsuarioDuplicado(usuario);

            if (existeUsuario == true)
            {
                return Ok();
            }

            return BadRequest("Usuario Duplicado");
        }

        [HttpPost("Logar")]
        public async Task<IActionResult> Logar(string usuario, string senha)
        { 
            var resultado = await _loginService.ValidarLogin(usuario, senha);

            if (resultado)
            {
                return Ok("Login realizado com sucesso!");
            }

            return Unauthorized("Usuário ou senha inválidos.");
        }
    }
}
