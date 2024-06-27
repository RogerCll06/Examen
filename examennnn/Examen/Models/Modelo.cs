namespace Examen.Models
{
    public class Modelo
    {
        public int Id { get; set; }
        public string NombreModelo { get; set; }
        public int MarcaId { get; set; }
        public Marca? Marca { get; set; }
        public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
    }
}
