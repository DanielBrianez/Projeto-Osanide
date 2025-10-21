using OsanideDTO;

namespace OsanideBLL
{
    public static class AppSession
    {
        // ✅ A sessão deve ser estática e centralizada
        public static FuncionarioDTO UsuarioLogado { get; set; }


        // 🔔 Evento global: notifica quando o usuário logado for alterado 
        public static event Action<FuncionarioDTO> OnUsuarioAtualizado;

        // ✅ Define o usuário inicial (ex: no login)
        public static void DefinirUsuario(FuncionarioDTO usuario)
        {
            UsuarioLogado = usuario;
        }

        // ✅ Atualiza o usuário e dispara o evento global
        public static void AtualizarUsuarioLogado(FuncionarioDTO novoUsuario)
        {
            UsuarioLogado = novoUsuario;
            OnUsuarioAtualizado?.Invoke(novoUsuario); // Notifica formulários/UCs ativos
        }
    }
}
