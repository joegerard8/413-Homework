interface PaginationProps {
    currentPage: number;
    totalPage: number;
    pageSize: number;
    onPageChange: (newPage: number) => void;
    onPageSizeChange: (newSize: number) => void;
}

// pagination component
const Pagination = ({ currentPage, totalPage, pageSize, onPageChange, onPageSizeChange }: PaginationProps) => {
  return (
    <>
      {/* Pagination container class we haven't used either, makes page things look nice. */}
      <div className="pagination-container d-flex justify-content-between align-items-center mb-3">
        <div className="d-flex align-items-center mb-3">
            <button
            className="btn btn-outline-primary me-2"
            onClick={() => onPageChange(currentPage - 1)}
            disabled={currentPage === 1}
            >
            Previous
            </button>

            {[...Array(totalPage)].map((_, index) => (
            <button
                key={index + 1}
                className={`btn ${currentPage === index + 1 ? 'btn-primary' : 'btn-outline-primary'} me-2`}
                onClick={() => onPageChange(index + 1)}
                disabled={currentPage === index + 1}
            >
                {index + 1}
            </button>
            ))}

            <button
            className="btn btn-outline-primary ms-2"
            onClick={() => onPageChange(currentPage + 1)}
            disabled={currentPage === totalPage}
            >
            Next
            </button>
        </div>

        <div className="d-flex align-items-center">
            <div className="me-3">
            <label className="form-label">Results per page:</label>
            <select
                className="form-select w-auto"
                value={pageSize}
                onChange={(e) => {
                onPageSizeChange(Number(e.target.value));
                onPageChange(1); // Reset to page 1 on page size change
                }}
            >
                <option value="5">5</option>
                <option value="10">10</option>
                <option value="20">20</option>
            </select>
            </div>
        </div>
    </div>
    </>
  );
};

export default Pagination;
