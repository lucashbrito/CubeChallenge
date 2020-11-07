using System.Collections.Generic;
using System.Threading.Tasks;
using Cube.Domain.Aggregates.CubeAggregate;
using Cube.Serivce.Dto;
using Cube.Serivce.ViewModel;

namespace Cube.Serivce
{
    public class CubeServices : ICubeServices
    {
        public ReportDto GetReport(CubesViewModel cubesViewModel)
        {
            var cubeX = CreateCube(cubesViewModel.CubeX);

            var cubeY = CreateCube(cubesViewModel.CubeY);

            return new ReportDto
            {
                IsCollided = cubeX.CollidesWith(cubeY),
                IntersectionVolume = cubeX.IntersectionVolumeWith(cubeY)
            };
        }

        private static Domain.Aggregates.CubeAggregate.Cube CreateCube(CubeViewModel cubeViewModel)
        {
            return new Domain.Aggregates.CubeAggregate.Cube(
                new Point(cubeViewModel.Width, cubeViewModel.Height, cubeViewModel.Depth),
                cubeViewModel.Coordinates);
        }

        public async Task<List<ReportDto>> GetReportAsync(List<CubesViewModel> cubesViewModel)
        {
            var reportsDto = new List<ReportDto>();

            await Task.Run(() =>
            {
                foreach (var cube in cubesViewModel)
                {
                    var cubeX = CreateCube(cube.CubeX);

                    var cubeY = CreateCube(cube.CubeY);

                    var report = new ReportDto()
                    {
                        IsCollided = cubeX.CollidesWith(cubeY),
                        IntersectionVolume = cubeX.IntersectionVolumeWith(cubeY)
                    };

                    reportsDto.Add(report);
                }
            });

            return reportsDto;
        }
    }
}
