using SystemDuo.Core.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace SystemDuo.ViewModels
{
    public class TodoOverviewViewModel : BaseViewModel
    {
        private Todo _todo = new();
        //parameter is set when update is selected
        [Parameter] public Guid todoId { get; set; }

        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };

            await GetTaskById(todoId);
        }

        public async Task GetTaskById(Guid todoId)
        {
            var res = await ServiceManager!.TodoService.GetTodoByIdAsync(todoId);
            if (res != null)
            {
                _todo = res;
                StateHasChanged();
            }
        }

        public Todo Todo
        {
            get { return _todo; }
            set { SetValue(ref _todo, value); }
        }
    }
}
