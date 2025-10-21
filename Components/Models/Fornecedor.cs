using System.Globalization;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace AppBugaoMotoFVLE.Components.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Responsavel { get; set; }
        public string Telefone { get; set; }
        public string Complemento { get; set; }
        public string CNPJ { get; set; }
        public string Rua { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        
    }
}
