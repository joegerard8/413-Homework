import { useState, useEffect } from 'react';
import { Book } from './types/Book';
import './Books.css';

function Books() {
    const [books, setBooks] = useState<Book[]>([]);

    useEffect(() => {
        const fetchBooks = async () => {
            const response = await fetch('https://localhost:7172/api/Books/AllBooks');
            const data = await response.json();
            setBooks(data);
        };
        fetchBooks();
    }, []);
    return (
        <>
        {books.map((b) => 
            <div id="bookCard">
                <div key={b.bookId}>
                    <h1>{b.title}</h1>
                    <p>by</p>
                    <h2>{b.author}</h2>
                    <h2>Published by: {b.publisher}</h2>
                    <h2>{b.isbn}</h2>
                    <h2>{b.classificiation}</h2>
                    <h2>{b.pageCount}</h2>
                    <h2>${b.price}</h2>
                </div>
            </div>
        )}
        </>
    );
}

export default Books;