using LinkBuildingTool.Core.Domain.Entities;
using LinkBuildingTool.Helpers;
using System.Collections.ObjectModel;
using System.Configuration;
using LinkBuildingTool.Core.Services;
using Mapster;
using System;
using MudBlazor;

namespace LinkBuildingTool.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private ObservableCollection<Todo> _todos = new();
        private ObservableCollection<Todo> _links = new();
        private Status _status = new();
        private ObservableCollection<Status> _statuses = new();
        private Status _selectedStatus = new();

        public string color = "black";
        public string bold = "normal";


        protected override async Task OnInitializedAsync()
        {
            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };

            await GetAllTodos();
            await GetAllLinks();
            await GetAllStatuses();
        }

        public async Task GetAllTodos()
        {
            var todo = await ServiceManager!.TodoService.GetAllWTodosAsync();
            if (todo != null)
                _todos = new ObservableCollection<Todo>(todo.Where(x => x.IsFinished != true));
        }

        public async Task GetAllLinks()
        {
            var links = await ServiceManager!.TodoService.GetAllWTodosAsync();
            if (links != null)
                _links = new ObservableCollection<Todo>(links.Where(x => x.IsFinished == true));
        }

        public async Task GetAllStatuses()
        {
            var st = await ServiceManager!.StatusService.GetAllStatusesAsync();
            if (st != null)
                _statuses = new ObservableCollection<Status>(st);
        }

        public async Task ChangeStatus(Todo todo)
        {
            var res = await ServiceManager!.TodoService.UpdateTodo(todo);
            if (res)
            {
                Snackbar!.Add("Successfully updated", Severity.Success);
            }
        }
        public async Task ApproveStatus(Todo todo)
        {
            switch (todo.StatusGroup)
            {
                case 1: todo.StatusGroup = 2; todo.Status = Statuses.Where(x => x.Name == "1. Kontakt").FirstOrDefault(); break;
                case 2: todo.StatusGroup = 3; todo.Status = Statuses.Where(x => x.Name == "Zusage").FirstOrDefault(); break;
            }
            if(todo.Status.Name.ToLower()  == "live")
            {
                todo.IsFinished = true;
                await GetAllTodos();
                await GetAllStatuses();
            }
            var res = await ServiceManager!.TodoService.UpdateTodo(todo);
            if (res)
            {
                Snackbar!.Add("Successfully updated", Severity.Success);
            }
        }

        public async Task ApprovePrice(Todo todo)
        {
            if (todo.ApprovePrice == false)
            {
                todo.ApprovePrice = true;
            }
            else
            {
                todo.ApprovePrice = false;
            } 

            var res = await ServiceManager!.TodoService.UpdateTodo(todo);
            if (res)
            {
                Snackbar!.Add("Successfully updated", Severity.Success);
            }
        }

        public void NavigateToTaskOverviewPage(Guid id)
        {
            NavigationManager!.NavigateTo("/todos/overview/" + id, false);
        }

        public void NavigateToCreateTaskPage()
        {
            NavigationManager!.NavigateTo("/task/create", false);
        }
        public void NavigateToTaskEditPage(Guid id)
        {
            NavigationManager!.NavigateTo("/task/update/" + id, false);
        }
        public ObservableCollection<Todo> Todos
        {
            get { return _todos; }
            set { SetValue(ref _todos, value); }
        }
        public ObservableCollection<Todo> Links
        {
            get { return _links; }
            set { SetValue(ref _links, value); }
        }
        public Status TodoStatus
        {
            get { return _status; }
            set { SetValue(ref _status, value); }
        }
        public ObservableCollection<Status> Statuses
        {
            get { return _statuses; }
            set { SetValue(ref _statuses, value); }
        }
        public Status SelectedStatus
        {
            get { return _selectedStatus; }
            set { SetValue(ref _selectedStatus, value); }
        }
    }
}
