using CommunityToolkit.Mvvm.ComponentModel;

namespace UnShellApp
{
    public partial class BasePageViewModel : ObservableObject
    {
        [ObservableProperty]
        bool _isBusy;

        [ObservableProperty]
        string _title;
    }
}
