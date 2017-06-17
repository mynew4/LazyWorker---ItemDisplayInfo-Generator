using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDisplayInfoGenerator.Sources.Model
{
    class GenerateModelData
    {
        public static void GenerateModelCSV(string m_ID, string m_helmetGeosetVis, string m_groupSoundIndex, string LowerLegTexture, 
            string m_spellVisualID, string m_inventoryIcon, string RightModelTexture, string HandsTexture, string LowerArmTexture, 
            string LowerTorsoTexture, string m_helmetGeosetVis_1, string UpperArmTexture, 
            string m_geosetGroup_1, string m_geosetGroup_2, string m_particleColorID, string LeftModel, string m_itemVisual, 
            string m_flags, string RightModel, string UpperTorsoTexture, string LeftModelTexture, string m_geosetGroup, string FootTexture, string UpperLegTexture)
        {
            StringBuilder ItemDisplayInfo = new StringBuilder();
            string Sep = ",";
            string DQ = "\"";

            ItemDisplayInfo.AppendLine(m_ID + Sep + DQ + LeftModel + DQ + Sep + DQ + RightModel + DQ + Sep + DQ + LeftModelTexture + DQ + Sep + DQ + RightModelTexture + DQ +
                Sep + DQ + m_inventoryIcon + DQ + Sep + "\"\"" + Sep + m_geosetGroup + Sep + m_geosetGroup + Sep + m_geosetGroup_1 + Sep + m_geosetGroup_2 + Sep +
                m_flags + Sep + m_spellVisualID + Sep + m_groupSoundIndex + Sep + m_helmetGeosetVis + Sep + m_helmetGeosetVis_1 + Sep + DQ +
                UpperArmTexture + DQ + Sep + DQ + LowerArmTexture + DQ + Sep + DQ + HandsTexture + DQ + Sep + DQ + UpperTorsoTexture + DQ + Sep + DQ + LowerTorsoTexture + DQ + Sep + DQ +
                UpperLegTexture + DQ + Sep + DQ + LowerLegTexture + DQ + Sep + DQ + FootTexture + DQ + Sep + m_itemVisual + Sep + m_particleColorID);

            if (!Directory.Exists("./DBC"))
                Directory.CreateDirectory("./DBC");

            File.AppendAllText("./DBC/ItemDisplayInfo.dbc.csv", ItemDisplayInfo.ToString());
        }
    }
}
