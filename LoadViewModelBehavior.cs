using CommunityToolkit.Mvvm.Input;

namespace UnShellApp
{
    public interface INeedToBeLoaded
    {
        IRelayCommand LoadCommand { get; }
    }

    public interface INeedToBeLoadedAsync
    {
        IAsyncRelayCommand LoadCommand { get; }
    }

    public class LoadViewModelBehavior : Behavior<Page>
    {
        protected override void OnAttachedTo(Page target)
        {
            target.Appearing += Target_Appearing;

            base.OnAttachedTo(target);
        }
        protected override void OnDetachingFrom(Page target)
        {
            target.Appearing -= Target_Appearing;

            base.OnDetachingFrom(target);
        }

        private void Target_Appearing(object sender, EventArgs e)
        {
            var target = sender as Page;

            if (target?.BindingContext is INeedToBeLoaded viewModel)
            {
                viewModel.LoadCommand.Execute(null);
            }

            if (target?.BindingContext is INeedToBeLoadedAsync viewModel2)
            {
                viewModel2.LoadCommand.Execute(null);
            }
        }
    }
}
