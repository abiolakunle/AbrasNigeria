import React from "react";

export default function Pagination(props) {
  return (
    <React.Fragment>
      {renderPagination(props.paging, props.querySender)}
    </React.Fragment>
  );
}

const renderPagination = ({ CurrentPage, TotalPages }, sendQuery) => {
  let pages = [];
  let prev = CurrentPage > 1 ? true : false; //check if current page is first page
  let next = CurrentPage === TotalPages ? false : true; //checks if current page is  last page

  for (let i = 1; i <= TotalPages; i++) {
    //add page number with event
    pages.push(
      <li
        key={i}
        className={i === CurrentPage ? "page-item active" : "page-item"}
        aria-current={i === CurrentPage ? "page" : ""}
      >
        <button
          className={
            i < CurrentPage + 23 && i > CurrentPage - 5 ? "page-link" : "d-none"
          }
          href=""
          onClick={() => {
            sendQuery(i);
          }}
        >
          {i}
        </button>
      </li>
    );
  }

  return (
    <React.Fragment>
      {TotalPages > 1 ? (
        <nav aria-label="..." className="d-flex justify-content-center">
          <ul className="pagination d-flex flex-wrap col-md-12">
            <li className={prev ? "page-item" : "page-item disabled"}>
              <button
                className="page-link"
                onClick={() => {
                  sendQuery(CurrentPage - 1);
                }}
                tabIndex="-1"
              >
                Previous
              </button>
            </li>
            {pages}

            <li className={next ? "page-item" : "page-item disabled"}>
              <button
                className="page-link"
                onClick={() => {
                  sendQuery(CurrentPage + 1);
                }}
              >
                Next
              </button>
            </li>
          </ul>
        </nav>
      ) : (
        <div />
      )}
    </React.Fragment>
  );
};
