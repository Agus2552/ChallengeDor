namespace ChallengeDor.Models
{
    public class ServiceResponse<T>
    {
        public string Code { get; set; } = "999";
        public string Message { get; set; } = "Error inesperado";
        public T? Data { get; set; }
    }
}
