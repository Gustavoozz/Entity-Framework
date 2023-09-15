namespace webapi.inlock_CodeFirst.Utils
{
    public static class Criptografia
    {
        /// <summary>
        /// Gerar uma Hash a partir de uma senha
        /// </summary>
        /// <param name="senha">Senha que receberá a hash.</param>
        /// <returns>Senha criptografada com a hash.</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Verifica se a hash da senha informada é igual a hash salva no BD.
        /// </summary>
        /// <param name="senhaForm"> Senha passsada na form de Login.</param>
        /// <param name="senhaBanco"> Senha cadastrada no banco.</param>
        /// <returns>True ou False</returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
