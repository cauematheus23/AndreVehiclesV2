using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CarJob
    {
        public readonly static string SELECT = "SELECT cs.Status,c.Placa,c.Nome,c.AnoModelo,c.AnoFabricacao,c.Cor,s.Id,s.Descricao from TB_CARROSERVICO cs inner join TB_CARRO c ON cs.PlacaCarro = c.Placa inner join TB_SERVICO s ON cs.IdServico = s.Id WHERE Status = 1;";
        public int Id { get; set; }
        public Car Car { get; set; }    
        public Job Job { get; set; }
        public bool Status { get; set; }
        public CarJob()
        {
        }
        public CarJob(CarJobDTO cjdto)
        {
            Car car = new Car { Plate = cjdto.CarPlate};
            Job job = new Job { Id = cjdto.JobId};
            this.Car = car;
            this.Job = job;
            this.Status = cjdto.Status;
        }

        public override string? ToString() => $"\n{Car}\nServiço {Job}\nStatus: {Status}";
    }
}
