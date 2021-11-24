using Domain.Model.Base;

namespace Domain.Model
{
    public class Car : Document
    {
        public string Cor { get; set; }

        public int Portas { get; set; }
    }
}
