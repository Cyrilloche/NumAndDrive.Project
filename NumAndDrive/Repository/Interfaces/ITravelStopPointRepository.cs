﻿using NumAndDrive.Models;

public interface ITravelStopPointRepository
{
    Task<TravelStopPoint?> GetTravelStopPointByIdAsync(int id);
    Task<IEnumerable<TravelStopPoint>> GetAllTravelStopPointsAsync();
    Task<TravelStopPoint> CreateTravelStopPointAsync(TravelStopPoint newTravelStopPoint);
    Task UpdateTravelStopPointAsync(TravelStopPoint updatedTravelStopPoint);
    Task DeleteTravelStopPointAsync(int id);
}
