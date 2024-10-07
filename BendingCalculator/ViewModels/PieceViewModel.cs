using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using BendingCalculator.Views.Editors.Piece;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BendingCalculator.ViewModels;

public partial class MainViewModel
{
    #region Bindings

    private ListLayersEditor? _listLayersEditor;

    [ObservableProperty] private bool _uiEnabledPieceEditor;

    [ObservableProperty] private ObservableCollection<Piece> _pieces = new();

    private Piece? _selectedPiece;

    public Piece? SelectedPiece
    {
        get => _selectedPiece;
        set
        {
            SetProperty(ref _selectedPiece, value);
            SelectedPieceChanged();
        }
    }

    #endregion

    #region Piece Edition

    public void CreateNewPiece()
    {
        Piece piece = new(1, "new");
        DataBaseCreator.NewPiece(_connection, piece);
        SelectedPiece = Pieces[^1];
    }

    public void RemovePiece()
    {
        if (SelectedPiece == null) return;
        DataBaseRemover.RemovePiece(_connection, SelectedPiece.Id);
        SelectedPiece = null;
    }
    
    private void SelectedPieceChanged()
    {
        if (SelectedPiece == null)
        {
            UiEnabledPieceEditor = false;
            return;
        }

        UiEnabledPieceEditor = true;
        PropertyChanged += (_,e) => SelectedPiecePropertyChanged(e);
    }

    private void LoadPieces(object? sender, EventArgs eventArgs)
    {
        List<Piece> pieces = DataBaseLoader.LoadPieces(_connection);
        Pieces = new ObservableCollection<Piece>(pieces);
    }
    
    private void SelectedPiecePropertyChanged(PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(SelectedPiece.Name):
            case nameof(SelectedPiece.Length):
                if (SelectedPiece == null) return;
                DataBaseUpdater.UpdatePiece(_connection, SelectedPiece);
                break;
        }
    }

    #endregion

    #region LayerOfPieceEditor

    public void CloseLayerOfPieceEditor()
    {
        _listLayersEditor?.Close();
    }

    public void OpenLayerOfPieceEditor()
    {
        if (SelectedPiece is null) return;
        if (_listLayersEditor != null) return;
        _listLayersEditor = new ListLayersEditor(this);
        _listLayersEditor.Closing += (_, _) => UiEnabledPieceEditor = true;
        _listLayersEditor.Closed += (_, _) => _listLayersEditor = null;
        _listLayersEditor.Show();
        UiEnabledPieceEditor = false;
    }

    #endregion
}