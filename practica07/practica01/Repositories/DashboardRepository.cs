using practica01.Data;
using practica01.ViewsModels;

namespace practica01.Repositories
{
    public class DashboardRepository
    {
        private readonly ApplicationDbContext _context;

        public DashboardRepository(ApplicationDbContext _applicationDBContext)
        {
            _context = _applicationDBContext;
        }

        public DashboardViewModel getDashboardMetrics()
        {
            var model = new DashboardViewModel(); 

            model.totalStaff = _context.staffModel.Count();
            model.activeStaff = _context.staffModel.Count(s => s.IsActive);
            model.inactiveStaff = _context.staffModel.Count(s => !s.IsActive);

            var categoryStats = _context.staffModel
                .Where(s => s.StaffCategory != null)
                .GroupBy(s => s.StaffCategory.Name)
                .Select(g => new { CategoryName = g.Key, Count = g.Count() })
                .ToList();

            foreach (var stat in categoryStats)
            {
                model.staffByCategory.Add(stat.CategoryName, stat.Count);
            }

            return model;
        }
    }
}
