namespace FreeCourse.Web.Models.ViewModels.Orders
{
    public class OrderCreatedViewModel
    {
        public int OrderId { get; set; }
        public string Error { get; set; }
        public bool IsSuccessful { get; set; }
    }
}