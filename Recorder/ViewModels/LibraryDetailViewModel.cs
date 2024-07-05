using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

using Recorder.Contracts.ViewModels;
using Recorder.Core.Contracts.Services;
using Recorder.Core.Models;

namespace Recorder.ViewModels;

public partial class LibraryDetailViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    [ObservableProperty]
    private SampleOrder? item;


    [ObservableProperty]
    private SampleOrder? selected;


    public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

    public LibraryDetailViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is long orderID)
        {
            var data = await _sampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.OrderID == orderID);
        }

        SampleItems.Clear();

        // TODO: Replace with real data.
        var data1 = await _sampleDataService.GetListDetailsDataAsync();

        foreach (var item in data1)
        {
            SampleItems.Add(item);
        }
    }

    public void EnsureItemSelected()
    {
        Selected ??= SampleItems.First();
    }

    public void OnNavigatedFrom()
    {
    }
}
