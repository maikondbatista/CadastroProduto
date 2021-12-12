namespace Categories.Domain.Utils.Messages
{
    public static class Messages
    {
        public static string Mandatory(string field) { return $"O Campo {field} é obrigatório(a)."; }
        public static string MaximumCharacters(string nomeCampo, int qtdCaracteres) { return $"O Campo {nomeCampo} deve ter no máximo {qtdCaracteres}."; }

        public static string BiggerThanZero(string nomeCampo) { return $"O Campo {nomeCampo} deve ser maior que zero."; }



        #region Erros Notificação
        public static string ErrorDeletingByCategory = "Erro ao excluir produtos associados à categoria";
        public static string ErroDeletingCategoryById = "Erro ao excluir por id";
        public static string ErrorUpdatingCategory = "Erro ao alterar categoria";
        public static string ErrorInsertingCategory = "Erro ao inserir categoria";
        public static string ErrorFindingById = "Erro ao buscar categoria por id";
        public static string ErrorGetAllCategories = "Erro aoa buscar as categorias";

        #endregion
    }
}
