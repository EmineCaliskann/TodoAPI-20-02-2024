namespace TodoAPI_20_02_2024.Dtos
{
    public class HavaDto
    {
        public DateOnly Tarih { get; set; }

        public int Sicaklik { get; set; } 

        public string Aciklama { get; set; } = null!;

    }
}
