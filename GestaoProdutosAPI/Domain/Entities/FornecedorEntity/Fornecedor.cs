namespace Domain.Entities.FornecedorEntity
{
    public partial class Fornecedor: BaseEntity
    {               
       public string Descricao { get; private set; } 
       public string CNPJ { get; private set; }

        public void SetDescricao(string value)
        {
            Descricao = value;
        }

        public void SetCNPJ(string value)
        {
            CNPJ = value;
        }
    }
}
