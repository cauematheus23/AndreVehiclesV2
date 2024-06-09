using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Job
    {
        public readonly static string INSERT = "INSERT INTO TB_SERVICO (Descricao) VALUES (@Descricao); select cast (scope_identity() as int)";
        public int Id { get; set; }
        public string Description { get; set; }

        public override string? ToString() => $"Id: {Id},\nDescrição: {Description}";
    }
}
