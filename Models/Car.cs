using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Car
    {
        [Key]
        public string Plate { get; set; }
        public string Name{ get; set; }
        public int ModelYear { get; set; }
        public int FabricationYear { get; set; }
        public string Color { get; set; }
        public bool Sold {  get; set; }
        public override string? ToString() => $"Placa: {Plate},\nNome: {Name},\nAno Modelo: {ModelYear},\nAno Fabricação: {FabricationYear},\nCor: {Color}";
    }
}
