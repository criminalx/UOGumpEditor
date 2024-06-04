﻿namespace UOGumpEditor
{
    partial class UOGumpEditorUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UOGumpEditorUI));
            BottomStatusStrip = new StatusStrip();
            ProgressBar = new ToolStripProgressBar();
            GumpInfoLabel = new ToolStripStatusLabel();
            ElementStrip = new ContextMenuStrip(components);
            AddLabelButton = new ToolStripMenuItem();
            AddTextBoxButton = new ToolStripMenuItem();
            AddHTMLButton = new ToolStripMenuItem();
            ArtPanel = new Panel();
            ClearHistoryButton = new Button();
            HistoryListbox = new ListBox();
            HistoryLabel = new Label();
            ArtSizeSearchBox = new TextBox();
            ArtNameSearchBox = new TextBox();
            ArtIDSearchBox = new TextBox();
            ArtPicturebox = new PictureBox();
            ArtSelectPanel = new Panel();
            ItemArtButton = new Button();
            GumpArtButton = new Button();
            SearchFlowPanel = new FlowLayoutPanel();
            toolStrip1 = new ToolStrip();
            NewButton = new ToolStripButton();
            SettingsButton = new ToolStripButton();
            LoadButton = new ToolStripButton();
            SaveButton = new ToolStripButton();
            ExportButton = new ToolStripButton();
            GetHelpButton = new ToolStripButton();
            BottomStatusStrip.SuspendLayout();
            ElementStrip.SuspendLayout();
            ArtPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ArtPicturebox).BeginInit();
            ArtSelectPanel.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BottomStatusStrip
            // 
            resources.ApplyResources(BottomStatusStrip, "BottomStatusStrip");
            BottomStatusStrip.GripMargin = new Padding(0);
            BottomStatusStrip.Items.AddRange(new ToolStripItem[] { ProgressBar, GumpInfoLabel });
            BottomStatusStrip.Name = "BottomStatusStrip";
            // 
            // ProgressBar
            // 
            ProgressBar.Name = "ProgressBar";
            resources.ApplyResources(ProgressBar, "ProgressBar");
            // 
            // GumpInfoLabel
            // 
            GumpInfoLabel.BackColor = SystemColors.Control;
            resources.ApplyResources(GumpInfoLabel, "GumpInfoLabel");
            GumpInfoLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;
            GumpInfoLabel.ForeColor = Color.FromArgb(32, 32, 32);
            GumpInfoLabel.LinkBehavior = LinkBehavior.NeverUnderline;
            GumpInfoLabel.Margin = new Padding(2, 3, 0, 2);
            GumpInfoLabel.Name = "GumpInfoLabel";
            // 
            // ElementStrip
            // 
            ElementStrip.BackColor = Color.DimGray;
            resources.ApplyResources(ElementStrip, "ElementStrip");
            ElementStrip.Items.AddRange(new ToolStripItem[] { AddLabelButton, AddTextBoxButton, AddHTMLButton });
            ElementStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            ElementStrip.Name = "ElementStrip";
            // 
            // AddLabelButton
            // 
            AddLabelButton.ForeColor = Color.WhiteSmoke;
            AddLabelButton.Name = "AddLabelButton";
            resources.ApplyResources(AddLabelButton, "AddLabelButton");
            // 
            // AddTextBoxButton
            // 
            AddTextBoxButton.ForeColor = Color.WhiteSmoke;
            AddTextBoxButton.Name = "AddTextBoxButton";
            resources.ApplyResources(AddTextBoxButton, "AddTextBoxButton");
            // 
            // AddHTMLButton
            // 
            AddHTMLButton.ForeColor = Color.WhiteSmoke;
            AddHTMLButton.Name = "AddHTMLButton";
            resources.ApplyResources(AddHTMLButton, "AddHTMLButton");
            // 
            // ArtPanel
            // 
            ArtPanel.BackColor = Color.FromArgb(64, 64, 64);
            ArtPanel.Controls.Add(ClearHistoryButton);
            ArtPanel.Controls.Add(HistoryListbox);
            ArtPanel.Controls.Add(HistoryLabel);
            ArtPanel.Controls.Add(ArtSizeSearchBox);
            ArtPanel.Controls.Add(ArtNameSearchBox);
            ArtPanel.Controls.Add(ArtIDSearchBox);
            ArtPanel.Controls.Add(ArtPicturebox);
            ArtPanel.Controls.Add(ArtSelectPanel);
            resources.ApplyResources(ArtPanel, "ArtPanel");
            ArtPanel.Name = "ArtPanel";
            // 
            // ClearHistoryButton
            // 
            ClearHistoryButton.BackColor = Color.Brown;
            resources.ApplyResources(ClearHistoryButton, "ClearHistoryButton");
            ClearHistoryButton.FlatAppearance.BorderSize = 0;
            ClearHistoryButton.Name = "ClearHistoryButton";
            ClearHistoryButton.UseVisualStyleBackColor = false;
            ClearHistoryButton.Click += ClearHistoryButton_Click;
            // 
            // HistoryListbox
            // 
            HistoryListbox.BackColor = Color.Gainsboro;
            HistoryListbox.BorderStyle = BorderStyle.None;
            resources.ApplyResources(HistoryListbox, "HistoryListbox");
            HistoryListbox.ForeColor = Color.Black;
            HistoryListbox.FormattingEnabled = true;
            HistoryListbox.Name = "HistoryListbox";
            HistoryListbox.SelectedIndexChanged += HistoryListbox_SelectedIndexChanged;
            // 
            // HistoryLabel
            // 
            resources.ApplyResources(HistoryLabel, "HistoryLabel");
            HistoryLabel.ForeColor = Color.Gold;
            HistoryLabel.Name = "HistoryLabel";
            // 
            // ArtSizeSearchBox
            // 
            ArtSizeSearchBox.BackColor = Color.Goldenrod;
            ArtSizeSearchBox.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(ArtSizeSearchBox, "ArtSizeSearchBox");
            ArtSizeSearchBox.ForeColor = Color.Black;
            ArtSizeSearchBox.Name = "ArtSizeSearchBox";
            ArtSizeSearchBox.TextChanged += ArtSizeSearchBox_TextChanged;
            // 
            // ArtNameSearchBox
            // 
            ArtNameSearchBox.BackColor = Color.Gold;
            ArtNameSearchBox.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(ArtNameSearchBox, "ArtNameSearchBox");
            ArtNameSearchBox.ForeColor = Color.Black;
            ArtNameSearchBox.Name = "ArtNameSearchBox";
            ArtNameSearchBox.TextChanged += ArtNameSearchBox_TextChanged;
            // 
            // ArtIDSearchBox
            // 
            ArtIDSearchBox.BackColor = Color.Khaki;
            ArtIDSearchBox.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(ArtIDSearchBox, "ArtIDSearchBox");
            ArtIDSearchBox.ForeColor = Color.Black;
            ArtIDSearchBox.Name = "ArtIDSearchBox";
            ArtIDSearchBox.TextChanged += ArtIDSearchBox_TextChanged;
            // 
            // ArtPicturebox
            // 
            ArtPicturebox.BackColor = Color.White;
            resources.ApplyResources(ArtPicturebox, "ArtPicturebox");
            ArtPicturebox.Name = "ArtPicturebox";
            ArtPicturebox.TabStop = false;
            // 
            // ArtSelectPanel
            // 
            ArtSelectPanel.Controls.Add(ItemArtButton);
            ArtSelectPanel.Controls.Add(GumpArtButton);
            resources.ApplyResources(ArtSelectPanel, "ArtSelectPanel");
            ArtSelectPanel.Name = "ArtSelectPanel";
            // 
            // ItemArtButton
            // 
            ItemArtButton.BackColor = Color.RoyalBlue;
            resources.ApplyResources(ItemArtButton, "ItemArtButton");
            ItemArtButton.FlatAppearance.BorderSize = 0;
            ItemArtButton.ForeColor = Color.Black;
            ItemArtButton.Name = "ItemArtButton";
            ItemArtButton.UseVisualStyleBackColor = false;
            ItemArtButton.Click += ItemArtButton_Click;
            // 
            // GumpArtButton
            // 
            GumpArtButton.BackColor = Color.DodgerBlue;
            resources.ApplyResources(GumpArtButton, "GumpArtButton");
            GumpArtButton.FlatAppearance.BorderSize = 0;
            GumpArtButton.ForeColor = Color.WhiteSmoke;
            GumpArtButton.Name = "GumpArtButton";
            GumpArtButton.UseVisualStyleBackColor = false;
            GumpArtButton.Click += GumpArtButton_Click;
            // 
            // SearchFlowPanel
            // 
            resources.ApplyResources(SearchFlowPanel, "SearchFlowPanel");
            SearchFlowPanel.Name = "SearchFlowPanel";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.WhiteSmoke;
            resources.ApplyResources(toolStrip1, "toolStrip1");
            toolStrip1.Items.AddRange(new ToolStripItem[] { NewButton, SaveButton, LoadButton, SettingsButton, GetHelpButton, ExportButton });
            toolStrip1.Name = "toolStrip1";
            // 
            // NewButton
            // 
            resources.ApplyResources(NewButton, "NewButton");
            NewButton.BackColor = Color.ForestGreen;
            NewButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            NewButton.Margin = new Padding(0, 2, 2, 2);
            NewButton.Name = "NewButton";
            NewButton.Click += NewButton_Click;
            // 
            // SettingsButton
            // 
            resources.ApplyResources(SettingsButton, "SettingsButton");
            SettingsButton.BackColor = Color.Goldenrod;
            SettingsButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SettingsButton.Margin = new Padding(0, 2, 0, 2);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Click += Settings_Click;
            // 
            // LoadButton
            // 
            resources.ApplyResources(LoadButton, "LoadButton");
            LoadButton.BackColor = Color.RoyalBlue;
            LoadButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            LoadButton.Margin = new Padding(0, 2, 2, 2);
            LoadButton.Name = "LoadButton";
            LoadButton.Click += LoadButton_Click;
            // 
            // SaveButton
            // 
            resources.ApplyResources(SaveButton, "SaveButton");
            SaveButton.BackColor = Color.SteelBlue;
            SaveButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SaveButton.Margin = new Padding(0, 2, 2, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Click += SaveButton_Click;
            // 
            // ExportButton
            // 
            ExportButton.Alignment = ToolStripItemAlignment.Right;
            resources.ApplyResources(ExportButton, "ExportButton");
            ExportButton.BackColor = Color.MediumPurple;
            ExportButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ExportButton.Margin = new Padding(0, 2, 1, 2);
            ExportButton.Name = "ExportButton";
            ExportButton.Click += ExportButton_Click;
            // 
            // GetHelpButton
            // 
            GetHelpButton.Alignment = ToolStripItemAlignment.Right;
            resources.ApplyResources(GetHelpButton, "GetHelpButton");
            GetHelpButton.BackColor = Color.Goldenrod;
            GetHelpButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            GetHelpButton.Margin = new Padding(1, 2, 5, 2);
            GetHelpButton.Name = "GetHelpButton";
            GetHelpButton.Click += EditorHelpButton_Click;
            // 
            // UOGumpEditorUI
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Black;
            ContextMenuStrip = ElementStrip;
            Controls.Add(SearchFlowPanel);
            Controls.Add(ArtPanel);
            Controls.Add(BottomStatusStrip);
            Controls.Add(toolStrip1);
            DoubleBuffered = true;
            ForeColor = Color.WhiteSmoke;
            Name = "UOGumpEditorUI";
            Load += UOGumpEditorUI_Load;
            BottomStatusStrip.ResumeLayout(false);
            BottomStatusStrip.PerformLayout();
            ElementStrip.ResumeLayout(false);
            ArtPanel.ResumeLayout(false);
            ArtPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ArtPicturebox).EndInit();
            ArtSelectPanel.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip BottomStatusStrip;
        private ToolStripStatusLabel GumpInfoLabel;
        private ToolStripProgressBar ProgressBar;
        private ContextMenuStrip ElementStrip;
        private ToolStripMenuItem AddLabelButton;
        private ToolStripMenuItem AddTextBoxButton;
        private ToolStripMenuItem AddHTMLButton;
        private Panel ArtPanel;
        private PictureBox ArtPicturebox;
        private TextBox ArtIDSearchBox;
        private ListBox HistoryListbox;
        private Label HistoryLabel;
        private Panel ArtSelectPanel;
        private Button ItemArtButton;
        private Button GumpArtButton;
        private Button ClearHistoryButton;
        private TextBox ArtSizeSearchBox;
        private TextBox ArtNameSearchBox;
        private FlowLayoutPanel SearchFlowPanel;
        private ToolStrip toolStrip1;
        private ToolStripButton NewButton;
        private ToolStripButton SaveButton;
        private ToolStripButton LoadButton;
        private ToolStripButton SettingsButton;
        private ToolStripButton GetHelpButton;
        private ToolStripButton ExportButton;
    }
}