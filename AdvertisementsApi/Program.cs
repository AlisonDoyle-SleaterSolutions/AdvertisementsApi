using AdvertisementsApi.classes;
using Microsoft.EntityFrameworkCore;

// Create app
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AdvertismentDb>(opt => opt.UseInMemoryDatabase("AdvertismentDB"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

// Routes
// Ads
app.MapPost("/ad", async (Ad ad, AdvertismentDb db) =>
{
    db.Ads.Add(ad);
    await db.SaveChangesAsync();

    return Results.Created($"/ad/{ad.Id}", ad);
});

app.MapGet("/ad", async (AdvertismentDb db) =>
    await db.Ads.ToListAsync());

app.MapGet("/ad/{id}", async (int id, AdvertismentDb db) =>
    await db.Ads.FindAsync(id)
        is Ad ad
            ? Results.Ok(ad)
            : Results.NotFound());

app.MapPut("/ad/{id}", async (int id, Ad updatedAdDetails, AdvertismentDb db) =>
{
    var ad = await db.Ads.FindAsync(id);

    if (ad is null) return Results.NotFound();

    ad.Title = updatedAdDetails.Title;
    ad.Description = updatedAdDetails.Description;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/ad/{id}", async (int id, AdvertismentDb db) =>
{
    if (await db.Ads.FindAsync(id) is Ad ad)
    {
        db.Ads.Remove(ad);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

// Sellers
app.MapPost("/seller", async (Seller seller, AdvertismentDb db) =>
{
    db.Sellers.Add(seller);
    await db.SaveChangesAsync();

    return Results.Created($"/seller/{seller.Id}", seller);
});

app.MapGet("/seller", async (AdvertismentDb db) =>
    await db.Sellers.ToListAsync());

app.MapGet("/seller/{id}/ads", async (int id, AdvertismentDb db) =>
    await db.Ads.FindAsync(id)
        is Ad ad
            ? Results.Ok(ad)
            : Results.NotFound());

// Start api
app.Run();