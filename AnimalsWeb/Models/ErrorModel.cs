namespace AnimalsWeb.Models
{
    public class ErrorModel
    {
        public string? Requested {  get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(Requested);
    }
}
