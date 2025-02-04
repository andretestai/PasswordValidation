using Microsoft.EntityFrameworkCore;
using PasswordValidation.Interfaces;
using PasswordValidation.Models;

namespace PasswordValidation.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataBase _context;

        public LoginRepository(DataBase context)
        {
            _context = context;
        }

        public async Task<bool> VerificarUsuarioDuplicado(string usuario)
        {
            return await _context.Usuarios
                .AnyAsync(u => u.NomeUsuario == usuario);
        }

        public async Task<bool> SalvarCadastro(string usuario, string senha)
        {
            var novoUsuario = new Usuario
            {
                NomeUsuario = usuario,
                SenhaUsuario = senha 
            };

            await _context.Usuarios.AddAsync(novoUsuario);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ValidarLogin(string usuario, string senha)
        {
            var usuarioBanco = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NomeUsuario == usuario);

            if (usuarioBanco == null)
            {
                return false; 
            }

            if (usuarioBanco.SenhaUsuario == senha)
            {
                return true;
            }

            return false;
        }

    }
}
