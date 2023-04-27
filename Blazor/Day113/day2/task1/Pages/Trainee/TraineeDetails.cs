using Microsoft.AspNetCore.Components;
using SharedModel;
using task1.Services;

namespace task1.Pages.Trainee
{
    public partial class  TraineeDetails
    {
        [Parameter]
        public int Id { get; set; }

        public SharedModel.Trainee? card { get; set; }
        [Inject]
        public ITrainee traineeDataService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            card = await traineeDataService.GetTraineeDetails(Id);
            await base.OnInitializedAsync();
        }
    }
}
