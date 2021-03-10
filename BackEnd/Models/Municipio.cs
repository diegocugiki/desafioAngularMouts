using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Municipio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }

        [Required(AllowEmptyStrings=true)]
        public string Prefeito { get; set; }
        
        [Required(AllowEmptyStrings=true)]
        public int Populacao { get; set; }
        public Estado Estado { get; set; }
        public int EstadoId { get; set; }

        public Municipio() {}

        public Municipio(int id, string nome, string prefeito, int populacao, int estadoId)
        {
            this.Id = id;
            this.Nome = nome;
            this.Prefeito = prefeito;
            this.Populacao = populacao;
            this.EstadoId = estadoId;
        }
    }
}