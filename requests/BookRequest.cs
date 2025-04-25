namespace Library.Request
{
    //public record BookRequest(
    //    int IdBook, int IdUser, int IdWriter, int IdChapter, string DataPost, decimal Price, string name
    //    );

    public class BookRequest ()
    {
      

        public int IdWriter { get; set; }

   

        public string DataPost { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }
    }



}
