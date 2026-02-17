using System;

namespace BookStoreApplication
{
    public class BookUtility
    {
        private Book _book;

        public BookUtility(Book book)
        {
            // TODO: Assign book object
            // _book.Id=book.Id;
            // _book.Title=book.Title;
            // _book.Author=book.Author;
            // _book.Price=book.Price;
            // _book.Stock=book.Stock;
            _book=book;
        }

        public void GetBookDetails()
        {
            // TODO:
            // Print format:
            // Details: <BookId> <Title> <Price> <Stock>
            Console.WriteLine("Details: "+_book.Id+" "+_book.Title+" "+_book.Price+" "+_book.Stock);
        }

        public void UpdateBookPrice(int newPrice)
        {
            // TODO:
            // Validate new price
            // Update price
            // Print: Updated Price: <newPrice>
            if(newPrice<0){
                Console.WriteLine("The price is invalid.Book price can not be updated");
                return;
            }
            _book.Price=newPrice;
            Console.WriteLine("Updated Price: "+_book.Price);
        }

        public void UpdateBookStock(int newStock)
        {
            // TODO:
            // Validate new stock
            // Update stock
            // Print: Updated Stock: <newStock>
            if(newStock<0){
                Console.WriteLine("The new stock is invalid. Book stock can not be updated");
                return;
            }
            _book.Stock=newStock;
            Console.WriteLine("Updated Stock: "+_book.Stock);
        }
    }
}
