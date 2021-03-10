using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public IEnumerable<Municipio> Municipios { get; set; }

        public Estado(){}

        public Estado(int id, string nome, string sigla)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sigla = sigla;
        }
    }
}