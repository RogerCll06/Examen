namespace Examen.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string NroPlaca { get; set; }

        //foreign key
        public int MarcaId { get; set; }
        public Marca? Marca { get; set; }

        //foreign key
        public int ModeloId { get; set; }
        public Modelo? Modelo { get; set; }

        public DateTime Año { get; set; }
        public string Color { get; set; }

    }
}
