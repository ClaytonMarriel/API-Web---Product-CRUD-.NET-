namespace ApiWeb.Mappings
{
    public class ProductResponse
    {
        private int id;
        private string name;
        private string description;
        private int quantityStock;
        private string barCode;
        private string mark;

        public ProductResponse(int id, string name, string description, int quantityStock, string barCode, string mark)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.quantityStock = quantityStock;
            this.barCode = barCode;
            this.mark = mark;
        }

        public object Id { get; internal set; }
    }
}