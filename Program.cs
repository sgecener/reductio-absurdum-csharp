List<Product> products = new List<Product>()
{

    new Product()
    {
        Name = "Cloak",
        Price = 6.00M,
        Sold = false,
        ProductTypeId = 1,
        DateStocked = new DateTime(2024, 2, 20)

    },
    new Product()
    {
        Name = "Harry's Wand",
        Price = 5.00M,
        Sold = true,
        ProductTypeId = 4,
        DateStocked = new DateTime(2024, 1, 20)


    },
    new Product()
    {
        Name = "Flaming Sword",
        Price = 10.00M,
        Sold = false,
        ProductTypeId = 3,
        DateStocked = new DateTime(2023, 12, 20)

    },
    new Product()
    {
        Name = "Potion of Health",
        Price = 7.00M,
        Sold = true,
        ProductTypeId = 2,
        DateStocked = new DateTime(2023, 11, 20)

    }
};

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Id = 1,
        Name = "Apparel"
    },
    new ProductType()
    {
        Id = 2,
        Name = "Potion"
    },
    new ProductType()
    {
        Id = 3,
        Name = "Enchanted Object"
    },
    new ProductType()
    {
        Id = 4,
        Name = "Wand"
    },
};


Console.WriteLine("Welcome to Reductio & Absurdum");
MainMenu();


void MainMenu()
{
    Console.WriteLine(@"Choose an option:
                        1. Display Products
                        2. Add a Product
                        3. Find Product By Type
                        4. Delete Product
                        5. Update Product Details
                        0. Exit
                        ");
                        
    

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "0":
            Console.Clear();
            Exit();
            break;
        case "1":
            Console.Clear();
            DisplayProducts();
            MainMenu();
            break;
        case "2":
            Console.Clear();
            AddProduct();
            MainMenu();
            break;
        case "3":
            Console.Clear();
            FindByType();
            MainMenu();
            break;
        case "4":
            Console.Clear();
            DeleteProduct();
            MainMenu();
            break;
        case "5":
            Console.Clear();
            UpdateProduct();
            MainMenu();
            break;

    }

}

void DisplayProducts()
{
    Console.WriteLine("All Products");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {ProductDetails(products[i])} has been on the shelf for {products[i].DaysOnShelf} days and {(products[i].Sold ? "was sold" : "is available")} for {products[i].Price} gold coins");
    }
}

void AddProduct() 
{
    Console.WriteLine("Add Product:\n");

    Product newProduct = new Product();

    Console.WriteLine("Enter the product name:\n");
    newProduct.Name = Console.ReadLine();


    Console.WriteLine("Enter an asking price:\n");
    newProduct.Price = decimal.Parse(Console.ReadLine());


    Console.WriteLine(@"Choose the type for the product:
                            1. Apparel
                            2. Potion
                            3. Enchanted Object
                            4. Wand
    ");

    int productTypeId;
    while (true)
    {
        Console.WriteLine("Pick a valid type:\n");
        if (int.TryParse(Console.ReadLine(), out productTypeId) && productTypeId >= 1 && productTypeId <= 4)
        {
            newProduct.ProductTypeId = productTypeId;
            break; // Exit the loop if input is valid
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
        }
    }
        

     Console.WriteLine("Product added successfully!");
        
    

    newProduct.Sold = false;

    products.Add(newProduct);


}

void DeleteProduct()
{
     for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {ProductDetails(products[i])}");
    }

        Console.WriteLine("Choose a product to delete:");
        try {
            int response = int.Parse(Console.ReadLine().Trim());

            products.RemoveAt(response - 1);
        }
        catch (FormatException)
        {
        Console.WriteLine("Please type number matching the item!");
        }
        catch (ArgumentOutOfRangeException)
        {
        Console.WriteLine("Please choose an existing item only!");
        }

        Console.WriteLine("Deleted successfully!");
    
}

void UpdateProduct() 
{
    Console.WriteLine("Update Product:");

    // Display all products
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {ProductDetails(products[i])} {(products[i].Sold ? "was sold" : "is available")} for {products[i].Price} gold coins");
    }

    Console.WriteLine("Choose a product to update:");
    int productIndex;
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out productIndex) && productIndex >= 1 && productIndex <= products.Count)
        {
            break; // Exit the loop if input is valid
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number corresponding to a product.");
        }
    }

    Product selectedProduct = products[productIndex - 1];

    Console.WriteLine("Enter a new name for the product (or leave blank to keep the current name):");
    string newName = Console.ReadLine();
    if (!string.IsNullOrEmpty(newName))
    {
        selectedProduct.Name = newName;
    }

    Console.WriteLine("Enter a new price for the product (or leave blank to keep the current price):");
    string newPriceInput = Console.ReadLine();
    if (!string.IsNullOrEmpty(newPriceInput))
    {
        decimal newPrice;
        if (decimal.TryParse(newPriceInput, out newPrice))
        {
            selectedProduct.Price = newPrice;
        }
        else
        {
            Console.WriteLine("Invalid price input. Price remains unchanged.");
        }
    }

    Console.WriteLine("Change the product type? (y/n)");
    if (Console.ReadLine().ToLower() == "y")
    {
        Console.WriteLine(@"Choose the new type for the product:
                            1. Apparel
                            2. Potion
                            3. Enchanted Object
                            4. Wand
        ");

        int newProductTypeId;
        while (true)
        {
            Console.WriteLine("Pick a valid type:");
            if (int.TryParse(Console.ReadLine(), out newProductTypeId) && newProductTypeId >= 1 && newProductTypeId <= 4)
            {
                selectedProduct.ProductTypeId = newProductTypeId;
                break; // Exit the loop if input is valid
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        }
    }

    Console.WriteLine($"Current availability: {(selectedProduct.Sold ? "Sold" : "Available")}");
    Console.WriteLine("Update availability? (y/n)");
    if (Console.ReadLine().ToLower() == "y")
    {
        Console.WriteLine("Set as sold? (y/n)");
        selectedProduct.Sold = Console.ReadLine().ToLower() == "y";
    }

    Console.WriteLine("Product updated successfully!");

}

void FindByType() 
{
    
    Console.WriteLine("Find Products by Type:");
    Console.WriteLine("Choose a product type:");

    // Display available product types
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
    }

    int typeIndex;
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out typeIndex) && typeIndex >= 1 && typeIndex <= productTypes.Count)
        {
            break; // Exit the loop if input is valid
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number corresponding to a product type.");
        }
    }

    int selectedTypeId = productTypes[typeIndex - 1].Id;

    Console.WriteLine($"Products of type '{productTypes[typeIndex - 1].Name}':");

    bool foundProducts = false;
    foreach (var product in products)
    {
        if (product.ProductTypeId == selectedTypeId)
        {
            Console.WriteLine($"{ProductDetails(product)} {(product.Sold ? "was sold" : "is available")} for {product.Price} gold coins");
            foundProducts = true;
        }
    }

    if (!foundProducts)
    {
        Console.WriteLine("No products found for the selected type.");
    }

}

void Exit() {
    Console.WriteLine("Goodbye!");
}

void InvalidOption() {
    Console.WriteLine("That doesn't exist.. try again!");
}

string ProductDetails(Product product)
{
    string productString = product.Name;

    return productString;

}
