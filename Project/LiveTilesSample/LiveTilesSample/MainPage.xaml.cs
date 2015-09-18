using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LiveTilesSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void SetTileButton_Click(object sender, RoutedEventArgs e)
        {
            TileManager.UpdateLiveTile(this.liveTileContentText.Text);
        }
                
        //private void RegisterTaskButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.RegisterTask();
        //}

        ///// <summary>
        ///// Register the task for the application
        ///// </summary>
        //private async void RegisterTask()
        //{
        //    var taskRegistered = Windows.ApplicationModel.Background.BackgroundTaskRegistration.AllTasks.Select(task => task.Value.Name == nameof(TileUpdaterTask)).Count() > 0;
        //    if (taskRegistered)
        //    {
        //        this.ShowDialog("Tarefa já registrada!");
        //    }
        //    else
        //    {
        //        // Check if task is registred
        //        BackgroundAccessStatus allowed = await BackgroundExecutionManager.RequestAccessAsync();

        //        if (allowed == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity || allowed == BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity)
        //        {
        //            var task = new BackgroundTaskBuilder
        //            {
        //                Name = nameof(TileUpdaterTask),
        //                CancelOnConditionLoss = false,
        //                TaskEntryPoint = typeof(TileUpdaterTask).ToString(),
        //            };

        //            task.SetTrigger(new TimeTrigger(15, false));
        //            task.AddCondition(new SystemCondition(SystemConditionType.UserPresent));
        //            task.Register();

        //            this.ShowDialog("Tarefa registrada com sucesso!");
        //        }
        //        else
        //        {
        //            this.ShowDialog("Não foi possível registrar a tarefa!");                    
        //        }
        //    }
        //}

        //private async void ShowDialog(string content)
        //{
        //    MessageDialog dialog = new MessageDialog(content);
        //    await dialog.ShowAsync();
        //}
    }
}
