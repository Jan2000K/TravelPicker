﻿using TravelPickerApp.DAL.Entities;

namespace TravelPickerApp.Models.Location;

public class LocationVM
{
    public Guid Id { get; set; }
    public String LocationName { get; set; } = String.Empty;
    public Decimal Latitude { get; set; }
    public KeyValueVM Country { get; set; } = default!;
    public Decimal Longitude { get; set; } 
    public DateTimeOffset DateCreated { get; set; }

}