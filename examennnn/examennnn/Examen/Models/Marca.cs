namespace Examen.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string NombreMarca { get; set; }

        public ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
        public ICollection<Vehiculo> vehiculos { get; set; } = new List<Vehiculo>();
    }
}
