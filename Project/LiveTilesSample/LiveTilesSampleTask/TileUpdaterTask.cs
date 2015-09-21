using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace LiveTilesSampleTask
{
    public sealed class TileUpdaterTask : IBackgroundTask
    {
        // Tile xml content
        private static string w10TileXml = @"<tile>
                                <visual>
                                 <binding template=""TileSmall"">
                                  <text>MVA</text>
                                  <text>UW</text>
                                 </binding>
                                 <binding template=""TileMedium"">
                                  <image placement=""peek"" src=""Assets\Square150x150Logo.png"" />
                                  <image src=""Assets\Tile_w10_150x150.png"" />                                  
                                 </binding>
                                 <binding template=""TileWide"">                                  
                                  <group>
                                   <subgroup hint-weight=""33"">
                                    <image placement=""inline"" src=""Assets\Tile_w10_310x150.png"" />
                                   </subgroup>
                                   <subgroup>
                                    <text hint-style=""caption"" hint-wrap=""true"" hint-maxLines=""3"">
                                      MVA Live Tiles
                                    </text>
                                    <text hint-style=""captionsubtle"" hint-wrap=""true"" hint-maxLines=""3"">
                                      Background Tasks
                                    </text>
                                   </subgroup>
                                  </group>
                                 </binding>
                                 <binding template=""TileLarge"" hint-textStacking=""center"" branding=""name"">
                                  <group>
                                   <subgroup hint-weight=""1"" />
                                   <subgroup hint-weight=""2"">
                                    <image src=""Assets\Tile_w10_150x150.png"" hint-crop=""circle"" />
                                   </subgroup>
                                   <subgroup hint-weight=""1"" />
                                  </group>
                                  <text hint-style=""title"" hint-wrap=""true"" hint-maxLines=""3"" hint-align=""center"">
                                    Universal Windows
                                  </text>
                                  <text hint-style=""caption"" hint-wrap=""true"" hint-maxLines=""3"" hint-align=""center"">
                                    Background Task
                                  </text>
                                 </binding>
                                </visual>
                               </tile>";

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // Check the task cost
            var cost = BackgroundWorkCost.CurrentBackgroundWorkCost;
            if (cost == BackgroundWorkCostValue.High)
            {
                return;
            }

            // Get the cancel token
            var cancel = new System.Threading.CancellationTokenSource();
            taskInstance.Canceled += (s, e) =>
            {
                cancel.Cancel();
                cancel.Dispose();
            };

            // Get deferral
            var deferral = taskInstance.GetDeferral();
            try
            {
                // Update Tile with the new xml
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(TileUpdaterTask.w10TileXml);

                TileNotification tileNotification = new TileNotification(xmldoc);
                TileUpdater tileUpdator = TileUpdateManager.CreateTileUpdaterForApplication();
                tileUpdator.Update(tileNotification);
            }
            finally
            {
                deferral.Complete();
            }
        }
    }
}
