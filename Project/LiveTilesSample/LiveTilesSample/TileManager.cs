using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace LiveTilesSample
{
    class TileManager
    {
        public static void UpdateLiveTile(string content)
        {

            //string tileXml = @"<tile>
            //                    <visual>
            //                     <binding template=""TileSmall"">
            //                      <text>Small</text>
            //                     </binding>
            //                     <binding template=""TileMedium"">
            //                      <text>Medium</text>
            //                     </binding>
            //                     <binding template=""TileWide"">
            //                      <text>Wide</text>
            //                     </binding>
            //                     <binding template=""TileLarge"">
            //                      <text>Large</text>
            //                     </binding>
            //                    </visual>
            //                   </tile>";

            string tileXml = string.Format(@"<tile>
                                <visual>
                                 <binding template=""TileSmall"">
                                  <text>Small</text>
                                 </binding>

                                 <binding template=""TileMedium"" branding=""name"">
                                  <image placement=""peek"" src=""Assets\Tile150x150.png"" />
                                  <text hint-wrap=""true"" hint-maxLines=""3"">{0}</text>
                                 </binding>

                                 <binding template=""TileWide"">                                  
                                  <group>
                                   <subgroup hint-weight=""33"">
                                    <image placement=""inline"" src=""Assets\Tile150x150Transparent.png"" />
                                   </subgroup>
                                   <subgroup>
                                    <text hint-style=""caption"" hint-wrap=""true"" hint-maxLines=""3"">
                                      MVA Live Tiles
                                    </text>
                                    <text hint-style=""captionsubtle"" hint-wrap=""true"" hint-maxLines=""3"">
                                      {1}
                                    </text>
                                   </subgroup>
                                  </group>
                                 </binding>

                                 <binding template=""TileLarge"" hint-textStacking=""center"" branding=""name"">
                                  <group>
                                   <subgroup hint-weight=""1"" />
                                   <subgroup hint-weight=""2"">
                                    <image src=""Assets\Tile150x150White.png"" hint-crop=""circle"" />
                                   </subgroup>
                                   <subgroup hint-weight=""1"" />
                                  </group>
                                  <text hint-style=""title"" hint-wrap=""true"" hint-maxLines=""3"" hint-align=""center"">
                                    MVA Live Tiles
                                  </text>
                                  <text hint-style=""caption"" hint-wrap=""true"" hint-maxLines=""3"" hint-align=""center"">
                                    {2}
                                  </text>
                                 </binding>
                                </visual>
                               </tile>", content, content, content);

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(tileXml);
            
            TileNotification tileNotification = new TileNotification(xmldoc);
            TileUpdater tileUpdator = TileUpdateManager.CreateTileUpdaterForApplication();

            tileUpdator.Update(tileNotification);           
        }
    }
}
