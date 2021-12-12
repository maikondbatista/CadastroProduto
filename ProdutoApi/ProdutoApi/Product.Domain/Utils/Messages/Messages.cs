namespace Products.Domain.Utils.Messages
{
    public static class Messages
    {
        public static string Mandatory(string field) { return $"O Campo {field} é obrigatório(a)."; }
        public static string MaximumCharacters(string nomeCampo, int qtdCaracteres) { return $"O Campo {nomeCampo} deve ter no máximo {qtdCaracteres}."; }

        public static string BiggerThanZero(string nomeCampo) { return $"O Campo {nomeCampo} deve ser maior que zero."; }
    }
}
