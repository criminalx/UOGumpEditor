﻿using UOGumpEditor.UOElements;

namespace UOGumpEditor
{
    public partial class UOGumpEditorUI : Form
    {
        private ArtCache? _artCache;

        public UOGumpEditorUI()
        {
            InitializeComponent();

            UOEditorCore.SetMainHandle(this);

            KeyPreview = true;

            Text = $"{Text} - 1.0.0.0";
        }

        private void UOGumpEditorUI_Load(object sender, EventArgs e)
        {
            if (UOEditorCore.ArtLoader == null && !string.IsNullOrEmpty(UOSettings.Default.UO_Folder))
            {
                UOEditorCore.LoadArt();

                LoadArtAsync();
            }
            else
            {
                using FolderBrowserDialog dialog = new() { Description = "Select UO Folder!" };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    UOSettings.Default.UO_Folder = dialog.SelectedPath;

                    UOSettings.Default.Save();

                    UOEditorCore.LoadArt();

                    LoadArtAsync();
                }
            }
        }

        private async void LoadArtAsync()
        {
            SetMainDisplay(CanvasPanel);

            SetLoadingState(true);

            GumpInfoLabel.Text = "Loading Gump Assets ...";

            await UOArtLoader.LoadAllGumpArtAsync();

            UOProgressBar.Value = 50;

            GumpInfoLabel.Text = "Loading Art Assets ...";

            await UOArtLoader.LoadAllItemArtAsync();

            UOEditorCore.ReLoadArt();

            SetLoadingState(false);

            DisplayArt(UOArtLoader.GetArtEntity(0, IsGump()));

            UOEditorCore.ResetEditor();

            if (File.Exists(UOArtLoader.BGImageFile))
            {
                BackgroundImage = Image.FromFile(UOArtLoader.BGImageFile);
            }
        }

        private void SetLoadingState(bool isLoading)
        {
            NewButton.Enabled = !isLoading;
            SaveButton.Enabled = !isLoading;
            LoadButton.Enabled = !isLoading;
            ExportButton.Enabled = !isLoading;
            ModeButton.Enabled = !isLoading;
            SettingsButton.Enabled = !isLoading;
            ElementStrip.Enabled = !isLoading;
            GumpArtButton.Enabled = !isLoading;
            ItemArtButton.Enabled = !isLoading;
            AllArtButton.Enabled = !isLoading;
            ArtIDSearchBox.Enabled = !isLoading;
            ArtNameSearchBox.Enabled = !isLoading;
            ArtWidthSearchBox.Enabled = !isLoading;
            ArtHeightSearchBox.Enabled = !isLoading;

            UOProgressBar.Value = isLoading ? 10 : 100;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                SaveButton_Click(this, EventArgs.Empty);

                return true;
            }
            else if (keyData == (Keys.Control | Keys.O))
            {
                LoadButton_Click(this, EventArgs.Empty);

                return true;
            }

            if (CanvasPanel.Controls.Count > 0)
            {
                CanvasPanel.SuspendLayout();

                for (int i = 0; i < CanvasPanel.Controls.Count; i++)
                {
                    if (CanvasPanel.Controls[i] is ElementControl ec && ec.IsSelected)
                    {
                        UOEditorCore.SendMoveAction(keyData, ec);
                    }
                }

                CanvasPanel.ResumeLayout();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.ResetEditor();
        }

        private GumpHandler? _Handler;

        private void CheckHandler()
        {
            if (_Handler != null && _Handler.Visible)
            {
                _Handler.Close();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (CanvasPanel.Controls.Count > 0)
            {
                CheckHandler();

                _Handler = new(GumpActions.Save);

                _Handler.Show();
            }
            else
            {
                MessageBox.Show("Missing Gump!", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (CanvasPanel.Controls.Count > 0)
            {
                if (MessageBox.Show("Clearing Canvas, Proceed?", "Load Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return;
                }

                UOEditorCore.ResetEditor();
            }

            CheckHandler();

            _Handler = new(GumpActions.Load);

            _Handler.Show();
        }

        public ExportUI? _ExportUI { get; set; }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (CanvasPanel.Controls.Count > 0 && _ExportUI == null)
            {
                List<ElementControl> elementList = [];

                foreach (var element in CanvasPanel.Controls)
                {
                    if (element is ElementControl ec)
                    {
                        elementList.Add(ec);
                    }
                }

                ElementControl[] elements = [.. elementList];

                _ExportUI = new ExportUI(elements);

                _ExportUI.Show();
            }
            else
            {
                _ExportUI?.Close();
            }
        }

        private void ModeButton_Click(object sender, EventArgs e)
        {
            CanvasPanel.BackColor = CanvasPanel.BackColor == Color.Black ? Color.Transparent : Color.Black;
        }

        SettingsUI? _Settings;

        private void Settings_Click(object sender, EventArgs e)
        {
            // todo Profile settings

            if (_Settings != null && _Settings.Visible)
            {
                _Settings.Close();
            }

            _Settings = new();

            _Settings.Show();
        }

        private void EditorHelpButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.OpenWebsite("https://www.uoopenai.com/uo_gump_editor");
        }

        private bool IsGump()
        {
            return GumpArtButton.BackColor == Color.DodgerBlue;
        }

        private void GumpArtButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.SwapButtonOn(GumpArtButton, ItemArtButton);

            DisplayArt(UOArtLoader.GetArtEntity(0, IsGump()));
        }

        private void ItemArtButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.SwapButtonOn(ItemArtButton, GumpArtButton);

            DisplayArt(UOArtLoader.GetArtEntity(0, IsGump()));
        }

        private void ArtPicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            if (UOEditorCore.CurrentArtDisplayed != null)
            {
                UpdateElementInfo(UOEditorCore.CurrentArtDisplayed);
            }

            if (sender == ArtPicturebox)
            {
                if (e.Button == MouseButtons.Left && ArtPicturebox.Tag is ArtEntity entity)
                {
                    ArtPicturebox.DoDragDrop(entity, DragDropEffects.Copy);
                }
            }
        }

        private void AllArtButton_Click(object sender, EventArgs e)
        {
            if (UOArtLoader.GetAllArt(IsGump(), out List<ArtEntity> results))
            {
                _artCache = new ArtCache(results);

                DisplayArtWindow();
            }
            else
            {
                DisplayArt(UOArtLoader.GetArtEntity(0, IsGump()));
            }
        }

        private void ArtIDSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ArtIDSearchBox.Text) && ArtIDSearchBox.Text.Length < 6)
            {
                if (int.TryParse(ArtIDSearchBox.Text, out int val))
                {
                    if (UOArtLoader.SearchArtByID(val, IsGump(), out List<ArtEntity> results))
                    {
                        _artCache = new ArtCache(results);

                        DisplayArtWindow();
                    }
                }
            }
            else
            {
                DisplayArt(UOArtLoader.GetArtEntity(0, IsGump()));
            }
        }

        private void ArtNameSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ArtNameSearchBox.Text) && ArtNameSearchBox.Text.Length < 25)
            {
                if (UOArtLoader.SearchArtByName(ArtNameSearchBox.Text, IsGump(), out List<ArtEntity> results))
                {
                    _artCache = new ArtCache(results);

                    DisplayArtWindow();
                }
            }
            else
            {
                DisplayArt(UOArtLoader.GetArtEntity(0, IsGump()));
            }
        }

        private void ArtSizeSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (!string.IsNullOrEmpty(tb.Text) && tb.Text.Length < 6)
                {
                    if (int.TryParse(tb.Text, out int size) && size > 0)
                    {
                        if (UOArtLoader.SearchArtBySize(size, IsGump(), out List<ArtEntity> results, sender == ArtWidthSearchBox))
                        {
                            _artCache = new ArtCache(results);

                            DisplayArtWindow();
                        }
                    }
                }
                else
                {
                    DisplayArt(UOArtLoader.GetArtEntity(0, IsGump()));
                }
            }
        }

        private void ArtSearchBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender is TextBox box && box.Text.Length == 0)
            {
                ResetIDSearch();
            }
        }

        private void HistoryListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HistoryListbox.SelectedItem != null && HistoryListbox.SelectedItem is ArtEntity entity)
            {
                DisplayArt(entity);
            }
        }

        private void ClearHistoryButton_Click(object sender, EventArgs e)
        {
            HistoryListbox.Items.Clear();
        }

        private void DisplayArtWindow()
        {
            if (_artCache != null)
            {
                var results = _artCache.GetCurrentWindow(SearchFlowPanel);

                if (_artCache.CanScrollPrev())
                {
                    PreviousButton.Visible = true;
                }

                if (_artCache.CanScrollNext())
                {
                    NextButton.Visible = true;
                }

                DisplaySearchResults(results);

                SetMainDisplay(SearchPanel);
            }
        }

        private void SetMainDisplay(Panel panel)
        {
            CanvasPanel.Dock = DockStyle.None;

            SearchPanel.Dock = DockStyle.None;

            panel.Dock = DockStyle.Fill;

            FocusPanel.Visible = CanvasPanel.Dock == DockStyle.Fill;

            panel.BringToFront();
        }

        private void DisplaySearchResults(List<ArtEntity> results)
        {
            if (results.Count > 0)
            {
                SearchFlowPanel.Controls.Clear();

                Color color;

                Image? image;

                foreach (var entity in results)
                {
                    image = entity.GetImage();

                    if (results.Count > 0 && results[results.Count / 2] == entity)
                    {
                        color = Color.WhiteSmoke;
                    }
                    else
                    {
                        if (image == null)
                        {
                            color = Color.Red;
                        }
                        else
                        {
                            color = Color.Black;
                        }
                    }

                    SearchFlowPanel.Controls.Add(new ArtPictureBox(entity, image, color));

                    image = null;
                }

                SearchFlowPanel.Visible = true;
            }
        }

        public void DisplayArt(ArtEntity entity)
        {
            ResetIDSearch();

            UOEditorCore.SetImageRenderer(ArtPicturebox, entity);

            SetMainDisplay(CanvasPanel);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            PreviousButton.Visible = false;

            if (_artCache != null && _artCache.CanScrollPrev())
            {
                _artCache.ScrollPrev();

                DisplayArtWindow();
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            NextButton.Visible = false;

            if (_artCache != null && _artCache.CanScrollNext())
            {
                _artCache.ScrollNext();

                DisplayArtWindow();
            }
        }

        private void ResetIDSearch()
        {
            ArtIDSearchBox.Clear();

            ArtNameSearchBox.Clear();

            ArtWidthSearchBox.Clear();

            ArtHeightSearchBox.Clear();

            SearchFlowPanel.Visible = false;
        }

        private void LayerListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelected();

            if (LayerListbox.SelectedItems.Count > 0)
            {
                foreach (var item in LayerListbox.SelectedItems)
                {
                    if (item is ElementEntity entity)
                    {
                        entity.Element.SetSelected(true);
                    }
                }

                CanvasPanel.Invalidate();
            }
        }

        public void ClearSelected()
        {
            if (LayerListbox.Items.Count > 0)
            {
                for (int i = 0; i < LayerListbox.Items.Count; i++)
                {
                    if (LayerListbox.Items[i] is ElementEntity entity)
                    {
                        entity.Element.SetSelected(false);
                    }
                }
            }

            CanvasPanel.Invalidate();
        }

        private void ClearSelectedButton_Click(object sender, EventArgs e)
        {
            ClearSelected();
        }

        private void CanvasPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(typeof(ArtEntity)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void CanvasPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                if (e.Data.GetDataPresent(typeof(ArtEntity)))
                {
                    if (e.Data.GetData(typeof(ArtEntity)) is ArtEntity entity)
                    {
                        var dropLocation = CanvasPanel.PointToClient(new Point(e.X, e.Y));

                        ElementControl element = new()
                        {
                            Tag = entity
                        };

                        UOEditorCore.AddElement(element);

                        element.SetImage(entity);

                        if (IsGump())
                        {
                            UOEditorCore.InitGumpConditions(entity, element);
                        }
                        else
                        {
                            element.ElementType = ElementTypes.Item;
                        }

                        AddArtToCanvas(element, dropLocation);
                    }
                }
            }
        }

        private void AddLabelButton_Click(object sender, EventArgs e)
        {
            OpenTextEntry(ElementTypes.Label);
        }

        private void AddHTMLButton_Click(object sender, EventArgs e)
        {
            OpenTextEntry(ElementTypes.Html);
        }

        private UOImageEditor? editor;

        internal void OpenImageEditor(ElementTypes element, ElementControl imageElement)
        {
            if (editor != null && editor.Visible)
            {
                return;
            }

            if (imageElement != null)
            {
                editor = new(element, imageElement);
            }
            else
            {
                editor = new(element);
            }

            editor.Show();
        }

        private UOTextEntry? entry;

        public void OpenTextEntry(ElementTypes element, ElementControl? textElement = null)
        {
            if (entry != null && entry.Visible)
            {
                return;
            }

            if (textElement != null)
            {
                entry = new(element, textElement);
            }
            else
            {
                entry = new(element);
            }

            entry.Show();
        }

        public void AddTextElement(string text, Color hue)
        {
            ElementControl element = new()
            {
                ElementType = ElementTypes.Label
            };

            UOEditorCore.AddElement(element);

            element.SetText(text, hue);

            AddArtToCanvas(element, new(50, 50));
        }

        private void AddArtToCanvas(ElementControl element, Point location)
        {
            element.Location = new Point(location.X - (element.Width / 2), location.Y - (element.Height / 2));

            CanvasPanel.Controls.Add(element);

            UOEditorCore.ReorderZLayers();
        }

        public void RemoveFromCanvas(ElementControl element)
        {
            UOEditorCore.Z_Layer.Remove(element);

            if (CanvasPanel.Controls.Contains(element))
            {
                CanvasPanel.Controls.Remove(element);

                UpdateLayerList(element, false);

                UOEditorCore.ReorderZLayers();
            }
        }

        public void ReorderLayerList()
        {
            LayerListbox.Items.Clear();

            foreach (ElementControl element in UOEditorCore.Z_Layer)
            {
                UpdateLayerList(element, true);
            }

            LayerListbox.Invalidate();
        }

        private void UpdateLayerList(ElementControl element, bool add)
        {
            if (!add)
            {
                ElementEntity? entity = null;

                foreach (var item in LayerListbox.Items)
                {
                    if (item is ElementEntity ee && ee.Element == element)
                    {
                        entity = ee;

                        break;
                    }
                }

                if (entity != null)
                {
                    LayerListbox.Items.Remove(entity);
                }
            }
            else
            {
                LayerListbox.Items.Add(new ElementEntity(element));
            }

            LayerListbox.Invalidate();
        }

        public void AddToHistory(ArtEntity entity)
        {
            HistoryListbox.Items.Add(entity);

            HistoryListbox.Invalidate();
        }

        public void UpdateElementInfo(ArtEntity entity)
        {
            GumpInfoLabel.Text = $"{(entity.IsGump ? "Gump" : "Item")} {entity.ID} : [{entity.Name}] - width: {entity.Width} / hieght: {entity.Height}";
        }

        private void UOGumpEditorUI_Resize(object sender, EventArgs e)
        {
            if (SearchFlowPanel.Visible)
            {
                DisplayArtWindow();
            }
            else
            {
                SetMainDisplay(CanvasPanel);
            }
        }

        private void RaiseLayerButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.MoveLayerUp();
        }

        private void LowerLayerButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.MoveLayerDown();
        }
    }
}
