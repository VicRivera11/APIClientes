namespace APIClientes.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
    }

    public class CreaClienteDto
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
    }
}