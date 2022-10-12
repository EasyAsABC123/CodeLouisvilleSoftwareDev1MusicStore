using MusicStore;
using MusicStore.Models;
using MusicStore.Services;

// See https://aka.ms/new-console-template for more information
/*
 * Music Store

- Track Sales
- Track Marketing Campaigns

- Keep Inventory
  - CRUD operations
  - Sell Inventory
  - Buy Inventory
  - Remove from inventory
  - Add from inventory
  	- Receive shipments
  - Items
	  - Instruments - 
	  - CDs - Artist, AlbumName, Price 
	  - Vinyl - Artist, AlbumName, Price
	  - Tapes - Artist, AlbumName, Price
*/

var fileName = "albums.json";

var albumInventorySvc = new AlbumInventoryService(fileName);

//albumInventorySvc.AddRange(new List<IAlbum>()
//{
//    new CD { Title = "Booker's Dream",  Artist = "Justin" },
//    new CD { Title = "Straight Outta The Highlands", Artist = "Brad" },
//    new CD { Title = "Barely Awake", Artist = "Michael" },
//    new Vinyl { Title = "Strange Daze",  Artist = "The Doors" },
//    new Vinyl { Title = "Best of the Best", Artist = "Frank Sinatra" },
//    new Vinyl { Title = "Kid A", Artist = "Radio Head" }
//});

Console.WriteLine("***Welcome to CL music store***");
Console.WriteLine("1. List Inventory");
Console.WriteLine("2. Add to Inventory");
Console.WriteLine("3. Update existing product");
Console.WriteLine("4. Remove from Inventory");
Console.WriteLine("5. Sell from Inventory");
Console.WriteLine("6. Exit");

var key = Console.ReadKey().KeyChar;

//Write a blank line. 
Console.WriteLine();

if (key == '1')
{
    Console.WriteLine("Inventory Contains:");
    albumInventorySvc.ListAlbums();
}
else if (key == '2')
{
    Console.WriteLine("What type of album would you like to add?");
    Console.WriteLine("1. CD");
    Console.WriteLine("2. Vinyl");
    Console.WriteLine("3. Cassette");
    var albumToAddInput = Console.ReadLine();

    Album albumToAdd = new Album(); 

    switch (albumToAddInput)
    {
        case "1":
            albumToAdd.Category = Category.CD;
            break;
        case "2":
            albumToAdd.Category = Category.Vinyl;
            break;
        case "3":
            albumToAdd.Category = Category.Cassette;
            break;
        default:
            throw new ArgumentException("USER DID NOT ENTER A VALID ALBUM TYPE TO ADD");
    }


    Console.WriteLine("Creating new CD.");
    Console.WriteLine("Title: ");
    var title = Console.ReadLine();

    albumToAdd.Title = title;

    Console.WriteLine("Artist: ");
    albumToAdd.Artist = Console.ReadLine();

    Console.WriteLine("Genre: ");
    albumToAdd.Genre = Console.ReadLine();

    Console.WriteLine("Price: ");
    var price = Console.ReadLine();
    try
    {
        albumToAdd.Price = decimal.Parse(price);
    }
    catch (Exception)
    {
        Console.WriteLine("Failed to include price - was not a valid decimal.");
    }

    Console.WriteLine("Year of release: ");
    var year = Console.ReadLine();
    try
    {
        albumToAdd.YearOfRelease = int.Parse(year);
    }
    catch (Exception)
    {
        Console.WriteLine("Failed to include year - was not a valid integer.");
    }

    albumInventorySvc.Add(albumToAdd);
    Console.WriteLine($"Added {albumToAdd.GetDetails()}");

    albumInventorySvc.Save();
}
else if (key == '3')
{
    Console.WriteLine("Choose CD to update: ");

    albumInventorySvc.ListAlbums();

    var selectedIdx = Console.ReadLine();

    int index;

    bool success = int.TryParse(selectedIdx, out index);

    if (success)
    {
        var selectedCD = albumInventorySvc.SelectAlbumByIndex(index);
        //Prompt user for updates


    }
}


Console.ReadLine();