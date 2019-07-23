import React from "react";

export default function Pagination(props) {
  return (
    <React.Fragment>
      {renderPagination(props.paging, props.querySender)}
    </React.Fragment>
  );
}

const renderPagination = (
  { TotalItems, ItemsPerPage, CurrentPage, TotalPages },
  sendQuery
) => {
  let pages = [];
  let prev = CurrentPage > 1 ? true : false; //check if current page is first page
  let next = CurrentPage === TotalPages ? false : true; //checks if current page is  last page

  for (let i = 1; i <= TotalPages; i++) {
    //add page number with event
    pages.push(
      <li
        key={i}
        class={i === CurrentPage ? "page-item active" : "page-item"}
        aria-current={i === CurrentPage ? "page" : ""}
      >
        <button
          class={
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
          <ul class="pagination d-flex flex-wrap col-md-12">
            <li class={prev ? "page-item" : "page-item disabled"}>
              <button
                class="page-link"
                onClick={() => {
                  sendQuery(CurrentPage - 1);
                }}
                tabindex="-1"
              >
                Previous
              </button>
            </li>
            {pages}

            <li class={next ? "page-item" : "page-item disabled"}>
              <button
                class="page-link"
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
