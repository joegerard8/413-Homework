import { useState } from 'react';
import { Book } from '../types/Book';
import { updateBook } from '../api/BooksAPI';

interface NewBookFormProps {
    book: Book;
    onSuccess: () => void;
    onCancel: () => void;
}
const EditBookForm = ({ onSuccess, onCancel, book }: NewBookFormProps) => {
  const [formData, setFormData] = useState<Book>({...book}); // Initialize with the book data passed in as a prop
    
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };
  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    await updateBook(formData); // just need the formdata, not an id because the form data should include the id
    onSuccess();
  };
  return (
    <form onSubmit={handleSubmit}>
        <h2>Edit Book</h2>
        <div className="form-grid">
            <label>
            Book Name:
            <input
                type="text"
                name="title"
                value={formData.title}
                onChange={handleChange}
            />
            </label>
            <label>
            Author:
            <input
                type="text"
                name="author"
                value={formData.author}
                onChange={handleChange}
            />
            </label>
            <label>
            Publisher:
            <input
                type="text"
                name="publisher"
                value={formData.publisher}
                onChange={handleChange}
            />
            </label>
            <label>
            ISBN:
            <input
                type="text"
                name="isbn"
                value={formData.isbn}
                onChange={handleChange}
            />
            </label>
            <label>
            Classification:
            <input
                type="text"
                name="classification"
                value={formData.classification}
                onChange={handleChange}
            />
            </label>
            <label>
            Category:
            <input
                type="text"
                name="category"
                value={formData.category}
                onChange={handleChange}
            />
            </label>
            <label>
            Page Count:
            <input
                type="number"
                name="pageCount"
                value={formData.pageCount}
                onChange={handleChange}
            />
            </label>
            <label>
            Price:
            <input
                type="number"
                name="price"
                value={formData.price}
                onChange={handleChange}
            />
            </label>
            <button type="submit" className="btn btn-success">Submit Changes</button>
            <button type="button" className="btn btn-danger" onClick={onCancel}>
            Cancel
            </button>
        </div>
    </form>
  );
};
export default EditBookForm;