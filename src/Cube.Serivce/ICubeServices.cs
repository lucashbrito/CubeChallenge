using System.Collections.Generic;
using System.Threading.Tasks;
using Cube.Serivce.Dto;
using Cube.Serivce.ViewModel;

namespace Cube.Serivce
{
    public interface ICubeServices
    {
        ReportDto GetReport(CubesViewModel cubesViewModel);

        Task<List<ReportDto>> GetReportAsync(List<CubesViewModel> cubesViewModel);
    }
}
