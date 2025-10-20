using CommunityToolkit.Mvvm.Input;
using YektamakMobil.Models;

namespace YektamakMobil.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}