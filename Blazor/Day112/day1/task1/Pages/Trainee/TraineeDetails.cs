using Microsoft.AspNetCore.Components;
using SharedModel;

namespace task1.Pages.Trainee
{
    public partial class  TraineeDetails
    {
        [Parameter]
        public int Id { get; set; }

        public SharedModel.Trainee? card { get; set; }

        protected override async Task OnInitializedAsync()
        {
            card = LattieData.Trainees.FirstOrDefault(i => i.Id == Id);
            await base.OnInitializedAsync();
        }
    }
}
