﻿using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Interfaces.Models;
using ITBees.DragArtboard.Models;
using ITBees.Interfaces.Repository;

namespace ITBees.DragArtboard.Services;

class ArtboardUpdatingService : IArtboardUpdatingService
{
    private readonly IWriteOnlyRepository<Artboard> _artboardRwRepository;
    private readonly IDragArtboardUserManager _artboardUserManager;

    public ArtboardUpdatingService(IWriteOnlyRepository<Artboard> artboardRwRepository, IDragArtboardUserManager artboardUserManager)
    {
        _artboardRwRepository = artboardRwRepository;
        _artboardUserManager = artboardUserManager;
    }
    public ArtboardVm Update(ArtboardUm artboardUm)
    {
        //toto security
        var result = _artboardRwRepository.UpdateData(x => x.Guid == artboardUm.Guid, x =>
        {
            x.ArtboardName = artboardUm.ArtboardName;
            x.ArtboardType = artboardUm.ArtboardType;
            x.BackgroundImagePositionX = artboardUm.BackgroundImagePositionX;
            x.BackgroundImagePositionY= artboardUm.BackgroundImagePositionY;
            x.BackgroundImageUrl = artboardUm.BackgroundImageUrl;
            x.BackgroundImageZoom = artboardUm.BackgroundImageZoom;
            x.DragEnabled = artboardUm.DragEnabled;
            x.ControlButtonsVisible = artboardUm.ControlButtonsVisible;
            x.IsActive = artboardUm.IsActive;
            x.MeshEnabled  = artboardUm.MeshEnabled;
            x.Zoom = artboardUm.Zoom;
            x.ShowToolbox = artboardUm.ShowToolbox;
        }, x => x.CreatedBy, x => x.CreatedBy.Language);
        if (result.Any())
        {
            return new ArtboardVm(result.FirstOrDefault());
        }
        else
        {
            throw new Exception("Item not found");
        }
    }
}