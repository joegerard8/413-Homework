import { useState, useEffect } from 'react';
import { Book } from './types/Book';
import './Books.css';

function Books() {
    // setting all of our state variables, books array, the results per page, the page you are on, and the total number of pages
    const [books, setBooks] = useState<Book[]>([]);
    const [pageSize, setPageSize] = useState<number>(5);
    const [page, setPage] = useState<number>(1);
    const [numPages, setNumPages] = useState<number>(1);

    useEffect(() => {
        const fetchBooks = async () => {
            const response = await fetch(`https://localhost:7172/api/Books/SomeBooks?pageSize=${pageSize}&page=${page}`, {credentials: 'include'}); // getting the response and passing query parameters
            const data = await response.json();
            setBooks(data.books); // setting the books array 
            console.log(data.count);
            const numberOfPages = Math.ceil(data.count / pageSize);
            setNumPages(numberOfPages); // setting the number of pages state by taking the total count of records and dividing by the amount of records per page
            console.log(numPages);
        }
        fetchBooks();
    }, [pageSize, page]); // dependency array, re runs if the page size or the page changes state

    return (
        <>
        {/** Returned JSX with Bootstrap styling */}
        <div className="container">
            <div className="row d-flex justify-content-center">
                {/** Mapping through the books array to create a card for each book */}
                {books.map((b) => (
                    <div key={b.bookId} className="col-md-6 col-sm-12 mb-4 d-flex justify-content-center">
                        <div className="card shadow-sm hover-scale w-100">
                            <div className="card-body">
                                <h5 className="card-title">{b.title}</h5>
                                <p className="card-text text-muted">by <strong>{b.author}</strong></p>
                                <p className="card-text">Published by: <strong>{b.publisher}</strong></p>
                                <p className="card-text">ISBN: <strong>{b.isbn}</strong></p>
                                <p className="card-text">Classification: <strong>{b.classificiation}</strong></p>
                                <p className="card-text">Page Count: <strong>{b.pageCount}</strong></p>
                                <p className="card-text">
                                    <strong>${b.price}</strong>
                                </p>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        </div>


        {/** Results per page option */}
        <div className="d-flex flex-column justify-content-center align-items-center p-3">
            {/* Pagination Buttons */}
            <div className="pagination-container d-flex align-items-center mb-3">
                <button 
                    className="btn btn-outline-primary me-2" 
                    onClick={() => setPage(page - 1)} 
                    disabled={page === 1}
                >
                    Previous
                </button>
                
                {/* Page Buttons */}
                {[...Array(numPages)].map((_, index) => (
                    <button 
                        key={index + 1} 
                        className={`btn ${page === index + 1 ? 'btn-primary' : 'btn-outline-primary'} me-2`} 
                        onClick={() => setPage(index + 1)}
                        disabled={page === (index + 1)}
                    >
                        {index + 1}
                    </button>
                ))}
                
                <button 
                    className="btn btn-outline-primary ms-2" 
                    onClick={() => setPage(page + 1)} 
                    disabled={page === numPages}
                >
                    Next
                </button>
            </div>

            {/* Results per Page Dropdown */}
            <div className="mt-3">
                <label className="form-label">Results per page:</label>
                <select 
                    className="form-select w-auto" 
                    value={pageSize} 
                    onChange={(p) => {setPageSize(Number(p.target.value));
                        setPage(1);}}
                >
                    <option value="5">5</option>
                    <option value="10">10</option>
                    <option value="20">20</option>
                </select>
            </div>
        </div>

        </>
    );
}

export default Books;
