using d_itemDisplayGenerator.Sources.XMLParser;
using ItemDisplayInfoGenerator.Sources.Image;
using ItemDisplayInfoGenerator.Sources.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace ItemDisplayInfoGenerator
{
    public partial class Fmain : Form
    {
        protected ConcurrentDictionary<string, string> ItemDisplayInfo;
        protected ConcurrentDictionary<string, string> Item_Template;
        protected XMLLoader loader;

        public Fmain()
        {
            InitializeComponent();
        }

        private void Fmain_Load(object sender, EventArgs e)
        {
            loader = new XMLLoader();
        }
        // ============================ ItemDisplayInfo ============================ \\
        private void SearchModel(string DisplayID)
        {
            if (cbx_ParseXMLData.Checked)
            {
                ItemDisplayInfo = loader.loadItemDisplay(DisplayID);

                if (ItemDisplayInfo == null)
                    return;
                foreach (KeyValuePair<string, string> attribute in ItemDisplayInfo)
                {
                    switch (attribute.Key)
                    {
                        case "m_helmetGeosetVis": txtm_helmetGeosetVis.Text = attribute.Value; break;
                        case "m_groupSoundIndex": txtm_groupSoundIndex.Text = attribute.Value; break;
                        case "m_spellVisualID": txtm_spellVisualID.Text = attribute.Value; break;
                        case "m_inventoryIcon": txtm_inventoryIcon.Text = attribute.Value; break;
                        case "RightModelTexture": txtm_RightModelTexture.Text = attribute.Value; break;
                        case "HandsTexture": txtm_HandsTexture.Text = attribute.Value; break;
                        case "LowerArmTexture": txtm_LowerArmTexture.Text = attribute.Value; break;
                        case "LowerTorsoTexture": txtm_LowerTorsoTexture.Text = attribute.Value; break;
                        case "m_helmetGeosetVis_1": txtm_helmetGeosetVis_1.Text = attribute.Value; break;
                        // case "m_inventoryIcon_1": txtm_inventoryIcon_1.Text = attribute.Value; break; not used
                        case "UpperArmTexture": txtm_UpperArmTexture.Text = attribute.Value; break;
                        case "m_geosetGroup_1": txtm_geosetGroup_1.Text = attribute.Value; break;
                        case "m_geosetGroup_2": txtm_geosetGroup_2.Text = attribute.Value; break;
                        case "m_particleColorID": txtm_particleColorID.Text = attribute.Value; break;
                        case "LeftModel": txtm_LeftModel.Text = attribute.Value; break;
                        case "m_itemVisual": txtm_itemVisual.Text = attribute.Value; break;
                        case "m_flags": txtm_flags.Text = attribute.Value; break;
                        case "RightModel": txtm_RightModel.Text = attribute.Value; break;
                        case "UpperTorsoTexture": txtm_UpperTorsoTexture.Text = attribute.Value; break;
                        case "LeftModelTexture": txtm_LeftModelTexture.Text = attribute.Value; break;
                        case "m_geosetGroup": txtm_geosetGroup.Text = attribute.Value; break;
                        case "FootTexture": txtm_FootTexture.Text = attribute.Value; break;
                        case "UpperLegTexture": txtm_UpperLegTexture.Text = attribute.Value; break;
                        case "LowerLegTexture": txtm_LowerLegTexture.Text = attribute.Value; break;
                    }
                    // debug
                    //Console.WriteLine("Key = {0}, Value = {1}", attribute.Key, attribute.Value);
                    // Console.Write("String " + attribute.Key + ", ");
                }
            }
        }

        private void cbx_DisplayID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchModel(cbx_DisplayID.Text);
        }

        private void cbx_DisplayID_TextChanged(object sender, EventArgs e)
        {
            SearchModel(cbx_DisplayID.Text);
        }

        private void txtm_inventoryIcon_TextChanged(object sender, EventArgs e)
        {
            LoadImageFromUI.LoadIconFromWoWHead(pbx_Icon, txtm_inventoryIcon.Text.ToLower());
        }

        private void btnm_GenerateCSV_Click(object sender, EventArgs e)
        {
            GenerateModelData.GenerateModelCSV(cbx_DisplayID.Text, txtm_helmetGeosetVis.Text, txtm_groupSoundIndex.Text, txtm_LowerLegTexture.Text, txtm_spellVisualID.Text, txtm_inventoryIcon.Text, txtm_RightModelTexture.Text, txtm_HandsTexture.Text, txtm_LowerArmTexture.Text, txtm_LowerTorsoTexture.Text, txtm_helmetGeosetVis_1.Text, 
                txtm_UpperArmTexture.Text, txtm_geosetGroup_1.Text, txtm_geosetGroup_2.Text, txtm_particleColorID.Text, txtm_LeftModel.Text, txtm_itemVisual.Text, txtm_flags.Text, txtm_RightModel.Text, txtm_UpperTorsoTexture.Text, txtm_LeftModelTexture.Text, txtm_geosetGroup.Text, txtm_FootTexture.Text, txtm_UpperLegTexture.Text);
        }

        public static void ClearAll(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var texbox = c as TextBox;
                var comboBox = c as ComboBox;
                var dateTimePicker = c as DateTimePicker;

                if (texbox != null)
                    texbox.Clear();
                if (comboBox != null)
                    comboBox.SelectedIndex = -1;
                if (dateTimePicker != null)
                {
                    dateTimePicker.Format = DateTimePickerFormat.Short;
                    dateTimePicker.CustomFormat = " ";
                }
                if (c.HasChildren)
                    ClearAll(c);
            }
        }

        // ============================ Item Template ============================ \\

        private void ItemSearch(string ItemOrDisplayID)
        {
            ClearAll(this);
            if (cbx_ParseXMLData.Checked)
            {
                ItemDisplayInfo = loader.loadItemTemplateById(ItemOrDisplayID);
                cbx_DisplayID.Items.Clear();
                
                if (ItemDisplayInfo == null)
                    return;
                foreach (KeyValuePair<string, string> attribute in ItemDisplayInfo)
                {
                    switch (attribute.Key)
                    {
                        case "entry":
                            txt_ItemID.Text = attribute.Value;
                            break;
                        case "name":
                            txt_ItemName.Text = attribute.Value;
                            break;
                        case "DisplayID":
                            if (attribute.Value != "0")
                            { 
                                cbx_DisplayID.Items.Add(attribute.Value);
                                cbx_DisplayID.Text = attribute.Value;
                            }
                            break;
                        case "DisplayID_1":
                            if (attribute.Value != "0")
                                cbx_DisplayID.Items.Add(attribute.Value);
                            break;
                        case "DisplayID_2":
                            if (attribute.Value != "0")
                                cbx_DisplayID.Items.Add(attribute.Value);
                            break;
                        case "DisplayID_3":
                            if (attribute.Value != "0")
                                cbx_DisplayID.Items.Add(attribute.Value);
                            break;
                        case "DisplayID_4":
                            if (attribute.Value != "0")
                                cbx_DisplayID.Items.Add(attribute.Value);
                            break;
                        case "icon":
                            txtm_inventoryIcon.Text = attribute.Value;
                            break;
                        case "icon_2":
                                // if (attribute.Value != "")
                                    txtm_inventoryIcon.Text = attribute.Value;
                            break;
                        case "quality":
                            txt_ItemQuality.Text = attribute.Value;
                            break;
                        case "class":
                            txt_ItemClass.Text = Math.Abs(int.Parse(attribute.Value)).ToString();
                            break;
                        case "subclass":
                            txt_ItemSubClass.Text = Math.Abs(int.Parse(attribute.Value)).ToString();
                            break;
                        case "InventorySlot":
                            txt_ItemInventorySlot.Text = attribute.Value;
                            break;
                        case "Material":
                            txt_ItemMaterial.Text = attribute.Value;
                            break;
                        case "Sheath":
                            txt_ItemSheath.Text = attribute.Value;
                            break;
                        case "SoundOverrideSubclass":
                            txt_SoundOverride.Text = attribute.Value;
                            break;
                        case "level":
                            txt_ItemLevel.Text = attribute.Value;
                            break;
                    }
                    // Console.WriteLine("Key = {0}, Value = {1}", attribute.Key, attribute.Value);
                }
            }
        }
        private void btn_GenerateDisplayID_Click(object sender, EventArgs e)
        {
            ItemSearch(txt_ItemID.Text);
        }

        private void lbl_wowdevreference_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://wowdev.wiki/DB/ItemDisplayInfo");
        }
    }
}
