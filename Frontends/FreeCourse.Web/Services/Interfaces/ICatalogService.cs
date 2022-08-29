using System.Collections.Generic;
using System.Threading.Tasks;
using FreeCourse.Web.Models.Inputs;
using FreeCourse.Web.Models.ViewModels.Catalogs;

namespace FreeCourse.Web.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<List<CourseViewModel>> GetAllCoursesAsync();
        Task<List<CategoryViewModel>> GetAllCategoriesAsync();
        Task<List<CourseViewModel>> GetAllCoursesByUserIdAsync(string userId);
        Task<List<CourseViewModel>> GetAllCoursesByCourseIdAsync(string courseId);
        Task<bool> DeleteCourseAsync(string courseId);
        Task<bool> CreateCourseAsync(CourseCreateInput courseCreateInput);
        Task<bool> UpdateCourseAsync(CourseUpdateInput courseUpdateInput );
    }
}