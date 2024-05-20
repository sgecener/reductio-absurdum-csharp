List<Product> products = new List<Product>()
{

    new Product()
    {
        Name = "Cloak",
        Price = 6.00M,
        Sold = false,
        ProductTypeId = 1

    },
    new Product()
    {
        Name = "Harry's Wand",
        Price = 5.00M,
        Sold = true,
        ProductTypeId = 4

    },
    new Product()
    {
        Name = "Flaming Sword",
        Price = 10.00M,
        Sold = false,
        ProductTypeId = 3
    },
    new Product()
    {
        Name = "Potion of Health",
        Price = 7.00M,
        Sold = true,
        ProductTypeId = 2
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

    }

}

void DisplayProducts()
{
    Console.WriteLine("All Products");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {ProductDetails(products[i])} {(products[i].Sold ? "was sold" : "is available")} for {products[i].Price} gold coins");
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
    newProduct.ProductTypeId = int.Parse(Console.ReadLine());
        if (newProduct.ProductTypeId < 1 || newProduct.ProductTypeId > 4 ) {
            Console.WriteLine("Please pick a valid product type");
        }
     

    newProduct.Sold = false;

    products.Add(newProduct);

    Console.WriteLine("Product added successfully!");

}

void FindByType() 
{
    Console.WriteLine("3works");

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
