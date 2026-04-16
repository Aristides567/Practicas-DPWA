namespace practica01.ViewsModels
{
    public class DashboardViewModel
    {
        public int totalStaff { get; set; }

        public int activeStaff { get; set; }

        public int inactiveStaff { get; set; }
    
        public Dictionary<string, int> staffByCategory { get; set; } = new Dictionary<string, int>();
    }
}
