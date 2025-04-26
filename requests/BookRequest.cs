namespace Library.Request
{
    //public record BookRequest(
    //    int IdBook, int IdUser, int IdWriter, int IdChapter, string DataPost, decimal Price, string name
    //    );

    
        public record BookRequest(string Name, int idWriter, string dataPost, decimal price,int idChapter = 1);




}
