using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace AppBugaoMotoFVLE.Components.Models
{

    public class Produto
    {
        public int IdProduto { get; set; }
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }




    }
}