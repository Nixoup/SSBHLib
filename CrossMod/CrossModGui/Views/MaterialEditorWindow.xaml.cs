﻿using CrossMod.Rendering;
using CrossModGui.Tools;
using CrossModGui.ViewModels;
using CrossModGui.ViewModels.MaterialEditor;
using System.Diagnostics;
using System.Windows;

namespace CrossModGui.Views
{
    /// <summary>
    /// Interaction logic for MaterialEditorWindow.xaml
    /// </summary>
    public partial class MaterialEditorWindow : Window
    {
        private readonly MaterialEditorWindowViewModel viewModel;

        private RenderSettings.RenderMode previousRenderMode;

        public MaterialEditorWindow(MaterialEditorWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
            DataContext = this.viewModel;
            InitializeComponent();
        }

        private void ExportMatl_Click(object sender, RoutedEventArgs e)
        {
            if (FileTools.TryOpenSaveFileDialog(out string fileName, "Ultimate Material (*.numatb)|*.numatb*", "model.numatb"))
                viewModel.SaveMatl(fileName);
        }

        private void ExportMatlXml_Click(object sender, RoutedEventArgs e)
        {
            if (FileTools.TryOpenSaveFileDialog(out string fileName, "XML Document (*.xml)|*.xml*"))
                viewModel.ExportMatlToXml(fileName);
        }

        private void MaterialReference_Click(object sender, RoutedEventArgs e)
        {
            var info = new ProcessStartInfo
            {
                FileName = "https://github.com/ScanMountGoat/Smush-Material-Research/blob/master/Material%20Parameters.md",
                UseShellExecute = true
            };
            Process.Start(info);
        }

        private void ComboBox_DropDownOpened(object sender, System.EventArgs e)
        {
            // Display material ID while selecting a material.
            previousRenderMode = RenderSettings.Instance.ShadingMode;
            RenderSettings.Instance.ShadingMode = RenderSettings.RenderMode.MaterialID;
            viewModel.OnRenderFrameNeeded();
        }

        private void ComboBox_DropDownClosed(object sender, System.EventArgs e)
        {
            // Restore the original shading mode after making a selection.
            RenderSettings.Instance.ShadingMode = previousRenderMode;
            viewModel.OnRenderFrameNeeded();
        }

        private void SelectPreset_Click(object sender, RoutedEventArgs e)
        {
            var vm = new MaterialPresetWindowViewModel();
            vm.PresetApplying += (s, e) => (DataContext as MaterialEditorWindowViewModel)?.ApplyPreset(e);

            var window = new MaterialPresetWindow() { DataContext = vm };
            window.Show();
        }
    }
}
