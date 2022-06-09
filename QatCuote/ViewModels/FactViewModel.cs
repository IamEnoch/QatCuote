using CommunityToolkit.Mvvm.Input;
using QatCuote.Models;
using QatCuote.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QatCuote.ViewModels
{
    public partial class FactViewModel : BaseViewModel
    {
        public ObservableCollection<CatFact> Fact { get; } = new();
        CatService catService;

        public FactViewModel(CatService catService)
        {
            Title = "Cat Facts";
            this.catService = catService;
        }


        [ICommand]
        async Task GetFactAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                if (Fact.Count != 0)
                    Fact.Clear();

                var facts = await catService.GetFactAsync();                              

                Fact.Add(facts);


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error", $"An error has occured: {ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
